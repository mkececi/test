using DP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Repository.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        DPEntities db = DBTool.DBInstance;
        public int insert(Employee item)
        {
            db.Employees.Add(item);
            return db.SaveChanges();
        }

        public int Update(Employee item)
        {
            Employee update = db.Employees.Find(item.Id);
            db.Entry(update).CurrentValues.SetValues(item);
            return db.SaveChanges();
        }

        public int Delete(int itemId)
        {
            Employee deleted = db.Employees.Find(itemId);
            deleted.Isdeleted = true;
            return db.SaveChanges();
        }

        public List<Employee> SelectAll()
        {
            return db.Employees.Where(x => x.Isdeleted == false).ToList();
        }

        public Employee SelectById(int itemId)
        {
            return db.Employees.Find(itemId);
        }
    }
}
