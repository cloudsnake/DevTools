using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevTools.Core;
using DevTools.Core.Mvvm;
using DevTools.Modules.CodeLibrary.Data;
using DevTools.Modules.CodeLibrary.Data.Service;
using DevTools.Modules.CodeLibrary.Helper;
using DevTools.Modules.CodeLibrary.Model;
using DevTools.Services.Interfaces;
using Prism.Commands;
using Prism.Regions;

namespace DevTools.Modules.CodeLibrary.ViewModels
{
    public class CodeViewModel : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        private long _countDoc;

        public long CountDoc
        {
            get { return _countDoc; }
            set { SetProperty(ref _countDoc, value); }
        }
        public DelegateCommand<ItemTreeData> SelectItemChangeCommand { get; private set; }
        public DelegateCommand RefreshCommand { get; private set; }
        public DelegateCommand AddNewUpdate { get; private set; }
        public DelegateCommand UpdateCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }
        public DelegateCommand<ItemTreeData> DoubleClickCommand { get; private set; }
        private IRegionManager _regionManager;

        public CodeViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            _regionManager = regionManager;
            Message = messageService.GetMessage();

            InitTreeView();
            AddNewUpdate = new DelegateCommand(OnAddUpdate);
            RefreshCommand = new DelegateCommand(OnRefresh);
            UpdateCommand = new DelegateCommand(OnUpdate);
            DeleteCommand = new DelegateCommand(OnDelete);
            //            DoubleClickCommand = new DelegateCommand<ItemTreeData>(OnDoubleClick);
            SelectItemChangeCommand = new DelegateCommand<ItemTreeData>(OnSelectItem);
            var code = DataHelper.Instance.Current.Select<CodeDocument>();
            var query = code.Where(t => t.Id > 0).ToList();
            GetDocumentCount();

        }

        public async void GetDocumentCount()
        {
            var count = await CodeDocumentService.GetCodeDocumentCount();
            CountDoc = count;
        }
        private async void OnDelete()
        {
            if (SelectedCodeId <= 0)
            {
                return;
            }
            var cd = await CodeDocumentService.GetCodeDocumentById(SelectedCodeId);
            await CodeDocumentService.DeleteCodeDocument(cd);
            OnRefresh();
        }

        private int SelectedCodeId = 0;

        private void OnUpdate()
        {
            if (SelectedCodeId <= 0)
            {
                return;
            }
            var parameters = new NavigationParameters();
            parameters.Add("Id", SelectedCodeId);

            _regionManager.RequestNavigate(RegionNames.ContentRegionCode, "AddUpdateCodeDocument", parameters);

        }
        private void OnSelectItem(ItemTreeData itemTreeData)
        {
            if (itemTreeData == null || itemTreeData.itemId <= 0)
            {
                SelectedCodeId = 0;
                return;
            }

            SelectedCodeId = itemTreeData.itemId;
            var parameters = new NavigationParameters();
            parameters.Add("Id", itemTreeData.itemId);
            _regionManager.RequestNavigate(RegionNames.ContentRegionCode, "CodeInfo", parameters);
        }

        private void OnRefresh()
        {
            InitTreeView();
        }
        private void OnAddUpdate()
        {
            var parameters = new NavigationParameters();
            parameters.Add("Id", Guid.NewGuid().ToString());
            _regionManager.RequestNavigate(RegionNames.ContentRegionCode, "AddUpdateCodeDocument", parameters);
        }
        // Item的树形结构
        private ObservableCollection<ItemTreeData> itemTreeDataList;
        public ObservableCollection<ItemTreeData> ItemTreeDataList
        {
            get { return itemTreeDataList; }
            set { SetProperty(ref itemTreeDataList, value); }
        }
        private void InitTreeView()
        {
            // 添加树形结构
            if (itemTreeDataList == null)
            {
                itemTreeDataList = new ObservableCollection<ItemTreeData>();
            }
            GetTreeData();
        }
        private async void GetTreeData()
        {
            var list = await CodeDocumentService.GetCodeDocumentTitlesByTitle("");

            string _root = "";
            var rootChild = new ItemTreeData();
            var _list = new List<ItemTreeData>();

            foreach (var s in list)
            {
                var ss = EnumHelper.GetEnumName<ProgrammingLanguage>(s.ProgrammingLanguageId);
                if (_root != ss)
                {
                    rootChild = new ItemTreeData();
                    rootChild.titleName = ss;
                    rootChild.itemId = 0;
                    _list.Add(rootChild);
                    _root = ss;
                }
                var child = new ItemTreeData();
                child.titleName = s.Title;
                child.itemId = s.Id;
                rootChild.Children.Add(child);
            }
            //itemTreeDataList.Clear();
            //ItemTreeDataList.Clear();
            try
            {
                ItemTreeDataList = new ObservableCollection<ItemTreeData>(_list);
            }
            catch (Exception e)
            {
            }
        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            /*获取导航参数*/
            var patientInfo = (string)navigationContext.Parameters["PatientInfo"];
            var refreshPageDel = (string)navigationContext.Parameters["RefreshPageDel"];
            var configInfoModel = (string)navigationContext.Parameters["ConfigInfoModel"];
        }
    }
}
