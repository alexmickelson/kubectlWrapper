using kubectlWrapper.Shared.Data;
using kubectlWrapper.Shared.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace kubectlWrapper.Wpf.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        private DelegateCommand<string> showView;

        public DelegateCommand<string> ShowView => showView ?? (showView = new DelegateCommand<string>(
                        //execute
                        (uri) => {
                            regionManager.RequestNavigate(Constants.ContentRegion, uri);
                        }
                    ));


    }
}
