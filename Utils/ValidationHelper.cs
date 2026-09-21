using System;
using System.Text.RegularExpressions;

namespace QuanLyKtx.Utils
{
    /// <summary>
    /// Lớp hỗ trợ kiểm tra tính hợp lệ của dữ liệu người dùng nhập
    /// </summary>
    public static class ValidationHelper
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private static readonly Regex PhoneRegex = new Regex(
            @"^(0[3|5|7|8|9])[0-9]{8}$",
            RegexOptions.Compiled);

        /// <summary>
        /// Kiểm tra chuỗi rỗng hoặc chỉ có khoảng trắng
        /// </summary>
        public static bool IsNotEmpty(string? input, string fieldName, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = $"Vui lòng không để trống {fieldName}!";
                return false;
            }
            errorMessage = string.Empty;
            return true;
        }

        /// <summary>
        /// Kiểm tra định dạng Email
        /// </summary>
        public static bool IsValidEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            return EmailRegex.IsMatch(email);
        }

        /// <summary>
        /// Kiểm tra số điện thoại (đầu số Việt Nam: 10 chữ số)
        /// </summary>
        public static bool IsValidPhone(string? phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }
            return PhoneRegex.IsMatch(phone);
        }

        /// <summary>
        /// Kiểm tra số nguyên dương (> 0)
        /// </summary>
        public static bool IsPositiveInteger(string? input, out int value)
        {
            if (int.TryParse(input, out value) && value > 0)
            {
                return true;
            }
            value = 0;
            return false;
        }

        /// <summary>
        /// Kiểm tra số thực không âm (>= 0)
        /// </summary>
        public static bool IsNonNegativeDecimal(string? input, out decimal value)
        {
            if (decimal.TryParse(input, out value) && value >= 0)
            {
                return true;
            }
            value = 0;
            return false;
        }

        /// <summary>
        /// Kiểm tra số thực dương (> 0)
        /// </summary>
        public static bool IsPositiveDecimal(string? input, out decimal value)
        {
            if (decimal.TryParse(input, out value) && value > 0)
            {
                return true;
            }
            value = 0;
            return false;
        }
    }
}
