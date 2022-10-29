using MobileTallerTEC.Models;
using MobileTallerTEC.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MobileTallerTEC.ViewModels
{
    /*
     * Clase RegistrationViewModel
     * Clase padre: BaseViewModel
     * Clase con la lógica asociada al Registration.xaml
     */
    public class RegistrationViewModel : BaseViewModel
    {
        //Instancia de servicio con el cual se realizan GETS y POST de la API
        private readonly IService _service;
        //String asociado al id del cliente
        private string client;
        //String asociado a la placa de la cita
        private string license_plate;
        //String asociado a la sucursal de la cita
        private Sucursal office;
        //String asociado al servicio de la cita
        private Lavado service;
        //String asociado a la fecha de la cita
        private string date;
        //String asociado a la fecha de hoy
        private string today;
        //String asociado al error/succses de un registro
        private string error;
        private IList<Sucursal> offices;
        private IList<Lavado> services;

        public Command LoadBillsCommand { get; }

        /*
         * Inicializador de la clase, asignacion de valores iniciales
         */
        public RegistrationViewModel(IService service)
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            LoadBillsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _service = service;
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            Title = "Registro de Citas";
            today = DateTime.Today.ToString("MM-dd-yyyy");
            date = DateTime.Today.ToString("MM-dd-yyyy");
            Error = "";
        }
        /*
         * Funcion que ejecuta un cargado de las facturas de un cliente
         * Se realiza un get utilizando el id del cliente para retornar las facturas
         * Estas facturas se cargan a la lista observable
         */
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                await App.DataBase.syncronizeDataBase(_service);
                Offices = await App.DataBase.GetSucursalesAsync();
                Services = await App.DataBase.GetLavadosAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            //SelectedBill = null;
        }
        /*
         * Funcion que valida si los espacios no estan vacios y cumplen con las restricciones para el registro
         */
        private bool ValidateSave()
        {
            bool valid = false;
            if (!String.IsNullOrWhiteSpace(license_plate) && license_plate.Length == 7
                && office != null
                && service != null
                && !String.IsNullOrWhiteSpace(date))
            {
                valid = true;
            }
            
            return valid;
        }
        /*
         * Getters y Setters 
         */
        public string Today
        {
            get => today;
            set => SetProperty(ref today, value);

        }
        public IList<Sucursal> Offices
        {
            get => offices;
            set => SetProperty(ref offices, value);

        }
        public IList<Lavado> Services
        {
            get => services;
            set => SetProperty(ref services, value);

        }
        public string Client
        {
            get => client;
            set => SetProperty(ref client, value);

        }
        public string License_plate
        {
            get => license_plate;
            set => SetProperty(ref license_plate, value);
        }
        public Sucursal Office
        {
            get => office;
            set => SetProperty(ref office, value);
        }
        public Lavado Service
        {
            get => service;
            set => SetProperty(ref service, value);
        }
        public string Date
        {
            get => date;
            set => SetProperty(ref date, value);
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
         * Funcion asociada al boton de registrar una cita
         * Encargada de asignar trabajadores a la cita, crear un nuevo objeto cita y hacer POST
         * Puede tener exito haciendo el post o puede mostrar en pantalla que la cita ya existe
         */
        private async void OnSave()
        {
            try
            {
                Trabajador Responsible = await App.DataBase.GetTrabajadorRAsync();
                Console.WriteLine(Responsible);
                var appointment = new Citum
                {
                    CedEmpleado = Responsible.Cedula,
                    PlacaVehiculo = License_plate,
                    TipoLavado = Service.TipoLavado,
                    CedCliente = UserSingleton.GetInstance().Id,
                    Sucursal = Office.Nombre,
                    Fecha = Convert.ToDateTime(Date),
                };

                //await _service.AddAppointmentAsync(appointment);
                await App.DataBase.SaveCitumAsync(appointment);
                await App.DataBase.syncronizeDataBase(_service);
                await Shell.Current.GoToAsync("..");
                Error = "Cita registrada correctamente";

                Console.WriteLine(JsonConvert.SerializeObject(appointment, Formatting.Indented));
            }
            catch (Exception ex)
            {
                Error = "No se pudo registrar la cita";
                Console.WriteLine(ex.Message);
            }
        }
    }
}
