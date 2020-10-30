using Prism.Navigation;
using Scarpa.Common.Entities;
using Scarpa.Common.Responses;

namespace Scarpa.Prism.ViewModels
{
    public class ConfigTabbedPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ConfigTabbedPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Configuración";
        }      

    }
}
