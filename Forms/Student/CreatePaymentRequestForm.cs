using System;
using System.Windows.Forms;
using QuanLyKtx.Models;
using QuanLyKtx.Services;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Student
{
    public partial class CreatePaymentRequestForm : Form
    {
        private readonly PaymentService _paymentService;

        public CreatePaymentRequestForm()
        {
            InitializeComponent();
            _paymentService = new PaymentService();
        }

        private void CreatePaymentRequestForm_Load(object? sender, EventArgs e)
        {
            if (cboPaymentType.Items.Count > 0)
                cboPaymentType.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            if (!Session.StudentID.HasValue)
            {
                MessageBox.Show("Không tìm thấy thông tin sinh viên phiên hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text.Trim(), out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Số tiền thanh toán phải lớn hơn 0 và là số hợp lệ!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            var payment = new Payment
            {
                StudentID = Session.StudentID.Value,
                ContractID = null,
                PaymentDate = DateTime.Today,
                Amount = amount,
                PaymentType = cboPaymentType.SelectedItem?.ToString() ?? "Khác",
                Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim(),
                Status = "Pending" // Lưu vào DB trạng thái Pending để sau đó quét QR và Admin/Sinh viên xác nhận
            };

            if (_paymentService.AddPayment(payment, out string error))
            {
                MessageBox.Show("✅ Đã lưu yêu cầu thanh toán vào hệ thống Database!\nBạn có thể quét mã QR để chuyển khoản ngay bây giờ.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu vào Database: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
