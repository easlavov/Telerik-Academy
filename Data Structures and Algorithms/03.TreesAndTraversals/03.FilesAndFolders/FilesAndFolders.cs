using System;
using System.IO;

class FilesAndFolders
{
    static void Main()
    {
        string rootDir = @"C:\Windows";
        Folder winFolder = new Folder("Windows");
        FillDirectoryTree(rootDir, winFolder);
        PrintSize(winFolder);
    }
  
    private static void PrintSize(Folder folder)
    {
        long folderSize = GetSize(folder);
        Console.WriteLine("Total size of {0} folder is {1} bytes.", folder.Name, folderSize);
    }

    private static long GetSize(Folder folder)
    {
        long totalSize = 0;
        CalcSize(folder, ref totalSize);
        return totalSize;
    }

    private static void CalcSize(Folder folder, ref long totalSize)
    {
        foreach (var file in folder.Files)
        {
            totalSize += file.Size;
        }
        foreach (var dir in folder.ChildFolders)
        {
            CalcSize(dir, ref totalSize);
        }
    }

    private static void FillDirectoryTree(string path, Folder folder)
    {
        try
        {
            // Append files
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                string fileName = GetName(file);
                FileInfo fileInfo = new FileInfo(file);
                folder.AddFile(new File(fileName, fileInfo.Length));
            }
            // Append dirs recursively
            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                string dirName = GetName(dir);
                Folder newFolder = new Folder(dirName);
                folder.AddFolder(newFolder);
                FillDirectoryTree(dir, newFolder);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
  
    private static string GetName(string dir)
    {
        int index = dir.LastIndexOf('\\') + 1;
        string fileName = dir.Substring(index, dir.Length - index);
        return fileName;
    }
}