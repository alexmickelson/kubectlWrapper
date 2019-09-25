using kubectlWrapper.Wpf.ViewModels;
using Moq;
using NUnit.Framework;
using Prism.Regions;
using System;
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

            context.Add("regionManagerMock", regionManagerMock);
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
            regionMock.Setup(rm => rm.RequestNavigate("ContentRegion", "YamlView")).Verifiable();

            var app = context.Get<MainWindowViewModel>("mainWindowViewModel");
            app.ShowView.Execute("YamlView");
        }
        
        [When(@"the user clicks navigateStatus")]
        public void WhenTheUserClicksNavigateStatus()
        {
            var regionMock = context.Get<Mock<IRegionManager>>("regionManagerMock");
            regionMock.Setup(rm => rm.RequestNavigate("ContentRegion", "StatusView")).Verifiable();
            var app = context.Get<MainWindowViewModel>("mainWindowViewModel");
            app.ShowView.Execute("YamlView");
        }

        [Then(@"YamlView is put in the Content Region")]
        public void ThenYamlViewIsPutInTheContentRegion()
        {
            var regionMock = context.Get<Mock<IRegionManager>>("regionManagerMock");
            regionMock.Verify();
        }
    }
}
