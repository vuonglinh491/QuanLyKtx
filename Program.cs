using System;
using System.Data;
using System.Windows.Forms;
using QuanLyKtx.Data;
using QuanLyKtx.Forms;

namespace QuanLyKtx
{
    internal static class Program
    {
        /// <summary>
        /// Điểm khởi chạy chính của ứng dụng Windows Forms
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Cờ kiểm tra kết nối DB dòng lệnh (dành cho kiểm thử)
            if (args != null && args.Length > 0 && args[0] == "--test-db")
            {
                if (DatabaseConnection.TestConnection(out string err))
                {
                    Console.WriteLine("DB_SUCCESS: Ket noi C# .NET 8 den SQL Server DormitoryDB thanh cong!");
                    var dt = DatabaseHelper.ExecuteQuery("SELECT UserID, Username, FullName, Role FROM dbo.Users");
                    Console.WriteLine($"SO_TAI_KHOAN: {dt.Rows.Count}");
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"TAI_KHOAN: {row["Username"]} | {row["FullName"]} | Quyen: {row["Role"]}");
                    }
                }
                else
                {
                    Console.WriteLine("DB_FAILED: " + err);
                }
                return;
            }

            // Khởi động giao diện Windows Forms
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}