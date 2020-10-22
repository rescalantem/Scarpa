using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scarpa.Prism.ViewModels
{
    public class ScarpaMasterDetailPageViewModel : ViewModelBase
    {
        public ScarpaMasterDetailPageViewModel(INavigationService navigationService):base(navigationService)
        {

        }
    }
}
