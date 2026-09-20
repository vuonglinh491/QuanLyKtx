using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyKtx.Data
{
    /// <summary>
    /// Lớp hỗ trợ thực thi các câu lệnh SQL với ADO.NET
    /// Đảm bảo sử dụng tham số (SqlParameter) để chống SQL Injection
    /// </summary>
    public static class DatabaseHelper
    {
        /// <summary>
        /// Thực thi câu lệnh SELECT và trả về DataTable
        /// </summary>
        public static DataTable ExecuteQuery(string query, SqlParameter[]? parameters = null)
        {
            var table = new DataTable();
            using var conn = DatabaseConnection.GetConnection();
            using var cmd = new SqlCommand(query, conn);

            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }

            using var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);
            return table;
        }

        /// <summary>
        /// Thực thi câu lệnh INSERT, UPDATE, DELETE và trả về số dòng bị ảnh hưởng
        /// </summary>
        public static int ExecuteNonQuery(string query, SqlParameter[]? parameters = null)
        {
            using var conn = DatabaseConnection.GetConnection();
            using var cmd = new SqlCommand(query, conn);

            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }

            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Thực thi câu lệnh trả về giá trị đơn (SELECT COUNT, SCOPE_IDENTITY, ...)
        /// </summary>
        public static object? ExecuteScalar(string query, SqlParameter[]? parameters = null)
        {
            using var conn = DatabaseConnection.GetConnection();
            using var cmd = new SqlCommand(query, conn);

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
        public static int ExecuteNonQuery(string query, SqlConnection conn, SqlTransaction transaction, SqlParameter[]? parameters = null)
        {
            using var cmd = new SqlCommand(query, conn, transaction);
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Thực thi câu lệnh lấy giá trị đơn trong một Transaction đang mở
        /// </summary>
        public static object? ExecuteScalar(string query, SqlConnection conn, SqlTransaction transaction, SqlParameter[]? parameters = null)
        {
            using var cmd = new SqlCommand(query, conn, transaction);
            if (parameters != null && parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }
            var result = cmd.ExecuteScalar();
            return result == DBNull.Value ? null : result;
        }
    }
}
