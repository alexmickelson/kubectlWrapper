using kubectlWrapper.Shared.Data;
using kubectlWrapper.Shared.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace kubectlWrapper.Shared.ViewModels
{
    public class KubectlViewModel : BindableBase
    {

        private IKubeService kubectlService;
        public KubectlViewModel(IKubeService KubectlService)
        {
            kubectlService = KubectlService;
            GetNodes = new DelegateCommand(
                        //execute
                        () => Nodes = kubectlService.Kubectl(SSHArgs.GetNodes),
                        //can execute
                        () => true
                    );
        }

        private DelegateCommand getNodes;
        public DelegateCommand GetNodes
        {
            get { return getNodes; }
            set { getNodes = value; }
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


        public bool Connectivity()
        {
            Connection = kubectlService.Kubectl(SSHArgs.CheckConnectivity);
            return true;
        }

        //public bool GetNodes()
        //{
        //    Nodes = kubectlService.Kubectl(SSHArgs.GetNodes);
        //    return true;
        //}

        public bool GetClusterInfo()
        {
            ClusterInfo = kubectlService.Kubectl(SSHArgs.GetConfig);
            return true;
        }

        public bool GetDeployments()
        {
            Deployments = kubectlService.Kubectl(SSHArgs.GetDeployments);
            return true;
        }


        public bool GetServices()
        {
            Services = kubectlService.Kubectl(SSHArgs.GetServices);
            return true;
        }

        public bool GetPods()
        {
            Pods = kubectlService.Kubectl(SSHArgs.GetPods);
            return true;
        }

        public bool GetNamespaces()
        {
            Namespaces = kubectlService.Kubectl(SSHArgs.GetNamespaces);
            return true;
        }

    }
}
