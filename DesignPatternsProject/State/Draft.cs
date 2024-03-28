using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.State
{
    public class Draft : FileState
    {
        public Draft(Composite.File file) : base(file)
        {
        }

        public override string Commit()
        {
            throw new NotImplementedException();
        }

        public override string Merge(Composite.File file)
        {
            throw new NotImplementedException();
        }

        public override string RequestAReview(List<Collabrator> collabrators)
        {
            int countPermissions = 0;
            if (collabrators != null)
            {
                foreach (var collabrator in collabrators)
                {
                    if (collabrator.Review() == true)
                    {
                        countPermissions++;
                    }
                }
                if (countPermissions > 2||countPermissions==collabrators.Count()) {
                    File.State = new ReadyTomerged(File);
                }
            }
            else File.State = new ReadyTomerged(File);
            return $"The file '{File.Name}' is ready to merge";
        }

        public override string UndoACommit()
        {
            throw new NotImplementedException();
        }
    }
}
