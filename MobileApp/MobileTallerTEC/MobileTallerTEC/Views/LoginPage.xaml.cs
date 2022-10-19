using MobileTallerTEC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTallerTEC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /*
    * Clase LoginPage
    * Clase asociada al LoginPage.xaml 
    */
    public partial class LoginPage : ContentPage
    {
        /*
         * Inicializador de la clase
         */
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = Startup.Resolve<LoginViewModel>();
        }
    }
}