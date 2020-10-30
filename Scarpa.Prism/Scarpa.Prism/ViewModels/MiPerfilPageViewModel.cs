using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scarpa.Prism.ViewModels
{
    public class MiPerfilPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public MiPerfilPageViewModel(INavigationService navigationService):base (navigationService)
        {
            _navigationService = navigationService;
            Title = "Mi perfil";
        }
    }
}
