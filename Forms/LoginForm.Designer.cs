namespace QuanLyKtx.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkShowPassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblHeaderSubtitle = new Label();
            lblHeaderTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            chkShowPassword = new CheckBox();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(15, 23, 42);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(526, 120);
            pnlHeader.TabIndex = 0;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.Dock = DockStyle.Bottom;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(203, 213, 225);
            lblHeaderSubtitle.Location = new Point(0, 69);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(526, 51);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Cổng thông tin Quản lý Ký túc xá & Sinh viên";
            lblHeaderSubtitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.Dock = DockStyle.Top;
            lblHeaderTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(0, 0);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(526, 69);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "🏫  ĐĂNG NHẬP HỆ THỐNG";
            lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(51, 65, 85);
            lblUsername.Location = new Point(57, 155);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(130, 21);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10.5F);
            txtUsername.Location = new Point(57, 183);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Nhập tài khoản (vd: admin, sv001)";
            txtUsername.Size = new Size(411, 31);
            txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(51, 65, 85);
            lblPassword.Location = new Point(57, 235);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(86, 21);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10.5F);
            txtPassword.Location = new Point(57, 263);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Nhập mật khẩu";
            txtPassword.Size = new Size(411, 31);
            txtPassword.TabIndex = 4;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(37, 99, 235);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 58, 138);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(57, 375);
            btnLogin.Margin = new Padding(3, 4, 3, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(200, 48);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "🔐  ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(241, 245, 249);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 1;
            btnExit.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(226, 232, 240);
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(203, 213, 225);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            btnExit.ForeColor = Color.FromArgb(51, 65, 85);
            btnExit.Location = new Point(268, 375);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(200, 48);
            btnExit.TabIndex = 7;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 9F);
            chkShowPassword.ForeColor = Color.FromArgb(71, 85, 105);
            chkShowPassword.Location = new Point(57, 315);
            chkShowPassword.Margin = new Padding(3, 4, 3, 4);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(148, 24);
            chkShowPassword.TabIndex = 5;
            chkShowPassword.Text = "Hiển thị mật khẩu";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(526, 475);
            Controls.Add(chkShowPassword);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập - Hệ Thống Quản Lý Ký Túc Xá";
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
