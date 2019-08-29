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
            vm.Output = string.Empty;
            vm.GetNodes();

            vm.Output.Should().NotBeNullOrEmpty();

        }
    }
}
