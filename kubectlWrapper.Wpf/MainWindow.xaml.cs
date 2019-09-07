using kubectlWrapper.Shared.Services;
using kubectlWrapper.Shared.ViewModels;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;

namespace kubectlWrapper.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new KubectlViewModel(new SshKube(), new WindowsFileService());
        }

    }
}
