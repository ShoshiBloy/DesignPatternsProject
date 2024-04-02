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

            return File.ErrorMessage();
        }

        public override string FinishEditing()
        {
            File.State = new Modified(File);
            File.PushToHistory();
            return $"File '{File.Name}' editing comleted";
        }

        public override string Merge(Composite.File file)
        {
            return File.ErrorMessage();
        }

        public override string RequestAReview(List<Collabrator> collabrators)
        {
            return File.ErrorMessage();
        }

        public override string UndoACommit()
        {
            return File.ErrorMessage();
        }
    }
}
