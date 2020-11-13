using Prism.Commands;
using Prism.Navigation;
using Scarpa.Common.Helpers;
using Scarpa.Common.Services;
using System;

namespace Scarpa.Prism.ViewModels
{
    public class ConfigPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private bool _isRunning;
        private bool _isEnabled;
        private bool _isVisibleContra;
        private bool _isVisible;
        private bool _cambiarContra;
        private DelegateCommand _guardarCommand;
        private DelegateCommand _estadoCommand;
        private string _host;
        private IApiServices _apiServices;
        public ConfigPageViewModel(INavigationService navigationService,IApiServices apiServices) : base(navigationService)
        {
            Title = "Configuración";
            _navigationService = navigationService;
            _apiServices = apiServices;

            Host = Settings.HostApi;
        }
        public bool CambiarContra 
        { 
            get => _cambiarContra; 
            set => SetProperty(ref _cambiarContra,value);
        }
        public bool IsVisibleContra
        {
            get => _isVisibleContra;
            set => SetProperty(ref _isVisibleContra, value);
        }
        public bool IsEnabled 
        { 
            get => _isEnabled; 
            set => SetProperty(ref _isEnabled,value);
        }
        public string Host 
        { 
            get => _host; 
            set => SetProperty(ref _host,value);
        }
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }
        public DelegateCommand GuardarCommand => _guardarCommand ?? (_guardarCommand = new DelegateCommand(Guardar));
        public DelegateCommand EstadoCommand => _estadoCommand ?? (_estadoCommand = new DelegateCommand(Estado));
        private void Estado()
        {
            IsVisibleContra = CambiarContra;
        }
        private async void Guardar()
        {
            IsEnabled = false;
            if(string.IsNullOrEmpty(Host))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Falta portal de scarpa", "Ok");
                IsEnabled = true;
                return;
            }
            
            IsRunning = true;            
            bool connection = await _apiServices.CheckConnection(Host);
            if (!connection)
            {
                IsRunning = false;
                IsEnabled = true;
                await App.Current.MainPage.DisplayAlert("Error", "El portal de enlace no responde, verifique!", "Aceptar");                
                return;
            }

            Settings.HostApi = Host;
            await App.Current.MainPage.DisplayAlert("Scarpa", "Portal scarpa salvado!", "Ok");
            IsEnabled = true;
            IsRunning = false;
        }
    }
}
