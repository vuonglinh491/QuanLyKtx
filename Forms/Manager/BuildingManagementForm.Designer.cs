namespace QuanLyKtx.Forms.Manager
{
    partial class BuildingManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblBuildingName;
        private System.Windows.Forms.TextBox txtBuildingName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.NumericUpDown nudCapacity;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvBuildings;

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
            grpInfo = new System.Windows.Forms.GroupBox();
            btnClear = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            txtDescription = new System.Windows.Forms.TextBox();
            lblDescription = new System.Windows.Forms.Label();
            nudCapacity = new System.Windows.Forms.NumericUpDown();
            lblCapacity = new System.Windows.Forms.Label();
            txtBuildingName = new System.Windows.Forms.TextBox();
            lblBuildingName = new System.Windows.Forms.Label();
            grpList = new System.Windows.Forms.GroupBox();
            dgvBuildings = new System.Windows.Forms.DataGridView();
            grpInfo.SuspendLayout();
            grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBuildings).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacity).BeginInit();
            SuspendLayout();
            // 
            // grpInfo
            // 
            grpInfo.BackColor = System.Drawing.Color.White;
            grpInfo.Controls.Add(btnClear);
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnEdit);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(txtDescription);
            grpInfo.Controls.Add(lblDescription);
            grpInfo.Controls.Add(nudCapacity);
            grpInfo.Controls.Add(lblCapacity);
            grpInfo.Controls.Add(txtBuildingName);
            grpInfo.Controls.Add(lblBuildingName);
            grpInfo.Dock = System.Windows.Forms.DockStyle.Left;
            grpInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpInfo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpInfo.Location = new System.Drawing.Point(0, 0);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new System.Windows.Forms.Padding(15);
            grpInfo.Size = new System.Drawing.Size(350, 690);
            grpInfo.TabIndex = 0;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin khu nhà";
            // 
            // btnClear
            // 
            btnClear.BackColor = System.Drawing.Color.FromArgb(240, 243, 246);
            btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClear.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnClear.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnClear.Location = new System.Drawing.Point(180, 310);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(145, 36);
            btnClear.TabIndex = 7;
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
            btnDelete.Location = new System.Drawing.Point(20, 310);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(145, 36);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Xóa khu";
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
            btnEdit.Location = new System.Drawing.Point(180, 260);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(145, 36);
            btnEdit.TabIndex = 5;
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
            btnAdd.Location = new System.Drawing.Point(20, 260);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(145, 36);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtDescription
            // 
            txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtDescription.Location = new System.Drawing.Point(20, 160);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.PlaceholderText = "Mô tả đặc điểm khu nhà (ví dụ: Khu nam, 4 tầng)";
            txtDescription.Size = new System.Drawing.Size(305, 75);
            txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblDescription.Location = new System.Drawing.Point(20, 137);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(46, 17);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Mô tả:";
            // 
            // nudCapacity
            // 
            nudCapacity.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            nudCapacity.Location = new System.Drawing.Point(20, 125);
            nudCapacity.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudCapacity.Name = "nudCapacity";
            nudCapacity.Size = new System.Drawing.Size(305, 25);
            nudCapacity.TabIndex = 2;
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblCapacity.Location = new System.Drawing.Point(20, 102);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new System.Drawing.Size(88, 17);
            lblCapacity.TabIndex = 8;
            lblCapacity.Text = "Sức chứa khu:";
            // 
            // txtBuildingName
            // 
            txtBuildingName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtBuildingName.Location = new System.Drawing.Point(20, 60);
            txtBuildingName.Name = "txtBuildingName";
            txtBuildingName.PlaceholderText = "Ví dụ: Tòa Nhà D";
            txtBuildingName.Size = new System.Drawing.Size(305, 25);
            txtBuildingName.TabIndex = 1;
            // 
            // lblBuildingName
            // 
            lblBuildingName.AutoSize = true;
            lblBuildingName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblBuildingName.Location = new System.Drawing.Point(20, 38);
            lblBuildingName.Name = "lblBuildingName";
            lblBuildingName.Size = new System.Drawing.Size(81, 17);
            lblBuildingName.TabIndex = 0;
            lblBuildingName.Text = "Tên khu nhà:";
            // 
            // grpList
            // 
            grpList.BackColor = System.Drawing.Color.White;
            grpList.Controls.Add(dgvBuildings);
            grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            grpList.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpList.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grpList.Location = new System.Drawing.Point(350, 0);
            grpList.Name = "grpList";
            grpList.Padding = new System.Windows.Forms.Padding(10);
            grpList.Size = new System.Drawing.Size(660, 690);
            grpList.TabIndex = 1;
            grpList.TabStop = false;
            grpList.Text = "Danh sách các khu nhà KTX";
            // 
            // dgvBuildings
            // 
            dgvBuildings.AllowUserToAddRows = false;
            dgvBuildings.AllowUserToDeleteRows = false;
            dgvBuildings.BackgroundColor = System.Drawing.Color.White;
            dgvBuildings.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvBuildings.ColumnHeadersHeight = 36;
            dgvBuildings.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvBuildings.EnableHeadersVisualStyles = false;
            dgvBuildings.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvBuildings.Location = new System.Drawing.Point(10, 29);
            dgvBuildings.MultiSelect = false;
            dgvBuildings.Name = "dgvBuildings";
            dgvBuildings.ReadOnly = true;
            dgvBuildings.RowHeadersVisible = false;
            dgvBuildings.RowTemplate.Height = 32;
            dgvBuildings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvBuildings.Size = new System.Drawing.Size(640, 651);
            dgvBuildings.TabIndex = 0;
            dgvBuildings.CellClick += dgvBuildings_CellClick;
            // 
            // BuildingManagementForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 690);
            Controls.Add(grpList);
            Controls.Add(grpInfo);
            Name = "BuildingManagementForm";
            Text = "Quản lý Khu nhà";
            Load += BuildingManagementForm_Load;
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBuildings).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCapacity).EndInit();
            ResumeLayout(false);
        }
    }
}
