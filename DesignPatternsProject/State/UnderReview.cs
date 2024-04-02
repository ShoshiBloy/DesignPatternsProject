using DesignPatternsProject.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.State
{
    public class UnderReview : FileState
    {
        public UnderReview(Composite.File file) : base(file)
        {
        }

        public override string Commit()
        {
            return File.ErrorMessage();
        }

        public override string FinishEditing()
        {
            return File.ErrorMessage();
        }

        public override string Merge(Composite.File file)
        {

            
            bool permission = ReviewsManager.CheckPermission(file);
            if (permission)
            {
                file = File;
                File.State = new Merged(File);
                File.PushToHistory();
                return $"The file '{File.Name}' has been successfully merged";
            }
            File.State=new Draft(File);
            File.PushToHistory();
            return $"The file '{File.Name}' has been sent for re-editing";
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
