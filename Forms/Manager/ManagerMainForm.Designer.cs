namespace QuanLyKtx.Forms.Manager
{
    partial class ManagerMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnBuildings;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Button btnAssignments;
        private System.Windows.Forms.Button btnContracts;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnElecWater;
        private System.Windows.Forms.Button btnViolations;
        private System.Windows.Forms.Button btnRequests;
        private System.Windows.Forms.Button btnStatistics;
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
            btnStatistics = new System.Windows.Forms.Button();
            btnRequests = new System.Windows.Forms.Button();
            btnViolations = new System.Windows.Forms.Button();
            btnElecWater = new System.Windows.Forms.Button();
            btnPayments = new System.Windows.Forms.Button();
            btnContracts = new System.Windows.Forms.Button();
            btnAssignments = new System.Windows.Forms.Button();
            btnRooms = new System.Windows.Forms.Button();
            btnBuildings = new System.Windows.Forms.Button();
            btnStudents = new System.Windows.Forms.Button();
            btnDashboard = new System.Windows.Forms.Button();
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
            pnlSidebar.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnStatistics);
            pnlSidebar.Controls.Add(btnRequests);
            pnlSidebar.Controls.Add(btnViolations);
            pnlSidebar.Controls.Add(btnElecWater);
            pnlSidebar.Controls.Add(btnPayments);
            pnlSidebar.Controls.Add(btnContracts);
            pnlSidebar.Controls.Add(btnAssignments);
            pnlSidebar.Controls.Add(btnRooms);
            pnlSidebar.Controls.Add(btnBuildings);
            pnlSidebar.Controls.Add(btnStudents);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            pnlSidebar.Location = new System.Drawing.Point(0, 60);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new System.Drawing.Size(230, 690);
            pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLogout.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnLogout.ForeColor = System.Drawing.Color.White;
            btnLogout.Location = new System.Drawing.Point(0, 640);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new System.Drawing.Size(230, 50);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "ĐĂNG XUẤT";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnStatistics
            // 
            btnStatistics.Cursor = System.Windows.Forms.Cursors.Hand;
            btnStatistics.Dock = System.Windows.Forms.DockStyle.Top;
            btnStatistics.FlatAppearance.BorderSize = 0;
            btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnStatistics.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnStatistics.ForeColor = System.Drawing.Color.WhiteSmoke;
            btnStatistics.Location = new System.Drawing.Point(0, 480);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnStatistics.Size = new System.Drawing.Size(230, 48);
            btnStatistics.TabIndex = 10;
            btnStatistics.Text = "Báo cáo thống kê";
            btnStatistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnStatistics.UseVisualStyleBackColor = true;
            btnStatistics.Click += btnStatistics_Click;
            // 
            // btnRequests
            // 
            btnRequests.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRequests.Dock = System.Windows.Forms.DockStyle.Top;
            btnRequests.FlatAppearance.BorderSize = 0;
            btnRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRequests.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRequests.ForeColor = System.Drawing.Color.WhiteSmoke;
            btnRequests.Location = new System.Drawing.Point(0, 432);
            btnRequests.Name = "btnRequests";
            btnRequests.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnRequests.Size = new System.Drawing.Size(230, 48);
            btnRequests.TabIndex = 9;
            btnRequests.Text = "Xử lý yêu cầu";
            btnRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnRequests.UseVisualStyleBackColor = true;
            btnRequests.Click += btnRequests_Click;
            // 
            // btnViolations
            // 
            btnViolations.Cursor = System.Windows.Forms.Cursors.Hand;
            btnViolations.Dock = System.Windows.Forms.DockStyle.Top;
            btnViolations.FlatAppearance.BorderSize = 0;
            btnViolations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnViolations.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnViolations.ForeColor = System.Drawing.Color.WhiteSmoke;
            btnViolations.Location = new System.Drawing.Point(0, 384);
            btnViolations.Name = "btnViolations";
            btnViolations.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnViolations.Size = new System.Drawing.Size(230, 48);
            btnViolations.TabIndex = 8;
            btnViolations.Text = "Kỷ luật & Vi phạm";
            btnViolations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnViolations.UseVisualStyleBackColor = true;
            btnViolations.Click += btnViolations_Click;
            // 
            // btnElecWater
            // 
            btnElecWater.Cursor = System.Windows.Forms.Cursors.Hand;
            btnElecWater.Dock = System.Windows.Forms.DockStyle.Top;
            btnElecWater.FlatAppearance.BorderSize = 0;
            btnElecWater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnElecWater.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnElecWater.ForeColor = System.Drawing.Color.WhiteSmoke;
            btnElecWater.Location = new System.Drawing.Point(0, 336);
            btnElecWater.Name = "btnElecWater";
            btnElecWater.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnElecWater.Size = new System.Drawing.Size(230, 48);
            btnElecWater.TabIndex = 7;
            btnElecWater.Text = "Chỉ số điện nước";
            btnElecWater.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnElecWater.UseVisualStyleBackColor = true;
            btnElecWater.Click += btnElecWater_Click;
            // 
            // btnPayments
            // 
            btnPayments.Cursor = System.Windows.Forms.Cursors.Hand;
            btnPayments.Dock = System.Windows.Forms.DockStyle.Top;
            btnPayments.FlatAppearance.BorderSize = 0;
            btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnPayments.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnPayments.ForeColor = System.Drawing.Color.WhiteSmoke;
            btnPayments.Location = new System.Drawing.Point(0, 288);
            btnPayments.Name = "btnPayments";
            btnPayments.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnPayments.Size = new System.Drawing.Size(230, 48);
            btnPayments.TabIndex = 6;
            btnPayments.Text = "Quản lý thanh toán";
            btnPayments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnPayments.UseVisualStyleBackColor = true;
            btnPayments.Click += btnPayments_Click;
            // 
            // btnContracts
            // 
            btnContracts.Cursor = System.Windows.Forms.Cursors.Hand;
            btnContracts.Dock = System.Windows.Forms.DockStyle.Top;
            btnContracts.FlatAppearance.BorderSize = 0;
            btnContracts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnContracts.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnContracts.ForeColor = System.Drawing.Color.WhiteSmoke;
            btnContracts.Location = new System.Drawing.Point(0, 240);
            btnContracts.Name = "btnContracts";
            btnContracts.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnContracts.Size = new System.Drawing.Size(230, 48);
            btnContracts.TabIndex = 5;
            btnContracts.Text = "Quản lý hợp đồng";
            btnContracts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnContracts.UseVisualStyleBackColor = true;
            btnContracts.Click += btnContracts_Click;
            // 
            // btnAssignments
            // 
            btnAssignments.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAssignments.Dock = System.Windows.Forms.DockStyle.Top;
            btnAssignments.FlatAppearance.BorderSize = 0;
            btnAssignments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAssignments.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnAssignments.ForeColor = System.Drawing.Color.WhiteSmoke;
            btnAssignments.Location = new System.Drawing.Point(0, 192);
            btnAssignments.Name = "btnAssignments";
            btnAssignments.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnAssignments.Size = new System.Drawing.Size(230, 48);
            btnAssignments.TabIndex = 4;
            btnAssignments.Text = "Phân & Chuyển phòng";
            btnAssignments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAssignments.UseVisualStyleBackColor = true;
            btnAssignments.Click += btnAssignments_Click;
            // 
            // btnRooms
            // 
            btnRooms.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRooms.Dock = System.Windows.Forms.DockStyle.Top;
            btnRooms.FlatAppearance.BorderSize = 0;
            btnRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRooms.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRooms.ForeColor = System.Drawing.Color.WhiteSmoke;
            btnRooms.Location = new System.Drawing.Point(0, 144);
            btnRooms.Name = "btnRooms";
            btnRooms.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnRooms.Size = new System.Drawing.Size(230, 48);
            btnRooms.TabIndex = 3;
            btnRooms.Text = "Quản lý phòng";
            btnRooms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnRooms.UseVisualStyleBackColor = true;
            btnRooms.Click += btnRooms_Click;
            // 
            // btnBuildings
            // 
            btnBuildings.Cursor = System.Windows.Forms.Cursors.Hand;
            btnBuildings.Dock = System.Windows.Forms.DockStyle.Top;
            btnBuildings.FlatAppearance.BorderSize = 0;
            btnBuildings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBuildings.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnBuildings.ForeColor = System.Drawing.Color.WhiteSmoke;
            btnBuildings.Location = new System.Drawing.Point(0, 96);
            btnBuildings.Name = "btnBuildings";
            btnBuildings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnBuildings.Size = new System.Drawing.Size(230, 48);
            btnBuildings.TabIndex = 2;
            btnBuildings.Text = "Quản lý khu nhà";
            btnBuildings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnBuildings.UseVisualStyleBackColor = true;
            btnBuildings.Click += btnBuildings_Click;
            // 
            // btnStudents
            // 
            btnStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            btnStudents.Dock = System.Windows.Forms.DockStyle.Top;
            btnStudents.FlatAppearance.BorderSize = 0;
            btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnStudents.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnStudents.ForeColor = System.Drawing.Color.WhiteSmoke;
            btnStudents.Location = new System.Drawing.Point(0, 48);
            btnStudents.Name = "btnStudents";
            btnStudents.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnStudents.Size = new System.Drawing.Size(230, 48);
            btnStudents.TabIndex = 1;
            btnStudents.Text = "Quản lý sinh viên";
            btnStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnStudents.UseVisualStyleBackColor = true;
            btnStudents.Click += btnStudents_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnDashboard.ForeColor = System.Drawing.Color.White;
            btnDashboard.Location = new System.Drawing.Point(0, 0);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnDashboard.Size = new System.Drawing.Size(230, 48);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "Bảng điều khiển";
            btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(24, 119, 242);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblAppTitle);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1240, 60);
            pnlHeader.TabIndex = 1;
            // 
            // lblWelcome
            // 
            lblWelcome.Dock = System.Windows.Forms.DockStyle.Right;
            lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblWelcome.ForeColor = System.Drawing.Color.White;
            lblWelcome.Location = new System.Drawing.Point(740, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            lblWelcome.Size = new System.Drawing.Size(500, 60);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Xin chào: Quản Trị Viên";
            lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAppTitle
            // 
            lblAppTitle.Dock = System.Windows.Forms.DockStyle.Left;
            lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblAppTitle.ForeColor = System.Drawing.Color.White;
            lblAppTitle.Location = new System.Drawing.Point(0, 0);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            lblAppTitle.Size = new System.Drawing.Size(480, 60);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "HỆ THỐNG QUẢN LÝ KÝ TÚC XÁ";
            lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlContent
            // 
            pnlContent.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlContent.Location = new System.Drawing.Point(230, 60);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new System.Drawing.Size(1010, 690);
            pnlContent.TabIndex = 2;
            // 
            // ManagerMainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1240, 750);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlHeader);
            MinimumSize = new System.Drawing.Size(1050, 680);
            Name = "ManagerMainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản Trị Viên - Hệ Thống Quản Lý Ký Túc Xá";
            FormClosing += ManagerMainForm_FormClosing;
            Load += ManagerMainForm_Load;
            pnlSidebar.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
