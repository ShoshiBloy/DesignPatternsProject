using DesignPatternsProject.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPatternsProject
{
    public class User
    {
        public string Name { get; set; }
        public int Password { get; set; }
        public List<Repository> Repositories { get; set; }
        public User(string name, int password) { 
            Name = name;
            Password = password;
            Repositories = new List<Repository>();
        }
        public void CreateRepository(string name)
        {
            
            Repositories.Add(new Repository(name,this));
        }

        public void CreateBranchInRepository(string Reponame,string BranchName)
        {   
            Branch branch=new Branch(BranchName, "Main");
            Repositories.Find(r => r.Name == Reponame).AddBranch(branch);
        }

        public void AddCollabrator(string name,int password, string repositoryName)
        {
            Collabrator collabrator= new Collabrator(name,password);
            Repositories.Find(r => r.Name == repositoryName).AddCollabrator(collabrator);
        }

        public void CloneBranchInRepository(string repoName,string branchName)
        {
            string type;
            Console.WriteLine("Enter branch type");
            type = Console.ReadLine();
            Repositories.Find(r => r.Name == repoName).AddBranch(Repositories.Find(r => r.Name == repoName).branches.Find(r => r.Name == branchName).CreateBranch(type));
        }

        public string Merge(string repoName, string sourceBranch,string destinationBranch)
        {
            Repository temp = Repositories.Find(r => r.Name == repoName);
                return temp.branches.Find(r => r.Name == sourceBranch).Merge(temp.branches.Find(r => r.Name == destinationBranch));
        }
        public string Commit(string repoName, string branchName, string fileName)
        {
            Repository temp = Repositories.Find(r => r.Name == repoName);
             FolderItem file=temp.branches.Find(r => r.Name == branchName).Items.Find(r => r.Name == fileName);
            return (file as Composite.File).State.Commit();
        }
        public string AddItemToBranch(string repoName, string branchName)
        {
            string itemName;
            Console.WriteLine("Enter item name");
            itemName = Console.ReadLine();
            string type;
            Console.WriteLine("Enter item type");
            type = Console.ReadLine();
            if (Equals(type,"Folder"))
                {
                Folder folder = new Folder(itemName);
              return  Repositories.Find(r => r.Name == repoName).branches.Find(r => r.Name == branchName).AddToBranch(folder);
            }
            if (Equals(type, "File"))
            {
               Composite.File file = new Composite.File(itemName);
             return   Repositories.Find(r => r.Name == repoName).branches.Find(r => r.Name == branchName).AddToBranch(file);
            }
            return "Cannot add it";
        }

        public string AddItemToFolder(string repoName, string branchName, string folderNmae)
        {
            string itemName;
            Console.WriteLine("Enter item name");
            itemName = Console.ReadLine();
            string type;
            Console.WriteLine("Enter item type");
            type = Console.ReadLine();
            if (Equals(type, "Folder"))
            {
                Folder folder = new Folder(itemName);
                FolderItem temp = Repositories.Find(r => r.Name == repoName).branches.Find(r => r.Name == branchName).Items.Find(r => r.Name == folderNmae);
                return (temp as Folder).Add(folder);
            }
            if (Equals(type, "File"))
            {
                Composite.File file = new Composite.File(itemName);
                FolderItem temp = Repositories.Find(r => r.Name == repoName).branches.Find(r => r.Name == branchName).Items.Find(r => r.Name == folderNmae);
                return (temp as Folder).Add(file);
            }
            return "Cannot add it";
        }
        public string RequestAReview(string repoName, string branchName,string fileName)
        {
            FolderItem temp = Repositories.Find(r => r.Name == repoName).branches.Find(r => r.Name == branchName).Items.Find(r => r.Name == fileName);
            
            return (temp as Composite.File).State.RequestAReview(Repositories.Find(r => r.Name == repoName).collabrators);
           
        }
        public void GetHistoryOfAFile(string repoName, string branchName, string fileName)
        {
            FolderItem temp = Repositories.Find(r => r.Name == repoName).branches.Find(r => r.Name == branchName).Items.Find(r => r.Name == fileName);

            (temp as Composite.File).ShowHistory();
        }

        public void GetHistoryOfAFolder(string repoName, string branchName, string fileName)
        {
            FolderItem temp = Repositories.Find(r => r.Name == repoName).branches.Find(r => r.Name == branchName).Items.Find(r => r.Name == fileName);

            (temp as Folder).ShowHistory();
        }

        //        DesignPatternsProject.Composite.File file1 = new("File1");
        //        Folder folder1 = new("folder1");
        //        Folder folder2 = new("folder2");
        //        Branch branch = new("DP", "Main");
        //        Console.WriteLine(branch.Add(file1)); 
        //branch.Items.Add(folder2);
    }
}
