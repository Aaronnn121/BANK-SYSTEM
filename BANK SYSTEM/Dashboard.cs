using System;
using System.Windows.Forms;

namespace BANK_SYSTEM
{
    public partial class Dashboard : Form
    {
        private readonly DbHelper _db;
        private readonly UserRepository _userRepo;
        private readonly AccountRepository _accountRepo;
        private readonly TransactionRepository _txRepo;

        private int currentUserId;
        private Label lblWelcome;
        private Label lblBalance;
        private Label lblAccountNumber;
        private DataGridView dgvTransactions;
        private Account currentAccount;

        public Dashboard(int userId)
        {
            currentUserId = userId;

            InitializeComponent(); // SAFE NOW

            _db = new DbHelper();
            _userRepo = new UserRepository(_db);
            _accountRepo = new AccountRepository(_db);
            _txRepo = new TransactionRepository(_db);

            LoadDashboardData();
            LoadTransactionHistory();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
        }

        private void LoadDashboardData()
        {
            var user = _userRepo.GetById(currentUserId);
            if (user == null)
            {
                MessageBox.Show("User not found.");
                return;
            }

            currentAccount = _accountRepo.GetByUserId(currentUserId);

            if (currentAccount == null)
            {
                currentAccount = new Account
                {
                    user_id = currentUserId,
                    account_number = "AC" + new Random().Next(100000, 999999),
                    balance = 0.0
                };
                _accountRepo.Add(currentAccount);
            }

            lblWelcome.Text = $"Good Day!\n{user.fullname}";
            lblBalance.Text = $"Balance: {currentAccount.balance:N2}";
            lblAccountNumber.Text = $"Account No: {currentAccount.account_number}";

            this.Text = $"{user.username}'s Dashboard";
        }

        private void LoadTransactionHistory()
        {
            var list = _txRepo.GetByAccountId(currentAccount.account_id, 200);
            dgvTransactions.DataSource = list;
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            var f = new DepositForm(currentUserId);
            f.FormClosed += (s, e2) =>
            {
                LoadDashboardData();
                LoadTransactionHistory();
            };
            f.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            var f = new WithdrawForm(currentUserId);
            f.FormClosed += (s, e2) =>
            {
                LoadDashboardData();
                LoadTransactionHistory();
            };
            f.ShowDialog();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            var f = new SendMoneyForm(currentUserId);
            f.FormClosed += (s, e2) =>
            {
                LoadDashboardData();
                LoadTransactionHistory();
            };
            f.ShowDialog();
        }

        private void InitializeComponent()
        {
            lblWelcome = new Label();
            lblBalance = new Label();
            lblAccountNumber = new Label();
            dgvTransactions = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(12, 25);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(38, 15);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "label1";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Location = new Point(12, 73);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(38, 15);
            lblBalance.TabIndex = 1;
            lblBalance.Text = "label1";
            // 
            // lblAccountNumber
            // 
            lblAccountNumber.AutoSize = true;
            lblAccountNumber.Location = new Point(12, 130);
            lblAccountNumber.Name = "lblAccountNumber";
            lblAccountNumber.Size = new Size(38, 15);
            lblAccountNumber.TabIndex = 2;
            lblAccountNumber.Text = "label1";
            // 
            // dgvTransactions
            // 
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(30, 170);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.Size = new Size(560, 330);
            dgvTransactions.TabIndex = 3;
            // 
            // Dashboard
            // 
            ClientSize = new Size(646, 535);
            Controls.Add(dgvTransactions);
            Controls.Add(lblAccountNumber);
            Controls.Add(lblBalance);
            Controls.Add(lblWelcome);
            Name = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}
