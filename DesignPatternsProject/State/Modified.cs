using DesignPatternsProject.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.State
{
    public class Modified : FileState
    {
        public Modified(Composite.File file) : base(file)
        {
        }

        public override string Commit()
        {
            string commit;
            File.State = new Commited(File);
            Console.WriteLine("Enter your commit");
            commit = Console.ReadLine();
            return $"The commit '{commit}' was successfully executed";
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
            throw new NotImplementedException();
        }

        public override string UndoACommit()
        {
            throw new NotImplementedException();
        }
    }
}
