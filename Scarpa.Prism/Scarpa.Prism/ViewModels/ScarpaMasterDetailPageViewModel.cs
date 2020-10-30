using Scarpa.Common.Entities;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Scarpa.Prism.ViewModels
{
    public class ScarpaMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public ScarpaMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        private void LoadMenus()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_settings",
                    PageName = "ConfigTabbedPage",
                    Title = "Configuración"
                },

                new Menu
                {
                    Icon = "ic_asistencia",
                    PageName = "AsistenciaPage",
                    Title = "Checar asistencia"
                },

                new Menu
                {
                    Icon = "ic_ventas",
                    PageName = "VentasPage",
                    Title = "Ventas"
                },

                new Menu
                {
                    Icon = "ic_inventarios",
                    PageName = "InventariosPage",
                    Title = "Inventarios"
                },
                new Menu
                {
                    Icon = "ic_traspasos",
                    PageName = "TraspasosPage",
                    Title = "Traspasos"
                },
                new Menu
                {
                    Icon = "ic_salir",
                    PageName = "LoginPage",
                    Title = "Salir"
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }
    }
}
