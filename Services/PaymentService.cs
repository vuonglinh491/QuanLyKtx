using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using QuanLyKtx.Data;
using QuanLyKtx.Models;

namespace QuanLyKtx.Services
{
    public class PaymentService
    {
        public const decimal DON_GIA_DIEN = 3500m; // 3,500 đ / kWh
        public const decimal DON_GIA_NUOC = 12000m; // 12,000 đ / m3

        #region ĐIỆN NƯỚC (ELECTRICITY & WATER)

        /// <summary>
        /// Lấy danh sách ghi nhận điện nước với bộ lọc tháng, năm, khu nhà và tìm kiếm
        /// </summary>
        public DataTable GetAllElectricityWater(int? month = null, int? year = null, int? buildingId = null, string? keyword = null)
        {
            var sb = new StringBuilder(@"
                SELECT 
                    ew.RecordID,
                    ew.RoomID,
                    b.BuildingName AS [Khu nhà],
                    r.RoomNumber AS [Số phòng],
                    ew.Month AS [Tháng],
                    ew.Year AS [Năm],
                    ew.OldElectricIndex AS [Điện cũ],
                    ew.NewElectricIndex AS [Điện mới],
                    (ew.NewElectricIndex - ew.OldElectricIndex) AS [Điện tiêu thụ],
                    ew.ElectricAmount AS [Tiền điện (đ)],
                    ew.OldWaterIndex AS [Nước cũ],
                    ew.NewWaterIndex AS [Nước mới],
                    (ew.NewWaterIndex - ew.OldWaterIndex) AS [Nước tiêu thụ],
                    ew.WaterAmount AS [Tiền nước (đ)],
                    ew.TotalAmount AS [Tổng tiền (đ)]
                FROM ElectricityWater ew
                JOIN Rooms r ON ew.RoomID = r.RoomID
                JOIN Buildings b ON r.BuildingID = b.BuildingID
                WHERE 1=1 ");

            var parameters = new System.Collections.Generic.List<SQLiteParameter>();

            if (month.HasValue && month.Value > 0)
            {
                sb.Append(" AND ew.Month = @Month ");
                parameters.Add(new SQLiteParameter("@Month", month.Value));
            }

            if (year.HasValue && year.Value > 0)
            {
                sb.Append(" AND ew.Year = @Year ");
                parameters.Add(new SQLiteParameter("@Year", year.Value));
            }

            if (buildingId.HasValue && buildingId.Value > 0)
            {
                sb.Append(" AND r.BuildingID = @BuildingID ");
                parameters.Add(new SQLiteParameter("@BuildingID", buildingId.Value));
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sb.Append(" AND (r.RoomNumber LIKE @kw OR b.BuildingName LIKE @kw) ");
                parameters.Add(new SQLiteParameter("@kw", $"%{keyword.Trim()}%"));
            }

            sb.Append(" ORDER BY ew.Year DESC, ew.Month DESC, b.BuildingName ASC, r.RoomNumber ASC");

            return DatabaseHelper.ExecuteQuery(sb.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// Lấy chỉ số mới của tháng gần nhất để gợi ý làm chỉ số cũ cho tháng mới
        /// </summary>
        public (decimal oldElectric, decimal oldWater) GetLatestIndices(int roomId)
        {
            string sql = @"
                    SELECT NewElectricIndex, NewWaterIndex
                FROM ElectricityWater
                WHERE RoomID = @RoomID 
                ORDER BY Year DESC, Month DESC LIMIT 1";

            var dt = DatabaseHelper.ExecuteQuery(sql, new[] { new SQLiteParameter("@RoomID", roomId) });
            if (dt.Rows.Count > 0)
            {
                decimal electric = Convert.ToDecimal(dt.Rows[0]["NewElectricIndex"]);
                decimal water = Convert.ToDecimal(dt.Rows[0]["NewWaterIndex"]);
                return (electric, water);
            }

            return (0, 0);
        }

        /// <summary>
        /// Thêm mới bản ghi điện nước hàng tháng
        /// </summary>
        public bool AddElectricityWater(ElectricityWater ew, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (ew.NewElectricIndex < ew.OldElectricIndex)
            {
                errorMessage = "Chỉ số điện mới không được nhỏ hơn chỉ số điện cũ!";
                return false;
            }

            if (ew.NewWaterIndex < ew.OldWaterIndex)
            {
                errorMessage = "Chỉ số nước mới không được nhỏ hơn chỉ số nước cũ!";
                return false;
            }

            // Kiểm tra trùng bản ghi tháng/năm cho cùng 1 phòng
            string checkSql = "SELECT COUNT(1) FROM ElectricityWater WHERE RoomID = @RoomID AND Month = @Month AND Year = @Year";
            var count = DatabaseHelper.ExecuteScalar(checkSql, new[]
            {
                new SQLiteParameter("@RoomID", ew.RoomID),
                new SQLiteParameter("@Month", ew.Month),
                new SQLiteParameter("@Year", ew.Year)
            });

            if (count != null && Convert.ToInt32(count) > 0)
            {
                errorMessage = $"Phòng này đã có dữ liệu điện nước cho tháng {ew.Month}/{ew.Year}!";
                return false;
            }

            // Tính toán số tiền
            decimal electricUsed = ew.NewElectricIndex - ew.OldElectricIndex;
            decimal waterUsed = ew.NewWaterIndex - ew.OldWaterIndex;
            decimal electricAmount = electricUsed * DON_GIA_DIEN;
            decimal waterAmount = waterUsed * DON_GIA_NUOC;
            decimal totalAmount = electricAmount + waterAmount;

            try
            {
                string sql = @"
                    INSERT INTO ElectricityWater 
                    (RoomID, Month, Year, OldElectricIndex, NewElectricIndex, ElectricAmount, OldWaterIndex, NewWaterIndex, WaterAmount, TotalAmount)
                    VALUES 
                    (@RoomID, @Month, @Year, @OldElectric, @NewElectric, @ElectricAmount, @OldWater, @NewWater, @WaterAmount, @TotalAmount)";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@RoomID", ew.RoomID),
                    new SQLiteParameter("@Month", ew.Month),
                    new SQLiteParameter("@Year", ew.Year),
                    new SQLiteParameter("@OldElectric", ew.OldElectricIndex),
                    new SQLiteParameter("@NewElectric", ew.NewElectricIndex),
                    new SQLiteParameter("@ElectricAmount", electricAmount),
                    new SQLiteParameter("@OldWater", ew.OldWaterIndex),
                    new SQLiteParameter("@NewWater", ew.NewWaterIndex),
                    new SQLiteParameter("@WaterAmount", waterAmount),
                    new SQLiteParameter("@TotalAmount", totalAmount)
                };

                bool success = DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
                if (success && totalAmount > 0)
                {
                    SyncElectricityWaterToPayments(ew.RoomID, ew.Month, ew.Year, totalAmount);
                }
                return success;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi thêm dữ liệu điện nước: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Cập nhật bản ghi điện nước
        /// </summary>
        public bool UpdateElectricityWater(ElectricityWater ew, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (ew.NewElectricIndex < ew.OldElectricIndex)
            {
                errorMessage = "Chỉ số điện mới không được nhỏ hơn chỉ số điện cũ!";
                return false;
            }

            if (ew.NewWaterIndex < ew.OldWaterIndex)
            {
                errorMessage = "Chỉ số nước mới không được nhỏ hơn chỉ số nước cũ!";
                return false;
            }

            decimal electricUsed = ew.NewElectricIndex - ew.OldElectricIndex;
            decimal waterUsed = ew.NewWaterIndex - ew.OldWaterIndex;
            decimal electricAmount = electricUsed * DON_GIA_DIEN;
            decimal waterAmount = waterUsed * DON_GIA_NUOC;
            decimal totalAmount = electricAmount + waterAmount;

            try
            {
                string sql = @"
                    UPDATE ElectricityWater 
                    SET OldElectricIndex = @OldElectric,
                        NewElectricIndex = @NewElectric,
                        ElectricAmount = @ElectricAmount,
                        OldWaterIndex = @OldWater,
                        NewWaterIndex = @NewWater,
                        WaterAmount = @WaterAmount,
                        TotalAmount = @TotalAmount
                    WHERE RecordID = @RecordID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@RecordID", ew.RecordID),
                    new SQLiteParameter("@OldElectric", ew.OldElectricIndex),
                    new SQLiteParameter("@NewElectric", ew.NewElectricIndex),
                    new SQLiteParameter("@ElectricAmount", electricAmount),
                    new SQLiteParameter("@OldWater", ew.OldWaterIndex),
                    new SQLiteParameter("@NewWater", ew.NewWaterIndex),
                    new SQLiteParameter("@WaterAmount", waterAmount),
                    new SQLiteParameter("@TotalAmount", totalAmount)
                };

                bool success = DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
                if (success && totalAmount > 0)
                {
                    // Lấy lại RoomID, Month, Year
                    string getSql = "SELECT RoomID, Month, Year FROM ElectricityWater WHERE RecordID = @RecordID";
                    var dt = DatabaseHelper.ExecuteQuery(getSql, new[] { new SQLiteParameter("@RecordID", ew.RecordID) });
                    if (dt.Rows.Count > 0)
                    {
                        int rId = Convert.ToInt32(dt.Rows[0]["RoomID"]);
                        int m = Convert.ToInt32(dt.Rows[0]["Month"]);
                        int y = Convert.ToInt32(dt.Rows[0]["Year"]);
                        SyncElectricityWaterToPayments(rId, m, y, totalAmount);
                    }
                }
                return success;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi cập nhật điện nước: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xóa bản ghi điện nước
        /// </summary>
        public bool DeleteElectricityWater(int recordId, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                // Trước khi xóa, lấy thông tin tháng/năm/phòng để dọn dẹp các hóa đơn Pending tương ứng
                string getSql = "SELECT RoomID, Month, Year FROM ElectricityWater WHERE RecordID = @RecordID";
                var dt = DatabaseHelper.ExecuteQuery(getSql, new[] { new SQLiteParameter("@RecordID", recordId) });
                if (dt.Rows.Count > 0)
                {
                    int m = Convert.ToInt32(dt.Rows[0]["Month"]);
                    int y = Convert.ToInt32(dt.Rows[0]["Year"]);
                    string pattern = $"%T{m}/{y}%";
                    string delPendingSql = "DELETE FROM Payments WHERE PaymentType = 'Tiền điện nước' AND Status = 'Pending' AND Description LIKE @Pattern";
                    DatabaseHelper.ExecuteNonQuery(delPendingSql, new[] { new SQLiteParameter("@Pattern", pattern) });
                }

                string sql = "DELETE FROM ElectricityWater WHERE RecordID = @RecordID";
                return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SQLiteParameter("@RecordID", recordId) }) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa bản ghi điện nước: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Đồng bộ tự động hóa đơn điện nước phòng sang bảng Payments (chờ thanh toán) cho các sinh viên trong phòng
        /// </summary>
        public void SyncElectricityWaterToPayments(int roomId, int month, int year, decimal totalAmount)
        {
            try
            {
                // Lấy danh sách sinh viên đang ở phòng này (RoomAssignments Active hoặc Contracts Active)
                string getStudentsSql = @"
                    SELECT DISTINCT s.StudentID, c.ContractID
                    FROM Students s
                    JOIN RoomAssignments ra ON s.StudentID = ra.StudentID AND ra.Status = 'Active' AND ra.RoomID = @RoomID
                    LEFT JOIN Contracts c ON s.StudentID = c.StudentID AND c.RoomID = @RoomID AND c.Status = 'Active'
                    UNION
                    SELECT DISTINCT s.StudentID, c.ContractID
                    FROM Students s
                    JOIN Contracts c ON s.StudentID = c.StudentID AND c.Status = 'Active' AND c.RoomID = @RoomID
                    WHERE s.StudentID NOT IN (SELECT StudentID FROM RoomAssignments WHERE RoomID = @RoomID AND Status = 'Active')";

                var dtStudents = DatabaseHelper.ExecuteQuery(getStudentsSql, new[] { new SQLiteParameter("@RoomID", roomId) });

                // Lấy thông tin phòng
                string roomInfoSql = @"
                    SELECT r.RoomNumber, b.BuildingName 
                    FROM Rooms r 
                    JOIN Buildings b ON r.BuildingID = b.BuildingID 
                    WHERE r.RoomID = @RoomID";
                var dtRoom = DatabaseHelper.ExecuteQuery(roomInfoSql, new[] { new SQLiteParameter("@RoomID", roomId) });
                string roomTitle = (dtRoom.Rows.Count > 0)
                    ? $"{dtRoom.Rows[0]["BuildingName"]} P.{dtRoom.Rows[0]["RoomNumber"]}"
                    : $"Phòng {roomId}";

                int studentCount = dtStudents.Rows.Count;
                if (studentCount > 0 && totalAmount > 0)
                {
                    decimal perStudent = Math.Round(totalAmount / studentCount, 0);

                    foreach (DataRow row in dtStudents.Rows)
                    {
                        int studentId = Convert.ToInt32(row["StudentID"]);
                        object? contractId = row["ContractID"] != DBNull.Value ? row["ContractID"] : null;
                        string desc = $"Tiền điện nước T{month}/{year} - {roomTitle}" + (studentCount > 1 ? $" (Tổng {totalAmount:N0}đ / {studentCount} SV)" : "");

                        // Kiểm tra xem đã tồn tại khoản thu điện nước của tháng này chưa
                        string checkSql = @"
                            SELECT PaymentID, Status FROM Payments 
                            WHERE StudentID = @StudentID AND PaymentType = 'Tiền điện nước' 
                            AND Description LIKE @Pattern";
                        string pattern = $"%T{month}/{year}%";
                        var dtExisting = DatabaseHelper.ExecuteQuery(checkSql, new[]
                        {
                            new SQLiteParameter("@StudentID", studentId),
                            new SQLiteParameter("@Pattern", pattern)
                        });

                        if (dtExisting.Rows.Count == 0)
                        {
                            string insertPaySql = @"
                                INSERT INTO Payments (StudentID, ContractID, PaymentDate, Amount, PaymentType, Description, Status)
                                VALUES (@StudentID, @ContractID, @PaymentDate, @Amount, 'Tiền điện nước', @Description, 'Pending')";
                            DatabaseHelper.ExecuteNonQuery(insertPaySql, new[]
                            {
                                new SQLiteParameter("@StudentID", studentId),
                                new SQLiteParameter("@ContractID", contractId ?? DBNull.Value),
                                new SQLiteParameter("@PaymentDate", DateTime.Today.ToString("yyyy-MM-dd")),
                                new SQLiteParameter("@Amount", perStudent),
                                new SQLiteParameter("@Description", desc)
                            });
                        }
                        else
                        {
                            int payId = Convert.ToInt32(dtExisting.Rows[0]["PaymentID"]);
                            string payStatus = dtExisting.Rows[0]["Status"].ToString() ?? "Pending";
                            if (payStatus == "Pending")
                            {
                                string updatePaySql = @"
                                    UPDATE Payments
                                    SET Amount = @Amount, Description = @Description
                                    WHERE PaymentID = @PaymentID";
                                DatabaseHelper.ExecuteNonQuery(updatePaySql, new[]
                                {
                                    new SQLiteParameter("@Amount", perStudent),
                                    new SQLiteParameter("@Description", desc),
                                    new SQLiteParameter("@PaymentID", payId)
                                });
                            }
                        }
                    }
                }
            }
            catch { }
        }

        #endregion

        #region THANH TOÁN (PAYMENTS)

        /// <summary>
        /// Lấy toàn bộ danh sách thanh toán có lọc theo tháng, năm, trạng thái và tìm kiếm
        /// </summary>
        public DataTable GetAllPayments(int? month = null, int? year = null, string? status = null, string? keyword = null)
        {
            var sb = new StringBuilder(@"
                SELECT 
                    p.PaymentID,
                    p.StudentID,
                    p.ContractID,
                    'PT' || printf('%04d', p.PaymentID) AS [Mã phiếu],
                    s.StudentCode AS [Mã SV],
                    s.FullName AS [Họ và tên],
                    strftime('%d/%m/%Y', p.PaymentDate) AS [Ngày nộp],
                    p.Amount AS [Số tiền (đ)],
                    p.PaymentType AS [Khoản nộp],
                    p.Description AS [Nội dung],
                    CASE p.Status
                        WHEN 'Paid' THEN 'Đã thanh toán'
                        WHEN 'Pending' THEN 
                            CASE 
                                WHEN p.Description LIKE '%[ĐÃ CHUYỂN KHOẢN%' THEN 'Chờ duyệt (Đã CK)'
                                ELSE 'Chờ xử lý'
                            END
                        WHEN 'Cancelled' THEN 'Đã hủy'
                        ELSE p.Status
                    END AS [Trạng thái],
                    p.Status AS [StatusCode],
                    p.PaymentDate
                FROM Payments p
                JOIN Students s ON p.StudentID = s.StudentID
                WHERE 1=1 ");

            var parameters = new System.Collections.Generic.List<SQLiteParameter>();

            if (month.HasValue && month.Value > 0)
            {
                sb.Append(" AND CAST(strftime('%m', p.PaymentDate) AS INTEGER) = @Month ");
                parameters.Add(new SQLiteParameter("@Month", month.Value));
            }

            if (year.HasValue && year.Value > 0)
            {
                sb.Append(" AND CAST(strftime('%Y', p.PaymentDate) AS INTEGER) = @Year ");
                parameters.Add(new SQLiteParameter("@Year", year.Value));
            }

            if (!string.IsNullOrWhiteSpace(status) && status != "All")
            {
                sb.Append(" AND p.Status = @Status ");
                parameters.Add(new SQLiteParameter("@Status", status));
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sb.Append(" AND (s.StudentCode LIKE @kw OR s.FullName LIKE @kw OR ('PT' || printf('%04d', p.PaymentID)) LIKE @kw OR p.PaymentType LIKE @kw) ");
                parameters.Add(new SQLiteParameter("@kw", $"%{keyword.Trim()}%"));
            }

            sb.Append(" ORDER BY p.PaymentID DESC");

            return DatabaseHelper.ExecuteQuery(sb.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// Lấy lịch sử thanh toán của 1 sinh viên cụ thể (dành cho cổng sinh viên)
        /// </summary>
        public DataTable GetPaymentsByStudent(int studentId)
        {
            string sql = @"
                SELECT 
                    'PT' || printf('%04d', p.PaymentID) AS [Mã phiếu],
                    strftime('%d/%m/%Y', p.PaymentDate) AS [Ngày nộp],
                    p.Amount AS [Số tiền (đ)],
                    p.PaymentType AS [Khoản nộp],
                    p.Description AS [Nội dung],
                    CASE p.Status
                        WHEN 'Paid' THEN 'Đã thanh toán'
                        WHEN 'Pending' THEN 'Chờ xử lý'
                        WHEN 'Cancelled' THEN 'Đã hủy'
                        ELSE p.Status
                    END AS [Trạng thái]
                FROM Payments p
                WHERE p.StudentID = @StudentID
                ORDER BY p.PaymentDate DESC";

            return DatabaseHelper.ExecuteQuery(sql, new[] { new SQLiteParameter("@StudentID", studentId) });
        }

        /// <summary>
        /// Thêm mới phiếu thu / thanh toán
        /// </summary>
        public bool AddPayment(Payment payment, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (payment.Amount <= 0)
            {
                errorMessage = "Số tiền thanh toán phải lớn hơn 0!";
                return false;
            }

            try
            {
                string sql = @"
                    INSERT INTO Payments (StudentID, ContractID, PaymentDate, Amount, PaymentType, Description, Status)
                    VALUES (@StudentID, @ContractID, @PaymentDate, @Amount, @PaymentType, @Description, @Status)";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@StudentID", payment.StudentID),
                    new SQLiteParameter("@ContractID", (object?)payment.ContractID ?? DBNull.Value),
                    new SQLiteParameter("@PaymentDate", payment.PaymentDate.Date),
                    new SQLiteParameter("@Amount", payment.Amount),
                    new SQLiteParameter("@PaymentType", payment.PaymentType.Trim()),
                    new SQLiteParameter("@Description", (object?)payment.Description?.Trim() ?? DBNull.Value),
                    new SQLiteParameter("@Status", string.IsNullOrWhiteSpace(payment.Status) ? "Paid" : payment.Status)
                };

                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi thêm thanh toán: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Cập nhật phiếu thanh toán
        /// </summary>
        public bool UpdatePayment(Payment payment, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (payment.Amount <= 0)
            {
                errorMessage = "Số tiền thanh toán phải lớn hơn 0!";
                return false;
            }

            try
            {
                string sql = @"
                    UPDATE Payments
                    SET StudentID = @StudentID,
                        ContractID = @ContractID,
                        PaymentDate = @PaymentDate,
                        Amount = @Amount,
                        PaymentType = @PaymentType,
                        Description = @Description,
                        Status = @Status
                    WHERE PaymentID = @PaymentID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@PaymentID", payment.PaymentID),
                    new SQLiteParameter("@StudentID", payment.StudentID),
                    new SQLiteParameter("@ContractID", (object?)payment.ContractID ?? DBNull.Value),
                    new SQLiteParameter("@PaymentDate", payment.PaymentDate.Date),
                    new SQLiteParameter("@Amount", payment.Amount),
                    new SQLiteParameter("@PaymentType", payment.PaymentType.Trim()),
                    new SQLiteParameter("@Description", (object?)payment.Description?.Trim() ?? DBNull.Value),
                    new SQLiteParameter("@Status", payment.Status)
                };

                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi cập nhật thanh toán: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xóa phiếu thanh toán
        /// </summary>
        public bool DeletePayment(int paymentId, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                string sql = "DELETE FROM Payments WHERE PaymentID = @PaymentID";
                return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SQLiteParameter("@PaymentID", paymentId) }) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa phiếu thanh toán: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách khoản thanh toán đang chờ xử lý (Pending) của một sinh viên
        /// </summary>
        public DataTable GetPendingPayments(int studentId)
        {
            string sql = @"
                SELECT 
                    p.PaymentID,
                    'PT' || printf('%04d', p.PaymentID) AS [Mã phiếu],
                    p.Amount AS [Số tiền (đ)],
                    p.PaymentType AS [Loại chi phí],
                    p.Description AS [Nội dung],
                    strftime('%d/%m/%Y', p.PaymentDate) AS [Ngày tạo],
                    CASE 
                        WHEN p.Description LIKE '%[ĐÃ CHUYỂN KHOẢN%' THEN '⏳ Chờ Admin duyệt'
                        ELSE 'Chưa thanh toán'
                    END AS [Trạng thái]
                FROM Payments p
                WHERE p.StudentID = @StudentID AND p.Status = 'Pending'
                ORDER BY p.PaymentDate DESC, p.PaymentID DESC";

            return DatabaseHelper.ExecuteQuery(sql, new[] { new SQLiteParameter("@StudentID", studentId) });
        }

        /// <summary>
        /// Sinh viên xác nhận đã chuyển khoản qua QR, gửi yêu cầu tới Admin để chờ duyệt
        /// </summary>
        public bool RequestPaymentConfirmation(int paymentId, string? studentNote, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string getSql = "SELECT Description FROM Payments WHERE PaymentID = @PaymentID AND Status = 'Pending'";
                var dt = DatabaseHelper.ExecuteQuery(getSql, new[] { new SQLiteParameter("@PaymentID", paymentId) });
                if (dt.Rows.Count == 0)
                {
                    errorMessage = "Khoản thanh toán không tồn tại hoặc đã được xử lý.";
                    return false;
                }

                string curDesc = dt.Rows[0]["Description"]?.ToString() ?? "";
                string tag = string.IsNullOrWhiteSpace(studentNote)
                    ? "[ĐÃ CHUYỂN KHOẢN - CHỜ DUYỆT]"
                    : $"[ĐÃ CHUYỂN KHOẢN - CHỜ DUYỆT (Mã GD/Ghi chú: {studentNote.Trim()})]";

                // Loại bỏ tag cũ nếu sinh viên gửi lại
                if (curDesc.Contains("[ĐÃ CHUYỂN KHOẢN - CHỜ DUYỆT"))
                {
                    int endIdx = curDesc.IndexOf(']');
                    if (endIdx >= 0)
                    {
                        curDesc = curDesc.Substring(endIdx + 1).TrimStart(' ', '|', '-');
                    }
                }

                string newDesc = string.IsNullOrWhiteSpace(curDesc)
                    ? tag
                    : $"{tag} | {curDesc}";

                string sql = @"
                    UPDATE Payments
                    SET Description = @Description
                    WHERE PaymentID = @PaymentID AND Status = 'Pending'";

                int rows = DatabaseHelper.ExecuteNonQuery(sql, new[]
                {
                    new SQLiteParameter("@PaymentID", paymentId),
                    new SQLiteParameter("@Description", newDesc)
                });

                return rows > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi gửi yêu cầu xác nhận: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Đánh dấu khoản thanh toán đã hoàn thành (Pending → Paid)
        /// </summary>
        public bool MarkAsPaid(int paymentId, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                // Lấy thông tin khoản thanh toán trước khi cập nhật
                string sqlGet = "SELECT StudentID, Amount, PaymentType, Description FROM Payments WHERE PaymentID = @PaymentID";
                var dt = DatabaseHelper.ExecuteQuery(sqlGet, new[] { new SQLiteParameter("@PaymentID", paymentId) });
                if (dt.Rows.Count == 0)
                {
                    errorMessage = "Không tìm thấy khoản thanh toán hoặc khoản này đã được xử lý.";
                    return false;
                }

                int studentId = Convert.ToInt32(dt.Rows[0]["StudentID"]);
                decimal amount = Convert.ToDecimal(dt.Rows[0]["Amount"]);
                string paymentType = dt.Rows[0]["PaymentType"].ToString() ?? "";
                string curDesc = dt.Rows[0]["Description"]?.ToString() ?? "";

                // Cập nhật tag ghi chú rõ ràng đã được Admin duyệt
                string updatedDesc = curDesc;
                if (updatedDesc.Contains("[ĐÃ CHUYỂN KHOẢN - CHỜ DUYỆT"))
                {
                    int endIdx = updatedDesc.IndexOf(']');
                    if (endIdx >= 0)
                    {
                        string notePart = updatedDesc.Substring(0, endIdx + 1).Replace("CHỜ DUYỆT", "ADMIN ĐÃ DUYỆT");
                        string restPart = updatedDesc.Substring(endIdx + 1);
                        updatedDesc = notePart + restPart;
                    }
                }
                else if (!updatedDesc.Contains("[ADMIN ĐÃ DUYỆT]"))
                {
                    updatedDesc = "[ADMIN ĐÃ DUYỆT] " + updatedDesc;
                }

                string sql = @"
                    UPDATE Payments 
                    SET Status = 'Paid', PaymentDate = @PaymentDate, Description = @Description
                    WHERE PaymentID = @PaymentID AND Status = 'Pending'";

                int rows = DatabaseHelper.ExecuteNonQuery(sql, new[]
                {
                    new SQLiteParameter("@PaymentID", paymentId),
                    new SQLiteParameter("@PaymentDate", DateTime.Today.ToString("yyyy-MM-dd")),
                    new SQLiteParameter("@Description", updatedDesc)
                });

                if (rows > 0)
                {
                    // Nếu là nộp tiền phạt vi phạm, tự động gạch nợ trong bảng Violations
                    if (paymentType.Contains("phạt", StringComparison.OrdinalIgnoreCase) || paymentType.Contains("vi phạm", StringComparison.OrdinalIgnoreCase))
                    {
                        string sqlUpdateViolation = @"
                            UPDATE Violations
                            SET Status = 'Paid'
                            WHERE StudentID = @StudentID AND Status = 'Unpaid' AND FineAmount = @Amount";
                        DatabaseHelper.ExecuteNonQuery(sqlUpdateViolation, new[]
                        {
                            new SQLiteParameter("@StudentID", studentId),
                            new SQLiteParameter("@Amount", amount)
                        });
                    }
                    return true;
                }

                errorMessage = "Không tìm thấy khoản thanh toán hoặc khoản này đã được xử lý.";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi cập nhật trạng thái: " + ex.Message;
                return false;
            }
        }

        #endregion
    }
}
