using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyKtx.Models;
using QuanLyKtx.Services;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Manager
{
    public partial class RoomManagementForm : Form
    {
        private readonly RoomService _roomService;
        private int _selectedRoomId = 0;
        private int _currentOccupancyOfSelected = 0;

        public RoomManagementForm()
        {
            InitializeComponent();
            _roomService = new RoomService();
        }

        private void RoomManagementForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            LoadBuildingCombos();
            cboRoomType.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            cboFilterStatus.SelectedIndex = 0;
            LoadRooms();
        }

        private void SetupDataGridViewStyle()
        {
            dgvRooms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvRooms.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvRooms.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvRooms.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvRooms.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvRooms.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadBuildingCombos()
        {
            try
            {
                var dtBuildings = _roomService.GetAllBuildings();

                // Nạp cho ComboBox nhập liệu bên trái
                cboBuilding.DataSource = dtBuildings.Copy();
                cboBuilding.DisplayMember = "Tên khu nhà";
                cboBuilding.ValueMember = "Mã khu";

                // Nạp cho ComboBox lọc trên thanh công cụ
                var dtFilter = dtBuildings.Copy();
                var allRow = dtFilter.NewRow();
                allRow["Mã khu"] = 0;
                allRow["Tên khu nhà"] = "Tất cả khu nhà";
                dtFilter.Rows.InsertAt(allRow, 0);

                cboFilterBuilding.DataSource = dtFilter;
                cboFilterBuilding.DisplayMember = "Tên khu nhà";
                cboFilterBuilding.ValueMember = "Mã khu";
                cboFilterBuilding.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục khu nhà: " + ex.Message);
            }
        }

        private void LoadRooms()
        {
            try
            {
                int? buildingId = null;
                if (cboFilterBuilding.SelectedValue != null && int.TryParse(cboFilterBuilding.SelectedValue.ToString(), out int bId) && bId > 0)
                {
                    buildingId = bId;
                }

                string? status = null;
                if (cboFilterStatus.SelectedIndex == 1) status = "Available";
                else if (cboFilterStatus.SelectedIndex == 2) status = "Full";
                else if (cboFilterStatus.SelectedIndex == 3) status = "Maintenance";

                string kw = txtSearch.Text.Trim();

                var table = _roomService.GetAllRooms(buildingId, status, kw);
                dgvRooms.DataSource = table;

                // Ẩn cột ID và mã StatusCode ẩn
                if (dgvRooms.Columns["RoomID"] != null) dgvRooms.Columns["RoomID"].Visible = false;
                if (dgvRooms.Columns["BuildingID"] != null) dgvRooms.Columns["BuildingID"].Visible = false;
                if (dgvRooms.Columns["StatusCode"] != null) dgvRooms.Columns["StatusCode"].Visible = false;

                // Căn chỉnh độ rộng cột
                if (dgvRooms.Columns["Khu nhà"] != null) dgvRooms.Columns["Khu nhà"].Width = 110;
                if (dgvRooms.Columns["Số phòng"] != null) dgvRooms.Columns["Số phòng"].Width = 85;
                if (dgvRooms.Columns["Tầng"] != null) dgvRooms.Columns["Tầng"].Width = 60;
                if (dgvRooms.Columns["Sức chứa"] != null) dgvRooms.Columns["Sức chứa"].Width = 80;
                if (dgvRooms.Columns["Đang ở"] != null) dgvRooms.Columns["Đang ở"].Width = 75;
                if (dgvRooms.Columns["Loại phòng"] != null) dgvRooms.Columns["Loại phòng"].Width = 110;
                if (dgvRooms.Columns["Giá thuê (VNĐ)"] != null)
                {
                    dgvRooms.Columns["Giá thuê (VNĐ)"].Width = 120;
                    dgvRooms.Columns["Giá thuê (VNĐ)"].DefaultCellStyle.Format = "N0";
                }
                if (dgvRooms.Columns["Trạng thái"] != null) dgvRooms.Columns["Trạng thái"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboFilter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadRooms();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadRooms();
        }

        private void txtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadRooms();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterBuilding.SelectedIndex = 0;
            cboFilterStatus.SelectedIndex = 0;
            LoadRooms();
            ClearInputForm();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs(out Room room)) return;

            if (_roomService.AddRoom(room, out string error))
            {
                MessageBox.Show($"Thêm mới phòng {room.RoomNumber} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRooms();
                ClearInputForm();
            }
            else
            {
                MessageBox.Show(error, "Lỗi thêm phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (_selectedRoomId == 0)
            {
                MessageBox.Show("Vui lòng chọn một phòng từ bảng danh sách bên phải để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInputs(out Room room)) return;
            room.RoomID = _selectedRoomId;
            room.CurrentOccupancy = _currentOccupancyOfSelected;

            if (_roomService.UpdateRoom(room, out string error))
            {
                MessageBox.Show("Cập nhật thông tin phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRooms();
                ClearInputForm();
            }
            else
            {
                MessageBox.Show(error, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedRoomId == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa từ bảng danh sách bên phải!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa phòng [{txtRoomNumber.Text}] không?",
                "Xác nhận xóa phòng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_roomService.DeleteRoom(_selectedRoomId, out string error))
                {
                    MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms();
                    ClearInputForm();
                }
                else
                {
                    MessageBox.Show(error, "Lỗi xóa phòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearInputForm();
        }

        private void dgvRooms_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRooms.Rows.Count) return;

            var row = dgvRooms.Rows[e.RowIndex];
            if (row.Cells["RoomID"].Value != null)
            {
                _selectedRoomId = Convert.ToInt32(row.Cells["RoomID"].Value);
                _currentOccupancyOfSelected = Convert.ToInt32(row.Cells["Đang ở"].Value);

                if (row.Cells["BuildingID"].Value != null)
                {
                    cboBuilding.SelectedValue = Convert.ToInt32(row.Cells["BuildingID"].Value);
                }

                txtRoomNumber.Text = row.Cells["Số phòng"].Value?.ToString() ?? string.Empty;
                txtFloor.Text = row.Cells["Tầng"].Value?.ToString() ?? "1";
                txtCapacity.Text = row.Cells["Sức chứa"].Value?.ToString() ?? "4";

                string rType = row.Cells["Loại phòng"].Value?.ToString() ?? "Tiêu chuẩn";
                cboRoomType.SelectedItem = rType;

                if (row.Cells["Giá thuê (VNĐ)"].Value != null)
                {
                    txtPrice.Text = Convert.ToDecimal(row.Cells["Giá thuê (VNĐ)"].Value).ToString("F0");
                }

                string statusCode = row.Cells["StatusCode"].Value?.ToString() ?? "Available";
                if (statusCode == "Available") cboStatus.SelectedIndex = 0;
                else if (statusCode == "Full") cboStatus.SelectedIndex = 1;
                else if (statusCode == "Maintenance") cboStatus.SelectedIndex = 2;
            }
        }

        private bool ValidateInputs(out Room room)
        {
            room = new Room();

            if (cboBuilding.SelectedValue == null || !int.TryParse(cboBuilding.SelectedValue.ToString(), out int buildingId) || buildingId <= 0)
            {
                MessageBox.Show("Vui lòng chọn khu nhà hợp lệ!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboBuilding.Focus();
                return false;
            }

            if (!ValidationHelper.IsNotEmpty(txtRoomNumber.Text, "Số phòng", out string errRoom))
            {
                MessageBox.Show(errRoom, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRoomNumber.Focus();
                return false;
            }

            if (!int.TryParse(txtFloor.Text.Trim(), out int floor) || floor <= 0)
            {
                MessageBox.Show("Tầng phải là một số nguyên dương (> 0)!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFloor.Focus();
                return false;
            }

            if (!int.TryParse(txtCapacity.Text.Trim(), out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Sức chứa phòng phải là một số nguyên dương (> 0)!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCapacity.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price < 0)
            {
                MessageBox.Show("Giá thuê phòng phải là số không âm (>= 0)!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            string status = "Available";
            if (cboStatus.SelectedIndex == 1) status = "Full";
            else if (cboStatus.SelectedIndex == 2) status = "Maintenance";

            room.BuildingID = buildingId;
            room.RoomNumber = txtRoomNumber.Text.Trim().ToUpper();
            room.Floor = floor;
            room.Capacity = capacity;
            room.RoomType = cboRoomType.SelectedItem?.ToString() ?? "Tiêu chuẩn";
            room.Price = price;
            room.Status = status;

            return true;
        }

        private void ClearInputForm()
        {
            _selectedRoomId = 0;
            _currentOccupancyOfSelected = 0;
            txtRoomNumber.Clear();
            txtFloor.Text = "1";
            txtCapacity.Text = "4";
            txtPrice.Clear();
            cboRoomType.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            txtRoomNumber.Focus();
        }
    }
}
