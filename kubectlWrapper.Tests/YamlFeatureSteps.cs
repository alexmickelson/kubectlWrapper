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

            context.Add("regionManagerMock", regionManagerMock);
            context.Add("kubeMock", kubeMock);
        }

        [Given(@"the application is initialized")]
        public void GivenTheApplicationIsInitialized()
        {
            var regionMock = context.Get<Mock<IRegionManager>>("regionManagerMock");
            var app = new MainWindowViewModel(regionMock.Object);

            context.Add("mainWindowViewModel", app);
        }

        [When(@"the user clicks navigateYaml")]
        public void WhenTheUserClicksNavigateYaml()
        {
            var regionMock = context.Get<Mock<IRegionManager>>("regionManagerMock");
            regionMock.Setup(rm => rm.RequestNavigate(Constants.ContentRegion, Constants.YamlView)).Verifiable();

            var app = context.Get<MainWindowViewModel>("mainWindowViewModel");
            app.ShowView.Execute(Constants.YamlView);
        }
        
        [When(@"the user clicks navigateStatus")]
        public void WhenTheUserClicksNavigateStatus()
        {
            var regionMock = context.Get<Mock<IRegionManager>>("regionManagerMock");
            regionMock.Setup(rm => rm.RequestNavigate(Constants.ContentRegion, Constants.YamlView)).Verifiable();
            var app = context.Get<MainWindowViewModel>("mainWindowViewModel");
            app.ShowView.Execute(Constants.YamlView);
        }

        [Then(@"YamlView is put in the Content Region")]
        public void ThenYamlViewIsPutInTheContentRegion()
        {
            var regionMock = context.Get<Mock<IRegionManager>>("regionManagerMock");
            regionMock.Verify();
        }
        
        [Then(@"StatusView is put in the Content Region")]
        public void ThenStatusViewIsPutInTheContentRegion()
        {
            var regionMock = context.Get<Mock<IRegionManager>>("regionManagerMock");
            regionMock.Verify();
        }

        [Given(@"you are at the status view")]
        public void InitializeStatusViewModel()
        {
            var statusVM = new StatusViewModel(context.Get<Mock<IKubeService>>("kubeMock").Object);
            context.Add("statusView", statusVM);
        }

        [When(@"the user clicks getconfig button")]
        public void ClickGetStatusButton()
        {
            var viewMock = context.Get<Mock<IKubeService>>("kubeMock");
            viewMock.Setup(v => v.Kubectl(SSHArgs.GetConfig)).Returns(Task.FromResult(@"apiVersion: v1
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
    client - key - data: REDACTED"));

            var vm = context.Get<StatusViewModel>("statusView");
            vm.GetClusterInfo.Execute();
        }

        [Then(@"the correct config of the cluster is recieved")]
        public void CheckResponseofStatusOfCluster()
        {
            var vm = context.Get<StatusViewModel>("statusView");
            Assert.AreEqual(@"apiVersion: v1
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
    client - key - data: REDACTED", vm.ClusterInfo);
        }


        
        
        
    }
}
