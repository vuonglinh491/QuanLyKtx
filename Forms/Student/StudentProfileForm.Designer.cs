namespace QuanLyKtx.Forms.Student
{
    partial class StudentProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpPersonalInfo;
        private System.Windows.Forms.Label lblStudentCode;
        private System.Windows.Forms.TextBox txtStudentCode;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.TextBox txtDob;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox txtGender;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label lblMajor;
        private System.Windows.Forms.TextBox txtMajor;
        private System.Windows.Forms.Label lblFaculty;
        private System.Windows.Forms.TextBox txtFaculty;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSaveContact;

        private System.Windows.Forms.GroupBox grpPassword;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnChangePassword;

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
            grpPersonalInfo = new System.Windows.Forms.GroupBox();
            btnSaveContact = new System.Windows.Forms.Button();
            txtAddress = new System.Windows.Forms.TextBox();
            lblAddress = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtPhone = new System.Windows.Forms.TextBox();
            lblPhone = new System.Windows.Forms.Label();
            txtFaculty = new System.Windows.Forms.TextBox();
            lblFaculty = new System.Windows.Forms.Label();
            txtMajor = new System.Windows.Forms.TextBox();
            lblMajor = new System.Windows.Forms.Label();
            txtClass = new System.Windows.Forms.TextBox();
            lblClass = new System.Windows.Forms.Label();
            txtGender = new System.Windows.Forms.TextBox();
            lblGender = new System.Windows.Forms.Label();
            txtDob = new System.Windows.Forms.TextBox();
            lblDob = new System.Windows.Forms.Label();
            txtFullName = new System.Windows.Forms.TextBox();
            lblFullName = new System.Windows.Forms.Label();
            txtStudentCode = new System.Windows.Forms.TextBox();
            lblStudentCode = new System.Windows.Forms.Label();

            grpPassword = new System.Windows.Forms.GroupBox();
            btnChangePassword = new System.Windows.Forms.Button();
            txtConfirmPassword = new System.Windows.Forms.TextBox();
            lblConfirmPassword = new System.Windows.Forms.Label();
            txtNewPassword = new System.Windows.Forms.TextBox();
            lblNewPassword = new System.Windows.Forms.Label();
            txtCurrentPassword = new System.Windows.Forms.TextBox();
            lblCurrentPassword = new System.Windows.Forms.Label();

            grpPersonalInfo.SuspendLayout();
            grpPassword.SuspendLayout();
            SuspendLayout();
            // 
            // grpPersonalInfo
            // 
            grpPersonalInfo.BackColor = System.Drawing.Color.White;
            grpPersonalInfo.Controls.Add(btnSaveContact);
            grpPersonalInfo.Controls.Add(txtAddress);
            grpPersonalInfo.Controls.Add(lblAddress);
            grpPersonalInfo.Controls.Add(txtEmail);
            grpPersonalInfo.Controls.Add(lblEmail);
            grpPersonalInfo.Controls.Add(txtPhone);
            grpPersonalInfo.Controls.Add(lblPhone);
            grpPersonalInfo.Controls.Add(txtFaculty);
            grpPersonalInfo.Controls.Add(lblFaculty);
            grpPersonalInfo.Controls.Add(txtMajor);
            grpPersonalInfo.Controls.Add(lblMajor);
            grpPersonalInfo.Controls.Add(txtClass);
            grpPersonalInfo.Controls.Add(lblClass);
            grpPersonalInfo.Controls.Add(txtGender);
            grpPersonalInfo.Controls.Add(lblGender);
            grpPersonalInfo.Controls.Add(txtDob);
            grpPersonalInfo.Controls.Add(lblDob);
            grpPersonalInfo.Controls.Add(txtFullName);
            grpPersonalInfo.Controls.Add(lblFullName);
            grpPersonalInfo.Controls.Add(txtStudentCode);
            grpPersonalInfo.Controls.Add(lblStudentCode);
            grpPersonalInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpPersonalInfo.ForeColor = System.Drawing.Color.FromArgb(15, 76, 129);
            grpPersonalInfo.Location = new System.Drawing.Point(25, 20);
            grpPersonalInfo.Name = "grpPersonalInfo";
            grpPersonalInfo.Size = new System.Drawing.Size(560, 580);
            grpPersonalInfo.TabIndex = 0;
            grpPersonalInfo.TabStop = false;
            grpPersonalInfo.Text = "Hồ sơ cá nhân";
            // 
            // lblStudentCode
            // 
            lblStudentCode.AutoSize = true;
            lblStudentCode.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStudentCode.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblStudentCode.Location = new System.Drawing.Point(25, 35);
            lblStudentCode.Name = "lblStudentCode";
            lblStudentCode.Size = new System.Drawing.Size(83, 17);
            lblStudentCode.TabIndex = 0;
            lblStudentCode.Text = "Mã sinh viên:";
            // 
            // txtStudentCode
            // 
            txtStudentCode.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtStudentCode.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtStudentCode.Location = new System.Drawing.Point(25, 55);
            txtStudentCode.Name = "txtStudentCode";
            txtStudentCode.ReadOnly = true;
            txtStudentCode.Size = new System.Drawing.Size(240, 24);
            txtStudentCode.TabIndex = 1;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblFullName.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFullName.Location = new System.Drawing.Point(290, 35);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new System.Drawing.Size(66, 17);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtFullName
            // 
            txtFullName.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtFullName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtFullName.Location = new System.Drawing.Point(290, 55);
            txtFullName.Name = "txtFullName";
            txtFullName.ReadOnly = true;
            txtFullName.Size = new System.Drawing.Size(245, 24);
            txtFullName.TabIndex = 3;
            // 
            // lblDob
            // 
            lblDob.AutoSize = true;
            lblDob.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblDob.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblDob.Location = new System.Drawing.Point(25, 95);
            lblDob.Name = "lblDob";
            lblDob.Size = new System.Drawing.Size(68, 17);
            lblDob.TabIndex = 4;
            lblDob.Text = "Ngày sinh:";
            // 
            // txtDob
            // 
            txtDob.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtDob.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtDob.Location = new System.Drawing.Point(25, 115);
            txtDob.Name = "txtDob";
            txtDob.ReadOnly = true;
            txtDob.Size = new System.Drawing.Size(240, 24);
            txtDob.TabIndex = 5;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblGender.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblGender.Location = new System.Drawing.Point(290, 95);
            lblGender.Name = "lblGender";
            lblGender.Size = new System.Drawing.Size(59, 17);
            lblGender.TabIndex = 6;
            lblGender.Text = "Giới tính:";
            // 
            // txtGender
            // 
            txtGender.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtGender.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtGender.Location = new System.Drawing.Point(290, 115);
            txtGender.Name = "txtGender";
            txtGender.ReadOnly = true;
            txtGender.Size = new System.Drawing.Size(245, 24);
            txtGender.TabIndex = 7;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblClass.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblClass.Location = new System.Drawing.Point(25, 155);
            lblClass.Name = "lblClass";
            lblClass.Size = new System.Drawing.Size(33, 17);
            lblClass.TabIndex = 8;
            lblClass.Text = "Lớp:";
            // 
            // txtClass
            // 
            txtClass.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtClass.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtClass.Location = new System.Drawing.Point(25, 175);
            txtClass.Name = "txtClass";
            txtClass.ReadOnly = true;
            txtClass.Size = new System.Drawing.Size(240, 24);
            txtClass.TabIndex = 9;
            // 
            // lblMajor
            // 
            lblMajor.AutoSize = true;
            lblMajor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblMajor.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblMajor.Location = new System.Drawing.Point(290, 155);
            lblMajor.Name = "lblMajor";
            lblMajor.Size = new System.Drawing.Size(95, 17);
            lblMajor.TabIndex = 10;
            lblMajor.Text = "Chuyên ngành:";
            // 
            // txtMajor
            // 
            txtMajor.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtMajor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtMajor.Location = new System.Drawing.Point(290, 175);
            txtMajor.Name = "txtMajor";
            txtMajor.ReadOnly = true;
            txtMajor.Size = new System.Drawing.Size(245, 24);
            txtMajor.TabIndex = 11;
            // 
            // lblFaculty
            // 
            lblFaculty.AutoSize = true;
            lblFaculty.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblFaculty.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFaculty.Location = new System.Drawing.Point(25, 215);
            lblFaculty.Name = "lblFaculty";
            lblFaculty.Size = new System.Drawing.Size(41, 17);
            lblFaculty.TabIndex = 12;
            lblFaculty.Text = "Khoa:";
            // 
            // txtFaculty
            // 
            txtFaculty.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtFaculty.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtFaculty.Location = new System.Drawing.Point(25, 235);
            txtFaculty.Name = "txtFaculty";
            txtFaculty.ReadOnly = true;
            txtFaculty.Size = new System.Drawing.Size(510, 24);
            txtFaculty.TabIndex = 13;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblPhone.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblPhone.Location = new System.Drawing.Point(25, 275);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new System.Drawing.Size(107, 17);
            lblPhone.TabIndex = 14;
            lblPhone.Text = "Số điện thoại (*):";
            // 
            // txtPhone
            // 
            txtPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtPhone.Location = new System.Drawing.Point(25, 295);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new System.Drawing.Size(510, 24);
            txtPhone.TabIndex = 15;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblEmail.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblEmail.Location = new System.Drawing.Point(25, 335);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(60, 17);
            lblEmail.TabIndex = 16;
            lblEmail.Text = "Email (*):";
            // 
            // txtEmail
            // 
            txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtEmail.Location = new System.Drawing.Point(25, 355);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(510, 24);
            txtEmail.TabIndex = 17;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblAddress.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblAddress.Location = new System.Drawing.Point(25, 395);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new System.Drawing.Size(73, 17);
            lblAddress.TabIndex = 18;
            lblAddress.Text = "Địa chỉ (*):";
            // 
            // txtAddress
            // 
            txtAddress.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtAddress.Location = new System.Drawing.Point(25, 415);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new System.Drawing.Size(510, 60);
            txtAddress.TabIndex = 19;
            // 
            // btnSaveContact
            // 
            btnSaveContact.BackColor = System.Drawing.Color.FromArgb(15, 76, 129);
            btnSaveContact.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSaveContact.FlatAppearance.BorderSize = 0;
            btnSaveContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSaveContact.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSaveContact.ForeColor = System.Drawing.Color.White;
            btnSaveContact.Location = new System.Drawing.Point(25, 495);
            btnSaveContact.Name = "btnSaveContact";
            btnSaveContact.Size = new System.Drawing.Size(510, 40);
            btnSaveContact.TabIndex = 20;
            btnSaveContact.Text = "Lưu thông tin liên hệ";
            btnSaveContact.UseVisualStyleBackColor = false;
            btnSaveContact.Click += btnSaveContact_Click;
            // 
            // grpPassword
            // 
            grpPassword.BackColor = System.Drawing.Color.White;
            grpPassword.Controls.Add(btnChangePassword);
            grpPassword.Controls.Add(txtConfirmPassword);
            grpPassword.Controls.Add(lblConfirmPassword);
            grpPassword.Controls.Add(txtNewPassword);
            grpPassword.Controls.Add(lblNewPassword);
            grpPassword.Controls.Add(txtCurrentPassword);
            grpPassword.Controls.Add(lblCurrentPassword);
            grpPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpPassword.ForeColor = System.Drawing.Color.FromArgb(15, 76, 129);
            grpPassword.Location = new System.Drawing.Point(610, 20);
            grpPassword.Name = "grpPassword";
            grpPassword.Size = new System.Drawing.Size(370, 310);
            grpPassword.TabIndex = 1;
            grpPassword.TabStop = false;
            grpPassword.Text = "Đổi mật khẩu";
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblCurrentPassword.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblCurrentPassword.Location = new System.Drawing.Point(25, 35);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new System.Drawing.Size(110, 17);
            lblCurrentPassword.TabIndex = 0;
            lblCurrentPassword.Text = "Mật khẩu hiện tại:";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtCurrentPassword.Location = new System.Drawing.Point(25, 55);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.PasswordChar = '●';
            txtCurrentPassword.Size = new System.Drawing.Size(320, 24);
            txtCurrentPassword.TabIndex = 1;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblNewPassword.Location = new System.Drawing.Point(25, 95);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new System.Drawing.Size(91, 17);
            lblNewPassword.TabIndex = 2;
            lblNewPassword.Text = "Mật khẩu mới:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtNewPassword.Location = new System.Drawing.Point(25, 115);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '●';
            txtNewPassword.Size = new System.Drawing.Size(320, 24);
            txtNewPassword.TabIndex = 3;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblConfirmPassword.Location = new System.Drawing.Point(25, 155);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new System.Drawing.Size(147, 17);
            lblConfirmPassword.TabIndex = 4;
            lblConfirmPassword.Text = "Xác nhận mật khẩu mới:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtConfirmPassword.Location = new System.Drawing.Point(25, 175);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new System.Drawing.Size(320, 24);
            txtConfirmPassword.TabIndex = 5;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnChangePassword.ForeColor = System.Drawing.Color.White;
            btnChangePassword.Location = new System.Drawing.Point(25, 230);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new System.Drawing.Size(320, 40);
            btnChangePassword.TabIndex = 6;
            btnChangePassword.Text = "Cập nhật mật khẩu";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // StudentProfileForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 650);
            Controls.Add(grpPassword);
            Controls.Add(grpPersonalInfo);
            Name = "StudentProfileForm";
            Text = "Hồ sơ cá nhân";
            Load += StudentProfileForm_Load;
            grpPersonalInfo.ResumeLayout(false);
            grpPersonalInfo.PerformLayout();
            grpPassword.ResumeLayout(false);
            grpPassword.PerformLayout();
            ResumeLayout(false);
        }
    }
}
