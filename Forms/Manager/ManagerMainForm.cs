using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyKtx.Data;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Manager
{
    public partial class ManagerMainForm : Form
    {
        private Form? activeForm = null;
        private Button? currentButton = null;

        public ManagerMainForm()
        {
            InitializeComponent();
        }

        private void ManagerMainForm_Load(object? sender, EventArgs e)
        {
            lblWelcome.Text = $"Xin chào: {Session.FullName} ({Session.Username})";
            HighlightButton(btnDashboard);
            ShowDashboardView();
        }

        private void HighlightButton(Button btn)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(30, 41, 59);
                currentButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            }
            currentButton = btn;
            currentButton.BackColor = Color.FromArgb(15, 23, 42);
            currentButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        }

        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void ShowDashboardView()
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
                activeForm = null;
            }

            pnlContent.Controls.Clear();

            // Tiêu đề Dashboard
            var lblTitle = new Label
            {
                Text = "BẢNG ĐIỀU KHIỂN QUẢN TRỊ KÝ TÚC XÁ",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(25, 20),
                AutoSize = true
            };
            pnlContent.Controls.Add(lblTitle);

            var btnRefresh = new Button
            {
                Text = "Làm mới dữ liệu",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(30, 41, 59),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 32),
                Location = new Point(830, 20),
                Cursor = Cursors.Hand
            };
            btnRefresh.Click += (s, ev) => ShowDashboardView();
            pnlContent.Controls.Add(btnRefresh);

            // Lấy dữ liệu thống kê từ SQL Server
            int totalStudents = 0;
            int stayingStudents = 0;
            int totalRooms = 0;
            int availableRooms = 0;
            int pendingRequests = 0;
            int unpaidViolations = 0;

            try
            {
                var objStudents = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM dbo.Students");
                if (objStudents != null) totalStudents = Convert.ToInt32(objStudents);

                var objStaying = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM dbo.RoomAssignments WHERE Status = 'Active'");
                if (objStaying != null) stayingStudents = Convert.ToInt32(objStaying);

                var objRooms = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM dbo.Rooms");
                if (objRooms != null) totalRooms = Convert.ToInt32(objRooms);

                var objAvailable = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM dbo.Rooms WHERE Status = 'Available'");
                if (objAvailable != null) availableRooms = Convert.ToInt32(objAvailable);

                var objRequests = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM dbo.Requests WHERE Status = 'Pending'");
                if (objRequests != null) pendingRequests = Convert.ToInt32(objRequests);

                var objViolations = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM dbo.Violations WHERE Status = 'Unpaid'");
                if (objViolations != null) unpaidViolations = Convert.ToInt32(objViolations);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu bảng điều khiển: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Hiển thị các Card thống kê nhanh
            CreateStatCard("Tổng sinh viên", $"{totalStudents} SV", $"{stayingStudents} đang ở KTX", Color.FromArgb(37, 99, 235), 25, 65);
            CreateStatCard("Tổng số phòng", $"{totalRooms} phòng", $"{availableRooms} phòng còn trống", Color.FromArgb(16, 185, 129), 270, 65);
            CreateStatCard("Yêu cầu chờ duyệt", $"{pendingRequests} đơn", "Cần quản lý xử lý", Color.FromArgb(239, 68, 68), 515, 65);
            CreateStatCard("Vi phạm chưa nộp", $"{unpaidViolations} vụ", "Chờ xử lý kỷ luật", Color.FromArgb(245, 158, 11), 760, 65);

            // Bảng 1: Sinh viên đang lưu trú gần đây
            var lblStayingTitle = new Label
            {
                Text = "Danh sách sinh viên đang lưu trú:",
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(25, 195),
                AutoSize = true
            };
            pnlContent.Controls.Add(lblStayingTitle);

            var dgvStaying = new DataGridView
            {
                Location = new Point(25, 230),
                Size = new Size(465, 420),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                RowHeadersVisible = false,
                ColumnHeadersHeight = 36,
                EnableHeadersVisualStyles = false,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular)
            };
            dgvStaying.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvStaying.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvStaying.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            ConfigureDashboardGrid(dgvStaying, new[] { 75, 145, 75, 115, 100 });

            // Bảng 2: Yêu cầu của sinh viên cần duyệt
            var lblRequestsTitle = new Label
            {
                Text = "Yêu cầu của sinh viên gần nhất:",
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(515, 195),
                AutoSize = true
            };
            pnlContent.Controls.Add(lblRequestsTitle);

            var dgvRequests = new DataGridView
            {
                Location = new Point(515, 230),
                Size = new Size(465, 420),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                RowHeadersVisible = false,
                ColumnHeadersHeight = 36,
                EnableHeadersVisualStyles = false,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular)
            };
            dgvRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            ConfigureDashboardGrid(dgvRequests, new[] { 75, 135, 115, 85, 100 });

            pnlContent.Controls.Add(dgvStaying);
            pnlContent.Controls.Add(dgvRequests);

            // Nạp dữ liệu vào 2 bảng
            try
            {
                string sqlStaying = @"
                    SELECT 
                        s.StudentCode AS [Mã SV],
                        s.FullName AS [Họ và tên],
                        r.RoomNumber AS [Phòng],
                        b.BuildingName AS [Khu nhà],
                        CONVERT(VARCHAR(10), a.StartDate, 103) AS [Ngày vào ở]
                    FROM dbo.RoomAssignments a
                    JOIN dbo.Students s ON a.StudentID = s.StudentID
                    JOIN dbo.Rooms r ON a.RoomID = r.RoomID
                    JOIN dbo.Buildings b ON r.BuildingID = b.BuildingID
                    WHERE a.Status = 'Active'
                    ORDER BY a.StartDate DESC";

                dgvStaying.DataSource = DatabaseHelper.ExecuteQuery(sqlStaying);

                string sqlRequests = @"
                    SELECT 
                        s.StudentCode AS [Mã SV],
                        s.FullName AS [Họ tên],
                        CASE req.RequestType
                            WHEN 'RegisterRoom' THEN N'Đăng ký phòng'
                            WHEN 'ChangeRoom' THEN N'Chuyển phòng'
                            WHEN 'LeaveRoom' THEN N'Trả phòng'
                            ELSE req.RequestType
                        END AS [Loại yêu cầu],
                        CONVERT(VARCHAR(10), req.CreatedAt, 103) AS [Ngày gửi],
                        CASE req.Status
                            WHEN 'Pending' THEN N'Chờ duyệt'
                            WHEN 'Approved' THEN N'Đã duyệt'
                            WHEN 'Rejected' THEN N'Từ chối'
                            ELSE req.Status
                        END AS [Trạng thái]
                    FROM dbo.Requests req
                    JOIN dbo.Students s ON req.StudentID = s.StudentID
                    ORDER BY req.CreatedAt DESC";

                dgvRequests.DataSource = DatabaseHelper.ExecuteQuery(sqlRequests);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách: " + ex.Message);
            }
        }

        private static void ConfigureDashboardGrid(DataGridView grid, int[] columnWidths)
        {
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            grid.AllowUserToResizeRows = false;

            grid.DataBindingComplete += (sender, _) =>
            {
                if (sender is not DataGridView boundGrid) return;

                for (int index = 0; index < boundGrid.Columns.Count && index < columnWidths.Length; index++)
                {
                    boundGrid.Columns[index].Width = columnWidths[index];
                }

                boundGrid.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            };

            grid.CellToolTipTextNeeded += (sender, eventArgs) =>
            {
                if (sender is DataGridView boundGrid && eventArgs.RowIndex >= 0 && eventArgs.ColumnIndex >= 0)
                {
                    eventArgs.ToolTipText = boundGrid.Rows[eventArgs.RowIndex].Cells[eventArgs.ColumnIndex].Value?.ToString();
                }
            };
        }

        private void CreateStatCard(string title, string mainVal, string subVal, Color accentColor, int x, int y)
        {
            var pnl = new Panel
            {
                Size = new Size(225, 110),
                Location = new Point(x, y),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var bar = new Panel
            {
                Size = new Size(225, 5),
                Dock = DockStyle.Top,
                BackColor = accentColor
            };

            var lblT = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(15, 14),
                AutoSize = true
            };

            var lblV = new Label
            {
                Text = mainVal,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(15, 40),
                AutoSize = true
            };

            var lblSub = new Label
            {
                Text = subVal,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Italic),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(15, 80),
                AutoSize = true
            };

            pnl.Controls.Add(bar);
            pnl.Controls.Add(lblT);
            pnl.Controls.Add(lblV);
            pnl.Controls.Add(lblSub);
            pnlContent.Controls.Add(pnl);
        }

        private void btnDashboard_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnDashboard);
            ShowDashboardView();
        }

        private void btnStudents_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnStudents);
            OpenChildForm(new StudentManagementForm());
        }

        private void btnBuildings_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnBuildings);
            OpenChildForm(new BuildingManagementForm());
        }

        private void btnRooms_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnRooms);
            OpenChildForm(new RoomManagementForm());
        }

        private void btnAssignments_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnAssignments);
            OpenChildForm(new RoomAssignmentForm());
        }

        private void btnContracts_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnContracts);
            OpenChildForm(new ContractManagementForm());
        }

        private void btnPayments_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnPayments);
            OpenChildForm(new PaymentManagementForm());
        }

        private void btnElecWater_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnElecWater);
            OpenChildForm(new ElectricityWaterForm());
        }

        private void btnViolations_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnViolations);
            OpenChildForm(new ViolationManagementForm());
        }

        private void btnRequests_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnRequests);
            OpenChildForm(new RequestManagementForm());
        }

        private void btnStatistics_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnStatistics);
            OpenChildForm(new StatisticsForm());
        }

        private void btnLogout_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Session.Clear();
                this.Hide();
                var login = new LoginForm();
                login.Show();
            }
        }

        private void ManagerMainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
