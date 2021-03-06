﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scarpa.Prism.ViewModels
{
    public class VentasPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public VentasPageViewModel(INavigationService navigationService):base(navigationService)
        {
            Title = "Ventas";
            _navigationService = navigationService;
        }
    }
}
