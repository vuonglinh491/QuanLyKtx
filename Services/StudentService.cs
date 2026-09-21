using System;
using System.Data;
using System.Data.SQLite;
using QuanLyKtx.Data;
using QuanLyKtx.Models;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Services
{
    public class StudentService
    {
        /// <summary>
        /// Lấy toàn bộ danh sách sinh viên
        /// </summary>
        public DataTable GetAllStudents()
        {
            string sql = @"
                SELECT 
                    StudentID,
                    StudentCode AS [Mã SV],
                    FullName AS [Họ và tên],
                    strftime('%d/%m/%Y', DateOfBirth) AS [Ngày sinh],
                    Gender AS [Giới tính],
                    Phone AS [Số điện thoại],
                    Email AS [Email],
                    ClassName AS [Lớp],
                    Faculty AS [Khoa],
                    Address AS [Địa chỉ],
                    DateOfBirth
                FROM Students
                ORDER BY StudentID DESC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// Tìm kiếm sinh viên theo Mã SV, Họ tên, SĐT hoặc Lớp
        /// </summary>
        public DataTable SearchStudents(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAllStudents();
            }

            string sql = @"
                SELECT 
                    StudentID,
                    StudentCode AS [Mã SV],
                    FullName AS [Họ và tên],
                    strftime('%d/%m/%Y', DateOfBirth) AS [Ngày sinh],
                    Gender AS [Giới tính],
                    Phone AS [Số điện thoại],
                    Email AS [Email],
                    ClassName AS [Lớp],
                    Faculty AS [Khoa],
                    Address AS [Địa chỉ],
                    DateOfBirth
                FROM Students
                WHERE StudentCode LIKE @kw 
                   OR FullName LIKE @kw 
                   OR Phone LIKE @kw 
                   OR ClassName LIKE @kw
                ORDER BY StudentID DESC";

            var parameters = new SQLiteParameter[]
            {
                new SQLiteParameter("@kw", $"%{keyword.Trim()}%")
            };

            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// Thêm mới một sinh viên và tự động tạo tài khoản đăng nhập mặc định (mật khẩu: 123456)
        /// </summary>
        public bool AddStudent(Student student, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Kiểm tra trùng mã sinh viên
            string checkSql = "SELECT COUNT(1) FROM Students WHERE StudentCode = @StudentCode";
            var count = DatabaseHelper.ExecuteScalar(checkSql, new[] { new SQLiteParameter("@StudentCode", student.StudentCode.Trim()) });
            if (count != null && Convert.ToInt32(count) > 0)
            {
                errorMessage = $"Mã sinh viên '{student.StudentCode}' đã tồn tại trong hệ thống!";
                return false;
            }

            // Thực hiện thêm sinh viên trong một Transaction
            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            using var tran = conn.BeginTransaction();

            try
            {
                string insertStudentSql = @"
                    INSERT INTO Students (StudentCode, FullName, DateOfBirth, Gender, Phone, Email, Address, ClassName, Faculty, CreatedAt)
                    VALUES (@StudentCode, @FullName, @DateOfBirth, @Gender, @Phone, @Email, @Address, @ClassName, @Faculty, CURRENT_TIMESTAMP);
                    SELECT last_insert_rowid();";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@StudentCode", student.StudentCode.Trim()),
                    new SQLiteParameter("@FullName", student.FullName.Trim()),
                    new SQLiteParameter("@DateOfBirth", student.DateOfBirth),
                    new SQLiteParameter("@Gender", student.Gender),
                    new SQLiteParameter("@Phone", student.Phone.Trim()),
                    new SQLiteParameter("@Email", student.Email.Trim()),
                    new SQLiteParameter("@Address", (object?)student.Address?.Trim() ?? DBNull.Value),
                    new SQLiteParameter("@ClassName", student.ClassName.Trim()),
                    new SQLiteParameter("@Faculty", student.Faculty.Trim())
                };

                var newStudentIdObj = DatabaseHelper.ExecuteScalar(insertStudentSql, conn, tran, parameters);
                int newStudentId = Convert.ToInt32(newStudentIdObj);

                // Tự động tạo tài khoản đăng nhập cho sinh viên
                // Username = mã SV viết thường, password = 123456
                string username = student.StudentCode.Trim();
                string passwordHash = PasswordHelper.HashPassword("123456");

                string checkUserSql = "SELECT COUNT(1) FROM Users WHERE Username = @Username";
                var userCount = DatabaseHelper.ExecuteScalar(checkUserSql, conn, tran, new[] { new SQLiteParameter("@Username", username) });

                if (userCount == null || Convert.ToInt32(userCount) == 0)
                {
                    string insertUserSql = @"
                        INSERT INTO Users (Username, PasswordHash, FullName, Role, StudentID, IsActive, CreatedAt)
                        VALUES (@Username, @PasswordHash, @FullName, 'SinhVien', @StudentID, 1, CURRENT_TIMESTAMP)";

                    var userParams = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@Username", username),
                        new SQLiteParameter("@PasswordHash", passwordHash),
                        new SQLiteParameter("@FullName", student.FullName.Trim()),
                        new SQLiteParameter("@StudentID", newStudentId)
                    };

                    DatabaseHelper.ExecuteNonQuery(insertUserSql, conn, tran, userParams);
                }
                else
                {
                    string checkExistingUserSql = @"
                        SELECT COUNT(1)
                        FROM Users
                        WHERE Username = @Username
                          AND Role = 'SinhVien'
                          AND StudentID IS NULL";

                    var reusableUser = DatabaseHelper.ExecuteScalar(
                        checkExistingUserSql,
                        conn,
                        tran,
                        new[] { new SQLiteParameter("@Username", username) });

                    if (reusableUser == null || Convert.ToInt32(reusableUser) == 0)
                    {
                        throw new InvalidOperationException("Tên đăng nhập này đang được sử dụng bởi một tài khoản khác.");
                    }

                    string restoreUserSql = @"
                        UPDATE Users
                        SET PasswordHash = @PasswordHash,
                            FullName = @FullName,
                            StudentID = @StudentID,
                            IsActive = 1
                        WHERE Username = @Username";

                    var restoreUserParams = new SQLiteParameter[]
                    {
                        new SQLiteParameter("@Username", username),
                        new SQLiteParameter("@PasswordHash", passwordHash),
                        new SQLiteParameter("@FullName", student.FullName.Trim()),
                        new SQLiteParameter("@StudentID", newStudentId)
                    };

                    DatabaseHelper.ExecuteNonQuery(restoreUserSql, conn, tran, restoreUserParams);
                }

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                errorMessage = "Lỗi khi thêm sinh viên: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin sinh viên
        /// </summary>
        public bool UpdateStudent(Student student, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Kiểm tra trùng mã sinh viên với người khác
            string checkSql = "SELECT COUNT(1) FROM Students WHERE StudentCode = @StudentCode AND StudentID != @StudentID";
            var parametersCheck = new SQLiteParameter[]
            {
                new SQLiteParameter("@StudentCode", student.StudentCode.Trim()),
                new SQLiteParameter("@StudentID", student.StudentID)
            };

            var count = DatabaseHelper.ExecuteScalar(checkSql, parametersCheck);
            if (count != null && Convert.ToInt32(count) > 0)
            {
                errorMessage = $"Mã sinh viên '{student.StudentCode}' đã được sử dụng bởi sinh viên khác!";
                return false;
            }

            try
            {
                string sql = @"
                    UPDATE Students
                    SET StudentCode = @StudentCode,
                        FullName = @FullName,
                        DateOfBirth = @DateOfBirth,
                        Gender = @Gender,
                        Phone = @Phone,
                        Email = @Email,
                        Address = @Address,
                        ClassName = @ClassName,
                        Faculty = @Faculty
                    WHERE StudentID = @StudentID;

                    -- Cập nhật đồng bộ họ tên trên bảng Users nếu có
                    UPDATE Users
                    SET FullName = @FullName
                    WHERE StudentID = @StudentID;";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@StudentID", student.StudentID),
                    new SQLiteParameter("@StudentCode", student.StudentCode.Trim()),
                    new SQLiteParameter("@FullName", student.FullName.Trim()),
                    new SQLiteParameter("@DateOfBirth", student.DateOfBirth),
                    new SQLiteParameter("@Gender", student.Gender),
                    new SQLiteParameter("@Phone", student.Phone.Trim()),
                    new SQLiteParameter("@Email", student.Email.Trim()),
                    new SQLiteParameter("@Address", (object?)student.Address?.Trim() ?? DBNull.Value),
                    new SQLiteParameter("@ClassName", student.ClassName.Trim()),
                    new SQLiteParameter("@Faculty", student.Faculty.Trim())
                };

                int rows = DatabaseHelper.ExecuteNonQuery(sql, parameters);
                return rows > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi cập nhật sinh viên: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xóa sinh viên khỏi hệ thống
        /// </summary>
        public bool DeleteStudent(int studentId, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Kiểm tra xem sinh viên có đang ở phòng không
            string checkStaying = "SELECT COUNT(1) FROM RoomAssignments WHERE StudentID = @StudentID AND Status = 'Active'";
            var countStaying = DatabaseHelper.ExecuteScalar(checkStaying, new[] { new SQLiteParameter("@StudentID", studentId) });
            if (countStaying != null && Convert.ToInt32(countStaying) > 0)
            {
                errorMessage = "Không thể xóa sinh viên đang có phòng ở kích hoạt! Vui lòng trả phòng cho sinh viên trước khi xóa.";
                return false;
            }

            try
            {
                using var conn = DatabaseConnection.GetConnection();
                conn.Open();
                using var tran = conn.BeginTransaction();

                try
                {
                    var parameter = new[] { new SQLiteParameter("@StudentID", studentId) };
                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE Users SET StudentID = NULL, IsActive = 0 WHERE StudentID = @StudentID",
                        conn,
                        tran,
                        parameter);
                    int rows = DatabaseHelper.ExecuteNonQuery("DELETE FROM Students WHERE StudentID = @StudentID", conn, tran, parameter);
                    tran.Commit();
                    return rows > 0;
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa sinh viên: " + ex.Message;
                return false;
            }
        }
    }
}
