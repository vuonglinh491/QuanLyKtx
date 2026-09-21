using System;
using System.Security.Cryptography;
using System.Text;

namespace QuanLyKtx.Utils
{
    /// <summary>
    /// Lớp hỗ trợ băm và kiểm tra mật khẩu sử dụng SHA-256
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// Băm chuỗi mật khẩu thô sang mã băm SHA-256 dạng Hex
        /// </summary>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return string.Empty;
            }

            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = sha256.ComputeHash(bytes);

            var sb = new StringBuilder();
            foreach (var b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// So khớp mật khẩu người dùng nhập vào với chuỗi băm trong CSDL
        /// </summary>
        public static bool VerifyPassword(string inputPassword, string storedHash)
        {
            if (string.IsNullOrEmpty(inputPassword) || string.IsNullOrEmpty(storedHash))
            {
                return false;
            }

            var inputHash = HashPassword(inputPassword);
            return string.Equals(inputHash, storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
