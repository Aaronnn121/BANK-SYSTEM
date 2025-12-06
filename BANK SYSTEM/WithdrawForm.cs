using System;
using System.Drawing;
using System.Windows.Forms;

namespace BANK_SYSTEM
{
    public partial class WithdrawForm : Form
    {
        private readonly DbHelper _db;
        private readonly AccountRepository _accRepo;
        private readonly int _userId;
        private Account _account;

        private Label lblAccInfo;
        private TextBox txtAmount;
        private Button btnWithdraw;

        public WithdrawForm(int userId)
        {
            _userId = userId;
            InitializeComponent();

            _db = new DbHelper();
            _accRepo = new AccountRepository(_db);

            _account = _accRepo.GetByUserId(_userId);

            if (_account == null)
            {
                MessageBox.Show("Account not found.");
                Close();
                return;
            }

            lblAccInfo.Text = $"Account: {_account.account_number}\nBalance: {_account.balance:N2}";
        }

        private void InitializeComponent()
        {
            lblAccInfo = new Label();
            txtAmount = new TextBox();
            btnWithdraw = new Button();
            SuspendLayout();
            // 
            // lblAccInfo
            // 
            lblAccInfo.AutoSize = true;
            lblAccInfo.Location = new Point(20, 20);
            lblAccInfo.Name = "lblAccInfo";
            lblAccInfo.Size = new Size(0, 15);
            lblAccInfo.TabIndex = 0;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(20, 80);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(200, 23);
            txtAmount.TabIndex = 1;
            // 
            // btnWithdraw
            // 
            btnWithdraw.Location = new Point(20, 120);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(75, 23);
            btnWithdraw.TabIndex = 2;
            btnWithdraw.Text = "Withdraw";
            btnWithdraw.Click += btnWithdraw_Click;
            // 
            // WithdrawForm
            // 
            ClientSize = new Size(350, 200);
            Controls.Add(lblAccInfo);
            Controls.Add(txtAmount);
            Controls.Add(btnWithdraw);
            Name = "WithdrawForm";
            Text = "Withdraw";
            Load += WithdrawForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtAmount.Text.Trim(), out double amount) || amount <= 0)
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            if (_account.balance < amount)
            {
                MessageBox.Show("Insufficient funds.");
                return;
            }

            _accRepo.ExecuteInTransaction(conn =>
            {
                _account.balance -= amount;
                conn.Update(_account);

                conn.Insert(new TransactionEntry
                {
                    user_id = _userId,
                    account_id = _account.account_id,
                    transaction_date = DateTime.UtcNow.ToString("o"),
                    transaction_type = "debit",
                    amount = amount,
                    description = "Withdraw"
                });
            });

            MessageBox.Show("Withdrawal successful!");
            Close();
        }

        private void WithdrawForm_Load(object sender, EventArgs e)
        {

        }
    }
}
