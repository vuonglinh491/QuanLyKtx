namespace QuanLyKtx.Forms.Manager
{
    partial class RoomAssignmentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.TabControl tabControlAssignment;
        private System.Windows.Forms.TabPage tabAssign;
        private System.Windows.Forms.TabPage tabChange;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cboStudent;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cboRoom;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Label lblSelectedInfo;
        private System.Windows.Forms.Label lblNewRoom;
        private System.Windows.Forms.ComboBox cboNewRoom;
        private System.Windows.Forms.Label lblActionDate;
        private System.Windows.Forms.DateTimePicker dtpActionDate;
        private System.Windows.Forms.Button btnChangeRoom;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvAssignments;

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
            pnlFilter = new System.Windows.Forms.Panel();
            btnRefresh = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            txtSearch = new System.Windows.Forms.TextBox();
            cboFilterStatus = new System.Windows.Forms.ComboBox();
            lblFilterStatus = new System.Windows.Forms.Label();
            pnlLeft = new System.Windows.Forms.Panel();
            tabControlAssignment = new System.Windows.Forms.TabControl();
            tabAssign = new System.Windows.Forms.TabPage();
            btnAssign = new System.Windows.Forms.Button();
            dtpStartDate = new System.Windows.Forms.DateTimePicker();
            lblStartDate = new System.Windows.Forms.Label();
            cboRoom = new System.Windows.Forms.ComboBox();
            lblRoom = new System.Windows.Forms.Label();
            cboStudent = new System.Windows.Forms.ComboBox();
            lblStudent = new System.Windows.Forms.Label();
            tabChange = new System.Windows.Forms.TabPage();
            btnCheckout = new System.Windows.Forms.Button();
            btnChangeRoom = new System.Windows.Forms.Button();
            dtpActionDate = new System.Windows.Forms.DateTimePicker();
            lblActionDate = new System.Windows.Forms.Label();
            cboNewRoom = new System.Windows.Forms.ComboBox();
            lblNewRoom = new System.Windows.Forms.Label();
            lblSelectedInfo = new System.Windows.Forms.Label();
            grpList = new System.Windows.Forms.GroupBox();
            dgvAssignments = new System.Windows.Forms.DataGridView();
            pnlFilter.SuspendLayout();
            pnlLeft.SuspendLayout();
            tabControlAssignment.SuspendLayout();
            tabAssign.SuspendLayout();
            tabChange.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).BeginInit();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = System.Drawing.Color.White;
            pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlFilter.Controls.Add(btnRefresh);
            pnlFilter.Controls.Add(btnSearch);
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(cboFilterStatus);
            pnlFilter.Controls.Add(lblFilterStatus);
            pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFilter.Location = new System.Drawing.Point(0, 0);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new System.Drawing.Size(1010, 56);
            pnlFilter.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnRefresh.Location = new System.Drawing.Point(730, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(95, 30);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.FromArgb(24, 119, 242);
            btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(625, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(95, 30);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtSearch.Location = new System.Drawing.Point(315, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã SV, họ tên hoặc số phòng...";
            txtSearch.Size = new System.Drawing.Size(300, 24);
            txtSearch.TabIndex = 2;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Đang lưu trú (Active)", "Đã kết thúc (Ended)" });
            cboFilterStatus.Location = new System.Drawing.Point(100, 15);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.Size = new System.Drawing.Size(190, 24);
            cboFilterStatus.TabIndex = 1;
            cboFilterStatus.SelectedIndexChanged += cboFilterStatus_SelectedIndexChanged;
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblFilterStatus.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFilterStatus.Location = new System.Drawing.Point(20, 18);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new System.Drawing.Size(75, 17);
            lblFilterStatus.TabIndex = 0;
            lblFilterStatus.Text = "Trạng thái:";
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = System.Drawing.Color.White;
            pnlLeft.Controls.Add(tabControlAssignment);
            pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            pnlLeft.Location = new System.Drawing.Point(0, 56);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new System.Windows.Forms.Padding(10);
            pnlLeft.Size = new System.Drawing.Size(360, 634);
            pnlLeft.TabIndex = 1;
            // 
            // tabControlAssignment
            // 
            tabControlAssignment.Controls.Add(tabAssign);
            tabControlAssignment.Controls.Add(tabChange);
            tabControlAssignment.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlAssignment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tabControlAssignment.Location = new System.Drawing.Point(10, 10);
            tabControlAssignment.Name = "tabControlAssignment";
            tabControlAssignment.SelectedIndex = 0;
            tabControlAssignment.Size = new System.Drawing.Size(340, 614);
            tabControlAssignment.TabIndex = 0;
            // 
            // tabAssign
            // 
            tabAssign.BackColor = System.Drawing.Color.White;
            tabAssign.Controls.Add(btnAssign);
            tabAssign.Controls.Add(dtpStartDate);
            tabAssign.Controls.Add(lblStartDate);
            tabAssign.Controls.Add(cboRoom);
            tabAssign.Controls.Add(lblRoom);
            tabAssign.Controls.Add(cboStudent);
            tabAssign.Controls.Add(lblStudent);
            tabAssign.Location = new System.Drawing.Point(4, 26);
            tabAssign.Name = "tabAssign";
            tabAssign.Padding = new System.Windows.Forms.Padding(15);
            tabAssign.Size = new System.Drawing.Size(332, 584);
            tabAssign.TabIndex = 0;
            tabAssign.Text = "Phân phòng mới";
            // 
            // btnAssign
            // 
            btnAssign.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            btnAssign.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAssign.FlatAppearance.BorderSize = 0;
            btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAssign.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnAssign.ForeColor = System.Drawing.Color.White;
            btnAssign.Location = new System.Drawing.Point(15, 230);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new System.Drawing.Size(300, 42);
            btnAssign.TabIndex = 6;
            btnAssign.Text = "XÁC NHẬN PHÂN PHÒNG";
            btnAssign.UseVisualStyleBackColor = false;
            btnAssign.Click += btnAssign_Click;
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpStartDate.Location = new System.Drawing.Point(15, 170);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new System.Drawing.Size(300, 24);
            dtpStartDate.TabIndex = 5;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStartDate.Location = new System.Drawing.Point(15, 148);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new System.Drawing.Size(86, 17);
            lblStartDate.TabIndex = 4;
            lblStartDate.Text = "Ngày vào ở *:";
            // 
            // cboRoom
            // 
            cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboRoom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboRoom.FormattingEnabled = true;
            cboRoom.Location = new System.Drawing.Point(15, 105);
            cboRoom.Name = "cboRoom";
            cboRoom.Size = new System.Drawing.Size(300, 24);
            cboRoom.TabIndex = 3;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRoom.Location = new System.Drawing.Point(15, 83);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new System.Drawing.Size(139, 17);
            lblRoom.TabIndex = 2;
            lblRoom.Text = "Chọn phòng còn chỗ *:";
            // 
            // cboStudent
            // 
            cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboStudent.FormattingEnabled = true;
            cboStudent.Location = new System.Drawing.Point(15, 40);
            cboStudent.Name = "cboStudent";
            cboStudent.Size = new System.Drawing.Size(300, 24);
            cboStudent.TabIndex = 1;
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStudent.Location = new System.Drawing.Point(15, 18);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new System.Drawing.Size(167, 17);
            lblStudent.TabIndex = 0;
            lblStudent.Text = "Chọn SV chưa có phòng *:";
            // 
            // tabChange
            // 
            tabChange.BackColor = System.Drawing.Color.White;
            tabChange.Controls.Add(btnCheckout);
            tabChange.Controls.Add(btnChangeRoom);
            tabChange.Controls.Add(dtpActionDate);
            tabChange.Controls.Add(lblActionDate);
            tabChange.Controls.Add(cboNewRoom);
            tabChange.Controls.Add(lblNewRoom);
            tabChange.Controls.Add(lblSelectedInfo);
            tabChange.Location = new System.Drawing.Point(4, 26);
            tabChange.Name = "tabChange";
            tabChange.Padding = new System.Windows.Forms.Padding(15);
            tabChange.Size = new System.Drawing.Size(332, 584);
            tabChange.TabIndex = 1;
            tabChange.Text = "Chuyển / Trả phòng";
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCheckout.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCheckout.ForeColor = System.Drawing.Color.White;
            btnCheckout.Location = new System.Drawing.Point(15, 335);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new System.Drawing.Size(300, 40);
            btnCheckout.TabIndex = 6;
            btnCheckout.Text = "XÁC NHẬN TRẢ PHÒNG";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // btnChangeRoom
            // 
            btnChangeRoom.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            btnChangeRoom.Cursor = System.Windows.Forms.Cursors.Hand;
            btnChangeRoom.FlatAppearance.BorderSize = 0;
            btnChangeRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnChangeRoom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnChangeRoom.ForeColor = System.Drawing.Color.White;
            btnChangeRoom.Location = new System.Drawing.Point(15, 280);
            btnChangeRoom.Name = "btnChangeRoom";
            btnChangeRoom.Size = new System.Drawing.Size(300, 40);
            btnChangeRoom.TabIndex = 5;
            btnChangeRoom.Text = "XÁC NHẬN CHUYỂN PHÒNG";
            btnChangeRoom.UseVisualStyleBackColor = false;
            btnChangeRoom.Click += btnChangeRoom_Click;
            // 
            // dtpActionDate
            // 
            dtpActionDate.CustomFormat = "dd/MM/yyyy";
            dtpActionDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dtpActionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpActionDate.Location = new System.Drawing.Point(15, 230);
            dtpActionDate.Name = "dtpActionDate";
            dtpActionDate.Size = new System.Drawing.Size(300, 24);
            dtpActionDate.TabIndex = 4;
            // 
            // lblActionDate
            // 
            lblActionDate.AutoSize = true;
            lblActionDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblActionDate.Location = new System.Drawing.Point(15, 208);
            lblActionDate.Name = "lblActionDate";
            lblActionDate.Size = new System.Drawing.Size(127, 17);
            lblActionDate.TabIndex = 3;
            lblActionDate.Text = "Ngày chuyển / trả *:";
            // 
            // cboNewRoom
            // 
            cboNewRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboNewRoom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboNewRoom.FormattingEnabled = true;
            cboNewRoom.Location = new System.Drawing.Point(15, 165);
            cboNewRoom.Name = "cboNewRoom";
            cboNewRoom.Size = new System.Drawing.Size(300, 24);
            cboNewRoom.TabIndex = 2;
            // 
            // lblNewRoom
            // 
            lblNewRoom.AutoSize = true;
            lblNewRoom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblNewRoom.Location = new System.Drawing.Point(15, 143);
            lblNewRoom.Name = "lblNewRoom";
            lblNewRoom.Size = new System.Drawing.Size(183, 17);
            lblNewRoom.TabIndex = 1;
            lblNewRoom.Text = "Chọn phòng mới chuyển đến:";
            // 
            // lblSelectedInfo
            // 
            lblSelectedInfo.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            lblSelectedInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblSelectedInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblSelectedInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblSelectedInfo.Location = new System.Drawing.Point(15, 15);
            lblSelectedInfo.Name = "lblSelectedInfo";
            lblSelectedInfo.Padding = new System.Windows.Forms.Padding(10);
            lblSelectedInfo.Size = new System.Drawing.Size(300, 110);
            lblSelectedInfo.TabIndex = 0;
            lblSelectedInfo.Text = "Vui lòng chọn một dòng sinh viên đang lưu trú từ bảng danh sách bên phải để thực hiện chuyển phòng hoặc trả phòng.";
            // 
            // grpList
            // 
            grpList.BackColor = System.Drawing.Color.White;
            grpList.Controls.Add(dgvAssignments);
            grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            grpList.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpList.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpList.Location = new System.Drawing.Point(360, 56);
            grpList.Name = "grpList";
            grpList.Padding = new System.Windows.Forms.Padding(10);
            grpList.Size = new System.Drawing.Size(650, 634);
            grpList.TabIndex = 2;
            grpList.TabStop = false;
            grpList.Text = "Danh sách phân phòng KTX";
            // 
            // dgvAssignments
            // 
            dgvAssignments.AllowUserToAddRows = false;
            dgvAssignments.AllowUserToDeleteRows = false;
            dgvAssignments.BackgroundColor = System.Drawing.Color.White;
            dgvAssignments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvAssignments.ColumnHeadersHeight = 36;
            dgvAssignments.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvAssignments.EnableHeadersVisualStyles = false;
            dgvAssignments.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvAssignments.Location = new System.Drawing.Point(10, 29);
            dgvAssignments.MultiSelect = false;
            dgvAssignments.Name = "dgvAssignments";
            dgvAssignments.ReadOnly = true;
            dgvAssignments.RowHeadersVisible = false;
            dgvAssignments.RowTemplate.Height = 32;
            dgvAssignments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvAssignments.Size = new System.Drawing.Size(630, 595);
            dgvAssignments.TabIndex = 0;
            dgvAssignments.CellClick += dgvAssignments_CellClick;
            // 
            // RoomAssignmentForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 690);
            Controls.Add(grpList);
            Controls.Add(pnlLeft);
            Controls.Add(pnlFilter);
            Name = "RoomAssignmentForm";
            Text = "Phân và Chuyển phòng";
            Load += RoomAssignmentForm_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlLeft.ResumeLayout(false);
            tabControlAssignment.ResumeLayout(false);
            tabAssign.ResumeLayout(false);
            tabAssign.PerformLayout();
            tabChange.ResumeLayout(false);
            tabChange.PerformLayout();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).EndInit();
            ResumeLayout(false);
        }
    }
}
