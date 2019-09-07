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

        public List<string> SelectDirectory()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = @"C:\Users\Alex\SudoNet\kube";
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() != CommonFileDialogResult.Ok)
            {
                return new List<string>();
            }
            var files = Directory.GetFiles(dialog.FileName);

            return new List<string>(files);
            //return "You selected: " + dialog.FileName;
        }
    }
}
