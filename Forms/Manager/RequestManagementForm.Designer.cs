namespace QuanLyKtx.Forms.Manager
{
    partial class RequestManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.Label lblFilterType;
        private System.Windows.Forms.ComboBox cboFilterType;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.Label lblSelectedInfo;
        private System.Windows.Forms.Label lblStudentInfo;
        private System.Windows.Forms.TextBox txtStudentInfo;
        private System.Windows.Forms.Label lblRequestType;
        private System.Windows.Forms.TextBox txtRequestType;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblAssignRoom;
        private System.Windows.Forms.ComboBox cboAvailableRooms;
        private System.Windows.Forms.Label lblManagerNote;
        private System.Windows.Forms.TextBox txtManagerNote;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvRequests;

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
            cboFilterType = new System.Windows.Forms.ComboBox();
            lblFilterType = new System.Windows.Forms.Label();
            cboFilterStatus = new System.Windows.Forms.ComboBox();
            lblFilterStatus = new System.Windows.Forms.Label();

            grpAction = new System.Windows.Forms.GroupBox();
            btnClear = new System.Windows.Forms.Button();
            btnReject = new System.Windows.Forms.Button();
            btnApprove = new System.Windows.Forms.Button();
            txtManagerNote = new System.Windows.Forms.TextBox();
            lblManagerNote = new System.Windows.Forms.Label();
            cboAvailableRooms = new System.Windows.Forms.ComboBox();
            lblAssignRoom = new System.Windows.Forms.Label();
            txtContent = new System.Windows.Forms.TextBox();
            lblContent = new System.Windows.Forms.Label();
            txtRequestType = new System.Windows.Forms.TextBox();
            lblRequestType = new System.Windows.Forms.Label();
            txtStudentInfo = new System.Windows.Forms.TextBox();
            lblStudentInfo = new System.Windows.Forms.Label();
            lblSelectedInfo = new System.Windows.Forms.Label();

            grpList = new System.Windows.Forms.GroupBox();
            dgvRequests = new System.Windows.Forms.DataGridView();

            pnlFilter.SuspendLayout();
            grpAction.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRequests).BeginInit();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = System.Drawing.Color.White;
            pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlFilter.Controls.Add(btnRefresh);
            pnlFilter.Controls.Add(btnSearch);
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(cboFilterType);
            pnlFilter.Controls.Add(lblFilterType);
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
            btnRefresh.Location = new System.Drawing.Point(895, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(90, 30);
            btnRefresh.TabIndex = 6;
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
            btnSearch.Location = new System.Drawing.Point(795, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(90, 30);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtSearch.Location = new System.Drawing.Point(545, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã SV, họ tên, mã YC...";
            txtSearch.Size = new System.Drawing.Size(235, 24);
            txtSearch.TabIndex = 4;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // cboFilterType
            // 
            cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterType.FormattingEnabled = true;
            cboFilterType.Items.AddRange(new object[] { "Tất cả", "Đăng ký phòng", "Chuyển phòng", "Trả phòng" });
            cboFilterType.Location = new System.Drawing.Point(355, 15);
            cboFilterType.Name = "cboFilterType";
            cboFilterType.Size = new System.Drawing.Size(170, 24);
            cboFilterType.TabIndex = 3;
            cboFilterType.SelectedIndexChanged += Filter_Changed;
            // 
            // lblFilterType
            // 
            lblFilterType.AutoSize = true;
            lblFilterType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblFilterType.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFilterType.Location = new System.Drawing.Point(285, 18);
            lblFilterType.Name = "lblFilterType";
            lblFilterType.Size = new System.Drawing.Size(61, 17);
            lblFilterType.TabIndex = 2;
            lblFilterType.Text = "Loại đơn:";
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Items.AddRange(new object[] { "Tất cả", "Chờ duyệt (Pending)", "Đã duyệt (Approved)", "Từ chối (Rejected)" });
            cboFilterStatus.Location = new System.Drawing.Point(95, 15);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.Size = new System.Drawing.Size(175, 24);
            cboFilterStatus.TabIndex = 1;
            cboFilterStatus.SelectedIndexChanged += Filter_Changed;
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblFilterStatus.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFilterStatus.Location = new System.Drawing.Point(15, 18);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new System.Drawing.Size(75, 17);
            lblFilterStatus.TabIndex = 0;
            lblFilterStatus.Text = "Trạng thái:";
            // 
            // grpAction
            // 
            grpAction.BackColor = System.Drawing.Color.White;
            grpAction.Controls.Add(btnClear);
            grpAction.Controls.Add(btnReject);
            grpAction.Controls.Add(btnApprove);
            grpAction.Controls.Add(txtManagerNote);
            grpAction.Controls.Add(lblManagerNote);
            grpAction.Controls.Add(cboAvailableRooms);
            grpAction.Controls.Add(lblAssignRoom);
            grpAction.Controls.Add(txtContent);
            grpAction.Controls.Add(lblContent);
            grpAction.Controls.Add(txtRequestType);
            grpAction.Controls.Add(lblRequestType);
            grpAction.Controls.Add(txtStudentInfo);
            grpAction.Controls.Add(lblStudentInfo);
            grpAction.Controls.Add(lblSelectedInfo);
            grpAction.Dock = System.Windows.Forms.DockStyle.Left;
            grpAction.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpAction.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpAction.Location = new System.Drawing.Point(0, 56);
            grpAction.Name = "grpAction";
            grpAction.Padding = new System.Windows.Forms.Padding(12);
            grpAction.Size = new System.Drawing.Size(360, 634);
            grpAction.TabIndex = 1;
            grpAction.TabStop = false;
            grpAction.Text = "Chi tiết & Duyệt yêu cầu";
            // 
            // lblSelectedInfo
            // 
            lblSelectedInfo.AutoSize = true;
            lblSelectedInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblSelectedInfo.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            lblSelectedInfo.Location = new System.Drawing.Point(16, 26);
            lblSelectedInfo.Name = "lblSelectedInfo";
            lblSelectedInfo.Size = new System.Drawing.Size(200, 19);
            lblSelectedInfo.TabIndex = 0;
            lblSelectedInfo.Text = "Chưa chọn yêu cầu nào";
            // 
            // lblStudentInfo
            // 
            lblStudentInfo.AutoSize = true;
            lblStudentInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStudentInfo.Location = new System.Drawing.Point(16, 55);
            lblStudentInfo.Name = "lblStudentInfo";
            lblStudentInfo.Size = new System.Drawing.Size(117, 15);
            lblStudentInfo.TabIndex = 1;
            lblStudentInfo.Text = "Sinh viên gửi yêu cầu:";
            // 
            // txtStudentInfo
            // 
            txtStudentInfo.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtStudentInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtStudentInfo.Location = new System.Drawing.Point(16, 75);
            txtStudentInfo.Name = "txtStudentInfo";
            txtStudentInfo.ReadOnly = true;
            txtStudentInfo.Size = new System.Drawing.Size(325, 24);
            txtStudentInfo.TabIndex = 2;
            // 
            // lblRequestType
            // 
            lblRequestType.AutoSize = true;
            lblRequestType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRequestType.Location = new System.Drawing.Point(16, 110);
            lblRequestType.Name = "lblRequestType";
            lblRequestType.Size = new System.Drawing.Size(76, 15);
            lblRequestType.TabIndex = 3;
            lblRequestType.Text = "Loại yêu cầu:";
            // 
            // txtRequestType
            // 
            txtRequestType.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtRequestType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtRequestType.Location = new System.Drawing.Point(16, 130);
            txtRequestType.Name = "txtRequestType";
            txtRequestType.ReadOnly = true;
            txtRequestType.Size = new System.Drawing.Size(325, 24);
            txtRequestType.TabIndex = 4;
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblContent.Location = new System.Drawing.Point(16, 165);
            lblContent.Name = "lblContent";
            lblContent.Size = new System.Drawing.Size(126, 15);
            lblContent.TabIndex = 5;
            lblContent.Text = "Nội dung sinh viên gửi:";
            // 
            // txtContent
            // 
            txtContent.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtContent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtContent.Location = new System.Drawing.Point(16, 185);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ReadOnly = true;
            txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtContent.Size = new System.Drawing.Size(325, 90);
            txtContent.TabIndex = 6;
            // 
            // lblAssignRoom
            // 
            lblAssignRoom.AutoSize = true;
            lblAssignRoom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblAssignRoom.Location = new System.Drawing.Point(16, 285);
            lblAssignRoom.Name = "lblAssignRoom";
            lblAssignRoom.Size = new System.Drawing.Size(193, 15);
            lblAssignRoom.TabIndex = 7;
            lblAssignRoom.Text = "Chọn phòng xếp / chuyển đến (*):";
            // 
            // cboAvailableRooms
            // 
            cboAvailableRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboAvailableRooms.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboAvailableRooms.FormattingEnabled = true;
            cboAvailableRooms.Location = new System.Drawing.Point(16, 305);
            cboAvailableRooms.Name = "cboAvailableRooms";
            cboAvailableRooms.Size = new System.Drawing.Size(325, 24);
            cboAvailableRooms.TabIndex = 8;
            // 
            // lblManagerNote
            // 
            lblManagerNote.AutoSize = true;
            lblManagerNote.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblManagerNote.Location = new System.Drawing.Point(16, 340);
            lblManagerNote.Name = "lblManagerNote";
            lblManagerNote.Size = new System.Drawing.Size(161, 15);
            lblManagerNote.TabIndex = 9;
            lblManagerNote.Text = "Ghi chú / Lý do phản hồi:";
            // 
            // txtManagerNote
            // 
            txtManagerNote.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtManagerNote.Location = new System.Drawing.Point(16, 360);
            txtManagerNote.Multiline = true;
            txtManagerNote.Name = "txtManagerNote";
            txtManagerNote.PlaceholderText = "Nhập phản hồi gửi cho sinh viên...";
            txtManagerNote.Size = new System.Drawing.Size(325, 95);
            txtManagerNote.TabIndex = 10;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnApprove.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnApprove.ForeColor = System.Drawing.Color.White;
            btnApprove.Location = new System.Drawing.Point(16, 475);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new System.Drawing.Size(155, 38);
            btnApprove.TabIndex = 11;
            btnApprove.Text = "Duyệt yêu cầu";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            btnReject.Cursor = System.Windows.Forms.Cursors.Hand;
            btnReject.FlatAppearance.BorderSize = 0;
            btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnReject.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnReject.ForeColor = System.Drawing.Color.White;
            btnReject.Location = new System.Drawing.Point(185, 475);
            btnReject.Name = "btnReject";
            btnReject.Size = new System.Drawing.Size(155, 38);
            btnReject.TabIndex = 12;
            btnReject.Text = "Từ chối";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnClear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnClear.Location = new System.Drawing.Point(16, 525);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(325, 36);
            btnClear.TabIndex = 13;
            btnClear.Text = "Bỏ chọn / Làm mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // grpList
            // 
            grpList.BackColor = System.Drawing.Color.White;
            grpList.Controls.Add(dgvRequests);
            grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            grpList.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpList.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpList.Location = new System.Drawing.Point(360, 56);
            grpList.Name = "grpList";
            grpList.Padding = new System.Windows.Forms.Padding(10);
            grpList.Size = new System.Drawing.Size(650, 634);
            grpList.TabIndex = 2;
            grpList.TabStop = false;
            grpList.Text = "Danh sách yêu cầu của sinh viên";
            // 
            // dgvRequests
            // 
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AllowUserToDeleteRows = false;
            dgvRequests.BackgroundColor = System.Drawing.Color.White;
            dgvRequests.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvRequests.ColumnHeadersHeight = 36;
            dgvRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvRequests.Location = new System.Drawing.Point(10, 29);
            dgvRequests.MultiSelect = false;
            dgvRequests.Name = "dgvRequests";
            dgvRequests.ReadOnly = true;
            dgvRequests.RowHeadersVisible = false;
            dgvRequests.RowTemplate.Height = 32;
            dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvRequests.Size = new System.Drawing.Size(630, 595);
            dgvRequests.TabIndex = 0;
            dgvRequests.CellClick += dgvRequests_CellClick;
            // 
            // RequestManagementForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 690);
            Controls.Add(grpList);
            Controls.Add(grpAction);
            Controls.Add(pnlFilter);
            Name = "RequestManagementForm";
            Text = "Xử lý Yêu cầu Sinh viên";
            Load += RequestManagementForm_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            grpAction.ResumeLayout(false);
            grpAction.PerformLayout();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRequests).EndInit();
            ResumeLayout(false);
        }
    }
}
