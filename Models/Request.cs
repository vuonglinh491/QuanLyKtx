using System;

namespace QuanLyKtx.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public int StudentID { get; set; }
        public string RequestType { get; set; } = string.Empty; // RegisterRoom, ChangeRoom, LeaveRoom
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ProcessedAt { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
        public string? ManagerNote { get; set; }

        // Thuộc tính hỗ trợ hiển thị
        public string? StudentCode { get; set; }
        public string? StudentName { get; set; }
    }
}
