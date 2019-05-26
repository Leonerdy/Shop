using Shop.UIForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shop.UIForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage //: BaseViewModel
    {
        public ICommand OpenWebCommand { get; }
        public AboutPage()
        {
            InitializeComponent();

            
         OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://lojaspeedservice.azurewebsites.net")));
        }
    }
}