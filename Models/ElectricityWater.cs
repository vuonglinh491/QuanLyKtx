namespace QuanLyKtx.Models
{
    public class ElectricityWater
    {
        public int RecordID { get; set; }
        public int RoomID { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal OldElectricIndex { get; set; }
        public decimal NewElectricIndex { get; set; }
        public decimal ElectricAmount { get; set; }
        public decimal OldWaterIndex { get; set; }
        public decimal NewWaterIndex { get; set; }
        public decimal WaterAmount { get; set; }
        public decimal TotalAmount { get; set; }

        // Thuộc tính hỗ trợ hiển thị
        public string? RoomNumber { get; set; }
        public string? BuildingName { get; set; }
        public decimal ElectricUsed => NewElectricIndex >= OldElectricIndex ? NewElectricIndex - OldElectricIndex : 0;
        public decimal WaterUsed => NewWaterIndex >= OldWaterIndex ? NewWaterIndex - OldWaterIndex : 0;
    }
}
