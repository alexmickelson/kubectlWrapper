using FluentAssertions;
using kubectlWrapper.Shared.Services;
using kubectlWrapper.Wpf.ViewModels;
using Moq;
using Prism.Regions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Test2_Framework
{
    [Binding]
    public class YamlFeatureSteps
    {
        private readonly ScenarioContext context;

        public YamlFeatureSteps(ScenarioContext context)
        {
            this.context = context;

            var regionManagerMock = new Mock<IRegionManager>();
            var kubeMock = new Mock<IKubeService>();
            var fileMock = new Mock<IFileService>();

            context.Add(TestConstants.RegionManagerMock, regionManagerMock);
            context.Add(TestConstants.KubeMock, kubeMock);
            context.Add(TestConstants.FileMock, fileMock);
        }

        [Given(@"you are at the Yaml View")]
        public void GivenYouAreAtTheYamlView()
        {
            var kubeMock = context.Get<Mock<IKubeService>>(TestConstants.KubeMock);
            var regionMock = context.Get<Mock<IFileService>>(TestConstants.FileMock);
            var vm = new YamlViewModel(kubeMock.Object, regionMock.Object);
            context.Add(TestConstants.YamlViewModel, vm);
        }

        [When(@"the user provides directory (.*)")]
        public void WhenTheUserProvidesDirectory(string dir)
        {
            var fileMock = context.Get<Mock<IFileService>>(TestConstants.FileMock);
            fileMock.Setup(f => f.DirectoryIsValid("validDir")).Returns(true);
            fileMock.Setup(f => f.DirectoryIsValid("invalidDir")).Returns(false);
            fileMock.Setup(f => f.ReadDirectoryOrNull(dir)).Returns(new List<string> { });

            var vm = context.Get<YamlViewModel>(TestConstants.YamlViewModel);
            vm.SelectedDirectory = dir;
        }

        [When(@"the user selects file (.*)")]
        public void WhenTheUserSelectsFile(string file)
        {
            var fileMock = context.Get<Mock<IFileService>>(TestConstants.FileMock);
            fileMock.Setup(f => f.ReadFile(file)).Returns(string.Empty);
            var vm = context.Get<YamlViewModel>(TestConstants.YamlViewModel);
            vm.SelectedFile = file;
        }

        [Then(@"the button is (.*)")]
        public void ThenTheButtonIs(string enabled)
        {
            var enabledBool = enabled == "true";
            var vm = context.Get<YamlViewModel>(TestConstants.YamlViewModel);
            vm.SelectedFileIsYaml.Should().Be(enabledBool);
        }




        [Given(@"the instructions of the assigment")]
        public void GivenTheInstructionsOfTheAssigment()
        {
            var kubeMock = context.Get<Mock<IKubeService>>(TestConstants.KubeMock);
            var regionMock = context.Get<Mock<IFileService>>(TestConstants.FileMock);
            var vm = new YamlViewModel(kubeMock.Object, regionMock.Object);
            context.Add(TestConstants.YamlViewModel, vm);
        }

        [When(@"The table is")]
        public void WhenTheTableIs(Table table)
        {
            var data = new List<string>(table.Header);
            var dir = data[0];
            var file = data[1];
            var vm = context.Get<YamlViewModel>(TestConstants.YamlViewModel);
            var fileMock = context.Get<Mock<IFileService>>(TestConstants.FileMock);
            fileMock.Setup(f => f.DirectoryIsValid("validDir")).Returns(true);
            fileMock.Setup(f => f.DirectoryIsValid("invalidDir")).Returns(false);
            fileMock.Setup(f => f.ReadDirectoryOrNull(dir)).Returns(new List<string> { });
            fileMock.Setup(f => f.ReadFile(file)).Returns(string.Empty);
            vm.SelectedDirectory = dir;
            vm.SelectedFile = file;
        }

        [Then(@"The button is enabled")]
        public void ThenTheButtonIsEnabled()
        {
            var vm = context.Get<YamlViewModel>(TestConstants.YamlViewModel);
            vm.SelectedFileIsYaml.Should().BeTrue();
        }
    }


    public static class TestConstants
    {
        public const string KubeMock = "kubeMock";
        public const string RegionManagerMock = "regionManagerMock";
        public const string FileMock = "fileServiceMock";
        public const string MainViewModel = "mainViewModel";
        public const string YamlViewModel = "yamlVewModel";
        public const string StatusViewModel = "statusViewModel";






        public const string GetConfigResult = @"apiVersion: v1
clusters:
-cluster:
    certificate - authority - data: DATA + OMITTED
    server: https://144.17.10.175:6443
  name: kubernetes
contexts:
-context:
    cluster: kubernetes
    user: kubernetes - admin
  name: kubernetes - admin@kubernetes
current - context: kubernetes - admin@kubernetes
kind: Config
preferences: { }
        users:
            -name: kubernetes - admin
  user:
            client - certificate - data: REDACTED
    client - key - data: REDACTED";
    }
}
