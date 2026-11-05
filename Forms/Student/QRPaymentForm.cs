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
            _paymentType    = string.IsNullOrWhiteSpace(paymentType) ? "Thanh toán KTX" : paymentType;
            _description    = description ?? string.Empty;
            _studentCode    = string.IsNullOrWhiteSpace(studentCode) ? "SV" : studentCode;
            _paymentService = new PaymentService();

            ApplyUITheme();
            PopulateInfo();
        }

        private void QRPaymentForm_Load(object? sender, EventArgs e)
        {
            ApplyUITheme();
            PopulateInfo();
            // Tự động tạo mã QR VietQR ngay khi mở giao diện
            btnGenerateQR_Click(btnGenerateQR, EventArgs.Empty);
        }

        private void ApplyUITheme()
        {
            UITheme.ApplyPrimaryButton(btnGenerateQR, "📱  Tạo lại mã QR");
            UITheme.ApplySecondaryButton(btnSaveQR, "💾  Lưu ảnh QR");
            UITheme.ApplySuccessButton(btnMarkPaid, "✅  Xác nhận đã thanh toán");
            UITheme.ApplySecondaryButton(btnClose, "Đóng");
        }

        // ─────────────────────────────────────────────────────────────
        // HIỂN THỊ THÔNG TIN KHOẢN CẦN THANH TOÁN
        // ─────────────────────────────────────────────────────────────
        private void PopulateInfo()
        {
            lblPaymentTypeValue.Text = string.IsNullOrWhiteSpace(_paymentType) ? "Thanh toán KTX" : _paymentType;
            lblAmountValue.Text      = _amount.ToString("N0") + " VNĐ";

            string note = string.IsNullOrWhiteSpace(_description) ? _paymentType : _description;
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
                                     "Sau khi chuyển thành công, nhấn \"Xác nhận đã thanh toán\" để gửi yêu cầu duyệt tới Admin.";
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
                btnGenerateQR.Text    = "📱  Tạo lại mã QR";
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
        // XÁC NHẬN ĐÃ THANH TOÁN (GỬI YÊU CẦU ĐỐI SOÁT TỚI ADMIN)
        // ─────────────────────────────────────────────────────────────
        private void btnMarkPaid_Click(object? sender, EventArgs e)
        {
            using var confirmDlg = new Form
            {
                Text = "Xác nhận đã chuyển khoản - Gửi Admin duyệt",
                Size = new Size(500, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            var lblHeader = new Label
            {
                Text = $"Xác nhận đã chuyển khoản {_amount:N0} VNĐ?",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 76, 129),
                Location = new Point(20, 16),
                Size = new Size(445, 26)
            };

            var lblSub = new Label
            {
                Text = $"Khoản chi phí: {_paymentType}\n" +
                       "Hệ thống sẽ gửi yêu cầu đối soát ngân hàng tới Ban quản lý KTX.\n" +
                       "Bạn có thể nhập Mã giao dịch ngân hàng / Tên tài khoản chuyển tiền:",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(20, 48),
                Size = new Size(445, 54)
            };

            var txtNote = new TextBox
            {
                Location = new Point(20, 110),
                Size = new Size(445, 27),
                Font = new Font("Segoe UI", 10F),
                PlaceholderText = "VD: Đã CK từ VCB lúc 08:30, MaGD 123456789..."
            };

            var pnlActions = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.FromArgb(248, 250, 252)
            };

            var btnConfirm = new Button
            {
                Text = "📩  Gửi yêu cầu tới Admin",
                DialogResult = DialogResult.OK,
                Size = new Size(195, 36),
                Location = new Point(140, 12),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };
            UITheme.ApplySuccessButton(btnConfirm, "📩  Gửi yêu cầu tới Admin");

            var btnCancel = new Button
            {
                Text = "Hủy bỏ",
                DialogResult = DialogResult.Cancel,
                Size = new Size(95, 36),
                Location = new Point(345, 12),
                Font = new Font("Segoe UI", 9.5F)
            };
            UITheme.ApplySecondaryButton(btnCancel, "Hủy bỏ");

            pnlActions.Controls.Add(btnConfirm);
            pnlActions.Controls.Add(btnCancel);
            confirmDlg.AcceptButton = btnConfirm;
            confirmDlg.CancelButton = btnCancel;

            confirmDlg.Controls.Add(pnlActions);
            confirmDlg.Controls.Add(txtNote);
            confirmDlg.Controls.Add(lblSub);
            confirmDlg.Controls.Add(lblHeader);

            if (confirmDlg.ShowDialog(this) == DialogResult.OK)
            {
                string note = txtNote.Text.Trim();
                if (_paymentService.RequestPaymentConfirmation(_paymentId, note, out string error))
                {
                    _markedPaid = true;
                    MessageBox.Show(
                        "✅ Đã gửi yêu cầu xác nhận thanh toán thành công!\n\n" +
                        "Hệ thống đã chuyển khoản phí này sang trạng thái \"⏳ Chờ Admin duyệt\".\n" +
                        "Ban quản lý KTX sẽ kiểm tra sao kê ngân hàng và phê duyệt hoàn tất cho bạn.",
                        "Gửi yêu cầu thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Lỗi gửi yêu cầu: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
