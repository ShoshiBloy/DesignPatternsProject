using DesignPatternsProject.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.State
{
    public class Commited : FileState
    {
        public Commited(Composite.File file) : base(file)
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
            throw new NotImplementedException();
        }

        public override string RequestAReview(List<Collabrator> collabrators)
        {
            if (collabrators != null)
            {
                Review review = new Review(collabrators, File);
                ReviewsManager.AddReview(review);
                File.State = new UnderReview(File);
            }
            else
            {
                File.State = new Merged(File);
            }
            return $"A review request has been sent for the file '{File.Name}'";
        }

        public override string UndoACommit()
        {
            throw new NotImplementedException();
        }
    }
}
