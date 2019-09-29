using FluentAssertions;
using kubectlWrapper.Shared.Data;
using kubectlWrapper.Shared.Services;
using kubectlWrapper.Wpf;
using kubectlWrapper.Wpf.ViewModels;
using Moq;
using NUnit.Framework;
using Prism.Regions;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace kubectlWrapper.Tests
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




        [Given(@"the application is initialized")]
        public void GivenTheApplicationIsInitialized()
        {
            var regionMock = context.Get<Mock<IRegionManager>>(TestConstants.RegionManagerMock);
            var app = new MainWindowViewModel(regionMock.Object);

            context.Add(TestConstants.MainViewModel, app);
        }

        [When(@"the user clicks navigateYaml")]
        public void WhenTheUserClicksNavigateYaml()
        {
            var regionMock = context.Get<Mock<IRegionManager>>(TestConstants.RegionManagerMock);
            regionMock.Setup(rm => rm.RequestNavigate(Constants.ContentRegion, Constants.YamlView)).Verifiable();

            var app = context.Get<MainWindowViewModel>(TestConstants.MainViewModel);
            app.ShowView.Execute(Constants.YamlView);
        }
        
        [When(@"the user clicks navigateStatus")]
        public void WhenTheUserClicksNavigateStatus()
        {
            var regionMock = context.Get<Mock<IRegionManager>>(TestConstants.RegionManagerMock);
            regionMock.Setup(rm => rm.RequestNavigate(Constants.ContentRegion, Constants.YamlView)).Verifiable();
            var app = context.Get<MainWindowViewModel>(TestConstants.MainViewModel);
            app.ShowView.Execute(Constants.YamlView);
        }

        [Then(@"YamlView is put in the Content Region")]
        public void ThenYamlViewIsPutInTheContentRegion()
        {
            var regionMock = context.Get<Mock<IRegionManager>>(TestConstants.RegionManagerMock);
            regionMock.Verify();
        }
        
        [Then(@"StatusView is put in the Content Region")]
        public void ThenStatusViewIsPutInTheContentRegion()
        {
            var regionMock = context.Get<Mock<IRegionManager>>(TestConstants.RegionManagerMock);
            regionMock.Verify();
        }

        [Given(@"you are at the status view")]
        public void InitializeStatusViewModel()
        {
            var statusVM = new StatusViewModel(context.Get<Mock<IKubeService>>(TestConstants.KubeMock).Object);
            context.Add(TestConstants.StatusViewModel, statusVM);
        }

        [When(@"the user clicks getconfig button")]
        public void ClickGetStatusButton()
        {
            var viewMock = context.Get<Mock<IKubeService>>(TestConstants.KubeMock);
            viewMock.Setup(v => v.Kubectl(SSHArgs.GetConfig)).Returns(Task.FromResult(TestConstants.GetConfigResult));

            var vm = context.Get<StatusViewModel>(TestConstants.StatusViewModel);
            vm.GetClusterInfo.Execute();
        }

        [Then(@"the correct config of the cluster is recieved")]
        public void CheckResponseofStatusOfCluster()
        {
            var vm = context.Get<StatusViewModel>(TestConstants.StatusViewModel);
            Assert.AreEqual(TestConstants.GetConfigResult, vm.ClusterInfo);
        }


        
        
        
    }
}
