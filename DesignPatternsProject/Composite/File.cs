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
        public bool Modified {get; set; }

        public File(string name) : base(name)
        {
            State = new Draft(this);
            Modified = false;
        }
        public override void Open(FolderItem folder)
        {
            throw new NotImplementedException();
        }

        public override string Update(FolderItem folder)
        {
            State = new Draft(this);
            return $"'{folder.Name}' update";
        }

        public  string Review() {

            return $"The file '{this.Name}' passed a review";
        }
    }
}
