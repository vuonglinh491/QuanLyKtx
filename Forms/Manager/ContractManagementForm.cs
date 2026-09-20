using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyKtx.Models;
using QuanLyKtx.Services;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Manager
{
    public partial class ContractManagementForm : Form
    {
        private readonly ContractService _contractService;
        private int _selectedContractId = 0;

        public ContractManagementForm()
        {
            InitializeComponent();
            _contractService = new ContractService();
        }

        private void ContractManagementForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            cboFilterStatus.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddMonths(10);
            LoadDropdowns();
            LoadContracts();
        }

        private void SetupDataGridViewStyle()
        {
            DataGridViewHelper.Configure(dgvContracts);
            ScrollableControlHelper.Configure(grpInfo);
            dgvContracts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvContracts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvContracts.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvContracts.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvContracts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvContracts.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadDropdowns()
        {
            try
            {
                var dtStudents = _contractService.GetStudentsForContract();
                cboStudent.DataSource = dtStudents;
                cboStudent.DisplayMember = "StudentDisplayName";
                cboStudent.ValueMember = "StudentID";

                var dtRooms = _contractService.GetRoomsForContract();
                cboRoom.DataSource = dtRooms;
                cboRoom.DisplayMember = "RoomDisplayName";
                cboRoom.ValueMember = "RoomID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private void LoadContracts()
        {
            try
            {
                string? status = null;
                if (cboFilterStatus.SelectedIndex == 1) status = "Active";
                else if (cboFilterStatus.SelectedIndex == 2) status = "Expired";
                else if (cboFilterStatus.SelectedIndex == 3) status = "Terminated";

                string kw = txtSearch.Text.Trim();

                var table = _contractService.GetAllContracts(status, kw);
                dgvContracts.DataSource = table;

                if (dgvContracts.Columns["ContractID"] != null) dgvContracts.Columns["ContractID"].Visible = false;
                if (dgvContracts.Columns["StudentID"] != null) dgvContracts.Columns["StudentID"].Visible = false;
                if (dgvContracts.Columns["RoomID"] != null) dgvContracts.Columns["RoomID"].Visible = false;
                if (dgvContracts.Columns["StatusCode"] != null) dgvContracts.Columns["StatusCode"].Visible = false;
                if (dgvContracts.Columns["StartDate"] != null) dgvContracts.Columns["StartDate"].Visible = false;
                if (dgvContracts.Columns["EndDate"] != null) dgvContracts.Columns["EndDate"].Visible = false;

                if (dgvContracts.Columns["Mã HĐ"] != null) dgvContracts.Columns["Mã HĐ"].Width = 80;
                if (dgvContracts.Columns["Mã SV"] != null) dgvContracts.Columns["Mã SV"].Width = 80;
                if (dgvContracts.Columns["Họ và tên"] != null) dgvContracts.Columns["Họ và tên"].Width = 140;
                if (dgvContracts.Columns["Khu nhà"] != null) dgvContracts.Columns["Khu nhà"].Width = 90;
                if (dgvContracts.Columns["Số phòng"] != null) dgvContracts.Columns["Số phòng"].Width = 80;
                if (dgvContracts.Columns["Ngày bắt đầu"] != null) dgvContracts.Columns["Ngày bắt đầu"].Width = 95;
                if (dgvContracts.Columns["Ngày kết thúc"] != null) dgvContracts.Columns["Ngày kết thúc"].Width = 95;

                if (dgvContracts.Columns["Tiền phòng/tháng"] != null)
                {
                    dgvContracts.Columns["Tiền phòng/tháng"].Width = 110;
                    dgvContracts.Columns["Tiền phòng/tháng"].DefaultCellStyle.Format = "N0";
                }

                if (dgvContracts.Columns["Tiền đặt cọc"] != null)
                {
                    dgvContracts.Columns["Tiền đặt cọc"].Width = 100;
                    dgvContracts.Columns["Tiền đặt cọc"].DefaultCellStyle.Format = "N0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboRoom_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboRoom.SelectedItem is DataRowView rowView)
            {
                if (rowView.Row["Price"] != DBNull.Value)
                {
                    decimal price = Convert.ToDecimal(rowView.Row["Price"]);
                    txtMonthlyFee.Text = price.ToString("F0");
                    if (string.IsNullOrWhiteSpace(txtDeposit.Text) || txtDeposit.Text == "0")
                    {
                        txtDeposit.Text = price.ToString("F0");
                    }
                }
            }
        }

        private void cboFilterStatus_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadContracts();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadContracts();
        }

        private void txtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadContracts();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterStatus.SelectedIndex = 0;
            LoadContracts();
            ClearInputForm();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs(out Contract contract)) return;

            if (_contractService.AddContract(contract, out string error))
            {
                MessageBox.Show("Tạo hợp đồng thuê phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadContracts();
                ClearInputForm();
            }
            else
            {
                MessageBox.Show(error, "Lỗi tạo hợp đồng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (_selectedContractId == 0)
            {
                MessageBox.Show("Vui lòng chọn một hợp đồng từ bảng bên phải để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInputs(out Contract contract)) return;
            contract.ContractID = _selectedContractId;

            if (_contractService.UpdateContract(contract, out string error))
            {
                MessageBox.Show("Cập nhật hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadContracts();
                ClearInputForm();
            }
            else
            {
                MessageBox.Show(error, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTerminate_Click(object? sender, EventArgs e)
        {
            if (_selectedContractId == 0)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần thanh lý từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn thanh lý hợp đồng này không? (Trạng thái sẽ đổi thành Đã thanh lý)",
                "Xác nhận thanh lý",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_contractService.TerminateContract(_selectedContractId, out string error))
                {
                    MessageBox.Show("Thanh lý hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadContracts();
                    ClearInputForm();
                }
                else
                {
                    MessageBox.Show(error, "Lỗi thanh lý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedContractId == 0)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa hợp đồng này khỏi hệ thống không?",
                "Xác nhận xóa hợp đồng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_contractService.DeleteContract(_selectedContractId, out string error))
                {
                    MessageBox.Show("Xóa hợp đồng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadContracts();
                    ClearInputForm();
                }
                else
                {
                    MessageBox.Show(error, "Lỗi xóa hợp đồng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearInputForm();
        }

        private void dgvContracts_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvContracts.Rows.Count) return;

            var row = dgvContracts.Rows[e.RowIndex];
            if (row.Cells["ContractID"].Value != null)
            {
                _selectedContractId = Convert.ToInt32(row.Cells["ContractID"].Value);

                if (row.Cells["StudentID"].Value != null)
                {
                    cboStudent.SelectedValue = Convert.ToInt32(row.Cells["StudentID"].Value);
                }
                if (row.Cells["RoomID"].Value != null)
                {
                    cboRoom.SelectedValue = Convert.ToInt32(row.Cells["RoomID"].Value);
                }

                if (row.Cells["StartDate"].Value != null && DateTime.TryParse(row.Cells["StartDate"].Value.ToString(), out DateTime sDate))
                {
                    dtpStartDate.Value = sDate;
                }
                if (row.Cells["EndDate"].Value != null && DateTime.TryParse(row.Cells["EndDate"].Value.ToString(), out DateTime eDate))
                {
                    dtpEndDate.Value = eDate;
                }

                if (row.Cells["Tiền phòng/tháng"].Value != null)
                {
                    txtMonthlyFee.Text = Convert.ToDecimal(row.Cells["Tiền phòng/tháng"].Value).ToString("F0");
                }
                if (row.Cells["Tiền đặt cọc"].Value != null)
                {
                    txtDeposit.Text = Convert.ToDecimal(row.Cells["Tiền đặt cọc"].Value).ToString("F0");
                }

                string statusCode = row.Cells["StatusCode"].Value?.ToString() ?? "Active";
                if (statusCode == "Active") cboStatus.SelectedIndex = 0;
                else if (statusCode == "Expired") cboStatus.SelectedIndex = 1;
                else if (statusCode == "Terminated") cboStatus.SelectedIndex = 2;
            }
        }

        private bool ValidateInputs(out Contract contract)
        {
            contract = new Contract();

            if (cboStudent.SelectedValue == null || !int.TryParse(cboStudent.SelectedValue.ToString(), out int studentId) || studentId <= 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboStudent.Focus();
                return false;
            }

            if (cboRoom.SelectedValue == null || !int.TryParse(cboRoom.SelectedValue.ToString(), out int roomId) || roomId <= 0)
            {
                MessageBox.Show("Vui lòng chọn phòng!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRoom.Focus();
                return false;
            }

            if (dtpEndDate.Value.Date < dtpStartDate.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc hợp đồng không thể trước ngày bắt đầu!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpEndDate.Focus();
                return false;
            }

            if (!decimal.TryParse(txtMonthlyFee.Text.Trim(), out decimal fee) || fee < 0)
            {
                MessageBox.Show("Tiền phòng hàng tháng phải là số không âm (>= 0)!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonthlyFee.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDeposit.Text.Trim(), out decimal deposit) || deposit < 0)
            {
                MessageBox.Show("Tiền đặt cọc phải là số không âm (>= 0)!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDeposit.Focus();
                return false;
            }

            string status = "Active";
            if (cboStatus.SelectedIndex == 1) status = "Expired";
            else if (cboStatus.SelectedIndex == 2) status = "Terminated";

            contract.StudentID = studentId;
            contract.RoomID = roomId;
            contract.StartDate = dtpStartDate.Value.Date;
            contract.EndDate = dtpEndDate.Value.Date;
            contract.MonthlyFee = fee;
            contract.Deposit = deposit;
            contract.Status = status;

            return true;
        }

        private void ClearInputForm()
        {
            _selectedContractId = 0;
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddMonths(10);
            txtMonthlyFee.Clear();
            txtDeposit.Clear();
            cboStatus.SelectedIndex = 0;
        }
    }
}
