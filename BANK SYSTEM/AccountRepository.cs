using System;
using SQLite;

namespace BANK_SYSTEM
{
    public class AccountRepository
    {
        private readonly DbHelper _db;
        public AccountRepository(DbHelper db)
        {
            _db = db;
        }

        public Account GetByUserId(int userId)
        {
            using (var conn = _db.GetConnection())
            {
                return conn.Table<Account>().FirstOrDefault(a => a.user_id == userId);
            }
        }

        public Account GetByAccountNumber(string accountNumber)
        {
            using (var conn = _db.GetConnection())
            {
                return conn.Table<Account>().FirstOrDefault(a => a.account_number == accountNumber);
            }
        }

        public bool Add(Account account)
        {
            using (var conn = _db.GetConnection())
            {
                return conn.Insert(account) > 0;
            }
        }

        public bool Update(Account acc)
        {
            using (var conn = _db.GetConnection())
            {
                return conn.Update(acc) > 0;
            }
        }

        // SAFER TRANSACTION METHOD (FULL FIX)
        public void ExecuteInTransaction(Action<SQLiteConnection> action)
        {
            using (var conn = _db.GetConnection())
            {
                try
                {
                    conn.BeginTransaction();
                    action(conn);
                    conn.Commit();
                }
                catch (Exception ex)
                {
                    conn.Rollback();
                    System.Windows.Forms.MessageBox.Show("Transaction failed:\n" + ex.Message);
                }
            }
        }
    }
}
