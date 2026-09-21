using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using QuanLyKtx.Data;
using QuanLyKtx.Models;

namespace QuanLyKtx.Services
{
    public class RoomService
    {
        #region QUẢN LÝ KHU NHÀ (BUILDINGS)

        /// <summary>
        /// Lấy toàn bộ danh sách khu nhà
        /// </summary>
        public DataTable GetAllBuildings()
        {
            string sql = @"
                SELECT 
                    b.BuildingID AS [Mã khu],
                    b.BuildingName AS [Tên khu nhà],
                    b.Description AS [Mô tả],
                    b.Capacity AS [Sức chứa khu],
                    COUNT(r.RoomID) AS [Tổng số phòng],
                    COALESCE(SUM(r.CurrentOccupancy), 0) AS [Đang ở]
                FROM Buildings b
                LEFT JOIN Rooms r ON b.BuildingID = r.BuildingID
                GROUP BY b.BuildingID, b.BuildingName, b.Description
                ORDER BY b.BuildingID ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// Thêm khu nhà mới
        /// </summary>
        public bool AddBuilding(Building building, out string errorMessage)
        {
            errorMessage = string.Empty;

            string checkSql = "SELECT COUNT(1) FROM Buildings WHERE BuildingName = @Name";
            var count = DatabaseHelper.ExecuteScalar(checkSql, new[] { new SQLiteParameter("@Name", building.BuildingName.Trim()) });
            if (count != null && Convert.ToInt32(count) > 0)
            {
                errorMessage = $"Tên khu nhà '{building.BuildingName}' đã tồn tại!";
                return false;
            }

            try
            {
                string sql = "INSERT INTO Buildings (BuildingName, Description, Capacity) VALUES (@Name, @Desc, @Capacity)";
                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@Name", building.BuildingName.Trim()),
                    new SQLiteParameter("@Desc", (object?)building.Description?.Trim() ?? DBNull.Value),
                    new SQLiteParameter("@Capacity", building.Capacity)
                };

                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi thêm khu nhà: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin khu nhà
        /// </summary>
        public bool UpdateBuilding(Building building, out string errorMessage)
        {
            errorMessage = string.Empty;

            string checkSql = "SELECT COUNT(1) FROM Buildings WHERE BuildingName = @Name AND BuildingID != @ID";
            var parametersCheck = new SQLiteParameter[]
            {
                new SQLiteParameter("@Name", building.BuildingName.Trim()),
                new SQLiteParameter("@ID", building.BuildingID)
            };

            var count = DatabaseHelper.ExecuteScalar(checkSql, parametersCheck);
            if (count != null && Convert.ToInt32(count) > 0)
            {
                errorMessage = $"Tên khu nhà '{building.BuildingName}' đã được sử dụng bởi khu khác!";
                return false;
            }

            try
            {
                string sql = "UPDATE Buildings SET BuildingName = @Name, Description = @Desc, Capacity = @Capacity WHERE BuildingID = @ID";
                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@ID", building.BuildingID),
                    new SQLiteParameter("@Name", building.BuildingName.Trim()),
                    new SQLiteParameter("@Desc", (object?)building.Description?.Trim() ?? DBNull.Value),
                    new SQLiteParameter("@Capacity", building.Capacity)
                };

                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi cập nhật khu nhà: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xóa khu nhà (chỉ cho phép khi chưa có phòng nào thuộc khu này)
        /// </summary>
        public bool DeleteBuilding(int buildingId, out string errorMessage)
        {
            errorMessage = string.Empty;

            string checkSql = "SELECT COUNT(1) FROM Rooms WHERE BuildingID = @ID";
            var count = DatabaseHelper.ExecuteScalar(checkSql, new[] { new SQLiteParameter("@ID", buildingId) });
            if (count != null && Convert.ToInt32(count) > 0)
            {
                errorMessage = "Khu nhà này đang có phòng trực thuộc! Vui lòng xóa hết các phòng trong khu trước khi xóa khu nhà.";
                return false;
            }

            try
            {
                string sql = "DELETE FROM Buildings WHERE BuildingID = @ID";
                return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SQLiteParameter("@ID", buildingId) }) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa khu nhà: " + ex.Message;
                return false;
            }
        }

        #endregion

        #region QUẢN LÝ PHÒNG (ROOMS)

        /// <summary>
        /// Lấy danh sách phòng có thể lọc theo Khu nhà, Trạng thái, hoặc Từ khóa tìm kiếm
        /// </summary>
        public DataTable GetAllRooms(int? buildingId = null, string? status = null, string? keyword = null)
        {
            var sb = new StringBuilder(@"
                SELECT 
                    r.RoomID,
                    r.BuildingID,
                    b.BuildingName AS [Khu nhà],
                    r.RoomNumber AS [Số phòng],
                    r.Floor AS [Tầng],
                    r.Capacity AS [Sức chứa],
                    r.CurrentOccupancy AS [Đang ở],
                    r.RoomType AS [Loại phòng],
                    r.Price AS [Giá thuê (VNĐ)],
                    CASE r.Status
                        WHEN 'Available' THEN 'Còn chỗ'
                        WHEN 'Full' THEN 'Đầy phòng'
                        WHEN 'Maintenance' THEN 'Bảo trì'
                        ELSE r.Status
                    END AS [Trạng thái],
                    r.Status AS [StatusCode]
                FROM Rooms r
                JOIN Buildings b ON r.BuildingID = b.BuildingID
                WHERE 1=1 ");

            var parameters = new System.Collections.Generic.List<SQLiteParameter>();

            if (buildingId.HasValue && buildingId.Value > 0)
            {
                sb.Append(" AND r.BuildingID = @BuildingID ");
                parameters.Add(new SQLiteParameter("@BuildingID", buildingId.Value));
            }

            if (!string.IsNullOrWhiteSpace(status) && status != "All")
            {
                sb.Append(" AND r.Status = @Status ");
                parameters.Add(new SQLiteParameter("@Status", status));
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sb.Append(" AND (r.RoomNumber LIKE @kw OR b.BuildingName LIKE @kw OR r.RoomType LIKE @kw) ");
                parameters.Add(new SQLiteParameter("@kw", $"%{keyword.Trim()}%"));
            }

            sb.Append(" ORDER BY b.BuildingName ASC, r.Floor ASC, r.RoomNumber ASC");

            return DatabaseHelper.ExecuteQuery(sb.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// Thêm phòng mới
        /// </summary>
        public bool AddRoom(Room room, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (room.Capacity <= 0)
            {
                errorMessage = "Sức chứa phòng phải lớn hơn 0!";
                return false;
            }

            if (room.Price < 0)
            {
                errorMessage = "Giá phòng không được nhỏ hơn 0!";
                return false;
            }

            // Kiểm tra trùng số phòng trong cùng khu nhà
            string checkSql = "SELECT COUNT(1) FROM Rooms WHERE BuildingID = @BuildingID AND RoomNumber = @RoomNumber";
            var parametersCheck = new SQLiteParameter[]
            {
                new SQLiteParameter("@BuildingID", room.BuildingID),
                new SQLiteParameter("@RoomNumber", room.RoomNumber.Trim().ToUpper())
            };

            var count = DatabaseHelper.ExecuteScalar(checkSql, parametersCheck);
            if (count != null && Convert.ToInt32(count) > 0)
            {
                errorMessage = $"Phòng '{room.RoomNumber}' đã tồn tại trong khu nhà này!";
                return false;
            }

            try
            {
                string sql = @"
                    INSERT INTO Rooms (BuildingID, RoomNumber, Floor, Capacity, CurrentOccupancy, RoomType, Price, Status)
                    VALUES (@BuildingID, @RoomNumber, @Floor, @Capacity, 0, @RoomType, @Price, @Status)";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@BuildingID", room.BuildingID),
                    new SQLiteParameter("@RoomNumber", room.RoomNumber.Trim().ToUpper()),
                    new SQLiteParameter("@Floor", room.Floor),
                    new SQLiteParameter("@Capacity", room.Capacity),
                    new SQLiteParameter("@RoomType", room.RoomType.Trim()),
                    new SQLiteParameter("@Price", room.Price),
                    new SQLiteParameter("@Status", string.IsNullOrWhiteSpace(room.Status) ? "Available" : room.Status)
                };

                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi thêm phòng: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin phòng
        /// </summary>
        public bool UpdateRoom(Room room, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (room.Capacity <= 0)
            {
                errorMessage = "Sức chứa phòng phải lớn hơn 0!";
                return false;
            }

            if (room.Capacity < room.CurrentOccupancy)
            {
                errorMessage = $"Sức chứa mới ({room.Capacity}) không thể nhỏ hơn số người đang ở ({room.CurrentOccupancy})!";
                return false;
            }

            // Kiểm tra trùng số phòng trong cùng khu nhà với phòng khác
            string checkSql = "SELECT COUNT(1) FROM Rooms WHERE BuildingID = @BuildingID AND RoomNumber = @RoomNumber AND RoomID != @RoomID";
            var parametersCheck = new SQLiteParameter[]
            {
                new SQLiteParameter("@BuildingID", room.BuildingID),
                new SQLiteParameter("@RoomNumber", room.RoomNumber.Trim().ToUpper()),
                new SQLiteParameter("@RoomID", room.RoomID)
            };

            var count = DatabaseHelper.ExecuteScalar(checkSql, parametersCheck);
            if (count != null && Convert.ToInt32(count) > 0)
            {
                errorMessage = $"Phòng '{room.RoomNumber}' đã tồn tại trong khu nhà này!";
                return false;
            }

            // Tự động điều chỉnh trạng thái nếu sức chứa thay đổi
            string finalStatus = room.Status;
            if (finalStatus != "Maintenance")
            {
                if (room.CurrentOccupancy >= room.Capacity)
                {
                    finalStatus = "Full";
                }
                else
                {
                    finalStatus = "Available";
                }
            }

            try
            {
                string sql = @"
                    UPDATE Rooms
                    SET BuildingID = @BuildingID,
                        RoomNumber = @RoomNumber,
                        Floor = @Floor,
                        Capacity = @Capacity,
                        RoomType = @RoomType,
                        Price = @Price,
                        Status = @Status
                    WHERE RoomID = @RoomID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@RoomID", room.RoomID),
                    new SQLiteParameter("@BuildingID", room.BuildingID),
                    new SQLiteParameter("@RoomNumber", room.RoomNumber.Trim().ToUpper()),
                    new SQLiteParameter("@Floor", room.Floor),
                    new SQLiteParameter("@Capacity", room.Capacity),
                    new SQLiteParameter("@RoomType", room.RoomType.Trim()),
                    new SQLiteParameter("@Price", room.Price),
                    new SQLiteParameter("@Status", finalStatus)
                };

                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi cập nhật phòng: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xóa phòng (chỉ cho phép xóa khi phòng không có ai đang ở)
        /// </summary>
        public bool DeleteRoom(int roomId, out string errorMessage)
        {
            errorMessage = string.Empty;

            string checkStaying = "SELECT CurrentOccupancy FROM Rooms WHERE RoomID = @RoomID";
            var occupancyObj = DatabaseHelper.ExecuteScalar(checkStaying, new[] { new SQLiteParameter("@RoomID", roomId) });
            if (occupancyObj != null && Convert.ToInt32(occupancyObj) > 0)
            {
                errorMessage = "Không thể xóa phòng đang có sinh viên lưu trú! Vui lòng chuyển hoặc trả phòng cho sinh viên trước.";
                return false;
            }

            try
            {
                string sql = "DELETE FROM Rooms WHERE RoomID = @RoomID";
                return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SQLiteParameter("@RoomID", roomId) }) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa phòng: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách phòng còn trống chỗ
        /// </summary>
        public DataTable GetAvailableRooms(int? buildingId = null)
        {
            string sql = @"
                SELECT 
                    r.RoomID,
                    b.BuildingName || ' - Phòng ' || r.RoomNumber || ' (Còn ' || CAST(r.Capacity - r.CurrentOccupancy AS TEXT) || ' chỗ - ' || printf('%,.0f', r.Price) || ' đ)' AS [RoomDisplayName],
                    r.Price
                FROM Rooms r
                JOIN Buildings b ON r.BuildingID = b.BuildingID
                WHERE r.Status = 'Available' AND r.CurrentOccupancy < r.Capacity " +
                (buildingId.HasValue ? " AND r.BuildingID = @BuildingID " : "") +
                " ORDER BY b.BuildingName, r.RoomNumber";

            var parameters = buildingId.HasValue ? new[] { new SQLiteParameter("@BuildingID", buildingId.Value) } : null;
            return DatabaseHelper.ExecuteQuery(sql, parameters);
        }

        #endregion

        #region PHÂN VÀ CHUYỂN PHÒNG (ROOM ASSIGNMENTS)

        /// <summary>
        /// Lấy danh sách phân phòng có lọc theo trạng thái và tìm kiếm
        /// </summary>
        public DataTable GetAllAssignments(string? status = null, string? keyword = null)
        {
            var sb = new StringBuilder(@"
                SELECT 
                    a.AssignmentID,
                    a.StudentID,
                    a.RoomID,
                    s.StudentCode AS [Mã SV],
                    s.FullName AS [Họ và tên],
                    s.Phone AS [SĐT],
                    s.ClassName AS [Lớp],
                    b.BuildingName AS [Khu nhà],
                    r.RoomNumber AS [Số phòng],
                    strftime('%d/%m/%Y', a.StartDate) AS [Ngày vào ở],
                    CASE WHEN a.EndDate IS NULL THEN 'Đang ở' ELSE strftime('%d/%m/%Y', a.EndDate) END AS [Ngày kết thúc],
                    CASE a.Status
                        WHEN 'Active' THEN 'Đang lưu trú'
                        WHEN 'Ended' THEN 'Đã kết thúc'
                        ELSE a.Status
                    END AS [Trạng thái],
                    a.Status AS [StatusCode]
                FROM RoomAssignments a
                JOIN Students s ON a.StudentID = s.StudentID
                JOIN Rooms r ON a.RoomID = r.RoomID
                JOIN Buildings b ON r.BuildingID = b.BuildingID
                WHERE 1=1 ");

            var parameters = new System.Collections.Generic.List<SQLiteParameter>();

            if (!string.IsNullOrWhiteSpace(status) && status != "All")
            {
                sb.Append(" AND a.Status = @Status ");
                parameters.Add(new SQLiteParameter("@Status", status));
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sb.Append(" AND (s.StudentCode LIKE @kw OR s.FullName LIKE @kw OR r.RoomNumber LIKE @kw OR b.BuildingName LIKE @kw) ");
                parameters.Add(new SQLiteParameter("@kw", $"%{keyword.Trim()}%"));
            }

            sb.Append(" ORDER BY a.Status ASC, a.StartDate DESC");

            return DatabaseHelper.ExecuteQuery(sb.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// Lấy danh sách các sinh viên chưa có phòng ở kích hoạt (Active) để phân phòng
        /// </summary>
        public DataTable GetStudentsWithoutRoom()
        {
            string sql = @"
                SELECT 
                    s.StudentID,
                    s.StudentCode || ' - ' || s.FullName || ' (' || s.ClassName || ')' AS [StudentDisplayName]
                FROM Students s
                WHERE NOT EXISTS (
                    SELECT 1 
                    FROM RoomAssignments a 
                    WHERE a.StudentID = s.StudentID AND a.Status = 'Active'
                )
                ORDER BY s.StudentCode ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// Phân phòng cho sinh viên sử dụng SQL Transaction
        /// </summary>
        public bool AssignRoom(int studentId, int roomId, DateTime startDate, out string errorMessage)
        {
            errorMessage = string.Empty;

            // 1. Kiểm tra sinh viên đã có phòng Active chưa
            string checkStudent = "SELECT COUNT(1) FROM RoomAssignments WHERE StudentID = @StudentID AND Status = 'Active'";
            var countActive = DatabaseHelper.ExecuteScalar(checkStudent, new[] { new SQLiteParameter("@StudentID", studentId) });
            if (countActive != null && Convert.ToInt32(countActive) > 0)
            {
                errorMessage = "Sinh viên này hiện đã được phân vào một phòng đang hoạt động!";
                return false;
            }

            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            using var tran = conn.BeginTransaction();

            try
            {
                // 2. Kiểm tra sức chứa và khóa dòng phòng (UPDLOCK)
                string checkRoomSql = @"
                    SELECT Capacity, CurrentOccupancy, Status 
                    FROM Rooms
                    WHERE RoomID = @RoomID";

                using (var cmdCheck = new SQLiteCommand(checkRoomSql, conn, tran))
                {
                    cmdCheck.Parameters.AddWithValue("@RoomID", roomId);
                    using var reader = cmdCheck.ExecuteReader();
                    if (!reader.Read())
                    {
                        errorMessage = "Phòng không tồn tại!";
                        return false;
                    }

                    int capacity = Convert.ToInt32(reader["Capacity"]);
                    int occupancy = Convert.ToInt32(reader["CurrentOccupancy"]);
                    string rStatus = reader["Status"].ToString() ?? string.Empty;

                    if (rStatus == "Maintenance")
                    {
                        errorMessage = "Phòng này hiện đang trong quá trình bảo trì, không thể phân sinh viên vào!";
                        return false;
                    }

                    if (occupancy >= capacity)
                    {
                        errorMessage = $"Phòng này đã đầy đủ sức chứa ({capacity}/{capacity} người)!";
                        return false;
                    }
                }

                // 3. Thêm bản ghi phân phòng RoomAssignments
                string insertSql = @"
                    INSERT INTO RoomAssignments (StudentID, RoomID, StartDate, EndDate, Status)
                    VALUES (@StudentID, @RoomID, @StartDate, NULL, 'Active')";

                var insertParams = new SQLiteParameter[]
                {
                    new SQLiteParameter("@StudentID", studentId),
                    new SQLiteParameter("@RoomID", roomId),
                    new SQLiteParameter("@StartDate", startDate.Date)
                };
                DatabaseHelper.ExecuteNonQuery(insertSql, conn, tran, insertParams);

                // 4. Cập nhật CurrentOccupancy và Status của phòng
                string updateRoomSql = @"
                    UPDATE Rooms
                    SET CurrentOccupancy = CurrentOccupancy + 1,
                        Status = CASE WHEN CurrentOccupancy + 1 >= Capacity THEN 'Full' ELSE 'Available' END
                    WHERE RoomID = @RoomID";

                DatabaseHelper.ExecuteNonQuery(updateRoomSql, conn, tran, new[] { new SQLiteParameter("@RoomID", roomId) });

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                errorMessage = "Lỗi khi phân phòng: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Chuyển phòng cho sinh viên sang phòng mới bằng SQL Transaction
        /// </summary>
        public bool ChangeRoom(int assignmentId, int oldRoomId, int newRoomId, DateTime changeDate, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (oldRoomId == newRoomId)
            {
                errorMessage = "Phòng mới phải khác phòng hiện tại!";
                return false;
            }

            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            using var tran = conn.BeginTransaction();

            try
            {
                // Lấy StudentID của bản ghi phân phòng hiện tại
                string getStudentSql = "SELECT StudentID FROM RoomAssignments WHERE AssignmentID = @AssignmentID";
                var studentIdObj = DatabaseHelper.ExecuteScalar(getStudentSql, conn, tran, new[] { new SQLiteParameter("@AssignmentID", assignmentId) });
                if (studentIdObj == null)
                {
                    errorMessage = "Bản ghi phân phòng không tồn tại!";
                    return false;
                }
                int studentId = Convert.ToInt32(studentIdObj);

                // Kiểm tra phòng mới còn chỗ không
                string checkNewRoomSql = @"
                    SELECT Capacity, CurrentOccupancy, Status 
                    FROM Rooms
                    WHERE RoomID = @NewRoomID";

                using (var cmdNew = new SQLiteCommand(checkNewRoomSql, conn, tran))
                {
                    cmdNew.Parameters.AddWithValue("@NewRoomID", newRoomId);
                    using var reader = cmdNew.ExecuteReader();
                    if (!reader.Read())
                    {
                        errorMessage = "Phòng mới không tồn tại!";
                        return false;
                    }

                    int capacity = Convert.ToInt32(reader["Capacity"]);
                    int occupancy = Convert.ToInt32(reader["CurrentOccupancy"]);
                    string rStatus = reader["Status"].ToString() ?? string.Empty;

                    if (rStatus == "Maintenance")
                    {
                        errorMessage = "Phòng mới đang bảo trì!";
                        return false;
                    }

                    if (occupancy >= capacity)
                    {
                        errorMessage = $"Phòng mới đã đầy ({capacity}/{capacity} người)!";
                        return false;
                    }
                }

                // 1. Kết thúc phân phòng cũ
                string endOldSql = @"
                    UPDATE RoomAssignments
                    SET EndDate = @ChangeDate, Status = 'Ended'
                    WHERE AssignmentID = @AssignmentID";

                DatabaseHelper.ExecuteNonQuery(endOldSql, conn, tran, new[]
                {
                    new SQLiteParameter("@ChangeDate", changeDate.Date),
                    new SQLiteParameter("@AssignmentID", assignmentId)
                });

                // 2. Giảm số người ở phòng cũ và chuyển Status = Available
                string updateOldRoomSql = @"
                    UPDATE Rooms
                    SET CurrentOccupancy = CASE WHEN CurrentOccupancy > 0 THEN CurrentOccupancy - 1 ELSE 0 END,
                        Status = 'Available'
                    WHERE RoomID = @OldRoomID";

                DatabaseHelper.ExecuteNonQuery(updateOldRoomSql, conn, tran, new[] { new SQLiteParameter("@OldRoomID", oldRoomId) });

                // 3. Tạo phân phòng mới
                string insertNewSql = @"
                    INSERT INTO RoomAssignments (StudentID, RoomID, StartDate, EndDate, Status)
                    VALUES (@StudentID, @NewRoomID, @ChangeDate, NULL, 'Active')";

                DatabaseHelper.ExecuteNonQuery(insertNewSql, conn, tran, new[]
                {
                    new SQLiteParameter("@StudentID", studentId),
                    new SQLiteParameter("@NewRoomID", newRoomId),
                    new SQLiteParameter("@ChangeDate", changeDate.Date)
                });

                // 4. Tăng số người ở phòng mới
                string updateNewRoomSql = @"
                    UPDATE Rooms
                    SET CurrentOccupancy = CurrentOccupancy + 1,
                        Status = CASE WHEN CurrentOccupancy + 1 >= Capacity THEN 'Full' ELSE 'Available' END
                    WHERE RoomID = @NewRoomID";

                DatabaseHelper.ExecuteNonQuery(updateNewRoomSql, conn, tran, new[] { new SQLiteParameter("@NewRoomID", newRoomId) });

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                errorMessage = "Lỗi khi chuyển phòng: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Trả phòng (Kết thúc phân phòng) sử dụng SQL Transaction
        /// </summary>
        public bool EndAssignment(int assignmentId, int roomId, DateTime endDate, out string errorMessage)
        {
            errorMessage = string.Empty;

            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            using var tran = conn.BeginTransaction();

            try
            {
                // 1. Cập nhật ngày kết thúc phân phòng
                string endSql = @"
                    UPDATE RoomAssignments
                    SET EndDate = @EndDate, Status = 'Ended'
                    WHERE AssignmentID = @AssignmentID";

                DatabaseHelper.ExecuteNonQuery(endSql, conn, tran, new[]
                {
                    new SQLiteParameter("@EndDate", endDate.Date),
                    new SQLiteParameter("@AssignmentID", assignmentId)
                });

                // 2. Giảm sĩ số phòng và đặt trạng thái Available
                string updateRoomSql = @"
                    UPDATE Rooms
                    SET CurrentOccupancy = CASE WHEN CurrentOccupancy > 0 THEN CurrentOccupancy - 1 ELSE 0 END,
                        Status = 'Available'
                    WHERE RoomID = @RoomID";

                DatabaseHelper.ExecuteNonQuery(updateRoomSql, conn, tran, new[] { new SQLiteParameter("@RoomID", roomId) });

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                errorMessage = "Lỗi khi trả phòng: " + ex.Message;
                return false;
            }
        }

        #endregion
    }
}
