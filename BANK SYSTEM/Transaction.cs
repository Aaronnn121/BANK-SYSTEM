using SQLite;

namespace BANK_SYSTEM
{
    public class Transaction
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public int user_id { get; set; }
        public int account_id { get; set; }

        public string transaction_date { get; set; }
        public string type { get; set; }    // "Debit" or "Credit"
        public double amount { get; set; }
        public string description { get; set; }
    }
}
