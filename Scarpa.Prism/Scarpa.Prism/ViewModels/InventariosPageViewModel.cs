using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scarpa.Prism.ViewModels
{
    public class InventariosPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public InventariosPageViewModel(INavigationService navigationService):base(navigationService)
        {
            Title = "Inventarios";
            _navigationService = navigationService;
        }
    }
}
