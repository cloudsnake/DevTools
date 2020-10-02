using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using DevTools.Core.Mvvm;
using DevTools.Services.Interfaces;
using Prism.Regions;

namespace DevTools.Modules.ColorTableMod.ViewModels
{
    public class ColorTableViewModel  : RegionViewModelBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ColorTableViewModel(IRegionManager regionManager, IMessageService messageService) :
            base(regionManager)
        {
            Message = messageService.GetMessage() + "ColorTableView";
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }
    }
}
