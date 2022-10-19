using MobileTallerTEC.Models;
using MobileTallerTEC.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace MobileTallerTEC.ViewModels
{
    /*
     * Clase RegisterViewModel
     * Clase padre: BaseViewModel
     * Clase con la lógica asociada al Register.xaml
     */
    public class RegisterViewModel : BaseViewModel
    {
        //Instancia de servicio con el cual se realizan GETS y POST de la API
        private readonly IService _service;
        //String asociado al id del cliente
        private string id;
        //String asociado al nombre del cliente
        private string name;
        //String asociado al usuario del cliente
        private string user;
        //String asociado al correo del cliente
        private string email;
        //String asociado a la contrasena del cliente
        private string password;
        //String asociado al error/succses de un registro
        private string error;

        /*
         * Inicializador de la clase, asignacion de valores iniciales
         */
        public RegisterViewModel(IService service)
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            _service = service;
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            Title = "Registrar como Cliente";
            Error = "";

        }
        /*
         * Funcion que valida si los espacios no estan vacios y cumplen con las restricciones para el registro
         */
        private bool ValidateSave()
        {
            bool valid = false;
            if (!String.IsNullOrWhiteSpace(id) && id.Length == 9
                && !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(user)
                && !String.IsNullOrWhiteSpace(email)
                && !String.IsNullOrWhiteSpace(password))

            {
                valid = true;
            }

            return valid;
        }
        /*
         * Getters y Setters 
         */
        public string Id
        {
            get => id;
            set => SetProperty(ref id, value);

        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string User
        {
            get => user;
            set => SetProperty(ref user, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string Error
        {
            get => error;
            set => SetProperty(ref error, value);
        }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        /*
         * Funcion asociada al boton de registrar un cliente
         * Encargada de hacer POST
         * Puede tener exito haciendo el post o puede mostrar en pantalla que la cita ya existe
         */
        private async void OnSave()
        {
            List<ClientAddress> Address = new List<ClientAddress>();
            List<ClientPhones> Phone = new List<ClientPhones>();
            try
            {
                var client = new Client
                {
                    Id = Id,
                    Name = Name,
                    Password = Password,
                    User = User,
                    Email = Email,
                    Address = Address,
                    Phone = Phone

                };

                await _service.AddClientAsync(client);

                await Shell.Current.GoToAsync("..");
                Error = "";
            }
            catch (Exception ex)
            {
                Error = "No se pudo registrar, un cliente ya existe con el número de cédula o usuario seleccionado";
                Console.WriteLine(ex.Message);
            }
        }
    }
}
