namespace QuanLyKtx.Forms.Manager
{
    partial class StudentManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblStudentCode;
        private System.Windows.Forms.TextBox txtStudentCode;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.TextBox txtFaculty;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvStudents;

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
            pnlSearch = new System.Windows.Forms.Panel();
            btnRefresh = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            txtSearch = new System.Windows.Forms.TextBox();
            lblSearch = new System.Windows.Forms.Label();
            grpInfo = new System.Windows.Forms.GroupBox();
            btnClear = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            txtAddress = new System.Windows.Forms.TextBox();
            lblAddress = new System.Windows.Forms.Label();
            txtFaculty = new System.Windows.Forms.TextBox();
            lblFaculty = new System.Windows.Forms.Label();
            txtClassName = new System.Windows.Forms.TextBox();
            lblClassName = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtPhone = new System.Windows.Forms.TextBox();
            lblPhone = new System.Windows.Forms.Label();
            cboGender = new System.Windows.Forms.ComboBox();
            lblGender = new System.Windows.Forms.Label();
            dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            lblDateOfBirth = new System.Windows.Forms.Label();
            txtFullName = new System.Windows.Forms.TextBox();
            lblFullName = new System.Windows.Forms.Label();
            txtStudentCode = new System.Windows.Forms.TextBox();
            lblStudentCode = new System.Windows.Forms.Label();
            grpList = new System.Windows.Forms.GroupBox();
            dgvStudents = new System.Windows.Forms.DataGridView();
            pnlSearch.SuspendLayout();
            grpInfo.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = System.Drawing.Color.White;
            pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlSearch.Controls.Add(btnRefresh);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            pnlSearch.Location = new System.Drawing.Point(0, 0);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new System.Drawing.Size(1010, 56);
            pnlSearch.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnRefresh.Location = new System.Drawing.Point(625, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(110, 30);
            btnRefresh.TabIndex = 3;
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
            btnSearch.Location = new System.Drawing.Point(505, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(110, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtSearch.Location = new System.Drawing.Point(155, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã SV, họ tên, SĐT hoặc lớp...";
            txtSearch.Size = new System.Drawing.Size(340, 25);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblSearch.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblSearch.Location = new System.Drawing.Point(20, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new System.Drawing.Size(126, 19);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm nhanh:";
            // 
            // grpInfo
            // 
            grpInfo.BackColor = System.Drawing.Color.White;
            grpInfo.Controls.Add(btnClear);
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnEdit);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(txtAddress);
            grpInfo.Controls.Add(lblAddress);
            grpInfo.Controls.Add(txtFaculty);
            grpInfo.Controls.Add(lblFaculty);
            grpInfo.Controls.Add(txtClassName);
            grpInfo.Controls.Add(lblClassName);
            grpInfo.Controls.Add(txtEmail);
            grpInfo.Controls.Add(lblEmail);
            grpInfo.Controls.Add(txtPhone);
            grpInfo.Controls.Add(lblPhone);
            grpInfo.Controls.Add(cboGender);
            grpInfo.Controls.Add(lblGender);
            grpInfo.Controls.Add(dtpDateOfBirth);
            grpInfo.Controls.Add(lblDateOfBirth);
            grpInfo.Controls.Add(txtFullName);
            grpInfo.Controls.Add(lblFullName);
            grpInfo.Controls.Add(txtStudentCode);
            grpInfo.Controls.Add(lblStudentCode);
            grpInfo.Dock = System.Windows.Forms.DockStyle.Left;
            grpInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpInfo.Location = new System.Drawing.Point(0, 56);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new System.Windows.Forms.Padding(12);
            grpInfo.Size = new System.Drawing.Size(350, 634);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin sinh viên";
            // 
            // btnClear
            // 
            btnClear.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnClear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnClear.Location = new System.Drawing.Point(180, 575);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(145, 36);
            btnClear.TabIndex = 21;
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
            btnDelete.Location = new System.Drawing.Point(20, 575);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(145, 36);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "Xóa SV";
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
            btnEdit.Location = new System.Drawing.Point(180, 530);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(145, 36);
            btnEdit.TabIndex = 19;
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
            btnAdd.Location = new System.Drawing.Point(20, 530);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(145, 36);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtAddress
            // 
            txtAddress.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtAddress.Location = new System.Drawing.Point(20, 480);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new System.Drawing.Size(305, 24);
            txtAddress.TabIndex = 17;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblAddress.Location = new System.Drawing.Point(20, 458);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new System.Drawing.Size(50, 17);
            lblAddress.TabIndex = 16;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtFaculty
            // 
            txtFaculty.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtFaculty.Location = new System.Drawing.Point(20, 425);
            txtFaculty.Name = "txtFaculty";
            txtFaculty.Size = new System.Drawing.Size(305, 24);
            txtFaculty.TabIndex = 15;
            // 
            // lblFaculty
            // 
            lblFaculty.AutoSize = true;
            lblFaculty.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblFaculty.Location = new System.Drawing.Point(20, 403);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new System.Drawing.Size(41, 17);
            lblFaculty.TabIndex = 14;
            lblFaculty.Text = "Khoa:";
            // 
            // txtClassName
            // 
            txtClassName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtClassName.Location = new System.Drawing.Point(20, 370);
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new System.Drawing.Size(305, 24);
            txtClassName.TabIndex = 13;
            // 
            // lblClassName
            // 
            lblClassName.AutoSize = true;
            lblClassName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblClassName.Location = new System.Drawing.Point(20, 348);
            lblClassName.Name = "lblClassName";
            lblClassName.Size = new System.Drawing.Size(33, 17);
            lblClassName.TabIndex = 12;
            lblClassName.Text = "Lớp:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtEmail.Location = new System.Drawing.Point(20, 315);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(305, 24);
            txtEmail.TabIndex = 11;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblEmail.Location = new System.Drawing.Point(20, 293);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(42, 17);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtPhone.Location = new System.Drawing.Point(20, 260);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new System.Drawing.Size(305, 24);
            txtPhone.TabIndex = 9;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblPhone.Location = new System.Drawing.Point(20, 238);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new System.Drawing.Size(88, 17);
            lblPhone.TabIndex = 8;
            lblPhone.Text = "Số điện thoại:";
            // 
            // cboGender
            // 
            cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboGender.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboGender.FormattingEnabled = true;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
            cboGender.Location = new System.Drawing.Point(20, 205);
            cboGender.Name = "cboGender";
            cboGender.Size = new System.Drawing.Size(305, 25);
            cboGender.TabIndex = 7;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblGender.Location = new System.Drawing.Point(20, 183);
            lblGender.Name = "lblGender";
            lblGender.Size = new System.Drawing.Size(59, 17);
            lblGender.TabIndex = 6;
            lblGender.Text = "Giới tính:";
            // 
            // dtpDateOfBirth
            // 
            dtpDateOfBirth.CustomFormat = "dd/MM/yyyy";
            dtpDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpDateOfBirth.Location = new System.Drawing.Point(20, 150);
            dtpDateOfBirth.Name = "dtpDateOfBirth";
            dtpDateOfBirth.Size = new System.Drawing.Size(305, 24);
            dtpDateOfBirth.TabIndex = 5;
            // 
            // lblDateOfBirth
            // 
            lblDateOfBirth.AutoSize = true;
            lblDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblDateOfBirth.Location = new System.Drawing.Point(20, 128);
            lblDateOfBirth.Name = "lblDateOfBirth";
            lblDateOfBirth.Size = new System.Drawing.Size(69, 17);
            lblDateOfBirth.TabIndex = 4;
            lblDateOfBirth.Text = "Ngày sinh:";
            // 
            // txtFullName
            // 
            txtFullName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtFullName.Location = new System.Drawing.Point(20, 95);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new System.Drawing.Size(305, 24);
            txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblFullName.Location = new System.Drawing.Point(20, 73);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new System.Drawing.Size(67, 17);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtStudentCode
            // 
            txtStudentCode.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtStudentCode.Location = new System.Drawing.Point(20, 45);
            txtStudentCode.Name = "txtStudentCode";
            txtStudentCode.Size = new System.Drawing.Size(305, 24);
            txtStudentCode.TabIndex = 1;
            // 
            // lblStudentCode
            // 
            lblStudentCode.AutoSize = true;
            lblStudentCode.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStudentCode.Location = new System.Drawing.Point(20, 25);
            lblStudentCode.Name = "lblStudentCode";
            lblStudentCode.Size = new System.Drawing.Size(84, 17);
            lblStudentCode.TabIndex = 0;
            lblStudentCode.Text = "Mã sinh viên:";
            // 
            // grpList
            // 
            grpList.BackColor = System.Drawing.Color.White;
            grpList.Controls.Add(dgvStudents);
            grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            grpList.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpList.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpList.Location = new System.Drawing.Point(350, 56);
            grpList.Name = "grpList";
            grpList.Padding = new System.Windows.Forms.Padding(10);
            grpList.Size = new System.Drawing.Size(660, 634);
            grpList.TabIndex = 2;
            grpList.TabStop = false;
            grpList.Text = "Danh sách sinh viên";
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.BackgroundColor = System.Drawing.Color.White;
            dgvStudents.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvStudents.ColumnHeadersHeight = 36;
            dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvStudents.EnableHeadersVisualStyles = false;
            dgvStudents.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvStudents.Location = new System.Drawing.Point(10, 29);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowTemplate.Height = 32;
            dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new System.Drawing.Size(640, 595);
            dgvStudents.TabIndex = 0;
            dgvStudents.CellClick += dgvStudents_CellClick;
            // 
            // StudentManagementForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 690);
            Controls.Add(grpList);
            Controls.Add(grpInfo);
            Controls.Add(pnlSearch);
            Name = "StudentManagementForm";
            Text = "Quản lý Sinh viên";
            Load += StudentManagementForm_Load;
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
        }
    }
}
