using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Student
{
    public partial class StudentMainForm : Form
    {
        private Form? activeForm = null;
        private Button? currentButton = null;

        public StudentMainForm()
        {
            InitializeComponent();
        }

        private void StudentMainForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"👤  {Session.FullName}  •  Sinh viên";
            HighlightButton(btnHome);
            ShowHomeView();
        }

        private void HighlightButton(Button btn)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(15, 76, 129);
                currentButton.ForeColor = Color.FromArgb(226, 232, 240);
                currentButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }
            currentButton = btn;
            currentButton.BackColor = Color.FromArgb(10, 50, 90);
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

        private void ShowHomeView()
        {
            pnlContent.Controls.Clear();
            pnlContent.Padding = new Padding(24, 20, 24, 20);

            // Container Panel cuộn hoặc kéo giãn
            var pnlHero = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 15)
            };

            var heroBar = new Panel
            {
                Height = 4,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(15, 76, 129)
            };
            pnlHero.Controls.Add(heroBar);

            var lblGreeting = new Label
            {
                Text = $"👋 Xin chào, {Session.FullName}!",
                Font = new Font("Segoe UI", 14.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 76, 129),
                Location = new Point(20, 15),
                AutoSize = true
            };
            pnlHero.Controls.Add(lblGreeting);

            var lblDesc = new Label
            {
                Text = "Cổng thông tin sinh viên nội trú ký túc xá. Tra cứu phòng ở, hợp đồng, hóa đơn điện nước và gửi yêu cầu trực tuyến tới ban quản lý.",
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(71, 85, 105),
                Location = new Point(20, 48),
                AutoSize = true
            };
            pnlHero.Controls.Add(lblDesc);

            // TableLayoutPanel cho 6 Shortcut Cards (2 dòng x 3 cột, tự động co giãn full màn hình)
            var tblShortcuts = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 270,
                ColumnCount = 3,
                RowCount = 2,
                BackColor = Color.Transparent,
                Margin = new Padding(0),
                Padding = new Padding(0, 15, 0, 0)
            };
            tblShortcuts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.333f));
            tblShortcuts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.333f));
            tblShortcuts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.333f));
            tblShortcuts.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            tblShortcuts.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

            var c1 = CreateShortcutCard("🏠  Phòng của tôi", "Tra cứu phòng đang ở & bạn cùng phòng", btnMyRoom_Click);
            var c2 = CreateShortcutCard("📄  Hợp đồng KTX", "Xem thời hạn hợp đồng và tiền phòng", btnMyContract_Click);
            var c3 = CreateShortcutCard("⚡  Điện nước phòng", "Xem chỉ số và tiền điện nước tháng này", btnMyElecWater_Click);
            var c4 = CreateShortcutCard("💳  Hóa đơn & Nộp phí", "Xem các khoản phí cần đóng và thanh toán QR", btnMyPayments_Click);
            var c5 = CreateShortcutCard("📩  Gửi yêu cầu KTX", "Đăng ký, chuyển phòng hoặc báo trả phòng", btnMyRequests_Click);
            var c6 = CreateShortcutCard("👤  Hồ sơ cá nhân", "Cập nhật số điện thoại, email, địa chỉ liên hệ", btnProfile_Click);

            c1.Margin = new Padding(0, 0, 8, 8);
            c2.Margin = new Padding(8, 0, 8, 8);
            c3.Margin = new Padding(8, 0, 0, 8);
            c4.Margin = new Padding(0, 8, 8, 0);
            c5.Margin = new Padding(8, 8, 8, 0);
            c6.Margin = new Padding(8, 8, 0, 0);

            tblShortcuts.Controls.Add(c1, 0, 0);
            tblShortcuts.Controls.Add(c2, 1, 0);
            tblShortcuts.Controls.Add(c3, 2, 0);
            tblShortcuts.Controls.Add(c4, 0, 1);
            tblShortcuts.Controls.Add(c5, 1, 1);
            tblShortcuts.Controls.Add(c6, 2, 1);

            pnlContent.Controls.Add(tblShortcuts);
            pnlContent.Controls.Add(pnlHero);

            pnlHero.SendToBack();
            tblShortcuts.BringToFront();
        }

        private Panel CreateShortcutCard(string title, string desc, EventHandler onClick)
        {
            var pnl = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            var topStripe = new Panel
            {
                Height = 3,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(37, 99, 235)
            };
            pnl.Controls.Add(topStripe);

            var lblT = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 76, 129),
                Location = new Point(14, 15),
                AutoSize = true,
                Cursor = Cursors.Hand
            };

            var lblD = new Label
            {
                Text = desc,
                Font = new Font("Segoe UI", 8.75F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(14, 42),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Size = new Size(pnl.Width - 28, 42),
                Cursor = Cursors.Hand
            };

            var lblAction = new Label
            {
                Text = "Khám phá →",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(37, 99, 235),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Location = new Point(14, 88),
                AutoSize = true,
                Cursor = Cursors.Hand
            };

            pnl.Controls.Add(lblT);
            pnl.Controls.Add(lblD);
            pnl.Controls.Add(lblAction);

            // Tự cập nhật chiều rộng nhãn mô tả khi card co giãn
            pnl.Resize += (s, e) =>
            {
                lblD.Width = Math.Max(50, pnl.Width - 28);
                lblAction.Location = new Point(14, pnl.Height - 26);
            };

            // Hiệu ứng hover tương tác
            void OnEnter(object? s, EventArgs e)
            {
                pnl.BackColor = Color.FromArgb(240, 249, 255);
            }
            void OnLeave(object? s, EventArgs e)
            {
                pnl.BackColor = Color.White;
            }

            pnl.MouseEnter += OnEnter;
            lblT.MouseEnter += OnEnter;
            lblD.MouseEnter += OnEnter;
            lblAction.MouseEnter += OnEnter;

            pnl.MouseLeave += OnLeave;
            lblT.MouseLeave += OnLeave;
            lblD.MouseLeave += OnLeave;
            lblAction.MouseLeave += OnLeave;

            pnl.Click += onClick;
            lblT.Click += onClick;
            lblD.Click += onClick;
            lblAction.Click += onClick;

            return pnl;
        }

        private void btnHome_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnHome);
            ShowHomeView();
        }

        private void btnProfile_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnProfile);
            OpenChildForm(new StudentProfileForm());
        }

        private void btnMyRoom_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnMyRoom);
            OpenChildForm(new MyRoomForm());
        }

        private void btnMyContract_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnMyContract);
            OpenChildForm(new MyContractForm());
        }

        private void btnMyPayments_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnMyPayments);
            OpenChildForm(new MyPaymentForm());
        }

        private void btnMyElecWater_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnMyElecWater);
            OpenChildForm(new ElectricityWaterViewForm());
        }

        private void btnMyRequests_Click(object? sender, EventArgs e)
        {
            HighlightButton(btnMyRequests);
            OpenChildForm(new RequestForm());
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

        private void StudentMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
