namespace QuanLyKtx.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public int BuildingID { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public int Floor { get; set; }
        public int Capacity { get; set; }
        public int CurrentOccupancy { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Status { get; set; } = "Available"; // Available, Full, Maintenance

        // Thuộc tính hỗ trợ hiển thị
        public string? BuildingName { get; set; }
    }
}
