﻿using kubectlWrapper.Shared.Data;
using kubectlWrapper.Shared.Services;
using Prism.Commands;
using Prism.Mvvm;
using System.Runtime.CompilerServices;

namespace kubectlWrapper.Shared.ViewModels
{
    public class KubectlViewModel : BindableBase
    {

        private IKubeService kubectlService;
        public KubectlViewModel(IKubeService KubectlService)
        {
            kubectlService = KubectlService;
        }

        private DelegateCommand getNodes;
        public DelegateCommand GetNodes => getNodes ?? (getNodes = new DelegateCommand(
                        //execute
                        () => Nodes = kubectlService.Kubectl(SSHArgs.GetNodes),
                        //can execute
                        () => true
                    ));

        private DelegateCommand getClusterInfo;
        public DelegateCommand GetClusterInfo => getClusterInfo ?? (getClusterInfo = new DelegateCommand(
                        //execute
                        () => ClusterInfo = kubectlService.Kubectl(SSHArgs.GetConfig),
                        //can execute
                        () => true
                    ));

        private DelegateCommand getPods;
        public DelegateCommand GetPods => getPods ?? (getPods = new DelegateCommand(
                        //execute
                        () => Pods = kubectlService.Kubectl(SSHArgs.GetPods),
                        //can execute
                        () => true
                    ));

        private DelegateCommand getDeployments;
        public DelegateCommand GetDeployments => getDeployments ?? (getDeployments = new DelegateCommand(
                        //execute
                        () => Deployments = kubectlService.Kubectl(SSHArgs.GetDeployments),
                        //can execute
                        () => true
                    ));

        private DelegateCommand getServices;
        public DelegateCommand GetServices => getServices ?? (getServices = new DelegateCommand(
                        //execute
                        () => Services = kubectlService.Kubectl(SSHArgs.GetServices),
                        //can execute
                        () => true
                    ));

        private DelegateCommand getNamespaces;
        public DelegateCommand GetNamespaces => getNamespaces ?? (getNamespaces = new DelegateCommand(
                        //execute
                        () => Namespaces = kubectlService.Kubectl(SSHArgs.GetNamespaces),
                        //can execute
                        () => true
                    ));

        private DelegateCommand getConnectivity;
        public DelegateCommand GetConnectivity => getConnectivity ?? (getConnectivity = new DelegateCommand(
                        //execute
                        () => Connection = kubectlService.Kubectl(SSHArgs.CheckConnectivity),
                        //can execute
                        () => true
                    ));

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
