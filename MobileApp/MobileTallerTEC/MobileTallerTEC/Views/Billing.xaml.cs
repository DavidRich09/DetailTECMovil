using MobileTallerTEC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTallerTEC.Views
{/*
     * Clase Billing
     * Clase asociada al Billing.xaml 
     */
    public partial class Billing : ContentPage
    {
        //Instanciacion del viewModel para realizar el refreshing
        BillingViewModel _viewModel;
        /*
         * Inicializador de la clase
         */
        public Billing()
        {
            InitializeComponent();
            BindingContext = _viewModel = Startup.Resolve<BillingViewModel>();
 
        }
        /*
         * Override de la funcion OnAppearing() para ejecturar más acciones de refrescado
         */
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}