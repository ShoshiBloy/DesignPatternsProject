﻿using System;
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

        public override string FinishEditing()
        {
            File.State = new Modified(File);
            return $"File '{File.Name}' editing comleted";
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