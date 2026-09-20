namespace QuanLyKtx.Forms.Student
{
    partial class RequestForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpSubmit;
        private System.Windows.Forms.Label lblRequestType;
        private System.Windows.Forms.ComboBox cboRequestType;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;

        private System.Windows.Forms.GroupBox grpHistory;
        private System.Windows.Forms.DataGridView dgvMyRequests;
        private System.Windows.Forms.Button btnRefresh;

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
            grpSubmit = new System.Windows.Forms.GroupBox();
            btnClear = new System.Windows.Forms.Button();
            btnSubmit = new System.Windows.Forms.Button();
            txtContent = new System.Windows.Forms.TextBox();
            lblContent = new System.Windows.Forms.Label();
            cboRequestType = new System.Windows.Forms.ComboBox();
            lblRequestType = new System.Windows.Forms.Label();

            grpHistory = new System.Windows.Forms.GroupBox();
            btnRefresh = new System.Windows.Forms.Button();
            dgvMyRequests = new System.Windows.Forms.DataGridView();

            grpSubmit.SuspendLayout();
            grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyRequests).BeginInit();
            SuspendLayout();
            // 
            // grpSubmit
            // 
            grpSubmit.BackColor = System.Drawing.Color.White;
            grpSubmit.Controls.Add(btnClear);
            grpSubmit.Controls.Add(btnSubmit);
            grpSubmit.Controls.Add(txtContent);
            grpSubmit.Controls.Add(lblContent);
            grpSubmit.Controls.Add(cboRequestType);
            grpSubmit.Controls.Add(lblRequestType);
            grpSubmit.Dock = System.Windows.Forms.DockStyle.Left;
            grpSubmit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpSubmit.ForeColor = System.Drawing.Color.FromArgb(15, 76, 129);
            grpSubmit.Location = new System.Drawing.Point(20, 20);
            grpSubmit.Name = "grpSubmit";
            grpSubmit.Padding = new System.Windows.Forms.Padding(12);
            grpSubmit.Size = new System.Drawing.Size(350, 600);
            grpSubmit.TabIndex = 0;
            grpSubmit.TabStop = false;
            grpSubmit.Text = "Gửi yêu cầu mới";
            // 
            // lblRequestType
            // 
            lblRequestType.AutoSize = true;
            lblRequestType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRequestType.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblRequestType.Location = new System.Drawing.Point(16, 35);
            lblRequestType.Name = "lblRequestType";
            lblRequestType.Size = new System.Drawing.Size(97, 17);
            lblRequestType.TabIndex = 0;
            lblRequestType.Text = "Loại yêu cầu (*):";
            // 
            // cboRequestType
            // 
            cboRequestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboRequestType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboRequestType.FormattingEnabled = true;
            cboRequestType.Items.AddRange(new object[] { "Đăng ký phòng mới", "Chuyển phòng KTX", "Báo trả phòng / Rời KTX" });
            cboRequestType.Location = new System.Drawing.Point(16, 60);
            cboRequestType.Name = "cboRequestType";
            cboRequestType.Size = new System.Drawing.Size(315, 24);
            cboRequestType.TabIndex = 1;
            // 
            // lblContent
            // 
            lblContent.AutoSize = true;
            lblContent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblContent.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblContent.Location = new System.Drawing.Point(16, 105);
            lblContent.Name = "lblContent";
            lblContent.Size = new System.Drawing.Size(135, 17);
            lblContent.TabIndex = 2;
            lblContent.Text = "Nội dung chi tiết / Lý do:";
            // 
            // txtContent
            // 
            txtContent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtContent.Location = new System.Drawing.Point(16, 130);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.PlaceholderText = "Nhập nguyện vọng, lý do chuyển hoặc thời gian dự kiến rời ký túc xá...";
            txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtContent.Size = new System.Drawing.Size(315, 180);
            txtContent.TabIndex = 3;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = System.Drawing.Color.FromArgb(15, 76, 129);
            btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSubmit.ForeColor = System.Drawing.Color.White;
            btnSubmit.Location = new System.Drawing.Point(16, 330);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new System.Drawing.Size(315, 42);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Gửi yêu cầu tới Ban Quản lý";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnClear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnClear.Location = new System.Drawing.Point(16, 385);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(315, 34);
            btnClear.TabIndex = 5;
            btnClear.Text = "Xóa nội dung";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // grpHistory
            // 
            grpHistory.BackColor = System.Drawing.Color.White;
            grpHistory.Controls.Add(btnRefresh);
            grpHistory.Controls.Add(dgvMyRequests);
            grpHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            grpHistory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpHistory.ForeColor = System.Drawing.Color.FromArgb(15, 76, 129);
            grpHistory.Location = new System.Drawing.Point(370, 20);
            grpHistory.Name = "grpHistory";
            grpHistory.Padding = new System.Windows.Forms.Padding(12);
            grpHistory.Size = new System.Drawing.Size(620, 600);
            grpHistory.TabIndex = 1;
            grpHistory.TabStop = false;
            grpHistory.Text = "Lịch sử và tiến độ duyệt yêu cầu";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnRefresh.Location = new System.Drawing.Point(510, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(95, 26);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvMyRequests
            // 
            dgvMyRequests.AllowUserToAddRows = false;
            dgvMyRequests.AllowUserToDeleteRows = false;
            dgvMyRequests.BackgroundColor = System.Drawing.Color.White;
            dgvMyRequests.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvMyRequests.ColumnHeadersHeight = 36;
            dgvMyRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvMyRequests.EnableHeadersVisualStyles = false;
            dgvMyRequests.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvMyRequests.Location = new System.Drawing.Point(12, 32);
            dgvMyRequests.MultiSelect = false;
            dgvMyRequests.Name = "dgvMyRequests";
            dgvMyRequests.ReadOnly = true;
            dgvMyRequests.RowHeadersVisible = false;
            dgvMyRequests.RowTemplate.Height = 32;
            dgvMyRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvMyRequests.Size = new System.Drawing.Size(596, 556);
            dgvMyRequests.TabIndex = 0;
            // 
            // RequestForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 640);
            Controls.Add(grpHistory);
            Controls.Add(grpSubmit);
            Name = "RequestForm";
            Padding = new System.Windows.Forms.Padding(20);
            Text = "Gửi Yêu Cầu";
            Load += RequestForm_Load;
            grpSubmit.ResumeLayout(false);
            grpSubmit.PerformLayout();
            grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMyRequests).EndInit();
            ResumeLayout(false);
        }
    }
}
