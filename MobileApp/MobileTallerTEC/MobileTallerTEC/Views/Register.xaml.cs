using MobileTallerTEC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace MobileTallerTEC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /*
     * Clase Register
     * Clase asociada al Register.xaml 
     */
    public partial class Register : ContentPage
    {
        RegisterViewModel _viewModel;
        /*
         * Inicializador de la clase
         */
        public Register()
        {
            InitializeComponent();
            InitializeControls();
            BindingContext = _viewModel = Startup.Resolve<RegisterViewModel>();
        }
        public void InitializeControls()
        {
            Phones.Completed += (sender, e) => _viewModel.SavePhone(sender, e);
            Addresses.Completed += (sender, e) => _viewModel.SaveAddress(sender, e);
        }

    }
}