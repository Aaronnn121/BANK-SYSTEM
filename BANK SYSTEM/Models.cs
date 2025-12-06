using SQLite;

namespace BANK_SYSTEM
{
    [Table("users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; } // plain-text for learning only
        public string fullname { get; set; }
    }

    [Table("accounts")]
    public class Account
    {
        [PrimaryKey, AutoIncrement]
        public int account_id { get; set; }
        public int user_id { get; set; }
        public string account_number { get; set; }
        public double balance { get; set; }
    }

    [Table("transactions")]
    public class TransactionEntry
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int user_id { get; set; }
        public int account_id { get; set; }
        public string transaction_date { get; set; } // ISO
        public string transaction_type { get; set; } // credit/debit/transfer
        public double amount { get; set; }
        public string description { get; set; }
    }
}
