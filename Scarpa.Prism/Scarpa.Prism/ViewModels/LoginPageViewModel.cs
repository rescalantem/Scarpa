using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace Scarpa.Prism.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string _contra;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _loginCommand;
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Login";
            IsEnabled = true;
        }
        public DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(Login));
        public string Email { get; set; }
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
        public bool IsRunning 
        { 
            get => _isRunning; 
            set => SetProperty(ref _isRunning, value); 
        }
        private async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Falta tu Email", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Contra))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Falta tu contraseña", "Ok");
                return;
            }
            await App.Current.MainPage.DisplayAlert("Adelante", "A consumir servicio", "Ok");
        }
    }
}
