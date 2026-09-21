namespace QuanLyKtx.Forms.Manager
{
    partial class PaymentManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilterMonth;
        private System.Windows.Forms.ComboBox cboFilterMonth;
        private System.Windows.Forms.Label lblFilterYear;
        private System.Windows.Forms.ComboBox cboFilterYear;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.ComboBox cboStudent;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.ComboBox cboContract;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblPaymentType;
        private System.Windows.Forms.ComboBox cboPaymentType;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnConfirmPaid;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvPayments;

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
            cboFilterYear = new System.Windows.Forms.ComboBox();
            lblFilterYear = new System.Windows.Forms.Label();
            cboFilterMonth = new System.Windows.Forms.ComboBox();
            lblFilterMonth = new System.Windows.Forms.Label();
            grpInfo = new System.Windows.Forms.GroupBox();
            btnClear = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            btnConfirmPaid = new System.Windows.Forms.Button();
            txtDescription = new System.Windows.Forms.TextBox();
            lblDescription = new System.Windows.Forms.Label();
            cboStatus = new System.Windows.Forms.ComboBox();
            lblStatus = new System.Windows.Forms.Label();
            cboPaymentType = new System.Windows.Forms.ComboBox();
            lblPaymentType = new System.Windows.Forms.Label();
            txtAmount = new System.Windows.Forms.TextBox();
            lblAmount = new System.Windows.Forms.Label();
            dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            lblPaymentDate = new System.Windows.Forms.Label();
            cboContract = new System.Windows.Forms.ComboBox();
            lblContract = new System.Windows.Forms.Label();
            cboStudent = new System.Windows.Forms.ComboBox();
            lblStudent = new System.Windows.Forms.Label();
            grpList = new System.Windows.Forms.GroupBox();
            dgvPayments = new System.Windows.Forms.DataGridView();
            pnlFilter.SuspendLayout();
            grpInfo.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
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
            pnlFilter.Controls.Add(cboFilterYear);
            pnlFilter.Controls.Add(lblFilterYear);
            pnlFilter.Controls.Add(cboFilterMonth);
            pnlFilter.Controls.Add(lblFilterMonth);
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
            btnRefresh.Location = new System.Drawing.Point(905, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(85, 30);
            btnRefresh.TabIndex = 8;
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
            btnSearch.Location = new System.Drawing.Point(815, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(85, 30);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtSearch.Location = new System.Drawing.Point(620, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã SV, họ tên hoặc mã phiếu...";
            txtSearch.Size = new System.Drawing.Size(185, 24);
            txtSearch.TabIndex = 6;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Items.AddRange(new object[] { "Tất cả", "Đã thanh toán (Paid)", "Chờ xử lý (Pending)", "Đã hủy (Cancelled)" });
            cboFilterStatus.Location = new System.Drawing.Point(465, 15);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.Size = new System.Drawing.Size(145, 24);
            cboFilterStatus.TabIndex = 5;
            cboFilterStatus.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblFilterStatus.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFilterStatus.Location = new System.Drawing.Point(390, 18);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new System.Drawing.Size(75, 17);
            lblFilterStatus.TabIndex = 4;
            lblFilterStatus.Text = "Trạng thái:";
            // 
            // cboFilterYear
            // 
            cboFilterYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterYear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterYear.FormattingEnabled = true;
            cboFilterYear.Items.AddRange(new object[] { "Tất cả", "2024", "2025", "2026", "2027" });
            cboFilterYear.Location = new System.Drawing.Point(280, 15);
            cboFilterYear.Name = "cboFilterYear";
            cboFilterYear.Size = new System.Drawing.Size(95, 24);
            cboFilterYear.TabIndex = 3;
            cboFilterYear.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // lblFilterYear
            // 
            lblFilterYear.AutoSize = true;
            lblFilterYear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblFilterYear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFilterYear.Location = new System.Drawing.Point(235, 18);
            lblFilterYear.Name = "lblFilterYear";
            lblFilterYear.Size = new System.Drawing.Size(41, 17);
            lblFilterYear.TabIndex = 2;
            lblFilterYear.Text = "Năm:";
            // 
            // cboFilterMonth
            // 
            cboFilterMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterMonth.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterMonth.FormattingEnabled = true;
            cboFilterMonth.Items.AddRange(new object[] { "Tất cả", "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" });
            cboFilterMonth.Location = new System.Drawing.Point(95, 15);
            cboFilterMonth.Name = "cboFilterMonth";
            cboFilterMonth.Size = new System.Drawing.Size(125, 24);
            cboFilterMonth.TabIndex = 1;
            cboFilterMonth.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // lblFilterMonth
            // 
            lblFilterMonth.AutoSize = true;
            lblFilterMonth.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblFilterMonth.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFilterMonth.Location = new System.Drawing.Point(20, 18);
            lblFilterMonth.Name = "lblFilterMonth";
            lblFilterMonth.Size = new System.Drawing.Size(51, 17);
            lblFilterMonth.TabIndex = 0;
            lblFilterMonth.Text = "Tháng:";
            // 
            // grpInfo
            // 
            grpInfo.BackColor = System.Drawing.Color.White;
            grpInfo.Controls.Add(btnClear);
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnEdit);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(btnConfirmPaid);
            grpInfo.Controls.Add(txtDescription);
            grpInfo.Controls.Add(lblDescription);
            grpInfo.Controls.Add(cboStatus);
            grpInfo.Controls.Add(lblStatus);
            grpInfo.Controls.Add(cboPaymentType);
            grpInfo.Controls.Add(lblPaymentType);
            grpInfo.Controls.Add(txtAmount);
            grpInfo.Controls.Add(lblAmount);
            grpInfo.Controls.Add(dtpPaymentDate);
            grpInfo.Controls.Add(lblPaymentDate);
            grpInfo.Controls.Add(cboContract);
            grpInfo.Controls.Add(lblContract);
            grpInfo.Controls.Add(cboStudent);
            grpInfo.Controls.Add(lblStudent);
            grpInfo.Dock = System.Windows.Forms.DockStyle.Left;
            grpInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpInfo.Location = new System.Drawing.Point(0, 56);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new System.Windows.Forms.Padding(12);
            grpInfo.Size = new System.Drawing.Size(340, 645);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin phiếu thu";
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
            btnClear.TabIndex = 17;
            btnClear.Text = "Xóa trắng";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnConfirmPaid
            // 
            btnConfirmPaid.BackColor = System.Drawing.Color.FromArgb(200, 210, 200);
            btnConfirmPaid.Cursor = System.Windows.Forms.Cursors.Hand;
            btnConfirmPaid.Enabled = false;
            btnConfirmPaid.FlatAppearance.BorderSize = 0;
            btnConfirmPaid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnConfirmPaid.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnConfirmPaid.ForeColor = System.Drawing.Color.White;
            btnConfirmPaid.Location = new System.Drawing.Point(20, 590);
            btnConfirmPaid.Name = "btnConfirmPaid";
            btnConfirmPaid.Size = new System.Drawing.Size(300, 36);
            btnConfirmPaid.TabIndex = 18;
            btnConfirmPaid.Text = "✔  Duyệt xác nhận thanh toán (Pending → Paid)";
            btnConfirmPaid.UseVisualStyleBackColor = false;
            btnConfirmPaid.Click += btnConfirmPaid_Click;
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
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Xóa phiếu";
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
            btnEdit.Location = new System.Drawing.Point(175, 500);
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
            btnAdd.Location = new System.Drawing.Point(20, 500);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(145, 36);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Lập phiếu thu";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtDescription
            // 
            txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtDescription.Location = new System.Drawing.Point(20, 420);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Ghi chú nội dung thanh toán...";
            txtDescription.Size = new System.Drawing.Size(300, 65);
            txtDescription.TabIndex = 13;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblDescription.Location = new System.Drawing.Point(20, 398);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(64, 17);
            lblDescription.TabIndex = 12;
            lblDescription.Text = "Nội dung:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Đã thanh toán (Paid)", "Chờ xử lý (Pending)", "Đã hủy (Cancelled)" });
            cboStatus.Location = new System.Drawing.Point(20, 360);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new System.Drawing.Size(300, 24);
            cboStatus.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStatus.Location = new System.Drawing.Point(20, 338);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(69, 17);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Trạng thái:";
            // 
            // cboPaymentType
            // 
            cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboPaymentType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboPaymentType.FormattingEnabled = true;
            cboPaymentType.Items.AddRange(new object[] { "Tiền phòng", "Tiền điện nước", "Tiền đặt cọc", "Tiền phạt vi phạm", "Khác" });
            cboPaymentType.Location = new System.Drawing.Point(20, 300);
            cboPaymentType.Name = "cboPaymentType";
            cboPaymentType.Size = new System.Drawing.Size(300, 24);
            cboPaymentType.TabIndex = 9;
            // 
            // lblPaymentType
            // 
            lblPaymentType.AutoSize = true;
            lblPaymentType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblPaymentType.Location = new System.Drawing.Point(20, 278);
            lblPaymentType.Name = "lblPaymentType";
            lblPaymentType.Size = new System.Drawing.Size(95, 17);
            lblPaymentType.TabIndex = 8;
            lblPaymentType.Text = "Khoản thu nộp:";
            // 
            // txtAmount
            // 
            txtAmount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtAmount.Location = new System.Drawing.Point(20, 240);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderText = "Ví dụ: 600000";
            txtAmount.Size = new System.Drawing.Size(300, 24);
            txtAmount.TabIndex = 7;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblAmount.Location = new System.Drawing.Point(20, 218);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new System.Drawing.Size(107, 17);
            lblAmount.TabIndex = 6;
            lblAmount.Text = "Số tiền thu (đ) *:";
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.CustomFormat = "dd/MM/yyyy";
            dtpPaymentDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpPaymentDate.Location = new System.Drawing.Point(20, 180);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new System.Drawing.Size(300, 24);
            dtpPaymentDate.TabIndex = 5;
            // 
            // lblPaymentDate
            // 
            lblPaymentDate.AutoSize = true;
            lblPaymentDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblPaymentDate.Location = new System.Drawing.Point(20, 158);
            lblPaymentDate.Name = "lblPaymentDate";
            lblPaymentDate.Size = new System.Drawing.Size(81, 17);
            lblPaymentDate.TabIndex = 4;
            lblPaymentDate.Text = "Ngày nộp *:";
            // 
            // cboContract
            // 
            cboContract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboContract.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboContract.FormattingEnabled = true;
            cboContract.Location = new System.Drawing.Point(20, 115);
            cboContract.Name = "cboContract";
            cboContract.Size = new System.Drawing.Size(300, 24);
            cboContract.TabIndex = 3;
            // 
            // lblContract
            // 
            lblContract.AutoSize = true;
            lblContract.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblContract.Location = new System.Drawing.Point(20, 93);
            lblContract.Name = "lblContract";
            lblContract.Size = new System.Drawing.Size(147, 17);
            lblContract.TabIndex = 2;
            lblContract.Text = "Hợp đồng (nếu có thu):";
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
            grpList.Controls.Add(dgvPayments);
            grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            grpList.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpList.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpList.Location = new System.Drawing.Point(340, 56);
            grpList.Name = "grpList";
            grpList.Padding = new System.Windows.Forms.Padding(10);
            grpList.Size = new System.Drawing.Size(670, 634);
            grpList.TabIndex = 2;
            grpList.TabStop = false;
            grpList.Text = "Danh sách hóa đơn & phiếu thu";
            // 
            // dgvPayments
            // 
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.BackgroundColor = System.Drawing.Color.White;
            dgvPayments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvPayments.ColumnHeadersHeight = 36;
            dgvPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvPayments.EnableHeadersVisualStyles = false;
            dgvPayments.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvPayments.Location = new System.Drawing.Point(10, 29);
            dgvPayments.MultiSelect = false;
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.RowTemplate.Height = 32;
            dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.Size = new System.Drawing.Size(650, 595);
            dgvPayments.TabIndex = 0;
            dgvPayments.CellClick += dgvPayments_CellClick;
            // 
            // PaymentManagementForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 690);
            Controls.Add(grpList);
            Controls.Add(grpInfo);
            Controls.Add(pnlFilter);
            Name = "PaymentManagementForm";
            Text = "Quản lý Thanh toán";
            Load += PaymentManagementForm_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            ResumeLayout(false);
        }
    }
}
