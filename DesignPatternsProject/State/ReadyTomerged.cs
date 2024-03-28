using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.State
{
    public class ReadyTomerged : FileState
    {
        public ReadyTomerged(Composite.File file) : base(file)
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
            throw new NotImplementedException();
        }

        public override string UndoACommit()
        {
            throw new NotImplementedException();
        }
    }
}
