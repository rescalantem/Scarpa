using Prism.Commands;
using Prism.Navigation;
using Scarpa.Common.Helpers;
using Scarpa.Common.Requests;
using Scarpa.Common.Responses;
using Scarpa.Common.Services;
using System;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Scarpa.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private bool _isRunning;
        private bool _isEnabled;
        private string _contra;
        private DelegateCommand _contraCommand;
        private readonly IApiServices _apiService;
        public LoginPageViewModel(INavigationService navigationservice, IApiServices apiService) : base(navigationservice)
        {
            Title = "Scarpa - Seguridad";
            _isEnabled = true;
            _apiService = apiService;
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
                if (string.IsNullOrEmpty(Settings.Token))
                {
                    string url = App.Current.Resources["UrlAPI"].ToString();

                    UsrLogin usrLogin = new UsrLogin { Celular = Settings.Celular, Contra = calculaHash(Contra) };

                    Response response = await _apiService.GetTokenAsync(url, "/api", "/token/createtoken", usrLogin);

                    if (!response.IsSuccess)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña incorrectos!", "Aceptar");
                        IsRunning = false;
                        IsEnabled = true;
                        Contra = string.Empty;
                        return;
                    }
                    TokenResponse token = (TokenResponse)response.Result;
                    Settings.Token = JsonConvert.SerializeObject(token);
                }

                await App.Current.MainPage.DisplayAlert("Scarpa", Contra, "Aceptar");
            }
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
