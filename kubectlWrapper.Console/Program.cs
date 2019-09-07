using kubectlWrapper.Shared.Services;
using kubectlWrapper.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace kubectlWrapper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kubectl = new KubectlViewModel(new SshKube(), new WindowsFileService());

            kubectl.GetClusterInfo.Execute();
            kubectl.GetNodes.Execute();
            kubectl.GetPods.Execute();
            kubectl.GetDeployments.Execute();
            kubectl.GetServices.Execute();
            kubectl.GetNamespaces.Execute();

            while (true)
            {
                System.Console.WriteLine("Cluster info: \n" + kubectl.ClusterInfo);
                System.Console.WriteLine("Nodes: \n" + kubectl.Nodes);
                System.Console.WriteLine("Pods: \n" + kubectl.Pods);
                System.Console.WriteLine("Deployments: \n" + kubectl.Deployments);
                System.Console.WriteLine("Services: \n" + kubectl.Services);
                System.Console.WriteLine("Namespaces: \n" + kubectl.Namespaces);
                Thread.Sleep(1000);
            }


        }
    }
}
