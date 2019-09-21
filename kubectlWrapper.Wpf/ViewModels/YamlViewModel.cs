using GuiSamples.Wpf;
using kubectlWrapper.Shared.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kubectlWrapper.Wpf.ViewModels
{
    public class YamlViewModel : BindableDataErrorInfoBase
    {
        private IFileService Fileservice { get; }
        private IKubeService KubectlService;
        public YamlViewModel(IKubeService KubectlService,
                                IFileService fileservice)
        {
            this.KubectlService = KubectlService;
            Fileservice = fileservice;
            SelectedFile = null;
            SelectedDirectory = @"C:\Users\Alex\SudoNet\kube";
        }

        private string selectedDirectory;

        public string SelectedDirectory
        {
            get { return selectedDirectory; }
            set {
                if (!Fileservice.DirectoryIsValid(value))
                {
                    SelectedDirectoryError = "Directory Not Valid";
                }
                else
                {
                    SelectedDirectoryError = null;
                    FileList = new ObservableCollection<string>(Fileservice.ReadDirectoryOrNull(value));
                }
                SetProperty(ref selectedDirectory, value);
            }
        }

        private string selectedDirectoryError;
        public string SelectedDirectoryError
        {
            get { return selectedDirectoryError; }
            set {
                SetProperty(ref selectedDirectoryError, value);
                ErrorDictionary[nameof(SelectedDirectory)] = value;
                SelectedDirectoryErrorVisibility = String.IsNullOrWhiteSpace(value) ? Visibility.Collapsed : Visibility.Visible;
                RaisePropertyChanged(nameof(Error));
            }
        }

        private Visibility selectedDirectoryErrorVisibility;
        public Visibility SelectedDirectoryErrorVisibility
        {
            get { return selectedDirectoryErrorVisibility; }
            set {
                SetProperty(ref selectedDirectoryErrorVisibility, value);
            }
        }




        private ObservableCollection<string> fileList;
        public ObservableCollection<string> FileList
        {
            get { return fileList; }
            set
            {
                SetProperty(ref fileList, value);
            }
        }


        private DelegateCommand applyYaml;
        public DelegateCommand ApplyYaml => applyYaml ?? (applyYaml = new DelegateCommand(
                        //execute
                        async () =>
                        {
                            ApplyYamlStatus = "Applying YAML...";
                            ApplyYamlStatus = await KubectlService.ApplyYaml(SelectedFile);
                        }
                    ));

        private string applyYamlStatus;
        public string ApplyYamlStatus
        {
            get { return applyYamlStatus; }
            set
            {
                applyYamlStatus = "Status: " + value;
                RaisePropertyChanged();
            }
        }


        public bool SelectedFileIsYaml
        {
            get
            {
                return (!string.IsNullOrEmpty(SelectedFile)) && (SelectedFile.EndsWith("yml") || SelectedFile.EndsWith("yaml"));
            }
        }
        private string selectedFile;
        public string SelectedFile
        {
            get { return selectedFile; }
            set
            {
                if (selectedFile != value)
                {
                    SelectedFileContents = Fileservice.ReadFile(value);
                    SetProperty(ref selectedFile, value);
                    RaisePropertyChanged(nameof(SelectedFileIsYaml));
                    RaisePropertyChanged(nameof(ApplyYaml));
                    if (value.Contains("yml") || value.Contains("yaml"))
                        SelectedFileNotYamlError = null;
                    else
                        SelectedFileNotYamlError = "Selected File Not Yaml";
                }
            }
        }


        private string selectedFileNotYamlError;
        public string SelectedFileNotYamlError
        {
            get { return selectedFileNotYamlError; }
            set
            {
                selectedFileNotYamlError = value;
                ErrorDictionary[nameof(SelectedFile)] = value;
                SelectedDirectoryErrorVisibility = String.IsNullOrWhiteSpace(value) ? Visibility.Collapsed : Visibility.Visible;
                RaisePropertyChanged(nameof(Error));
            }
        }
        private Visibility selectedFileNotYamlErrorVisibility;
        public Visibility SelectedFileNotYamlErrorVisibility
        {
            get { return selectedFileNotYamlErrorVisibility; }
            set { selectedFileNotYamlErrorVisibility = value;
                RaisePropertyChanged();
            }
        }


        private string selectedFileContents;
        public string SelectedFileContents
        {
            get { return selectedFileContents; }
            set
            {
                SetProperty(ref selectedFileContents, value);
            }
        }

        //public Visibility ErrorVisibility
        //{
        //    get => (selectedFileNotYamlErrorVisibility == Visibility.Visible || SelectedDirectoryErrorVisibility == Visibility.Visible) ? Visibility.Visible : Visibility.Hidden;
        //}
        

    }
}
