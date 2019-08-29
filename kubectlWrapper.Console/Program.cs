using kubectlWrapper.Shared.ViewModels;
using System;
using System.Threading.Tasks;

namespace kubectlWrapper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain().Wait();

        }
        static async Task AsyncMain()
        {
            var kubectl = new KubectlViewModel();
            await kubectl.GetClusterInfo();
            System.Console.WriteLine("Cluster info: \n" + kubectl.ClusterInfo);

            await kubectl.GetNodes();
            System.Console.WriteLine("Nodes: \n" + kubectl.Nodes);

            await kubectl.GetPods();
            System.Console.WriteLine("Pods: \n" + kubectl.Pods);

            await kubectl.GetDeployments();
            System.Console.WriteLine("Deployments: \n" + kubectl.Deployments);

            await kubectl.GetServices();
            System.Console.WriteLine("Services: \n" + kubectl.Services);


        }
    }
}
