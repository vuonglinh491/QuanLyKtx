using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLyKtx.Data;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Student
{
    public partial class StudentProfileForm : Form
    {
        public StudentProfileForm()
        {
            InitializeComponent();
        }

        private void StudentProfileForm_Load(object? sender, EventArgs e)
        {
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            if (!Session.StudentID.HasValue)
            {
                MessageBox.Show("Không xác định được mã sinh viên của phiên đăng nhập hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sql = @"
                    SELECT StudentCode, FullName, DateOfBirth, Gender, Phone, Email, Address, ClassName, Major, Faculty
                    FROM dbo.Students
                    WHERE StudentID = @StudentID";

                var dt = DatabaseHelper.ExecuteQuery(sql, new[] { new SqlParameter("@StudentID", Session.StudentID.Value) });
                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    txtStudentCode.Text = row["StudentCode"].ToString();
                    txtFullName.Text = row["FullName"].ToString();

                    if (row["DateOfBirth"] != DBNull.Value && DateTime.TryParse(row["DateOfBirth"].ToString(), out var dob))
                        txtDob.Text = dob.ToString("dd/MM/yyyy");

                    string g = row["Gender"].ToString() ?? "";
                    txtGender.Text = g == "Male" ? "Nam" : (g == "Female" ? "Nữ" : g);

                    txtClass.Text = row["ClassName"].ToString();
                    txtMajor.Text = row["Major"].ToString();
                    txtFaculty.Text = row["Faculty"].ToString();

                    txtPhone.Text = row["Phone"].ToString();
                    txtEmail.Text = row["Email"].ToString();
                    txtAddress.Text = row["Address"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveContact_Click(object? sender, EventArgs e)
        {
            if (!Session.StudentID.HasValue) return;

            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();

            if (!ValidationHelper.IsValidPhone(phone))
            {
                MessageBox.Show("Số điện thoại không hợp lệ (phải gồm 10 chữ số, bắt đầu bằng 0)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            if (!ValidationHelper.IsValidEmail(email))
            {
                MessageBox.Show("Email không đúng định dạng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Địa chỉ không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return;
            }

            try
            {
                string sql = @"
                    UPDATE dbo.Students
                    SET Phone = @Phone, Email = @Email, Address = @Address
                    WHERE StudentID = @StudentID";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@StudentID", Session.StudentID.Value),
                    new SqlParameter("@Phone", phone),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Address", address)
                };

                int affected = DatabaseHelper.ExecuteNonQuery(sql, parameters);
                if (affected > 0)
                {
                    MessageBox.Show("Cập nhật thông tin liên hệ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể lưu thông tin, vui lòng thử lại sau!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChangePassword_Click(object? sender, EventArgs e)
        {
            string currentPass = txtCurrentPassword.Text.Trim();
            string newPass = txtNewPassword.Text.Trim();
            string confirmPass = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(currentPass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(newPass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (newPass.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp với mật khẩu mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            try
            {
                // Kiểm tra mật khẩu hiện tại trong DB
                string checkSql = "SELECT PasswordHash FROM dbo.Users WHERE UserID = @UserID";
                var objHash = DatabaseHelper.ExecuteScalar(checkSql, new[] { new SqlParameter("@UserID", Session.UserID) });

                if (objHash == null || !PasswordHelper.VerifyPassword(currentPass, objHash.ToString() ?? ""))
                {
                    MessageBox.Show("Mật khẩu hiện tại không chính xác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCurrentPassword.Focus();
                    return;
                }

                // Cập nhật mật khẩu mới
                string newHash = PasswordHelper.HashPassword(newPass);
                string updateSql = "UPDATE dbo.Users SET PasswordHash = @PasswordHash WHERE UserID = @UserID";
                int affected = DatabaseHelper.ExecuteNonQuery(updateSql, new[]
                {
                    new SqlParameter("@PasswordHash", newHash),
                    new SqlParameter("@UserID", Session.UserID)
                });

                if (affected > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCurrentPassword.Clear();
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Không thể đổi mật khẩu, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đổi mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
