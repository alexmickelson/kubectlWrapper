using FluentAssertions;
using kubectlWrapper.Shared.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace kubectlWrapper.Tests
{
    class kubectlViewModelUnitTests
    {
        [Test]
        public void kubectl_get_cluster_info()
        {
            var vm = new KubectlViewModel();
            vm.ClusterInfo = string.Empty;
            var t = vm.GetClusterInfo();
            t.Wait();

            vm.ClusterInfo.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void kubectl_gets_nodes()
        {
            var vm = new KubectlViewModel();
            vm.Nodes = string.Empty;
            var t = vm.GetNodes();
            t.Wait();

            vm.Nodes.Should().NotBeNullOrEmpty();
        }


        [Test]
        public void kubectl_get_deployments()
        {
            var vm = new KubectlViewModel();
            vm.Deployments = string.Empty;
            var t=vm.GetDeployments();
            t.Wait();

            vm.Deployments.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void kubectl_get_services()
        {
            var vm = new KubectlViewModel();
            vm.Services = string.Empty;
            var t = vm.GetServices();
            t.Wait();

            vm.Services.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void kubectl_get_pods()
        {
            var vm = new KubectlViewModel();
            vm.Pods = string.Empty;
            var t = vm.GetPods();
            t.Wait();

            vm.Pods.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void bad_command_throws_error()
        {
            var vm = new KubectlViewModel();
            var p = new Process();
            vm.Error = string.Empty;
            p.StartInfo.FileName = "ToTalyNotACoMMAND";
            Action act = () => {
                var t = vm.RunProcessAsync(p);
                t.Wait();
            };

            act.Should().Throw<Exception>();

        }


    }
}
