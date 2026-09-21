namespace QuanLyKtx.Forms.Student
{
    partial class QRPaymentForm
    {
        private System.ComponentModel.IContainer components = null;

        // ── Header info panel ──────────────────────────────────────────
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;

        // ── Info labels ────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblPaymentTypeTitle;
        private System.Windows.Forms.Label lblPaymentTypeValue;
        private System.Windows.Forms.Label lblAmountTitle;
        private System.Windows.Forms.Label lblAmountValue;
        private System.Windows.Forms.Label lblDescriptionTitle;
        private System.Windows.Forms.Label lblDescriptionValue;
        private System.Windows.Forms.Label lblBankTitle;
        private System.Windows.Forms.Label lblBankValue;
        private System.Windows.Forms.Label lblAccountTitle;
        private System.Windows.Forms.Label lblAccountValue;
        private System.Windows.Forms.Label lblOwnerTitle;
        private System.Windows.Forms.Label lblOwnerValue;

        // ── QR area ────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlQR;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lblQRHint;
        private System.Windows.Forms.Button btnGenerateQR;

        // ── Bottom buttons ─────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnSaveQR;
        private System.Windows.Forms.Button btnMarkPaid;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop              = new System.Windows.Forms.Panel();
            lblTitle            = new System.Windows.Forms.Label();
            lblSubTitle         = new System.Windows.Forms.Label();

            pnlInfo             = new System.Windows.Forms.Panel();
            lblPaymentTypeTitle = new System.Windows.Forms.Label();
            lblPaymentTypeValue = new System.Windows.Forms.Label();
            lblAmountTitle      = new System.Windows.Forms.Label();
            lblAmountValue      = new System.Windows.Forms.Label();
            lblDescriptionTitle = new System.Windows.Forms.Label();
            lblDescriptionValue = new System.Windows.Forms.Label();
            lblBankTitle        = new System.Windows.Forms.Label();
            lblBankValue        = new System.Windows.Forms.Label();
            lblAccountTitle     = new System.Windows.Forms.Label();
            lblAccountValue     = new System.Windows.Forms.Label();
            lblOwnerTitle       = new System.Windows.Forms.Label();
            lblOwnerValue       = new System.Windows.Forms.Label();

            pnlQR               = new System.Windows.Forms.Panel();
            picQR               = new System.Windows.Forms.PictureBox();
            lblQRHint           = new System.Windows.Forms.Label();
            btnGenerateQR       = new System.Windows.Forms.Button();

            pnlButtons          = new System.Windows.Forms.Panel();
            btnSaveQR           = new System.Windows.Forms.Button();
            btnMarkPaid         = new System.Windows.Forms.Button();
            btnClose            = new System.Windows.Forms.Button();

            pnlTop.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlQR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picQR).BeginInit();
            pnlButtons.SuspendLayout();
            SuspendLayout();

            // ── pnlTop ──────────────────────────────────────────────────
            pnlTop.BackColor  = System.Drawing.Color.FromArgb(15, 76, 129);
            pnlTop.Dock       = System.Windows.Forms.DockStyle.Top;
            pnlTop.Height     = 70;
            pnlTop.Padding    = new System.Windows.Forms.Padding(20, 10, 20, 10);
            pnlTop.Controls.Add(lblSubTitle);
            pnlTop.Controls.Add(lblTitle);

            lblTitle.AutoSize  = true;
            lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location  = new System.Drawing.Point(20, 10);
            lblTitle.Text      = "📱 Thanh toán QR VietQR";

            lblSubTitle.AutoSize  = true;
            lblSubTitle.Font      = new System.Drawing.Font("Segoe UI", 9F);
            lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(200, 225, 255);
            lblSubTitle.Location  = new System.Drawing.Point(22, 42);
            lblSubTitle.Text      = "Quét mã QR bằng ứng dụng ngân hàng để thanh toán tự động";

            // ── pnlInfo ─────────────────────────────────────────────────
            pnlInfo.BackColor   = System.Drawing.Color.White;
            pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlInfo.Dock        = System.Windows.Forms.DockStyle.Left;
            pnlInfo.Width       = 310;
            pnlInfo.Padding     = new System.Windows.Forms.Padding(16);
            pnlInfo.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblPaymentTypeTitle, lblPaymentTypeValue,
                lblAmountTitle, lblAmountValue,
                lblDescriptionTitle, lblDescriptionValue,
                lblBankTitle, lblBankValue,
                lblAccountTitle, lblAccountValue,
                lblOwnerTitle, lblOwnerValue,
                btnGenerateQR
            });

            // Row helper lambda (cannot use real lambdas in designer code, inline positions below)
            int y = 20;

            // Loại chi phí
            lblPaymentTypeTitle.AutoSize  = true;
            lblPaymentTypeTitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblPaymentTypeTitle.ForeColor = System.Drawing.Color.Gray;
            lblPaymentTypeTitle.Location  = new System.Drawing.Point(16, y);
            lblPaymentTypeTitle.Text      = "LOẠI CHI PHÍ";

            y += 20;
            lblPaymentTypeValue.Font      = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            lblPaymentTypeValue.ForeColor = System.Drawing.Color.FromArgb(15, 76, 129);
            lblPaymentTypeValue.Location  = new System.Drawing.Point(16, y);
            lblPaymentTypeValue.Size      = new System.Drawing.Size(275, 22);
            lblPaymentTypeValue.Text      = "—";

            // Số tiền
            y += 34;
            lblAmountTitle.AutoSize  = true;
            lblAmountTitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblAmountTitle.ForeColor = System.Drawing.Color.Gray;
            lblAmountTitle.Location  = new System.Drawing.Point(16, y);
            lblAmountTitle.Text      = "SỐ TIỀN";

            y += 20;
            lblAmountValue.Font      = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblAmountValue.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            lblAmountValue.Location  = new System.Drawing.Point(16, y);
            lblAmountValue.Size      = new System.Drawing.Size(275, 32);
            lblAmountValue.Text      = "0 VNĐ";

            // Nội dung
            y += 44;
            lblDescriptionTitle.AutoSize  = true;
            lblDescriptionTitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblDescriptionTitle.ForeColor = System.Drawing.Color.Gray;
            lblDescriptionTitle.Location  = new System.Drawing.Point(16, y);
            lblDescriptionTitle.Text      = "NỘI DUNG CHUYỂN KHOẢN";

            y += 20;
            lblDescriptionValue.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            lblDescriptionValue.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblDescriptionValue.Location  = new System.Drawing.Point(16, y);
            lblDescriptionValue.Size      = new System.Drawing.Size(275, 40);
            lblDescriptionValue.Text      = "—";

            // Separator line (ngân hàng)
            y += 52;
            var sep1 = new System.Windows.Forms.Label
            {
                BackColor = System.Drawing.Color.FromArgb(230, 235, 240),
                Location  = new System.Drawing.Point(16, y),
                Size      = new System.Drawing.Size(275, 1)
            };
            pnlInfo.Controls.Add(sep1);

            y += 10;
            lblBankTitle.AutoSize  = true;
            lblBankTitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblBankTitle.ForeColor = System.Drawing.Color.Gray;
            lblBankTitle.Location  = new System.Drawing.Point(16, y);
            lblBankTitle.Text      = "NGÂN HÀNG";

            y += 20;
            lblBankValue.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblBankValue.ForeColor = System.Drawing.Color.FromArgb(0, 81, 165);  // VCB blue
            lblBankValue.Location  = new System.Drawing.Point(16, y);
            lblBankValue.Size      = new System.Drawing.Size(275, 22);
            lblBankValue.Text      = "Vietcombank (VCB)";

            y += 34;
            lblAccountTitle.AutoSize  = true;
            lblAccountTitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblAccountTitle.ForeColor = System.Drawing.Color.Gray;
            lblAccountTitle.Location  = new System.Drawing.Point(16, y);
            lblAccountTitle.Text      = "SỐ TÀI KHOẢN";

            y += 20;
            lblAccountValue.Font      = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblAccountValue.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblAccountValue.Location  = new System.Drawing.Point(16, y);
            lblAccountValue.Size      = new System.Drawing.Size(275, 26);
            lblAccountValue.Text      = "9329022717";

            y += 36;
            lblOwnerTitle.AutoSize  = true;
            lblOwnerTitle.Font      = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblOwnerTitle.ForeColor = System.Drawing.Color.Gray;
            lblOwnerTitle.Location  = new System.Drawing.Point(16, y);
            lblOwnerTitle.Text      = "CHỦ TÀI KHOẢN";

            y += 20;
            lblOwnerValue.Font      = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            lblOwnerValue.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblOwnerValue.Location  = new System.Drawing.Point(16, y);
            lblOwnerValue.Size      = new System.Drawing.Size(275, 22);
            lblOwnerValue.Text      = "NGUYEN DUC TRUNG";

            // Nút Tạo QR
            y += 45;
            btnGenerateQR.BackColor          = System.Drawing.Color.FromArgb(24, 119, 242);
            btnGenerateQR.Cursor             = System.Windows.Forms.Cursors.Hand;
            btnGenerateQR.FlatAppearance.BorderSize = 0;
            btnGenerateQR.FlatStyle          = System.Windows.Forms.FlatStyle.Flat;
            btnGenerateQR.Font               = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnGenerateQR.ForeColor          = System.Drawing.Color.White;
            btnGenerateQR.Location           = new System.Drawing.Point(16, y);
            btnGenerateQR.Size               = new System.Drawing.Size(275, 40);
            btnGenerateQR.Text               = "⟳  Tạo mã QR thanh toán";
            btnGenerateQR.Click             += btnGenerateQR_Click;

            // ── pnlQR ───────────────────────────────────────────────────
            pnlQR.BackColor = System.Drawing.Color.FromArgb(248, 250, 253);
            pnlQR.Dock      = System.Windows.Forms.DockStyle.Fill;
            pnlQR.Padding   = new System.Windows.Forms.Padding(20);
            pnlQR.Controls.Add(picQR);
            pnlQR.Controls.Add(lblQRHint);

            picQR.BackColor   = System.Drawing.Color.White;
            picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picQR.Location    = new System.Drawing.Point(40, 20);
            picQR.Size        = new System.Drawing.Size(320, 320);
            picQR.SizeMode    = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            lblQRHint.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            lblQRHint.ForeColor = System.Drawing.Color.Gray;
            lblQRHint.Location  = new System.Drawing.Point(25, 350);
            lblQRHint.Size      = new System.Drawing.Size(350, 60);
            lblQRHint.Text      = "👆 Nhấn \"Tạo mã QR thanh toán\" để tạo mã QR.\n\nMở app ngân hàng → Quét QR → Xác nhận số tiền → Chuyển khoản.";
            lblQRHint.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            // ── pnlButtons ──────────────────────────────────────────────
            pnlButtons.BackColor = System.Drawing.Color.White;
            pnlButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlButtons.Dock     = System.Windows.Forms.DockStyle.Bottom;
            pnlButtons.Height   = 60;
            pnlButtons.Padding  = new System.Windows.Forms.Padding(10);
            pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] { btnClose, btnMarkPaid, btnSaveQR });

            btnSaveQR.BackColor          = System.Drawing.Color.FromArgb(240, 243, 246);
            btnSaveQR.Cursor             = System.Windows.Forms.Cursors.Hand;
            btnSaveQR.FlatStyle          = System.Windows.Forms.FlatStyle.Flat;
            btnSaveQR.Font               = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            btnSaveQR.ForeColor          = System.Drawing.Color.FromArgb(30, 41, 59);
            btnSaveQR.Location           = new System.Drawing.Point(12, 12);
            btnSaveQR.Size               = new System.Drawing.Size(130, 34);
            btnSaveQR.Text               = "💾  Lưu ảnh QR";
            btnSaveQR.Click             += btnSaveQR_Click;

            btnMarkPaid.BackColor        = System.Drawing.Color.FromArgb(16, 185, 129);
            btnMarkPaid.Cursor           = System.Windows.Forms.Cursors.Hand;
            btnMarkPaid.FlatAppearance.BorderSize = 0;
            btnMarkPaid.FlatStyle        = System.Windows.Forms.FlatStyle.Flat;
            btnMarkPaid.Font             = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnMarkPaid.ForeColor        = System.Drawing.Color.White;
            btnMarkPaid.Location         = new System.Drawing.Point(155, 12);
            btnMarkPaid.Size             = new System.Drawing.Size(175, 34);
            btnMarkPaid.Text             = "✔  Đã chuyển khoản xong";
            btnMarkPaid.Click           += btnMarkPaid_Click;

            btnClose.BackColor           = System.Drawing.Color.FromArgb(239, 68, 68);
            btnClose.Cursor              = System.Windows.Forms.Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle           = System.Windows.Forms.FlatStyle.Flat;
            btnClose.Font                = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            btnClose.ForeColor           = System.Drawing.Color.White;
            btnClose.Location            = new System.Drawing.Point(343, 12);
            btnClose.Size                = new System.Drawing.Size(90, 34);
            btnClose.Text                = "✕  Đóng";
            btnClose.Click              += btnClose_Click;

            // ── Form ────────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            BackColor           = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize          = new System.Drawing.Size(730, 570);
            FormBorderStyle     = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox         = false;
            MinimizeBox         = false;
            StartPosition       = System.Windows.Forms.FormStartPosition.CenterParent;
            Text                = "Thanh toán QR - KTX";
            Controls.Add(pnlQR);
            Controls.Add(pnlInfo);
            Controls.Add(pnlButtons);
            Controls.Add(pnlTop);

            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            pnlQR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picQR).EndInit();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
