namespace QuanLyKtx.Forms.Student
{
    partial class ElectricityWaterViewForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblRoomTitle;
        private System.Windows.Forms.Label lblFilterYear;
        private System.Windows.Forms.ComboBox cboFilterYear;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvBills;

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
            pnlSummary = new System.Windows.Forms.Panel();
            btnRefresh = new System.Windows.Forms.Button();
            cboFilterYear = new System.Windows.Forms.ComboBox();
            lblFilterYear = new System.Windows.Forms.Label();
            lblRoomTitle = new System.Windows.Forms.Label();

            grpList = new System.Windows.Forms.GroupBox();
            dgvBills = new System.Windows.Forms.DataGridView();

            pnlSummary.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBills).BeginInit();
            SuspendLayout();
            // 
            // pnlSummary
            // 
            pnlSummary.BackColor = System.Drawing.Color.White;
            pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlSummary.Controls.Add(btnRefresh);
            pnlSummary.Controls.Add(cboFilterYear);
            pnlSummary.Controls.Add(lblFilterYear);
            pnlSummary.Controls.Add(lblRoomTitle);
            pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            pnlSummary.Location = new System.Drawing.Point(0, 0);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new System.Drawing.Size(1010, 60);
            pnlSummary.TabIndex = 0;
            // 
            // lblRoomTitle
            // 
            lblRoomTitle.AutoSize = true;
            lblRoomTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblRoomTitle.ForeColor = System.Drawing.Color.FromArgb(15, 76, 129);
            lblRoomTitle.Location = new System.Drawing.Point(20, 18);
            lblRoomTitle.Name = "lblRoomTitle";
            lblRoomTitle.Size = new System.Drawing.Size(260, 21);
            lblRoomTitle.TabIndex = 0;
            lblRoomTitle.Text = "Hóa đơn Điện nước phòng của bạn";
            // 
            // lblFilterYear
            // 
            lblFilterYear.AutoSize = true;
            lblFilterYear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblFilterYear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFilterYear.Location = new System.Drawing.Point(620, 20);
            lblFilterYear.Name = "lblFilterYear";
            lblFilterYear.Size = new System.Drawing.Size(73, 17);
            lblFilterYear.TabIndex = 1;
            lblFilterYear.Text = "Chọn năm:";
            // 
            // cboFilterYear
            // 
            cboFilterYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterYear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterYear.FormattingEnabled = true;
            cboFilterYear.Location = new System.Drawing.Point(700, 17);
            cboFilterYear.Name = "cboFilterYear";
            cboFilterYear.Size = new System.Drawing.Size(130, 24);
            cboFilterYear.TabIndex = 2;
            cboFilterYear.SelectedIndexChanged += cboFilterYear_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnRefresh.Location = new System.Drawing.Point(850, 14);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(100, 30);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // grpList
            // 
            grpList.BackColor = System.Drawing.Color.White;
            grpList.Controls.Add(dgvBills);
            grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            grpList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpList.ForeColor = System.Drawing.Color.FromArgb(15, 76, 129);
            grpList.Location = new System.Drawing.Point(0, 60);
            grpList.Name = "grpList";
            grpList.Padding = new System.Windows.Forms.Padding(12);
            grpList.Size = new System.Drawing.Size(1010, 580);
            grpList.TabIndex = 1;
            grpList.TabStop = false;
            grpList.Text = "Lịch sử hóa đơn điện & nước theo tháng";
            // 
            // dgvBills
            // 
            dgvBills.AllowUserToAddRows = false;
            dgvBills.AllowUserToDeleteRows = false;
            dgvBills.BackgroundColor = System.Drawing.Color.White;
            dgvBills.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvBills.ColumnHeadersHeight = 36;
            dgvBills.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvBills.EnableHeadersVisualStyles = false;
            dgvBills.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvBills.Location = new System.Drawing.Point(12, 32);
            dgvBills.MultiSelect = false;
            dgvBills.Name = "dgvBills";
            dgvBills.ReadOnly = true;
            dgvBills.RowHeadersVisible = false;
            dgvBills.RowTemplate.Height = 32;
            dgvBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvBills.Size = new System.Drawing.Size(986, 536);
            dgvBills.TabIndex = 0;
            // 
            // ElectricityWaterViewForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 640);
            Controls.Add(grpList);
            Controls.Add(pnlSummary);
            Name = "ElectricityWaterViewForm";
            Text = "Điện nước phòng";
            Load += ElectricityWaterViewForm_Load;
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBills).EndInit();
            ResumeLayout(false);
        }
    }
}
