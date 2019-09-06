using kubectlWrapper.Shared.Services;
using kubectlWrapper.Shared.ViewModels;
using System.Windows;

namespace kubectlWrapper.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public KubectlViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new KubectlViewModel(new SshKube());
        }

    }
}
