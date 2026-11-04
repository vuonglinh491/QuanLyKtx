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
            lblWelcome.Text = $"👤  {Session.FullName} ({Session.Username})  •  Quản trị viên";
            HighlightButton(btnDashboard);
            ShowDashboardView();
        }

        private void HighlightButton(Button btn)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(15, 23, 42);
                currentButton.ForeColor = Color.FromArgb(203, 213, 225);
                currentButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }
            currentButton = btn;
            currentButton.BackColor = Color.FromArgb(37, 99, 235);
            currentButton.ForeColor = Color.White;
            currentButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
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
            pnlContent.Padding = new Padding(24, 20, 24, 20);

            // 1. Panel tiêu đề trên cùng (Trực quan, tự động co giãn)
            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 44,
                BackColor = Color.Transparent
            };

            var lblTitle = new Label
            {
                Text = "BẢNG ĐIỀU KHIỂN QUẢN TRỊ KÝ TÚC XÁ",
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Dock = DockStyle.Left,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft
            };

            var btnRefresh = new Button
            {
                Size = new Size(165, 36),
                Dock = DockStyle.Right,
                Cursor = Cursors.Hand
            };
            UITheme.ApplySecondaryButton(btnRefresh, "🔄  Làm mới dữ liệu");
            btnRefresh.Click += (s, ev) => ShowDashboardView();

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(btnRefresh);

            // 2. Lấy dữ liệu thống kê từ SQLite
            int totalStudents = 0;
            int stayingStudents = 0;
            int totalRooms = 0;
            int availableRooms = 0;
            int pendingRequests = 0;
            int unpaidViolations = 0;

            try
            {
                var objStudents = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Students");
                if (objStudents != null) totalStudents = Convert.ToInt32(objStudents);

                var objStaying = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM RoomAssignments WHERE Status = 'Active'");
                if (objStaying != null) stayingStudents = Convert.ToInt32(objStaying);

                var objRooms = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Rooms");
                if (objRooms != null) totalRooms = Convert.ToInt32(objRooms);

                var objAvailable = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Rooms WHERE Status = 'Available'");
                if (objAvailable != null) availableRooms = Convert.ToInt32(objAvailable);

                var objRequests = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Requests WHERE Status = 'Pending'");
                if (objRequests != null) pendingRequests = Convert.ToInt32(objRequests);

                var objViolations = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Violations WHERE Status = 'Unpaid'");
                if (objViolations != null) unpaidViolations = Convert.ToInt32(objViolations);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu bảng điều khiển: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 3. TableLayoutPanel 4 Cards thống kê (Tự động kéo giãn 4 cột 25% đều nhau theo chiều rộng full màn hình)
            var tblCards = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 125,
                ColumnCount = 4,
                RowCount = 1,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
                Padding = new Padding(0, 10, 0, 10)
            };
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
            tblCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            var card1 = CreateStatCard("Tổng sinh viên", $"{totalStudents} SV", $"{stayingStudents} đang ở KTX", Color.FromArgb(37, 99, 235), "👥");
            var card2 = CreateStatCard("Tổng số phòng", $"{totalRooms} phòng", $"{availableRooms} phòng còn trống", Color.FromArgb(16, 185, 129), "🏢");
            var card3 = CreateStatCard("Yêu cầu chờ duyệt", $"{pendingRequests} đơn", "Cần quản lý xử lý", Color.FromArgb(239, 68, 68), "📩");
            var card4 = CreateStatCard("Vi phạm chưa nộp", $"{unpaidViolations} vụ", "Chờ xử lý kỷ luật", Color.FromArgb(245, 158, 11), "⚠️");

            card1.Margin = new Padding(0, 0, 8, 0);
            card2.Margin = new Padding(8, 0, 8, 0);
            card3.Margin = new Padding(8, 0, 8, 0);
            card4.Margin = new Padding(8, 0, 0, 0);

            tblCards.Controls.Add(card1, 0, 0);
            tblCards.Controls.Add(card2, 1, 0);
            tblCards.Controls.Add(card3, 2, 0);
            tblCards.Controls.Add(card4, 3, 0);

            // 4. TableLayoutPanel 2 Bảng dữ liệu (Tự động kéo giãn 50% mỗi cột và Fill toàn bộ chiều cao còn lại)
            var tblGrids = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
                Padding = new Padding(0, 8, 0, 0)
            };
            tblGrids.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tblGrids.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tblGrids.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

            // Bảng 1 Container
            var pnlLeftGrid = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 8, 0),
                BackColor = Color.Transparent
            };
            var lblStayingTitle = new Label
            {
                Text = "Danh sách sinh viên đang lưu trú:",
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Dock = DockStyle.Top,
                Height = 32,
                TextAlign = ContentAlignment.MiddleLeft
            };
            var dgvStaying = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            DataGridViewHelper.Configure(dgvStaying);
            pnlLeftGrid.Controls.Add(dgvStaying);
            pnlLeftGrid.Controls.Add(lblStayingTitle);

            // Bảng 2 Container
            var pnlRightGrid = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(8, 0, 0, 0),
                BackColor = Color.Transparent
            };
            var lblRequestsTitle = new Label
            {
                Text = "Yêu cầu của sinh viên gần nhất:",
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Dock = DockStyle.Top,
                Height = 32,
                TextAlign = ContentAlignment.MiddleLeft
            };
            var dgvRequests = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            DataGridViewHelper.Configure(dgvRequests);
            pnlRightGrid.Controls.Add(dgvRequests);
            pnlRightGrid.Controls.Add(lblRequestsTitle);

            tblGrids.Controls.Add(pnlLeftGrid, 0, 0);
            tblGrids.Controls.Add(pnlRightGrid, 1, 0);

            // Thêm các thành phần vào pnlContent theo đúng thứ tự Dock
            pnlContent.Controls.Add(tblGrids);
            pnlContent.Controls.Add(tblCards);
            pnlContent.Controls.Add(pnlTop);

            // Đảm bảo z-order để Dock hoạt động chính xác
            pnlTop.SendToBack();
            tblCards.SendToBack();
            tblGrids.BringToFront();

            // Nạp dữ liệu vào 2 bảng
            try
            {
                string sqlStaying = @"
                    SELECT 
                        s.StudentCode AS [Mã SV],
                        s.FullName AS [Họ và tên],
                        r.RoomNumber AS [Phòng],
                        b.BuildingName AS [Khu nhà],
                        strftime('%d/%m/%Y', a.StartDate) AS [Ngày vào ở]
                    FROM RoomAssignments a
                    JOIN Students s ON a.StudentID = s.StudentID
                    JOIN Rooms r ON a.RoomID = r.RoomID
                    JOIN Buildings b ON r.BuildingID = b.BuildingID
                    WHERE a.Status = 'Active'
                    ORDER BY a.StartDate DESC";

                dgvStaying.DataSource = DatabaseHelper.ExecuteQuery(sqlStaying);

                string sqlRequests = @"
                    SELECT 
                        s.StudentCode AS [Mã SV],
                        s.FullName AS [Họ tên],
                        CASE req.RequestType
                            WHEN 'RegisterRoom' THEN 'Đăng ký phòng'
                            WHEN 'ChangeRoom' THEN 'Chuyển phòng'
                            WHEN 'LeaveRoom' THEN 'Trả phòng'
                            ELSE req.RequestType
                        END AS [Loại yêu cầu],
                        strftime('%d/%m/%Y', req.CreatedAt) AS [Ngày gửi],
                        CASE req.Status
                            WHEN 'Pending' THEN 'Chờ duyệt'
                            WHEN 'Approved' THEN 'Đã duyệt'
                            WHEN 'Rejected' THEN 'Từ chối'
                            ELSE req.Status
                        END AS [Trạng thái]
                    FROM Requests req
                    JOIN Students s ON req.StudentID = s.StudentID
                    ORDER BY req.CreatedAt DESC";

                dgvRequests.DataSource = DatabaseHelper.ExecuteQuery(sqlRequests);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách: " + ex.Message);
            }

            // Tự động phân chia tỷ lệ cột khi DataBinding hoàn tất
            dgvStaying.DataBindingComplete += (sender, _) =>
            {
                if (dgvStaying.Columns.Count >= 5)
                {
                    dgvStaying.Columns[0].FillWeight = 80;   // Mã SV
                    dgvStaying.Columns[1].FillWeight = 160;  // Họ và tên
                    dgvStaying.Columns[2].FillWeight = 70;   // Phòng
                    dgvStaying.Columns[3].FillWeight = 90;   // Khu nhà
                    dgvStaying.Columns[4].FillWeight = 100;  // Ngày vào ở
                }
            };

            dgvRequests.DataBindingComplete += (sender, _) =>
            {
                if (dgvRequests.Columns.Count >= 5)
                {
                    dgvRequests.Columns[0].FillWeight = 80;   // Mã SV
                    dgvRequests.Columns[1].FillWeight = 140;  // Họ tên
                    dgvRequests.Columns[2].FillWeight = 130;  // Loại yêu cầu
                    dgvRequests.Columns[3].FillWeight = 90;   // Ngày gửi
                    dgvRequests.Columns[4].FillWeight = 100;  // Trạng thái
                }
            };
        }

        private static Panel CreateStatCard(string title, string mainVal, string subVal, Color accentColor, string icon)
        {
            var pnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var bar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 4,
                BackColor = accentColor
            };

            var lblIcon = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 20F),
                Size = new Size(50, 50),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblT = new Label
            {
                Text = title.ToUpper(),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(14, 14),
                AutoSize = true
            };

            var lblV = new Label
            {
                Text = mainVal,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(12, 36),
                AutoSize = true
            };

            var lblSub = new Label
            {
                Text = "• " + subVal,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                ForeColor = accentColor,
                Location = new Point(14, 76),
                AutoSize = true
            };

            pnl.Controls.Add(bar);
            pnl.Controls.Add(lblIcon);
            pnl.Controls.Add(lblT);
            pnl.Controls.Add(lblV);
            pnl.Controls.Add(lblSub);

            // Căn icon góc phải trên khi kích thước card thay đổi
            pnl.Resize += (s, e) =>
            {
                lblIcon.Location = new Point(pnl.Width - 58, 14);
            };

            return pnl;
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
