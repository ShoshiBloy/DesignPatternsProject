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
        public Folder(string name):base(name)
        {
            Items = new List<FolderItem>();
            Name = name;
        }
        public string Add(FolderItem item)
        {
            this.Items.Add(item);
          return  $"'{item.Name}' added to the folder";
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
        

        public override void Open(FolderItem folder)
        {
            throw new NotImplementedException();
        }

        public override string Update(FolderItem folder)
        {
            throw new NotImplementedException();
        }
    }
}
