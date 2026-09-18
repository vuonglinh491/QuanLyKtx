namespace QuanLyKtx.Forms.Student
{
    partial class MyPaymentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlCardPaid;
        private System.Windows.Forms.Label lblTotalPaidTitle;
        private System.Windows.Forms.Label lblTotalPaidValue;
        private System.Windows.Forms.Panel pnlCardUnpaid;
        private System.Windows.Forms.Label lblTotalUnpaidTitle;
        private System.Windows.Forms.Label lblTotalUnpaidValue;
        private System.Windows.Forms.Label lblFilterType;
        private System.Windows.Forms.ComboBox cboFilterType;
        private System.Windows.Forms.Button btnRefresh;

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
            pnlHeader = new System.Windows.Forms.Panel();
            btnRefresh = new System.Windows.Forms.Button();
            cboFilterType = new System.Windows.Forms.ComboBox();
            lblFilterType = new System.Windows.Forms.Label();
            pnlCardUnpaid = new System.Windows.Forms.Panel();
            lblTotalUnpaidValue = new System.Windows.Forms.Label();
            lblTotalUnpaidTitle = new System.Windows.Forms.Label();
            pnlCardPaid = new System.Windows.Forms.Panel();
            lblTotalPaidValue = new System.Windows.Forms.Label();
            lblTotalPaidTitle = new System.Windows.Forms.Label();

            grpList = new System.Windows.Forms.GroupBox();
            dgvPayments = new System.Windows.Forms.DataGridView();

            pnlHeader.SuspendLayout();
            pnlCardUnpaid.SuspendLayout();
            pnlCardPaid.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.White;
            pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(cboFilterType);
            pnlHeader.Controls.Add(lblFilterType);
            pnlHeader.Controls.Add(pnlCardUnpaid);
            pnlHeader.Controls.Add(pnlCardPaid);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1010, 105);
            pnlHeader.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnRefresh.Location = new System.Drawing.Point(885, 38);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(95, 32);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // cboFilterType
            // 
            cboFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterType.FormattingEnabled = true;
            cboFilterType.Items.AddRange(new object[] { "Tất cả", "Tiền phòng", "Điện nước", "Vi phạm" });
            cboFilterType.Location = new System.Drawing.Point(700, 42);
            cboFilterType.Name = "cboFilterType";
            cboFilterType.Size = new System.Drawing.Size(170, 24);
            cboFilterType.TabIndex = 3;
            cboFilterType.SelectedIndexChanged += cboFilterType_SelectedIndexChanged;
            // 
            // lblFilterType
            // 
            lblFilterType.AutoSize = true;
            lblFilterType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblFilterType.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFilterType.Location = new System.Drawing.Point(605, 45);
            lblFilterType.Name = "lblFilterType";
            lblFilterType.Size = new System.Drawing.Size(89, 17);
            lblFilterType.TabIndex = 2;
            lblFilterType.Text = "Loại chi phí:";
            // 
            // pnlCardUnpaid
            // 
            pnlCardUnpaid.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            pnlCardUnpaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlCardUnpaid.Controls.Add(lblTotalUnpaidValue);
            pnlCardUnpaid.Controls.Add(lblTotalUnpaidTitle);
            pnlCardUnpaid.Location = new System.Drawing.Point(300, 15);
            pnlCardUnpaid.Name = "pnlCardUnpaid";
            pnlCardUnpaid.Size = new System.Drawing.Size(260, 75);
            pnlCardUnpaid.TabIndex = 1;
            // 
            // lblTotalUnpaidValue
            // 
            lblTotalUnpaidValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTotalUnpaidValue.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            lblTotalUnpaidValue.Location = new System.Drawing.Point(10, 36);
            lblTotalUnpaidValue.Name = "lblTotalUnpaidValue";
            lblTotalUnpaidValue.Size = new System.Drawing.Size(238, 28);
            lblTotalUnpaidValue.TabIndex = 1;
            lblTotalUnpaidValue.Text = "0 VNĐ";
            lblTotalUnpaidValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalUnpaidTitle
            // 
            lblTotalUnpaidTitle.AutoSize = true;
            lblTotalUnpaidTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTotalUnpaidTitle.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            lblTotalUnpaidTitle.Location = new System.Drawing.Point(10, 10);
            lblTotalUnpaidTitle.Name = "lblTotalUnpaidTitle";
            lblTotalUnpaidTitle.Size = new System.Drawing.Size(127, 15);
            lblTotalUnpaidTitle.TabIndex = 0;
            lblTotalUnpaidTitle.Text = "Khoản chưa nộp phạt:";
            // 
            // pnlCardPaid
            // 
            pnlCardPaid.BackColor = System.Drawing.Color.FromArgb(240, 253, 244);
            pnlCardPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlCardPaid.Controls.Add(lblTotalPaidValue);
            pnlCardPaid.Controls.Add(lblTotalPaidTitle);
            pnlCardPaid.Location = new System.Drawing.Point(20, 15);
            pnlCardPaid.Name = "pnlCardPaid";
            pnlCardPaid.Size = new System.Drawing.Size(260, 75);
            pnlCardPaid.TabIndex = 0;
            // 
            // lblTotalPaidValue
            // 
            lblTotalPaidValue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTotalPaidValue.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            lblTotalPaidValue.Location = new System.Drawing.Point(10, 36);
            lblTotalPaidValue.Name = "lblTotalPaidValue";
            lblTotalPaidValue.Size = new System.Drawing.Size(238, 28);
            lblTotalPaidValue.TabIndex = 1;
            lblTotalPaidValue.Text = "0 VNĐ";
            lblTotalPaidValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalPaidTitle
            // 
            lblTotalPaidTitle.AutoSize = true;
            lblTotalPaidTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTotalPaidTitle.ForeColor = System.Drawing.Color.FromArgb(4, 120, 87);
            lblTotalPaidTitle.Location = new System.Drawing.Point(10, 10);
            lblTotalPaidTitle.Name = "lblTotalPaidTitle";
            lblTotalPaidTitle.Size = new System.Drawing.Size(129, 15);
            lblTotalPaidTitle.TabIndex = 0;
            lblTotalPaidTitle.Text = "Tổng tiền đã nộp KTX:";
            // 
            // grpList
            // 
            grpList.BackColor = System.Drawing.Color.White;
            grpList.Controls.Add(dgvPayments);
            grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            grpList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpList.ForeColor = System.Drawing.Color.FromArgb(15, 76, 129);
            grpList.Location = new System.Drawing.Point(0, 105);
            grpList.Name = "grpList";
            grpList.Padding = new System.Windows.Forms.Padding(12);
            grpList.Size = new System.Drawing.Size(1010, 535);
            grpList.TabIndex = 1;
            grpList.TabStop = false;
            grpList.Text = "Lịch sử biên lai đóng phí KTX";
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
            dgvPayments.Location = new System.Drawing.Point(12, 32);
            dgvPayments.MultiSelect = false;
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.RowTemplate.Height = 32;
            dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.Size = new System.Drawing.Size(986, 491);
            dgvPayments.TabIndex = 0;
            // 
            // MyPaymentForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 640);
            Controls.Add(grpList);
            Controls.Add(pnlHeader);
            Name = "MyPaymentForm";
            Text = "Thanh toán của tôi";
            Load += MyPaymentForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCardUnpaid.ResumeLayout(false);
            pnlCardUnpaid.PerformLayout();
            pnlCardPaid.ResumeLayout(false);
            pnlCardPaid.PerformLayout();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            ResumeLayout(false);
        }
    }
}
