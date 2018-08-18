using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPECFILE_M
{
    class CopyDirectories
    {
       
        public CopyDirectories()
        {
            string sourceFolder = @"..\..\..\..\WEJSCIE\";
            string destFolder = @"..\..\..\..\BUFOR\";
            if (IsDirectoryExist(sourceFolder))
            {
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

    }
}
