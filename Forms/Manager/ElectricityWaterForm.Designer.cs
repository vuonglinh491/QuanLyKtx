namespace QuanLyKtx.Forms.Manager
{
    partial class ElectricityWaterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilterMonth;
        private System.Windows.Forms.ComboBox cboFilterMonth;
        private System.Windows.Forms.Label lblFilterYear;
        private System.Windows.Forms.ComboBox cboFilterYear;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cboRoom;
        private System.Windows.Forms.Label lblMonthYear;
        private System.Windows.Forms.NumericUpDown nudMonth;
        private System.Windows.Forms.NumericUpDown nudYear;
        private System.Windows.Forms.Label lblOldElectric;
        private System.Windows.Forms.TextBox txtOldElectric;
        private System.Windows.Forms.Label lblNewElectric;
        private System.Windows.Forms.TextBox txtNewElectric;
        private System.Windows.Forms.Label lblOldWater;
        private System.Windows.Forms.TextBox txtOldWater;
        private System.Windows.Forms.Label lblNewWater;
        private System.Windows.Forms.TextBox txtNewWater;
        private System.Windows.Forms.Label lblPreviewTotal;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvElecWater;

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
            cboFilterYear = new System.Windows.Forms.ComboBox();
            lblFilterYear = new System.Windows.Forms.Label();
            cboFilterMonth = new System.Windows.Forms.ComboBox();
            lblFilterMonth = new System.Windows.Forms.Label();
            grpInfo = new System.Windows.Forms.GroupBox();
            btnClear = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            lblPreviewTotal = new System.Windows.Forms.Label();
            txtNewWater = new System.Windows.Forms.TextBox();
            lblNewWater = new System.Windows.Forms.Label();
            txtOldWater = new System.Windows.Forms.TextBox();
            lblOldWater = new System.Windows.Forms.Label();
            txtNewElectric = new System.Windows.Forms.TextBox();
            lblNewElectric = new System.Windows.Forms.Label();
            txtOldElectric = new System.Windows.Forms.TextBox();
            lblOldElectric = new System.Windows.Forms.Label();
            nudYear = new System.Windows.Forms.NumericUpDown();
            nudMonth = new System.Windows.Forms.NumericUpDown();
            lblMonthYear = new System.Windows.Forms.Label();
            cboRoom = new System.Windows.Forms.ComboBox();
            lblRoom = new System.Windows.Forms.Label();
            grpList = new System.Windows.Forms.GroupBox();
            dgvElecWater = new System.Windows.Forms.DataGridView();
            pnlFilter.SuspendLayout();
            grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMonth).BeginInit();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvElecWater).BeginInit();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = System.Drawing.Color.White;
            pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlFilter.Controls.Add(btnRefresh);
            pnlFilter.Controls.Add(btnSearch);
            pnlFilter.Controls.Add(txtSearch);
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
            btnRefresh.Location = new System.Drawing.Point(765, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(95, 30);
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
            btnSearch.Location = new System.Drawing.Point(660, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(95, 30);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtSearch.Location = new System.Drawing.Point(430, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập số phòng (vd: A101)...";
            txtSearch.Size = new System.Drawing.Size(220, 24);
            txtSearch.TabIndex = 4;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // cboFilterYear
            // 
            cboFilterYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterYear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterYear.FormattingEnabled = true;
            cboFilterYear.Items.AddRange(new object[] { "Tất cả", "2024", "2025", "2026", "2027" });
            cboFilterYear.Location = new System.Drawing.Point(295, 15);
            cboFilterYear.Name = "cboFilterYear";
            cboFilterYear.Size = new System.Drawing.Size(115, 24);
            cboFilterYear.TabIndex = 3;
            cboFilterYear.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // lblFilterYear
            // 
            lblFilterYear.AutoSize = true;
            lblFilterYear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblFilterYear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFilterYear.Location = new System.Drawing.Point(250, 18);
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
            cboFilterMonth.Size = new System.Drawing.Size(135, 24);
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
            grpInfo.Controls.Add(lblPreviewTotal);
            grpInfo.Controls.Add(txtNewWater);
            grpInfo.Controls.Add(lblNewWater);
            grpInfo.Controls.Add(txtOldWater);
            grpInfo.Controls.Add(lblOldWater);
            grpInfo.Controls.Add(txtNewElectric);
            grpInfo.Controls.Add(lblNewElectric);
            grpInfo.Controls.Add(txtOldElectric);
            grpInfo.Controls.Add(lblOldElectric);
            grpInfo.Controls.Add(nudYear);
            grpInfo.Controls.Add(nudMonth);
            grpInfo.Controls.Add(lblMonthYear);
            grpInfo.Controls.Add(cboRoom);
            grpInfo.Controls.Add(lblRoom);
            grpInfo.Dock = System.Windows.Forms.DockStyle.Left;
            grpInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpInfo.Location = new System.Drawing.Point(0, 56);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new System.Windows.Forms.Padding(12);
            grpInfo.Size = new System.Drawing.Size(340, 634);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Chỉ số điện nước";
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
            btnDelete.Text = "Xóa bản ghi";
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
            btnAdd.Text = "Lưu chỉ số";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblPreviewTotal
            // 
            lblPreviewTotal.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            lblPreviewTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblPreviewTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblPreviewTotal.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblPreviewTotal.Location = new System.Drawing.Point(20, 395);
            lblPreviewTotal.Name = "lblPreviewTotal";
            lblPreviewTotal.Padding = new System.Windows.Forms.Padding(8);
            lblPreviewTotal.Size = new System.Drawing.Size(300, 90);
            lblPreviewTotal.TabIndex = 13;
            lblPreviewTotal.Text = "TẠM TÍNH:\r\n• Điện tiêu thụ: 0 kWh = 0 đ\r\n• Nước tiêu thụ: 0 m³ = 0 đ\r\n• TỔNG TIỀN: 0 đ";
            // 
            // txtNewWater
            // 
            txtNewWater.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtNewWater.Location = new System.Drawing.Point(20, 355);
            txtNewWater.Name = "txtNewWater";
            txtNewWater.PlaceholderText = "Nhập chỉ số nước mới";
            txtNewWater.Size = new System.Drawing.Size(300, 24);
            txtNewWater.TabIndex = 12;
            txtNewWater.TextChanged += txtIndices_TextChanged;
            // 
            // lblNewWater
            // 
            lblNewWater.AutoSize = true;
            lblNewWater.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblNewWater.Location = new System.Drawing.Point(20, 333);
            lblNewWater.Name = "lblNewWater";
            lblNewWater.Size = new System.Drawing.Size(126, 17);
            lblNewWater.TabIndex = 11;
            lblNewWater.Text = "Chỉ số nước mới (m³):";
            // 
            // txtOldWater
            // 
            txtOldWater.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtOldWater.Location = new System.Drawing.Point(20, 295);
            txtOldWater.Name = "txtOldWater";
            txtOldWater.PlaceholderText = "Nhập chỉ số nước cũ";
            txtOldWater.Size = new System.Drawing.Size(300, 24);
            txtOldWater.TabIndex = 10;
            txtOldWater.TextChanged += txtIndices_TextChanged;
            // 
            // lblOldWater
            // 
            lblOldWater.AutoSize = true;
            lblOldWater.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblOldWater.Location = new System.Drawing.Point(20, 273);
            lblOldWater.Name = "lblOldWater";
            lblOldWater.Size = new System.Drawing.Size(120, 17);
            lblOldWater.TabIndex = 9;
            lblOldWater.Text = "Chỉ số nước cũ (m³):";
            // 
            // txtNewElectric
            // 
            txtNewElectric.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtNewElectric.Location = new System.Drawing.Point(20, 235);
            txtNewElectric.Name = "txtNewElectric";
            txtNewElectric.PlaceholderText = "Nhập chỉ số điện mới";
            txtNewElectric.Size = new System.Drawing.Size(300, 24);
            txtNewElectric.TabIndex = 8;
            txtNewElectric.TextChanged += txtIndices_TextChanged;
            // 
            // lblNewElectric
            // 
            lblNewElectric.AutoSize = true;
            lblNewElectric.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblNewElectric.Location = new System.Drawing.Point(20, 213);
            lblNewElectric.Name = "lblNewElectric";
            lblNewElectric.Size = new System.Drawing.Size(133, 17);
            lblNewElectric.TabIndex = 7;
            lblNewElectric.Text = "Chỉ số điện mới (kWh):";
            // 
            // txtOldElectric
            // 
            txtOldElectric.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtOldElectric.Location = new System.Drawing.Point(20, 175);
            txtOldElectric.Name = "txtOldElectric";
            txtOldElectric.PlaceholderText = "Nhập chỉ số điện cũ";
            txtOldElectric.Size = new System.Drawing.Size(300, 24);
            txtOldElectric.TabIndex = 6;
            txtOldElectric.TextChanged += txtIndices_TextChanged;
            // 
            // lblOldElectric
            // 
            lblOldElectric.AutoSize = true;
            lblOldElectric.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblOldElectric.Location = new System.Drawing.Point(20, 153);
            lblOldElectric.Name = "lblOldElectric";
            lblOldElectric.Size = new System.Drawing.Size(127, 17);
            lblOldElectric.TabIndex = 5;
            lblOldElectric.Text = "Chỉ số điện cũ (kWh):";
            // 
            // nudYear
            // 
            nudYear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            nudYear.Location = new System.Drawing.Point(180, 110);
            nudYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 2000, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.Size = new System.Drawing.Size(140, 24);
            nudYear.TabIndex = 4;
            nudYear.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // nudMonth
            // 
            nudMonth.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            nudMonth.Location = new System.Drawing.Point(20, 110);
            nudMonth.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nudMonth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMonth.Name = "nudMonth";
            nudMonth.Size = new System.Drawing.Size(140, 24);
            nudMonth.TabIndex = 3;
            nudMonth.Value = new decimal(new int[] { 9, 0, 0, 0 });
            // 
            // lblMonthYear
            // 
            lblMonthYear.AutoSize = true;
            lblMonthYear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblMonthYear.Location = new System.Drawing.Point(20, 88);
            lblMonthYear.Name = "lblMonthYear";
            lblMonthYear.Size = new System.Drawing.Size(144, 17);
            lblMonthYear.TabIndex = 2;
            lblMonthYear.Text = "Kỳ thu (Tháng / Năm) *:";
            // 
            // cboRoom
            // 
            cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboRoom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboRoom.FormattingEnabled = true;
            cboRoom.Location = new System.Drawing.Point(20, 50);
            cboRoom.Name = "cboRoom";
            cboRoom.Size = new System.Drawing.Size(300, 24);
            cboRoom.TabIndex = 1;
            cboRoom.SelectedIndexChanged += cboRoom_SelectedIndexChanged;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRoom.Location = new System.Drawing.Point(20, 28);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new System.Drawing.Size(89, 17);
            lblRoom.TabIndex = 0;
            lblRoom.Text = "Chọn phòng *:";
            // 
            // grpList
            // 
            grpList.BackColor = System.Drawing.Color.White;
            grpList.Controls.Add(dgvElecWater);
            grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            grpList.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpList.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpList.Location = new System.Drawing.Point(340, 56);
            grpList.Name = "grpList";
            grpList.Padding = new System.Windows.Forms.Padding(10);
            grpList.Size = new System.Drawing.Size(670, 634);
            grpList.TabIndex = 2;
            grpList.TabStop = false;
            grpList.Text = "Bảng kê chỉ số & tiền điện nước";
            // 
            // dgvElecWater
            // 
            dgvElecWater.AllowUserToAddRows = false;
            dgvElecWater.AllowUserToDeleteRows = false;
            dgvElecWater.BackgroundColor = System.Drawing.Color.White;
            dgvElecWater.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvElecWater.ColumnHeadersHeight = 36;
            dgvElecWater.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvElecWater.EnableHeadersVisualStyles = false;
            dgvElecWater.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvElecWater.Location = new System.Drawing.Point(10, 29);
            dgvElecWater.MultiSelect = false;
            dgvElecWater.Name = "dgvElecWater";
            dgvElecWater.ReadOnly = true;
            dgvElecWater.RowHeadersVisible = false;
            dgvElecWater.RowTemplate.Height = 32;
            dgvElecWater.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvElecWater.Size = new System.Drawing.Size(650, 595);
            dgvElecWater.TabIndex = 0;
            dgvElecWater.CellClick += dgvElecWater_CellClick;
            // 
            // ElectricityWaterForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 690);
            Controls.Add(grpList);
            Controls.Add(grpInfo);
            Controls.Add(pnlFilter);
            Name = "ElectricityWaterForm";
            Text = "Quản lý Điện nước";
            Load += ElectricityWaterForm_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMonth).EndInit();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvElecWater).EndInit();
            ResumeLayout(false);
        }
    }
}
