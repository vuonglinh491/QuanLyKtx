using System;
using System.Data;
using System.Data.SQLite;

namespace QuanLyKtx.Data
{
    /// <summary>
    /// Lớp hỗ trợ thực thi các câu lệnh SQL với ADO.NET
    /// Đảm bảo sử dụng tham số (SQLiteParameter) để chống SQL Injection
    /// </summary>
    public static class DatabaseHelper
    {
        /// <summary>
        /// Thực thi câu lệnh SELECT và trả về DataTable
        /// </summary>
        public static DataTable ExecuteQuery(string query, SQLiteParameter[]? parameters = null)
        {
            var table = new DataTable();
            using var conn = DatabaseConnection.GetConnection();
            using var cmd = new SQLiteCommand(query, conn);

            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }

            using var adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(table);
            return table;
        }

        /// <summary>
        /// Thực thi câu lệnh INSERT, UPDATE, DELETE và trả về số dòng bị ảnh hưởng
        /// </summary>
        public static int ExecuteNonQuery(string query, SQLiteParameter[]? parameters = null)
        {
            using var conn = DatabaseConnection.GetConnection();
            using var cmd = new SQLiteCommand(query, conn);

            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Thực thi câu lệnh trả về giá trị đơn (SELECT COUNT, last_insert_rowid, ...)
        /// </summary>
        public static object? ExecuteScalar(string query, SQLiteParameter[]? parameters = null)
        {
            using var conn = DatabaseConnection.GetConnection();
            using var cmd = new SQLiteCommand(query, conn);

            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }

            conn.Open();
            var result = cmd.ExecuteScalar();
            return result == DBNull.Value ? null : result;
        }

        /// <summary>
        /// Thực thi câu lệnh trong một Transaction đang mở
        /// </summary>
        public static int ExecuteNonQuery(string query, SQLiteConnection conn, SQLiteTransaction transaction, SQLiteParameter[]? parameters = null)
        {
            using var cmd = new SQLiteCommand(query, conn, transaction);
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Thực thi câu lệnh lấy giá trị đơn trong một Transaction đang mở
        /// </summary>
        public static object? ExecuteScalar(string query, SQLiteConnection conn, SQLiteTransaction transaction, SQLiteParameter[]? parameters = null)
        {
            using var cmd = new SQLiteCommand(query, conn, transaction);
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            var result = cmd.ExecuteScalar();
            return result == DBNull.Value ? null : result;
        }
    }
}
