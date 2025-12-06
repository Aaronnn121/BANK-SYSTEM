using System.Collections.Generic;
using System.Linq;

namespace BANK_SYSTEM
{
    public class TransactionRepository
    {
        private readonly DbHelper _db;
        public TransactionRepository(DbHelper db)
        {
            _db = db;
        }

        public bool Add(TransactionEntry tx)
        {
            using (var conn = _db.GetConnection())
            {
                return conn.Insert(tx) > 0;
            }
        }

        public List<TransactionEntry> GetByAccountId(int accountId, int limit = 50)
        {
            using (var conn = _db.GetConnection())
            {
                return conn.Table<TransactionEntry>()
                    .Where(t => t.account_id == accountId)
                    .OrderByDescending(t => t.id)
                    .Take(limit)
                    .ToList();
            }
        }
    }
}
