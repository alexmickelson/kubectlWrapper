using kubectlWrapper.Shared.Services;
using kubectlWrapper.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kubectlWrapper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kubectl = new KubectlViewModel(new SshKube());
            var b = kubectl.Connectivity();
            System.Console.WriteLine("Connection Status: \n" + kubectl.Connection);

            kubectl.GetClusterInfo();
            kubectl.GetNodes();
            kubectl.GetPods();
            kubectl.GetDeployments();
            kubectl.GetServices();
            kubectl.GetNamespaces();


            System.Console.WriteLine("Cluster info: \n" + kubectl.ClusterInfo);
            System.Console.WriteLine("Nodes: \n" + kubectl.Nodes);
            System.Console.WriteLine("Pods: \n" + kubectl.Pods);
            System.Console.WriteLine("Deployments: \n" + kubectl.Deployments);
            System.Console.WriteLine("Services: \n" + kubectl.Services);
            System.Console.WriteLine("Namespaces: \n" + kubectl.Namespaces);

        }
    }
}
