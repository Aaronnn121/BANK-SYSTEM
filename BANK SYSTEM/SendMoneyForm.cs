using System;
using System.Drawing;
using System.Windows.Forms;

namespace BANK_SYSTEM
{
    public partial class SendMoneyForm : Form
    {
        private readonly DbHelper _db;
        private readonly AccountRepository _accRepo;
        private readonly UserRepository _userRepo;
        private int _userId;
        private Account _fromAccount;

        private Label lblFromAcc;
        private TextBox txtRecipientUsername;
        private TextBox txtAmount;
        private Button btnSend;

        public SendMoneyForm(int userId)
        {
            _userId = userId;
            InitializeComponent();

            _db = new DbHelper();
            _accRepo = new AccountRepository(_db);
            _userRepo = new UserRepository(_db);

            // Load sender account
            _fromAccount = _accRepo.GetByUserId(_userId);

            if (_fromAccount == null)
            {
                MessageBox.Show("Your account could not be loaded.");
                Close();
                return;
            }

            lblFromAcc.Text = $"From Account: {_fromAccount.account_number}\nBalance: {_fromAccount.balance:N2}";
        }

        private void InitializeComponent()
        {
            lblFromAcc = new Label();
            txtRecipientUsername = new TextBox();
            txtAmount = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // lblFromAcc
            // 
            lblFromAcc.AutoSize = true;
            lblFromAcc.Font = new Font("Segoe UI", 10F);
            lblFromAcc.Location = new Point(20, 20);
            lblFromAcc.Name = "lblFromAcc";
            lblFromAcc.Size = new Size(0, 19);
            lblFromAcc.TabIndex = 0;
            // 
            // txtRecipientUsername
            // 
            txtRecipientUsername.Location = new Point(20, 70);
            txtRecipientUsername.Name = "txtRecipientUsername";
            txtRecipientUsername.PlaceholderText = "Recipient Username";
            txtRecipientUsername.Size = new Size(250, 23);
            txtRecipientUsername.TabIndex = 1;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(20, 110);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderText = "Amount";
            txtAmount.Size = new Size(250, 23);
            txtAmount.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(20, 150);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(120, 30);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send Money";
            btnSend.Click += btnSend_Click;
            // 
            // SendMoneyForm
            // 
            ClientSize = new Size(380, 220);
            Controls.Add(lblFromAcc);
            Controls.Add(txtRecipientUsername);
            Controls.Add(txtAmount);
            Controls.Add(btnSend);
            Name = "SendMoneyForm";
            Text = "Send Money";
            Load += SendMoneyForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string recipientUsername = txtRecipientUsername.Text.Trim();

            if (recipientUsername == "")
            {
                MessageBox.Show("Enter recipient username.");
                return;
            }

            if (!double.TryParse(txtAmount.Text.Trim(), out double amount) || amount <= 0)
            {
                MessageBox.Show("Enter a valid amount.");
                return;
            }

            // Find recipient user
            var recipientUser = _userRepo.GetByUsername(recipientUsername);

            if (recipientUser == null)
            {
                MessageBox.Show("Recipient username not found.");
                return;
            }

            // Get recipient account
            var toAccount = _accRepo.GetByUserId(recipientUser.user_id);

            if (toAccount == null)
            {
                MessageBox.Show("Recipient account not found.");
                return;
            }

            if (_fromAccount.balance < amount)
            {
                MessageBox.Show("Insufficient funds.");
                return;
            }

            // TRANSFER
            _accRepo.ExecuteInTransaction(conn =>
            {
                _fromAccount.balance -= amount;
                toAccount.balance += amount;

                conn.Update(_fromAccount);
                conn.Update(toAccount);

                // Sender transaction
                conn.Insert(new TransactionEntry
                {
                    user_id = _userId,
                    account_id = _fromAccount.account_id,
                    transaction_date = DateTime.UtcNow.ToString("o"),
                    transaction_type = "debit",
                    amount = amount,
                    description = $"Sent to {recipientUsername}"
                });

                // Receiver transaction
                conn.Insert(new TransactionEntry
                {
                    user_id = recipientUser.user_id,
                    account_id = toAccount.account_id,
                    transaction_date = DateTime.UtcNow.ToString("o"),
                    transaction_type = "credit",
                    amount = amount,
                    description = $"Received from {_fromAccount.account_number}"
                });
            });

            MessageBox.Show("Money sent successfully!");
            Close();
        }

        private void SendMoneyForm_Load(object sender, EventArgs e)
        {

        }
    }
}
