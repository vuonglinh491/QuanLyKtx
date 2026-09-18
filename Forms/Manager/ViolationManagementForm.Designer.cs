namespace QuanLyKtx.Forms.Manager
{
    partial class ViolationManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cboStudent;
        private System.Windows.Forms.Label lblViolationDate;
        private System.Windows.Forms.DateTimePicker dtpViolationDate;
        private System.Windows.Forms.Label lblViolationType;
        private System.Windows.Forms.ComboBox cboViolationType;
        private System.Windows.Forms.Label lblFineAmount;
        private System.Windows.Forms.TextBox txtFineAmount;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvViolations;

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
            grpInfo = new System.Windows.Forms.GroupBox();
            btnClear = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            txtDescription = new System.Windows.Forms.TextBox();
            lblDescription = new System.Windows.Forms.Label();
            cboStatus = new System.Windows.Forms.ComboBox();
            lblStatus = new System.Windows.Forms.Label();
            txtFineAmount = new System.Windows.Forms.TextBox();
            lblFineAmount = new System.Windows.Forms.Label();
            cboViolationType = new System.Windows.Forms.ComboBox();
            lblViolationType = new System.Windows.Forms.Label();
            dtpViolationDate = new System.Windows.Forms.DateTimePicker();
            lblViolationDate = new System.Windows.Forms.Label();
            cboStudent = new System.Windows.Forms.ComboBox();
            lblStudent = new System.Windows.Forms.Label();
            grpList = new System.Windows.Forms.GroupBox();
            dgvViolations = new System.Windows.Forms.DataGridView();
            pnlFilter.SuspendLayout();
            grpInfo.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvViolations).BeginInit();
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
            btnRefresh.Location = new System.Drawing.Point(745, 12);
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
            btnSearch.Location = new System.Drawing.Point(640, 12);
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
            txtSearch.Location = new System.Drawing.Point(345, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã SV, họ tên hoặc mã VP...";
            txtSearch.Size = new System.Drawing.Size(280, 24);
            txtSearch.TabIndex = 2;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Items.AddRange(new object[] { "Tất cả", "Chưa nộp phạt (Unpaid)", "Đã nộp phạt (Paid)" });
            cboFilterStatus.Location = new System.Drawing.Point(100, 15);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.Size = new System.Drawing.Size(220, 24);
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
            // grpInfo
            // 
            grpInfo.BackColor = System.Drawing.Color.White;
            grpInfo.Controls.Add(btnClear);
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnEdit);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(txtDescription);
            grpInfo.Controls.Add(lblDescription);
            grpInfo.Controls.Add(cboStatus);
            grpInfo.Controls.Add(lblStatus);
            grpInfo.Controls.Add(txtFineAmount);
            grpInfo.Controls.Add(lblFineAmount);
            grpInfo.Controls.Add(cboViolationType);
            grpInfo.Controls.Add(lblViolationType);
            grpInfo.Controls.Add(dtpViolationDate);
            grpInfo.Controls.Add(lblViolationDate);
            grpInfo.Controls.Add(cboStudent);
            grpInfo.Controls.Add(lblStudent);
            grpInfo.Dock = System.Windows.Forms.DockStyle.Left;
            grpInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpInfo.Location = new System.Drawing.Point(0, 56);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new System.Windows.Forms.Padding(12);
            grpInfo.Size = new System.Drawing.Size(340, 634);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin vi phạm";
            // 
            // btnClear
            // 
            btnClear.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnClear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnClear.Location = new System.Drawing.Point(175, 520);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(145, 36);
            btnClear.TabIndex = 15;
            btnClear.Text = "Xóa trắng";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.Location = new System.Drawing.Point(20, 520);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(145, 36);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Xóa vi phạm";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnEdit.ForeColor = System.Drawing.Color.White;
            btnEdit.Location = new System.Drawing.Point(175, 475);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(145, 36);
            btnEdit.TabIndex = 13;
            btnEdit.Text = "Cập nhật";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.Location = new System.Drawing.Point(20, 475);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(145, 36);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Thêm vi phạm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtDescription
            // 
            txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtDescription.Location = new System.Drawing.Point(20, 360);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Chi tiết diễn biến sự việc...";
            txtDescription.Size = new System.Drawing.Size(300, 95);
            txtDescription.TabIndex = 11;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblDescription.Location = new System.Drawing.Point(20, 338);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(95, 17);
            lblDescription.TabIndex = 10;
            lblDescription.Text = "Mô tả chi tiết:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Chưa nộp phạt (Unpaid)", "Đã nộp phạt (Paid)" });
            cboStatus.Location = new System.Drawing.Point(20, 300);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new System.Drawing.Size(300, 24);
            cboStatus.TabIndex = 9;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStatus.Location = new System.Drawing.Point(20, 278);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(69, 17);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Trạng thái:";
            // 
            // txtFineAmount
            // 
            txtFineAmount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtFineAmount.Location = new System.Drawing.Point(20, 240);
            txtFineAmount.Name = "txtFineAmount";
            txtFineAmount.PlaceholderText = "Ví dụ: 100000";
            txtFineAmount.Size = new System.Drawing.Size(300, 24);
            txtFineAmount.TabIndex = 7;
            // 
            // lblFineAmount
            // 
            lblFineAmount.AutoSize = true;
            lblFineAmount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblFineAmount.Location = new System.Drawing.Point(20, 218);
            lblFineAmount.Name = "lblFineAmount";
            lblFineAmount.Size = new System.Drawing.Size(109, 17);
            lblFineAmount.TabIndex = 6;
            lblFineAmount.Text = "Tiền phạt (VNĐ):";
            // 
            // cboViolationType
            // 
            cboViolationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboViolationType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboViolationType.FormattingEnabled = true;
            cboViolationType.Items.AddRange(new object[] { "Nấu ăn trong phòng", "Về quá giờ quy định", "Gây mất trật tự", "Sử dụng thiết bị cấm", "Vệ sinh phòng kém", "Dẫn người lạ vào phòng", "Khác" });
            cboViolationType.Location = new System.Drawing.Point(20, 180);
            cboViolationType.Name = "cboViolationType";
            cboViolationType.Size = new System.Drawing.Size(300, 24);
            cboViolationType.TabIndex = 5;
            // 
            // lblViolationType
            // 
            lblViolationType.AutoSize = true;
            lblViolationType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblViolationType.Location = new System.Drawing.Point(20, 158);
            lblViolationType.Name = "lblViolationType";
            lblViolationType.Size = new System.Drawing.Size(98, 17);
            lblViolationType.TabIndex = 4;
            lblViolationType.Text = "Hành vi vi phạm:";
            // 
            // dtpViolationDate
            // 
            dtpViolationDate.CustomFormat = "dd/MM/yyyy";
            dtpViolationDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dtpViolationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpViolationDate.Location = new System.Drawing.Point(20, 120);
            dtpViolationDate.Name = "dtpViolationDate";
            dtpViolationDate.Size = new System.Drawing.Size(300, 24);
            dtpViolationDate.TabIndex = 3;
            // 
            // lblViolationDate
            // 
            lblViolationDate.AutoSize = true;
            lblViolationDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblViolationDate.Location = new System.Drawing.Point(20, 98);
            lblViolationDate.Name = "lblViolationDate";
            lblViolationDate.Size = new System.Drawing.Size(95, 17);
            lblViolationDate.TabIndex = 2;
            lblViolationDate.Text = "Ngày vi phạm:";
            // 
            // cboStudent
            // 
            cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboStudent.FormattingEnabled = true;
            cboStudent.Location = new System.Drawing.Point(20, 60);
            cboStudent.Name = "cboStudent";
            cboStudent.Size = new System.Drawing.Size(300, 24);
            cboStudent.TabIndex = 1;
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStudent.Location = new System.Drawing.Point(20, 38);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new System.Drawing.Size(123, 17);
            lblStudent.TabIndex = 0;
            lblStudent.Text = "Sinh viên vi phạm *:";
            // 
            // grpList
            // 
            grpList.BackColor = System.Drawing.Color.White;
            grpList.Controls.Add(dgvViolations);
            grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            grpList.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpList.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpList.Location = new System.Drawing.Point(340, 56);
            grpList.Name = "grpList";
            grpList.Padding = new System.Windows.Forms.Padding(10);
            grpList.Size = new System.Drawing.Size(670, 634);
            grpList.TabIndex = 2;
            grpList.TabStop = false;
            grpList.Text = "Danh sách biên bản kỷ luật & vi phạm";
            // 
            // dgvViolations
            // 
            dgvViolations.AllowUserToAddRows = false;
            dgvViolations.AllowUserToDeleteRows = false;
            dgvViolations.BackgroundColor = System.Drawing.Color.White;
            dgvViolations.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvViolations.ColumnHeadersHeight = 36;
            dgvViolations.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvViolations.EnableHeadersVisualStyles = false;
            dgvViolations.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvViolations.Location = new System.Drawing.Point(10, 29);
            dgvViolations.MultiSelect = false;
            dgvViolations.Name = "dgvViolations";
            dgvViolations.ReadOnly = true;
            dgvViolations.RowHeadersVisible = false;
            dgvViolations.RowTemplate.Height = 32;
            dgvViolations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvViolations.Size = new System.Drawing.Size(650, 595);
            dgvViolations.TabIndex = 0;
            dgvViolations.CellClick += dgvViolations_CellClick;
            // 
            // ViolationManagementForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 690);
            Controls.Add(grpList);
            Controls.Add(grpInfo);
            Controls.Add(pnlFilter);
            Name = "ViolationManagementForm";
            Text = "Quản lý Vi phạm";
            Load += ViolationManagementForm_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvViolations).EndInit();
            ResumeLayout(false);
        }
    }
}
