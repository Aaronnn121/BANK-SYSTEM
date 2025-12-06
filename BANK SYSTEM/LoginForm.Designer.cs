namespace BANK_SYSTEM
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.LinkLabel lnkCreateAccount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cardPanel = new Panel();
            lblTitle = new Label();
            lblUser = new Label();
            txtUsername = new TextBox();
            lblPass = new Label();
            txtPassword = new TextBox();
            btnSignIn = new Button();
            lnkCreateAccount = new LinkLabel();
            cardPanel.SuspendLayout();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.Anchor = AnchorStyles.None;
            cardPanel.BackColor = Color.FromArgb(30, 30, 30);
            cardPanel.BorderStyle = BorderStyle.FixedSingle;
            cardPanel.Controls.Add(lblTitle);
            cardPanel.Controls.Add(lblUser);
            cardPanel.Controls.Add(txtUsername);
            cardPanel.Controls.Add(lblPass);
            cardPanel.Controls.Add(txtPassword);
            cardPanel.Controls.Add(btnSignIn);
            cardPanel.Controls.Add(lnkCreateAccount);
            cardPanel.Location = new Point(176, 129);
            cardPanel.Name = "cardPanel";
            cardPanel.Size = new Size(380, 260);
            cardPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(120, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(146, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BANK LOGIN";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 9F);
            lblUser.ForeColor = Color.LightGray;
            lblUser.Location = new Point(36, 70);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(60, 15);
            lblUser.TabIndex = 1;
            lblUser.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(42, 42, 42);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.ForeColor = Color.White;
            txtUsername.Location = new Point(36, 92);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(308, 23);
            txtUsername.TabIndex = 2;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 9F);
            lblPass.ForeColor = Color.LightGray;
            lblPass.Location = new Point(36, 130);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(57, 15);
            lblPass.TabIndex = 3;
            lblPass.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(42, 42, 42);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(36, 152);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(308, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnSignIn
            // 
            btnSignIn.BackColor = Color.FromArgb(0, 200, 83);
            btnSignIn.Cursor = Cursors.Hand;
            btnSignIn.FlatAppearance.BorderSize = 0;
            btnSignIn.FlatStyle = FlatStyle.Flat;
            btnSignIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSignIn.ForeColor = Color.Black;
            btnSignIn.Location = new Point(36, 190);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(308, 36);
            btnSignIn.TabIndex = 5;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = false;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // lnkCreateAccount
            // 
            lnkCreateAccount.AutoSize = true;
            lnkCreateAccount.LinkColor = Color.FromArgb(0, 200, 83);
            lnkCreateAccount.Location = new Point(120, 234);
            lnkCreateAccount.Name = "lnkCreateAccount";
            lnkCreateAccount.Size = new Size(105, 15);
            lnkCreateAccount.TabIndex = 6;
            lnkCreateAccount.TabStop = true;
            lnkCreateAccount.Text = "Create an Account";
            lnkCreateAccount.Click += lblCreateAccount_Click;
            // 
            // LoginForm
            // 
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(744, 571);
            Controls.Add(cardPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}
