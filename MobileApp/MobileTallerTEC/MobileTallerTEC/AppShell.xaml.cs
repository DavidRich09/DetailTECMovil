using MobileTallerTEC.ViewModels;
using MobileTallerTEC.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileTallerTEC
{
    /*
     * Clase Appshell
     * Clase asociada al Appshell.xaml 
     */
    public partial class AppShell : Xamarin.Forms.Shell
    {
        /*
         * Inicializador de la clase
         */
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Register), typeof(Register));
        }
        /*
         * Logica del item flotante logout
         */
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
