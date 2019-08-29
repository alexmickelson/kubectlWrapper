using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace kubectlWrapper.Shared.ViewModels
{
    public class KubectlViewModel : ViewModelBase
    {
        private string nodes;
        private string output;
        private string error;

        public string Nodes
        {
            get { return nodes; }
            set { nodes = value; }
        }


        public string Output
        {
            get => output;
            set
            {
                output = value;
                RaisePropertyChanged(nameof(Output));
            }
        }
        public string Error
        {
            get => error;
            set
            {
                error = value;
                RaisePropertyChanged(nameof(Error));
            }
        }

        public async void GetNodes()
        {
            var p = new Process();
            p.StartInfo.FileName = "ssh";

            p.StartInfo.Arguments = "benny kubectl get nodes";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            //2) capture stdout
            Output = String.Empty;
            Error = String.Empty;

            p.WaitForExit();
        }
    }
}
