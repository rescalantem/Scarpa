using Prism;
using Prism.Ioc;
using Scarpa.Prism.ViewModels;
using Scarpa.Prism.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Scarpa.Common.Services;
using Scarpa.Common.Helpers;

namespace Scarpa.Prism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            if (Settings.Configurado)
            {
                await NavigationService.NavigateAsync("NavigationPage/LoginPage");
            }
            else
            {
                await NavigationService.NavigateAsync("NavigationPage/InitPage");
            }            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IApiServices, ApiServices>();
            containerRegistry.RegisterForNavigation<NavigationPage>();            
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<ConfigPage, ConfigPageViewModel>();
            containerRegistry.RegisterForNavigation<ScarpaMasterDetailPage, ScarpaMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<AsistenciaPage, AsistenciaPageViewModel>();
            containerRegistry.RegisterForNavigation<InitPage, InitPageViewModel>();
            containerRegistry.RegisterForNavigation<VentasPage, VentasPageViewModel>();
            containerRegistry.RegisterForNavigation<InventariosPage, InventariosPageViewModel>();
            containerRegistry.RegisterForNavigation<TraspasosPage, TraspasosPageViewModel>();
            containerRegistry.RegisterForNavigation<MiPerfilPage, MiPerfilPageViewModel>();
            containerRegistry.RegisterForNavigation<ConfigTabbedPage, ConfigTabbedPageViewModel>();
        }
    }
}
