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
     * Clase Register
     * Clase asociada al Register.xaml 
     */
    public partial class Register : ContentPage
    {
        /*
         * Inicializador de la clase
         */
        public Register()
        {
            InitializeComponent();
            BindingContext = Startup.Resolve<RegisterViewModel>();
        }
    }
}