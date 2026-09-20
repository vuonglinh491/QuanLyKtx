using System;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyKtx.Data;
using QuanLyKtx.Models;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Services
{
    public class LoginService
    {
        /// <summary>
        /// Xác thực đăng nhập của người dùng từ SQL Server
        /// </summary>
        /// <param name="username">Tên đăng nhập</param>
        /// <param name="password">Mật khẩu thô</param>
        /// <param name="errorMessage">Thông báo lỗi trả về</param>
        /// <returns>Đối tượng User nếu thành công, null nếu thất bại</returns>
        public User? Authenticate(string username, string password, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu!";
                return null;
            }

            string query = @"
                SELECT UserID, Username, PasswordHash, FullName, Role, StudentID, IsActive, CreatedAt
                FROM dbo.Users
                WHERE Username = @Username";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username.Trim())
            };

            var table = DatabaseHelper.ExecuteQuery(query, parameters);
            if (table.Rows.Count == 0)
            {
                errorMessage = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                return null;
            }

            var row = table.Rows[0];
            string role = row["Role"].ToString() ?? string.Empty;
            bool isStudentWithoutRecord = role.Equals("SinhVien", StringComparison.OrdinalIgnoreCase)
                && row["StudentID"] == DBNull.Value;

            if (isStudentWithoutRecord)
            {
                errorMessage = "Tài khoản này không còn nằm trong danh sách sinh viên ở ký túc xá.";
                return null;
            }

            bool isActive = Convert.ToBoolean(row["IsActive"]);
            if (!isActive)
            {
                errorMessage = "Tài khoản này hiện đang bị khóa. Vui lòng liên hệ ban quản lý!";
                return null;
            }

            string storedHash = row["PasswordHash"].ToString() ?? string.Empty;
            if (!PasswordHelper.VerifyPassword(password, storedHash))
            {
                errorMessage = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                return null;
            }

            // Tạo đối tượng User và thiết lập Session
            var user = new User
            {
                UserID = Convert.ToInt32(row["UserID"]),
                Username = row["Username"].ToString() ?? string.Empty,
                PasswordHash = storedHash,
                FullName = row["FullName"].ToString() ?? string.Empty,
                Role = role,
                StudentID = row["StudentID"] == DBNull.Value ? null : Convert.ToInt32(row["StudentID"]),
                IsActive = isActive,
                CreatedAt = Convert.ToDateTime(row["CreatedAt"])
            };

            // Lưu vào Session tĩnh toàn cục
            Session.UserID = user.UserID;
            Session.Username = user.Username;
            Session.FullName = user.FullName;
            Session.Role = user.Role;
            Session.StudentID = user.StudentID;

            return user;
        }
    }
}
