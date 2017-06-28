using DP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.Repository
{
    public class DBTool
    {
        private static DPEntities _dbInstance;

        public static DPEntities DBInstance
        {
            get
            {
                if (_dbInstance == null)
                {
                    _dbInstance = new DPEntities();
                }
                return _dbInstance;
            }
        }
    }
}
