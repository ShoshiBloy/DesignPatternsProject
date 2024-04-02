using DesignPatternsProject.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject
{
    public class Collabrator : User
    {
        public bool Message { get; set; }
        public Collabrator(string name, int password):base(name,password) { 
            Message = false;
        }
        public void HasAMessage()
        {
            Message = true;
        }
        public bool Review(Composite.File file)
        {
            return true;
        }
    }
}
