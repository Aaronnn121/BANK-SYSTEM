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
        private readonly int _userId;
        private TextBox txtReceiver;
        private TextBox txtAmount;
        private Button btnSend;
        private Button btnCancel;
        private Label lblFrom;
        private Account _fromAccount;

        public SendMoneyForm(int userId)
        {
            _userId = userId;
            InitializeComponent();

            _db = new DbHelper();
            _accRepo = new AccountRepository(_db);
            _userRepo = new UserRepository(_db);

            _fromAccount = _accRepo.GetByUserId(_userId);

            if (_fromAccount == null)
            {
                MessageBox.Show("Account not found.");
                Close();
                return;
            }

            lblFrom.Text = $"From Account: {_fromAccount.account_number}\nBalance: {_fromAccount.balance:N2}";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string receiverUser = txtReceiver.Text.Trim();

            var targetUser = _userRepo.GetByUsername(receiverUser);

            if (targetUser == null)
            {
                MessageBox.Show("Recipient not found.");
                return;
            }

            var toAccount = _accRepo.GetByUserId(targetUser.user_id);

            if (!double.TryParse(txtAmount.Text.Trim(), out double amount) || amount <= 0)
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            if (_fromAccount.balance < amount)
            {
                MessageBox.Show("Insufficient balance.");
                return;
            }

            _accRepo.ExecuteInTransaction(conn =>
            {
                _fromAccount.balance -= amount;
                conn.Update(_fromAccount);

                toAccount.balance += amount;
                conn.Update(toAccount);

                conn.Insert(new TransactionEntry
                {
                    user_id = _userId,
                    account_id = _fromAccount.account_id,
                    transaction_date = DateTime.UtcNow.ToString("o"),
                    transaction_type = "transfer_out",
                    amount = amount,
                    description = $"Transfer to {receiverUser}"
                });

                conn.Insert(new TransactionEntry
                {
                    user_id = targetUser.user_id,
                    account_id = toAccount.account_id,
                    transaction_date = DateTime.UtcNow.ToString("o"),
                    transaction_type = "transfer_in",
                    amount = amount,
                    description = $"Received from {_fromAccount.account_number}"
                });
            });

            MessageBox.Show("Transfer completed!");
            Close();
        }

        private void InitializeComponent()
        {
            txtReceiver = new TextBox();
            txtAmount = new TextBox();
            btnSend = new Button();
            btnCancel = new Button();
            lblFrom = new Label();
            SuspendLayout();
            // 
            // txtReceiver
            // 
            txtReceiver.Location = new Point(121, 82);
            txtReceiver.Name = "txtReceiver";
            txtReceiver.Size = new Size(100, 23);
            txtReceiver.TabIndex = 0;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(121, 129);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(121, 209);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(202, 209);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(122, 42);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(38, 15);
            lblFrom.TabIndex = 4;
            lblFrom.Text = "label1";
            // 
            // SendMoneyForm
            // 
            ClientSize = new Size(629, 506);
            Controls.Add(lblFrom);
            Controls.Add(btnCancel);
            Controls.Add(btnSend);
            Controls.Add(txtAmount);
            Controls.Add(txtReceiver);
            Name = "SendMoneyForm";
            ResumeLayout(false);
            PerformLayout();

        }
    }
}
