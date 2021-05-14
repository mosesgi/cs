using System;
using System.IO;
using static System.Console;

namespace WorkingWithFileSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            // OutputFileSystemInfo();
            // WorkWithDrives();
            // WorkWithDirectories();
            WorkWithFiles();
        }

        static void OutputFileSystemInfo()
        {
            WriteLine("{0,-33} {1}", "Path.PathSeparator", Path.PathSeparator);
            WriteLine("{0,-33} {1}", "Path.DirectorySeparatorChar",
                Path.DirectorySeparatorChar);
            WriteLine("{0,-33} {1}", "Directory.GetCurrentDirectory()",
                Directory.GetCurrentDirectory());
            WriteLine("{0,-33} {1}", "Environment.CurrentDirectory",
                Environment.CurrentDirectory);
            WriteLine("{0,-33} {1}", "Environment.SystemDirectory", 
                Environment.SystemDirectory);
            WriteLine("{0,-33} {1}", "Path.GetTempPath()", Path.GetTempPath());
            WriteLine("GetFolderPath(SpecialFolder");
            WriteLine("{0,-33} {1}", " .System)", 
                Environment.GetFolderPath(Environment.SpecialFolder.System));
            WriteLine("{0,-33} {1}", " .ApplicationData)",
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            WriteLine("{0,-33} {1}", " .MyDocuments)",
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            WriteLine("{0,-33} {1}", " .Personal)",
                Environment.GetFolderPath(Environment.SpecialFolder.Personal));
        }

        static void WorkWithDrives()
        {
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
                "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    WriteLine(
                        "{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
                        drive.Name, drive.DriveType, drive.DriveFormat, 
                        drive.TotalSize, drive.AvailableFreeSpace);
                }
                else
                {
                    WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
                }
            }
        }

        static void WorkWithDirectories()
        {
            var newFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), 
                "Code", "Chapter09", "NewFolder");
            WriteLine($"Working with: {newFolder}");
            //check if it exists
            WriteLine($"Does it exist? {Directory.Exists(newFolder)}");
            //create directory
            WriteLine("Creating it...");
            Directory.CreateDirectory(newFolder);
            WriteLine($"Does it exist? {Directory.Exists(newFolder)}");
            Write("Confirm the directory exists, and then press Enter: ");
            ReadLine();
            //delete directory
            WriteLine("Deleting it...");
            Directory.Delete(newFolder, true);
            WriteLine($"Does it exist? {Directory.Exists(newFolder)}");
        }

        static void WorkWithFiles()
        {
            //define a directory path to output files starting in the user's folder.
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Codes", "study", "cs", "Chapter09", "OutputFiles");
            Directory.CreateDirectory(dir);
            //define file path
            string textFile = Path.Combine(dir, "Dummy.txt");
            string backupFile = Path.Combine(dir, "Dummy.bak");
            WriteLine($"Working with: {textFile}");
            //check if a file exists
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            //create a new text file and write a line to it
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello, C#!");
            textWriter.Close();     //close file and release resources.
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            //copy the file, and overwrite if it already exists
            File.Copy(textFile, backupFile, true);
            WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");
            Write("Confirm the files exist, and then press ENTER: ");
            ReadLine();
            //delete file
            File.Delete(textFile);
            WriteLine($"Does it exist? {File.Exists(textFile)}");
            //read from the text file backup
            WriteLine($"Read contents of {backupFile}:");
            StreamReader reader = File.OpenText(backupFile);
            WriteLine(reader.ReadToEnd());
            reader.Close();

            // Managing paths
            WriteLine($"Folder Name: {Path.GetDirectoryName(textFile)}");
            WriteLine($"File Name: {Path.GetFileName(textFile)}");
            WriteLine("File Name without Extension: {0}", Path.GetFileNameWithoutExtension(textFile));
            WriteLine($"File Extension: {Path.GetExtension(textFile)}");
            WriteLine($"Random File Name: {Path.GetRandomFileName()}");
            WriteLine($"Temporary File Name: {Path.GetTempFileName()}");

            var info = new FileInfo(backupFile);
            WriteLine($"{backupFile}:");
            WriteLine($"Contains {info.Length} bytes");
            WriteLine($"Last accessed {info.LastAccessTime}");
            WriteLine($"Has readonly set to {info.IsReadOnly}");
        }
    }
}
