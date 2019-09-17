using CommonServiceLocator;
using kubectlWrapper.Shared.Services;
using kubectlWrapper.Wpf.Views;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace kubectlWrapper.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindowView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register(typeof(IKubeService), typeof(SshKube));
            containerRegistry.Register(typeof(IFileService), typeof(WindowsFileService));
            containerRegistry.RegisterForNavigation<YamlView>();
            containerRegistry.RegisterForNavigation<StatusView>();
            
        }

        protected override void ConfigureServiceLocator()
        {
            base.ConfigureServiceLocator();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}
