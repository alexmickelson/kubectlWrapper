using FluentAssertions;
using kubectlWrapper.Shared.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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


        //[Test]
        //public void kubectl_get_deployments()
        //{
        //    var vm = new KubectlViewModel();
        //    vm.ClusterInfo = string.Empty;
        //    vm.GetClusterInfo();

        //    vm.ClusterInfo.Should().NotBeNullOrEmpty();
        //}

        //[Test]
        //public void kubectl_get_services()
        //{
        //    var vm = new KubectlViewModel();
        //    vm.ClusterInfo = string.Empty;
        //    vm.GetClusterInfo();

        //    vm.ClusterInfo.Should().NotBeNullOrEmpty();
        //}

        //[Test]
        //public void kubectl_get_pods()
        //{
        //    var vm = new KubectlViewModel();
        //    vm.ClusterInfo = string.Empty;
        //    vm.GetClusterInfo();

        //    vm.ClusterInfo.Should().NotBeNullOrEmpty();
        //}


    }
}
