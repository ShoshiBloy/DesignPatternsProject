using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject.Composite
{
    public class Folder : FolderItem
    {
        public List<FolderItem> Items { get; set; }
        public Folder(string name)
        {
            Items = new List<FolderItem>();
            Name = name;
        }
        public void Add(FolderItem item)
        {
            Items.Add(item);
        }
        public void Remove(FolderItem item)
        {
            Items.Remove(item);
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
