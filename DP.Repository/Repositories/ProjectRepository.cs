using DP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Repository.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        DPEntities db = DBTool.DBInstance;
        public int insert(Project item)
        {
            db.Projects.Add(item);
            return db.SaveChanges();
        }

        public int Update(Project item)
        {
            Project update = db.Projects.Find(item.Id);
            db.Entry(update).CurrentValues.SetValues(item);
            return db.SaveChanges();
        }

        public int Delete(int itemId)
        {
            Project deleted = db.Projects.Find(itemId);
            deleted.Isdeleted = true;
            return db.SaveChanges();
        }

        public List<Project> SelectAll()
        {
            return db.Projects.Where(x => x.Isdeleted == false).ToList();
        }

        public Project SelectById(int itemId)
        {
            return db.Projects.Find(itemId);
        }
    }
}
