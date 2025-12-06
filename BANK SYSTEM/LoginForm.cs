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
    public partial class LoginForm : Form
    {
        private readonly DbHelper _db;
        private readonly UserRepository _userRepo;
        public LoginForm()
        {
            InitializeComponent();
            _db = new DbHelper();
            _userRepo = new UserRepository(_db);
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = _userRepo.GetByUsername(username);

            if (user != null && user.password == password)
            {
                Dashboard dash = new Dashboard(user.user_id);
                dash.Show();
                this.Hide();
                return;
            }

            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            RegisterForm reg = new RegisterForm();
            reg.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
