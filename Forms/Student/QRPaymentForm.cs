using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using QuanLyKtx.Services;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Student
{
    /// <summary>
    /// Form hiển thị mã QR VietQR để sinh viên thanh toán qua ngân hàng
    /// </summary>
    public partial class QRPaymentForm : Form
    {
        private readonly int      _paymentId;
        private readonly decimal  _amount;
        private readonly string   _paymentType;
        private readonly string   _description;
        private readonly string   _studentCode;
        private readonly PaymentService _paymentService;

        private Bitmap? _currentQR;
        private bool    _markedPaid = false;

        /// <summary>
        /// Trả về true nếu sinh viên đã bấm "Đã chuyển khoản xong"
        /// (dùng để caller biết cần reload dữ liệu)
        /// </summary>
        public bool WasMarkedPaid => _markedPaid;

        public QRPaymentForm(int paymentId, decimal amount, string paymentType,
                             string description, string studentCode)
        {
            InitializeComponent();
            _paymentId      = paymentId;
            _amount         = amount;
            _paymentType    = paymentType;
            _description    = description;
            _studentCode    = studentCode;
            _paymentService = new PaymentService();
        }

        private void QRPaymentForm_Load(object? sender, EventArgs e)
        {
            PopulateInfo();
        }

        // ─────────────────────────────────────────────────────────────
        // HIỂN THỊ THÔNG TIN KHOẢN CẦN THANH TOÁN
        // ─────────────────────────────────────────────────────────────
        private void PopulateInfo()
        {
            lblPaymentTypeValue.Text = _paymentType;
            lblAmountValue.Text      = _amount.ToString("N0") + " VNĐ";

            string note = string.IsNullOrWhiteSpace(_description) ? "—" : _description;
            lblDescriptionValue.Text = $"KTX {_studentCode} - {note}";
        }

        // ─────────────────────────────────────────────────────────────
        // TẠO MÃ QR
        // ─────────────────────────────────────────────────────────────
        private async void btnGenerateQR_Click(object? sender, EventArgs e)
        {
            btnGenerateQR.Enabled = false;
            btnGenerateQR.Text    = "⏳  Đang tạo mã QR...";
            picQR.Image           = null;
            lblQRHint.Text        = "Đang kết nối VietQR API...";

            try
            {
                string transferNote = QRCodeHelper.BuildTransferDescription(
                    _studentCode, _paymentType, _paymentId);

                Bitmap? qr = await QRCodeHelper.GenerateVietQRAsync(_amount, transferNote);

                if (qr != null)
                {
                    _currentQR?.Dispose();
                    _currentQR    = qr;
                    picQR.Image   = qr;
                    lblQRHint.Text = "✅ Mở ứng dụng ngân hàng → Quét QR → Xác nhận số tiền → Chuyển khoản.\n" +
                                     "Sau khi chuyển thành công, nhấn \"Đã chuyển khoản xong\".";
                    btnSaveQR.Enabled    = true;
                    btnMarkPaid.Enabled  = true;
                }
                else
                {
                    lblQRHint.Text = "❌ Không thể tạo mã QR. Vui lòng kiểm tra kết nối mạng và thử lại.\n\n" +
                                     "Bạn có thể chuyển khoản thủ công theo thông tin ngân hàng bên trái.";
                }
            }
            catch (Exception ex)
            {
                lblQRHint.Text = $"❌ Lỗi: {ex.Message}";
            }
            finally
            {
                btnGenerateQR.Enabled = true;
                btnGenerateQR.Text    = "⟳  Tạo lại mã QR";
            }
        }

        // ─────────────────────────────────────────────────────────────
        // LƯU ẢNH QR
        // ─────────────────────────────────────────────────────────────
        private void btnSaveQR_Click(object? sender, EventArgs e)
        {
            if (_currentQR == null)
            {
                MessageBox.Show("Chưa có mã QR để lưu. Hãy tạo mã QR trước.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new SaveFileDialog
            {
                Title            = "Lưu ảnh QR thanh toán",
                Filter           = "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg",
                FileName         = $"QR_KTX_{_studentCode}_{_paymentType.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmm}",
                DefaultExt       = "png",
                FilterIndex      = 1
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fmt = dlg.FilterIndex == 1
                    ? System.Drawing.Imaging.ImageFormat.Png
                    : System.Drawing.Imaging.ImageFormat.Jpeg;

                _currentQR.Save(dlg.FileName, fmt);
                MessageBox.Show($"Đã lưu ảnh QR thành công!\n{dlg.FileName}",
                    "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // XÁC NHẬN ĐÃ THANH TOÁN
        // ─────────────────────────────────────────────────────────────
        private void btnMarkPaid_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                $"Bạn xác nhận đã chuyển khoản thành công số tiền:\n\n" +
                $"   {_amount:N0} VNĐ\n\n" +
                $"Trạng thái khoản này sẽ được cập nhật thành \"Đã thanh toán\".\n" +
                $"Vui lòng chỉ xác nhận khi giao dịch ngân hàng đã hoàn tất!",
                "Xác nhận thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            if (_paymentService.MarkAsPaid(_paymentId, out string error))
            {
                _markedPaid = true;
                MessageBox.Show(
                    "✅ Đã ghi nhận thanh toán thành công!\n\nKhoản phí đã được chuyển sang trạng thái \"Đã thanh toán\".",
                    "Thanh toán thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Lỗi cập nhật: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        private void btnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _currentQR?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
