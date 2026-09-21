using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyKtx.Models;
using QuanLyKtx.Services;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Manager
{
    public partial class PaymentManagementForm : Form
    {
        private readonly PaymentService _paymentService;
        private readonly ContractService _contractService;
        private int _selectedPaymentId = 0;

        public PaymentManagementForm()
        {
            InitializeComponent();
            _paymentService = new PaymentService();
            _contractService = new ContractService();
        }

        private void PaymentManagementForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            cboFilterMonth.SelectedIndex = 0;
            cboFilterYear.SelectedIndex = 0;
            cboFilterStatus.SelectedIndex = 0;
            cboPaymentType.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            dtpPaymentDate.Value = DateTime.Today;
            LoadDropdowns();
            LoadPayments();
        }

        private void SetupDataGridViewStyle()
        {
            DataGridViewHelper.Configure(dgvPayments);
            ScrollableControlHelper.Configure(grpInfo);
            dgvPayments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvPayments.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvPayments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvPayments.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadDropdowns()
        {
            try
            {
                var dtStudents = _contractService.GetStudentsForContract();
                cboStudent.DataSource = dtStudents;
                cboStudent.DisplayMember = "StudentDisplayName";
                cboStudent.ValueMember = "StudentID";

                var dtContracts = _contractService.GetAllContracts("Active", null);
                var dtContractChoice = dtContracts.Clone();
                var nullRow = dtContractChoice.NewRow();
                nullRow["ContractID"] = 0;
                nullRow["Mã HĐ"] = "Không gắn hợp đồng";
                dtContractChoice.Rows.InsertAt(nullRow, 0);

                foreach (DataRow r in dtContracts.Rows)
                {
                    dtContractChoice.ImportRow(r);
                }

                cboContract.DataSource = dtContractChoice;
                cboContract.DisplayMember = "Mã HĐ";
                cboContract.ValueMember = "ContractID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private void LoadPayments()
        {
            try
            {
                int? month = null;
                if (cboFilterMonth.SelectedIndex > 0)
                {
                    month = cboFilterMonth.SelectedIndex;
                }

                int? year = null;
                if (cboFilterYear.SelectedIndex > 0 && int.TryParse(cboFilterYear.SelectedItem?.ToString(), out int y))
                {
                    year = y;
                }

                string? status = null;
                if (cboFilterStatus.SelectedIndex == 1) status = "Paid";
                else if (cboFilterStatus.SelectedIndex == 2) status = "Pending";
                else if (cboFilterStatus.SelectedIndex == 3) status = "Cancelled";

                string kw = txtSearch.Text.Trim();

                var table = _paymentService.GetAllPayments(month, year, status, kw);
                dgvPayments.DataSource = table;

                if (dgvPayments.Columns["PaymentID"] != null) dgvPayments.Columns["PaymentID"].Visible = false;
                if (dgvPayments.Columns["StudentID"] != null) dgvPayments.Columns["StudentID"].Visible = false;
                if (dgvPayments.Columns["ContractID"] != null) dgvPayments.Columns["ContractID"].Visible = false;
                if (dgvPayments.Columns["StatusCode"] != null) dgvPayments.Columns["StatusCode"].Visible = false;
                if (dgvPayments.Columns["PaymentDate"] != null) dgvPayments.Columns["PaymentDate"].Visible = false;

                if (dgvPayments.Columns["Mã phiếu"] != null) dgvPayments.Columns["Mã phiếu"].Width = 85;
                if (dgvPayments.Columns["Mã SV"] != null) dgvPayments.Columns["Mã SV"].Width = 80;
                if (dgvPayments.Columns["Họ và tên"] != null) dgvPayments.Columns["Họ và tên"].Width = 140;
                if (dgvPayments.Columns["Ngày nộp"] != null) dgvPayments.Columns["Ngày nộp"].Width = 95;
                if (dgvPayments.Columns["Khoản nộp"] != null) dgvPayments.Columns["Khoản nộp"].Width = 110;
                if (dgvPayments.Columns["Số tiền (đ)"] != null)
                {
                    dgvPayments.Columns["Số tiền (đ)"].Width = 110;
                    dgvPayments.Columns["Số tiền (đ)"].DefaultCellStyle.Format = "N0";
                }
                if (dgvPayments.Columns["Trạng thái"] != null) dgvPayments.Columns["Trạng thái"].Width = 110;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboFilter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadPayments();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadPayments();
        }

        private void txtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadPayments();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterMonth.SelectedIndex = 0;
            cboFilterYear.SelectedIndex = 0;
            cboFilterStatus.SelectedIndex = 0;
            LoadPayments();
            ClearInputForm();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs(out Payment payment)) return;

            if (_paymentService.AddPayment(payment, out string error))
            {
                MessageBox.Show("Lập phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPayments();
                ClearInputForm();
            }
            else
            {
                MessageBox.Show(error, "Lỗi lập phiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (_selectedPaymentId == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu thanh toán từ danh sách bên phải để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInputs(out Payment payment)) return;
            payment.PaymentID = _selectedPaymentId;

            if (_paymentService.UpdatePayment(payment, out string error))
            {
                MessageBox.Show("Cập nhật phiếu thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPayments();
                ClearInputForm();
            }
            else
            {
                MessageBox.Show(error, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedPaymentId == 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu thu cần xóa từ danh sách bên phải!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa phiếu thanh toán này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_paymentService.DeletePayment(_selectedPaymentId, out string error))
                {
                    MessageBox.Show("Xóa phiếu thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPayments();
                    ClearInputForm();
                }
                else
                {
                    MessageBox.Show(error, "Lỗi xóa phiếu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearInputForm();
        }

        private void dgvPayments_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvPayments.Rows.Count) return;

            var row = dgvPayments.Rows[e.RowIndex];
            if (row.Cells["PaymentID"].Value != null)
            {
                _selectedPaymentId = Convert.ToInt32(row.Cells["PaymentID"].Value);

                if (row.Cells["StudentID"].Value != null)
                {
                    cboStudent.SelectedValue = Convert.ToInt32(row.Cells["StudentID"].Value);
                }

                if (row.Cells["ContractID"].Value != DBNull.Value && row.Cells["ContractID"].Value != null)
                {
                    cboContract.SelectedValue = Convert.ToInt32(row.Cells["ContractID"].Value);
                }
                else
                {
                    cboContract.SelectedIndex = 0;
                }

                if (row.Cells["PaymentDate"].Value != null && DateTime.TryParse(row.Cells["PaymentDate"].Value.ToString(), out DateTime pDate))
                {
                    dtpPaymentDate.Value = pDate;
                }

                if (row.Cells["Số tiền (đ)"].Value != null)
                {
                    txtAmount.Text = Convert.ToDecimal(row.Cells["Số tiền (đ)"].Value).ToString("F0");
                }

                string pType = row.Cells["Khoản nộp"].Value?.ToString() ?? "Tiền phòng";
                cboPaymentType.SelectedItem = pType;

                string statusCode = row.Cells["StatusCode"].Value?.ToString() ?? "Paid";
                if (statusCode == "Paid") cboStatus.SelectedIndex = 0;
                else if (statusCode == "Pending") cboStatus.SelectedIndex = 1;
                else if (statusCode == "Cancelled") cboStatus.SelectedIndex = 2;

                txtDescription.Text = row.Cells["Nội dung"].Value?.ToString() ?? string.Empty;

                // Bật/tắt nút duyệt xác nhận thanh toán
                btnConfirmPaid.Enabled    = (statusCode == "Pending");
                btnConfirmPaid.BackColor  = (statusCode == "Pending")
                    ? System.Drawing.Color.FromArgb(16, 185, 129)
                    : System.Drawing.Color.FromArgb(200, 210, 200);
            }
        }

        /// <summary>
        /// Admin duyệt xác nhận khoản "Pending" → "Paid"
        /// </summary>
        private void btnConfirmPaid_Click(object? sender, EventArgs e)
        {
            if (_selectedPaymentId == 0)
            {
                MessageBox.Show("Vui lòng chọn một phiếu thanh toán từ danh sách.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string statusCode = cboStatus.SelectedIndex == 1 ? "Pending" : "Other";
            if (statusCode != "Pending")
            {
                MessageBox.Show("Chỉ có thể xác nhận các khoản đang ở trạng thái \"Chờ xử lý (Pending)\".",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string studentInfo = $"{cboStudent.Text}";
            string amountText  = txtAmount.Text.Trim();

            var confirm = MessageBox.Show(
                $"Xác nhận duyệt khoản thanh toán sau?\n\n" +
                $"   Sinh viên : {studentInfo}\n" +
                $"   Khoản nộp : {cboPaymentType.Text}\n" +
                $"   Số tiền   : {(decimal.TryParse(amountText, out decimal amt) ? amt.ToString("N0") : amountText)} VNĐ\n\n" +
                $"Trạng thái sẽ chuyển từ \"Chờ xử lý\" → \"Đã thanh toán\".",
                "Xác nhận duyệt thanh toán",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            if (_paymentService.MarkAsPaid(_selectedPaymentId, out string error))
            {
                MessageBox.Show("✅ Đã duyệt thanh toán thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPayments();
                ClearInputForm();
            }
            else
            {
                MessageBox.Show("Lỗi: " + error, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs(out Payment payment)
        {
            payment = new Payment();

            if (cboStudent.SelectedValue == null || !int.TryParse(cboStudent.SelectedValue.ToString(), out int studentId) || studentId <= 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên nộp tiền!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboStudent.Focus();
                return false;
            }

            if (!decimal.TryParse(txtAmount.Text.Trim(), out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Số tiền nộp phải là một số dương (> 0)!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }

            int? contractId = null;
            if (cboContract.SelectedValue != null && int.TryParse(cboContract.SelectedValue.ToString(), out int cId) && cId > 0)
            {
                contractId = cId;
            }

            string status = "Paid";
            if (cboStatus.SelectedIndex == 1) status = "Pending";
            else if (cboStatus.SelectedIndex == 2) status = "Cancelled";

            payment.StudentID   = studentId;
            payment.ContractID  = contractId;
            payment.PaymentDate = dtpPaymentDate.Value.Date;
            payment.Amount      = amount;
            payment.PaymentType = cboPaymentType.SelectedItem?.ToString() ?? "Tiền phòng";
            payment.Description = txtDescription.Text.Trim();
            payment.Status      = status;

            return true;
        }

        private void ClearInputForm()
        {
            _selectedPaymentId = 0;
            dtpPaymentDate.Value = DateTime.Today;
            txtAmount.Clear();
            cboPaymentType.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            txtDescription.Clear();
            cboContract.SelectedIndex = 0;
            txtAmount.Focus();
            btnConfirmPaid.Enabled   = false;
            btnConfirmPaid.BackColor = System.Drawing.Color.FromArgb(200, 210, 200);
        }
    }
}
