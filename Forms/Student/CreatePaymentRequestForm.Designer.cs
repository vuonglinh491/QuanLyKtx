namespace QuanLyKtx.Forms.Student
{
    partial class CreatePaymentRequestForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSub;

        private System.Windows.Forms.Label lblPaymentType;
        private System.Windows.Forms.ComboBox cboPaymentType;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblHint;

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new System.Windows.Forms.Panel();
            lblHeaderTitle = new System.Windows.Forms.Label();
            lblHeaderSub = new System.Windows.Forms.Label();

            lblPaymentType = new System.Windows.Forms.Label();
            cboPaymentType = new System.Windows.Forms.ComboBox();
            lblAmount = new System.Windows.Forms.Label();
            txtAmount = new System.Windows.Forms.TextBox();
            lblDescription = new System.Windows.Forms.Label();
            txtDescription = new System.Windows.Forms.TextBox();
            lblHint = new System.Windows.Forms.Label();

            btnSubmit = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();

            pnlHeader.SuspendLayout();
            SuspendLayout();

            // ── pnlHeader ──────────────────────────────────────────────
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 76, 129);
            pnlHeader.Controls.Add(lblHeaderSub);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(460, 65);
            pnlHeader.TabIndex = 0;

            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            lblHeaderTitle.Location = new System.Drawing.Point(18, 12);
            lblHeaderTitle.Text = "Tạo yêu cầu thanh toán";

            lblHeaderSub.AutoSize = true;
            lblHeaderSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(200, 225, 255);
            lblHeaderSub.Location = new System.Drawing.Point(20, 37);
            lblHeaderSub.Text = "Tạo khoản phí để lấy mã QR chuyển khoản KTX";

            // ── Controls ───────────────────────────────────────────────
            lblPaymentType.AutoSize = true;
            lblPaymentType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblPaymentType.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblPaymentType.Location = new System.Drawing.Point(25, 85);
            lblPaymentType.Text = "Khoản cần nộp:";

            cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboPaymentType.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboPaymentType.FormattingEnabled = true;
            cboPaymentType.Items.AddRange(new object[] {
                "Tiền phòng",
                "Tiền điện nước",
                "Tiền đặt cọc",
                "Tiền phạt vi phạm",
                "Khác"
            });
            cboPaymentType.Location = new System.Drawing.Point(25, 110);
            cboPaymentType.Name = "cboPaymentType";
            cboPaymentType.Size = new System.Drawing.Size(410, 25);
            cboPaymentType.TabIndex = 1;

            lblAmount.AutoSize = true;
            lblAmount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblAmount.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblAmount.Location = new System.Drawing.Point(25, 150);
            lblAmount.Text = "Số tiền (VNĐ) *:";

            txtAmount.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtAmount.Location = new System.Drawing.Point(25, 175);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderText = "Ví dụ: 500000";
            txtAmount.Size = new System.Drawing.Size(410, 26);
            txtAmount.TabIndex = 2;

            lblDescription.AutoSize = true;
            lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblDescription.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblDescription.Location = new System.Drawing.Point(25, 215);
            lblDescription.Text = "Ghi chú nội dung:";

            txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtDescription.Location = new System.Drawing.Point(25, 240);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Ví dụ: Đóng tiền phòng tháng 9...";
            txtDescription.Size = new System.Drawing.Size(410, 60);
            txtDescription.TabIndex = 3;

            lblHint.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblHint.Location = new System.Drawing.Point(25, 310);
            lblHint.Size = new System.Drawing.Size(410, 40);
            lblHint.Text = "Khoản này sẽ được lưu vào cơ sở dữ liệu với trạng thái 'Chờ xử lý (Pending)' để bạn quét mã QR thanh toán.";

            // ── Buttons ────────────────────────────────────────────────
            btnSubmit.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnSubmit.ForeColor = System.Drawing.Color.White;
            btnSubmit.Location = new System.Drawing.Point(210, 360);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new System.Drawing.Size(130, 36);
            btnSubmit.TabIndex = 4;
            btnSubmit.Text = "Tạo & Lưu DB";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;

            btnCancel.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnCancel.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnCancel.Location = new System.Drawing.Point(345, 360);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(90, 36);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;

            // ── Form ───────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(460, 415);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Tạo yêu cầu thanh toán";
            Load += CreatePaymentRequestForm_Load;
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(lblHint);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtAmount);
            Controls.Add(lblAmount);
            Controls.Add(cboPaymentType);
            Controls.Add(lblPaymentType);
            Controls.Add(pnlHeader);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
