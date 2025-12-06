namespace BANK_SYSTEM
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Label lblWelcome;
        private Label lblBalance;
        private Label lblAccountNumber;
        private DataGridView dgvTransactions;
        private Button btnDeposit;
        private Button btnWithdraw;
        private Button btnTransfer;
        private Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            mainPanel = new Panel();
            lblWelcome = new Label();
            lblBalance = new Label();
            lblAccountNumber = new Label();
            dgvTransactions = new DataGridView();
            btnDeposit = new Button();
            btnWithdraw = new Button();
            btnTransfer = new Button();
            btnLogout = new Button();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(30, 30, 30);
            mainPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(lblWelcome);
            mainPanel.Controls.Add(lblBalance);
            mainPanel.Controls.Add(lblAccountNumber);
            mainPanel.Controls.Add(dgvTransactions);
            mainPanel.Controls.Add(btnDeposit);
            mainPanel.Controls.Add(btnWithdraw);
            mainPanel.Controls.Add(btnTransfer);
            mainPanel.Controls.Add(btnLogout);
            mainPanel.Location = new Point(68, 81);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1075, 636);
            mainPanel.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(348, 21);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(164, 32);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "DASHBOARD";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 12F);
            lblBalance.ForeColor = Color.White;
            lblBalance.Location = new Point(40, 80);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(0, 21);
            lblBalance.TabIndex = 1;
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.AutoSize = true;
            lblAccountNumber.Font = new Font("Segoe UI", 12F);
            lblAccountNumber.ForeColor = Color.White;
            lblAccountNumber.Location = new Point(40, 120);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(0, 21);
            lblAccountNumber.TabIndex = 2;
            // 
            // dgvTransactions
            // 
            dgvTransactions.BackgroundColor = Color.FromArgb(42, 42, 42);
            dgvTransactions.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(61, 61, 61);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(42, 42, 42);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTransactions.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.Location = new Point(46, 120);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.Size = new Size(858, 444);
            dgvTransactions.TabIndex = 3;
            // 
            // btnDeposit
            // 
            btnDeposit.BackColor = Color.FromArgb(0, 230, 118);
            btnDeposit.FlatStyle = FlatStyle.Flat;
            btnDeposit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDeposit.ForeColor = Color.Black;
            btnDeposit.Location = new Point(910, 120);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(150, 45);
            btnDeposit.TabIndex = 4;
            btnDeposit.Text = "Deposit";
            btnDeposit.UseVisualStyleBackColor = false;
            btnDeposit.Click += btnDeposit_Click;
            // 
            // btnWithdraw
            // 
            btnWithdraw.BackColor = Color.FromArgb(0, 230, 118);
            btnWithdraw.FlatStyle = FlatStyle.Flat;
            btnWithdraw.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnWithdraw.ForeColor = Color.Black;
            btnWithdraw.Location = new Point(910, 180);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(150, 45);
            btnWithdraw.TabIndex = 5;
            btnWithdraw.Text = "Withdraw";
            btnWithdraw.UseVisualStyleBackColor = false;
            btnWithdraw.Click += btnWithdraw_Click;
            // 
            // btnTransfer
            // 
            btnTransfer.BackColor = Color.FromArgb(0, 230, 118);
            btnTransfer.FlatStyle = FlatStyle.Flat;
            btnTransfer.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnTransfer.ForeColor = Color.Black;
            btnTransfer.Location = new Point(910, 240);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(150, 45);
            btnTransfer.TabIndex = 6;
            btnTransfer.Text = "Transfer";
            btnTransfer.UseVisualStyleBackColor = false;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkRed;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(910, 572);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(150, 45);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // Dashboard
            // 
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(1180, 767);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
        }
        #endregion
    }
}
