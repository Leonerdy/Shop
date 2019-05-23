using GalaSoft.MvvmLight.Command;
using Shop.Common.Models;
using Shop.UIForms.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Shop.UIForms.ViewModels
{
    public class MainViewModel //: BaseViewModel
    {

        private static MainViewModel instance;

        //private User user;

        //public User User
        //{
        //    get => this.user;
        //    set => this.SetValue(ref this.user, value);
        //}


        public string UserEmail { get; set; }

        public string UserPassword { get; set; }


        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        public LoginViewModel Login { get; set; }

        public ProductsViewModel Products { get; set; }

        public AddProductViewModel AddProduct { get; set; }

        //public OrderViewModel AddOrder { get; set; }

        public EditProductViewModel EditProduct { get; set; }

        public ChangePasswordViewModel ChangePassword { get; set; }

        public User User { get; set; }

        public RegisterViewModel Register { get; set; }

        public ProfileViewModel Profile { get; set; }

        public ICommand AddProductCommand { get { return new RelayCommand(this.GoAddProduct); } }

        public ICommand AddOrderCommand { get { return new RelayCommand(this.GoOrder); } }

        public TokenResponse Token { get; set; }

        public RememberPasswordViewModel RememberPassword { get; set; }
        

        public MainViewModel()
        {
            instance = this;
            this.LoadMenus();
        }

        private async void GoAddProduct()
        {
            this.AddProduct = new AddProductViewModel();
            await App.Navigator.PushAsync(new AddProductPage());
        }
        private async void GoOrder()
        {
            //this.AddOrder = new OrderViewModel();
            await App.Navigator.PushAsync(new OrderPage());
        }


        private void LoadMenus()
        {
            var menus = new List<Menu>
        {
            new Menu
            {
                Icon = "ic_build",
                PageName = "OrderPage",
                Title = "Pedido de serviço"
            },
            new Menu
            {
                Icon = "ic_add_shopping_cart",
                PageName = "AddProductPage",
                Title = "Adicionar Produtos"
            },
            new Menu
            {
                Icon = "ic_person",
                PageName = "ProfilePage",
                Title = "Modificar usuário"
            },


            new Menu
            {
                Icon = "setup",
                PageName = "SetupPage",
                Title = "Configuração"
            },

            new Menu
            {
                Icon = "info",
                PageName = "AboutPage",
                Title = "Sobre"
            },

            new Menu
            {
                Icon = "exit",
                PageName = "LoginPage",
                Title = "Sair"
            }
        };

            this.Menus = new ObservableCollection<MenuItemViewModel>(menus.Select(m => new MenuItemViewModel
            {
                Icon = m.Icon,
                PageName = m.PageName,
                Title = m.Title
            }).ToList());
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
