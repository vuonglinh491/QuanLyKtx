using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyKtx.Models;
using QuanLyKtx.Services;
using QuanLyKtx.Utils;

namespace QuanLyKtx.Forms.Manager
{
    public partial class ElectricityWaterForm : Form
    {
        private readonly PaymentService _paymentService;
        private readonly RoomService _roomService;
        private int _selectedRecordId = 0;

        public ElectricityWaterForm()
        {
            InitializeComponent();
            _paymentService = new PaymentService();
            _roomService = new RoomService();
        }

        private void ElectricityWaterForm_Load(object? sender, EventArgs e)
        {
            SetupDataGridViewStyle();
            nudMonth.Value = DateTime.Today.Month;
            nudYear.Value = DateTime.Today.Year;
            cboFilterMonth.SelectedIndex = 0;
            cboFilterYear.SelectedIndex = 0;
            LoadRoomDropdown();
            LoadRecords();
        }

        private void SetupDataGridViewStyle()
        {
            dgvElecWater.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvElecWater.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 243, 246);
            dgvElecWater.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvElecWater.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvElecWater.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 238, 255);
            dgvElecWater.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
        }

        private void LoadRoomDropdown()
        {
            try
            {
                var dtRooms = _roomService.GetAllRooms();
                cboRoom.DataSource = dtRooms;
                cboRoom.DisplayMember = "Số phòng";
                cboRoom.ValueMember = "RoomID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục phòng: " + ex.Message);
            }
        }

        private void LoadRecords()
        {
            try
            {
                int? month = null;
                if (cboFilterMonth.SelectedIndex > 0)
                {
                    month = cboFilterMonth.SelectedIndex;
                }

                int? year = null;
                if (cboFilterYear.SelectedIndex > 0 && int.TryParse(cboFilterYear.SelectedItem?.ToString(), out int y))
                {
                    year = y;
                }

                string kw = txtSearch.Text.Trim();

                var table = _paymentService.GetAllElectricityWater(month, year, null, kw);
                dgvElecWater.DataSource = table;

                if (dgvElecWater.Columns["RecordID"] != null) dgvElecWater.Columns["RecordID"].Visible = false;
                if (dgvElecWater.Columns["RoomID"] != null) dgvElecWater.Columns["RoomID"].Visible = false;

                if (dgvElecWater.Columns["Khu nhà"] != null) dgvElecWater.Columns["Khu nhà"].Width = 90;
                if (dgvElecWater.Columns["Số phòng"] != null) dgvElecWater.Columns["Số phòng"].Width = 80;
                if (dgvElecWater.Columns["Tháng"] != null) dgvElecWater.Columns["Tháng"].Width = 55;
                if (dgvElecWater.Columns["Năm"] != null) dgvElecWater.Columns["Năm"].Width = 60;
                if (dgvElecWater.Columns["Điện cũ"] != null) dgvElecWater.Columns["Điện cũ"].Width = 70;
                if (dgvElecWater.Columns["Điện mới"] != null) dgvElecWater.Columns["Điện mới"].Width = 70;
                if (dgvElecWater.Columns["Điện tiêu thụ"] != null) dgvElecWater.Columns["Điện tiêu thụ"].Width = 90;
                if (dgvElecWater.Columns["Tiền điện (đ)"] != null)
                {
                    dgvElecWater.Columns["Tiền điện (đ)"].Width = 100;
                    dgvElecWater.Columns["Tiền điện (đ)"].DefaultCellStyle.Format = "N0";
                }
                if (dgvElecWater.Columns["Nước cũ"] != null) dgvElecWater.Columns["Nước cũ"].Width = 65;
                if (dgvElecWater.Columns["Nước mới"] != null) dgvElecWater.Columns["Nước mới"].Width = 65;
                if (dgvElecWater.Columns["Nước tiêu thụ"] != null) dgvElecWater.Columns["Nước tiêu thụ"].Width = 90;
                if (dgvElecWater.Columns["Tiền nước (đ)"] != null)
                {
                    dgvElecWater.Columns["Tiền nước (đ)"].Width = 95;
                    dgvElecWater.Columns["Tiền nước (đ)"].DefaultCellStyle.Format = "N0";
                }
                if (dgvElecWater.Columns["Tổng tiền (đ)"] != null)
                {
                    dgvElecWater.Columns["Tổng tiền (đ)"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvElecWater.Columns["Tổng tiền (đ)"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu điện nước: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboRoom_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_selectedRecordId == 0 && cboRoom.SelectedValue != null && int.TryParse(cboRoom.SelectedValue.ToString(), out int roomId) && roomId > 0)
            {
                var (lastElectric, lastWater) = _paymentService.GetLatestIndices(roomId);
                txtOldElectric.Text = lastElectric.ToString("F0");
                txtOldWater.Text = lastWater.ToString("F0");
                UpdatePreview();
            }
        }

        private void txtIndices_TextChanged(object? sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            decimal.TryParse(txtOldElectric.Text.Trim(), out decimal oldE);
            decimal.TryParse(txtNewElectric.Text.Trim(), out decimal newE);
            decimal.TryParse(txtOldWater.Text.Trim(), out decimal oldW);
            decimal.TryParse(txtNewWater.Text.Trim(), out decimal newW);

            decimal usedE = newE >= oldE ? newE - oldE : 0;
            decimal usedW = newW >= oldW ? newW - oldW : 0;

            decimal costE = usedE * PaymentService.DON_GIA_DIEN;
            decimal costW = usedW * PaymentService.DON_GIA_NUOC;
            decimal total = costE + costW;

            lblPreviewTotal.Text = $"TẠM TÍNH:\n" +
                                   $"• Điện tiêu thụ: {usedE:N0} kWh = {costE:N0} đ (Đơn giá: {PaymentService.DON_GIA_DIEN:N0} đ)\n" +
                                   $"• Nước tiêu thụ: {usedW:N0} m³ = {costW:N0} đ (Đơn giá: {PaymentService.DON_GIA_NUOC:N0} đ)\n" +
                                   $"• TỔNG TIỀN: {total:N0} đ";
        }

        private void cboFilter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadRecords();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            LoadRecords();
        }

        private void txtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadRecords();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterMonth.SelectedIndex = 0;
            cboFilterYear.SelectedIndex = 0;
            LoadRecords();
            ClearInputForm();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInputs(out ElectricityWater ew)) return;

            if (_paymentService.AddElectricityWater(ew, out string error))
            {
                MessageBox.Show("Ghi nhận chỉ số điện nước thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecords();
                ClearInputForm();
            }
            else
            {
                MessageBox.Show(error, "Lỗi thêm chỉ số", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (_selectedRecordId == 0)
            {
                MessageBox.Show("Vui lòng chọn một bản ghi từ danh sách bên phải để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInputs(out ElectricityWater ew)) return;
            ew.RecordID = _selectedRecordId;

            if (_paymentService.UpdateElectricityWater(ew, out string error))
            {
                MessageBox.Show("Cập nhật chỉ số điện nước thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecords();
                ClearInputForm();
            }
            else
            {
                MessageBox.Show(error, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedRecordId == 0)
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần xóa từ danh sách bên phải!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa bản ghi điện nước này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (_paymentService.DeleteElectricityWater(_selectedRecordId, out string error))
                {
                    MessageBox.Show("Xóa bản ghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();
                    ClearInputForm();
                }
                else
                {
                    MessageBox.Show(error, "Lỗi xóa bản ghi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            ClearInputForm();
        }

        private void dgvElecWater_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvElecWater.Rows.Count) return;

            var row = dgvElecWater.Rows[e.RowIndex];
            if (row.Cells["RecordID"].Value != null)
            {
                _selectedRecordId = Convert.ToInt32(row.Cells["RecordID"].Value);

                if (row.Cells["RoomID"].Value != null)
                {
                    cboRoom.SelectedValue = Convert.ToInt32(row.Cells["RoomID"].Value);
                }

                if (row.Cells["Tháng"].Value != null) nudMonth.Value = Convert.ToInt32(row.Cells["Tháng"].Value);
                if (row.Cells["Năm"].Value != null) nudYear.Value = Convert.ToInt32(row.Cells["Năm"].Value);

                txtOldElectric.Text = Convert.ToDecimal(row.Cells["Điện cũ"].Value).ToString("F0");
                txtNewElectric.Text = Convert.ToDecimal(row.Cells["Điện mới"].Value).ToString("F0");
                txtOldWater.Text = Convert.ToDecimal(row.Cells["Nước cũ"].Value).ToString("F0");
                txtNewWater.Text = Convert.ToDecimal(row.Cells["Nước mới"].Value).ToString("F0");

                UpdatePreview();
            }
        }

        private bool ValidateInputs(out ElectricityWater ew)
        {
            ew = new ElectricityWater();

            if (cboRoom.SelectedValue == null || !int.TryParse(cboRoom.SelectedValue.ToString(), out int roomId) || roomId <= 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cần ghi chỉ số!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRoom.Focus();
                return false;
            }

            if (!decimal.TryParse(txtOldElectric.Text.Trim(), out decimal oldE) || oldE < 0)
            {
                MessageBox.Show("Chỉ số điện cũ phải là số không âm (>= 0)!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldElectric.Focus();
                return false;
            }

            if (!decimal.TryParse(txtNewElectric.Text.Trim(), out decimal newE) || newE < 0)
            {
                MessageBox.Show("Chỉ số điện mới phải là số không âm (>= 0)!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewElectric.Focus();
                return false;
            }

            if (newE < oldE)
            {
                MessageBox.Show("Chỉ số điện mới không được nhỏ hơn chỉ số điện cũ!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewElectric.Focus();
                return false;
            }

            if (!decimal.TryParse(txtOldWater.Text.Trim(), out decimal oldW) || oldW < 0)
            {
                MessageBox.Show("Chỉ số nước cũ phải là số không âm (>= 0)!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldWater.Focus();
                return false;
            }

            if (!decimal.TryParse(txtNewWater.Text.Trim(), out decimal newW) || newW < 0)
            {
                MessageBox.Show("Chỉ số nước mới phải là số không âm (>= 0)!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewWater.Focus();
                return false;
            }

            if (newW < oldW)
            {
                MessageBox.Show("Chỉ số nước mới không được nhỏ hơn chỉ số nước cũ!", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewWater.Focus();
                return false;
            }

            ew.RoomID = roomId;
            ew.Month = (int)nudMonth.Value;
            ew.Year = (int)nudYear.Value;
            ew.OldElectricIndex = oldE;
            ew.NewElectricIndex = newE;
            ew.OldWaterIndex = oldW;
            ew.NewWaterIndex = newW;

            return true;
        }

        private void ClearInputForm()
        {
            _selectedRecordId = 0;
            txtNewElectric.Clear();
            txtNewWater.Clear();
            cboRoom_SelectedIndexChanged(null, EventArgs.Empty);
        }
    }
}
