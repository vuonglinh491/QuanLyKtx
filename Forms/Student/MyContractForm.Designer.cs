namespace QuanLyKtx.Forms.Student
{
    partial class MyContractForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpActiveContract;
        private System.Windows.Forms.Label lblContractNumber;
        private System.Windows.Forms.TextBox txtContractNumber;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.Label lblRoomPrice;
        private System.Windows.Forms.TextBox txtRoomPrice;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblTerms;
        private System.Windows.Forms.TextBox txtTerms;

        private System.Windows.Forms.GroupBox grpHistory;
        private System.Windows.Forms.DataGridView dgvContracts;
        private System.Windows.Forms.Label lblNoContract;

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
            grpActiveContract = new System.Windows.Forms.GroupBox();
            txtTerms = new System.Windows.Forms.TextBox();
            lblTerms = new System.Windows.Forms.Label();
            txtStatus = new System.Windows.Forms.TextBox();
            lblStatus = new System.Windows.Forms.Label();
            txtDeposit = new System.Windows.Forms.TextBox();
            lblDeposit = new System.Windows.Forms.Label();
            txtRoomPrice = new System.Windows.Forms.TextBox();
            lblRoomPrice = new System.Windows.Forms.Label();
            txtEndDate = new System.Windows.Forms.TextBox();
            lblEndDate = new System.Windows.Forms.Label();
            txtStartDate = new System.Windows.Forms.TextBox();
            lblStartDate = new System.Windows.Forms.Label();
            txtRoom = new System.Windows.Forms.TextBox();
            lblRoom = new System.Windows.Forms.Label();
            txtContractNumber = new System.Windows.Forms.TextBox();
            lblContractNumber = new System.Windows.Forms.Label();

            grpHistory = new System.Windows.Forms.GroupBox();
            dgvContracts = new System.Windows.Forms.DataGridView();
            lblNoContract = new System.Windows.Forms.Label();

            grpActiveContract.SuspendLayout();
            grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContracts).BeginInit();
            SuspendLayout();
            // 
            // grpActiveContract
            // 
            grpActiveContract.BackColor = System.Drawing.Color.White;
            grpActiveContract.Controls.Add(txtTerms);
            grpActiveContract.Controls.Add(lblTerms);
            grpActiveContract.Controls.Add(txtStatus);
            grpActiveContract.Controls.Add(lblStatus);
            grpActiveContract.Controls.Add(txtDeposit);
            grpActiveContract.Controls.Add(lblDeposit);
            grpActiveContract.Controls.Add(txtRoomPrice);
            grpActiveContract.Controls.Add(lblRoomPrice);
            grpActiveContract.Controls.Add(txtEndDate);
            grpActiveContract.Controls.Add(lblEndDate);
            grpActiveContract.Controls.Add(txtStartDate);
            grpActiveContract.Controls.Add(lblStartDate);
            grpActiveContract.Controls.Add(txtRoom);
            grpActiveContract.Controls.Add(lblRoom);
            grpActiveContract.Controls.Add(txtContractNumber);
            grpActiveContract.Controls.Add(lblContractNumber);
            grpActiveContract.Dock = System.Windows.Forms.DockStyle.Top;
            grpActiveContract.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpActiveContract.ForeColor = System.Drawing.Color.FromArgb(15, 76, 129);
            grpActiveContract.Location = new System.Drawing.Point(20, 20);
            grpActiveContract.Name = "grpActiveContract";
            grpActiveContract.Size = new System.Drawing.Size(970, 210);
            grpActiveContract.TabIndex = 0;
            grpActiveContract.TabStop = false;
            grpActiveContract.Text = "Hợp đồng đang có hiệu lực";
            // 
            // lblContractNumber
            // 
            lblContractNumber.AutoSize = true;
            lblContractNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblContractNumber.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblContractNumber.Location = new System.Drawing.Point(25, 30);
            lblContractNumber.Name = "lblContractNumber";
            lblContractNumber.Size = new System.Drawing.Size(86, 17);
            lblContractNumber.TabIndex = 0;
            lblContractNumber.Text = "Số hợp đồng:";
            // 
            // txtContractNumber
            // 
            txtContractNumber.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtContractNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtContractNumber.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            txtContractNumber.Location = new System.Drawing.Point(25, 50);
            txtContractNumber.Name = "txtContractNumber";
            txtContractNumber.ReadOnly = true;
            txtContractNumber.Size = new System.Drawing.Size(210, 25);
            txtContractNumber.TabIndex = 1;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRoom.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblRoom.Location = new System.Drawing.Point(260, 30);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new System.Drawing.Size(68, 17);
            lblRoom.TabIndex = 2;
            lblRoom.Text = "Phòng KTX:";
            // 
            // txtRoom
            // 
            txtRoom.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtRoom.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtRoom.Location = new System.Drawing.Point(260, 50);
            txtRoom.Name = "txtRoom";
            txtRoom.ReadOnly = true;
            txtRoom.Size = new System.Drawing.Size(210, 25);
            txtRoom.TabIndex = 3;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStartDate.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblStartDate.Location = new System.Drawing.Point(495, 30);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new System.Drawing.Size(89, 17);
            lblStartDate.TabIndex = 4;
            lblStartDate.Text = "Ngày bắt đầu:";
            // 
            // txtStartDate
            // 
            txtStartDate.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtStartDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtStartDate.Location = new System.Drawing.Point(495, 50);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.ReadOnly = true;
            txtStartDate.Size = new System.Drawing.Size(210, 25);
            txtStartDate.TabIndex = 5;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblEndDate.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblEndDate.Location = new System.Drawing.Point(730, 30);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new System.Drawing.Size(90, 17);
            lblEndDate.TabIndex = 6;
            lblEndDate.Text = "Ngày kết thúc:";
            // 
            // txtEndDate
            // 
            txtEndDate.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtEndDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtEndDate.Location = new System.Drawing.Point(730, 50);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.ReadOnly = true;
            txtEndDate.Size = new System.Drawing.Size(210, 25);
            txtEndDate.TabIndex = 7;
            // 
            // lblRoomPrice
            // 
            lblRoomPrice.AutoSize = true;
            lblRoomPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblRoomPrice.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblRoomPrice.Location = new System.Drawing.Point(25, 85);
            lblRoomPrice.Name = "lblRoomPrice";
            lblRoomPrice.Size = new System.Drawing.Size(71, 17);
            lblRoomPrice.TabIndex = 8;
            lblRoomPrice.Text = "Tiền phòng:";
            // 
            // txtRoomPrice
            // 
            txtRoomPrice.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtRoomPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtRoomPrice.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            txtRoomPrice.Location = new System.Drawing.Point(25, 105);
            txtRoomPrice.Name = "txtRoomPrice";
            txtRoomPrice.ReadOnly = true;
            txtRoomPrice.Size = new System.Drawing.Size(210, 25);
            txtRoomPrice.TabIndex = 9;
            // 
            // lblDeposit
            // 
            lblDeposit.AutoSize = true;
            lblDeposit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblDeposit.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblDeposit.Location = new System.Drawing.Point(260, 85);
            lblDeposit.Name = "lblDeposit";
            lblDeposit.Size = new System.Drawing.Size(80, 17);
            lblDeposit.TabIndex = 10;
            lblDeposit.Text = "Tiền đặt cọc:";
            // 
            // txtDeposit
            // 
            txtDeposit.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtDeposit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtDeposit.Location = new System.Drawing.Point(260, 105);
            txtDeposit.Name = "txtDeposit";
            txtDeposit.ReadOnly = true;
            txtDeposit.Size = new System.Drawing.Size(210, 25);
            txtDeposit.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblStatus.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblStatus.Location = new System.Drawing.Point(495, 85);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(69, 17);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Trạng thái:";
            // 
            // txtStatus
            // 
            txtStatus.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            txtStatus.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            txtStatus.Location = new System.Drawing.Point(495, 105);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new System.Drawing.Size(210, 25);
            txtStatus.TabIndex = 13;
            // 
            // lblTerms
            // 
            lblTerms.AutoSize = true;
            lblTerms.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblTerms.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTerms.Location = new System.Drawing.Point(25, 140);
            lblTerms.Name = "lblTerms";
            lblTerms.Size = new System.Drawing.Size(126, 17);
            lblTerms.TabIndex = 14;
            lblTerms.Text = "Điều khoản hợp đồng:";
            // 
            // txtTerms
            // 
            txtTerms.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            txtTerms.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtTerms.Location = new System.Drawing.Point(25, 160);
            txtTerms.Multiline = true;
            txtTerms.Name = "txtTerms";
            txtTerms.ReadOnly = true;
            txtTerms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtTerms.Size = new System.Drawing.Size(915, 38);
            txtTerms.TabIndex = 15;
            // 
            // grpHistory
            // 
            grpHistory.BackColor = System.Drawing.Color.White;
            grpHistory.Controls.Add(dgvContracts);
            grpHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            grpHistory.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            grpHistory.ForeColor = System.Drawing.Color.FromArgb(15, 76, 129);
            grpHistory.Location = new System.Drawing.Point(20, 245);
            grpHistory.Name = "grpHistory";
            grpHistory.Padding = new System.Windows.Forms.Padding(12);
            grpHistory.Size = new System.Drawing.Size(970, 375);
            grpHistory.TabIndex = 1;
            grpHistory.TabStop = false;
            grpHistory.Text = "Lịch sử hợp đồng ký túc xá";
            // 
            // dgvContracts
            // 
            dgvContracts.AllowUserToAddRows = false;
            dgvContracts.AllowUserToDeleteRows = false;
            dgvContracts.BackgroundColor = System.Drawing.Color.White;
            dgvContracts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgvContracts.ColumnHeadersHeight = 36;
            dgvContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvContracts.EnableHeadersVisualStyles = false;
            dgvContracts.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dgvContracts.Location = new System.Drawing.Point(12, 32);
            dgvContracts.MultiSelect = false;
            dgvContracts.Name = "dgvContracts";
            dgvContracts.ReadOnly = true;
            dgvContracts.RowHeadersVisible = false;
            dgvContracts.RowTemplate.Height = 32;
            dgvContracts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvContracts.Size = new System.Drawing.Size(946, 331);
            dgvContracts.TabIndex = 0;
            // 
            // lblNoContract
            // 
            lblNoContract.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            lblNoContract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblNoContract.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblNoContract.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblNoContract.Location = new System.Drawing.Point(20, 20);
            lblNoContract.Name = "lblNoContract";
            lblNoContract.Size = new System.Drawing.Size(970, 60);
            lblNoContract.TabIndex = 2;
            lblNoContract.Text = "Bạn chưa có hợp đồng ký túc xá nào trong hệ thống!";
            lblNoContract.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblNoContract.Visible = false;
            // 
            // MyContractForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            ClientSize = new System.Drawing.Size(1010, 640);
            Controls.Add(lblNoContract);
            Controls.Add(grpHistory);
            Controls.Add(grpActiveContract);
            Name = "MyContractForm";
            Padding = new System.Windows.Forms.Padding(20);
            Text = "Hợp đồng của tôi";
            Load += MyContractForm_Load;
            grpActiveContract.ResumeLayout(false);
            grpActiveContract.PerformLayout();
            grpHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvContracts).EndInit();
            ResumeLayout(false);
        }
    }
}
