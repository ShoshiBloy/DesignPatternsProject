using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject
{
    public class Repository
    {
        public string Name { get; set; }
        public List<Branch> branches { get; set; }
        public List<Collabrator> collabrators { get; set; }
        public User User { get; set; }
        public Repository(string name, User user)
        {
            Name = name;
            branches = new List<Branch>();
            collabrators = new List<Collabrator>();
            User = user;
        }
        public void AddBranch(Branch branch)
        {
            branches.Add(branch);
        }
        public void AddCollabrator(Collabrator collabrator)
        {
            collabrators.Add(collabrator);
        }
    }
}
