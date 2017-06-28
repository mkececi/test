using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.DAL
{
    public class EntitiyBase
    {
        public EntitiyBase()
        {
            CreatedDate = DateTime.Now;
            Isdeleted = false;
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Isdeleted { get; set; }
    }
}
