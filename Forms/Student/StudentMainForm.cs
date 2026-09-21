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
            lblWelcome.Text = $"Xin chào: {Session.FullName}";
            HighlightButton(btnHome);
            ShowHomeView();
        }

        private void HighlightButton(Button btn)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(15, 76, 129);
                currentButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }
            currentButton = btn;
            currentButton.BackColor = Color.FromArgb(10, 50, 90);
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

            var lblGreeting = new Label
            {
                Text = $"Chào mừng bạn, {Session.FullName}!",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 76, 129),
                Location = new Point(30, 25),
                AutoSize = true
            };
            pnlContent.Controls.Add(lblGreeting);

            var lblDesc = new Label
            {
                Text = "Chào mừng bạn đến với Cổng thông tin ký túc xá trực tuyến. Hãy chọn chức năng bên trái để tra cứu thông tin cá nhân, phòng ở, hợp đồng, chỉ số điện nước và gửi yêu cầu đến ban quản lý.",
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.FromArgb(70, 70, 70),
                Location = new Point(30, 65),
                Size = new Size(700, 50)
            };
            pnlContent.Controls.Add(lblDesc);

            // Các nút truy cập nhanh
            CreateShortcutCard("🏠 Phòng của tôi", "Tra cứu phòng đang ở & bạn cùng phòng", 30, 130, btnMyRoom_Click);
            CreateShortcutCard("📄 Hợp đồng KTX", "Xem thời hạn hợp đồng và tiền phòng", 270, 130, btnMyContract_Click);
            CreateShortcutCard("⚡ Điện nước", "Xem chỉ số và tiền điện nước tháng này", 510, 130, btnMyElecWater_Click);
            CreateShortcutCard("💳 Thanh toán", "Xem các khoản phí cần đóng và lịch sử", 30, 260, btnMyPayments_Click);
            CreateShortcutCard("📩 Gửi yêu cầu", "Đăng ký, chuyển phòng hoặc báo trả phòng", 270, 260, btnMyRequests_Click);
            CreateShortcutCard("👤 Hồ sơ cá nhân", "Cập nhật số điện thoại, email, địa chỉ", 510, 260, btnProfile_Click);
        }

        private void CreateShortcutCard(string title, string desc, int x, int y, EventHandler onClick)
        {
            var pnl = new Panel
            {
                Size = new Size(220, 110),
                Location = new Point(x, y),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };

            var lblT = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 76, 129),
                Location = new Point(15, 15),
                AutoSize = true
            };

            var lblD = new Label
            {
                Text = desc,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.Gray,
                Location = new Point(15, 45),
                Size = new Size(190, 50)
            };

            pnl.Controls.Add(lblT);
            pnl.Controls.Add(lblD);

            pnl.Click += onClick;
            lblT.Click += onClick;
            lblD.Click += onClick;

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
