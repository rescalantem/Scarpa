using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Scarpa.Common.Entities;
using Scarpa.Common.Helpers;
using Scarpa.Common.Services;
using System;

namespace Scarpa.Prism.ViewModels
{
    public class MiPerfilPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiServices _apiServices;
        private bool _isRunning;
        private string _fotoUsuario;
        private DelegateCommand _guardarCommand;
        private string _nombre;
        private string _direccion;
        private DateTime _nacimiento;
        private DateTime _alta;
        private string _rfc;
        private string _curp;
        private string _puesto;
        private string _clasificacion;
        private string _departamento;
        private string _email;
        private string _telefono;
        private string _nomina;
        public MiPerfilPageViewModel(INavigationService navigationService, IApiServices apiServices) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiServices = apiServices;
            Title = "Mi perfil";

            Usuarios usu = JsonConvert.DeserializeObject<Usuarios>(Settings.Usuario);

            Nombre = usu.UsuNombre;
            Direccion = usu.UsuDireccion;
            Email = usu.UsuEmail;
            Rfc = usu.UsuRfc;
            Curp = usu.UsuCurp;
            Puesto = usu.Pue.PueDescripcion;
            Clasificacion = usu.Cla.ClaDescripcion;
            Departamento = usu.Dep.DepDescripcion;
            Telefono = usu.UsuTelefono;
            Nomina = usu.UsuClaveNomina;
            Alta = usu.UsuFechaInicial;
            Nacimiento = usu.UsuNacimiento;
            FotoUsuario = "usrSinFoto";
        }
        public DelegateCommand GuardarCommand => _guardarCommand ?? (_guardarCommand = new DelegateCommand(Guardar));
        public string Nombre
        {
            get => _nombre;
            set => SetProperty(ref _nombre, value);
        }
        public string Direccion
        {
            get => _direccion;
            set => SetProperty(ref _direccion, value);
        }
        public string Rfc
        {
            get => _rfc;
            set => SetProperty(ref _rfc, value);
        }
        public string Curp
        {
            get => _curp;
            set => SetProperty(ref _curp, value);
        }
        public string Puesto
        {
            get => _puesto;
            set => SetProperty(ref _puesto, value);
        }
        public string Clasificacion
        {
            get => _clasificacion;
            set => SetProperty(ref _clasificacion, value);
        }
        public string Departamento
        {
            get => _departamento;
            set => SetProperty(ref _departamento, value);
        }
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string Telefono
        {
            get => _telefono;
            set => SetProperty(ref _telefono, value);
        }
        public string Nomina
        {
            get => _nomina;
            set => SetProperty(ref _nomina, value);
        }
        public DateTime Alta
        {
            get => _alta;
            set => SetProperty(ref _alta, value);
        }
        public DateTime Nacimiento
        {
            get => _nacimiento;
            set => SetProperty(ref _nacimiento, value);
        }
        public string FotoUsuario
        {
            get => _fotoUsuario;
            set => SetProperty(ref _fotoUsuario, value);
        }
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        private async void Guardar()
        {
            IsRunning = true;




            IsRunning = false;
            await App.Current.MainPage.DisplayAlert("Salvado", "Su datos han sido salvados!", "Ok");
        }
    }
}
