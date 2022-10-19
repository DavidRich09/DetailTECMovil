using MobileTallerTEC.Models;
using MobileTallerTEC.Services;
using System;
using System.Collections.Generic;
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
        private string office;
        //String asociado al servicio de la cita
        private string service;
        //String asociado a la fecha de la cita
        private string date;
        //String asociado a la fecha de hoy
        private string today;
        //String asociado al error/succses de un registro
        private string error;

        /*
         * Inicializador de la clase, asignacion de valores iniciales
         */
        public RegistrationViewModel(IService service)
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            _service = service;
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
            Title = "Registro de Citas";
            today = DateTime.Today.ToString("MM-dd-yyyy");
            date = DateTime.Today.ToString("MM-dd-yyyy");
            Error = "";
        }
        /*
         * Funcion que valida si los espacios no estan vacios y cumplen con las restricciones para el registro
         */
        private bool ValidateSave()
        {
            bool valid = false;
            if (!String.IsNullOrWhiteSpace(license_plate) && license_plate.Length == 7
                && !String.IsNullOrWhiteSpace(office)
                && !String.IsNullOrWhiteSpace(service)
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
        public string Office
        {
            get => office;
            set => SetProperty(ref office, value);
        }
        public string Service
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
            List<Replacements> Replacements = new List<Replacements>();
            try
            {
                Worker Responsible = await _service.GetWorkerRAsync();
                Worker Assistant = await _service.GetWorkerRAsync();
                var appointment = new Appointment
                {
                    responsible = Responsible.idNumber.ToString(),
                    assistant = Assistant.idNumber.ToString(),
                    licensePlate = License_plate,
                    service = Service,
                    client = UserSingleton.GetInstance().Id,
                    office = Office,
                    date = Date.Substring(3, 2)+"-"+Date.Substring(0,2)+"-"+Date.Substring(6, 4),
                    replacements = Replacements
                };

                await _service.AddAppointmentAsync(appointment);

                await Shell.Current.GoToAsync("..");
                Error = "Cita registrada correctamente";
            }
            catch (Exception ex)
            {
                Error = "No se pudo registrar la cita";
                Console.WriteLine(ex.Message);
            }
        }
    }
}
