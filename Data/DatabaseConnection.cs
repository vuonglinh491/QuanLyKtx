using System;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace QuanLyKtx.Data
{
    public static class DatabaseConnection
    {
        private static readonly string ConnectionString;

        static DatabaseConnection()
        {
            var configStr = ConfigurationManager.ConnectionStrings["DormitoryDB"]?.ConnectionString;
            if (!string.IsNullOrWhiteSpace(configStr))
            {
                ConnectionString = configStr;
            }
            else
            {
                // Chuỗi kết nối dự phòng mặc định nếu App.config chưa đọc được
                ConnectionString = "Server=localhost;Database=DormitoryDB;Trusted_Connection=True;TrustServerCertificate=True;";
            }
        }

        /// <summary>
        /// Lấy chuỗi kết nối hiện tại
        /// </summary>
        public static string GetConnectionString()
        {
            return ConnectionString;
        }

        /// <summary>
        /// Tạo và trả về một đối tượng SqlConnection mới
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Hàm kiểm tra nhanh kết nối đến SQL Server
        /// </summary>
        /// <param name="errorMessage">Thông báo lỗi nếu có</param>
        /// <returns>True nếu kết nối thành công, False nếu thất bại</returns>
        public static bool TestConnection(out string errorMessage)
        {
            try
            {
                using var conn = GetConnection();
                conn.Open();
                errorMessage = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
