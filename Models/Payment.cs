using System;

namespace QuanLyKtx.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int StudentID { get; set; }
        public int? ContractID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = "Paid"; // Paid, Pending, Cancelled

        // Thuộc tính hỗ trợ hiển thị
        public string? StudentCode { get; set; }
        public string? StudentName { get; set; }
    }
}
