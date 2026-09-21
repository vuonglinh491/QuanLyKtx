using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyKtx.Models;
using QuanLyKtx.Services;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Manager
{
    public partial class BuildingManagementForm : Form
    {
        private readonly RoomService _roomService;
        private int _selectedBuildingId = 0;

        public BuildingManagementForm()
        {
            InitializeComponent();
            _roomService = new RoomService();
        }

        private void BuildingManagementForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            LoadBuildings();
        }

        private void SetupDataGridViewStyle()
        {
            DataGridViewHelper.Configure(dgvBuildings);
            ScrollableControlHelper.Configure(grpInfo);
            dgvBuildings.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvBuildings.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvBuildings.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvBuildings.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvBuildings.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvBuildings.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadBuildings()
        {
            try
            {
                var table = _roomService.GetAllBuildings();
                dgvBuildings.DataSource = table;

                if (dgvBuildings.Columns["Mã khu"] != null) dgvBuildings.Columns["Mã khu"].Width = 80;
                if (dgvBuildings.Columns["Tên khu nhà"] != null) dgvBuildings.Columns["Tên khu nhà"].Width = 150;
                if (dgvBuildings.Columns["Sức chứa khu"] != null) dgvBuildings.Columns["Sức chứa khu"].Width = 100;
                if (dgvBuildings.Columns["Tổng số phòng"] != null) dgvBuildings.Columns["Tổng số phòng"].Width = 110;
                if (dgvBuildings.Columns["Đang ở"] != null) dgvBuildings.Columns["Đang ở"].Width = 90;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khu nhà: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidationHelper.IsNotEmpty(txtBuildingName.Text, "Tên khu nhà", out string err))
            {
                MessageBox.Show(err, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuildingName.Focus();
                return;
            }

            var building = new Building
            {
                BuildingName = txtBuildingName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Capacity = (int)nudCapacity.Value
            };

            if (_roomService.AddBuilding(building, out string error))
            {
                MessageBox.Show("Thêm mới khu nhà thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBuildings();
                ClearInputForm();
            }
            else
            {
                MessageBox.Show(error, "Lỗi thêm khu nhà", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (_selectedBuildingId == 0)
            {
                MessageBox.Show("Vui lòng chọn một khu nhà từ danh sách để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidationHelper.IsNotEmpty(txtBuildingName.Text, "Tên khu nhà", out string err))
            {
                MessageBox.Show(err, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuildingName.Focus();
                return;
            }

            var building = new Building
            {
                BuildingID = _selectedBuildingId,
                BuildingName = txtBuildingName.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Capacity = (int)nudCapacity.Value
            };

            if (_roomService.UpdateBuilding(building, out string error))
            {
                MessageBox.Show("Cập nhật khu nhà thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBuildings();
                ClearInputForm();
            }
            else
            {
                MessageBox.Show(error, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedBuildingId == 0)
            {
                MessageBox.Show("Vui lòng chọn khu nhà cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khu nhà [{txtBuildingName.Text}] không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_roomService.DeleteBuilding(_selectedBuildingId, out string error))
                {
                    MessageBox.Show("Xóa khu nhà thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBuildings();
                    ClearInputForm();
                }
                else
                {
                    MessageBox.Show(error, "Lỗi xóa khu nhà", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearInputForm();
        }

        private void dgvBuildings_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvBuildings.Rows.Count) return;

            var row = dgvBuildings.Rows[e.RowIndex];
            if (row.Cells["Mã khu"].Value != null)
            {
                _selectedBuildingId = Convert.ToInt32(row.Cells["Mã khu"].Value);
                txtBuildingName.Text = row.Cells["Tên khu nhà"].Value?.ToString() ?? string.Empty;
                txtDescription.Text = row.Cells["Mô tả"].Value?.ToString() ?? string.Empty;
                if (row.Cells["Sức chứa khu"].Value != null && row.Cells["Sức chứa khu"].Value != DBNull.Value)
                {
                    nudCapacity.Value = Convert.ToDecimal(row.Cells["Sức chứa khu"].Value);
                }
            }
        }

        private void ClearInputForm()
        {
            _selectedBuildingId = 0;
            txtBuildingName.Clear();
            txtDescription.Clear();
            nudCapacity.Value = 0;
            txtBuildingName.Focus();
        }
    }
}
