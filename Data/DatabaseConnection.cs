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
#if DEBUG
            return Path.Combine(Directory.GetCurrentDirectory(), "DormitoryDB.sqlite");
#else
            return Path.Combine(AppContext.BaseDirectory, "DormitoryDB.sqlite");
#endif
        }
    }
}
