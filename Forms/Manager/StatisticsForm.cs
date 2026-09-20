using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPdfLicenseType = QuestPDF.Infrastructure.LicenseType;
using QuanLyKtx.Data;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Manager
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void StatisticsForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyles();
            LoadYears();
            LoadAllStatistics();
        }

        private void SetupDataGridViewStyles()
        {
            DataGridView[] grids = { dgvRevenue, dgvOccupancy, dgvViolations };
            foreach (var dgv in grids)
            {
                DataGridViewHelper.Configure(dgv);
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
                dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            }
        }

        private void LoadYears()
        {
            cboYear.Items.Clear();
            int currentYear = DateTime.Today.Year;
            for (int y = currentYear; y >= currentYear - 4; y--)
            {
                cboYear.Items.Add(y.ToString());
            }
            if (cboYear.Items.Count > 0)
                cboYear.SelectedIndex = 0;
        }

        private int GetSelectedYear()
        {
            if (cboYear.SelectedItem != null && int.TryParse(cboYear.SelectedItem.ToString(), out int yr))
                return yr;
            return DateTime.Today.Year;
        }

        private void LoadAllStatistics()
        {
            int year = GetSelectedYear();
            LoadSummaryCards(year);
            LoadMonthlyRevenue(year);
            LoadOccupancyStats();
            LoadViolationsStats(year);
        }

        private void LoadSummaryCards(int year)
        {
            try
            {
                // Tổng doanh thu KTX
                string sqlTotal = @"
                    SELECT ISNULL(SUM(Amount), 0)
                    FROM dbo.Payments
                    WHERE YEAR(PaymentDate) = @Year AND Status = 'Paid'";

                var objTotal = DatabaseHelper.ExecuteScalar(sqlTotal, new[] { new SqlParameter("@Year", year) });
                decimal totalRev = (objTotal != null && objTotal != DBNull.Value) ? Convert.ToDecimal(objTotal) : 0m;
                lblTotalRevenueValue.Text = totalRev.ToString("N0") + " đ";

                // Doanh thu tiền phòng
                string sqlRoom = @"
                    SELECT ISNULL(SUM(Amount), 0)
                    FROM dbo.Payments
                    WHERE YEAR(PaymentDate) = @Year AND Status = 'Paid' AND PaymentType = 'Room'";

                var objRoom = DatabaseHelper.ExecuteScalar(sqlRoom, new[] { new SqlParameter("@Year", year) });
                decimal roomRev = (objRoom != null && objRoom != DBNull.Value) ? Convert.ToDecimal(objRoom) : 0m;
                lblRoomRevenueValue.Text = roomRev.ToString("N0") + " đ";

                // Doanh thu điện nước
                string sqlUtil = @"
                    SELECT ISNULL(SUM(Amount), 0)
                    FROM dbo.Payments
                    WHERE YEAR(PaymentDate) = @Year AND Status = 'Paid' AND PaymentType = 'ElectricityWater'";

                var objUtil = DatabaseHelper.ExecuteScalar(sqlUtil, new[] { new SqlParameter("@Year", year) });
                decimal utilRev = (objUtil != null && objUtil != DBNull.Value) ? Convert.ToDecimal(objUtil) : 0m;
                lblUtilityRevenueValue.Text = utilRev.ToString("N0") + " đ";

                // Tỷ lệ lấp đầy
                string sqlOcc = @"
                    SELECT ISNULL(SUM(CurrentOccupancy), 0) AS Occ, ISNULL(SUM(Capacity), 0) AS Cap
                    FROM dbo.Rooms";

                var dtOcc = DatabaseHelper.ExecuteQuery(sqlOcc);
                if (dtOcc.Rows.Count > 0)
                {
                    int occ = Convert.ToInt32(dtOcc.Rows[0]["Occ"]);
                    int cap = Convert.ToInt32(dtOcc.Rows[0]["Cap"]);
                    if (cap > 0)
                    {
                        double rate = Math.Round(((double)occ / cap) * 100, 1);
                        lblOccupancyValue.Text = $"{rate}% ({occ}/{cap})";
                    }
                    else
                    {
                        lblOccupancyValue.Text = "0%";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính toán chỉ số thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonthlyRevenue(int year)
        {
            try
            {
                string sql = @"
                    WITH Months AS (
                        SELECT 1 AS [Month] UNION SELECT 2 UNION SELECT 3 UNION SELECT 4
                        UNION SELECT 5 UNION SELECT 6 UNION SELECT 7 UNION SELECT 8
                        UNION SELECT 9 UNION SELECT 10 UNION SELECT 11 UNION SELECT 12
                    )
                    SELECT 
                        'Tháng ' + CAST(m.[Month] AS VARCHAR(2)) AS [Tháng],
                        @Year AS [Năm],
                        ISNULL(SUM(CASE WHEN p.PaymentType = 'Room' THEN p.Amount ELSE 0 END), 0) AS [Tiền phòng (đ)],
                        ISNULL(SUM(CASE WHEN p.PaymentType = 'ElectricityWater' THEN p.Amount ELSE 0 END), 0) AS [Điện nước (đ)],
                        ISNULL(SUM(CASE WHEN p.PaymentType = 'Violation' THEN p.Amount ELSE 0 END), 0) AS [Phạt vi phạm (đ)],
                        ISNULL(SUM(p.Amount), 0) AS [Tổng doanh thu (đ)]
                    FROM Months m
                    LEFT JOIN dbo.Payments p ON MONTH(p.PaymentDate) = m.[Month] AND YEAR(p.PaymentDate) = @Year AND p.Status = 'Paid'
                    GROUP BY m.[Month]
                    ORDER BY m.[Month]";

                var dt = DatabaseHelper.ExecuteQuery(sql, new[] { new SqlParameter("@Year", year) });
                dgvRevenue.DataSource = dt;

                string[] curCols = { "Tiền phòng (đ)", "Điện nước (đ)", "Phạt vi phạm (đ)", "Tổng doanh thu (đ)" };
                foreach (var col in curCols)
                {
                    if (dgvRevenue.Columns.Contains(col))
                    {
                        dgvRevenue.Columns[col].DefaultCellStyle.Format = "N0";
                        dgvRevenue.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }

                dgvRevenue.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOccupancyStats()
        {
            try
            {
                string sql = @"
                    SELECT 
                        b.BuildingName AS [Tòa nhà],
                        N'Tất cả' AS [Dành cho],
                        COUNT(r.RoomID) AS [Tổng số phòng],
                        ISNULL(SUM(r.Capacity), 0) AS [Tổng sức chứa (chỗ)],
                        ISNULL(SUM(r.CurrentOccupancy), 0) AS [Đang lưu trú (SV)],
                        ISNULL(SUM(r.Capacity - r.CurrentOccupancy), 0) AS [Số chỗ trống],
                        CASE WHEN ISNULL(SUM(r.Capacity), 0) > 0 
                             THEN CAST(ROUND(CAST(SUM(r.CurrentOccupancy) AS FLOAT) / SUM(r.Capacity) * 100, 1) AS VARCHAR(10)) + '%'
                             ELSE '0%' 
                        END AS [Tỷ lệ lấp đầy]
                    FROM dbo.Buildings b
                    LEFT JOIN dbo.Rooms r ON b.BuildingID = r.BuildingID
                    GROUP BY b.BuildingID, b.BuildingName
                    ORDER BY b.BuildingName";

                var dt = DatabaseHelper.ExecuteQuery(sql);
                dgvOccupancy.DataSource = dt;
                dgvOccupancy.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê tỷ lệ lấp đầy: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadViolationsStats(int year)
        {
            try
            {
                string sql = @"
                    SELECT 
                        v.ViolationType AS [Hành vi vi phạm],
                        COUNT(v.ViolationID) AS [Số vụ vi phạm],
                        ISNULL(SUM(v.FineAmount), 0) AS [Tổng tiền phạt (đ)],
                        ISNULL(SUM(CASE WHEN v.Status = 'Paid' THEN v.FineAmount ELSE 0 END), 0) AS [Đã thu (đ)],
                        ISNULL(SUM(CASE WHEN v.Status = 'Unpaid' THEN v.FineAmount ELSE 0 END), 0) AS [Chưa thu (đ)]
                    FROM dbo.Violations v
                    WHERE YEAR(v.ViolationDate) = @Year
                    GROUP BY v.ViolationType
                    ORDER BY [Số vụ vi phạm] DESC";

                var dt = DatabaseHelper.ExecuteQuery(sql, new[] { new SqlParameter("@Year", year) });
                dgvViolations.DataSource = dt;

                string[] curCols = { "Tổng tiền phạt (đ)", "Đã thu (đ)", "Chưa thu (đ)" };
                foreach (var col in curCols)
                {
                    if (dgvViolations.Columns.Contains(col))
                    {
                        dgvViolations.Columns[col].DefaultCellStyle.Format = "N0";
                        dgvViolations.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }

                dgvViolations.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê vi phạm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboYear_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadAllStatistics();
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadAllStatistics();
        }

        private void btnExportPdf_Click(object? sender, EventArgs e)
        {
            DataGridView? currentGrid = null;
            string defaultFileName = "BaoCao_";
            string reportTitle = "BÁO CÁO THỐNG KÊ";

            if (tabStatistics.SelectedTab == tabRevenue)
            {
                currentGrid = dgvRevenue;
                defaultFileName += "DoanhThu_" + GetSelectedYear();
                reportTitle = $"BÁO CÁO DOANH THU NĂM {GetSelectedYear()}";
            }
            else if (tabStatistics.SelectedTab == tabOccupancy)
            {
                currentGrid = dgvOccupancy;
                defaultFileName += "TyLeLapDay";
                reportTitle = "BÁO CÁO TỶ LỆ LẤP ĐẦY KÝ TÚC XÁ";
            }
            else if (tabStatistics.SelectedTab == tabViolations)
            {
                currentGrid = dgvViolations;
                defaultFileName += "ViPham_" + GetSelectedYear();
                reportTitle = $"BÁO CÁO VI PHẠM NĂM {GetSelectedYear()}";
            }

            if (currentGrid == null || currentGrid.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trong bảng hiện tại để xuất file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "File PDF (*.pdf)|*.pdf",
                FileName = defaultFileName + ".pdf",
                Title = "Lưu file báo cáo thống kê"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    QuestPDF.Settings.License = QuestPdfLicenseType.Community;
                    var visibleColumns = new List<DataGridViewColumn>();
                    foreach (DataGridViewColumn column in currentGrid.Columns)
                    {
                        if (column.Visible) visibleColumns.Add(column);
                    }

                    Document.Create(document => document.Page(page =>
                    {
                        page.Size(PageSizes.A4.Landscape());
                        page.Margin(24);
                        page.DefaultTextStyle(style => style.FontFamily("Arial").FontSize(8));
                        page.Header().Column(column =>
                        {
                            column.Item().AlignCenter().Text(reportTitle).Bold().FontSize(15);
                            column.Item().AlignCenter().Text($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(8);
                        });
                        page.Content().PaddingTop(14).Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                foreach (var _ in visibleColumns) columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                foreach (DataGridViewColumn column in visibleColumns)
                                {
                                    header.Cell().Background(Colors.Blue.Darken2).Padding(4)
                                        .Text(column.HeaderText).FontColor(Colors.White).Bold();
                                }
                            });

                            foreach (DataGridViewRow row in currentGrid.Rows)
                            {
                                if (row.IsNewRow) continue;
                                foreach (DataGridViewColumn column in visibleColumns)
                                {
                                    string value = row.Cells[column.Index].Value?.ToString() ?? string.Empty;
                                    table.Cell().Border(0.5f).BorderColor(Colors.Grey.Lighten2).Padding(4).Text(value);
                                }
                            }
                        });
                        page.Footer().AlignCenter().Text(text =>
                        {
                            text.Span("Trang ");
                            text.CurrentPageNumber();
                            text.Span(" / ");
                            text.TotalPages();
                        });
                    })).GeneratePdf(sfd.FileName);

                    MessageBox.Show($"Đã xuất file báo cáo thành công tại:\n{sfd.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
