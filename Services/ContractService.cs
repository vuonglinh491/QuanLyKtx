using System;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;
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
                    'HD' + RIGHT('0000' + CAST(c.ContractID AS VARCHAR(10)), 4) AS [Mã HĐ],
                    s.StudentCode AS [Mã SV],
                    s.FullName AS [Họ và tên],
                    b.BuildingName AS [Khu nhà],
                    r.RoomNumber AS [Số phòng],
                    CONVERT(VARCHAR(10), c.StartDate, 103) AS [Ngày bắt đầu],
                    CONVERT(VARCHAR(10), c.EndDate, 103) AS [Ngày kết thúc],
                    c.MonthlyFee AS [Tiền phòng/tháng],
                    c.Deposit AS [Tiền đặt cọc],
                    CASE c.Status
                        WHEN 'Active' THEN N'Đang hiệu lực'
                        WHEN 'Expired' THEN N'Hết hạn'
                        WHEN 'Terminated' THEN N'Đã thanh lý'
                        ELSE c.Status
                    END AS [Trạng thái],
                    c.Status AS [StatusCode],
                    c.StartDate,
                    c.EndDate
                FROM dbo.Contracts c
                JOIN dbo.Students s ON c.StudentID = s.StudentID
                JOIN dbo.Rooms r ON c.RoomID = r.RoomID
                JOIN dbo.Buildings b ON r.BuildingID = b.BuildingID
                WHERE 1=1 ");

            var parameters = new System.Collections.Generic.List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(status) && status != "All")
            {
                sb.Append(" AND c.Status = @Status ");
                parameters.Add(new SqlParameter("@Status", status));
            }

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                sb.Append(" AND (s.StudentCode LIKE @kw OR s.FullName LIKE @kw OR r.RoomNumber LIKE @kw OR ('HD' + RIGHT('0000' + CAST(c.ContractID AS VARCHAR(10)), 4)) LIKE @kw) ");
                parameters.Add(new SqlParameter("@kw", $"%{keyword.Trim()}%"));
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
                    s.StudentCode + ' - ' + s.FullName + ' (' + s.ClassName + ')' AS [StudentDisplayName]
                FROM dbo.Students s
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
                    b.BuildingName + ' - Phòng ' + r.RoomNumber + ' (' + FORMAT(r.Price, 'N0') + ' đ/tháng)' AS [RoomDisplayName],
                    r.Price
                FROM dbo.Rooms r
                JOIN dbo.Buildings b ON r.BuildingID = b.BuildingID
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
                    INSERT INTO dbo.Contracts (StudentID, RoomID, StartDate, EndDate, MonthlyFee, Deposit, Status)
                    VALUES (@StudentID, @RoomID, @StartDate, @EndDate, @MonthlyFee, @Deposit, @Status)";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@StudentID", contract.StudentID),
                    new SqlParameter("@RoomID", contract.RoomID),
                    new SqlParameter("@StartDate", contract.StartDate.Date),
                    new SqlParameter("@EndDate", contract.EndDate.Date),
                    new SqlParameter("@MonthlyFee", contract.MonthlyFee),
                    new SqlParameter("@Deposit", contract.Deposit),
                    new SqlParameter("@Status", string.IsNullOrWhiteSpace(contract.Status) ? "Active" : contract.Status)
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
                    UPDATE dbo.Contracts
                    SET StudentID = @StudentID,
                        RoomID = @RoomID,
                        StartDate = @StartDate,
                        EndDate = @EndDate,
                        MonthlyFee = @MonthlyFee,
                        Deposit = @Deposit,
                        Status = @Status
                    WHERE ContractID = @ContractID";

                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@ContractID", contract.ContractID),
                    new SqlParameter("@StudentID", contract.StudentID),
                    new SqlParameter("@RoomID", contract.RoomID),
                    new SqlParameter("@StartDate", contract.StartDate.Date),
                    new SqlParameter("@EndDate", contract.EndDate.Date),
                    new SqlParameter("@MonthlyFee", contract.MonthlyFee),
                    new SqlParameter("@Deposit", contract.Deposit),
                    new SqlParameter("@Status", contract.Status)
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
                string sql = "UPDATE dbo.Contracts SET Status = 'Terminated' WHERE ContractID = @ContractID";
                return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SqlParameter("@ContractID", contractId) }) > 0;
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
            string checkPayments = "SELECT COUNT(1) FROM dbo.Payments WHERE ContractID = @ContractID";
            var countObj = DatabaseHelper.ExecuteScalar(checkPayments, new[] { new SqlParameter("@ContractID", contractId) });
            if (countObj != null && Convert.ToInt32(countObj) > 0)
            {
                errorMessage = "Hợp đồng này đã có lịch sử hóa đơn thanh toán! Không thể xóa. Bạn có thể chọn Thanh lý hợp đồng.";
                return false;
            }

            try
            {
                string sql = "DELETE FROM dbo.Contracts WHERE ContractID = @ContractID";
                return DatabaseHelper.ExecuteNonQuery(sql, new[] { new SqlParameter("@ContractID", contractId) }) > 0;
            }
            catch (Exception ex)
            {
                errorMessage = "Lỗi khi xóa hợp đồng: " + ex.Message;
                return false;
            }
        }
    }
}
