using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Composite
{
    public abstract class FolderItem
    {
        public string Name { get; set; }
        public abstract void Open(FolderItem folder);
        public abstract void Update(FolderItem folder);
        public FolderItem(string name)
        {
            this.Name = name;
        }
    }
}
