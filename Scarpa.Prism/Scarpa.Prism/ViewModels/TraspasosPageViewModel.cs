using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scarpa.Prism.ViewModels
{
    public class TraspasosPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public TraspasosPageViewModel(INavigationService navigationService):base(navigationService)
        {
            Title = "Traspasos";
            _navigationService = navigationService;
        }
    }
}
