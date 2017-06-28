using DP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Repository.Repositories
{
    public class UserRepository : IRepository<User>
    {
        DPEntities db = DBTool.DBInstance;
        public int insert(User item)
        {
            db.Users.Add(item);
            return db.SaveChanges();
        }

        public int Update(User item)
        {
            User update = db.Users.Find(item.Id);
            db.Entry(update).CurrentValues.SetValues(item);
            return db.SaveChanges();
        }

        public int Delete(int itemId)
        {
            User deleted = db.Users.Find(itemId);
            deleted.Isdeleted = true;
            return db.SaveChanges();
        }

        public List<User> SelectAll()
        {
            return db.Users.Where(x => x.Isdeleted == false).ToList();
        }

        public User SelectById(int itemId)
        {
            return db.Users.Find(itemId);
        }
    }
}
