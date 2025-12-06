namespace BANK_SYSTEM
{
    partial class Dashboard
    {
        private System.ComponentModel.IContainer components = null;

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
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            lblWelcome = new Label();
            lblBalance = new Label();
            lblAccountNumber = new Label();
            dgvTransactions = new DataGridView();
            btnDeposit = new Button();
            btnWithdraw = new Button();
            btnTransfer = new Button();
            btnLogout = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();

            // --------- FORM GENERAL STYLE ----------
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 11F);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(900, 550);

            // --------- WELCOME LABEL ----------
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblWelcome.Location = new Point(30, 30);
            lblWelcome.Text = "Welcome,";

            // --------- BALANCE ----------
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            lblBalance.Location = new Point(30, 90);
            lblBalance.Text = "Balance:";

            // --------- ACCOUNT NUMBER ----------
            lblAccountNumber.AutoSize = true;
            lblAccountNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            lblAccountNumber.Location = new Point(30, 130);
            lblAccountNumber.Text = "Account No:";

            // --------- TRANSACTIONS GRID ----------
            dgvTransactions.Location = new Point(30, 180);
            dgvTransactions.Size = new Size(620, 330);
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.ReadOnly = true;
            dgvTransactions.ColumnHeadersHeight = 35;

            // --------- BUTTON STYLE ----------
            Size btnSize = new Size(150, 40);
            Font btnFont = new Font("Segoe UI", 10F, FontStyle.Bold);

            // --------- DEPOSIT BUTTON ----------
            btnDeposit.Text = "Deposit";
            btnDeposit.Location = new Point(680, 180);
            btnDeposit.Size = btnSize;
            btnDeposit.Font = btnFont;
            btnDeposit.BackColor = Color.LightSkyBlue;
            btnDeposit.FlatStyle = FlatStyle.Flat;

            // --------- WITHDRAW BUTTON ----------
            btnWithdraw.Text = "Withdraw";
            btnWithdraw.Location = new Point(680, 230);
            btnWithdraw.Size = btnSize;
            btnWithdraw.Font = btnFont;
            btnWithdraw.BackColor = Color.LightGreen;
            btnWithdraw.FlatStyle = FlatStyle.Flat;

            // --------- TRANSFER BUTTON ----------
            btnTransfer.Text = "Transfer";
            btnTransfer.Location = new Point(680, 280);
            btnTransfer.Size = btnSize;
            btnTransfer.Font = btnFont;
            btnTransfer.BackColor = Color.Khaki;
            btnTransfer.FlatStyle = FlatStyle.Flat;

            // --------- LOGOUT BUTTON ----------
            btnLogout.Text = "Logout";
            btnLogout.Location = new Point(680, 330);
            btnLogout.Size = btnSize;
            btnLogout.Font = btnFont;
            btnLogout.BackColor = Color.Salmon;
            btnLogout.FlatStyle = FlatStyle.Flat;

            // ------- ADD CONTROLS TO FORM -------
            Controls.Add(lblWelcome);
            Controls.Add(lblBalance);
            Controls.Add(lblAccountNumber);
            Controls.Add(dgvTransactions);

            Controls.Add(btnDeposit);
            Controls.Add(btnWithdraw);
            Controls.Add(btnTransfer);
            Controls.Add(btnLogout);

            this.Text = "Dashboard";
            Load += Dashboard_Load_1;

            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
            PerformLayout();
            // deposit
            btnDeposit.Text = "Deposit";
            btnDeposit.Location = new Point(680, 180);
            btnDeposit.Size = btnSize;
            btnDeposit.Font = btnFont;
            btnDeposit.BackColor = Color.LightSkyBlue;
            btnDeposit.FlatStyle = FlatStyle.Flat;
            btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);

            // withdraw
            btnWithdraw.Text = "Withdraw";
            btnWithdraw.Location = new Point(680, 230);
            btnWithdraw.Size = btnSize;
            btnWithdraw.Font = btnFont;
            btnWithdraw.BackColor = Color.LightGreen;
            btnWithdraw.FlatStyle = FlatStyle.Flat;
            btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);

            // transfer
            btnTransfer.Text = "Transfer";
            btnTransfer.Location = new Point(680, 280);
            btnTransfer.Size = btnSize;
            btnTransfer.Font = btnFont;
            btnTransfer.BackColor = Color.Khaki;
            btnTransfer.FlatStyle = FlatStyle.Flat;
            btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);

            // logout
            btnLogout.Text = "Logout";
            btnLogout.Location = new Point(680, 330);
            btnLogout.Size = btnSize;
            btnLogout.Font = btnFont;
            btnLogout.BackColor = Color.Salmon;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

        }
        #endregion
    }
}
