using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace QuanLyKtx.Utils
{
    public static class DataGridViewHelper
    {
        public static void Configure(DataGridView grid)
        {
            // Bật DoubleBuffered chống giật lag / nhấp nháy khi cuộn bảng
            EnableDoubleBuffer(grid);

            // Bố cục & cuộn
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grid.RowTemplate.Height = 34;
            grid.AllowUserToResizeRows = false;
            grid.RowHeadersVisible = false;
            grid.ScrollBars = ScrollBars.Both;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(226, 232, 240); // Slate 200

            // Header chuyên nghiệp
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 38;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249); // Slate 100
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);    // Slate 800
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);

            // Hàng dữ liệu chuẩn
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42); // Slate 900
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254); // Blue 100
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            grid.DefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Hiệu ứng Zebra striping (hàng xen kẽ) tăng khả năng đọc
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252); // Slate 50
            grid.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            grid.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

            // Tự động phân màu badge cho các cột trạng thái
            grid.CellFormatting -= Grid_CellFormatting;
            grid.CellFormatting += Grid_CellFormatting;

            // Gắn lại sự kiện DataBindingComplete
            grid.DataBindingComplete -= Grid_DataBindingComplete;
            grid.DataBindingComplete += Grid_DataBindingComplete;

            // Tooltip khi trỏ chuột vào ô
            grid.CellToolTipTextNeeded -= Grid_CellToolTipTextNeeded;
            grid.CellToolTipTextNeeded += Grid_CellToolTipTextNeeded;
        }

        private static void EnableDoubleBuffer(DataGridView grid)
        {
            try
            {
                var dgvType = grid.GetType();
                var pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
                pi?.SetValue(grid, true, null);
            }
            catch
            {
                // Bỏ qua nếu môi trường không cho phép truy xuất reflection
            }
        }

        private static void Grid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is not DataGridView grid || grid.Columns.Count == 0) return;

            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            foreach (DataGridViewColumn column in grid.Columns)
            {
                if (column.Visible && column.Width < 75)
                {
                    column.Width = 75;
                }
            }
        }

        private static void Grid_CellToolTipTextNeeded(object? sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (sender is DataGridView grid && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var val = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (!string.IsNullOrEmpty(val))
                {
                    e.ToolTipText = val;
                }
            }
        }

        private static void Grid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || sender is not DataGridView grid || e.CellStyle == null) return;

            string colName = grid.Columns[e.ColumnIndex].HeaderText?.Trim().ToLower() ?? "";
            string val = e.Value.ToString()?.Trim() ?? "";

            // Nhận diện cột trạng thái
            if (colName.Contains("trạng thái") || colName.Contains("tình trạng") || colName.Contains("status"))
            {
                string lowerVal = val.ToLower();

                // Nhóm thành công / Hoạt động / Đã thanh toán
                if (lowerVal.Contains("active") || lowerVal.Contains("đang ở") ||
                    lowerVal.Contains("đã duyệt") || lowerVal.Contains("approved") ||
                    lowerVal.Contains("đã nộp") || lowerVal.Contains("đã thu") ||
                    lowerVal.Contains("paid") || lowerVal.Contains("đã thanh toán") ||
                    lowerVal.Contains("hoạt động") || lowerVal.Contains("còn trống") ||
                    lowerVal.Contains("available") || lowerVal.Contains("bình thường"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(6, 95, 70); // Emerald 800
                    e.CellStyle.Font = new Font(grid.Font.FontFamily, grid.Font.Size, FontStyle.Bold);
                }
                // Nhóm chờ xử lý / Cảnh báo / Chưa thu
                else if (lowerVal.Contains("pending") || lowerVal.Contains("chờ duyệt") ||
                         lowerVal.Contains("chờ") || lowerVal.Contains("unpaid") ||
                         lowerVal.Contains("chưa nộp") || lowerVal.Contains("chưa thu") ||
                         lowerVal.Contains("đang xử lý") || lowerVal.Contains("sắp hết hạn"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9); // Amber 700
                    e.CellStyle.Font = new Font(grid.Font.FontFamily, grid.Font.Size, FontStyle.Bold);
                }
                // Nhóm từ chối / Hết hạn / Vi phạm / Khóa
                else if (lowerVal.Contains("rejected") || lowerVal.Contains("từ chối") ||
                         lowerVal.Contains("đã hủy") || lowerVal.Contains("cancelled") ||
                         lowerVal.Contains("inactive") || lowerVal.Contains("vi phạm") ||
                         lowerVal.Contains("hết hạn") || lowerVal.Contains("đầy") ||
                         lowerVal.Contains("full") || lowerVal.Contains("đã trả phòng"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28); // Red 700
                    e.CellStyle.Font = new Font(grid.Font.FontFamily, grid.Font.Size, FontStyle.Bold);
                }
            }
        }
    }
}
