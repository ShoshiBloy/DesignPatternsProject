using DesignPatternsProject.Composite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Memento
{
    public interface IFolderItemMemento
    {
        //string GetName();
        FolderItem GetLastState();
        DateTime GetDate();
    }
}
