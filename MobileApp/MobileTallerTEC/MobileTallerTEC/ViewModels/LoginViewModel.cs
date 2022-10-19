using MobileTallerTEC.Models;
using MobileTallerTEC.Services;
using MobileTallerTEC.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MobileTallerTEC.ViewModels
{
    /*
     * Clase LoginViewModel
     * Clase padre: BaseViewModel
     * Clase con la lógica asociada al LoginPage.xaml
     */
    public class LoginViewModel : BaseViewModel
    {
        //Comando asociado al boton de login
        public Command LoginCommand { get; }
        //Comando asociado al boton de registrarse
        public Command RegisterCommand { get; }
        //Instancia de servicio con el cual se realizan GETS y POST de la API
        private readonly IService _service;
        //String asociado al usuario del cliente
        private string user;
        //String asociado a la contrasena del cliente
        private string password;
        //String asociado al error/succses de un registro
        private string error;
        /*
         * Inicializador de la clase, asignacion de valores iniciales
         */
        public LoginViewModel(IService service)
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
            _service = service;
            Error = "";
            user = "";
            password = "";
        }
        /*
         * Funcion asociada al boton de login
         * Encargada de verificar el incio de sesion usando un GET
         * Puede tener exito haciendo el get y validando la contrasena o puede mostrar en pantalla que la cita ya existe
         */
        private async void OnLoginClicked(object obj)
        {
            try
            {
                Client client = await _service.GetClientAsync(User);
                Error = "";
                if (client.Password == password)
                {
                    UserSingleton.GetInstance().Id =client.Id;
                    await Shell.Current.GoToAsync($"//{nameof(Registration)}");
                }
                else
                {
                    Error = "No se pudo iniciar sesión, contraseña equivocada";
                }
            }
            catch (Exception ex)
            {
                Error = "No se pudo iniciar sesión, nombre de usuario no encontrado";
                Console.WriteLine(ex.Message);
            }
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

        }
        /*
         * Funcion asociada al boton de registrarse
         *Encargada de rederigir a la pagina de registro de clientes
         */
        private async void OnRegisterClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync(nameof(Register));
        }
        /*
         * Getters y Setters 
         */
        public string User
        {
            get => user;
            set => SetProperty(ref user, value);

        }
        public string Error
        {
            get => error;
            set => SetProperty(ref error, value);

        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);

        }

    }
}
