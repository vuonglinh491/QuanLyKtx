namespace QuanLyKtx.Forms.Manager
{
    partial class ContractManagementForm
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
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cboRoom;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblMonthlyFee;
        private System.Windows.Forms.TextBox txtMonthlyFee;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnTerminate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvContracts;

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
            btnTerminate = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            cboStatus = new System.Windows.Forms.ComboBox();
            lblStatus = new System.Windows.Forms.Label();
            txtDeposit = new System.Windows.Forms.TextBox();
            lblDeposit = new System.Windows.Forms.Label();
            txtMonthlyFee = new System.Windows.Forms.TextBox();
            lblMonthlyFee = new System.Windows.Forms.Label();
            dtpEndDate = new System.Windows.Forms.DateTimePicker();
            lblEndDate = new System.Windows.Forms.Label();
            dtpStartDate = new System.Windows.Forms.DateTimePicker();
            lblStartDate = new System.Windows.Forms.Label();
            cboRoom = new System.Windows.Forms.ComboBox();
            lblRoom = new System.Windows.Forms.Label();
            cboStudent = new System.Windows.Forms.ComboBox();
            lblStudent = new System.Windows.Forms.Label();
            grpList = new System.Windows.Forms.GroupBox();
            dgvContracts = new System.Windows.Forms.DataGridView();
            pnlFilter.SuspendLayout();
            grpInfo.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContracts).BeginInit();
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
            txtSearch.PlaceholderText = "Nhập mã HĐ, mã SV hoặc họ tên...";
            txtSearch.Size = new System.Drawing.Size(300, 24);
            txtSearch.TabIndex = 2;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Đang hiệu lực (Active)", "Hết hạn (Expired)", "Đã thanh lý (Terminated)" });
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
            // grpInfo
            // 
            grpInfo.BackColor = System.Drawing.Color.White;
            grpInfo.Controls.Add(btnClear);
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnTerminate);
            grpInfo.Controls.Add(btnEdit);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(cboStatus);
            grpInfo.Controls.Add(lblStatus);
            grpInfo.Controls.Add(txtDeposit);
            grpInfo.Controls.Add(lblDeposit);
            grpInfo.Controls.Add(txtMonthlyFee);
            grpInfo.Controls.Add(lblMonthlyFee);
            grpInfo.Controls.Add(dtpEndDate);
            grpInfo.Controls.Add(lblEndDate);
            grpInfo.Controls.Add(dtpStartDate);
            grpInfo.Controls.Add(lblStartDate);
            grpInfo.Controls.Add(cboRoom);
            grpInfo.Controls.Add(lblRoom);
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
            grpInfo.Text = "Thông tin hợp đồng";
            // 
            // btnClear
            // 
            btnClear.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnClear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnClear.Location = new System.Drawing.Point(175, 545);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(145, 36);
            btnClear.TabIndex = 18;
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
            btnDelete.Location = new System.Drawing.Point(20, 545);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(145, 36);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Xóa HĐ";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnTerminate
            // 
            btnTerminate.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            btnTerminate.Cursor = System.Windows.Forms.Cursors.Hand;
            btnTerminate.FlatAppearance.BorderSize = 0;
            btnTerminate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTerminate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnTerminate.ForeColor = System.Drawing.Color.White;
            btnTerminate.Location = new System.Drawing.Point(20, 500);
            btnTerminate.Name = "btnTerminate";
            btnTerminate.Size = new System.Drawing.Size(300, 36);
            btnTerminate.TabIndex = 16;
            btnTerminate.Text = "THANH LÝ HỢP ĐỒNG";
            btnTerminate.UseVisualStyleBackColor = false;
            btnTerminate.Click += btnTerminate_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnEdit.ForeColor = System.Drawing.Color.White;
            btnEdit.Location = new System.Drawing.Point(175, 455);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(145, 36);
            btnEdit.TabIndex = 15;
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
            btnAdd.Location = new System.Drawing.Point(20, 455);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(145, 36);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Tạo hợp đồng";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Đang hiệu lực (Active)", "Hết hạn (Expired)", "Đã thanh lý (Terminated)" });
            cboStatus.Location = new System.Drawing.Point(20, 405);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new System.Drawing.Size(300, 24);
            cboStatus.TabIndex = 13;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStatus.Location = new System.Drawing.Point(20, 383);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(69, 17);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Trạng thái:";
            // 
            // txtDeposit
            // 
            txtDeposit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtDeposit.Location = new System.Drawing.Point(20, 345);
            txtDeposit.Name = "txtDeposit";
            txtDeposit.PlaceholderText = "Ví dụ: 600000";
            txtDeposit.Size = new System.Drawing.Size(300, 24);
            txtDeposit.TabIndex = 11;
            // 
            // lblDeposit
            // 
            lblDeposit.AutoSize = true;
            lblDeposit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblDeposit.Location = new System.Drawing.Point(20, 323);
            lblDeposit.Name = "lblDeposit";
            lblDeposit.Size = new System.Drawing.Size(107, 17);
            lblDeposit.TabIndex = 10;
            lblDeposit.Text = "Tiền đặt cọc (đ):";
            // 
            // txtMonthlyFee
            // 
            txtMonthlyFee.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtMonthlyFee.Location = new System.Drawing.Point(20, 285);
            txtMonthlyFee.Name = "txtMonthlyFee";
            txtMonthlyFee.PlaceholderText = "Ví dụ: 600000";
            txtMonthlyFee.Size = new System.Drawing.Size(300, 24);
            txtMonthlyFee.TabIndex = 9;
            // 
            // lblMonthlyFee
            // 
            lblMonthlyFee.AutoSize = true;
            lblMonthlyFee.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblMonthlyFee.Location = new System.Drawing.Point(20, 263);
            lblMonthlyFee.Name = "lblMonthlyFee";
            lblMonthlyFee.Size = new System.Drawing.Size(130, 17);
            lblMonthlyFee.TabIndex = 8;
            lblMonthlyFee.Text = "Tiền phòng/tháng (đ):";
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "dd/MM/yyyy";
            dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpEndDate.Location = new System.Drawing.Point(20, 225);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new System.Drawing.Size(300, 24);
            dtpEndDate.TabIndex = 7;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblEndDate.Location = new System.Drawing.Point(20, 203);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new System.Drawing.Size(99, 17);
            lblEndDate.TabIndex = 6;
            lblEndDate.Text = "Ngày kết thúc *:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "dd/MM/yyyy";
            dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpStartDate.Location = new System.Drawing.Point(20, 165);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new System.Drawing.Size(300, 24);
            dtpStartDate.TabIndex = 5;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStartDate.Location = new System.Drawing.Point(20, 143);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new System.Drawing.Size(97, 17);
            lblStartDate.TabIndex = 4;
            lblStartDate.Text = "Ngày bắt đầu *:";
            // 
            // cboRoom
            // 
            cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboRoom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboRoom.FormattingEnabled = true;
            cboRoom.Location = new System.Drawing.Point(20, 105);
            cboRoom.Name = "cboRoom";
            cboRoom.Size = new System.Drawing.Size(300, 24);
            cboRoom.TabIndex = 3;
            cboRoom.SelectedIndexChanged += cboRoom_SelectedIndexChanged;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRoom.Location = new System.Drawing.Point(20, 83);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new System.Drawing.Size(89, 17);
            lblRoom.TabIndex = 2;
            lblRoom.Text = "Chọn phòng *:";
            // 
            // cboStudent
            // 
            cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboStudent.FormattingEnabled = true;
            cboStudent.Location = new System.Drawing.Point(20, 50);
            cboStudent.Name = "cboStudent";
            cboStudent.Size = new System.Drawing.Size(300, 24);
            cboStudent.TabIndex = 1;
            // 
            // lblStudent
            // 
            lblStudent.AutoSize = true;
            lblStudent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStudent.Location = new System.Drawing.Point(20, 28);
            lblStudent.Name = "lblStudent";
            lblStudent.Size = new System.Drawing.Size(103, 17);
            lblStudent.TabIndex = 0;
            lblStudent.Text = "Chọn sinh viên *:";
            // 
            // grpList
            // 
            grpList.BackColor = System.Drawing.Color.White;
            grpList.Controls.Add(dgvContracts);
            grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            grpList.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpList.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpList.Location = new System.Drawing.Point(340, 56);
            grpList.Name = "grpList";
            grpList.Padding = new System.Windows.Forms.Padding(10);
            grpList.Size = new System.Drawing.Size(670, 634);
            grpList.TabIndex = 2;
            grpList.TabStop = false;
            grpList.Text = "Danh sách hợp đồng KTX";
            // 
            // dgvContracts
            // 
            dgvContracts.AllowUserToAddRows = false;
            dgvContracts.AllowUserToDeleteRows = false;
            dgvContracts.BackgroundColor = System.Drawing.Color.White;
            dgvContracts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvContracts.ColumnHeadersHeight = 36;
            dgvContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvContracts.EnableHeadersVisualStyles = false;
            dgvContracts.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvContracts.Location = new System.Drawing.Point(10, 29);
            dgvContracts.MultiSelect = false;
            dgvContracts.Name = "dgvContracts";
            dgvContracts.ReadOnly = true;
            dgvContracts.RowHeadersVisible = false;
            dgvContracts.RowTemplate.Height = 32;
            dgvContracts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvContracts.Size = new System.Drawing.Size(650, 595);
            dgvContracts.TabIndex = 0;
            dgvContracts.CellClick += dgvContracts_CellClick;
            // 
            // ContractManagementForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 690);
            Controls.Add(grpList);
            Controls.Add(grpInfo);
            Controls.Add(pnlFilter);
            Name = "ContractManagementForm";
            Text = "Quản lý Hợp đồng";
            Load += ContractManagementForm_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvContracts).EndInit();
            ResumeLayout(false);
        }
    }
}
