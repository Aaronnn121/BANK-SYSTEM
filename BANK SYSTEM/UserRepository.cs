using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace BANK_SYSTEM
{
    public class UserRepository
    {
        private readonly DbHelper _db;
        public UserRepository(DbHelper db)
        {
            _db = db;
        }

        public User GetByUsername(string username)
        {
            using (var conn = _db.GetConnection())
            {
                return conn.Table<User>().FirstOrDefault(u => u.username == username);
            }
        }

        public User GetById(int id)
        {
            using (var conn = _db.GetConnection())
            {
                return conn.Find<User>(id);
            }
        }

        // ensures user.user_id is populated
        public bool Add(User user)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Insert(user);
                var id = conn.ExecuteScalar<int>("select last_insert_rowid()");
                if (id > 0) user.user_id = id;
                return user.user_id > 0;
            }
        }

        public List<User> GetAll()
        {
            using (var conn = _db.GetConnection())
            {
                return conn.Table<User>().ToList();
            }
        }
    }
}
