using kubectlWrapper.Shared.ViewModels;
using System;

namespace kubectlWrapper.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kubectl = new KubectlViewModel();
            kubectl.GetClusterInfo();
            System.Console.WriteLine("Cluster Info:");
            System.Console.WriteLine(kubectl.ClusterInfo);

            kubectl.GetNodes();
            System.Console.WriteLine("Nodes:");
            System.Console.WriteLine(kubectl.Nodes);

            kubectl.();
            System.Console.WriteLine("Nodes:");
            System.Console.WriteLine(kubectl.Nodes);

        }
    }
}
