using System;
using System.Drawing;
using System.Windows.Forms;

namespace BANK_SYSTEM
{
    public partial class DepositForm : Form
    {
        private readonly DbHelper _db;
        private readonly AccountRepository _accRepo;
        private readonly int _userId;
        private Account _account;

        private Label lblAccInfo;
        private TextBox txtAmount;
        private Button btnDeposit;

        public DepositForm(int userId)
        {
            _userId = userId;
            InitializeComponent();

            _db = new DbHelper();
            _accRepo = new AccountRepository(_db);

            _account = _accRepo.GetByUserId(_userId);

            if (_account == null)
            {
                MessageBox.Show("Account not found for this user.");
                Close();
                return;
            }

            lblAccInfo.Text = $"Account: {_account.account_number}\nBalance: {_account.balance:N2}";
        }

        private void InitializeComponent()
        {
            lblAccInfo = new Label();
            txtAmount = new TextBox();
            btnDeposit = new Button();
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
            // btnDeposit
            // 
            btnDeposit.Location = new Point(20, 120);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(75, 23);
            btnDeposit.TabIndex = 2;
            btnDeposit.Text = "Deposit";
            btnDeposit.Click += btnDeposit_Click;
            // 
            // DepositForm
            // 
            ClientSize = new Size(350, 200);
            Controls.Add(lblAccInfo);
            Controls.Add(txtAmount);
            Controls.Add(btnDeposit);
            Name = "DepositForm";
            Text = "Deposit";
            Load += DepositForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtAmount.Text.Trim(), out double amount) || amount <= 0)
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            _accRepo.ExecuteInTransaction(conn =>
            {
                _account.balance += amount;
                conn.Update(_account);

                conn.Insert(new TransactionEntry
                {
                    user_id = _userId,
                    account_id = _account.account_id,
                    transaction_date = DateTime.UtcNow.ToString("o"),
                    transaction_type = "credit",
                    amount = amount,
                    description = "Deposit"
                });
            });

            MessageBox.Show("Deposit successful!");
            Close();
        }

        private void DepositForm_Load(object sender, EventArgs e)
        {

        }
    }
}