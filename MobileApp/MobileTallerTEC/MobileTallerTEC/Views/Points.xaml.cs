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
    public partial class Points : ContentPage
    {
        //Instanciacion del viewModel para realizar el refreshing
        PointsViewModel _viewModel;
        /*
         * Inicializador de la clase
         */
        public Points()
        {
            InitializeComponent();
            BindingContext = _viewModel = Startup.Resolve<PointsViewModel>();
 
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