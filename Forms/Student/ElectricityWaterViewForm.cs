using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLyKtx.Data;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Student
{
    public partial class ElectricityWaterViewForm : Form
    {
        private int _currentRoomId = 0;

        public ElectricityWaterViewForm()
        {
            InitializeComponent();
        }

        private void ElectricityWaterViewForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            LoadYearDropdown();
            LoadStudentRoom();
            LoadBills();
        }

        private void SetupDataGridViewStyle()
        {
            dgvBills.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvBills.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvBills.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvBills.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvBills.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvBills.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadYearDropdown()
        {
            cboFilterYear.Items.Clear();
            cboFilterYear.Items.Add("Tất cả");
            int curYear = DateTime.Today.Year;
            for (int y = curYear; y >= curYear - 5; y--)
            {
                cboFilterYear.Items.Add(y.ToString());
            }
            cboFilterYear.SelectedIndex = 0;
        }

        private void LoadStudentRoom()
        {
            if (!Session.StudentID.HasValue) return;

            try
            {
                string sql = @"
                    SELECT r.RoomID, b.BuildingName + ' - Phòng ' + r.RoomNumber AS RoomTitle
                    FROM dbo.RoomAssignments a
                    JOIN dbo.Rooms r ON a.RoomID = r.RoomID
                    JOIN dbo.Buildings b ON r.BuildingID = b.BuildingID
                    WHERE a.StudentID = @StudentID AND a.Status = 'Active'";

                var dt = DatabaseHelper.ExecuteQuery(sql, new[] { new SqlParameter("@StudentID", Session.StudentID.Value) });
                if (dt.Rows.Count > 0)
                {
                    _currentRoomId = Convert.ToInt32(dt.Rows[0]["RoomID"]);
                    lblRoomTitle.Text = $"Hóa đơn Điện & Nước: {dt.Rows[0]["RoomTitle"]}";
                }
                else
                {
                    lblRoomTitle.Text = "Bạn chưa được phân phòng đang hoạt động.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBills()
        {
            if (_currentRoomId <= 0)
            {
                dgvBills.DataSource = null;
                return;
            }

            try
            {
                string sql = @"
                    SELECT 
                        ew.LogID,
                        ew.Month AS [Tháng],
                        ew.Year AS [Năm],
                        ew.ElectricityOld AS [Số điện cũ],
                        ew.ElectricityNew AS [Số điện mới],
                        (ew.ElectricityNew - ew.ElectricityOld) AS [Điện tiêu thụ (kWh)],
                        ew.ElectricityCost AS [Tiền điện (đ)],
                        ew.WaterOld AS [Số nước cũ],
                        ew.WaterNew AS [Số nước mới],
                        (ew.WaterNew - ew.WaterOld) AS [Nước tiêu thụ (m³)],
                        ew.WaterCost AS [Tiền nước (đ)],
                        ew.TotalAmount AS [Tổng cộng (đ)],
                        CASE ew.Status
                            WHEN 'Paid' THEN N'Đã thanh toán'
                            WHEN 'Unpaid' THEN N'Chưa thanh toán'
                            ELSE ew.Status
                        END AS [Trạng thái],
                        CONVERT(VARCHAR(10), ew.RecordedDate, 103) AS [Ngày ghi chỉ số]
                    FROM dbo.ElectricityWater ew
                    WHERE ew.RoomID = @RoomID";

                if (cboFilterYear.SelectedIndex > 0 && int.TryParse(cboFilterYear.SelectedItem?.ToString(), out int selectedYear))
                {
                    sql += " AND ew.Year = " + selectedYear;
                }

                sql += " ORDER BY ew.Year DESC, ew.Month DESC";

                var dt = DatabaseHelper.ExecuteQuery(sql, new[] { new SqlParameter("@RoomID", _currentRoomId) });
                dgvBills.DataSource = dt;

                if (dgvBills.Columns.Contains("LogID"))
                    dgvBills.Columns["LogID"].Visible = false;

                // Format số tiền
                string[] currencyCols = { "Tiền điện (đ)", "Tiền nước (đ)", "Tổng cộng (đ)" };
                foreach (var col in currencyCols)
                {
                    if (dgvBills.Columns.Contains(col))
                    {
                        dgvBills.Columns[col].DefaultCellStyle.Format = "N0";
                        dgvBills.Columns[col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }

                dgvBills.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboFilterYear_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadBills();
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadStudentRoom();
            LoadBills();
        }
    }
}
