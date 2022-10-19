using Microsoft.Extensions.DependencyInjection;
using System;
using MobileTallerTEC.Services;
using MobileTallerTEC.ViewModels;


namespace MobileTallerTEC
{
    /*
     * Clase Startup
     * Clase que realiza distintas instanciaciones y configuraciones para el inicio de la aplicacion
     */
    public static class Startup
    {
        //Clase proveedora de servicios
        private static IServiceProvider serviceProvider;
        /*
         * Funcion que configura y ata los distintos servicios y ViewModels
         */
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddHttpClient<IService, ApiService>(c =>
            {
              c.BaseAddress = new Uri("http://10.0.2.2:9968/");
              c.DefaultRequestHeaders.Add("Accept", "application/json");
            });


            //add viewmodels
            services.AddTransient<BillingViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegistrationViewModel>();
            services.AddTransient<RegisterViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }
        /*
         * Funcion que resuelve y retorna un ViewModel atado a un servicio
         */
        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
