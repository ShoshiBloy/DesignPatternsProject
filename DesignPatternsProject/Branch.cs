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
        public Folder Items { get; set; }
       

        public Branch(string name, string type, Folder items)
        {
            this.Name = name;
            this.Type = type;
            this.Items = items;
        }

        public string Merge(Branch branch)
        {
            this.Items= branch.Items;
            return $"Branch '{this.Name}' merged with branch '{branch.Name}'.";
        }
    
        
    }
}
