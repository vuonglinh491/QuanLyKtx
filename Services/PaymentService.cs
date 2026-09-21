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

                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
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

                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
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
                string sql = "DELETE FROM ElectricityWater WHERE RecordID = @RecordID";
                return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SQLiteParameter("@RecordID", recordId) }) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa bản ghi điện nước: " + ex.Message;
                return false;
            }
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
                        WHEN 'Pending' THEN 'Chờ xử lý'
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
                    strftime('%d/%m/%Y', p.PaymentDate) AS [Ngày tạo]
                FROM Payments p
                WHERE p.StudentID = @StudentID AND p.Status = 'Pending'
                ORDER BY p.PaymentDate DESC, p.PaymentID DESC";

            return DatabaseHelper.ExecuteQuery(sql, new[] { new SQLiteParameter("@StudentID", studentId) });
        }

        /// <summary>
        /// Đánh dấu khoản thanh toán đã hoàn thành (Pending → Paid)
        /// </summary>
        public bool MarkAsPaid(int paymentId, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                string sql = @"
                    UPDATE Payments 
                    SET Status = 'Paid', PaymentDate = @PaymentDate
                    WHERE PaymentID = @PaymentID AND Status = 'Pending'";

                int rows = DatabaseHelper.ExecuteNonQuery(sql, new[]
                {
                    new SQLiteParameter("@PaymentID", paymentId),
                    new SQLiteParameter("@PaymentDate", DateTime.Today)
                });

                if (rows == 0)
                {
                    errorMessage = "Không tìm thấy khoản thanh toán hoặc khoản này đã được xử lý.";
                    return false;
                }
                return true;
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
