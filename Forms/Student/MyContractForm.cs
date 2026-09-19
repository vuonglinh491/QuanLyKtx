using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QuanLyKtx.Data;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Student
{
    public partial class MyContractForm : Form
    {
        public MyContractForm()
        {
            InitializeComponent();
        }

        private void MyContractForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            LoadContractData();
        }

        private void SetupDataGridViewStyle()
        {
            dgvContracts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvContracts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvContracts.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvContracts.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvContracts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvContracts.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadContractData()
        {
            if (!Session.StudentID.HasValue)
            {
                ShowNoContract("Không xác định được sinh viên đăng nhập!");
                return;
            }

            try
            {
                // 1. Tải hợp đồng đang có hiệu lực (hoặc hợp đồng mới nhất)
                string sqlActive = @"
                    SELECT TOP 1
                        c.ContractID,
                        c.ContractNumber,
                        b.BuildingName + ' - ' + r.RoomNumber AS RoomDisplayName,
                        c.StartDate,
                        c.EndDate,
                        c.RoomPrice,
                        c.DepositAmount,
                        c.Status,
                        c.Terms
                    FROM dbo.Contracts c
                    JOIN dbo.Rooms r ON c.RoomID = r.RoomID
                    JOIN dbo.Buildings b ON r.BuildingID = b.BuildingID
                    WHERE c.StudentID = @StudentID
                    ORDER BY CASE c.Status WHEN 'Active' THEN 1 ELSE 2 END, c.StartDate DESC";

                var dtActive = DatabaseHelper.ExecuteQuery(sqlActive, new[] { new SqlParameter("@StudentID", Session.StudentID.Value) });

                if (dtActive.Rows.Count == 0)
                {
                    ShowNoContract("Bạn chưa có hợp đồng ký túc xá nào trong hệ thống!");
                    return;
                }

                var row = dtActive.Rows[0];
                txtContractNumber.Text = row["ContractNumber"].ToString();
                txtRoom.Text = row["RoomDisplayName"].ToString();

                if (row["StartDate"] != DBNull.Value && DateTime.TryParse(row["StartDate"].ToString(), out var sDate))
                    txtStartDate.Text = sDate.ToString("dd/MM/yyyy");

                if (row["EndDate"] != DBNull.Value && DateTime.TryParse(row["EndDate"].ToString(), out var eDate))
                    txtEndDate.Text = eDate.ToString("dd/MM/yyyy");

                decimal price = Convert.ToDecimal(row["RoomPrice"]);
                txtRoomPrice.Text = price.ToString("N0") + " VNĐ";

                decimal deposit = Convert.ToDecimal(row["DepositAmount"]);
                txtDeposit.Text = deposit.ToString("N0") + " VNĐ";

                string st = row["Status"].ToString() ?? "";
                txtStatus.Text = st == "Active" ? "Đang hiệu lực" : (st == "Expired" ? "Đã hết hạn" : (st == "Terminated" ? "Đã thanh lý" : st));
                txtTerms.Text = row["Terms"]?.ToString() ?? "(Không có điều khoản bổ sung)";

                lblNoContract.Visible = false;
                grpActiveContract.Visible = true;
                grpHistory.Visible = true;

                // 2. Lịch sử tất cả các hợp đồng
                string sqlHistory = @"
                    SELECT 
                        c.ContractNumber AS [Số hợp đồng],
                        b.BuildingName + ' - ' + r.RoomNumber AS [Phòng KTX],
                        CONVERT(VARCHAR(10), c.StartDate, 103) AS [Ngày bắt đầu],
                        CONVERT(VARCHAR(10), c.EndDate, 103) AS [Ngày kết thúc],
                        c.RoomPrice AS [Tiền phòng (đ)],
                        c.DepositAmount AS [Tiền cọc (đ)],
                        CASE c.Status
                            WHEN 'Active' THEN N'Đang hiệu lực'
                            WHEN 'Expired' THEN N'Đã hết hạn'
                            WHEN 'Terminated' THEN N'Đã thanh lý'
                            ELSE c.Status
                        END AS [Trạng thái]
                    FROM dbo.Contracts c
                    JOIN dbo.Rooms r ON c.RoomID = r.RoomID
                    JOIN dbo.Buildings b ON r.BuildingID = b.BuildingID
                    WHERE c.StudentID = @StudentID
                    ORDER BY c.StartDate DESC";

                var dtHistory = DatabaseHelper.ExecuteQuery(sqlHistory, new[] { new SqlParameter("@StudentID", Session.StudentID.Value) });
                dgvContracts.DataSource = dtHistory;

                if (dgvContracts.Columns.Contains("Tiền phòng (đ)"))
                {
                    dgvContracts.Columns["Tiền phòng (đ)"].DefaultCellStyle.Format = "N0";
                    dgvContracts.Columns["Tiền phòng (đ)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvContracts.Columns.Contains("Tiền cọc (đ)"))
                {
                    dgvContracts.Columns["Tiền cọc (đ)"].DefaultCellStyle.Format = "N0";
                    dgvContracts.Columns["Tiền cọc (đ)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                dgvContracts.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin hợp đồng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowNoContract(string message)
        {
            lblNoContract.Text = message;
            lblNoContract.Visible = true;
            grpActiveContract.Visible = false;
            grpHistory.Visible = false;
        }

        private void dgvContracts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
