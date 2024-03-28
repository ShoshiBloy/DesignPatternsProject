using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject
{
    public class User
    {
        public string Name { get; set; }
        public int Password { get; set; }
        public List<Branch> Branches { get; set; }
    }
}
