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
        public Folder(string name) : base(name)
        {
            Items = new List<FolderItem>();

        }
        public Folder(string name, List<FolderItem> items) : base(name)
        {

            Items = new List<FolderItem>();
            foreach (var item in items)
            {
                Items.Add(item.Clone());
            }
        }
        public string Add(FolderItem item)
        {
            PushToHistory();
            Items.Add(item);
            return $"'{item.Name}' added to the folder";
        }
        //public bool AddToFolder(FolderItem item)
        //{
        //    foreach (var item1 in Items)
        //    {
        //        if (item1.Name == this.Name && item1 is Folder)
        //        {
        //            (item1 as Folder).Items.Add(item);
        //            Console.WriteLine("The item was added succesfully");
        //            return true;
        //        }
        //        if (item1 is  Folder) { 
        //            (item1 as Folder).AddToFolder(item);
        //        }
        //    }
        //    return false;
        //}
        //public bool Remove(FolderItem item)
        //{
        //    foreach (var item1 in Items)
        //    {
        //        if (item1.Name == Name && item1 is Folder)
        //        {
        //            (item1 as Folder).Items.Remove(item);
        //            return true;
        //        }
        //        if (item1 is Folder)
        //        {
        //            (item1 as Folder).Remove(item);
        //        }
        //    }
        //    return false;

        //}
        public void Merge(Folder folder)
        {
            if (Name == folder.Name)
            {
                PushToHistory();
                for (int j = 0; j < Items.Count; j++)
                {
                    if (Items[j] is Composite.File)
                    {
                        (Items[j] as Composite.File).State.Merge((folder.Items[j] as Folder).Items[j] as Composite.File);
                    }
                    else
                    {
                        (Items[j] as Folder).Merge(folder.Items[j] as Folder);
                    }
                }
            }
        }

        public override string Open()
        {
            return $"The folder '{Name}' was opened";
        }



        public override FolderItem Clone()
        {
            Folder folder = new(Name, Items);
            return folder;
        }
        public void Undo()
        {
            if (Mementos.Count > 0)
            {
                var memento = this.Mementos.Pop().GetLastState();
                Items = (memento as Folder).Items;
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
            foreach (var item in this.Mementos)
            {
                Console.WriteLine($"{item.GetDate()} {(item as Folder).Items.Count}");
            }
        }
    }
}

