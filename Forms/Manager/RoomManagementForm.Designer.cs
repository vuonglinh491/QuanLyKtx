namespace QuanLyKtx.Forms.Manager
{
    partial class RoomManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilterBuilding;
        private System.Windows.Forms.ComboBox cboFilterBuilding;
        private System.Windows.Forms.Label lblFilterStatus;
        private System.Windows.Forms.ComboBox cboFilterStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.ComboBox cboBuilding;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.TextBox txtCapacity;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.ComboBox cboRoomType;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvRooms;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlFilter = new System.Windows.Forms.Panel();
            btnRefresh = new System.Windows.Forms.Button();
            btnSearch = new System.Windows.Forms.Button();
            txtSearch = new System.Windows.Forms.TextBox();
            cboFilterStatus = new System.Windows.Forms.ComboBox();
            lblFilterStatus = new System.Windows.Forms.Label();
            cboFilterBuilding = new System.Windows.Forms.ComboBox();
            lblFilterBuilding = new System.Windows.Forms.Label();
            grpInfo = new System.Windows.Forms.GroupBox();
            btnClear = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            cboStatus = new System.Windows.Forms.ComboBox();
            lblStatus = new System.Windows.Forms.Label();
            txtPrice = new System.Windows.Forms.TextBox();
            lblPrice = new System.Windows.Forms.Label();
            cboRoomType = new System.Windows.Forms.ComboBox();
            lblRoomType = new System.Windows.Forms.Label();
            txtCapacity = new System.Windows.Forms.TextBox();
            lblCapacity = new System.Windows.Forms.Label();
            txtFloor = new System.Windows.Forms.TextBox();
            lblFloor = new System.Windows.Forms.Label();
            txtRoomNumber = new System.Windows.Forms.TextBox();
            lblRoomNumber = new System.Windows.Forms.Label();
            cboBuilding = new System.Windows.Forms.ComboBox();
            lblBuilding = new System.Windows.Forms.Label();
            grpList = new System.Windows.Forms.GroupBox();
            dgvRooms = new System.Windows.Forms.DataGridView();
            pnlFilter.SuspendLayout();
            grpInfo.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = System.Drawing.Color.White;
            pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlFilter.Controls.Add(btnRefresh);
            pnlFilter.Controls.Add(btnSearch);
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(cboFilterStatus);
            pnlFilter.Controls.Add(lblFilterStatus);
            pnlFilter.Controls.Add(cboFilterBuilding);
            pnlFilter.Controls.Add(lblFilterBuilding);
            pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFilter.Location = new System.Drawing.Point(0, 0);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new System.Drawing.Size(1010, 56);
            pnlFilter.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnRefresh.Location = new System.Drawing.Point(885, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(95, 30);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.FromArgb(24, 119, 242);
            btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(780, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(95, 30);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtSearch.Location = new System.Drawing.Point(540, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập số phòng (vd: A101)...";
            txtSearch.Size = new System.Drawing.Size(225, 24);
            txtSearch.TabIndex = 4;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // cboFilterStatus
            // 
            cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterStatus.FormattingEnabled = true;
            cboFilterStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Còn chỗ (Available)", "Đầy phòng (Full)", "Bảo trì (Maintenance)" });
            cboFilterStatus.Location = new System.Drawing.Point(365, 15);
            cboFilterStatus.Name = "cboFilterStatus";
            cboFilterStatus.Size = new System.Drawing.Size(160, 24);
            cboFilterStatus.TabIndex = 3;
            cboFilterStatus.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // lblFilterStatus
            // 
            lblFilterStatus.AutoSize = true;
            lblFilterStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblFilterStatus.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFilterStatus.Location = new System.Drawing.Point(285, 18);
            lblFilterStatus.Name = "lblFilterStatus";
            lblFilterStatus.Size = new System.Drawing.Size(75, 17);
            lblFilterStatus.TabIndex = 2;
            lblFilterStatus.Text = "Trạng thái:";
            // 
            // cboFilterBuilding
            // 
            cboFilterBuilding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFilterBuilding.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFilterBuilding.FormattingEnabled = true;
            cboFilterBuilding.Location = new System.Drawing.Point(95, 15);
            cboFilterBuilding.Name = "cboFilterBuilding";
            cboFilterBuilding.Size = new System.Drawing.Size(175, 24);
            cboFilterBuilding.TabIndex = 1;
            cboFilterBuilding.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            // 
            // lblFilterBuilding
            // 
            lblFilterBuilding.AutoSize = true;
            lblFilterBuilding.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblFilterBuilding.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFilterBuilding.Location = new System.Drawing.Point(20, 18);
            lblFilterBuilding.Name = "lblFilterBuilding";
            lblFilterBuilding.Size = new System.Drawing.Size(69, 17);
            lblFilterBuilding.TabIndex = 0;
            lblFilterBuilding.Text = "Khu nhà:";
            // 
            // grpInfo
            // 
            grpInfo.BackColor = System.Drawing.Color.White;
            grpInfo.Controls.Add(btnClear);
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnEdit);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(cboStatus);
            grpInfo.Controls.Add(lblStatus);
            grpInfo.Controls.Add(txtPrice);
            grpInfo.Controls.Add(lblPrice);
            grpInfo.Controls.Add(cboRoomType);
            grpInfo.Controls.Add(lblRoomType);
            grpInfo.Controls.Add(txtCapacity);
            grpInfo.Controls.Add(lblCapacity);
            grpInfo.Controls.Add(txtFloor);
            grpInfo.Controls.Add(lblFloor);
            grpInfo.Controls.Add(txtRoomNumber);
            grpInfo.Controls.Add(lblRoomNumber);
            grpInfo.Controls.Add(cboBuilding);
            grpInfo.Controls.Add(lblBuilding);
            grpInfo.Dock = System.Windows.Forms.DockStyle.Left;
            grpInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpInfo.Location = new System.Drawing.Point(0, 56);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new System.Windows.Forms.Padding(12);
            grpInfo.Size = new System.Drawing.Size(340, 634);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin phòng ở";
            // 
            // btnClear
            // 
            btnClear.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnClear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnClear.Location = new System.Drawing.Point(175, 485);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(145, 36);
            btnClear.TabIndex = 17;
            btnClear.Text = "Xóa trắng";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.Location = new System.Drawing.Point(20, 485);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(145, 36);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Xóa phòng";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnEdit.ForeColor = System.Drawing.Color.White;
            btnEdit.Location = new System.Drawing.Point(175, 440);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(145, 36);
            btnEdit.TabIndex = 15;
            btnEdit.Text = "Cập nhật";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.Location = new System.Drawing.Point(20, 440);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(145, 36);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Còn chỗ (Available)", "Đầy phòng (Full)", "Bảo trì (Maintenance)" });
            cboStatus.Location = new System.Drawing.Point(20, 390);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new System.Drawing.Size(300, 24);
            cboStatus.TabIndex = 13;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStatus.Location = new System.Drawing.Point(20, 368);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(69, 17);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Trạng thái:";
            // 
            // txtPrice
            // 
            txtPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtPrice.Location = new System.Drawing.Point(20, 335);
            txtPrice.Name = "txtPrice";
            txtPrice.PlaceholderText = "Ví dụ: 600000";
            txtPrice.Size = new System.Drawing.Size(300, 24);
            txtPrice.TabIndex = 11;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblPrice.Location = new System.Drawing.Point(20, 313);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new System.Drawing.Size(126, 17);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "Giá thuê/tháng (đ):";
            // 
            // cboRoomType
            // 
            cboRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboRoomType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboRoomType.FormattingEnabled = true;
            cboRoomType.Items.AddRange(new object[] { "Tiêu chuẩn", "Chất lượng cao", "VIP" });
            cboRoomType.Location = new System.Drawing.Point(20, 280);
            cboRoomType.Name = "cboRoomType";
            cboRoomType.Size = new System.Drawing.Size(300, 24);
            cboRoomType.TabIndex = 9;
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRoomType.Location = new System.Drawing.Point(20, 258);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new System.Drawing.Size(76, 17);
            lblRoomType.TabIndex = 8;
            lblRoomType.Text = "Loại phòng:";
            // 
            // txtCapacity
            // 
            txtCapacity.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtCapacity.Location = new System.Drawing.Point(20, 225);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.PlaceholderText = "Ví dụ: 4 hoặc 8";
            txtCapacity.Size = new System.Drawing.Size(300, 24);
            txtCapacity.TabIndex = 7;
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblCapacity.Location = new System.Drawing.Point(20, 203);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new System.Drawing.Size(123, 17);
            lblCapacity.TabIndex = 6;
            lblCapacity.Text = "Sức chứa (người):";
            // 
            // txtFloor
            // 
            txtFloor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtFloor.Location = new System.Drawing.Point(20, 170);
            txtFloor.Name = "txtFloor";
            txtFloor.PlaceholderText = "Ví dụ: 1, 2, 3...";
            txtFloor.Size = new System.Drawing.Size(300, 24);
            txtFloor.TabIndex = 5;
            // 
            // lblFloor
            // 
            lblFloor.AutoSize = true;
            lblFloor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblFloor.Location = new System.Drawing.Point(20, 148);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new System.Drawing.Size(41, 17);
            lblFloor.TabIndex = 4;
            lblFloor.Text = "Tầng:";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtRoomNumber.Location = new System.Drawing.Point(20, 115);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.PlaceholderText = "Ví dụ: A101, B203...";
            txtRoomNumber.Size = new System.Drawing.Size(300, 24);
            txtRoomNumber.TabIndex = 3;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRoomNumber.Location = new System.Drawing.Point(20, 93);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new System.Drawing.Size(66, 17);
            lblRoomNumber.TabIndex = 2;
            lblRoomNumber.Text = "Số phòng:";
            // 
            // cboBuilding
            // 
            cboBuilding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboBuilding.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboBuilding.FormattingEnabled = true;
            cboBuilding.Location = new System.Drawing.Point(20, 60);
            cboBuilding.Name = "cboBuilding";
            cboBuilding.Size = new System.Drawing.Size(300, 24);
            cboBuilding.TabIndex = 1;
            // 
            // lblBuilding
            // 
            lblBuilding.AutoSize = true;
            lblBuilding.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblBuilding.Location = new System.Drawing.Point(20, 38);
            lblBuilding.Name = "lblBuilding";
            lblBuilding.Size = new System.Drawing.Size(95, 17);
            lblBuilding.TabIndex = 0;
            lblBuilding.Text = "Thuộc khu nhà:";
            // 
            // grpList
            // 
            grpList.BackColor = System.Drawing.Color.White;
            grpList.Controls.Add(dgvRooms);
            grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            grpList.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpList.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpList.Location = new System.Drawing.Point(340, 56);
            grpList.Name = "grpList";
            grpList.Padding = new System.Windows.Forms.Padding(10);
            grpList.Size = new System.Drawing.Size(670, 634);
            grpList.TabIndex = 2;
            grpList.TabStop = false;
            grpList.Text = "Danh sách phòng KTX";
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.BackgroundColor = System.Drawing.Color.White;
            dgvRooms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvRooms.ColumnHeadersHeight = 36;
            dgvRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvRooms.EnableHeadersVisualStyles = false;
            dgvRooms.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvRooms.Location = new System.Drawing.Point(10, 29);
            dgvRooms.MultiSelect = false;
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.RowTemplate.Height = 32;
            dgvRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new System.Drawing.Size(650, 595);
            dgvRooms.TabIndex = 0;
            dgvRooms.CellClick += dgvRooms_CellClick;
            // 
            // RoomManagementForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 690);
            Controls.Add(grpList);
            Controls.Add(grpInfo);
            Controls.Add(pnlFilter);
            Name = "RoomManagementForm";
            Text = "Quản lý Phòng";
            Load += RoomManagementForm_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            ResumeLayout(false);
        }
    }
}
