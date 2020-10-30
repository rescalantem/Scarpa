﻿using Prism.Commands;
using Prism.Navigation;
using Scarpa.Common.Entities;

namespace Scarpa.Prism.ViewModels
{
    public class MenuItemViewModel : Menu
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectMenuCommand;

        public MenuItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public DelegateCommand SelectMenuCommand => _selectMenuCommand ?? (_selectMenuCommand = new DelegateCommand(selectMenu));
        private async void selectMenu()
        {
            if (PageName.Equals("LoginPage"))
            {
                await _navigationService.NavigateAsync("/NavigationPage/LoginPage");
                return;
            }
            await _navigationService.NavigateAsync($"/ScarpaMasterDetailPage/NavigationPage/{PageName}");
        }
    }
}
