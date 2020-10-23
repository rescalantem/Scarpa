using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Scarpa.Common.Entities;
using Scarpa.Common.Helpers;
using ZXing;

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
        private bool _isVisible;
        private DelegateCommand _onScanResultCommand;
        private readonly INavigationService _navigationService;
        public AsistenciaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Checa Asistencia";
            _isScanning = true;
            _isAnalyzing = true;
            _isVisible = true;

            //var options = new MobileBarcodeScanningOptions();
            //options.PossibleFormats = new List<BarcodeFormat>(){BarcodeFormat.QR_CODE,BarcodeFormat.CODE_128};

            //var overlay = new ZXingDefaultOverlay
            //{
            //    ShowFlashButton = false,
            //    TopText = "Coloca el código de barras frente al dispositivo",
            //    BottomText = "El escaneo es automático",
            //    Opacity = 0.75
            //};
            //overlay.BindingContext = overlay;

            _nombre = JsonConvert.DeserializeObject<Usuarios>(Settings.Usuario).UsuNombre;
            _navigationService = navigationService;
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
        public DelegateCommand OnScanResultCommand => _onScanResultCommand ?? (_onScanResultCommand = new DelegateCommand(OnScanResult));

        private void OnScanResult()
        {
            //IsAnalyzing = false;
            //IsScanning = false;
            //IsVisible = false;

            Nombre = "Acabo de leer";

            //Device.BeginInvokeOnMainThread(async () =>
            //{
            //    BarcodeText = Result.Text;
            //    BarcodeFormat = BarcodeFormatConverter.ConvertEnumToString(Result.BarcodeFormat);
            //});            

        }
    }
}
