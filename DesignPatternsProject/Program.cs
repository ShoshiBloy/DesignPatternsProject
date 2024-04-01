// See https://aka.ms/new-console-template for more information
using DesignPatternsProject;
using DesignPatternsProject.Command;
using DesignPatternsProject.Composite;

Console.WriteLine("Hello, World!");
DesignPatternsProject.Composite.File file1 = new("File1");
Folder folder1 = new("folder1");
Folder folder2 = new("folder2");
Branch branch = new("DP","Main");
Console.WriteLine(branch.Add(file1)); 
branch.Items.Add(folder2);
file1.
//branch.Items.