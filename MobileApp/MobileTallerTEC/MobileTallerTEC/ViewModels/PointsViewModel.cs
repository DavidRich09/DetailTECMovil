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
    public class PointsViewModel : BaseViewModel
    {
        //private Bill _selectedBill;

        //Instancia de servicio con el cual se realizan GETS y POST de la API
        private readonly IService _service;

        //Comando para cargar las facturas de un cliente
        public Command LoadBillsCommand { get; }
        //Cantidad de puntos totales
        private string cantPoints;
        //Cantidad de puntos redimidos
        private string cantPointsRed;
        //Cantidad de puntos sobrantes
        private string cantPointsAviable;

        /*
         * Inicializador de la clase, asignacion de valores iniciales
         */
        public PointsViewModel(IService service)
        {
            Title = "Puntos";
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
                await App.DataBase.syncronizeDataBase(_service);
                List<Cliente> clientes = await App.DataBase.GetClientesAsync();
                Cliente client = new Cliente();
                foreach (Cliente _cliente in clientes)
                {
                    if (_cliente.Cedula == UserSingleton.GetInstance().Id)
                        client = _cliente;
                }
                CantPoints = (client.Puntos + client.PuntosRedimidos).ToString();
                CantPointsAviable = client.Puntos.ToString();
                CantPointsRed = client.PuntosRedimidos.ToString();
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
            //SelectedBill = null;
        }
        public string CantPoints
        {
            get => cantPoints;
            set => SetProperty(ref cantPoints, value);

        }
        public string CantPointsRed
        {
            get => cantPointsRed;
            set => SetProperty(ref cantPointsRed, value);

        }
        public string CantPointsAviable
        {
            get => cantPointsAviable;
            set => SetProperty(ref cantPointsAviable, value);

        }
    }
}