using System;
using System.Data;
using System.Text;
using System.Data.SQLite;
using QuanLyKtx.Data;
using QuanLyKtx.Models;

namespace QuanLyKtx.Services
{
    public class ContractService
    {
        /// <summary>
        /// Lấy toàn bộ danh sách hợp đồng có bộ lọc trạng thái và tìm kiếm
        /// </summary>
        public DataTable GetAllContracts(string? status = null, string? keyword = null)
        {
            var sb = new StringBuilder(@"
                SELECT 
                    c.ContractID,
                    c.StudentID,
                    c.RoomID,
                    'HD' || printf('%04d', c.ContractID) AS [Mã HĐ],
                    s.StudentCode AS [Mã SV],
                    s.FullName AS [Họ và tên],
                    b.BuildingName AS [Khu nhà],
                    r.RoomNumber AS [Số phòng],
                    strftime('%d/%m/%Y', c.StartDate) AS [Ngày bắt đầu],
                    strftime('%d/%m/%Y', c.EndDate) AS [Ngày kết thúc],
                    c.MonthlyFee AS [Tiền phòng/tháng],
                    c.Deposit AS [Tiền đặt cọc],
                    CASE c.Status
                        WHEN 'Active' THEN 'Đang hiệu lực'
                        WHEN 'Expired' THEN 'Hết hạn'
                        WHEN 'Terminated' THEN 'Đã thanh lý'
                        ELSE c.Status
                    END AS [Trạng thái],
                    c.Status AS [StatusCode],
                    c.StartDate,
                    c.EndDate
                FROM Contracts c
                JOIN Students s ON c.StudentID = s.StudentID
                JOIN Rooms r ON c.RoomID = r.RoomID
                JOIN Buildings b ON r.BuildingID = b.BuildingID
                WHERE 1=1 ");

            var parameters = new System.Collections.Generic.List<SQLiteParameter>();

            if (!string.IsNullOrWhiteSpace(status) && status != "All")
            {
                sb.Append(" AND c.Status = @Status ");
                parameters.Add(new SQLiteParameter("@Status", status));
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sb.Append(" AND (s.StudentCode LIKE @kw OR s.FullName LIKE @kw OR r.RoomNumber LIKE @kw OR ('HD' || printf('%04d', c.ContractID)) LIKE @kw) ");
                parameters.Add(new SQLiteParameter("@kw", $"%{keyword.Trim()}%"));
            }

            sb.Append(" ORDER BY c.ContractID DESC");

            return DatabaseHelper.ExecuteQuery(sb.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// Lấy danh sách sinh viên phục vụ tạo hợp đồng
        /// </summary>
        public DataTable GetStudentsForContract()
        {
            string sql = @"
                SELECT 
                    s.StudentID,
                    s.StudentCode || ' - ' || s.FullName || ' (' || s.ClassName || ')' AS [StudentDisplayName]
                FROM Students s
                ORDER BY s.StudentCode ASC";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// Lấy danh sách phòng cho chọn hợp đồng
        /// </summary>
        public DataTable GetRoomsForContract()
        {
            string sql = @"
                SELECT 
                    r.RoomID,
                    b.BuildingName || ' - Phòng ' || r.RoomNumber || ' (' || printf('%,.0f', r.Price) || ' đ/tháng)' AS [RoomDisplayName],
                    r.Price
                FROM Rooms r
                JOIN Buildings b ON r.BuildingID = b.BuildingID
                ORDER BY b.BuildingName, r.RoomNumber";

            return DatabaseHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// Thêm mới hợp đồng thuê phòng
        /// </summary>
        public bool AddContract(Contract contract, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (contract.EndDate < contract.StartDate)
            {
                errorMessage = "Ngày kết thúc hợp đồng phải sau hoặc cùng ngày bắt đầu!";
                return false;
            }

            if (contract.MonthlyFee < 0)
            {
                errorMessage = "Tiền phòng hàng tháng không thể nhỏ hơn 0!";
                return false;
            }

            if (contract.Deposit < 0)
            {
                errorMessage = "Tiền đặt cọc không thể nhỏ hơn 0!";
                return false;
            }

            try
            {
                string sql = @"
                    INSERT INTO Contracts (StudentID, RoomID, StartDate, EndDate, MonthlyFee, Deposit, Status)
                    VALUES (@StudentID, @RoomID, @StartDate, @EndDate, @MonthlyFee, @Deposit, @Status)";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@StudentID", contract.StudentID),
                    new SQLiteParameter("@RoomID", contract.RoomID),
                    new SQLiteParameter("@StartDate", contract.StartDate.Date),
                    new SQLiteParameter("@EndDate", contract.EndDate.Date),
                    new SQLiteParameter("@MonthlyFee", contract.MonthlyFee),
                    new SQLiteParameter("@Deposit", contract.Deposit),
                    new SQLiteParameter("@Status", string.IsNullOrWhiteSpace(contract.Status) ? "Active" : contract.Status)
                };

                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi tạo hợp đồng: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Cập nhật hợp đồng
        /// </summary>
        public bool UpdateContract(Contract contract, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (contract.EndDate < contract.StartDate)
            {
                errorMessage = "Ngày kết thúc hợp đồng phải sau hoặc cùng ngày bắt đầu!";
                return false;
            }

            if (contract.MonthlyFee < 0)
            {
                errorMessage = "Tiền phòng hàng tháng không thể nhỏ hơn 0!";
                return false;
            }

            if (contract.Deposit < 0)
            {
                errorMessage = "Tiền đặt cọc không thể nhỏ hơn 0!";
                return false;
            }

            try
            {
                string sql = @"
                    UPDATE Contracts
                    SET StudentID = @StudentID,
                        RoomID = @RoomID,
                        StartDate = @StartDate,
                        EndDate = @EndDate,
                        MonthlyFee = @MonthlyFee,
                        Deposit = @Deposit,
                        Status = @Status
                    WHERE ContractID = @ContractID";

                var parameters = new SQLiteParameter[]
                {
                    new SQLiteParameter("@ContractID", contract.ContractID),
                    new SQLiteParameter("@StudentID", contract.StudentID),
                    new SQLiteParameter("@RoomID", contract.RoomID),
                    new SQLiteParameter("@StartDate", contract.StartDate.Date),
                    new SQLiteParameter("@EndDate", contract.EndDate.Date),
                    new SQLiteParameter("@MonthlyFee", contract.MonthlyFee),
                    new SQLiteParameter("@Deposit", contract.Deposit),
                    new SQLiteParameter("@Status", contract.Status)
                };

                return DatabaseHelper.ExecuteNonQuery(sql, parameters) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi cập nhật hợp đồng: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Thanh lý / Hủy hợp đồng
        /// </summary>
        public bool TerminateContract(int contractId, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                string sql = "UPDATE Contracts SET Status = 'Terminated' WHERE ContractID = @ContractID";
                return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SQLiteParameter("@ContractID", contractId) }) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi thanh lý hợp đồng: " + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Xóa hợp đồng khỏi hệ thống
        /// </summary>
        public bool DeleteContract(int contractId, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Kiểm tra xem hợp đồng đã phát sinh thanh toán nào chưa
            string checkPayments = "SELECT COUNT(1) FROM Payments WHERE ContractID = @ContractID";
            var countObj = DatabaseHelper.ExecuteScalar(checkPayments, new[] { new SQLiteParameter("@ContractID", contractId) });
            if (countObj != null && Convert.ToInt32(countObj) > 0)
            {
                errorMessage = "Hợp đồng này đã có lịch sử hóa đơn thanh toán! Không thể xóa. Bạn có thể chọn Thanh lý hợp đồng.";
                return false;
            }

            try
            {
                string sql = "DELETE FROM Contracts WHERE ContractID = @ContractID";
                return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SQLiteParameter("@ContractID", contractId) }) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa hợp đồng: " + ex.Message;
                return false;
            }
        }
    }
}
