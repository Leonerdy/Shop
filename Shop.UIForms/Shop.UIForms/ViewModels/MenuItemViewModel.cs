﻿namespace Shop.UIForms.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Shop.Common.Helpers;
    using Shop.UIForms.Views;
    using Xamarin.Forms;

    public class MenuItemViewModel : Common.Models.Menu
    {
        public AddProductViewModel AddProduct { get; set; }

        public ICommand SelectMenuCommand => new RelayCommand(this.SelectMenu);

        private async void SelectMenu()
        {
            
            
            App.Master.IsPresented = false;
            var mainViewModel = MainViewModel.GetInstance();

            switch (this.PageName)
            {
                case "OrderPage":
                    await App.Navigator.PushAsync(new OrderPage());
                    break;

                case "AddProductPage":
                    this.AddProduct = new AddProductViewModel();
                    if (mainViewModel.User.IsAdmin)
                    {
                        await App.Navigator.PushAsync(new AddProductPage());
                        break;
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Você não pode acessar essa página",
                    "Accept");
                        return;
                    }

                case "SetupPage":
                    await App.Navigator.PushAsync(new SetupPage());
                    break;
                case "ProfilePage":
                    mainViewModel.Profile = new ProfileViewModel();
                    await App.Navigator.PushAsync(new ProfilePage());
                    break;
                case "AboutPage":
                    await App.Navigator.PushAsync(new AboutPage());
                    break;

                default:
                    Settings.User = string.Empty;
                    Settings.IsRemember = false;
                    Settings.Token = string.Empty;
                    Settings.UserEmail = string.Empty;
                    Settings.UserPassword = string.Empty;

                    MainViewModel.GetInstance().Login = new LoginViewModel();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    break;
            }
        }
    }
}
