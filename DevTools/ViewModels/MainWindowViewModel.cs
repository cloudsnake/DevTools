using System.Windows;
using DevTools.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace DevTools.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "开发工具集";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public DelegateCommand<string> NavigationCommand { get; set; }

        private readonly IRegionManager _regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigationCommand = new DelegateCommand<string>(OnNavigation);
        }

        private void OnNavigation(string view)
        {

            if (string.IsNullOrWhiteSpace(view))
            {
                return;
            }

            if (_regionManager == null)
            {
                return;
            }

            /*给导航给予参数*/
            NavigationParameters pars = new NavigationParameters();
            pars.Add("PatientInfo", "this");

            /*添加 导航参数*/
            pars.Add("RefreshPageDel", "this");
            pars.Add("ConfigInfoModel", "this");
            
            _regionManager.RequestNavigate(RegionNames.ContentRegion, view,pars);
        }
    }
}
