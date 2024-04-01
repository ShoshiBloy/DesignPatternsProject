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
            this.Name = name;
            this.Type = type;
            this.Items = new();
        }
        public string Add(FolderItem item)
        {
            this.Items.Add(item);
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
            this.Items= branch.Items;
            return $"Branch '{this.Name}' merged with branch '{branch.Name}'.";
        }
    
        
    }
}
