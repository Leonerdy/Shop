using GalaSoft.MvvmLight.Command;
using Shop.UIForms.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Shop.UIForms.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(this.Login);

        public LoginViewModel()
        {
            this.Email = "enge.leon@gmail.com";
            this.Password = "123456";
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Você deve entrar um email.",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Você deve entrar um Password.",
                    "Accept");
                return;
            }

            if (!this.Email.Equals("enge.leon@gmail.com") || !this.Password.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Usuario ou password errados.",
                    "Accept");
                return;
            }

            //await Application.Current.MainPage.DisplayAlert(
            //  "Ok",
            // "Fuck Yeah!!",
            //  "Accept");

            MainViewModel.GetInstance().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
            
        }
    }
}
