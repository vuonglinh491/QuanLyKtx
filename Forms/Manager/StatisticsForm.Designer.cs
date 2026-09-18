namespace QuanLyKtx.Forms.Manager
{
    partial class StatisticsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExportCsv;

        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel pnlCardTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenueTitle;
        private System.Windows.Forms.Label lblTotalRevenueValue;
        private System.Windows.Forms.Panel pnlCardRoomRevenue;
        private System.Windows.Forms.Label lblRoomRevenueTitle;
        private System.Windows.Forms.Label lblRoomRevenueValue;
        private System.Windows.Forms.Panel pnlCardUtilityRevenue;
        private System.Windows.Forms.Label lblUtilityRevenueTitle;
        private System.Windows.Forms.Label lblUtilityRevenueValue;
        private System.Windows.Forms.Panel pnlCardOccupancy;
        private System.Windows.Forms.Label lblOccupancyTitle;
        private System.Windows.Forms.Label lblOccupancyValue;

        private System.Windows.Forms.TabControl tabStatistics;
        private System.Windows.Forms.TabPage tabRevenue;
        private System.Windows.Forms.DataGridView dgvRevenue;
        private System.Windows.Forms.TabPage tabOccupancy;
        private System.Windows.Forms.DataGridView dgvOccupancy;
        private System.Windows.Forms.TabPage tabViolations;
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
            btnExportCsv = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();
            cboYear = new System.Windows.Forms.ComboBox();
            lblYear = new System.Windows.Forms.Label();

            pnlCards = new System.Windows.Forms.Panel();
            pnlCardOccupancy = new System.Windows.Forms.Panel();
            lblOccupancyValue = new System.Windows.Forms.Label();
            lblOccupancyTitle = new System.Windows.Forms.Label();
            pnlCardUtilityRevenue = new System.Windows.Forms.Panel();
            lblUtilityRevenueValue = new System.Windows.Forms.Label();
            lblUtilityRevenueTitle = new System.Windows.Forms.Label();
            pnlCardRoomRevenue = new System.Windows.Forms.Panel();
            lblRoomRevenueValue = new System.Windows.Forms.Label();
            lblRoomRevenueTitle = new System.Windows.Forms.Label();
            pnlCardTotalRevenue = new System.Windows.Forms.Panel();
            lblTotalRevenueValue = new System.Windows.Forms.Label();
            lblTotalRevenueTitle = new System.Windows.Forms.Label();

            tabStatistics = new System.Windows.Forms.TabControl();
            tabRevenue = new System.Windows.Forms.TabPage();
            dgvRevenue = new System.Windows.Forms.DataGridView();
            tabOccupancy = new System.Windows.Forms.TabPage();
            dgvOccupancy = new System.Windows.Forms.DataGridView();
            tabViolations = new System.Windows.Forms.TabPage();
            dgvViolations = new System.Windows.Forms.DataGridView();

            pnlFilter.SuspendLayout();
            pnlCards.SuspendLayout();
            pnlCardOccupancy.SuspendLayout();
            pnlCardUtilityRevenue.SuspendLayout();
            pnlCardRoomRevenue.SuspendLayout();
            pnlCardTotalRevenue.SuspendLayout();
            tabStatistics.SuspendLayout();
            tabRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).BeginInit();
            tabOccupancy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOccupancy).BeginInit();
            tabViolations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvViolations).BeginInit();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = System.Drawing.Color.White;
            pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlFilter.Controls.Add(btnExportCsv);
            pnlFilter.Controls.Add(btnRefresh);
            pnlFilter.Controls.Add(cboYear);
            pnlFilter.Controls.Add(lblYear);
            pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFilter.Location = new System.Drawing.Point(0, 0);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new System.Drawing.Size(1010, 56);
            pnlFilter.TabIndex = 0;
            // 
            // btnExportCsv
            // 
            btnExportCsv.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            btnExportCsv.Cursor = System.Windows.Forms.Cursors.Hand;
            btnExportCsv.FlatAppearance.BorderSize = 0;
            btnExportCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExportCsv.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnExportCsv.ForeColor = System.Drawing.Color.White;
            btnExportCsv.Location = new System.Drawing.Point(860, 12);
            btnExportCsv.Name = "btnExportCsv";
            btnExportCsv.Size = new System.Drawing.Size(130, 32);
            btnExportCsv.TabIndex = 3;
            btnExportCsv.Text = "Xuất file CSV";
            btnExportCsv.UseVisualStyleBackColor = false;
            btnExportCsv.Click += btnExportCsv_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(24, 119, 242);
            btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.Location = new System.Drawing.Point(235, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(110, 32);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Xem báo cáo";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // cboYear
            // 
            cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboYear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboYear.FormattingEnabled = true;
            cboYear.Location = new System.Drawing.Point(95, 16);
            cboYear.Name = "cboYear";
            cboYear.Size = new System.Drawing.Size(120, 24);
            cboYear.TabIndex = 1;
            cboYear.SelectedIndexChanged += cboYear_SelectedIndexChanged;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblYear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblYear.Location = new System.Drawing.Point(18, 19);
            lblYear.Name = "lblYear";
            lblYear.Size = new System.Drawing.Size(71, 17);
            lblYear.TabIndex = 0;
            lblYear.Text = "Năm xem:";
            // 
            // pnlCards
            // 
            pnlCards.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            pnlCards.Controls.Add(pnlCardOccupancy);
            pnlCards.Controls.Add(pnlCardUtilityRevenue);
            pnlCards.Controls.Add(pnlCardRoomRevenue);
            pnlCards.Controls.Add(pnlCardTotalRevenue);
            pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            pnlCards.Location = new System.Drawing.Point(0, 56);
            pnlCards.Name = "pnlCards";
            pnlCards.Size = new System.Drawing.Size(1010, 100);
            pnlCards.TabIndex = 1;
            // 
            // pnlCardOccupancy
            // 
            pnlCardOccupancy.BackColor = System.Drawing.Color.White;
            pnlCardOccupancy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlCardOccupancy.Controls.Add(lblOccupancyValue);
            pnlCardOccupancy.Controls.Add(lblOccupancyTitle);
            pnlCardOccupancy.Location = new System.Drawing.Point(765, 12);
            pnlCardOccupancy.Name = "pnlCardOccupancy";
            pnlCardOccupancy.Size = new System.Drawing.Size(225, 76);
            pnlCardOccupancy.TabIndex = 3;
            // 
            // lblOccupancyValue
            // 
            lblOccupancyValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblOccupancyValue.ForeColor = System.Drawing.Color.FromArgb(139, 92, 246);
            lblOccupancyValue.Location = new System.Drawing.Point(10, 36);
            lblOccupancyValue.Name = "lblOccupancyValue";
            lblOccupancyValue.Size = new System.Drawing.Size(203, 26);
            lblOccupancyValue.TabIndex = 1;
            lblOccupancyValue.Text = "0%";
            lblOccupancyValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOccupancyTitle
            // 
            lblOccupancyTitle.AutoSize = true;
            lblOccupancyTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblOccupancyTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblOccupancyTitle.Location = new System.Drawing.Point(10, 12);
            lblOccupancyTitle.Name = "lblOccupancyTitle";
            lblOccupancyTitle.Size = new System.Drawing.Size(103, 15);
            lblOccupancyTitle.TabIndex = 0;
            lblOccupancyTitle.Text = "TỶ LỆ LẤP ĐẦY KTX";
            // 
            // pnlCardUtilityRevenue
            // 
            pnlCardUtilityRevenue.BackColor = System.Drawing.Color.White;
            pnlCardUtilityRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlCardUtilityRevenue.Controls.Add(lblUtilityRevenueValue);
            pnlCardUtilityRevenue.Controls.Add(lblUtilityRevenueTitle);
            pnlCardUtilityRevenue.Location = new System.Drawing.Point(515, 12);
            pnlCardUtilityRevenue.Name = "pnlCardUtilityRevenue";
            pnlCardUtilityRevenue.Size = new System.Drawing.Size(235, 76);
            pnlCardUtilityRevenue.TabIndex = 2;
            // 
            // lblUtilityRevenueValue
            // 
            lblUtilityRevenueValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblUtilityRevenueValue.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11);
            lblUtilityRevenueValue.Location = new System.Drawing.Point(10, 36);
            lblUtilityRevenueValue.Name = "lblUtilityRevenueValue";
            lblUtilityRevenueValue.Size = new System.Drawing.Size(213, 26);
            lblUtilityRevenueValue.TabIndex = 1;
            lblUtilityRevenueValue.Text = "0 đ";
            lblUtilityRevenueValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUtilityRevenueTitle
            // 
            lblUtilityRevenueTitle.AutoSize = true;
            lblUtilityRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblUtilityRevenueTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblUtilityRevenueTitle.Location = new System.Drawing.Point(10, 12);
            lblUtilityRevenueTitle.Name = "lblUtilityRevenueTitle";
            lblUtilityRevenueTitle.Size = new System.Drawing.Size(133, 15);
            lblUtilityRevenueTitle.TabIndex = 0;
            lblUtilityRevenueTitle.Text = "DOANH THU ĐIỆN NƯỚC";
            // 
            // pnlCardRoomRevenue
            // 
            pnlCardRoomRevenue.BackColor = System.Drawing.Color.White;
            pnlCardRoomRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlCardRoomRevenue.Controls.Add(lblRoomRevenueValue);
            pnlCardRoomRevenue.Controls.Add(lblRoomRevenueTitle);
            pnlCardRoomRevenue.Location = new System.Drawing.Point(265, 12);
            pnlCardRoomRevenue.Name = "pnlCardRoomRevenue";
            pnlCardRoomRevenue.Size = new System.Drawing.Size(235, 76);
            pnlCardRoomRevenue.TabIndex = 1;
            // 
            // lblRoomRevenueValue
            // 
            lblRoomRevenueValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblRoomRevenueValue.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            lblRoomRevenueValue.Location = new System.Drawing.Point(10, 36);
            lblRoomRevenueValue.Name = "lblRoomRevenueValue";
            lblRoomRevenueValue.Size = new System.Drawing.Size(213, 26);
            lblRoomRevenueValue.TabIndex = 1;
            lblRoomRevenueValue.Text = "0 đ";
            lblRoomRevenueValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRoomRevenueTitle
            // 
            lblRoomRevenueTitle.AutoSize = true;
            lblRoomRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblRoomRevenueTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblRoomRevenueTitle.Location = new System.Drawing.Point(10, 12);
            lblRoomRevenueTitle.Name = "lblRoomRevenueTitle";
            lblRoomRevenueTitle.Size = new System.Drawing.Size(139, 15);
            lblRoomRevenueTitle.TabIndex = 0;
            lblRoomRevenueTitle.Text = "DOANH THU TIỀN PHÒNG";
            // 
            // pnlCardTotalRevenue
            // 
            pnlCardTotalRevenue.BackColor = System.Drawing.Color.White;
            pnlCardTotalRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlCardTotalRevenue.Controls.Add(lblTotalRevenueValue);
            pnlCardTotalRevenue.Controls.Add(lblTotalRevenueTitle);
            pnlCardTotalRevenue.Location = new System.Drawing.Point(18, 12);
            pnlCardTotalRevenue.Name = "pnlCardTotalRevenue";
            pnlCardTotalRevenue.Size = new System.Drawing.Size(235, 76);
            pnlCardTotalRevenue.TabIndex = 0;
            // 
            // lblTotalRevenueValue
            // 
            lblTotalRevenueValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTotalRevenueValue.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            lblTotalRevenueValue.Location = new System.Drawing.Point(10, 36);
            lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            lblTotalRevenueValue.Size = new System.Drawing.Size(213, 26);
            lblTotalRevenueValue.TabIndex = 1;
            lblTotalRevenueValue.Text = "0 đ";
            lblTotalRevenueValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalRevenueTitle
            // 
            lblTotalRevenueTitle.AutoSize = true;
            lblTotalRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTotalRevenueTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblTotalRevenueTitle.Location = new System.Drawing.Point(10, 12);
            lblTotalRevenueTitle.Name = "lblTotalRevenueTitle";
            lblTotalRevenueTitle.Size = new System.Drawing.Size(132, 15);
            lblTotalRevenueTitle.TabIndex = 0;
            lblTotalRevenueTitle.Text = "TỔNG THU KTX TRONG NĂM";
            // 
            // tabStatistics
            // 
            tabStatistics.Controls.Add(tabRevenue);
            tabStatistics.Controls.Add(tabOccupancy);
            tabStatistics.Controls.Add(tabViolations);
            tabStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            tabStatistics.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tabStatistics.Location = new System.Drawing.Point(0, 156);
            tabStatistics.Name = "tabStatistics";
            tabStatistics.SelectedIndex = 0;
            tabStatistics.Size = new System.Drawing.Size(1010, 534);
            tabStatistics.TabIndex = 2;
            // 
            // tabRevenue
            // 
            tabRevenue.Controls.Add(dgvRevenue);
            tabRevenue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabRevenue.Location = new System.Drawing.Point(4, 26);
            tabRevenue.Name = "tabRevenue";
            tabRevenue.Padding = new System.Windows.Forms.Padding(8);
            tabRevenue.Size = new System.Drawing.Size(1002, 504);
            tabRevenue.TabIndex = 0;
            tabRevenue.Text = "Báo cáo Doanh thu theo tháng";
            tabRevenue.UseVisualStyleBackColor = true;
            // 
            // dgvRevenue
            // 
            dgvRevenue.AllowUserToAddRows = false;
            dgvRevenue.AllowUserToDeleteRows = false;
            dgvRevenue.BackgroundColor = System.Drawing.Color.White;
            dgvRevenue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvRevenue.ColumnHeadersHeight = 36;
            dgvRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvRevenue.EnableHeadersVisualStyles = false;
            dgvRevenue.Location = new System.Drawing.Point(8, 8);
            dgvRevenue.MultiSelect = false;
            dgvRevenue.Name = "dgvRevenue";
            dgvRevenue.ReadOnly = true;
            dgvRevenue.RowHeadersVisible = false;
            dgvRevenue.RowTemplate.Height = 32;
            dgvRevenue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvRevenue.Size = new System.Drawing.Size(986, 488);
            dgvRevenue.TabIndex = 0;
            // 
            // tabOccupancy
            // 
            tabOccupancy.Controls.Add(dgvOccupancy);
            tabOccupancy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabOccupancy.Location = new System.Drawing.Point(4, 26);
            tabOccupancy.Name = "tabOccupancy";
            tabOccupancy.Padding = new System.Windows.Forms.Padding(8);
            tabOccupancy.Size = new System.Drawing.Size(1002, 504);
            tabOccupancy.TabIndex = 1;
            tabOccupancy.Text = "Tỷ lệ Lấp đầy theo Tòa nhà & Phòng";
            tabOccupancy.UseVisualStyleBackColor = true;
            // 
            // dgvOccupancy
            // 
            dgvOccupancy.AllowUserToAddRows = false;
            dgvOccupancy.AllowUserToDeleteRows = false;
            dgvOccupancy.BackgroundColor = System.Drawing.Color.White;
            dgvOccupancy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvOccupancy.ColumnHeadersHeight = 36;
            dgvOccupancy.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvOccupancy.EnableHeadersVisualStyles = false;
            dgvOccupancy.Location = new System.Drawing.Point(8, 8);
            dgvOccupancy.MultiSelect = false;
            dgvOccupancy.Name = "dgvOccupancy";
            dgvOccupancy.ReadOnly = true;
            dgvOccupancy.RowHeadersVisible = false;
            dgvOccupancy.RowTemplate.Height = 32;
            dgvOccupancy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvOccupancy.Size = new System.Drawing.Size(986, 488);
            dgvOccupancy.TabIndex = 0;
            // 
            // tabViolations
            // 
            tabViolations.Controls.Add(dgvViolations);
            tabViolations.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabViolations.Location = new System.Drawing.Point(4, 26);
            tabViolations.Name = "tabViolations";
            tabViolations.Padding = new System.Windows.Forms.Padding(8);
            tabViolations.Size = new System.Drawing.Size(1002, 504);
            tabViolations.TabIndex = 2;
            tabViolations.Text = "Thống kê Vi phạm Nội quy";
            tabViolations.UseVisualStyleBackColor = true;
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
            dgvViolations.Location = new System.Drawing.Point(8, 8);
            dgvViolations.MultiSelect = false;
            dgvViolations.Name = "dgvViolations";
            dgvViolations.ReadOnly = true;
            dgvViolations.RowHeadersVisible = false;
            dgvViolations.RowTemplate.Height = 32;
            dgvViolations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvViolations.Size = new System.Drawing.Size(986, 488);
            dgvViolations.TabIndex = 0;
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 690);
            Controls.Add(tabStatistics);
            Controls.Add(pnlCards);
            Controls.Add(pnlFilter);
            Name = "StatisticsForm";
            Text = "Báo cáo Thống kê";
            Load += StatisticsForm_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlCards.ResumeLayout(false);
            pnlCardOccupancy.ResumeLayout(false);
            pnlCardOccupancy.PerformLayout();
            pnlCardUtilityRevenue.ResumeLayout(false);
            pnlCardUtilityRevenue.PerformLayout();
            pnlCardRoomRevenue.ResumeLayout(false);
            pnlCardRoomRevenue.PerformLayout();
            pnlCardTotalRevenue.ResumeLayout(false);
            pnlCardTotalRevenue.PerformLayout();
            tabStatistics.ResumeLayout(false);
            tabRevenue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).EndInit();
            tabOccupancy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOccupancy).EndInit();
            tabViolations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvViolations).EndInit();
            ResumeLayout(false);
        }
    }
}
