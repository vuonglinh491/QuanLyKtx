using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
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
            DataGridViewHelper.Configure(dgvBills);
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
                    SELECT r.RoomID, b.BuildingName || ' - Phòng ' || r.RoomNumber AS RoomTitle
                    FROM RoomAssignments a
                    JOIN Rooms r ON a.RoomID = r.RoomID
                    JOIN Buildings b ON r.BuildingID = b.BuildingID
                    WHERE a.StudentID = @StudentID AND a.Status = 'Active'";

                var dt = DatabaseHelper.ExecuteQuery(sql, new[] { new SQLiteParameter("@StudentID", Session.StudentID.Value) });
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
                ew.RecordID,
                ew.Month AS [Tháng],
                ew.Year AS [Năm],
                ew.OldElectricIndex AS [Số điện cũ],
                ew.NewElectricIndex AS [Số điện mới],
                (ew.NewElectricIndex - ew.OldElectricIndex) AS [Điện tiêu thụ (kWh)],
                ew.ElectricAmount AS [Tiền điện (đ)],
                ew.OldWaterIndex AS [Số nước cũ],
                ew.NewWaterIndex AS [Số nước mới],
                (ew.NewWaterIndex - ew.OldWaterIndex) AS [Nước tiêu thụ (m³)],
                ew.WaterAmount AS [Tiền nước (đ)],
                ew.TotalAmount AS [Tổng cộng (đ)]
            FROM ElectricityWater ew
            WHERE ew.RoomID = @RoomID";

                if (cboFilterYear.SelectedIndex > 0 && int.TryParse(cboFilterYear.SelectedItem?.ToString(), out int selectedYear))
                {
                    sql += " AND ew.Year = " + selectedYear;
                }

                sql += " ORDER BY ew.Year DESC, ew.Month DESC";

                var dt = DatabaseHelper.ExecuteQuery(sql, new[] { new SQLiteParameter("@RoomID", _currentRoomId) });
                dgvBills.DataSource = dt;

                if (dgvBills.Columns.Contains("RecordID"))
                    dgvBills.Columns["RecordID"].Visible = false;

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
