using FluentAssertions;
using kubectlWrapper.Shared.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace kubectlWrapper.Tests
{
    class kubectlViewModelUnitTests
    {

        [Test]
        public void kubectl_gets_nodes()
        {
            var vm = new KubectlViewModel();
            vm.Nodes = string.Empty;
            vm.GetNodes();

            vm.Nodes.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void kubectl_get_cluster_info()
        {
            var vm = new KubectlViewModel();
            vm.ClusterInfo = string.Empty;
            vm.GetClusterInfo();

            vm.ClusterInfo.Should().NotBeNullOrEmpty();
        }

        //[Test]
        //public void kubectl_gets_cluster_name()
        //{
        //    var vm = new KubectlViewModel();
        //    vm.GetNodes();

        //    vm.Nodes.Should().NotBeNullOrEmpty();
        //}
    }
}
