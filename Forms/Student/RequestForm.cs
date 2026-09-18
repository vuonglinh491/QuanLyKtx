using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyKtx.Models;
using QuanLyKtx.Services;
using QuanLyKtx.Utils;
using StudentModel = QuanLyKtx.Models.Student;

namespace QuanLyKtx.Forms.Student
{
    public partial class RequestForm : Form
    {
        private readonly RequestService _requestService;

        public RequestForm()
        {
            InitializeComponent();
            _requestService = new RequestService();
        }

        private void RequestForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            if (cboRequestType.Items.Count > 0)
                cboRequestType.SelectedIndex = 0;

            LoadMyRequests();
        }

        private void SetupDataGridViewStyle()
        {
            dgvMyRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvMyRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvMyRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvMyRequests.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvMyRequests.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvMyRequests.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadMyRequests()
        {
            if (!Session.StudentID.HasValue) return;

            try
            {
                var dt = _requestService.GetRequestsByStudent(Session.StudentID.Value);
                dgvMyRequests.DataSource = dt;
                dgvMyRequests.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử yêu cầu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            if (!Session.StudentID.HasValue)
            {
                MessageBox.Show("Không xác định được sinh viên đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string content = txtContent.Text.Trim();
            if (string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Vui lòng nhập nội dung hoặc lý do chi tiết cho yêu cầu của bạn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContent.Focus();
                return;
            }

            string reqType = "RegisterRoom";
            if (cboRequestType.SelectedIndex == 1) reqType = "ChangeRoom";
            else if (cboRequestType.SelectedIndex == 2) reqType = "LeaveRoom";

            var req = new Request
            {
                StudentID = Session.StudentID.Value,
                RequestType = reqType,
                Content = content
            };

            if (_requestService.CreateRequest(req, out string errMsg))
            {
                MessageBox.Show("Đã gửi yêu cầu thành công! Ban quản lý KTX sẽ sớm xem xét và phản hồi đến bạn.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtContent.Clear();
                LoadMyRequests();
            }
            else
            {
                MessageBox.Show(errMsg, "Lỗi gửi yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            txtContent.Clear();
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadMyRequests();
        }
    }
}
