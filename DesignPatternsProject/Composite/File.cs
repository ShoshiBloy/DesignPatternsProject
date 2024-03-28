using DesignPatternsProject.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Composite
{
    public class File : FolderItem
    {
        public FileState State { private get; set; }
        public File(string name):base(name)
        {
            State = new Draft(this);
        }
        public override void Open(FolderItem folder)
        {
            throw new NotImplementedException();
        }

        public override void Update(FolderItem folder)
        {
            throw new NotImplementedException();
        }
    }
}
