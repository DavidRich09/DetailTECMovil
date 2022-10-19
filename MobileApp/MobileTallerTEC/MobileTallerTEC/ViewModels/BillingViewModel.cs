using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using MobileTallerTEC.Services;
using MobileTallerTEC.Models;
using MobileTallerTEC.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MobileTallerTEC.ViewModels
{
    /*
     * Clase BillingViewModel
     * Clase padre: BaseViewModel
     * Clase con la lógica asociada al Billing.xaml
     */
    public class BillingViewModel : BaseViewModel
    {
        private Bill _selectedBill;

        //Instancia de servicio con el cual se realizan GETS y POST de la API
        private readonly IService _service;
        //Lista observable de facturas de un cliente
        public ObservableCollection<Bill> Bills { get; }
        //Comando para cargar las facturas de un cliente
        public Command LoadBillsCommand { get; }
        /*
         * Inicializador de la clase, asignacion de valores iniciales
         */
        public BillingViewModel(IService service)
        {
            Title = "Facturación";
            Bills = new ObservableCollection<Bill>();
            LoadBillsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            _service = service;
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
                Bills.Clear();
                List<Bill> bills = await _service.GetBillsAsync(UserSingleton.GetInstance().Id);
                foreach (var bill in bills)
                {
                    Bills.Add(bill);
                }
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
        //Funcion para la inicializacion de variables en aparicion
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedBill = null;
        }

        public Bill SelectedBill
        {
            get => _selectedBill;
            set
            {
                SetProperty(ref _selectedBill, value);
            }
        }
    }
}