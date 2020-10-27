using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Scarpa.Common.Helpers;
using Scarpa.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Xamarin.Forms;

namespace Scarpa.Prism.ViewModels
{    
    public class ConfigPageViewModel : ViewModelBase
    {
        private string _numCelular;
        private string _claveSms;
        private string _host;
        private bool _isEnabledStack;
        private bool _isRunning;
        private string _clave;
        private bool _isEnabledBtnRegistrar;
        private INavigationService _navigation;
        private readonly IApiServices _iapiservices;
        private DelegateCommand _registrarCommand;
        private DelegateCommand _activarCommand;

        public ConfigPageViewModel(INavigationService navigation,IApiServices iapiservices):base(navigation)
        {
            Title = "SCARPA Registro";            
            _isEnabledBtnRegistrar = true;            
            _navigation = navigation;
            _iapiservices = iapiservices;
        }
        public DelegateCommand RegistrarCommand => _registrarCommand ?? (_registrarCommand = new DelegateCommand(registrar));
        public DelegateCommand ActivarCommand => _activarCommand ?? (_activarCommand = new DelegateCommand(activar));
        public string Host 
        { 
            get => _host; 
            set => SetProperty(ref _host,value); 
        }
        public string ClaveSms 
        { 
            get => _claveSms; 
            set => SetProperty(ref _claveSms,value); 
        }
        public bool IsEnabledBtnRegistrar 
        { 
            get => _isEnabledBtnRegistrar; 
            set => SetProperty(ref _isEnabledBtnRegistrar,value); 
        }
        public bool IsRunning 
        { 
            get => _isRunning; 
            set => SetProperty(ref _isRunning,value); 
        }
        public bool IsEnabledStack 
        { 
            get => _isEnabledStack; 
            set => SetProperty(ref _isEnabledStack,value); 
        }
        public string NumCelular 
        { 
            get => _numCelular; 
            set => SetProperty(ref _numCelular,value); 
        }        
        private async void activar()
        {
            if(ClaveSms != _clave)
            {
                await App.Current.MainPage.DisplayAlert("Error","Clave inválida, verifique!","Aceptar");
                return;
            }
            else
            {
                Settings.Configurado = true;
                Settings.Celular = NumCelular;
                Settings.HostApi = "http://" + Host;
                await NavigationService.NavigateAsync("NavigationPage/LoginPage");                
                return;
            }
        }
        private async void registrar()
        {
            if (string.IsNullOrEmpty(Host))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Falta el portal web!", "Aceptar");
                return;
            }
            if (NumCelular.Length != 10)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Celular inválido, verifique!", "Aceptar");                
                return;
            }
            IsRunning = true;
            IsEnabledBtnRegistrar = false;
            string url = App.Current.Resources["UrlSMS"].ToString();            

            bool connection = await _iapiservices.CheckConnection(url);
            if (!connection)
            {
                IsRunning = false;
                IsEnabledBtnRegistrar = true;
                await App.Current.MainPage.DisplayAlert("Error", "No hay internet disponible, verifique", "Aceptar");                
                return;
            }
            var ran = new Random(Environment.TickCount);
            _clave = ran.Next(10).ToString() + ran.Next(10).ToString() + ran.Next(10).ToString() + ran.Next(10).ToString();

            string mensaje = "SU CODIGO ES: " + _clave + " SCARPA - Punto de Venta";
            url += "/SvtSendSms?username=ALESCA&password=ESCALANTE&message=" + mensaje + "&numbers=" + NumCelular + "&platform=5";

            var sol = new HttpClient {BaseAddress = new Uri(url)};
            var response = await sol.GetAsync(url);
            
            var answer = await response.Content.ReadAsStringAsync();            

            if (answer.IndexOf("<status>OK<")!=0)
            {
                IsRunning = false;                
                IsEnabledStack = true;
                await App.Current.MainPage.DisplayAlert("Scarpa","En un momento recibira un MSM con su clave!", "Aceptar");
                return;
            }
            else
            {
                IsRunning = false;
                IsEnabledBtnRegistrar = true;
                IsEnabledStack = true;
                await App.Current.MainPage.DisplayAlert("Error", "Ocurrio un error en el SMS, intente mas tarde!", "Aceptar");
                return;
            }
        }
    }    
}
