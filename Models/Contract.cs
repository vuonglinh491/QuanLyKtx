using System;

namespace QuanLyKtx.Models
{
    public class Contract
    {
        public int ContractID { get; set; }
        public int StudentID { get; set; }
        public int RoomID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MonthlyFee { get; set; }
        public decimal Deposit { get; set; }
        public string Status { get; set; } = "Active"; // Active, Expired, Terminated

        // Thuộc tính hỗ trợ hiển thị
        public string? StudentCode { get; set; }
        public string? StudentName { get; set; }
        public string? RoomNumber { get; set; }
        public string? BuildingName { get; set; }
    }
}
