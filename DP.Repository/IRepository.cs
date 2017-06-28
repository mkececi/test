using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Repository
{
    public interface IRepository<T>
    {
        int insert(T item);
        int Update(T item);
        int Delete(int itemId);
        List<T> SelectAll();
        T SelectById(int itemId);
    }
}
