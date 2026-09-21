using System;

namespace QuanLyKtx.Models
{
    public class Violation
    {
        public int ViolationID { get; set; }
        public int StudentID { get; set; }
        public DateTime ViolationDate { get; set; }
        public string ViolationType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal FineAmount { get; set; }
        public string Status { get; set; } = "Unpaid"; // Unpaid, Paid

        // Thuộc tính hỗ trợ hiển thị
        public string? StudentCode { get; set; }
        public string? StudentName { get; set; }
    }
}
