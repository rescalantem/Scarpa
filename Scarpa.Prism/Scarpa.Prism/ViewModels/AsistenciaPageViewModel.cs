using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Scarpa.Common.Helpers;
using Scarpa.Common.Responses;
using Scarpa.Common.Services;
using Scarpa.Common.Entities;
using ZXing;
using System;
using System.Linq;

namespace Scarpa.Prism.ViewModels
{
    public class AsistenciaPageViewModel : ViewModelBase
    {
        private string _nombre;
        private string _puesto;
        private string _horario;
        private string _mensaje;
        private bool _isScanning;
        private bool _isAnalyzing;
        private bool _isRunning;
        private bool _isVisible;
        private Result _result;
        private DelegateCommand _scanResultCommand;
        private DelegateCommand _leerQRCommand;
        private readonly INavigationService _navigationService;
        private readonly IApiServices _apiService;
        public AsistenciaPageViewModel(INavigationService navigationService, IApiServices apiService) : base(navigationService)
        {
            Title = "Checa Asistencia";
            _isScanning = true;
            _isAnalyzing = true;
            _isVisible = false;
            _navigationService = navigationService;
            _apiService = apiService;
            Puesto = "Puesto: ";
            Horario = "Horario: ";            
        }
        public DelegateCommand ScanResultCommand => _scanResultCommand ?? (_scanResultCommand = new DelegateCommand(ScanResult));
        public DelegateCommand LeerQRCommand => _leerQRCommand ?? (_leerQRCommand = new DelegateCommand(leerQR));        
        public Result Result
        {
            get => _result;
            set => SetProperty(ref _result, value);
        }
        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }
        public string Puesto
        {
            get => _puesto;
            set => SetProperty(ref _puesto, value);
        }
        public string Horario
        {
            get => _horario;
            set => SetProperty(ref _horario, value);
        }
        public string Mensaje
        {
            get => _mensaje;
            set => SetProperty(ref _mensaje, value);
        }
        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }
        public bool IsScanning
        {
            get => _isScanning;
            set => SetProperty(ref _isScanning, value);
        }
        public bool IsAnalyzing
        {
            get => _isAnalyzing;
            set => SetProperty(ref _isAnalyzing, value);
        }
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        private void leerQR()
        {
            IsAnalyzing = true;
            IsVisible = false;
            IsRunning = false;            
            Nombre = "";
            Puesto = "Puesto: ";
            Horario = "Horario: ";
            Mensaje = "";
        }
        public async void ScanResult()
        {
            IsVisible = true;
            IsRunning = true;            
            IsAnalyzing = false;
            //IsScanning = false;            
            string url = App.Current.Resources["UrlAPI"].ToString();

            bool connection = await _apiService.CheckConnection(url);
            if (!connection)
            {
                IsAnalyzing = false;
                IsScanning = false;
                IsVisible = false;
                await App.Current.MainPage.DisplayAlert("Error", "No hay internet disponible, verifique", "Aceptar");
                return;
            }
            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            asisChecada che = new asisChecada { Guid = _result.Text, Celular = Settings.Celular };
            Response registro = await _apiService.PostChecadaAsync(url, "scarpaapi_/api", "/Asistencia", "bearer", token.Token, che);
            
            if (!registro.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No se checo asistencia, intente de nuevo!", "Aceptar");
                return;
            }

            Mensaje = registro.Message;
            IsRunning = false;            
        }
    }
}
