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
        public FileState State {  get; set; }
        

        public File(string name) : base(name)
        {
            State = new Draft(this);
            
        }

        public File(string name,FileState state) : base(name)
        {
            State =  state;

        }
        public  string Update(FolderItem folder)
        {
            State = new Draft(this);
            return $"'{folder.Name}' update";
        }

        public  string Review() {

            return $"The file '{Name}' passed a review";
        }

        public override string Open()
        {
            return $"The file '{Name}' was opened";
        }

        public override FolderItem Clone()
        {
            File Clonefolder = new(Name,State);
            return Clonefolder;
        }
        public string ErrorMessage()
        {
            return $"You can't do this action, you're in {State}";
        }
        public void Undo()
        {
            if (Mementos.Count > 0)
            {
                var memento = Mementos.Pop().GetLastState();
                State = (memento as File).State;
                Name = memento.Name;
            }
            else
            {
                Console.WriteLine("no history");
            }
        }
        public void ShowHistory()
        {
            Console.WriteLine("Caretaker: Here's the list of mementos:");
            foreach (var item in Mementos)
            {
                Console.WriteLine($"{item.GetDate()} {(item as File).State}");
            }
        }
    }
}
