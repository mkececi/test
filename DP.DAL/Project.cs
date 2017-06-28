using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.DAL
{
    public class Project : EntitiyBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
    }
}
