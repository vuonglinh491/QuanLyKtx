using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using QuanLyKtx.Data;
using QuanLyKtx.Services;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Student
{
    public partial class MyPaymentForm : Form
    {
        private readonly PaymentService _paymentService;

        public MyPaymentForm()
        {
            InitializeComponent();
            _paymentService = new PaymentService();
        }

        private void MyPaymentForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            tabControl.SelectedIndex = 0;
            LoadSummaryCards();
            LoadPayments();
            LoadPendingPayments();
        }

        private void SetupDataGridViewStyle()
        {
            DataGridViewHelper.Configure(dgvPayments);
            dgvPayments.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvPayments.DefaultCellStyle.Font                   = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvPayments.DefaultCellStyle.SelectionBackColor     = Color.FromArgb(224, 238, 255);
            dgvPayments.DefaultCellStyle.SelectionForeColor     = Color.FromArgb(15, 23, 42);

            DataGridViewHelper.Configure(dgvPending);
            dgvPending.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvPending.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 244, 220);
            dgvPending.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(120, 60, 0);
            dgvPending.DefaultCellStyle.Font                   = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvPending.DefaultCellStyle.SelectionBackColor     = Color.FromArgb(255, 235, 180);
            dgvPending.DefaultCellStyle.SelectionForeColor     = Color.FromArgb(30, 41, 59);
        }

        // ─────────────────────────────────────────────────────────────
        // SUMMARY CARDS
        // ─────────────────────────────────────────────────────────────
        private void LoadSummaryCards()
        {
            if (!Session.StudentID.HasValue) return;

            try
            {
                // Tổng tiền đã nộp KTX
                string sqlPaid = @"
                    SELECT COALESCE(SUM(Amount), 0)
                    FROM Payments
                    WHERE StudentID = @StudentID AND Status = 'Paid'";

                var objPaid = DatabaseHelper.ExecuteScalar(sqlPaid,
                    new[] { new SQLiteParameter("@StudentID", Session.StudentID.Value) });
                decimal totalPaid = (objPaid != null && objPaid != DBNull.Value) ? Convert.ToDecimal(objPaid) : 0m;
                lblTotalPaidValue.Text = totalPaid.ToString("N0") + " VNĐ";

                // Tổng tiền vi phạm chưa nộp
                string sqlUnpaidViolations = @"
                    SELECT COALESCE(SUM(FineAmount), 0)
                    FROM Violations
                    WHERE StudentID = @StudentID AND Status = 'Unpaid'";

                var objUnpaid = DatabaseHelper.ExecuteScalar(sqlUnpaidViolations,
                    new[] { new SQLiteParameter("@StudentID", Session.StudentID.Value) });
                decimal totalUnpaid = (objUnpaid != null && objUnpaid != DBNull.Value) ? Convert.ToDecimal(objUnpaid) : 0m;
                lblTotalUnpaidValue.Text = totalUnpaid.ToString("N0") + " VNĐ";

                // Đếm khoản đang chờ thanh toán
                string sqlPending = @"
                    SELECT COUNT(1) FROM Payments
                    WHERE StudentID = @StudentID AND Status = 'Pending'";
                var objCount = DatabaseHelper.ExecuteScalar(sqlPending,
                    new[] { new SQLiteParameter("@StudentID", Session.StudentID.Value) });
                int pendingCount = (objCount != null && objCount != DBNull.Value) ? Convert.ToInt32(objCount) : 0;

                // Cập nhật tiêu đề tab Pending
                tabPending.Text = pendingCount > 0
                    ? $"⏳ Chờ thanh toán ({pendingCount})"
                    : "⏳ Chờ thanh toán";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính toán công nợ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // LỊCH SỬ THANH TOÁN (TAB 1)
        // ─────────────────────────────────────────────────────────────
        private void LoadPayments()
        {
            if (!Session.StudentID.HasValue) return;

            try
            {
                string sql = @"
            SELECT 
                'BL' || printf('%04d', p.PaymentID) AS [Mã biên lai],
                p.PaymentType AS [Loại chi phí],
                p.Amount AS [Số tiền (đ)],
                strftime('%d/%m/%Y', p.PaymentDate) AS [Ngày nộp],
                CASE p.Status
                    WHEN 'Paid' THEN 'Đã hoàn thành'
                    WHEN 'Pending' THEN 'Chờ xử lý'
                    WHEN 'Cancelled' THEN 'Đã hủy'
                    ELSE p.Status
                END AS [Trạng thái],
                p.Description AS [Nội dung ghi chú]
            FROM Payments p
            WHERE p.StudentID = @StudentID";

                if (cboFilterType.SelectedIndex == 1)
                    sql += " AND p.PaymentType LIKE '%phòng%'";
                else if (cboFilterType.SelectedIndex == 2)
                    sql += " AND p.PaymentType LIKE '%điện%'";
                else if (cboFilterType.SelectedIndex == 3)
                    sql += " AND p.PaymentType LIKE '%vi phạm%'";

                sql += " ORDER BY p.PaymentDate DESC, p.PaymentID DESC";

                var dt = DatabaseHelper.ExecuteQuery(sql,
                    new[] { new SQLiteParameter("@StudentID", Session.StudentID.Value) });
                dgvPayments.DataSource = dt;

                if (dgvPayments.Columns.Contains("Số tiền (đ)"))
                {
                    dgvPayments.Columns["Số tiền (đ)"].DefaultCellStyle.Format    = "N0";
                    dgvPayments.Columns["Số tiền (đ)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                dgvPayments.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử thanh toán: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // KHOẢN CHỜ THANH TOÁN (TAB 2)
        // ─────────────────────────────────────────────────────────────
        private void LoadPendingPayments()
        {
            if (!Session.StudentID.HasValue) return;

            try
            {
                var dt = _paymentService.GetPendingPayments(Session.StudentID.Value);
                dgvPending.DataSource = dt;

                if (dgvPending.Columns.Contains("PaymentID"))
                    dgvPending.Columns["PaymentID"].Visible = false;

                if (dgvPending.Columns.Contains("Số tiền (đ)"))
                {
                    dgvPending.Columns["Số tiền (đ)"].DefaultCellStyle.Format    = "N0";
                    dgvPending.Columns["Số tiền (đ)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPending.Columns["Số tiền (đ)"].Width = 130;
                }

                dgvPending.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                // Cập nhật trạng thái nút
                UpdateQRButtonState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chờ thanh toán: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateQRButtonState()
        {
            bool hasSelection = dgvPending.SelectedRows.Count > 0;
            btnPayQR.Enabled = hasSelection;
            btnPayQR.BackColor = hasSelection
                ? Color.FromArgb(24, 119, 242)
                : Color.FromArgb(180, 190, 210);
        }

        // ─────────────────────────────────────────────────────────────
        // SỰ KIỆN
        // ─────────────────────────────────────────────────────────────
        private void cboFilterType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadPayments();
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadSummaryCards();
            LoadPayments();
            LoadPendingPayments();
        }

        private void tabControl_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                LoadPendingPayments();
            }
        }

        private void dgvPending_SelectionChanged(object? sender, EventArgs e)
        {
            UpdateQRButtonState();
        }

        /// <summary>
        /// Sinh viên bấm tạo yêu cầu thanh toán mới -> lưu vào DB với trạng thái Pending
        /// </summary>
        private void btnCreateRequest_Click(object? sender, EventArgs e)
        {
            using var reqForm = new CreatePaymentRequestForm();
            if (reqForm.ShowDialog(this) == DialogResult.OK)
            {
                LoadSummaryCards();
                LoadPendingPayments();
                LoadPayments();
            }
        }

        /// <summary>
        /// Nút Thanh toán QR — mở QRPaymentForm với khoản được chọn
        /// </summary>
        private void btnPayQR_Click(object? sender, EventArgs e)
        {
            if (dgvPending.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một khoản cần thanh toán từ danh sách.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvPending.SelectedRows[0];

            // Lấy PaymentID từ cột ẩn
            if (!int.TryParse(row.Cells["PaymentID"].Value?.ToString(), out int paymentId))
            {
                MessageBox.Show("Không xác định được khoản thanh toán.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal amount      = row.Cells["Số tiền (đ)"].Value != null
                                  ? Convert.ToDecimal(row.Cells["Số tiền (đ)"].Value) : 0m;
            string paymentType  = row.Cells["Loại chi phí"].Value?.ToString() ?? "Thanh toán KTX";
            string description  = row.Cells["Nội dung"].Value?.ToString() ?? string.Empty;
            string studentCode  = Session.Username; // Mã sinh viên = username đăng nhập

            using var qrForm = new QRPaymentForm(paymentId, amount, paymentType, description, studentCode);
            qrForm.ShowDialog(this);

            if (qrForm.WasMarkedPaid)
            {
                // Reload mọi thứ sau khi đã xác nhận thanh toán
                LoadSummaryCards();
                LoadPayments();
                LoadPendingPayments();
            }
        }
    }
}
