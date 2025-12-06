using System;
using System.Windows.Forms;

namespace BANK_SYSTEM
{
    public partial class WithdrawForm : Form
    {
        private readonly DbHelper _db;
        private readonly AccountRepository _accountRepo;
        private readonly TransactionRepository _txRepo;
        private readonly int _userId;
        private TextBox txtAmount;
        private Button button1;
        private Account _userAccount;

        public WithdrawForm(int userId)
        {
            // InitializeComponent(); // Excluded designer call
            _userId = userId;

            _db = new DbHelper();
            _accountRepo = new AccountRepository(_db);
            _txRepo = new TransactionRepository(_db);

            // Fetch the user's account upon form creation
            _userAccount = _accountRepo.GetByUserId(_userId);
            if (_userAccount == null)
            {
                MessageBox.Show("Account not found. Cannot proceed with withdrawal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            // NOTE: Assumes a TextBox control for the amount is named 'txtAmount'
            if (!double.TryParse(txtAmount.Text, out double amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount to withdraw.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_userAccount == null) return;

            // CRITICAL: Insufficient Balance Check
            if (amount > _userAccount.balance)
            {
                MessageBox.Show($"Insufficient balance. Current balance: {_userAccount.balance:C}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Use the transactional helper from AccountRepository for atomicity
                _accountRepo.ExecuteInTransaction(conn =>
                {
                    // 1. Update Account Balance (Debit)
                    _userAccount.balance -= amount;
                    _accountRepo.Update(_userAccount);

                    // 2. Record Transaction
                    var tx = new TransactionEntry
                    {
                        user_id = _userId,
                        account_id = _userAccount.account_id,
                        transaction_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        transaction_type = "Withdrawal",
                        amount = amount,
                        description = $"ATM/Cash Withdrawal"
                    };
                    _txRepo.Add(tx);
                });

                MessageBox.Show($"Successfully withdrew {amount:C}. New Balance: {_userAccount.balance:C}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                // AccountRepository.ExecuteInTransaction displays an error message on failure and rolls back.
                this.Close();
            }
        }

        private void InitializeComponent()
        {
            txtAmount = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(89, 88);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(102, 139);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // WithdrawForm
            // 
            ClientSize = new Size(284, 261);
            Controls.Add(button1);
            Controls.Add(txtAmount);
            Name = "WithdrawForm";
            ResumeLayout(false);
            PerformLayout();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}