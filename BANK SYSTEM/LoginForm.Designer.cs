namespace BANK_SYSTEM
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelCard = new Panel();
            lblTitle = new Label();
            lblUser = new Label();
            txtUsername = new TextBox();
            lblPass = new Label();
            txtPassword = new TextBox();
            btnSignIn = new Button();
            lblCreateAccount = new Label();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.FromArgb(30, 30, 30);
            panelCard.BorderStyle = BorderStyle.FixedSingle;
            panelCard.Controls.Add(lblTitle);
            panelCard.Controls.Add(lblUser);
            panelCard.Controls.Add(txtUsername);
            panelCard.Controls.Add(lblPass);
            panelCard.Controls.Add(txtPassword);
            panelCard.Controls.Add(btnSignIn);
            panelCard.Controls.Add(lblCreateAccount);
            panelCard.Location = new Point(240, 164);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(360, 260);
            panelCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(110, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(146, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BANK LOGIN";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F);
            lblUser.ForeColor = Color.FromArgb(160, 160, 160);
            lblUser.Location = new Point(40, 75);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(71, 19);
            lblUser.TabIndex = 1;
            lblUser.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(42, 42, 42);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.ForeColor = Color.White;
            txtUsername.Location = new Point(40, 95);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(280, 23);
            txtUsername.TabIndex = 2;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 10F);
            lblPass.ForeColor = Color.FromArgb(160, 160, 160);
            lblPass.Location = new Point(40, 135);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(67, 19);
            lblPass.TabIndex = 3;
            lblPass.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(42, 42, 42);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(40, 155);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(280, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnSignIn
            // 
            btnSignIn.BackColor = Color.FromArgb(0, 200, 83);
            btnSignIn.Cursor = Cursors.Hand;
            btnSignIn.FlatAppearance.BorderSize = 0;
            btnSignIn.FlatStyle = FlatStyle.Flat;
            btnSignIn.Font = new Font("Segoe UI Semibold", 10F);
            btnSignIn.ForeColor = Color.Black;
            btnSignIn.Location = new Point(40, 195);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(280, 35);
            btnSignIn.TabIndex = 5;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = false;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // lblCreateAccount
            // 
            lblCreateAccount.AutoSize = true;
            lblCreateAccount.Cursor = Cursors.Hand;
            lblCreateAccount.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            lblCreateAccount.ForeColor = Color.FromArgb(0, 230, 118);
            lblCreateAccount.Location = new Point(110, 235);
            lblCreateAccount.Name = "lblCreateAccount";
            lblCreateAccount.Size = new Size(105, 15);
            lblCreateAccount.TabIndex = 6;
            lblCreateAccount.Text = "Create an Account";
            lblCreateAccount.Click += lblCreateAccount_Click;
            // 
            // LoginForm
            // 
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(853, 637);
            Controls.Add(panelCard);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCard;
        private Label lblTitle;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnSignIn;
        private Label lblCreateAccount;
        private Label lblUser;
        private Label lblPass;
    }
}
