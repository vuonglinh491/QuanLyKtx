using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyKtx.Data;
using QuanLyKtx.Services;
using StudentModel = QuanLyKtx.Models.Student;

namespace QuanLyKtx.Forms.Manager
{
    public partial class RequestManagementForm : Form
    {
        private readonly RequestService _requestService;
        private readonly RoomService _roomService;
        private int _selectedRequestId = 0;
        private string _selectedTypeCode = string.Empty;
        private string _selectedStatusCode = string.Empty;

        public RequestManagementForm()
        {
            InitializeComponent();
            _requestService = new RequestService();
            _roomService = new RoomService();
        }

        private void RequestManagementForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            LoadAvailableRoomsDropdown();

            if (cboFilterStatus.Items.Count > 1)
                cboFilterStatus.SelectedIndex = 1; // Mặc định: Chờ duyệt (Pending)

            if (cboFilterType.Items.Count > 0)
                cboFilterType.SelectedIndex = 0; // Mặc định: Tất cả

            ClearDetails();
            LoadRequests();
        }

        private void SetupDataGridViewStyle()
        {
            dgvRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvRequests.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvRequests.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvRequests.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadAvailableRoomsDropdown()
        {
            try
            {
                var dt = _roomService.GetAvailableRooms();
                cboAvailableRooms.DataSource = dt;
                cboAvailableRooms.DisplayMember = "RoomDisplayName";
                cboAvailableRooms.ValueMember = "RoomID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phòng trống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRequests()
        {
            try
            {
                string? statusFilter = null;
                if (cboFilterStatus.SelectedIndex == 1) statusFilter = "Pending";
                else if (cboFilterStatus.SelectedIndex == 2) statusFilter = "Approved";
                else if (cboFilterStatus.SelectedIndex == 3) statusFilter = "Rejected";

                string? typeFilter = null;
                if (cboFilterType.SelectedIndex == 1) typeFilter = "RegisterRoom";
                else if (cboFilterType.SelectedIndex == 2) typeFilter = "ChangeRoom";
                else if (cboFilterType.SelectedIndex == 3) typeFilter = "LeaveRoom";

                string keyword = txtSearch.Text.Trim();

                var dt = _requestService.GetAllRequests(statusFilter, typeFilter, keyword);
                dgvRequests.DataSource = dt;

                // Ẩn các cột kỹ thuật
                if (dgvRequests.Columns.Contains("RequestID"))
                    dgvRequests.Columns["RequestID"].Visible = false;
                if (dgvRequests.Columns.Contains("StudentID"))
                    dgvRequests.Columns["StudentID"].Visible = false;
                if (dgvRequests.Columns.Contains("TypeCode"))
                    dgvRequests.Columns["TypeCode"].Visible = false;
                if (dgvRequests.Columns.Contains("StatusCode"))
                    dgvRequests.Columns["StatusCode"].Visible = false;

                dgvRequests.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách yêu cầu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRequests_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRequests.Rows.Count) return;

            var row = dgvRequests.Rows[e.RowIndex];
            if (row.Cells["RequestID"].Value == null) return;

            _selectedRequestId = Convert.ToInt32(row.Cells["RequestID"].Value);
            _selectedTypeCode = row.Cells["TypeCode"].Value?.ToString() ?? string.Empty;
            _selectedStatusCode = row.Cells["StatusCode"].Value?.ToString() ?? string.Empty;

            string reqCode = row.Cells["Mã YC"].Value?.ToString() ?? "";
            string studentCode = row.Cells["Mã SV"].Value?.ToString() ?? "";
            string fullName = row.Cells["Họ và tên"].Value?.ToString() ?? "";
            string className = row.Cells["Lớp"].Value?.ToString() ?? "";
            string phone = row.Cells["SĐT"].Value?.ToString() ?? "";
            string statusName = row.Cells["Trạng thái"].Value?.ToString() ?? "";

            lblSelectedInfo.Text = $"Đơn: {reqCode} - {statusName}";
            txtStudentInfo.Text = $"{studentCode} - {fullName} (Lớp: {className}, SĐT: {phone})";
            txtRequestType.Text = row.Cells["Loại yêu cầu"].Value?.ToString() ?? "";
            txtContent.Text = row.Cells["Nội dung yêu cầu"].Value?.ToString() ?? "";
            txtManagerNote.Text = row.Cells["Ghi chú của Quản lý"].Value?.ToString() ?? "";

            bool isPending = (_selectedStatusCode == "Pending");
            btnApprove.Enabled = isPending;
            btnReject.Enabled = isPending;
            txtManagerNote.ReadOnly = !isPending;

            if (_selectedTypeCode == "RegisterRoom" || _selectedTypeCode == "ChangeRoom")
            {
                lblAssignRoom.Visible = true;
                cboAvailableRooms.Visible = true;
                cboAvailableRooms.Enabled = isPending;
            }
            else
            {
                lblAssignRoom.Visible = false;
                cboAvailableRooms.Visible = false;
            }
        }

        private void btnApprove_Click(object? sender, EventArgs e)
        {
            if (_selectedRequestId <= 0 || _selectedStatusCode != "Pending")
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu đang chờ duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int? assignedRoomId = null;
            if (_selectedTypeCode == "RegisterRoom" || _selectedTypeCode == "ChangeRoom")
            {
                if (cboAvailableRooms.SelectedValue == null || !int.TryParse(cboAvailableRooms.SelectedValue.ToString(), out int rId) || rId <= 0)
                {
                    MessageBox.Show("Vui lòng chọn phòng ký túc xá để phân xếp cho sinh viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboAvailableRooms.Focus();
                    return;
                }
                assignedRoomId = rId;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn DUYỆT yêu cầu này không?",
                "Xác nhận duyệt",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string note = txtManagerNote.Text.Trim();
            if (_requestService.ApproveRequest(_selectedRequestId, assignedRoomId, note, out string errMsg))
            {
                MessageBox.Show("Duyệt yêu cầu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAvailableRoomsDropdown();
                ClearDetails();
                LoadRequests();
            }
            else
            {
                MessageBox.Show(errMsg, "Lỗi duyệt yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReject_Click(object? sender, EventArgs e)
        {
            if (_selectedRequestId <= 0 || _selectedStatusCode != "Pending")
            {
                MessageBox.Show("Vui lòng chọn một yêu cầu đang chờ duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string note = txtManagerNote.Text.Trim();
            if (string.IsNullOrWhiteSpace(note))
            {
                MessageBox.Show("Vui lòng nhập lý do từ chối vào ô 'Ghi chú / Lý do phản hồi' để sinh viên nắm được thông tin!", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtManagerNote.Focus();
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn TỪ CHỐI yêu cầu này không?",
                "Xác nhận từ chối",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            if (_requestService.RejectRequest(_selectedRequestId, note, out string errMsg))
            {
                MessageBox.Show("Đã từ chối yêu cầu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearDetails();
                LoadRequests();
            }
            else
            {
                MessageBox.Show(errMsg, "Lỗi từ chối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearDetails();
        }

        private void ClearDetails()
        {
            _selectedRequestId = 0;
            _selectedTypeCode = string.Empty;
            _selectedStatusCode = string.Empty;

            lblSelectedInfo.Text = "Chưa chọn yêu cầu nào";
            txtStudentInfo.Clear();
            txtRequestType.Clear();
            txtContent.Clear();
            txtManagerNote.Clear();
            txtManagerNote.ReadOnly = false;

            lblAssignRoom.Visible = true;
            cboAvailableRooms.Visible = true;
            cboAvailableRooms.Enabled = true;

            btnApprove.Enabled = false;
            btnReject.Enabled = false;
        }

        private void Filter_Changed(object? sender, EventArgs e)
        {
            ClearDetails();
            LoadRequests();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            ClearDetails();
            LoadRequests();
        }

        private void txtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                ClearDetails();
                LoadRequests();
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterStatus.SelectedIndex = 1; // Pending
            cboFilterType.SelectedIndex = 0; // All
            LoadAvailableRoomsDropdown();
            ClearDetails();
            LoadRequests();
        }
    }
}
