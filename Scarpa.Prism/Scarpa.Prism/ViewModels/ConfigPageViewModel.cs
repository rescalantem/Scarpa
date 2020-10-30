

using Prism.Navigation;

namespace Scarpa.Prism.ViewModels
{
    public class ConfigPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public ConfigPageViewModel(INavigationService navigationService):base (navigationService)
        {
            Title = "Configuración";
            _navigationService = navigationService;
        }
    }
}
