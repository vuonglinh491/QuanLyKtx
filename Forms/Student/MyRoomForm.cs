using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using QuanLyKtx.Data;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Student
{
    public partial class MyRoomForm : Form
    {
        public MyRoomForm()
        {
            InitializeComponent();
        }

        private void MyRoomForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            LoadRoomData();
        }

        private void SetupDataGridViewStyle()
        {
            DataGridViewHelper.Configure(dgvRoommates);
            dgvRoommates.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvRoommates.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvRoommates.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvRoommates.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvRoommates.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvRoommates.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadRoomData()
        {
            if (!Session.StudentID.HasValue)
            {
                ShowNoRoom("Không xác định được sinh viên đăng nhập!");
                return;
            }

            try
            {
                // Lấy thông tin phòng đang Active
                string sqlRoom = @"
            SELECT 
                r.RoomID,
                b.BuildingName,
                r.RoomNumber,
                r.RoomType,
                r.Price AS BasePrice,
                r.Capacity,
                r.CurrentOccupancy,
                a.StartDate
            FROM RoomAssignments a
            JOIN Rooms r ON a.RoomID = r.RoomID
            JOIN Buildings b ON r.BuildingID = b.BuildingID
            WHERE a.StudentID = @StudentID AND a.Status = 'Active'";

                var dtRoom = DatabaseHelper.ExecuteQuery(sqlRoom, new[] { new SQLiteParameter("@StudentID", Session.StudentID.Value) });

                if (dtRoom.Rows.Count == 0)
                {
                    ShowNoRoom("Hiện tại bạn chưa được phân phòng hoặc chưa có hợp đồng lưu trú còn hiệu lực. Vui lòng vào mục 'Gửi yêu cầu' để đăng ký phòng!");
                    return;
                }

                var row = dtRoom.Rows[0];
                int roomId = Convert.ToInt32(row["RoomID"]);

                txtBuilding.Text = row["BuildingName"].ToString();
                txtRoomNumber.Text = row["RoomNumber"].ToString();
                txtRoomType.Text = row["RoomType"].ToString();

                decimal price = Convert.ToDecimal(row["BasePrice"]);
                txtPrice.Text = price.ToString("N0") + " VNĐ";

                int occ = Convert.ToInt32(row["CurrentOccupancy"]);
                int cap = Convert.ToInt32(row["Capacity"]);
                txtOccupancy.Text = $"{occ} / {cap} người";

                if (row["StartDate"] != DBNull.Value && DateTime.TryParse(row["StartDate"].ToString(), out var sDate))
                    txtStartDate.Text = sDate.ToString("dd/MM/yyyy");

                // Lấy danh sách bạn cùng phòng (Đã sửa s.Class -> s.ClassName)
                string sqlRoommates = @"
            SELECT 
                s.StudentCode AS [Mã SV],
                s.FullName AS [Họ và tên],
                s.ClassName AS [Lớp],
                s.Phone AS [SĐT],
                s.Email AS [Email],
                strftime('%d/%m/%Y', a.StartDate) AS [Ngày vào ở]
            FROM RoomAssignments a
            JOIN Students s ON a.StudentID = s.StudentID
            WHERE a.RoomID = @RoomID AND a.Status = 'Active'
            ORDER BY a.StartDate ASC";

                var dtRoommates = DatabaseHelper.ExecuteQuery(sqlRoommates, new[] { new SQLiteParameter("@RoomID", roomId) });
                dgvRoommates.DataSource = dtRoommates;
                dgvRoommates.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                lblNoRoom.Visible = false;
                grpRoomInfo.Visible = true;
                grpRoommates.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowNoRoom(string message)
        {
            lblNoRoom.Text = message;
            lblNoRoom.Visible = true;
            grpRoomInfo.Visible = false;
            grpRoommates.Visible = false;
        }
    }
}
