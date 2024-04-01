using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsProject.Command;
using DesignPatternsProject.Composite;
namespace DesignPatternsProject
{
    public abstract class FileState
    {
        public Composite.File File { get; set; }
        public ReviewsManager ReviewsManager { get; }
        public  FileState(Composite.File file)
        {
            File = file;
            ReviewsManager = Command.ReviewsManager.GetInstance();
        }

    

        public abstract string Commit();
        public abstract string Merge(Composite.File file);
        public abstract string UndoACommit();
        public abstract string RequestAReview(List<Collabrator> collabrators);
        public abstract string FinishEditing();

    }
}
