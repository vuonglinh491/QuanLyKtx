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
            grpActiveContract = new GroupBox();
            txtTerms = new TextBox();
            lblTerms = new Label();
            txtStatus = new TextBox();
            lblStatus = new Label();
            txtDeposit = new TextBox();
            lblDeposit = new Label();
            txtRoomPrice = new TextBox();
            lblRoomPrice = new Label();
            txtEndDate = new TextBox();
            lblEndDate = new Label();
            txtStartDate = new TextBox();
            lblStartDate = new Label();
            txtRoom = new TextBox();
            lblRoom = new Label();
            txtContractNumber = new TextBox();
            lblContractNumber = new Label();
            grpHistory = new GroupBox();
            dgvContracts = new DataGridView();
            lblNoContract = new Label();
            grpActiveContract.SuspendLayout();
            grpHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContracts).BeginInit();
            SuspendLayout();
            // 
            // grpActiveContract
            // 
            grpActiveContract.BackColor = Color.White;
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
            grpActiveContract.Dock = DockStyle.Top;
            grpActiveContract.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpActiveContract.ForeColor = Color.FromArgb(15, 76, 129);
            grpActiveContract.Location = new Point(23, 27);
            grpActiveContract.Margin = new Padding(3, 4, 3, 4);
            grpActiveContract.Name = "grpActiveContract";
            grpActiveContract.Padding = new Padding(3, 4, 3, 4);
            grpActiveContract.Size = new Size(1108, 280);
            grpActiveContract.TabIndex = 0;
            grpActiveContract.TabStop = false;
            grpActiveContract.Text = "Hợp đồng đang có hiệu lực";
            // 
            // txtTerms
            // 
            txtTerms.BackColor = Color.FromArgb(245, 247, 250);
            txtTerms.Font = new Font("Segoe UI", 9F);
            txtTerms.Location = new Point(29, 213);
            txtTerms.Margin = new Padding(3, 4, 3, 4);
            txtTerms.Multiline = true;
            txtTerms.Name = "txtTerms";
            txtTerms.ReadOnly = true;
            txtTerms.ScrollBars = ScrollBars.Vertical;
            txtTerms.Size = new Size(1045, 49);
            txtTerms.TabIndex = 15;
            // 
            // lblTerms
            // 
            lblTerms.AutoSize = true;
            lblTerms.Font = new Font("Segoe UI", 9.5F);
            lblTerms.ForeColor = Color.FromArgb(30, 41, 59);
            lblTerms.Location = new Point(29, 187);
            lblTerms.Name = "lblTerms";
            lblTerms.Size = new Size(164, 21);
            lblTerms.TabIndex = 14;
            lblTerms.Text = "Điều khoản hợp đồng:";
            // 
            // txtStatus
            // 
            txtStatus.BackColor = Color.FromArgb(245, 247, 250);
            txtStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtStatus.ForeColor = Color.FromArgb(37, 99, 235);
            txtStatus.Location = new Point(566, 140);
            txtStatus.Margin = new Padding(3, 4, 3, 4);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(239, 30);
            txtStatus.TabIndex = 13;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9.5F);
            lblStatus.ForeColor = Color.FromArgb(30, 41, 59);
            lblStatus.Location = new Point(566, 113);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(82, 21);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Trạng thái:";
            // 
            // txtDeposit
            // 
            txtDeposit.BackColor = Color.FromArgb(245, 247, 250);
            txtDeposit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtDeposit.Location = new Point(297, 140);
            txtDeposit.Margin = new Padding(3, 4, 3, 4);
            txtDeposit.Name = "txtDeposit";
            txtDeposit.ReadOnly = true;
            txtDeposit.Size = new Size(239, 30);
            txtDeposit.TabIndex = 11;
            // 
            // lblDeposit
            // 
            lblDeposit.AutoSize = true;
            lblDeposit.Font = new Font("Segoe UI", 9.5F);
            lblDeposit.ForeColor = Color.FromArgb(30, 41, 59);
            lblDeposit.Location = new Point(297, 113);
            lblDeposit.Name = "lblDeposit";
            lblDeposit.Size = new Size(95, 21);
            lblDeposit.TabIndex = 10;
            lblDeposit.Text = "Tiền đặt cọc:";
            // 
            // txtRoomPrice
            // 
            txtRoomPrice.BackColor = Color.FromArgb(245, 247, 250);
            txtRoomPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtRoomPrice.ForeColor = Color.FromArgb(16, 185, 129);
            txtRoomPrice.Location = new Point(29, 140);
            txtRoomPrice.Margin = new Padding(3, 4, 3, 4);
            txtRoomPrice.Name = "txtRoomPrice";
            txtRoomPrice.ReadOnly = true;
            txtRoomPrice.Size = new Size(239, 30);
            txtRoomPrice.TabIndex = 9;
            // 
            // lblRoomPrice
            // 
            lblRoomPrice.AutoSize = true;
            lblRoomPrice.Font = new Font("Segoe UI", 9.5F);
            lblRoomPrice.ForeColor = Color.FromArgb(30, 41, 59);
            lblRoomPrice.Location = new Point(29, 113);
            lblRoomPrice.Name = "lblRoomPrice";
            lblRoomPrice.Size = new Size(91, 21);
            lblRoomPrice.TabIndex = 8;
            lblRoomPrice.Text = "Tiền phòng:";
            // 
            // txtEndDate
            // 
            txtEndDate.BackColor = Color.FromArgb(245, 247, 250);
            txtEndDate.Font = new Font("Segoe UI", 10F);
            txtEndDate.Location = new Point(834, 67);
            txtEndDate.Margin = new Padding(3, 4, 3, 4);
            txtEndDate.Name = "txtEndDate";
            txtEndDate.ReadOnly = true;
            txtEndDate.Size = new Size(239, 30);
            txtEndDate.TabIndex = 7;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 9.5F);
            lblEndDate.ForeColor = Color.FromArgb(30, 41, 59);
            lblEndDate.Location = new Point(834, 40);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(109, 21);
            lblEndDate.TabIndex = 6;
            lblEndDate.Text = "Ngày kết thúc:";
            // 
            // txtStartDate
            // 
            txtStartDate.BackColor = Color.FromArgb(245, 247, 250);
            txtStartDate.Font = new Font("Segoe UI", 10F);
            txtStartDate.Location = new Point(566, 67);
            txtStartDate.Margin = new Padding(3, 4, 3, 4);
            txtStartDate.Name = "txtStartDate";
            txtStartDate.ReadOnly = true;
            txtStartDate.Size = new Size(239, 30);
            txtStartDate.TabIndex = 5;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 9.5F);
            lblStartDate.ForeColor = Color.FromArgb(30, 41, 59);
            lblStartDate.Location = new Point(566, 40);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(106, 21);
            lblStartDate.TabIndex = 4;
            lblStartDate.Text = "Ngày bắt đầu:";
            // 
            // txtRoom
            // 
            txtRoom.BackColor = Color.FromArgb(245, 247, 250);
            txtRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtRoom.Location = new Point(297, 67);
            txtRoom.Margin = new Padding(3, 4, 3, 4);
            txtRoom.Name = "txtRoom";
            txtRoom.ReadOnly = true;
            txtRoom.Size = new Size(239, 30);
            txtRoom.TabIndex = 3;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 9.5F);
            lblRoom.ForeColor = Color.FromArgb(30, 41, 59);
            lblRoom.Location = new Point(297, 40);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(88, 21);
            lblRoom.TabIndex = 2;
            lblRoom.Text = "Phòng KTX:";
            // 
            // txtContractNumber
            // 
            txtContractNumber.BackColor = Color.FromArgb(245, 247, 250);
            txtContractNumber.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtContractNumber.ForeColor = Color.FromArgb(37, 99, 235);
            txtContractNumber.Location = new Point(29, 67);
            txtContractNumber.Margin = new Padding(3, 4, 3, 4);
            txtContractNumber.Name = "txtContractNumber";
            txtContractNumber.ReadOnly = true;
            txtContractNumber.Size = new Size(239, 30);
            txtContractNumber.TabIndex = 1;
            // 
            // lblContractNumber
            // 
            lblContractNumber.AutoSize = true;
            lblContractNumber.Font = new Font("Segoe UI", 9.5F);
            lblContractNumber.ForeColor = Color.FromArgb(30, 41, 59);
            lblContractNumber.Location = new Point(29, 40);
            lblContractNumber.Name = "lblContractNumber";
            lblContractNumber.Size = new Size(103, 21);
            lblContractNumber.TabIndex = 0;
            lblContractNumber.Text = "Số hợp đồng:";
            // 
            // grpHistory
            // 
            grpHistory.BackColor = Color.White;
            grpHistory.Controls.Add(dgvContracts);
            grpHistory.Dock = DockStyle.Fill;
            grpHistory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpHistory.ForeColor = Color.FromArgb(15, 76, 129);
            grpHistory.Location = new Point(23, 307);
            grpHistory.Margin = new Padding(3, 4, 3, 4);
            grpHistory.Name = "grpHistory";
            grpHistory.Padding = new Padding(14, 16, 14, 16);
            grpHistory.Size = new Size(1108, 519);
            grpHistory.TabIndex = 1;
            grpHistory.TabStop = false;
            grpHistory.Text = "Lịch sử hợp đồng ký túc xá";
            // 
            // dgvContracts
            // 
            dgvContracts.AllowUserToAddRows = false;
            dgvContracts.AllowUserToDeleteRows = false;
            dgvContracts.BackgroundColor = Color.White;
            dgvContracts.BorderStyle = BorderStyle.Fixed3D;
            dgvContracts.ColumnHeadersHeight = 36;
            dgvContracts.Dock = DockStyle.Fill;
            dgvContracts.EnableHeadersVisualStyles = false;
            dgvContracts.Font = new Font("Segoe UI", 9.5F);
            dgvContracts.Location = new Point(14, 41);
            dgvContracts.Margin = new Padding(3, 4, 3, 4);
            dgvContracts.MultiSelect = false;
            dgvContracts.Name = "dgvContracts";
            dgvContracts.ReadOnly = true;
            dgvContracts.RowHeadersVisible = false;
            dgvContracts.RowHeadersWidth = 51;
            dgvContracts.RowTemplate.Height = 32;
            dgvContracts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContracts.Size = new Size(1080, 462);
            dgvContracts.TabIndex = 0;
            dgvContracts.CellContentClick += dgvContracts_CellContentClick;
            // 
            // lblNoContract
            // 
            lblNoContract.BackColor = Color.FromArgb(254, 242, 242);
            lblNoContract.BorderStyle = BorderStyle.FixedSingle;
            lblNoContract.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblNoContract.ForeColor = Color.FromArgb(220, 38, 38);
            lblNoContract.Location = new Point(23, 27);
            lblNoContract.Name = "lblNoContract";
            lblNoContract.Size = new Size(1108, 79);
            lblNoContract.TabIndex = 2;
            lblNoContract.Text = "Bạn chưa có hợp đồng ký túc xá nào trong hệ thống!";
            lblNoContract.TextAlign = ContentAlignment.MiddleCenter;
            lblNoContract.Visible = false;
            // 
            // MyContractForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1154, 853);
            Controls.Add(lblNoContract);
            Controls.Add(grpHistory);
            Controls.Add(grpActiveContract);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MyContractForm";
            Padding = new Padding(23, 27, 23, 27);
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
