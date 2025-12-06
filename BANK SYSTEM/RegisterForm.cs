namespace BANK_SYSTEM
{
    public partial class RegisterForm : Form
    {
        private readonly DbHelper _db;
        private readonly UserRepository _userRepo;
        private readonly AccountRepository _accountRepo;

        public RegisterForm()
        {
            InitializeComponent();
            _db = new DbHelper();
            _userRepo = new UserRepository(_db);
            _accountRepo = new AccountRepository(_db);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string fullname = txtFullname.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please provide username and password.");
                return;
            }

            if (_userRepo.GetByUsername(username) != null)
            {
                MessageBox.Show("Username already exists.");
                return;
            }

            var user = new User
            {
                username = username,
                password = password,
                fullname = fullname
            };

            var ok = _userRepo.Add(user);
            if (!ok)
            {
                MessageBox.Show("Failed to register user.");
                return;
            }

            // Create account for the new user using the assigned user.user_id
            var acc = new Account
            {
                user_id = user.user_id,
                account_number = GenerateAccountNumber(),
                balance = 0.0
            };

            _accountRepo.Add(acc);

            MessageBox.Show("Registration successful. You can now login.");

            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private string GenerateAccountNumber()
        {
            var rnd = new Random();
            return "AC" + rnd.Next(100000, 999999).ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
