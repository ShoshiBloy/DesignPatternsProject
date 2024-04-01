using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Command
{
    public class Review
    {
        public List<Collabrator> collabrators { get; set; }
        public Composite.File file;
        public bool ReviewPermission { get; set; }

        public Review(List<Collabrator> collabrators, Composite.File file)
        {
            this.collabrators = collabrators;
            this.file = file;
        }

        public bool execute(Collabrator collabrator,Composite.File _file)
        {
            ReviewPermission = collabrator.Review(_file);
            return ReviewPermission;
        }
    }
}
