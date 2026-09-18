namespace QuanLyKtx.Utils
{
    /// <summary>
    /// Lưu trữ thông tin phiên làm việc của người dùng sau khi đăng nhập
    /// </summary>
    public static class Session
    {
        public static int UserID { get; set; }
        public static string Username { get; set; } = string.Empty;
        public static string FullName { get; set; } = string.Empty;
        public static string Role { get; set; } = string.Empty; // "QuanLy" hoặc "SinhVien"
        public static int? StudentID { get; set; }

        public static bool IsLoggedIn => UserID > 0;
        public static bool IsManager => Role.Equals("QuanLy", StringComparison.OrdinalIgnoreCase);
        public static bool IsStudent => Role.Equals("SinhVien", StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Xóa sạch thông tin phiên khi đăng xuất
        /// </summary>
        public static void Clear()
        {
            UserID = 0;
            Username = string.Empty;
            FullName = string.Empty;
            Role = string.Empty;
            StudentID = null;
        }
    }
}
