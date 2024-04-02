using DesignPatternsProject.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsProject
{
    public class Branch
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<FolderItem> Items { get; set; }
       

        public Branch(string name, string type)
        {
            Name = name;
            Type = type;
            Items = new();
        }
        public Branch(string name, string type, List<FolderItem> items)
        {
            Name = name;
            Type = type;
            Items = new();
            foreach (var item in items)
            {
                Items.Add(item.Clone());
            }
        }
        public Branch CreateBranch(string type)
        {;
            Branch CloneBranch = new(Name, type, Items);
            return CloneBranch;
        }
        public string AddToBranch(FolderItem item)
        {
            Items.Add(item);
            if (item is Folder)
                (item as Folder).PushToHistory();
            return $"'{item.Name}' added to the branch";
        }

        //public void AddToFolder(FolderItem item)
        //{
        //    foreach (var item1 in Items) 
        //    {
        //        if (item1 is Folder)
        //        {
        //            if((item1 as Folder).AddToFolder(item)==true) { 
        //                return;
        //            }
        //        }

        //    }
        //    AddToBranch(item);
        //}
        //public void AddToBranch(FolderItem item)
        //{
        //    Items.Add(item);
        //    Console.WriteLine($"'{item.Name}' added to the branch");
        //} 
        //public string RemoveFromBranch(FolderItem item)
        //{
        //    if (Items.Contains(item))
        //    {
        //        Items.Remove(item);
        //        return $"The item '{item.Name}' was deleted succesfully";
        //    }
        //    else return Remove(item);
        //}
        //public string Remove(FolderItem item)
        //{
        //    foreach (var item1 in Items) 
        //    {
        //        if (item1 is Folder)
        //        {
        //            if ((item1 as Folder).Remove(item)==true);
        //                return $"The item '{item.Name}' was deleted succesfully";
        //        }
        //    }
        //    return $"The destination or the item were invalid";
        //}

        public string Merge(Branch branch)
        {
            if(Name==branch.Name)
            {
               for(int i = 0; i <Items.Count(); i++)
                {
                    if (Items[i] is Composite.File)
                    {
                        (Items[i] as Composite.File).State.Merge(branch.Items[i] as Composite.File);
                    }
                    else
                    {
                        (Items[i] as Folder).Merge((branch.Items[i] as Folder));
                        
                        }
                    }return $"Branch '{this.Name}' merged with branch '{branch.Name}'.";
                }
            return $"Branch '{Name}' can't be merged with branch '{branch.Name}'.";
        }
    }
}
