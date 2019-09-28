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

        }
        [Given(@"we have mocked all of our services")]
        public void GivenWeHaveMockedAllOfOurServices()
        {
            var regionManagerMock = new Mock<IRegionManager>();
            var kubeMock = new Mock<IKubeService>();
            var fileMock = new Mock<IFileService>();

            context.Add(TestConstants.RegionManagerMock, regionManagerMock);
            context.Add(TestConstants.KubeMock, kubeMock);
            context.Add(TestConstants.FileMock, fileMock);
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
