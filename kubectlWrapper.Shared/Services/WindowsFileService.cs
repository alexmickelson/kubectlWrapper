using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace kubectlWrapper.Shared.Services
{
    public class WindowsFileService : IFileService
    {
        public string ReadFile(string location)
        {
            return System.IO.File.ReadAllText(location);
        }

        public List<string> ReadDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                return new List<string>(Directory.GetFileSystemEntries(directory));
            }
            else
            {
                return null;
            }
        }


    }
}
