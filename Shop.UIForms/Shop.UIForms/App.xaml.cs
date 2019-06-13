using Newtonsoft.Json;
using Shop.Common.Helpers;
using Shop.Common.Models;
using Shop.UIForms.ViewModels;
using Shop.UIForms.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Shop.UIForms
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }

        public static MasterPage Master { get; internal set; }

        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTA0MDI1QDMxMzcyZTMxMmUzMFI4Z2s0NWJVcFVscUY5bEZHZ2oveXJZMEF4dFlRL0VXUzhVRFc2SDRwWUk9");
            InitializeComponent();

#if DEBUG
            HotReloader.Current.Start(this);
#endif

            if (Settings.IsRemember)
            {
                var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
                var user = JsonConvert.DeserializeObject<User>(Settings.User);

                if (token.Expiration > DateTime.Now)
                {
                    var mainViewModel = MainViewModel.GetInstance();
                    mainViewModel.Token = token;
                    mainViewModel.User = user;
                    mainViewModel.UserEmail = Settings.UserEmail;
                    mainViewModel.UserPassword = Settings.UserPassword;
                    mainViewModel.Products = new ProductsViewModel();
                    this.MainPage = new MasterPage();
                    return;
                }
                
            }

            MainViewModel.GetInstance().Login = new LoginViewModel();
            this.MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
