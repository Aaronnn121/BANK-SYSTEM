using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANK_SYSTEM
{
    public partial class Dashboard : Form
    {
        private readonly DbHelper _db;
        private readonly UserRepository _userRepo;
        private readonly AccountRepository _accountRepo;
        private readonly TransactionRepository _txRepo;

        private int _userId;
        private Account _account;

        public Dashboard()
        {
            InitializeComponent();
        }
        public Dashboard(int userId)
        {
            _userId = userId;

            InitializeComponent();

            _db = new DbHelper();
            _userRepo = new UserRepository(_db);
            _accountRepo = new AccountRepository(_db);
            _txRepo = new TransactionRepository(_db);

            LoadDashboard();
            LoadTransactions();
        }
        private void LoadDashboard()
        {
            var user = _userRepo.GetById(_userId);
            if (user == null)
            {
                MessageBox.Show("User not found.");
                return;
            }

            _account = _accountRepo.GetByUserId(_userId);
            if (_account == null)
            {
                _account = new Account
                {
                    user_id = user.user_id,
                    account_number = "AC" + new Random().Next(100000, 999999),
                    balance = 0
                };
                _accountRepo.Add(_account);
            }

            lblWelcome.Text = $"Welcome, {user.fullname}";
            lblBalance.Text = $"Balance: {_account.balance:N2}";
            lblAccountNumber.Text = $"Account: {_account.account_number}";
        }

        private void LoadTransactions()
        {
            var list = _txRepo.GetByAccountId(_account.account_id, 200);
            dgvTransactions.DataSource = list;
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load_1(object sender, EventArgs e)
        {

        }
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            var f = new DepositForm(_userId);
            f.FormClosed += (s, a) =>
            {
                LoadDashboard();
                LoadTransactions();
            };
            f.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            var f = new WithdrawForm(_userId);
            f.FormClosed += (s, a) =>
            {
                LoadDashboard();
                LoadTransactions();
            };
            f.ShowDialog();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            var f = new SendMoneyForm(_userId);
            f.FormClosed += (s, a) =>
            {
                LoadDashboard();
                LoadTransactions();
            };
            f.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

    }
}
