using MobileTallerTEC.Models;
using MobileTallerTEC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        //String asociado al telefono del cliente (entry)
        private string phone;
        //String asociado a los telefonos del cliente
        private string phones;
        //String asociado a la direccion del cliente (entry)
        private string address;
        //String asociado a las direcciones del cliente
        private string addresses;

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
            phones = "";
            addresses = "";

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
                && !String.IsNullOrWhiteSpace(password)
                && !String.IsNullOrWhiteSpace(phones)
                && !String.IsNullOrWhiteSpace(addresses))

            {
                valid = true;
            }

            return valid;
        }
        /*
         * Getters y Setters 
         */
        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);

        }
        public string Addresses
        {
            get => addresses;
            set => SetProperty(ref addresses, value);

        }
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);

        }
        public string Phones
        {
            get => phones;
            set => SetProperty(ref phones, value);

        }
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

        public void SavePhone(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(phone) && phone.Length == 8)
            {
                Phones = Phones + Phone + "\n";
                Phone = "";
            }
        }
        public void SaveAddress(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(address))
            {
                Addresses = Addresses + Address + "\n";
                Address = "";
            }
            
        }
        /*
         * Funcion asociada al boton de registrar un cliente
         * Encargada de hacer POST
         * Puede tener exito haciendo el post o puede mostrar en pantalla que la cita ya existe
         */
        private async void OnSave()
        {
            try
            {
                var cliente = new Cliente
                {
                   Cedula = int.Parse(Id),
                   Nombre = Name,
                   Usuario = User,
                   CPassword = Password,
                   Correo = Email,
                   Puntos = 0,
                   PuntosRedimidos = 0

                };
                //await _service.AddClientAsync(client);
                await App.DataBase.SaveClienteAsync(cliente);
                await App.DataBase.syncronizeDataBase(_service);
                List<string> _Address = Addresses.Split("\n").ToList();
                _Address.RemoveAt(_Address.Count - 1);
                List<DirCliente> _Addresses = new List<DirCliente>();
                foreach (string _address in _Address)
                {
                    var dirCliente = new DirCliente
                    {
                        Direccion = _address,
                        CedCliente = int.Parse(Id)
                    };
                    await App.DataBase.SaveDirClienteAsync(dirCliente);
                }
                List<string> _Phone = Phones.Split("\n").ToList();
                _Phone.RemoveAt(_Phone.Count - 1);
                List<TelCliente> _Phones = new List<TelCliente>();
                foreach (string _phone in _Phone)
                {
                    var telCliente = new TelCliente
                    {
                        Telefono = int.Parse(_phone),
                        CedCliente = int.Parse(Id)
                    };
                    await App.DataBase.SaveTelClienteAsync(telCliente);
                }
                await App.DataBase.syncronizeDataBase(_service);
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
