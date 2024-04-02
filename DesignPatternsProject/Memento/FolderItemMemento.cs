using DesignPatternsProject.Composite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Memento
{
    public class FolderItemMemento : IFolderItemMemento
    {
        private DateTime _date;
        private FolderItem _lastInitialState;
        public FolderItemMemento(FolderItem lastInitialState)
        {
            _date = DateTime.Now;
            _lastInitialState = lastInitialState;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public FolderItem GetLastState()
        {
            return _lastInitialState;
        }
        
    }
}
