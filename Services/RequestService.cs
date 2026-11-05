using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using QuanLyKtx.Data;
using QuanLyKtx.Models;

namespace QuanLyKtx.Services
{
    public class RequestService
    {
        #region QUẢN LÝ VI PHẠM (VIOLATIONS)

        /// <summary>
        /// Lấy toàn bộ danh sách vi phạm có lọc theo trạng thái và tìm kiếm
        /// </summary>
        public DataTable GetAllViolations(string? status = null, string? keyword = null)
        {
            var sb = new StringBuilder(@"
                SELECT 
                    v.ViolationID,
                    v.StudentID,
                    'VP' || printf('%04d', v.ViolationID) AS [Mã VP],
                    s.StudentCode AS [Mã SV],
                    s.FullName AS [Họ và tên],
                    s.ClassName AS [Lớp],
                    strftime('%d/%m/%Y', v.ViolationDate) AS [Ngày vi phạm],
                    v.ViolationType AS [Loại vi phạm],
                    v.FineAmount AS [Tiền phạt (đ)],
                    CASE v.Status
                        WHEN 'Unpaid' THEN 'Chưa nộp phạt'
                        WHEN 'Paid' THEN 'Đã nộp phạt'
                        ELSE v.Status
                    END AS [Trạng thái],
                    v.Status AS [StatusCode],
                    v.Description AS [Mô tả chi tiết],
                    v.ViolationDate
                FROM Violations v
                JOIN Students s ON v.StudentID = s.StudentID
                WHERE 1=1 ");

            var parameters = new System.Collections.Generic.List<SQLiteParameter>();

            if (!string.IsNullOrWhiteSpace(status) && status != "All")
            {
                sb.Append(" AND v.Status = @Status ");
                parameters.Add(new SQLiteParameter("@Status", status));
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sb.Append(" AND (s.StudentCode LIKE @kw OR s.FullName LIKE @kw OR v.ViolationType LIKE @kw OR ('VP' || printf('%04d', v.ViolationID)) LIKE @kw) ");
                parameters.Add(new SQLiteParameter("@kw", $"%{keyword.Trim()}%"));
            }

            sb.Append(" ORDER BY v.ViolationID DESC");

            return DatabaseHelper.ExecuteQuery(sb.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// Lấy danh sách vi phạm của riêng 1 sinh viên
        /// </summary>
        public DataTable GetViolationsByStudent(int studentId)
        {
            string sql = @"
                SELECT 
                    'VP' || printf('%04d', v.ViolationID) AS [Mã VP],
                    strftime('%d/%m/%Y', v.ViolationDate) AS [Ngày vi phạm],
                    v.ViolationType AS [Loại vi phạm],
                    v.Description AS [Mô tả],
                    v.FineAmount AS [Tiền phạt (đ)],
                    CASE v.Status
                        WHEN 'Unpaid' THEN 'Chưa nộp phạt'
                        WHEN 'Paid' THEN 'Đã nộp phạt'
                        ELSE v.Status
                    END AS [Trạng thái]
                FROM Violations v
                WHERE v.StudentID = @StudentID
                ORDER BY v.ViolationDate DESC";

            return DatabaseHelper.ExecuteQuery(sql, new[] { new SQLiteParameter("@StudentID", studentId) });
        }

        /// <summary>
        /// Thêm mới biên bản vi phạm
        /// </summary>
        public bool AddViolation(Violation violation, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (violation.FineAmount < 0)
            {
                errorMessage = "Tiền phạt không thể nhỏ hơn 0!";
                return false;
            }

            try
            {
                string sql = @"
                    INSERT INTO Violations (StudentID, ViolationDate, ViolationType, Description, FineAmount, Status)
                    VALUES (@StudentID, @ViolationDate, @ViolationType, @Description, @FineAmount, @Status)";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@StudentID", violation.StudentID),
                    new SQLiteParameter("@ViolationDate", violation.ViolationDate.Date),
                    new SQLiteParameter("@ViolationType", violation.ViolationType.Trim()),
                    new SQLiteParameter("@Description", (object?)violation.Description?.Trim() ?? DBNull.Value),
                    new SQLiteParameter("@FineAmount", violation.FineAmount),
                    new SQLiteParameter("@Status", string.IsNullOrWhiteSpace(violation.Status) ? "Unpaid" : violation.Status)
                };

                int rows = DatabaseHelper.ExecuteNonQuery(sql, parameters);
                if (rows > 0)
                {
                    // Tự động sinh hóa đơn/khoản thu trong bảng Payments khi có tiền phạt > 0
                    if (violation.FineAmount > 0)
                    {
                        string paymentStatus = (violation.Status == "Paid") ? "Paid" : "Pending";
                        string pDesc = $"Phạt vi phạm: {violation.ViolationType.Trim()}" +
                            (string.IsNullOrWhiteSpace(violation.Description) ? "" : $" - {violation.Description.Trim()}");

                        string sqlPayment = @"
                            INSERT INTO Payments (StudentID, ContractID, PaymentDate, Amount, PaymentType, Description, Status)
                            VALUES (@StudentID, NULL, @PaymentDate, @Amount, 'Tiền phạt vi phạm', @Description, @Status)";

                        DatabaseHelper.ExecuteNonQuery(sqlPayment, new[]
                        {
                            new SQLiteParameter("@StudentID", violation.StudentID),
                            new SQLiteParameter("@PaymentDate", violation.ViolationDate.Date),
                            new SQLiteParameter("@Amount", violation.FineAmount),
                            new SQLiteParameter("@Description", pDesc),
                            new SQLiteParameter("@Status", paymentStatus)
                        });
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi ghi nhận vi phạm: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Cập nhật biên bản vi phạm
        /// </summary>
        public bool UpdateViolation(Violation violation, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (violation.FineAmount < 0)
            {
                errorMessage = "Tiền phạt không thể nhỏ hơn 0!";
                return false;
            }

            try
            {
                string sql = @"
                    UPDATE Violations
                    SET StudentID = @StudentID,
                        ViolationDate = @ViolationDate,
                        ViolationType = @ViolationType,
                        Description = @Description,
                        FineAmount = @FineAmount,
                        Status = @Status
                    WHERE ViolationID = @ViolationID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@ViolationID", violation.ViolationID),
                    new SQLiteParameter("@StudentID", violation.StudentID),
                    new SQLiteParameter("@ViolationDate", violation.ViolationDate.Date),
                    new SQLiteParameter("@ViolationType", violation.ViolationType.Trim()),
                    new SQLiteParameter("@Description", (object?)violation.Description?.Trim() ?? DBNull.Value),
                    new SQLiteParameter("@FineAmount", violation.FineAmount),
                    new SQLiteParameter("@Status", violation.Status)
                };

                int rows = DatabaseHelper.ExecuteNonQuery(sql, parameters);
                if (rows > 0)
                {
                    // Nếu cập nhật trạng thái vi phạm sang Paid, tự động gạch nợ bản ghi Pending tương ứng trong Payments
                    if (violation.Status == "Paid")
                    {
                        string sqlSync = @"
                            UPDATE Payments
                            SET Status = 'Paid'
                            WHERE StudentID = @StudentID 
                              AND PaymentType = 'Tiền phạt vi phạm' 
                              AND Status = 'Pending' 
                              AND Amount = @Amount";
                        DatabaseHelper.ExecuteNonQuery(sqlSync, new[]
                        {
                            new SQLiteParameter("@StudentID", violation.StudentID),
                            new SQLiteParameter("@Amount", violation.FineAmount)
                        });
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi cập nhật vi phạm: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xóa biên bản vi phạm
        /// </summary>
        public bool DeleteViolation(int violationId, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                var dt = DatabaseHelper.ExecuteQuery(
                    "SELECT StudentID, FineAmount FROM Violations WHERE ViolationID = @ViolationID",
                    new[] { new SQLiteParameter("@ViolationID", violationId) });

                string sql = "DELETE FROM Violations WHERE ViolationID = @ViolationID";
                int rows = DatabaseHelper.ExecuteNonQuery(sql, new[] { new SQLiteParameter("@ViolationID", violationId) });

                if (rows > 0 && dt.Rows.Count > 0)
                {
                    int sId = Convert.ToInt32(dt.Rows[0]["StudentID"]);
                    decimal amount = Convert.ToDecimal(dt.Rows[0]["FineAmount"]);

                    string sqlDelPayment = @"
                        DELETE FROM Payments 
                        WHERE StudentID = @StudentID 
                          AND PaymentType = 'Tiền phạt vi phạm' 
                          AND Amount = @Amount 
                          AND Status = 'Pending'";
                    DatabaseHelper.ExecuteNonQuery(sqlDelPayment, new[]
                    {
                        new SQLiteParameter("@StudentID", sId),
                        new SQLiteParameter("@Amount", amount)
                    });
                }
                return rows > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa vi phạm: " + ex.Message;
                return false;
            }
        }

        #endregion

        #region XỬ LÝ YÊU CẦU CỦA SINH VIÊN (REQUESTS)

        /// <summary>
        /// Lấy toàn bộ danh sách yêu cầu có lọc theo trạng thái, loại yêu cầu và tìm kiếm
        /// </summary>
        public DataTable GetAllRequests(string? status = null, string? requestType = null, string? keyword = null)
        {
            var sb = new StringBuilder(@"
                SELECT 
                    req.RequestID,
                    req.StudentID,
                    'YC' || printf('%04d', req.RequestID) AS [Mã YC],
                    s.StudentCode AS [Mã SV],
                    s.FullName AS [Họ và tên],
                    s.ClassName AS [Lớp],
                    s.Phone AS [SĐT],
                    CASE req.RequestType
                        WHEN 'RegisterRoom' THEN 'Đăng ký phòng'
                        WHEN 'ChangeRoom' THEN 'Chuyển phòng'
                        WHEN 'LeaveRoom' THEN 'Trả phòng'
                        WHEN 'PaymentConfirmation' THEN 'Xác nhận nộp phí'
                        ELSE req.RequestType
                    END AS [Loại yêu cầu],
                    req.Content AS [Nội dung yêu cầu],
                    strftime('%d/%m/%Y %H:%M:%S', req.CreatedAt) AS [Ngày gửi],
                    CASE req.Status
                        WHEN 'Pending' THEN 'Chờ duyệt'
                        WHEN 'Approved' THEN 'Đã duyệt'
                        WHEN 'Rejected' THEN 'Từ chối'
                        ELSE req.Status
                    END AS [Trạng thái],
                    req.ManagerNote AS [Ghi chú của Quản lý],
                    strftime('%d/%m/%Y %H:%M:%S', req.ProcessedAt) AS [Ngày xử lý],
                    req.RequestType AS [TypeCode],
                    req.Status AS [StatusCode]
                FROM Requests req
                JOIN Students s ON req.StudentID = s.StudentID
                WHERE 1=1 ");

            var parameters = new System.Collections.Generic.List<SQLiteParameter>();

            if (!string.IsNullOrWhiteSpace(status) && status != "All")
            {
                sb.Append(" AND req.Status = @Status ");
                parameters.Add(new SQLiteParameter("@Status", status));
            }

            if (!string.IsNullOrWhiteSpace(requestType) && requestType != "All")
            {
                sb.Append(" AND req.RequestType = @RequestType ");
                parameters.Add(new SQLiteParameter("@RequestType", requestType));
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sb.Append(" AND (s.StudentCode LIKE @kw OR s.FullName LIKE @kw OR req.Content LIKE @kw OR ('YC' || printf('%04d', req.RequestID)) LIKE @kw) ");
                parameters.Add(new SQLiteParameter("@kw", $"%{keyword.Trim()}%"));
            }

            sb.Append(" ORDER BY CASE req.Status WHEN 'Pending' THEN 1 ELSE 2 END, req.RequestID DESC");

            return DatabaseHelper.ExecuteQuery(sb.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// Lấy danh sách yêu cầu của 1 sinh viên cụ thể
        /// </summary>
        public DataTable GetRequestsByStudent(int studentId)
        {
            string sql = @"
                SELECT 
                    'YC' || printf('%04d', req.RequestID) AS [Mã YC],
                    CASE req.RequestType
                        WHEN 'RegisterRoom' THEN 'Đăng ký phòng'
                        WHEN 'ChangeRoom' THEN 'Chuyển phòng'
                        WHEN 'LeaveRoom' THEN 'Trả phòng'
                        WHEN 'PaymentConfirmation' THEN 'Xác nhận nộp phí'
                        ELSE req.RequestType
                    END AS [Loại yêu cầu],
                    req.Content AS [Nội dung],
                    strftime('%d/%m/%Y %H:%M:%S', req.CreatedAt) AS [Ngày gửi],
                    CASE req.Status
                        WHEN 'Pending' THEN 'Chờ duyệt'
                        WHEN 'Approved' THEN 'Đã duyệt'
                        WHEN 'Rejected' THEN 'Từ chối'
                        ELSE req.Status
                    END AS [Trạng thái],
                    req.ManagerNote AS [Phản hồi của QL]
                FROM Requests req
                WHERE req.StudentID = @StudentID
                ORDER BY req.RequestID DESC";

            return DatabaseHelper.ExecuteQuery(sql, new[] { new SQLiteParameter("@StudentID", studentId) });
        }

        /// <summary>
        /// Sinh viên tạo một yêu cầu mới (Đăng ký phòng / Chuyển phòng / Trả phòng)
        /// </summary>
        public bool CreateRequest(Request request, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(request.Content))
            {
                errorMessage = "Vui lòng nhập nội dung chi tiết của yêu cầu!";
                return false;
            }

            try
            {
                string sql = @"
                    INSERT INTO Requests (StudentID, RequestType, Content, CreatedAt, Status)
                    VALUES (@StudentID, @RequestType, @Content, CURRENT_TIMESTAMP, 'Pending')";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@StudentID", request.StudentID),
                    new SQLiteParameter("@RequestType", request.RequestType),
                    new SQLiteParameter("@Content", request.Content.Trim())
                };

                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi gửi yêu cầu: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Quản lý Duyệt yêu cầu sinh viên sử dụng SQL Transaction
        /// - Đăng ký phòng: Phân phòng vào phòng được chọn
        /// - Chuyển phòng: Chuyển sang phòng mới được chọn
        /// - Trả phòng: Trả phòng hiện tại
        /// </summary>
        public bool ApproveRequest(int requestId, int? assignedRoomId, string? managerNote, out string errorMessage)
        {
            errorMessage = string.Empty;

            using var conn = DatabaseConnection.GetConnection();
            conn.Open();
            using var tran = conn.BeginTransaction();

            try
            {
                // 1. Đọc thông tin yêu cầu hiện tại
                string getReqSql = "SELECT StudentID, RequestType, Status FROM Requests WHERE RequestID = @RequestID";
                using var cmdReq = new SQLiteCommand(getReqSql, conn, tran);
                cmdReq.Parameters.AddWithValue("@RequestID", requestId);
                int studentId;
                string reqType;
                string curStatus;

                using (var reader = cmdReq.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        errorMessage = "Không tìm thấy yêu cầu này!";
                        return false;
                    }
                    studentId = Convert.ToInt32(reader["StudentID"]);
                    reqType = reader["RequestType"].ToString() ?? string.Empty;
                    curStatus = reader["Status"].ToString() ?? string.Empty;
                }

                if (curStatus != "Pending")
                {
                    errorMessage = "Yêu cầu này đã được xử lý trước đó!";
                    return false;
                }

                // 2. Xử lý nghiệp vụ theo từng loại yêu cầu
                if (reqType == "RegisterRoom")
                {
                    if (!assignedRoomId.HasValue || assignedRoomId.Value <= 0)
                    {
                        errorMessage = "Vui lòng chọn phòng để xếp cho sinh viên khi duyệt yêu cầu đăng ký phòng!";
                        return false;
                    }

                    // Kiểm tra sức chứa phòng
                    string checkRoom = "SELECT Capacity, CurrentOccupancy, Status FROM Rooms WHERE RoomID = @RoomID";
                    using var cmdRoom = new SQLiteCommand(checkRoom, conn, tran);
                    cmdRoom.Parameters.AddWithValue("@RoomID", assignedRoomId.Value);
                    using (var rReader = cmdRoom.ExecuteReader())
                    {
                        if (!rReader.Read())
                        {
                            errorMessage = "Phòng được chọn không tồn tại!";
                            return false;
                        }
                        int cap = Convert.ToInt32(rReader["Capacity"]);
                        int occ = Convert.ToInt32(rReader["CurrentOccupancy"]);
                        string st = rReader["Status"].ToString() ?? string.Empty;
                        if (st == "Maintenance" || occ >= cap)
                        {
                            errorMessage = "Phòng được chọn đã đầy hoặc đang bảo trì!";
                            return false;
                        }
                    }

                    // Tạo phân phòng
                    string insAssign = @"
                        INSERT INTO RoomAssignments (StudentID, RoomID, StartDate, EndDate, Status)
                        VALUES (@StudentID, @RoomID, date('now'), NULL, 'Active')";
                    using var cmdIns = new SQLiteCommand(insAssign, conn, tran);
                    cmdIns.Parameters.AddWithValue("@StudentID", studentId);
                    cmdIns.Parameters.AddWithValue("@RoomID", assignedRoomId.Value);
                    cmdIns.ExecuteNonQuery();

                    // Cập nhật số người ở phòng
                    string upRoom = @"
                        UPDATE Rooms 
                        SET CurrentOccupancy = CurrentOccupancy + 1,
                            Status = CASE WHEN CurrentOccupancy + 1 >= Capacity THEN 'Full' ELSE 'Available' END
                        WHERE RoomID = @RoomID";
                    using var cmdUp = new SQLiteCommand(upRoom, conn, tran);
                    cmdUp.Parameters.AddWithValue("@RoomID", assignedRoomId.Value);
                    cmdUp.ExecuteNonQuery();
                }
                else if (reqType == "ChangeRoom")
                {
                    if (!assignedRoomId.HasValue || assignedRoomId.Value <= 0)
                    {
                        errorMessage = "Vui lòng chọn phòng mới khi duyệt yêu cầu chuyển phòng!";
                        return false;
                    }

                    // Tìm phân phòng đang Active của SV
                    string getActive = "SELECT AssignmentID, RoomID FROM RoomAssignments WHERE StudentID = @StudentID AND Status = 'Active'";
                    using var cmdAct = new SQLiteCommand(getActive, conn, tran);
                    cmdAct.Parameters.AddWithValue("@StudentID", studentId);
                    int oldAssignId = 0;
                    int oldRoomId = 0;
                    using (var aReader = cmdAct.ExecuteReader())
                    {
                        if (aReader.Read())
                        {
                            oldAssignId = Convert.ToInt32(aReader["AssignmentID"]);
                            oldRoomId = Convert.ToInt32(aReader["RoomID"]);
                        }
                    }

                    if (oldAssignId > 0)
                    {
                        // Đóng phân phòng cũ
                        string endOld = "UPDATE RoomAssignments SET EndDate = date('now'), Status = 'Ended' WHERE AssignmentID = @AID";
                        using var cmdEnd = new SQLiteCommand(endOld, conn, tran);
                        cmdEnd.Parameters.AddWithValue("@AID", oldAssignId);
                        cmdEnd.ExecuteNonQuery();

                        // Giảm số người phòng cũ
                        string decRoom = "UPDATE Rooms SET CurrentOccupancy = CASE WHEN CurrentOccupancy > 0 THEN CurrentOccupancy - 1 ELSE 0 END, Status = 'Available' WHERE RoomID = @RID";
                        using var cmdDec = new SQLiteCommand(decRoom, conn, tran);
                        cmdDec.Parameters.AddWithValue("@RID", oldRoomId);
                        cmdDec.ExecuteNonQuery();
                    }

                    // Tạo phân phòng mới
                    string insNew = @"
                        INSERT INTO RoomAssignments (StudentID, RoomID, StartDate, EndDate, Status)
                        VALUES (@StudentID, @RoomID, date('now'), NULL, 'Active')";
                    using var cmdInsN = new SQLiteCommand(insNew, conn, tran);
                    cmdInsN.Parameters.AddWithValue("@StudentID", studentId);
                    cmdInsN.Parameters.AddWithValue("@RoomID", assignedRoomId.Value);
                    cmdInsN.ExecuteNonQuery();

                    // Tăng số người phòng mới
                    string incRoom = @"
                        UPDATE Rooms 
                        SET CurrentOccupancy = CurrentOccupancy + 1,
                            Status = CASE WHEN CurrentOccupancy + 1 >= Capacity THEN 'Full' ELSE 'Available' END
                        WHERE RoomID = @RoomID";
                    using var cmdInc = new SQLiteCommand(incRoom, conn, tran);
                    cmdInc.Parameters.AddWithValue("@RoomID", assignedRoomId.Value);
                    cmdInc.ExecuteNonQuery();
                }
                else if (reqType == "LeaveRoom")
                {
                    // Tìm phân phòng Active và kết thúc
                    string getActive = "SELECT AssignmentID, RoomID FROM RoomAssignments WHERE StudentID = @StudentID AND Status = 'Active'";
                    using var cmdAct = new SQLiteCommand(getActive, conn, tran);
                    cmdAct.Parameters.AddWithValue("@StudentID", studentId);
                    int oldAssignId = 0;
                    int oldRoomId = 0;
                    using (var aReader = cmdAct.ExecuteReader())
                    {
                        if (aReader.Read())
                        {
                            oldAssignId = Convert.ToInt32(aReader["AssignmentID"]);
                            oldRoomId = Convert.ToInt32(aReader["RoomID"]);
                        }
                    }

                    if (oldAssignId > 0)
                    {
                        string endOld = "UPDATE RoomAssignments SET EndDate = date('now'), Status = 'Ended' WHERE AssignmentID = @AID";
                        using var cmdEnd = new SQLiteCommand(endOld, conn, tran);
                        cmdEnd.Parameters.AddWithValue("@AID", oldAssignId);
                        cmdEnd.ExecuteNonQuery();

                        string decRoom = "UPDATE Rooms SET CurrentOccupancy = CASE WHEN CurrentOccupancy > 0 THEN CurrentOccupancy - 1 ELSE 0 END, Status = 'Available' WHERE RoomID = @RID";
                        using var cmdDec = new SQLiteCommand(decRoom, conn, tran);
                        cmdDec.Parameters.AddWithValue("@RID", oldRoomId);
                        cmdDec.ExecuteNonQuery();
                    }
                }

                else if (reqType == "PaymentConfirmation")
                {
                    // Lấy nội dung yêu cầu để trích xuất PaymentID (dạng PTxxxx)
                    string content = "";
                    using (var cmdC = new SQLiteCommand("SELECT Content FROM Requests WHERE RequestID = @RID", conn, tran))
                    {
                        cmdC.Parameters.AddWithValue("@RID", requestId);
                        var objC = cmdC.ExecuteScalar();
                        if (objC != null) content = objC.ToString() ?? "";
                    }

                    var match = System.Text.RegularExpressions.Regex.Match(content, @"PT(\d+)");
                    if (match.Success && int.TryParse(match.Groups[1].Value, out int payId))
                    {
                        string markPaidSql = @"
                            UPDATE Payments 
                            SET Status = 'Paid', PaymentDate = date('now') 
                            WHERE PaymentID = @PID AND Status = 'Pending'";
                        using var cmdMark = new SQLiteCommand(markPaidSql, conn, tran);
                        cmdMark.Parameters.AddWithValue("@PID", payId);
                        cmdMark.ExecuteNonQuery();
                    }
                }

                // 3. Cập nhật trạng thái Request thành Approved
                string upReqSql = @"
                    UPDATE Requests 
                    SET Status = 'Approved', 
                        ProcessedAt = CURRENT_TIMESTAMP,
                        ManagerNote = @Note 
                    WHERE RequestID = @RequestID";

                using var cmdUpReq = new SQLiteCommand(upReqSql, conn, tran);
                cmdUpReq.Parameters.AddWithValue("@RequestID", requestId);
                cmdUpReq.Parameters.AddWithValue("@Note", (object?)managerNote?.Trim() ?? DBNull.Value);
                cmdUpReq.ExecuteNonQuery();

                tran.Commit();

                // Đồng bộ sau khi commit nếu là PaymentConfirmation
                if (reqType == "PaymentConfirmation")
                {
                    try
                    {
                        var dtC = DatabaseHelper.ExecuteQuery(
                            "SELECT Content FROM Requests WHERE RequestID = @RID",
                            new[] { new SQLiteParameter("@RID", requestId) });
                        if (dtC.Rows.Count > 0)
                        {
                            var m = System.Text.RegularExpressions.Regex.Match(dtC.Rows[0]["Content"]?.ToString() ?? "", @"PT(\d+)");
                            if (m.Success && int.TryParse(m.Groups[1].Value, out int pId))
                            {
                                var payService = new PaymentService();
                                payService.MarkAsPaid(pId, out _);
                            }
                        }
                    }
                    catch { }
                }

                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                errorMessage = "Lỗi khi duyệt yêu cầu: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Quản lý Từ chối yêu cầu của sinh viên
        /// </summary>
        public bool RejectRequest(int requestId, string? managerNote, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                var dtReq = DatabaseHelper.ExecuteQuery(
                    "SELECT RequestType, Content FROM Requests WHERE RequestID = @RequestID",
                    new[] { new SQLiteParameter("@RequestID", requestId) });

                string sql = @"
                    UPDATE Requests 
                    SET Status = 'Rejected', 
                        ProcessedAt = CURRENT_TIMESTAMP,
                        ManagerNote = @Note 
                    WHERE RequestID = @RequestID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@RequestID", requestId),
                    new SQLiteParameter("@Note", (object?)managerNote?.Trim() ?? DBNull.Value)
                };

                bool ok = DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
                if (ok && dtReq.Rows.Count > 0)
                {
                    string rType = dtReq.Rows[0]["RequestType"]?.ToString() ?? "";
                    if (rType == "PaymentConfirmation")
                    {
                        string content = dtReq.Rows[0]["Content"]?.ToString() ?? "";
                        var match = System.Text.RegularExpressions.Regex.Match(content, @"PT(\d+)");
                        if (match.Success && int.TryParse(match.Groups[1].Value, out int payId))
                        {
                            string unTagSql = @"
                                UPDATE Payments 
                                SET Description = REPLACE(Description, '[ĐÃ CHUYỂN KHOẢN - CHỜ DUYỆT', '[TỪ CHỐI DUYỆT')
                                WHERE PaymentID = @PID AND Status = 'Pending'";
                            DatabaseHelper.ExecuteNonQuery(unTagSql, new[] { new SQLiteParameter("@PID", payId) });
                        }
                    }
                }
                return ok;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi từ chối yêu cầu: " + ex.Message;
                return false;
            }
        }

        #endregion
    }
}
