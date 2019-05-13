using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.UIForms.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        private static MainViewModel instance;

        public LoginViewModel Login { get; set; }

        public ProductsViewModel Products { get; set; }

        public MainViewModel()
        {

            instance = this;
            //this.Login = new LoginViewModel();
        }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
    }
}
