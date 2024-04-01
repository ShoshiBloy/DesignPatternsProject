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
            throw new NotImplementedException();
        }

        public override string FinishEditing()
        {
            throw new NotImplementedException();
        }

        public override string Merge(Composite.File file)
        {

            List<Review> reviews = ReviewsManager.afterReview;
            bool permission = false;
            foreach (Review review in reviews)
            {
                if (review.file.Name == file.Name)
                    permission = review.ReviewPermission;
            }
            if (permission)
            {
                file = File;
                File.State = new Merged(File);
                return $"The file '{File.Name}' has been successfully merged";
            }
            File.State=new Draft(File);
            return $"The file '{File.Name}' has been sent for re-editing";
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
