using GalaSoft.MvvmLight;
using kubectlWrapper.Shared.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace kubectlWrapper.Shared.ViewModels
{
    public class KubectlViewModel : ViewModelBase
    {
        private string nodes;
        private string error;

        public string Nodes
        {
            get { return nodes; }
            set
            {
                nodes = value;
                RaisePropertyChanged(nameof(Nodes));
            }
        }

        private string clusterInfo;

        public string ClusterInfo
        {
            get { return clusterInfo; }
            set
            {
                clusterInfo = value;
                RaisePropertyChanged(nameof(Nodes));
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

        public void GetNodes()
        {
            var p = new Process();
            p.StartInfo.FileName = "ssh";
            p.StartInfo.Arguments = SSHArgs.GetNodes;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            Nodes = String.Empty;
            Error = String.Empty;
            Nodes = p.StandardOutput.ReadToEnd();
            Error = p.StandardError.ReadToEnd();


            p.WaitForExit();
        }

        public void GetClusterInfo()
        {
            var p = new Process();
            p.StartInfo.FileName = "ssh";
            p.StartInfo.Arguments = SSHArgs.GetConfig;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            ClusterInfo = String.Empty;
            Error = String.Empty;
            ClusterInfo = p.StandardOutput.ReadToEnd();
            Error = p.StandardError.ReadToEnd();
            p.WaitForExit();
        }
    }
}
