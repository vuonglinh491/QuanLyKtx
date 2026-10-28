using System;
using System.Configuration;
using System.IO;
using System.Data.SQLite;

namespace QuanLyKtx.Data
{
    public static class DatabaseConnection
    {
        private static readonly string ConnectionString;

        static DatabaseConnection()
        {
            var configStr = ConfigurationManager.ConnectionStrings["DormitoryDB"]?.ConnectionString;
            var databasePath = GetDatabasePath();
            var builder = new SQLiteConnectionStringBuilder(configStr ?? string.Empty)
            {
                DataSource = databasePath,
                ForeignKeys = true
            };
            ConnectionString = builder.ConnectionString;
            EnsureDatabase(databasePath);
            EnsureBuildingCapacityColumn();
            EnsureDefaultAdmin();
        }

        /// <summary>
        /// Lấy chuỗi kết nối hiện tại
        /// </summary>
        public static string GetConnectionString()
        {
            return ConnectionString;
        }

        /// <summary>
        /// Tạo và trả về một kết nối SQLite mới
        /// </summary>
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }

        /// <summary>
        /// Hàm kiểm tra nhanh kết nối đến SQLite
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

        private static void EnsureDatabase(string databasePath)
        {
            if (File.Exists(databasePath))
            {
                return;
            }

            var schemaPath = Path.Combine(AppContext.BaseDirectory, "Database", "DormitoryDB.sql");
            if (!File.Exists(schemaPath))
            {
                throw new FileNotFoundException("Không tìm thấy script khởi tạo SQLite.", schemaPath);
            }

            using var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            using var command = new SQLiteCommand(File.ReadAllText(schemaPath), conn);
            command.ExecuteNonQuery();
        }

        private static void EnsureDefaultAdmin()
        {
            const string adminPasswordHash = "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9";
            using var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            using var command = new SQLiteCommand(@"
                INSERT OR IGNORE INTO Users (Username, PasswordHash, FullName, Role, StudentID, IsActive)
                VALUES ('admin', @PasswordHash, 'Quản Trị Viên KTX', 'QuanLy', NULL, 1);", conn);
            command.Parameters.AddWithValue("@PasswordHash", adminPasswordHash);
            command.ExecuteNonQuery();
        }

        private static void EnsureBuildingCapacityColumn()
        {
            using var conn = new SQLiteConnection(ConnectionString);
            conn.Open();
            using var check = new SQLiteCommand("PRAGMA table_info(Buildings);", conn);
            using var reader = check.ExecuteReader();
            while (reader.Read())
            {
                if (string.Equals(reader["name"]?.ToString(), "Capacity", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }
            }

            using var alter = new SQLiteCommand(
                "ALTER TABLE Buildings ADD COLUMN Capacity INTEGER NOT NULL DEFAULT 0 CHECK (Capacity >= 0);", conn);
            alter.ExecuteNonQuery();
        }

        private static string GetDatabasePath()
        {
            // 1. Kiểm tra ngay cạnh file thực thi (AppContext.BaseDirectory)
            string baseDirDb = Path.Combine(AppContext.BaseDirectory, "DormitoryDB.sqlite");
            if (File.Exists(baseDirDb)) return baseDirDb;

            // 2. Kiểm tra thư mục làm việc hiện tại (Directory.GetCurrentDirectory)
            string currentDirDb = Path.Combine(Directory.GetCurrentDirectory(), "DormitoryDB.sqlite");
            if (File.Exists(currentDirDb)) return currentDirDb;

            // 3. Kiểm tra thư mục con QuanLyKtx-main (khi chạy từ thư mục root giải pháp)
            string subDirDb = Path.Combine(Directory.GetCurrentDirectory(), "QuanLyKtx-main", "DormitoryDB.sqlite");
            if (File.Exists(subDirDb)) return subDirDb;

            // 4. Kiểm tra thư mục gốc dự án khi Debug trong Visual Studio (lùi 3 cấp từ bin/Debug/net8.0-windows)
            string projectRootDb = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "DormitoryDB.sqlite"));
            if (File.Exists(projectRootDb)) return projectRootDb;

            return baseDirDb;
        }
    }
}
