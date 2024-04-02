using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.State
{
    public class Merged : FileState
    {
        public Merged(Composite.File file) : base(file)
        {
        }

        public override string Commit()
        {   string commit;
            File.State = new Commited(File);
            File.PushToHistory();
            Console.WriteLine("Enter your commit");
            commit=Console.ReadLine();
            return $"The commit '{commit}' was successfully executed";
        }

        public override string FinishEditing()
        {
            return File.ErrorMessage();
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
