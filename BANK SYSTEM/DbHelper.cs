using System.IO;
using System.Windows.Forms;
using SQLite;

namespace BANK_SYSTEM
{
    public class DbHelper
    {
        private readonly string _dbPath;
        public DbHelper()
        {
            _dbPath = Path.Combine(Application.StartupPath, "bank.db");
            using (var conn = GetConnection())
            {
                conn.CreateTable<User>();
                conn.CreateTable<Account>();
                conn.CreateTable<TransactionEntry>();
            }
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(_dbPath);
        }
    }
}
