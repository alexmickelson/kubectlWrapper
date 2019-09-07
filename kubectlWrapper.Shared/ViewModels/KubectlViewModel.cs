using kubectlWrapper.Shared.Data;
using kubectlWrapper.Shared.Services;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace kubectlWrapper.Shared.ViewModels
{
    public class KubectlViewModel : BindableBase
    {

        private IFileService Fileservice { get; }
        private IKubeService KubectlService;
        public KubectlViewModel(IKubeService KubectlService,
                                IFileService fileservice)
        {
            this.KubectlService = KubectlService;
            Fileservice = fileservice;
            SelectedFile = null;
        }

        private DelegateCommand getNodes;
        public DelegateCommand GetNodes => getNodes ?? (getNodes = new DelegateCommand(
                        //execute
                        async () => {
                            Nodes = "Getting Nodes";
                            Nodes = await KubectlService.Kubectl(SSHArgs.GetNodes);
                            },
                        //can execute
                        () => true
                    ));

        private DelegateCommand getClusterInfo;
        public DelegateCommand GetClusterInfo => getClusterInfo ?? (getClusterInfo = new DelegateCommand(
                        //execute
                        async () => {
                            ClusterInfo = "Getting Cluster Info";
                            ClusterInfo = await KubectlService.Kubectl(SSHArgs.GetConfig);
                            },
                        //can execute
                        () => true
                    ));

        private DelegateCommand getPods;
        public DelegateCommand GetPods => getPods ?? (getPods = new DelegateCommand(
                        //execute
                        async () => {
                            Pods = "Getting Pods";
                            Pods = await KubectlService.Kubectl(SSHArgs.GetPods);
                            },
                        //can execute
                        () => true
                    ));

        private DelegateCommand getDeployments;
        public DelegateCommand GetDeployments => getDeployments ?? (getDeployments = new DelegateCommand(
                        //execute
                        async () => {
                            Deployments = "Getting Deployments";
                            Deployments = await KubectlService.Kubectl(SSHArgs.GetDeployments);
                            },
                        //can execute
                        () => true
                    ));

        private DelegateCommand getServices;
        public DelegateCommand GetServices => getServices ?? (getServices = new DelegateCommand(
                        //execute
                        async () => {
                            Services = "Getting Services";
                            Services = await KubectlService.Kubectl(SSHArgs.GetServices);
                            },
                        //can execute
                        () => true
                    ));

        private DelegateCommand getNamespaces;
        public DelegateCommand GetNamespaces => getNamespaces ?? (getNamespaces = new DelegateCommand(
                        //execute
                        async () =>
                        {
                            Namespaces = "Getting Namespaces";
                            Namespaces = await KubectlService.Kubectl(SSHArgs.GetNamespaces);
                        },
                        //can execute
                        () => true
                    ));

        private DelegateCommand getConnectivity;
        public DelegateCommand GetConnectivity => getConnectivity ?? (getConnectivity = new DelegateCommand(
                        //execute
                        async () =>
                        {
                            Connection = "Getting Connection";
                            Connection = await KubectlService.Kubectl(SSHArgs.CheckConnectivity);
                        },
                        //can execute
                        () => true
                    ));

        private DelegateCommand selectDirectory;
        public DelegateCommand SelectDirectory => selectDirectory ?? (selectDirectory = new DelegateCommand(
                        //execute
                        async () =>
                        {
                            FileList = new ObservableCollection<string>(Fileservice.SelectDirectory());
                        },
                        //can execute
                        () => true
                    ));
        

        private DelegateCommand applyYaml;
        public DelegateCommand ApplyYaml => applyYaml ?? (applyYaml = new DelegateCommand(
                        //execute
                        async () =>
                        {
                            ApplyYamlStatus = "Applying YAML...";
                            ApplyYamlStatus = await KubectlService.ApplyYaml(SelectedFile);
                        }
                    ));

        private ObservableCollection<string> fileList;
        public ObservableCollection<string> FileList
        {
            get { return fileList; }
            set
            {
                fileList = value;
                RaisePropertyChanged(nameof(FileList));
            }
        }

        private string applyYamlStatus;
        public string ApplyYamlStatus
        {
            get { return applyYamlStatus; }
            set
            {
                applyYamlStatus = "Status: " +  value;
                RaisePropertyChanged(nameof(ApplyYamlStatus));
            }
        }

        public bool IsSelectedFile => !string.IsNullOrEmpty(SelectedFile);

        private string selectedFile;
        public string SelectedFile
        {
            get { return selectedFile; }
            set
            {
                if (selectedFile != value)
                {
                    selectedFile = value;
                    SelectedFileContents = Fileservice.ReadFile(selectedFile);
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsSelectedFile));
                    RaisePropertyChanged(nameof(ApplyYaml));
                }
            }
        }

        private string selectedFileContents;
        public string SelectedFileContents
        {
            get { return selectedFileContents; }
            set
            {
                selectedFileContents = value;
                RaisePropertyChanged(nameof(SelectedFileContents));
            }
        }

        private string clusterInfo;
        public string ClusterInfo
        {
            get { return clusterInfo; }
            set
            {
                clusterInfo = value;
                RaisePropertyChanged(nameof(ClusterInfo));
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
            [MethodImpl(MethodImplOptions.Synchronized)]
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
                RaisePropertyChanged(nameof(Deployments));
            }
        }

        private string services;
        public string Services
        {
            get { return services; }
            set
            {
                services = value;
                RaisePropertyChanged(nameof(Services));
            }
        }

        private string pods;
        public string Pods
        {
            get { return pods; }
            set
            {
                pods = value;
                RaisePropertyChanged(nameof(Pods));
            }
        }

        private string namespaces;
        public string Namespaces
        {
            get { return namespaces; }
            set
            {
                namespaces = value;
                RaisePropertyChanged(nameof(Namespaces));
            }
        }
        
        private string connection;
        public string Connection
        {
            get { return connection; }
            set
            {
                connection = value;
                RaisePropertyChanged(nameof(Connection));
            }
        }

    }
}
