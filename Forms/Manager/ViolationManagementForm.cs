using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyKtx.Data;
using QuanLyKtx.Models;
using QuanLyKtx.Services;
using StudentModel = QuanLyKtx.Models.Student;

namespace QuanLyKtx.Forms.Manager
{
    public partial class ViolationManagementForm : Form
    {
        private readonly RequestService _requestService;
        private int _selectedViolationId = 0;

        public ViolationManagementForm()
        {
            InitializeComponent();
            _requestService = new RequestService();
        }

        private void ViolationManagementForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            LoadStudentDropdown();

            if (cboViolationType.Items.Count > 0)
                cboViolationType.SelectedIndex = 0;

            if (cboStatus.Items.Count > 0)
                cboStatus.SelectedIndex = 0;

            if (cboFilterStatus.Items.Count > 0)
                cboFilterStatus.SelectedIndex = 0;

            dtpViolationDate.Value = DateTime.Today;
            txtFineAmount.Text = "0";

            LoadViolations();
            UpdateButtonStates();
        }

        private void SetupDataGridViewStyle()
        {
            dgvViolations.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvViolations.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvViolations.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvViolations.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvViolations.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvViolations.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadStudentDropdown()
        {
            try
            {
                string sql = @"
                    SELECT StudentID, StudentCode + ' - ' + FullName AS DisplayName
                    FROM dbo.Students
                    ORDER BY StudentCode";

                var dt = DatabaseHelper.ExecuteQuery(sql);
                cboStudent.DataSource = dt;
                cboStudent.DisplayMember = "DisplayName";
                cboStudent.ValueMember = "StudentID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadViolations()
        {
            try
            {
                string? statusFilter = null;
                if (cboFilterStatus.SelectedIndex == 1) statusFilter = "Unpaid";
                else if (cboFilterStatus.SelectedIndex == 2) statusFilter = "Paid";

                string keyword = txtSearch.Text.Trim();

                var dt = _requestService.GetAllViolations(statusFilter, keyword);
                dgvViolations.DataSource = dt;

                // Ẩn các cột khóa phụ
                if (dgvViolations.Columns.Contains("ViolationID"))
                    dgvViolations.Columns["ViolationID"].Visible = false;
                if (dgvViolations.Columns.Contains("StudentID"))
                    dgvViolations.Columns["StudentID"].Visible = false;
                if (dgvViolations.Columns.Contains("StatusCode"))
                    dgvViolations.Columns["StatusCode"].Visible = false;
                if (dgvViolations.Columns.Contains("ViolationDate"))
                    dgvViolations.Columns["ViolationDate"].Visible = false;

                // Định dạng cột tiền tệ
                if (dgvViolations.Columns.Contains("Tiền phạt (đ)"))
                {
                    dgvViolations.Columns["Tiền phạt (đ)"].DefaultCellStyle.Format = "N0";
                    dgvViolations.Columns["Tiền phạt (đ)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                dgvViolations.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách vi phạm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvViolations_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvViolations.Rows.Count) return;

            var row = dgvViolations.Rows[e.RowIndex];
            if (row.Cells["ViolationID"].Value == null) return;

            _selectedViolationId = Convert.ToInt32(row.Cells["ViolationID"].Value);
            cboStudent.SelectedValue = Convert.ToInt32(row.Cells["StudentID"].Value);

            if (row.Cells["ViolationDate"].Value != null && DateTime.TryParse(row.Cells["ViolationDate"].Value.ToString(), out var vDate))
            {
                dtpViolationDate.Value = vDate;
            }

            string vType = row.Cells["Loại vi phạm"].Value?.ToString() ?? string.Empty;
            if (cboViolationType.Items.Contains(vType))
                cboViolationType.SelectedItem = vType;
            else
                cboViolationType.Text = vType;

            if (row.Cells["Tiền phạt (đ)"].Value != null)
                txtFineAmount.Text = Convert.ToDecimal(row.Cells["Tiền phạt (đ)"].Value).ToString("G29");

            string statusCode = row.Cells["StatusCode"].Value?.ToString() ?? "Unpaid";
            cboStatus.SelectedIndex = (statusCode == "Paid") ? 1 : 0;

            txtDescription.Text = row.Cells["Mô tả chi tiết"].Value?.ToString() ?? string.Empty;

            UpdateButtonStates();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên vi phạm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string vType = cboViolationType.SelectedItem?.ToString() ?? cboViolationType.Text.Trim();
            if (string.IsNullOrWhiteSpace(vType))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập loại vi phạm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtFineAmount.Text.Trim(), out decimal fineAmount) || fineAmount < 0)
            {
                MessageBox.Show("Tiền phạt phải là số hợp lệ không âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var violation = new Violation
            {
                StudentID = Convert.ToInt32(cboStudent.SelectedValue),
                ViolationDate = dtpViolationDate.Value.Date,
                ViolationType = vType,
                FineAmount = fineAmount,
                Status = cboStatus.SelectedIndex == 1 ? "Paid" : "Unpaid",
                Description = txtDescription.Text.Trim()
            };

            if (_requestService.AddViolation(violation, out string errMsg))
            {
                MessageBox.Show("Thêm biên bản vi phạm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadViolations();
            }
            else
            {
                MessageBox.Show(errMsg, "Lỗi thêm vi phạm", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (_selectedViolationId <= 0)
            {
                MessageBox.Show("Vui lòng chọn biên bản vi phạm cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cboStudent.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên vi phạm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string vType = cboViolationType.SelectedItem?.ToString() ?? cboViolationType.Text.Trim();
            if (string.IsNullOrWhiteSpace(vType))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập loại vi phạm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtFineAmount.Text.Trim(), out decimal fineAmount) || fineAmount < 0)
            {
                MessageBox.Show("Tiền phạt phải là số hợp lệ không âm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var violation = new Violation
            {
                ViolationID = _selectedViolationId,
                StudentID = Convert.ToInt32(cboStudent.SelectedValue),
                ViolationDate = dtpViolationDate.Value.Date,
                ViolationType = vType,
                FineAmount = fineAmount,
                Status = cboStatus.SelectedIndex == 1 ? "Paid" : "Unpaid",
                Description = txtDescription.Text.Trim()
            };

            if (_requestService.UpdateViolation(violation, out string errMsg))
            {
                MessageBox.Show("Cập nhật biên bản vi phạm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadViolations();
            }
            else
            {
                MessageBox.Show(errMsg, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedViolationId <= 0)
            {
                MessageBox.Show("Vui lòng chọn biên bản vi phạm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa biên bản vi phạm này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_requestService.DeleteViolation(_selectedViolationId, out string errMsg))
                {
                    MessageBox.Show("Xóa biên bản vi phạm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadViolations();
                }
                else
                {
                    MessageBox.Show(errMsg, "Lỗi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _selectedViolationId = 0;
            if (cboStudent.Items.Count > 0) cboStudent.SelectedIndex = 0;
            if (cboViolationType.Items.Count > 0) cboViolationType.SelectedIndex = 0;
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;
            dtpViolationDate.Value = DateTime.Today;
            txtFineAmount.Text = "0";
            txtDescription.Clear();
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool isSelected = _selectedViolationId > 0;
            btnEdit.Enabled = isSelected;
            btnDelete.Enabled = isSelected;
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadViolations();
        }

        private void txtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadViolations();
            }
        }

        private void cboFilterStatus_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadViolations();
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterStatus.SelectedIndex = 0;
            ClearForm();
            LoadViolations();
        }
    }
}
