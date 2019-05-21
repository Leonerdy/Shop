using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Shop.Common.Helpers;
using Shop.Common.Models;
using Shop.Common.Services;
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

        private bool isRunning;
        private bool isEnabled;
        private readonly ApiService apiService;

        public bool IsRemember { get; set; }

        public bool IsRunning
        {
            get => this.isRunning;
            set => this.SetValue(ref this.isRunning, value);
        }

        public bool IsEnabled
        {
            get => this.isEnabled;
            set => this.SetValue(ref this.isEnabled, value);
        }

        public ICommand LoginCommand => new RelayCommand(this.Login);

        public ICommand RegisterCommand => new RelayCommand(this.Register);

        public ICommand RememberPasswordCommand => new RelayCommand(this.RememberPassword);


        public LoginViewModel()
        {
            this.apiService = new ApiService();
            this.IsEnabled = true;
            this.IsRemember = true;
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

            this.IsRunning = true;
            this.IsEnabled = false;

            var request = new TokenRequest
            {
                Password = this.Password,
                Username = this.Email
            };

            var url = Application.Current.Resources["UrlAPI"].ToString();
            var response = await this.apiService.GetTokenAsync(
                url,
                "/Account",
                "/CreateToken",
                request);

            this.IsRunning = false;
            this.IsEnabled = true;

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Email or password incorrect.", "Accept");
                return;
            }

            var token = (TokenResponse)response.Result;

            var response2 = await this.apiService.GetUserByEmailAsync(
            url,
            "/api",
            "/Account/GetUserByEmail",
            this.Email,
            "bearer",
            token.Token);

            var user = (User)response2.Result;


            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.User = user;
            mainViewModel.Token = token;
            mainViewModel.Products = new ProductsViewModel();
            mainViewModel.UserEmail = this.Email;
            mainViewModel.UserPassword = this.Password;

            Settings.IsRemember = this.IsRemember;
            Settings.UserEmail = this.Email;
            Settings.UserPassword = this.Password;
            Settings.Token = JsonConvert.SerializeObject(token);
            Settings.User = JsonConvert.SerializeObject(user);


            Application.Current.MainPage = new MasterPage();

        }

        private async void Register()
        {
            MainViewModel.GetInstance().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        private async void RememberPassword()
        {
            MainViewModel.GetInstance().RememberPassword = new RememberPasswordViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RememberPasswordPage());
        }

    }
}
