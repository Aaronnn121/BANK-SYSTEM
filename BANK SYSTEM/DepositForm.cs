using System;
using System.Windows.Forms;

namespace BANK_SYSTEM
{
    public partial class DepositForm : Form
    {
        private readonly DbHelper _db;
        private readonly AccountRepository _accountRepo;
        private readonly TransactionRepository _txRepo;
        private readonly int _userId;
        private TextBox txtAmount;
        private Button btnDeposit;
        private Button btnCancel;
        private Account _userAccount;

        public DepositForm(int userId)
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
                MessageBox.Show("Account not found. Cannot proceed with deposit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            // NOTE: Assumes a TextBox control for the amount is named 'txtAmount'
            if (!double.TryParse(txtAmount.Text, out double amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid positive amount to deposit.", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_userAccount == null) return;

            try
            {
                // Use the transactional helper from AccountRepository for atomicity
                _accountRepo.ExecuteInTransaction(conn =>
                {
                    // 1. Update Account Balance
                    _userAccount.balance += amount;
                    _accountRepo.Update(_userAccount);

                    // 2. Record Transaction
                    var tx = new TransactionEntry
                    {
                        user_id = _userId,
                        account_id = _userAccount.account_id,
                        transaction_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        transaction_type = "Deposit",
                        amount = amount,
                        description = $"Cash Deposit"
                    };
                    _txRepo.Add(tx);
                });

                MessageBox.Show($"Successfully deposited {amount:C}. New Balance: {_userAccount.balance:C}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            btnDeposit = new Button();
            btnCancel = new Button();
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(82, 55);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 0;
            // 
            // btnDeposit
            // 
            btnDeposit.Location = new Point(47, 157);
            btnDeposit.Name = "btnDeposit";
            btnDeposit.Size = new Size(75, 23);
            btnDeposit.TabIndex = 1;
            btnDeposit.Text = "Deposit";
            btnDeposit.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(144, 157);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // DepositForm
            // 
            ClientSize = new Size(284, 261);
            Controls.Add(btnCancel);
            Controls.Add(btnDeposit);
            Controls.Add(txtAmount);
            Name = "DepositForm";
            //Load += DepositForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}