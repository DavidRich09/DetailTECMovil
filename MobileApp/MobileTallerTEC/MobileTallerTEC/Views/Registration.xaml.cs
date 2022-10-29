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
     * Clase Registration
     * Clase asociada al Registration.xaml 
     */
    public partial class Registration : ContentPage

    {
        //Instanciacion del viewModel para realizar el refreshing
        RegistrationViewModel _viewModel;
        /*
         * Inicializador de la clase
         */
        public Registration()
        {
            InitializeComponent();

            BindingContext = _viewModel = Startup.Resolve<RegistrationViewModel>();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}