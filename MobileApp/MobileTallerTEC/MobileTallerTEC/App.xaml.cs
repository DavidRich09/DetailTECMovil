using MobileTallerTEC.Services;
using MobileTallerTEC.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileTallerTEC
{
    /*
     * Clase App
     * Clase asociada al App.xaml 
     */
    public partial class App : Application
    {
        /*
         * Inicializador de la clase
         */
        public App()
        {
            InitializeComponent();
            Startup.ConfigureServices();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
