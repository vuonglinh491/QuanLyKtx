namespace QuanLyKtx.Forms.Student
{
    partial class MyPaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        // ── Header cards ───────────────────────────────────────────────
        private System.Windows.Forms.Panel     pnlHeader;
        private System.Windows.Forms.Panel     pnlCardPaid;
        private System.Windows.Forms.Label     lblTotalPaidTitle;
        private System.Windows.Forms.Label     lblTotalPaidValue;
        private System.Windows.Forms.Panel     pnlCardUnpaid;
        private System.Windows.Forms.Label     lblTotalUnpaidTitle;
        private System.Windows.Forms.Label     lblTotalUnpaidValue;
        private System.Windows.Forms.Label     lblFilterType;
        private System.Windows.Forms.ComboBox  cboFilterType;
        private System.Windows.Forms.Button    btnRefresh;

        // ── TabControl ─────────────────────────────────────────────────
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage    tabHistory;
        private System.Windows.Forms.TabPage    tabPending;

        // ── Tab 1: History ─────────────────────────────────────────────
        private System.Windows.Forms.DataGridView dgvPayments;

        // ── Tab 2: Pending + QR ────────────────────────────────────────
        private System.Windows.Forms.Panel        pnlPendingToolbar;
        private System.Windows.Forms.Label        lblPendingHint;
        private System.Windows.Forms.Button       btnCreateRequest;
        private System.Windows.Forms.Button       btnPayQR;
        private System.Windows.Forms.DataGridView dgvPending;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader        = new System.Windows.Forms.Panel();
            btnRefresh       = new System.Windows.Forms.Button();
            cboFilterType    = new System.Windows.Forms.ComboBox();
            lblFilterType    = new System.Windows.Forms.Label();
            pnlCardUnpaid    = new System.Windows.Forms.Panel();
            lblTotalUnpaidValue = new System.Windows.Forms.Label();
            lblTotalUnpaidTitle = new System.Windows.Forms.Label();
            pnlCardPaid      = new System.Windows.Forms.Panel();
            lblTotalPaidValue= new System.Windows.Forms.Label();
            lblTotalPaidTitle= new System.Windows.Forms.Label();

            tabControl       = new System.Windows.Forms.TabControl();
            tabHistory       = new System.Windows.Forms.TabPage();
            tabPending       = new System.Windows.Forms.TabPage();

            dgvPayments      = new System.Windows.Forms.DataGridView();

            pnlPendingToolbar = new System.Windows.Forms.Panel();
            lblPendingHint   = new System.Windows.Forms.Label();
            btnCreateRequest = new System.Windows.Forms.Button();
            btnPayQR         = new System.Windows.Forms.Button();
            dgvPending       = new System.Windows.Forms.DataGridView();

            pnlHeader.SuspendLayout();
            pnlCardUnpaid.SuspendLayout();
            pnlCardPaid.SuspendLayout();
            tabControl.SuspendLayout();
            tabHistory.SuspendLayout();
            tabPending.SuspendLayout();
            pnlPendingToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPending).BeginInit();
            SuspendLayout();

            // ── pnlHeader ─────────────────────────────────────────────
            pnlHeader.BackColor   = System.Drawing.Color.White;
            pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(cboFilterType);
            pnlHeader.Controls.Add(lblFilterType);
            pnlHeader.Controls.Add(pnlCardUnpaid);
            pnlHeader.Controls.Add(pnlCardPaid);
            pnlHeader.Dock     = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name     = "pnlHeader";
            pnlHeader.Size     = new System.Drawing.Size(1010, 105);
            pnlHeader.TabIndex = 0;

            // btnRefresh
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnRefresh.Cursor    = System.Windows.Forms.Cursors.Hand;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnRefresh.Location  = new System.Drawing.Point(885, 38);
            btnRefresh.Name      = "btnRefresh";
            btnRefresh.Size      = new System.Drawing.Size(95, 32);
            btnRefresh.TabIndex  = 4;
            btnRefresh.Text      = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click    += btnRefresh_Click;

            // cboFilterType
            cboFilterType.DropDownStyle   = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterType.Font            = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterType.FormattingEnabled = true;
            cboFilterType.Items.AddRange(new object[] { "Tất cả", "Tiền phòng", "Điện nước", "Vi phạm" });
            cboFilterType.Location        = new System.Drawing.Point(700, 42);
            cboFilterType.Name            = "cboFilterType";
            cboFilterType.Size            = new System.Drawing.Size(170, 24);
            cboFilterType.TabIndex        = 3;
            cboFilterType.SelectedIndexChanged += cboFilterType_SelectedIndexChanged;

            // lblFilterType
            lblFilterType.AutoSize  = true;
            lblFilterType.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblFilterType.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFilterType.Location  = new System.Drawing.Point(605, 45);
            lblFilterType.Name      = "lblFilterType";
            lblFilterType.TabIndex  = 2;
            lblFilterType.Text      = "Loại chi phí:";

            // pnlCardUnpaid
            pnlCardUnpaid.BackColor   = System.Drawing.Color.FromArgb(254, 242, 242);
            pnlCardUnpaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlCardUnpaid.Controls.Add(lblTotalUnpaidValue);
            pnlCardUnpaid.Controls.Add(lblTotalUnpaidTitle);
            pnlCardUnpaid.Location = new System.Drawing.Point(300, 15);
            pnlCardUnpaid.Name     = "pnlCardUnpaid";
            pnlCardUnpaid.Size     = new System.Drawing.Size(260, 75);
            pnlCardUnpaid.TabIndex = 1;

            lblTotalUnpaidValue.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTotalUnpaidValue.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            lblTotalUnpaidValue.Location  = new System.Drawing.Point(10, 36);
            lblTotalUnpaidValue.Name      = "lblTotalUnpaidValue";
            lblTotalUnpaidValue.Size      = new System.Drawing.Size(238, 28);
            lblTotalUnpaidValue.TabIndex  = 1;
            lblTotalUnpaidValue.Text      = "0 VNĐ";
            lblTotalUnpaidValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            lblTotalUnpaidTitle.AutoSize  = true;
            lblTotalUnpaidTitle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTotalUnpaidTitle.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            lblTotalUnpaidTitle.Location  = new System.Drawing.Point(10, 10);
            lblTotalUnpaidTitle.Name      = "lblTotalUnpaidTitle";
            lblTotalUnpaidTitle.TabIndex  = 0;
            lblTotalUnpaidTitle.Text      = "Khoản chưa nộp phạt:";

            // pnlCardPaid
            pnlCardPaid.BackColor   = System.Drawing.Color.FromArgb(240, 253, 244);
            pnlCardPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlCardPaid.Controls.Add(lblTotalPaidValue);
            pnlCardPaid.Controls.Add(lblTotalPaidTitle);
            pnlCardPaid.Location = new System.Drawing.Point(20, 15);
            pnlCardPaid.Name     = "pnlCardPaid";
            pnlCardPaid.Size     = new System.Drawing.Size(260, 75);
            pnlCardPaid.TabIndex = 0;

            lblTotalPaidValue.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTotalPaidValue.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            lblTotalPaidValue.Location  = new System.Drawing.Point(10, 36);
            lblTotalPaidValue.Name      = "lblTotalPaidValue";
            lblTotalPaidValue.Size      = new System.Drawing.Size(238, 28);
            lblTotalPaidValue.TabIndex  = 1;
            lblTotalPaidValue.Text      = "0 VNĐ";
            lblTotalPaidValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            lblTotalPaidTitle.AutoSize  = true;
            lblTotalPaidTitle.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTotalPaidTitle.ForeColor = System.Drawing.Color.FromArgb(4, 120, 87);
            lblTotalPaidTitle.Location  = new System.Drawing.Point(10, 10);
            lblTotalPaidTitle.Name      = "lblTotalPaidTitle";
            lblTotalPaidTitle.TabIndex  = 0;
            lblTotalPaidTitle.Text      = "Tổng tiền đã nộp KTX:";

            // ── TabControl ─────────────────────────────────────────────
            tabControl.Dock           = System.Windows.Forms.DockStyle.Fill;
            tabControl.Font           = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabControl.Location       = new System.Drawing.Point(0, 105);
            tabControl.Name           = "tabControl";
            tabControl.SelectedIndex  = 0;
            tabControl.TabIndex       = 1;
            tabControl.Controls.Add(tabHistory);
            tabControl.Controls.Add(tabPending);
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;

            // ── tabHistory ─────────────────────────────────────────────
            tabHistory.BackColor = System.Drawing.Color.White;
            tabHistory.Controls.Add(dgvPayments);
            tabHistory.Font     = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tabHistory.ForeColor= System.Drawing.Color.FromArgb(15, 76, 129);
            tabHistory.Name     = "tabHistory";
            tabHistory.Padding  = new System.Windows.Forms.Padding(10);
            tabHistory.Text     = "📋  Lịch sử biên lai";
            tabHistory.TabIndex = 0;

            dgvPayments.AllowUserToAddRows  = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.BackgroundColor     = System.Drawing.Color.White;
            dgvPayments.BorderStyle         = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvPayments.ColumnHeadersHeight = 36;
            dgvPayments.Dock                = System.Windows.Forms.DockStyle.Fill;
            dgvPayments.EnableHeadersVisualStyles = false;
            dgvPayments.Font                = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvPayments.Location            = new System.Drawing.Point(10, 10);
            dgvPayments.MultiSelect         = false;
            dgvPayments.Name                = "dgvPayments";
            dgvPayments.ReadOnly            = true;
            dgvPayments.RowHeadersVisible   = false;
            dgvPayments.RowTemplate.Height  = 32;
            dgvPayments.SelectionMode       = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.TabIndex            = 0;

            // ── tabPending ─────────────────────────────────────────────
            tabPending.BackColor = System.Drawing.Color.FromArgb(255, 252, 245);
            tabPending.Controls.Add(dgvPending);
            tabPending.Controls.Add(pnlPendingToolbar);
            tabPending.Name     = "tabPending";
            tabPending.Text     = "⏳  Chờ thanh toán";
            tabPending.TabIndex = 1;

            // pnlPendingToolbar
            pnlPendingToolbar.BackColor   = System.Drawing.Color.White;
            pnlPendingToolbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlPendingToolbar.Dock        = System.Windows.Forms.DockStyle.Top;
            pnlPendingToolbar.Height      = 55;
            pnlPendingToolbar.Padding     = new System.Windows.Forms.Padding(10, 8, 10, 8);
            pnlPendingToolbar.Controls.Add(btnCreateRequest);
            pnlPendingToolbar.Controls.Add(btnPayQR);
            pnlPendingToolbar.Controls.Add(lblPendingHint);

            lblPendingHint.AutoSize  = true;
            lblPendingHint.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblPendingHint.ForeColor = System.Drawing.Color.FromArgb(120, 80, 0);
            lblPendingHint.Location  = new System.Drawing.Point(12, 18);
            lblPendingHint.Text      = "Chọn khoản phí rồi bấm \"Thanh toán QR\" hoặc bấm \"+ Yêu cầu thanh toán mới\" để tạo khoản nộp.";

            btnCreateRequest.BackColor          = System.Drawing.Color.FromArgb(15, 76, 129);
            btnCreateRequest.Cursor             = System.Windows.Forms.Cursors.Hand;
            btnCreateRequest.FlatAppearance.BorderSize = 0;
            btnCreateRequest.FlatStyle          = System.Windows.Forms.FlatStyle.Flat;
            btnCreateRequest.Font               = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnCreateRequest.ForeColor          = System.Drawing.Color.White;
            btnCreateRequest.Location           = new System.Drawing.Point(620, 10);
            btnCreateRequest.Name               = "btnCreateRequest";
            btnCreateRequest.Size               = new System.Drawing.Size(180, 34);
            btnCreateRequest.TabIndex           = 0;
            btnCreateRequest.Text               = "➕ Yêu cầu thanh toán mới";
            btnCreateRequest.UseVisualStyleBackColor = false;
            btnCreateRequest.Click             += btnCreateRequest_Click;

            btnPayQR.BackColor          = System.Drawing.Color.FromArgb(180, 190, 210);
            btnPayQR.Cursor             = System.Windows.Forms.Cursors.Hand;
            btnPayQR.Enabled            = false;
            btnPayQR.FlatAppearance.BorderSize = 0;
            btnPayQR.FlatStyle          = System.Windows.Forms.FlatStyle.Flat;
            btnPayQR.Font               = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnPayQR.ForeColor          = System.Drawing.Color.White;
            btnPayQR.Location           = new System.Drawing.Point(810, 10);
            btnPayQR.Name               = "btnPayQR";
            btnPayQR.Size               = new System.Drawing.Size(160, 34);
            btnPayQR.TabIndex           = 1;
            btnPayQR.Text               = "📱  Thanh toán QR";
            btnPayQR.Click             += btnPayQR_Click;

            // dgvPending
            dgvPending.AllowUserToAddRows    = false;
            dgvPending.AllowUserToDeleteRows = false;
            dgvPending.BackgroundColor       = System.Drawing.Color.FromArgb(255, 252, 245);
            dgvPending.BorderStyle           = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvPending.ColumnHeadersHeight   = 36;
            dgvPending.Dock                  = System.Windows.Forms.DockStyle.Fill;
            dgvPending.EnableHeadersVisualStyles = false;
            dgvPending.Font                  = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvPending.Location              = new System.Drawing.Point(0, 55);
            dgvPending.MultiSelect           = false;
            dgvPending.Name                  = "dgvPending";
            dgvPending.ReadOnly              = true;
            dgvPending.RowHeadersVisible     = false;
            dgvPending.RowTemplate.Height    = 34;
            dgvPending.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvPending.TabIndex              = 1;
            dgvPending.SelectionChanged     += dgvPending_SelectionChanged;

            // ── Form ───────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            BackColor           = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize          = new System.Drawing.Size(1010, 640);
            Controls.Add(tabControl);
            Controls.Add(pnlHeader);
            Name  = "MyPaymentForm";
            Text  = "Thanh toán của tôi";
            Load += MyPaymentForm_Load;

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlCardUnpaid.ResumeLayout(false);
            pnlCardUnpaid.PerformLayout();
            pnlCardPaid.ResumeLayout(false);
            pnlCardPaid.PerformLayout();
            tabControl.ResumeLayout(false);
            tabHistory.ResumeLayout(false);
            tabPending.ResumeLayout(false);
            pnlPendingToolbar.ResumeLayout(false);
            pnlPendingToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPending).EndInit();
            ResumeLayout(false);
        }
    }
}
