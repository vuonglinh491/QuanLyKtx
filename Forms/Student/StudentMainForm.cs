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

            var pnlHero = new Panel
            {
                Location = new Point(30, 20),
                Size = new Size(740, 95),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            var heroBar = new Panel
            {
                Size = new Size(740, 4),
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
                Size = new Size(700, 36)
            };
            pnlHero.Controls.Add(lblDesc);

            pnlContent.Controls.Add(pnlHero);

            // Các nút truy cập nhanh
            CreateShortcutCard("🏠  Phòng của tôi", "Tra cứu phòng đang ở & bạn cùng phòng", 30, 135, btnMyRoom_Click);
            CreateShortcutCard("📄  Hợp đồng KTX", "Xem thời hạn hợp đồng và tiền phòng", 280, 135, btnMyContract_Click);
            CreateShortcutCard("⚡  Điện nước phòng", "Xem chỉ số và tiền điện nước tháng này", 530, 135, btnMyElecWater_Click);
            CreateShortcutCard("💳  Hóa đơn & Nộp phí", "Xem các khoản phí cần đóng và thanh toán QR", 30, 270, btnMyPayments_Click);
            CreateShortcutCard("📩  Gửi yêu cầu KTX", "Đăng ký, chuyển phòng hoặc báo trả phòng", 280, 270, btnMyRequests_Click);
            CreateShortcutCard("👤  Hồ sơ cá nhân", "Cập nhật số điện thoại, email, địa chỉ liên hệ", 530, 270, btnProfile_Click);
        }

        private void CreateShortcutCard(string title, string desc, int x, int y, EventHandler onClick)
        {
            var pnl = new Panel
            {
                Size = new Size(230, 118),
                Location = new Point(x, y),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            var topStripe = new Panel
            {
                Size = new Size(230, 3),
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
                Size = new Size(202, 42),
                Cursor = Cursors.Hand
            };

            var lblAction = new Label
            {
                Text = "Khám phá →",
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(37, 99, 235),
                Location = new Point(14, 88),
                AutoSize = true,
                Cursor = Cursors.Hand
            };

            pnl.Controls.Add(lblT);
            pnl.Controls.Add(lblD);
            pnl.Controls.Add(lblAction);

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

            pnlContent.Controls.Add(pnl);
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
