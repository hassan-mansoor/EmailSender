using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPECFILE_M
{
    class CopyDirectories
    {
        string sourceFolder = ConfigurationManager.AppSettings["WEJSCIEDirectory"];
        string destFolder = ConfigurationManager.AppSettings["BUFORDirectory"];
        public List<string> MessageLogger = new List<string>();

        public void Init()
        {
            MessageLogger.Add("Start ....");
            MessageLogger.Add("Createing  Directory: "+ destFolder.Split('\\').Last());
            if (IsDirectoryExist(sourceFolder))
            {
                MessageLogger.Add("StartCopying Folder and files ....");
                CopyFolder(sourceFolder, destFolder);
            }
        }

        private void CreateNewDirectory(string directory)
        {
            Directory.CreateDirectory(directory);
        }

        private bool IsDirectoryExist(string directory)
        {
            return Directory.Exists(directory);
        }

        private void CopyFiles(string sourceFolder, string destFolder)
        {
            string[] files = Directory.GetFiles(sourceFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
                RemoveFiles(file);
            }
        }

        private void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!IsDirectoryExist(destFolder))
            {
                CreateNewDirectory(destFolder);
            }
            CopyFiles(sourceFolder, destFolder);
            string[] folders = Directory.GetDirectories(sourceFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
                MessageLogger.Add("Copping directory: "+ folder.Split('\\').Last());
                RemoveDirectory(folder);
            }
        }

        private void RemoveFiles(string file)
        {
            File.Delete(file);
        }

        private void RemoveDirectory(string direcoty)
        {
            Directory.Delete(direcoty);
        }

        public bool CheckWEJSCIEISEmpty()
        {
            return IsDirectoryExist(sourceFolder) && Directory.GetDirectories(sourceFolder).Length != 0;
        }

        public void RemoveDirectoryRecursively(string directory)
        {
            Directory.Delete(directory, true);
        }
    }
}
