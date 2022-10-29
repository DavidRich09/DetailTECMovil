using MobileTallerTEC.Services;
using MobileTallerTEC.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileTallerTEC.DataBase;
using System.IO;
using MobileTallerTEC.Models;

namespace MobileTallerTEC
{
    /*
     * Clase App
     * Clase asociada al App.xaml 
     */
    public partial class App : Application
    {
        /*
         * Inicializacion de la base de datos lite
         */
        private static Database dataBase;
        public static Database DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    dataBase = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbLite16.db3"));

                }
                return dataBase;
            }
        }
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
