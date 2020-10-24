using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Scarpa.Common.Helpers;
using Scarpa.Common.Requests;
using Scarpa.Common.Responses;
using Scarpa.Common.Services;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Scarpa.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private bool _isRunning;
        private bool _isEnabled;
        private string _contra;
        private DelegateCommand _contraCommand;
        private readonly IApiServices _apiService; 
        private readonly INavigationService _navigationService;
        public LoginPageViewModel(INavigationService navigationService, IApiServices apiService) : base(navigationService)
        {
            Title = "Scarpa - Seguridad";
            _isEnabled = true;
            _apiService = apiService;
            _navigationService = navigationService;
        }
        public DelegateCommand ContraCommand => _contraCommand ?? (_contraCommand = new DelegateCommand(contra));
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        public string Contra
        {
            get => _contra;
            set => SetProperty(ref _contra, value);
        }
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }
        private async void contra()
        {
            if (!string.IsNullOrEmpty(Contra))
            {
                IsEnabled = false;
                IsRunning = true;

                string url = App.Current.Resources["UrlAPI"].ToString();
                bool connection = await _apiService.CheckConnection(url);
                if (!connection)
                {
                    IsRunning = false;                    
                    await App.Current.MainPage.DisplayAlert("Error", "No hay internet disponible, verifique", "Aceptar");
                    return;
                }

                //Si el token no existe lo genera, por única vez
                if (string.IsNullOrEmpty(Settings.Token))
                {
                    await GeneraTokenAsync();
                }

                TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);

                if (token?.Expiration > DateTime.Now)
                {
                    // Checar pass con token                    
                    UsrLogin usrLogin = new UsrLogin { Celular = Settings.Celular, Contra = calculaHash(Contra) };
                    Response usr = await _apiService.GetUserByCelularAsync(url, "scarpaapi_/api", "/Usuarios/GetUserByCelular", "bearer", token.Token, usrLogin);
                    if (!usr.IsSuccess)
                    {
                        IsEnabled = true;
                        IsRunning = false;
                        await App.Current.MainPage.DisplayAlert("Error", "La contraseña no es válida!", "Aceptar");
                        Contra = string.Empty;
                        return;
                    }                                    

                    Settings.Usuario = JsonConvert.SerializeObject(usr.Result);
                    
                    Contra = string.Empty;
                    IsEnabled = true;
                    IsRunning = false;

                    await _navigationService.NavigateAsync("/ScarpaMasterDetailPage/NavigationPage/AsistenciaPage");
                }
            }
        }
        private async Task GeneraTokenAsync()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();
            UsrLogin usrLogin = new UsrLogin { Celular = Settings.Celular, Contra = "" };

            Response response = await _apiService.GetTokenAsync(url, "/scarpaapi_/api", "/token/createtoken", usrLogin);

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Número de celular incorrecto!", "Aceptar");
                IsRunning = false;
                IsEnabled = true;
                Contra = string.Empty;
                return;
            }
            TokenResponse token = (TokenResponse)response.Result;
            Settings.Token = JsonConvert.SerializeObject(token);
            return;
        }
        private string calculaHash(string contra)
        {
            UnicodeEncoding codigo = new UnicodeEncoding();
            SHA1Managed sha = new SHA1Managed();
            byte[] byt = sha.ComputeHash(codigo.GetBytes(contra));
            return Convert.ToBase64String(byt);
        }
    }
}
