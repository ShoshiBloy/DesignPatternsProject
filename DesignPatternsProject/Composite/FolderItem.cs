using FinalProject.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPatternsProject.Composite
{
    public abstract class FolderItem
    {
        public string Name { get; set; }

        public Stack<IFolderItemMemento> Mementos = new Stack<IFolderItemMemento>();

        public abstract string Open();
        public abstract FolderItem Clone();

        public FolderItem(string name)
        {
            Name = name;
        }

        public void PushToHistory()
        {
            var temp = this.Clone();
            Mementos.Push(new FolderItemMemento(temp));
        }

        
    }
}
