namespace QuanLyKtx.Forms.Student
{
    partial class MyRoomForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpRoomInfo;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.TextBox txtBuilding;
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.TextBox txtRoomNumber;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.TextBox txtRoomType;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblOccupancy;
        private System.Windows.Forms.TextBox txtOccupancy;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.TextBox txtStartDate;

        private System.Windows.Forms.GroupBox grpRoommates;
        private System.Windows.Forms.DataGridView dgvRoommates;
        private System.Windows.Forms.Label lblNoRoom;

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
            grpRoomInfo = new System.Windows.Forms.GroupBox();
            txtStartDate = new System.Windows.Forms.TextBox();
            lblStartDate = new System.Windows.Forms.Label();
            txtOccupancy = new System.Windows.Forms.TextBox();
            lblOccupancy = new System.Windows.Forms.Label();
            txtPrice = new System.Windows.Forms.TextBox();
            lblPrice = new System.Windows.Forms.Label();
            txtRoomType = new System.Windows.Forms.TextBox();
            lblRoomType = new System.Windows.Forms.Label();
            txtRoomNumber = new System.Windows.Forms.TextBox();
            lblRoomNumber = new System.Windows.Forms.Label();
            txtBuilding = new System.Windows.Forms.TextBox();
            lblBuilding = new System.Windows.Forms.Label();

            grpRoommates = new System.Windows.Forms.GroupBox();
            dgvRoommates = new System.Windows.Forms.DataGridView();
            lblNoRoom = new System.Windows.Forms.Label();

            grpRoomInfo.SuspendLayout();
            grpRoommates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoommates).BeginInit();
            SuspendLayout();
            // 
            // grpRoomInfo
            // 
            grpRoomInfo.BackColor = System.Drawing.Color.White;
            grpRoomInfo.Controls.Add(txtStartDate);
            grpRoomInfo.Controls.Add(lblStartDate);
            grpRoomInfo.Controls.Add(txtOccupancy);
            grpRoomInfo.Controls.Add(lblOccupancy);
            grpRoomInfo.Controls.Add(txtPrice);
            grpRoomInfo.Controls.Add(lblPrice);
            grpRoomInfo.Controls.Add(txtRoomType);
            grpRoomInfo.Controls.Add(lblRoomType);
            grpRoomInfo.Controls.Add(txtRoomNumber);
            grpRoomInfo.Controls.Add(lblRoomNumber);
            grpRoomInfo.Controls.Add(txtBuilding);
            grpRoomInfo.Controls.Add(lblBuilding);
            grpRoomInfo.Dock = System.Windows.Forms.DockStyle.Top;
            grpRoomInfo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpRoomInfo.ForeColor = System.Drawing.Color.FromArgb(15, 76, 129);
            grpRoomInfo.Location = new System.Drawing.Point(20, 20);
            grpRoomInfo.Name = "grpRoomInfo";
            grpRoomInfo.Size = new System.Drawing.Size(970, 150);
            grpRoomInfo.TabIndex = 0;
            grpRoomInfo.TabStop = false;
            grpRoomInfo.Text = "Thông tin phòng đang ở";
            // 
            // lblBuilding
            // 
            lblBuilding.AutoSize = true;
            lblBuilding.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblBuilding.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblBuilding.Location = new System.Drawing.Point(25, 35);
            lblBuilding.Name = "lblBuilding";
            lblBuilding.Size = new System.Drawing.Size(59, 17);
            lblBuilding.TabIndex = 0;
            lblBuilding.Text = "Tòa nhà:";
            // 
            // txtBuilding
            // 
            txtBuilding.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtBuilding.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtBuilding.Location = new System.Drawing.Point(25, 55);
            txtBuilding.Name = "txtBuilding";
            txtBuilding.ReadOnly = true;
            txtBuilding.Size = new System.Drawing.Size(280, 25);
            txtBuilding.TabIndex = 1;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRoomNumber.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblRoomNumber.Location = new System.Drawing.Point(340, 35);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new System.Drawing.Size(68, 17);
            lblRoomNumber.TabIndex = 2;
            lblRoomNumber.Text = "Số phòng:";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtRoomNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtRoomNumber.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            txtRoomNumber.Location = new System.Drawing.Point(340, 55);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.ReadOnly = true;
            txtRoomNumber.Size = new System.Drawing.Size(280, 25);
            txtRoomNumber.TabIndex = 3;
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRoomType.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblRoomType.Location = new System.Drawing.Point(655, 35);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new System.Drawing.Size(76, 17);
            lblRoomType.TabIndex = 4;
            lblRoomType.Text = "Loại phòng:";
            // 
            // txtRoomType
            // 
            txtRoomType.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtRoomType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtRoomType.Location = new System.Drawing.Point(655, 55);
            txtRoomType.Name = "txtRoomType";
            txtRoomType.ReadOnly = true;
            txtRoomType.Size = new System.Drawing.Size(280, 25);
            txtRoomType.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblPrice.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblPrice.Location = new System.Drawing.Point(25, 90);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new System.Drawing.Size(95, 17);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Giá phòng / kỳ:";
            // 
            // txtPrice
            // 
            txtPrice.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtPrice.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            txtPrice.Location = new System.Drawing.Point(25, 110);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new System.Drawing.Size(280, 25);
            txtPrice.TabIndex = 7;
            // 
            // lblOccupancy
            // 
            lblOccupancy.AutoSize = true;
            lblOccupancy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblOccupancy.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblOccupancy.Location = new System.Drawing.Point(340, 90);
            lblOccupancy.Name = "lblOccupancy";
            lblOccupancy.Size = new System.Drawing.Size(63, 17);
            lblOccupancy.TabIndex = 8;
            lblOccupancy.Text = "Số người:";
            // 
            // txtOccupancy
            // 
            txtOccupancy.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtOccupancy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtOccupancy.Location = new System.Drawing.Point(340, 110);
            txtOccupancy.Name = "txtOccupancy";
            txtOccupancy.ReadOnly = true;
            txtOccupancy.Size = new System.Drawing.Size(280, 25);
            txtOccupancy.TabIndex = 9;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStartDate.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblStartDate.Location = new System.Drawing.Point(655, 90);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new System.Drawing.Size(84, 17);
            lblStartDate.TabIndex = 10;
            lblStartDate.Text = "Ngày vào ở:";
            // 
            // txtStartDate
            // 
            txtStartDate.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtStartDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtStartDate.Location = new System.Drawing.Point(655, 110);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.ReadOnly = true;
            txtStartDate.Size = new System.Drawing.Size(280, 25);
            txtStartDate.TabIndex = 11;
            // 
            // grpRoommates
            // 
            grpRoommates.BackColor = System.Drawing.Color.White;
            grpRoommates.Controls.Add(dgvRoommates);
            grpRoommates.Dock = System.Windows.Forms.DockStyle.Fill;
            grpRoommates.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpRoommates.ForeColor = System.Drawing.Color.FromArgb(15, 76, 129);
            grpRoommates.Location = new System.Drawing.Point(20, 185);
            grpRoommates.Name = "grpRoommates";
            grpRoommates.Padding = new System.Windows.Forms.Padding(12);
            grpRoommates.Size = new System.Drawing.Size(970, 435);
            grpRoommates.TabIndex = 1;
            grpRoommates.TabStop = false;
            grpRoommates.Text = "Danh sách sinh viên cùng phòng";
            // 
            // dgvRoommates
            // 
            dgvRoommates.AllowUserToAddRows = false;
            dgvRoommates.AllowUserToDeleteRows = false;
            dgvRoommates.BackgroundColor = System.Drawing.Color.White;
            dgvRoommates.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvRoommates.ColumnHeadersHeight = 36;
            dgvRoommates.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvRoommates.EnableHeadersVisualStyles = false;
            dgvRoommates.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvRoommates.Location = new System.Drawing.Point(12, 32);
            dgvRoommates.MultiSelect = false;
            dgvRoommates.Name = "dgvRoommates";
            dgvRoommates.ReadOnly = true;
            dgvRoommates.RowHeadersVisible = false;
            dgvRoommates.RowTemplate.Height = 32;
            dgvRoommates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvRoommates.Size = new System.Drawing.Size(946, 391);
            dgvRoommates.TabIndex = 0;
            // 
            // lblNoRoom
            // 
            lblNoRoom.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            lblNoRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblNoRoom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblNoRoom.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblNoRoom.Location = new System.Drawing.Point(20, 20);
            lblNoRoom.Name = "lblNoRoom";
            lblNoRoom.Size = new System.Drawing.Size(970, 60);
            lblNoRoom.TabIndex = 2;
            lblNoRoom.Text = "Hiện tại bạn chưa được phân phòng hoặc chưa có hợp đồng lưu trú còn hiệu lực. Vui lòng vào mục 'Gửi yêu cầu' để đăng ký phòng!";
            lblNoRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblNoRoom.Visible = false;
            // 
            // MyRoomForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 640);
            Controls.Add(lblNoRoom);
            Controls.Add(grpRoommates);
            Controls.Add(grpRoomInfo);
            Name = "MyRoomForm";
            Padding = new System.Windows.Forms.Padding(20);
            Text = "Phòng của tôi";
            Load += MyRoomForm_Load;
            grpRoomInfo.ResumeLayout(false);
            grpRoomInfo.PerformLayout();
            grpRoommates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoommates).EndInit();
            ResumeLayout(false);
        }
    }
}
