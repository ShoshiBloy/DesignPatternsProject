// See https://aka.ms/new-console-template for more information
using DesignPatternsProject;
using DesignPatternsProject.Command;
using DesignPatternsProject.Composite;
User user = new("Brachi", 325928737);
user.CreateRepository("DP");
user.CreateBranchInRepository("DP", "Lesson1");
Console.WriteLine(user.AddItemToBranch("DP", "Lesson1"));
user.AddCollabrator("Shoshi",325698569,"DP");
user.CloneBranchInRepository("DP", "Lesson1");
Console.WriteLine(user.AddItemToFolder("DP", "Lesson1", "Folder")); 
//user.Merge("DP", "Lesson1", "Lesson2");
//Console.WriteLine("Hello, World!");
//DesignPatternsProject.Composite.File file1 = new("File1");
//Folder folder1 = new("folder1");
//Folder folder2 = new("folder2");
//Branch branch = new("DP","Main");

//branch.Items.Add(folder2);

//branch.Items.