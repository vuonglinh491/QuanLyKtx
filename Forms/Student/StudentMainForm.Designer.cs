namespace QuanLyKtx.Forms.Student
{
    partial class StudentMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnMyRoom;
        private System.Windows.Forms.Button btnMyContract;
        private System.Windows.Forms.Button btnMyPayments;
        private System.Windows.Forms.Button btnMyElecWater;
        private System.Windows.Forms.Button btnMyRequests;
        private System.Windows.Forms.Button btnLogout;

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
            pnlSidebar = new System.Windows.Forms.Panel();
            btnLogout = new System.Windows.Forms.Button();
            btnMyRequests = new System.Windows.Forms.Button();
            btnMyElecWater = new System.Windows.Forms.Button();
            btnMyPayments = new System.Windows.Forms.Button();
            btnMyContract = new System.Windows.Forms.Button();
            btnMyRoom = new System.Windows.Forms.Button();
            btnProfile = new System.Windows.Forms.Button();
            btnHome = new System.Windows.Forms.Button();
            pnlHeader = new System.Windows.Forms.Panel();
            lblWelcome = new System.Windows.Forms.Label();
            lblAppTitle = new System.Windows.Forms.Label();
            pnlContent = new System.Windows.Forms.Panel();
            pnlSidebar.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = System.Drawing.Color.FromArgb(15, 76, 129);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnMyRequests);
            pnlSidebar.Controls.Add(btnMyElecWater);
            pnlSidebar.Controls.Add(btnMyPayments);
            pnlSidebar.Controls.Add(btnMyContract);
            pnlSidebar.Controls.Add(btnMyRoom);
            pnlSidebar.Controls.Add(btnProfile);
            pnlSidebar.Controls.Add(btnHome);
            pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            pnlSidebar.Location = new System.Drawing.Point(0, 60);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new System.Drawing.Size(220, 640);
            pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnLogout.ForeColor = System.Drawing.Color.White;
            btnLogout.Location = new System.Drawing.Point(0, 592);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new System.Drawing.Size(220, 48);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "🚪 Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnMyRequests
            // 
            btnMyRequests.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMyRequests.Dock = System.Windows.Forms.DockStyle.Top;
            btnMyRequests.FlatAppearance.BorderSize = 0;
            btnMyRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMyRequests.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnMyRequests.ForeColor = System.Drawing.Color.White;
            btnMyRequests.Location = new System.Drawing.Point(0, 288);
            btnMyRequests.Name = "btnMyRequests";
            btnMyRequests.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btnMyRequests.Size = new System.Drawing.Size(220, 48);
            btnMyRequests.TabIndex = 6;
            btnMyRequests.Text = "📩 Gửi yêu cầu";
            btnMyRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnMyRequests.UseVisualStyleBackColor = true;
            btnMyRequests.Click += btnMyRequests_Click;
            // 
            // btnMyElecWater
            // 
            btnMyElecWater.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMyElecWater.Dock = System.Windows.Forms.DockStyle.Top;
            btnMyElecWater.FlatAppearance.BorderSize = 0;
            btnMyElecWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMyElecWater.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnMyElecWater.ForeColor = System.Drawing.Color.White;
            btnMyElecWater.Location = new System.Drawing.Point(0, 240);
            btnMyElecWater.Name = "btnMyElecWater";
            btnMyElecWater.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btnMyElecWater.Size = new System.Drawing.Size(220, 48);
            btnMyElecWater.TabIndex = 5;
            btnMyElecWater.Text = "⚡ Điện nước phòng";
            btnMyElecWater.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnMyElecWater.UseVisualStyleBackColor = true;
            btnMyElecWater.Click += btnMyElecWater_Click;
            // 
            // btnMyPayments
            // 
            btnMyPayments.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMyPayments.Dock = System.Windows.Forms.DockStyle.Top;
            btnMyPayments.FlatAppearance.BorderSize = 0;
            btnMyPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMyPayments.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnMyPayments.ForeColor = System.Drawing.Color.White;
            btnMyPayments.Location = new System.Drawing.Point(0, 192);
            btnMyPayments.Name = "btnMyPayments";
            btnMyPayments.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btnMyPayments.Size = new System.Drawing.Size(220, 48);
            btnMyPayments.TabIndex = 4;
            btnMyPayments.Text = "💳 Lịch sử thanh toán";
            btnMyPayments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnMyPayments.UseVisualStyleBackColor = true;
            btnMyPayments.Click += btnMyPayments_Click;
            // 
            // btnMyContract
            // 
            btnMyContract.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMyContract.Dock = System.Windows.Forms.DockStyle.Top;
            btnMyContract.FlatAppearance.BorderSize = 0;
            btnMyContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMyContract.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnMyContract.ForeColor = System.Drawing.Color.White;
            btnMyContract.Location = new System.Drawing.Point(0, 144);
            btnMyContract.Name = "btnMyContract";
            btnMyContract.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btnMyContract.Size = new System.Drawing.Size(220, 48);
            btnMyContract.TabIndex = 3;
            btnMyContract.Text = "📄 Hợp đồng của tôi";
            btnMyContract.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnMyContract.UseVisualStyleBackColor = true;
            btnMyContract.Click += btnMyContract_Click;
            // 
            // btnMyRoom
            // 
            btnMyRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            btnMyRoom.Dock = System.Windows.Forms.DockStyle.Top;
            btnMyRoom.FlatAppearance.BorderSize = 0;
            btnMyRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMyRoom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnMyRoom.ForeColor = System.Drawing.Color.White;
            btnMyRoom.Location = new System.Drawing.Point(0, 96);
            btnMyRoom.Name = "btnMyRoom";
            btnMyRoom.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btnMyRoom.Size = new System.Drawing.Size(220, 48);
            btnMyRoom.TabIndex = 2;
            btnMyRoom.Text = "🏠 Phòng đang ở";
            btnMyRoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnMyRoom.UseVisualStyleBackColor = true;
            btnMyRoom.Click += btnMyRoom_Click;
            // 
            // btnProfile
            // 
            btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnProfile.ForeColor = System.Drawing.Color.White;
            btnProfile.Location = new System.Drawing.Point(0, 48);
            btnProfile.Name = "btnProfile";
            btnProfile.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btnProfile.Size = new System.Drawing.Size(220, 48);
            btnProfile.TabIndex = 1;
            btnProfile.Text = "👤 Thông tin cá nhân";
            btnProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = System.Drawing.Color.FromArgb(10, 50, 90);
            btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnHome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnHome.ForeColor = System.Drawing.Color.White;
            btnHome.Location = new System.Drawing.Point(0, 0);
            btnHome.Name = "btnHome";
            btnHome.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btnHome.Size = new System.Drawing.Size(220, 48);
            btnHome.TabIndex = 0;
            btnHome.Text = "🏠 Trang chủ";
            btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 76, 129);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblAppTitle);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1000, 60);
            pnlHeader.TabIndex = 1;
            // 
            // lblWelcome
            // 
            lblWelcome.Dock = System.Windows.Forms.DockStyle.Right;
            lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblWelcome.ForeColor = System.Drawing.Color.White;
            lblWelcome.Location = new System.Drawing.Point(600, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            lblWelcome.Size = new System.Drawing.Size(400, 60);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Xin chào Sinh viên";
            lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAppTitle
            // 
            lblAppTitle.Dock = System.Windows.Forms.DockStyle.Left;
            lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblAppTitle.ForeColor = System.Drawing.Color.White;
            lblAppTitle.Location = new System.Drawing.Point(0, 0);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            lblAppTitle.Size = new System.Drawing.Size(450, 60);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "CỔNG THÔNG TIN SINH VIÊN KTX";
            lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlContent.Location = new System.Drawing.Point(220, 60);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new System.Drawing.Size(780, 640);
            pnlContent.TabIndex = 2;
            // 
            // StudentMainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1000, 700);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlHeader);
            MinimumSize = new System.Drawing.Size(900, 600);
            Name = "StudentMainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cổng Sinh Viên - Quản Lý Ký Túc Xá";
            FormClosing += StudentMainForm_FormClosing;
            Load += StudentMainForm_Load;
            pnlSidebar.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
