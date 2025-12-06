namespace BANK_SYSTEM
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblFullname;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cardPanel = new Panel();
            lblHeader = new Label();
            lblFullname = new Label();
            txtFullname = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnRegister = new Button();
            btnCancel = new Button();
            cardPanel.SuspendLayout();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.BackColor = Color.FromArgb(30, 30, 30);
            cardPanel.BorderStyle = BorderStyle.FixedSingle;
            cardPanel.Controls.Add(lblHeader);
            cardPanel.Controls.Add(lblFullname);
            cardPanel.Controls.Add(txtFullname);
            cardPanel.Controls.Add(lblUsername);
            cardPanel.Controls.Add(txtUsername);
            cardPanel.Controls.Add(lblPassword);
            cardPanel.Controls.Add(txtPassword);
            cardPanel.Controls.Add(btnRegister);
            cardPanel.Controls.Add(btnCancel);
            cardPanel.Location = new Point(159, 149);
            cardPanel.Name = "cardPanel";
            cardPanel.Size = new Size(420, 360);
            cardPanel.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(120, 18);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(174, 25);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "CREATE ACCOUNT";
            // 
            // lblFullname
            // 
            lblFullname.ForeColor = Color.LightGray;
            lblFullname.Location = new Point(40, 70);
            lblFullname.Name = "lblFullname";
            lblFullname.Size = new Size(100, 23);
            lblFullname.TabIndex = 1;
            lblFullname.Text = "Full Name";
            // 
            // txtFullname
            // 
            txtFullname.BackColor = Color.FromArgb(42, 42, 42);
            txtFullname.BorderStyle = BorderStyle.FixedSingle;
            txtFullname.ForeColor = Color.White;
            txtFullname.Location = new Point(40, 95);
            txtFullname.Name = "txtFullname";
            txtFullname.Size = new Size(340, 23);
            txtFullname.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.ForeColor = Color.LightGray;
            lblUsername.Location = new Point(40, 135);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(100, 23);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(42, 42, 42);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.ForeColor = Color.White;
            txtUsername.Location = new Point(40, 160);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(340, 23);
            txtUsername.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.ForeColor = Color.LightGray;
            lblPassword.Location = new Point(40, 200);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(100, 23);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(42, 42, 42);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(40, 225);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(340, 23);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(0, 200, 83);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.ForeColor = Color.Black;
            btnRegister.Location = new Point(40, 270);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(160, 36);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(55, 55, 55);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(220, 270);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(160, 36);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // RegisterForm
            // 
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(741, 654);
            Controls.Add(cardPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}
