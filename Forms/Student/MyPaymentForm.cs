using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLyKtx.Data;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Student
{
    public partial class MyPaymentForm : Form
    {
        public MyPaymentForm()
        {
            InitializeComponent();
        }

        private void MyPaymentForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            cboFilterType.SelectedIndex = 0;
            LoadSummaryCards();
            LoadPayments();
        }

        private void SetupDataGridViewStyle()
        {
            DataGridViewHelper.Configure(dgvPayments);
            dgvPayments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvPayments.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvPayments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvPayments.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadSummaryCards()
        {
            if (!Session.StudentID.HasValue) return;

            try
            {
                // Tổng tiền đã nộp KTX
                string sqlPaid = @"
                    SELECT ISNULL(SUM(Amount), 0)
                    FROM dbo.Payments
                    WHERE StudentID = @StudentID AND Status = 'Paid'";

                var objPaid = DatabaseHelper.ExecuteScalar(sqlPaid, new[] { new SqlParameter("@StudentID", Session.StudentID.Value) });
                decimal totalPaid = (objPaid != null && objPaid != DBNull.Value) ? Convert.ToDecimal(objPaid) : 0m;
                lblTotalPaidValue.Text = totalPaid.ToString("N0") + " VNĐ";

                // Tổng tiền vi phạm chưa nộp
                string sqlUnpaidViolations = @"
                    SELECT ISNULL(SUM(FineAmount), 0)
                    FROM dbo.Violations
                    WHERE StudentID = @StudentID AND Status = 'Unpaid'";

                var objUnpaid = DatabaseHelper.ExecuteScalar(sqlUnpaidViolations, new[] { new SqlParameter("@StudentID", Session.StudentID.Value) });
                decimal totalUnpaid = (objUnpaid != null && objUnpaid != DBNull.Value) ? Convert.ToDecimal(objUnpaid) : 0m;
                lblTotalUnpaidValue.Text = totalUnpaid.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính toán công nợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPayments()
        {
            if (!Session.StudentID.HasValue) return;

            try
            {
                string sql = @"
            SELECT 
                'BL' + RIGHT('0000' + CAST(p.PaymentID AS VARCHAR(10)), 4) AS [Mã biên lai],
                p.PaymentType AS [Loại chi phí],
                p.Amount AS [Số tiền (đ)],
                CONVERT(VARCHAR(10), p.PaymentDate, 103) AS [Ngày nộp],
                CASE p.Status
                    WHEN 'Paid' THEN N'Đã hoàn thành'
                    WHEN 'Pending' THEN N'Chờ xử lý'
                    WHEN 'Cancelled' THEN N'Đã hủy'
                    ELSE p.Status
                END AS [Trạng thái],
                p.Description AS [Nội dung ghi chú]
            FROM dbo.Payments p
            WHERE p.StudentID = @StudentID";

                if (cboFilterType.SelectedIndex == 1)
                    sql += " AND p.PaymentType LIKE N'%phòng%'";
                else if (cboFilterType.SelectedIndex == 2)
                    sql += " AND p.PaymentType LIKE N'%điện%'";
                else if (cboFilterType.SelectedIndex == 3)
                    sql += " AND p.PaymentType LIKE N'%vi phạm%'";

                sql += " ORDER BY p.PaymentDate DESC, p.PaymentID DESC";

                var dt = DatabaseHelper.ExecuteQuery(sql, new[] { new SqlParameter("@StudentID", Session.StudentID.Value) });
                dgvPayments.DataSource = dt;

                if (dgvPayments.Columns.Contains("Số tiền (đ)"))
                {
                    dgvPayments.Columns["Số tiền (đ)"].DefaultCellStyle.Format = "N0";
                    dgvPayments.Columns["Số tiền (đ)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                dgvPayments.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboFilterType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadPayments();
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadSummaryCards();
            LoadPayments();
        }
    }
}
