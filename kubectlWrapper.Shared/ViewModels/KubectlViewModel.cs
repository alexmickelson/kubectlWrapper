using GalaSoft.MvvmLight;
using kubectlWrapper.Shared.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace kubectlWrapper.Shared.ViewModels
{
    public class KubectlViewModel : ViewModelBase
    {

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

        private string error;
        public string Error
        {
            get => error;
            set
            {
                error = value;
                RaisePropertyChanged(nameof(Error));
            }
        }

        private string nodes;
        public string Nodes
        {
            get { return nodes; }
            set
            {
                nodes = value;
                RaisePropertyChanged(nameof(Nodes));
            }
        }

        private string deployments;
        public string Deployments
        {
            get { return deployments; }
            set
            {
                deployments = value;
                RaisePropertyChanged(nameof(Error));
            }
        }

        private string services;
        public string Services
        {
            get { return services; }
            set
            {
                services = value;
                RaisePropertyChanged(nameof(Error));
            }
        }

        private string pods;

        public string Pods
        {
            get { return pods; }
            set
            {
                pods = value;
                RaisePropertyChanged(nameof(Error));
            }
        }

        private string namespaces;

        public string Namespaces
        {
            get { return namespaces; }
            set
            {
                namespaces = value;
                RaisePropertyChanged(nameof(Error));
            }
        }


        public async Task<bool> GetNodes()
        {
            var p = new Process();
            p.StartInfo.FileName = "ssh";
            p.StartInfo.Arguments = SSHArgs.GetNodes;

            Nodes = await RunProcessAsync(p);
            return true;
        }

        public async Task<bool> GetClusterInfo()
        {
            var p = new Process();
            p.StartInfo.FileName = "ssh";
            p.StartInfo.Arguments = SSHArgs.GetConfig;

            ClusterInfo = await RunProcessAsync(p);
            return true;
        }

        public async Task<bool> GetDeployments()
        {
            var p = new Process();
            p.StartInfo.FileName = "ssh";
            p.StartInfo.Arguments = SSHArgs.GetDeployments;

            Deployments = await RunProcessAsync(p);
            return true;
        }


        public async Task<bool> GetServices()
        {
            var p = new Process();
            p.StartInfo.FileName = "ssh";
            p.StartInfo.Arguments = SSHArgs.GetServices;

            Services = await RunProcessAsync(p);
            return true;
        }

        public async Task<bool> GetPods()
        {
            var p = new Process();
            p.StartInfo.FileName = "ssh";
            p.StartInfo.Arguments = SSHArgs.GetPods;

            Pods = await RunProcessAsync(p);
            return true;
        }

        public async Task<bool> GetNamespaces()
        {
            var p = new Process();
            p.StartInfo.FileName = "ssh";
            p.StartInfo.Arguments = SSHArgs.GetNamespaces;

            Namespaces = await RunProcessAsync(p);
            return true;
        }


        public Task<string> RunProcessAsync(Process process)
        {
            var tcs = new TaskCompletionSource<string>();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardError = true;
            process.EnableRaisingEvents = true;

            process.Exited += (sender, args) =>
            {
                if (process.ExitCode != 0)
                {
                    Error = "The process did not exit correctly. \n" +
                        "The corresponding error message was: \n" +
                        process.StandardError.ReadToEnd();
                    tcs.SetResult("Error running command " + process.StartInfo.FileName + " " + process.StartInfo.Arguments);
                }
                else
                {
                    tcs.SetResult(process.StandardOutput.ReadToEnd());

                }
                process.Dispose();
            };
            process.Start();
            return tcs.Task;
        }
    }
}
