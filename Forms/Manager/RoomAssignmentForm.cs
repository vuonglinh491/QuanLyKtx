using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyKtx.Services;

namespace QuanLyKtx.Forms.Manager
{
    public partial class RoomAssignmentForm : Form
    {
        private readonly RoomService _roomService;
        private int _selectedAssignmentId = 0;
        private int _selectedRoomId = 0;
        private string _selectedStudentName = string.Empty;
        private string _selectedRoomNumber = string.Empty;
        private string _selectedStatus = string.Empty;

        public RoomAssignmentForm()
        {
            InitializeComponent();
            _roomService = new RoomService();
        }

        private void RoomAssignmentForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            cboFilterStatus.SelectedIndex = 1; // Mặc định lọc "Đang lưu trú (Active)"
            dtpStartDate.Value = DateTime.Today;
            dtpActionDate.Value = DateTime.Today;
            LoadDropdowns();
            LoadAssignments();
        }

        private void SetupDataGridViewStyle()
        {
            dgvAssignments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvAssignments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvAssignments.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvAssignments.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvAssignments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvAssignments.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadDropdowns()
        {
            try
            {
                // Danh sách sinh viên chưa có phòng
                var dtStudents = _roomService.GetStudentsWithoutRoom();
                cboStudent.DataSource = dtStudents;
                cboStudent.DisplayMember = "StudentDisplayName";
                cboStudent.ValueMember = "StudentID";

                // Danh sách phòng còn trống chỗ
                var dtRooms = _roomService.GetAvailableRooms();
                cboRoom.DataSource = dtRooms;
                cboRoom.DisplayMember = "RoomDisplayName";
                cboRoom.ValueMember = "RoomID";

                // Danh sách phòng mới cho tab chuyển phòng
                var dtNewRooms = _roomService.GetAvailableRooms();
                cboNewRoom.DataSource = dtNewRooms;
                cboNewRoom.DisplayMember = "RoomDisplayName";
                cboNewRoom.ValueMember = "RoomID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục chọn phòng: " + ex.Message);
            }
        }

        private void LoadAssignments()
        {
            try
            {
                string? status = null;
                if (cboFilterStatus.SelectedIndex == 1) status = "Active";
                else if (cboFilterStatus.SelectedIndex == 2) status = "Ended";

                string kw = txtSearch.Text.Trim();

                var table = _roomService.GetAllAssignments(status, kw);
                dgvAssignments.DataSource = table;

                if (dgvAssignments.Columns["AssignmentID"] != null) dgvAssignments.Columns["AssignmentID"].Visible = false;
                if (dgvAssignments.Columns["StudentID"] != null) dgvAssignments.Columns["StudentID"].Visible = false;
                if (dgvAssignments.Columns["RoomID"] != null) dgvAssignments.Columns["RoomID"].Visible = false;
                if (dgvAssignments.Columns["StatusCode"] != null) dgvAssignments.Columns["StatusCode"].Visible = false;

                if (dgvAssignments.Columns["Mã SV"] != null) dgvAssignments.Columns["Mã SV"].Width = 85;
                if (dgvAssignments.Columns["Họ và tên"] != null) dgvAssignments.Columns["Họ và tên"].Width = 140;
                if (dgvAssignments.Columns["SĐT"] != null) dgvAssignments.Columns["SĐT"].Width = 100;
                if (dgvAssignments.Columns["Lớp"] != null) dgvAssignments.Columns["Lớp"].Width = 80;
                if (dgvAssignments.Columns["Khu nhà"] != null) dgvAssignments.Columns["Khu nhà"].Width = 100;
                if (dgvAssignments.Columns["Số phòng"] != null) dgvAssignments.Columns["Số phòng"].Width = 80;
                if (dgvAssignments.Columns["Ngày vào ở"] != null) dgvAssignments.Columns["Ngày vào ở"].Width = 95;
                if (dgvAssignments.Columns["Ngày kết thúc"] != null) dgvAssignments.Columns["Ngày kết thúc"].Width = 105;
                if (dgvAssignments.Columns["Trạng thái"] != null) dgvAssignments.Columns["Trạng thái"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phân phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboFilterStatus_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadAssignments();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadAssignments();
        }

        private void txtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadAssignments();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadDropdowns();
            LoadAssignments();
            ResetSelection();
        }

        private void btnAssign_Click(object? sender, EventArgs e)
        {
            if (cboStudent.SelectedValue == null || !int.TryParse(cboStudent.SelectedValue.ToString(), out int studentId) || studentId <= 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần phân phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboRoom.SelectedValue == null || !int.TryParse(cboRoom.SelectedValue.ToString(), out int roomId) || roomId <= 0)
            {
                MessageBox.Show("Vui lòng chọn phòng ở còn trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime startDate = dtpStartDate.Value.Date;

            if (_roomService.AssignRoom(studentId, roomId, startDate, out string error))
            {
                MessageBox.Show("Phân phòng cho sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDropdowns();
                LoadAssignments();
            }
            else
            {
                MessageBox.Show(error, "Lỗi phân phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnChangeRoom_Click(object? sender, EventArgs e)
        {
            if (_selectedAssignmentId == 0)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên đang lưu trú từ bảng bên phải để chuyển phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedStatus != "Active")
            {
                MessageBox.Show("Chỉ có thể chuyển phòng cho sinh viên đang lưu trú (Active)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboNewRoom.SelectedValue == null || !int.TryParse(cboNewRoom.SelectedValue.ToString(), out int newRoomId) || newRoomId <= 0)
            {
                MessageBox.Show("Vui lòng chọn phòng mới cần chuyển đến!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newRoomId == _selectedRoomId)
            {
                MessageBox.Show("Phòng mới chuyển đến phải khác phòng đang ở hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime changeDate = dtpActionDate.Value.Date;

            var confirm = MessageBox.Show(
                $"Xác nhận chuyển phòng cho sinh viên [{_selectedStudentName}] từ phòng {_selectedRoomNumber} sang phòng mới?",
                "Xác nhận chuyển phòng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_roomService.ChangeRoom(_selectedAssignmentId, _selectedRoomId, newRoomId, changeDate, out string error))
                {
                    MessageBox.Show("Chuyển phòng cho sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDropdowns();
                    LoadAssignments();
                    ResetSelection();
                }
                else
                {
                    MessageBox.Show(error, "Lỗi chuyển phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCheckout_Click(object? sender, EventArgs e)
        {
            if (_selectedAssignmentId == 0)
            {
                MessageBox.Show("Vui lòng chọn một sinh viên từ bảng bên phải để thực hiện trả phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedStatus != "Active")
            {
                MessageBox.Show("Bản ghi phân phòng này đã kết thúc trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime endDate = dtpActionDate.Value.Date;

            var confirm = MessageBox.Show(
                $"Xác nhận trả phòng cho sinh viên [{_selectedStudentName}] khỏi phòng {_selectedRoomNumber}?",
                "Xác nhận trả phòng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_roomService.EndAssignment(_selectedAssignmentId, _selectedRoomId, endDate, out string error))
                {
                    MessageBox.Show("Xác nhận trả phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDropdowns();
                    LoadAssignments();
                    ResetSelection();
                }
                else
                {
                    MessageBox.Show(error, "Lỗi trả phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvAssignments_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvAssignments.Rows.Count) return;

            var row = dgvAssignments.Rows[e.RowIndex];
            if (row.Cells["AssignmentID"].Value != null)
            {
                _selectedAssignmentId = Convert.ToInt32(row.Cells["AssignmentID"].Value);
                _selectedRoomId = Convert.ToInt32(row.Cells["RoomID"].Value);
                _selectedStudentName = row.Cells["Họ và tên"].Value?.ToString() ?? string.Empty;
                _selectedRoomNumber = row.Cells["Số phòng"].Value?.ToString() ?? string.Empty;
                _selectedStatus = row.Cells["StatusCode"].Value?.ToString() ?? string.Empty;

                string studentCode = row.Cells["Mã SV"].Value?.ToString() ?? string.Empty;
                string buildingName = row.Cells["Khu nhà"].Value?.ToString() ?? string.Empty;
                string startDate = row.Cells["Ngày vào ở"].Value?.ToString() ?? string.Empty;
                string statusText = row.Cells["Trạng thái"].Value?.ToString() ?? string.Empty;

                lblSelectedInfo.Text = $"SINH VIÊN ĐANG CHỌN:\n" +
                                       $"• Họ tên: {_selectedStudentName} ({studentCode})\n" +
                                       $"• Phòng hiện tại: {_selectedRoomNumber} - {buildingName}\n" +
                                       $"• Ngày vào ở: {startDate}\n" +
                                       $"• Trạng thái: {statusText}";

                // Tự động chuyển sang tab Chuyển / Trả phòng để tiện thao tác
                tabControlAssignment.SelectedTab = tabChange;
            }
        }

        private void ResetSelection()
        {
            _selectedAssignmentId = 0;
            _selectedRoomId = 0;
            _selectedStudentName = string.Empty;
            _selectedRoomNumber = string.Empty;
            _selectedStatus = string.Empty;
            lblSelectedInfo.Text = "Vui lòng chọn một dòng sinh viên đang lưu trú từ bảng danh sách bên phải để thực hiện chuyển phòng hoặc trả phòng.";
        }
    }
}
