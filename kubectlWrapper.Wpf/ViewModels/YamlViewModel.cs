using kubectlWrapper.Shared.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kubectlWrapper.Wpf.ViewModels
{
    public class YamlViewModel : BindableBase
    {
        private IFileService Fileservice { get; }
        private IKubeService KubectlService;
        public YamlViewModel(IKubeService KubectlService,
                                IFileService fileservice)
        {
            this.KubectlService = KubectlService;
            Fileservice = fileservice;
            SelectedFile = null;
        }

        private DelegateCommand selectDirectory;
        public DelegateCommand SelectDirectory => selectDirectory ?? (selectDirectory = new DelegateCommand(
                        //execute
                        async () =>
                        {
                            FileList = new ObservableCollection<string>(Fileservice.SelectDirectory());
                        },
                        //can execute
                        () => true
                    ));


        private DelegateCommand applyYaml;
        public DelegateCommand ApplyYaml => applyYaml ?? (applyYaml = new DelegateCommand(
                        //execute
                        async () =>
                        {
                            ApplyYamlStatus = "Applying YAML...";
                            ApplyYamlStatus = await KubectlService.ApplyYaml(SelectedFile);
                        }
                    ));

        private ObservableCollection<string> fileList;
        public ObservableCollection<string> FileList
        {
            get { return fileList; }
            set
            {
                fileList = value;
                RaisePropertyChanged(nameof(FileList));
            }
        }

        private string applyYamlStatus;
        public string ApplyYamlStatus
        {
            get { return applyYamlStatus; }
            set
            {
                applyYamlStatus = "Status: " + value;
                RaisePropertyChanged(nameof(ApplyYamlStatus));
            }
        }

        public bool IsSelectedFile => !string.IsNullOrEmpty(SelectedFile);

        private string selectedFile;
        public string SelectedFile
        {
            get { return selectedFile; }
            set
            {
                if (selectedFile != value)
                {
                    selectedFile = value;
                    SelectedFileContents = Fileservice.ReadFile(selectedFile);
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsSelectedFile));
                    RaisePropertyChanged(nameof(ApplyYaml));
                }
            }
        }

        private string selectedFileContents;
        public string SelectedFileContents
        {
            get { return selectedFileContents; }
            set
            {
                selectedFileContents = value;
                RaisePropertyChanged(nameof(SelectedFileContents));
            }
        }
    }
}
