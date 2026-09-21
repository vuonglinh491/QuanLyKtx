using System;

namespace QuanLyKtx.Models
{
    public class RoomAssignment
    {
        public int AssignmentID { get; set; }
        public int StudentID { get; set; }
        public int RoomID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = "Active"; // Active, Ended

        // Thuộc tính hỗ trợ hiển thị
        public string? StudentCode { get; set; }
        public string? StudentName { get; set; }
        public string? RoomNumber { get; set; }
        public string? BuildingName { get; set; }
    }
}
