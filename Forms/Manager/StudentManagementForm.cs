using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyKtx.Models;
using QuanLyKtx.Services;
using QuanLyKtx.Utils;
using StudentModel = QuanLyKtx.Models.Student;

namespace QuanLyKtx.Forms.Manager
{
    public partial class StudentManagementForm : Form
    {
        private readonly StudentService _studentService;
        private int _selectedStudentId = 0;

        public StudentManagementForm()
        {
            InitializeComponent();
            _studentService = new StudentService();
        }

        private void StudentManagementForm_Load(object? sender, EventArgs e)
        {
            cboGender.SelectedIndex = 0; // Mặc định là "Nam"
            dtpDateOfBirth.Value = new DateTime(2004, 1, 1);
            SetupDataGridViewStyle();
            LoadStudents();
        }

        private void SetupDataGridViewStyle()
        {
            DataGridViewHelper.Configure(dgvStudents);
            ScrollableControlHelper.Configure(grpInfo);
            dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvStudents.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvStudents.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvStudents.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadStudents()
        {
            try
            {
                var table = _studentService.GetAllStudents();
                dgvStudents.DataSource = table;

                // Ẩn cột StudentID và DateOfBirth thô
                if (dgvStudents.Columns["StudentID"] != null)
                {
                    dgvStudents.Columns["StudentID"].Visible = false;
                }
                if (dgvStudents.Columns["DateOfBirth"] != null)
                {
                    dgvStudents.Columns["DateOfBirth"].Visible = false;
                }

                ConfigureStudentGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            try
            {
                string kw = txtSearch.Text.Trim();
                var table = _studentService.SearchStudents(kw);
                dgvStudents.DataSource = table;
                ConfigureStudentGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureStudentGrid()
        {
            if (dgvStudents.Columns.Count == 0) return;

            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvStudents.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvStudents.AllowUserToResizeRows = false;

            string[] columnNames = { "Mã SV", "Họ và tên", "Ngày sinh", "Giới tính", "Số điện thoại", "Email", "Lớp", "Khoa", "Địa chỉ" };
            int[] columnWidths = { 78, 145, 82, 70, 105, 165, 80, 125, 150 };
            for (int index = 0; index < columnNames.Length; index++)
            {
                if (dgvStudents.Columns[columnNames[index]] != null)
                {
                    dgvStudents.Columns[columnNames[index]].Width = columnWidths[index];
                }
            }

            dgvStudents.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        private void txtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadStudents();
            ClearInputForm();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var student = new StudentModel
            {
                StudentCode = txtStudentCode.Text.Trim().ToUpper(),
                FullName = txtFullName.Text.Trim(),
                DateOfBirth = dtpDateOfBirth.Value.Date,
                Gender = cboGender.SelectedItem?.ToString() ?? "Nam",
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                ClassName = txtClassName.Text.Trim(),
                Faculty = txtFaculty.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };

            if (_studentService.AddStudent(student, out string error))
            {
                MessageBox.Show(
                    $"Thêm mới sinh viên thành công!\nĐã tạo tài khoản: {student.StudentCode.ToLower()} (mật khẩu mặc định: 123456)",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadStudents();
                ClearInputForm();
            }
            else
            {
                MessageBox.Show(error, "Lỗi thêm sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (_selectedStudentId == 0)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên từ danh sách bên phải để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInputs()) return;

            var student = new StudentModel
            {
                StudentID = _selectedStudentId,
                StudentCode = txtStudentCode.Text.Trim().ToUpper(),
                FullName = txtFullName.Text.Trim(),
                DateOfBirth = dtpDateOfBirth.Value.Date,
                Gender = cboGender.SelectedItem?.ToString() ?? "Nam",
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                ClassName = txtClassName.Text.Trim(),
                Faculty = txtFaculty.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };

            if (_studentService.UpdateStudent(student, out string error))
            {
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudents();
                ClearInputForm();
            }
            else
            {
                MessageBox.Show(error, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedStudentId == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa từ danh sách bên phải!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sinh viên [{txtStudentCode.Text} - {txtFullName.Text}] không?\n(Thao tác này sẽ xóa cả tài khoản và dữ liệu liên quan)",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_studentService.DeleteStudent(_selectedStudentId, out string error))
                {
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                    ClearInputForm();
                }
                else
                {
                    MessageBox.Show(error, "Lỗi xóa sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearInputForm();
        }

        private void dgvStudents_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvStudents.Rows.Count) return;

            var row = dgvStudents.Rows[e.RowIndex];
            if (row.Cells["StudentID"].Value != null)
            {
                _selectedStudentId = Convert.ToInt32(row.Cells["StudentID"].Value);
                txtStudentCode.Text = row.Cells["Mã SV"].Value?.ToString() ?? string.Empty;
                txtFullName.Text = row.Cells["Họ và tên"].Value?.ToString() ?? string.Empty;

                if (row.Cells["DateOfBirth"].Value != null && DateTime.TryParse(row.Cells["DateOfBirth"].Value.ToString(), out DateTime dob))
                {
                    dtpDateOfBirth.Value = dob;
                }

                string gender = row.Cells["Giới tính"].Value?.ToString() ?? "Nam";
                cboGender.SelectedItem = gender;

                txtPhone.Text = row.Cells["Số điện thoại"].Value?.ToString() ?? string.Empty;
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? string.Empty;
                txtClassName.Text = row.Cells["Lớp"].Value?.ToString() ?? string.Empty;
                txtFaculty.Text = row.Cells["Khoa"].Value?.ToString() ?? string.Empty;
                txtAddress.Text = row.Cells["Địa chỉ"].Value?.ToString() ?? string.Empty;
            }
        }

        private bool ValidateInputs()
        {
            if (!ValidationHelper.IsNotEmpty(txtStudentCode.Text, "Mã sinh viên", out string errCode))
            {
                MessageBox.Show(errCode, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentCode.Focus();
                return false;
            }

            if (!ValidationHelper.IsNotEmpty(txtFullName.Text, "Họ và tên", out string errName))
            {
                MessageBox.Show(errName, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (!ValidationHelper.IsNotEmpty(txtPhone.Text, "Số điện thoại", out string errPhone))
            {
                MessageBox.Show(errPhone, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            if (!ValidationHelper.IsValidPhone(txtPhone.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập số điện thoại 10 chữ số (vd: 0912345678).", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            if (!ValidationHelper.IsNotEmpty(txtEmail.Text, "Email", out string errEmail))
            {
                MessageBox.Show(errEmail, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!ValidationHelper.IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Email không đúng định dạng! (vd: sinhvien@gmail.com)", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!ValidationHelper.IsNotEmpty(txtClassName.Text, "Lớp", out string errClass))
            {
                MessageBox.Show(errClass, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClassName.Focus();
                return false;
            }

            if (!ValidationHelper.IsNotEmpty(txtFaculty.Text, "Khoa", out string errFaculty))
            {
                MessageBox.Show(errFaculty, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFaculty.Focus();
                return false;
            }

            return true;
        }

        private void ClearInputForm()
        {
            _selectedStudentId = 0;
            txtStudentCode.Clear();
            txtFullName.Clear();
            dtpDateOfBirth.Value = new DateTime(2004, 1, 1);
            cboGender.SelectedIndex = 0;
            txtPhone.Clear();
            txtEmail.Clear();
            txtClassName.Clear();
            txtFaculty.Clear();
            txtAddress.Clear();
            txtStudentCode.Focus();
        }
    }
}
