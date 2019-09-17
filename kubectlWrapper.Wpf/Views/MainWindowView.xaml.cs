using kubectlWrapper.Shared.Services;
using kubectlWrapper.Wpf.ViewModels;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;

namespace kubectlWrapper.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {

        public MainWindowView()
        {
            InitializeComponent();
            //this.DataContext = new KubectlViewModel(new SshKube(), new WindowsFileService());
        }

    }
}
