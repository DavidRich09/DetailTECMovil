using MobileTallerTEC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MobileTallerTEC.Services
{
    /*
     * Clase ApiService
     * Implementa la interfaz IService
     * Clase con la lógica asociada a los GETS y POSTS de la API
     */
    public class ApiService : IService
    {
        //Instanciacion del cliente que hara requests a la API
        private readonly HttpClient _httpClient;
        /*
         * Inicializador de la clase, asignacion de valores iniciales
         */
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddClienteAsync(Cliente cliente)
        {
            var response = await _httpClient.PostAsync("Cliente/saveClient",
                new StringContent(JsonConvert.SerializeObject(cliente, Formatting.Indented), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
        public async Task<List<Cliente>> GetClientesAsync()
        {
            var response = await _httpClient.GetAsync($"Cliente/getAllClients/");
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var a = JsonConvert.DeserializeObject<string>(responseAsString);
            return JsonConvert.DeserializeObject<List<Cliente>>(a);
        }

        public async Task AddTrabajadorAsync(Trabajador trabajador)
        {
            _httpClient.Timeout = TimeSpan.FromSeconds(10);
            var response = await _httpClient.PostAsync("Trabajadors/saveWorker",
                new StringContent(JsonConvert.SerializeObject(trabajador, Formatting.Indented), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
        public async Task<List<Trabajador>> GetTrabajadoresAsync()
        {
            var response = await _httpClient.GetAsync($"Trabajadors/getAllWorkers/");
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var a = JsonConvert.DeserializeObject<string>(responseAsString);
            return JsonConvert.DeserializeObject<List<Trabajador>>(a);
        }

        public async Task AddSucursalAsync(Sucursal sucursal)
        {
            _httpClient.Timeout = TimeSpan.FromSeconds(10);
            var response = await _httpClient.PostAsync("Sucursal/saveOffice",
                new StringContent(JsonConvert.SerializeObject(sucursal, Formatting.Indented), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
        public async Task<List<Sucursal>> GetSucursalesAsync()
        {
            var response = await _httpClient.GetAsync($"Sucursal/getAllOffices/");
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var a = JsonConvert.DeserializeObject<string>(responseAsString);
            return JsonConvert.DeserializeObject<List<Sucursal>>(a);
        }

        public async Task AddLavadoAsync(Lavado lavado)
        {
            _httpClient.Timeout = TimeSpan.FromSeconds(10);
            var response = await _httpClient.PostAsync("Wash/saveWash",
                new StringContent(JsonConvert.SerializeObject(lavado, Formatting.Indented), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
        public async Task<List<Lavado>> GetLavadosAsync()
        {
            var response = await _httpClient.GetAsync($"Wash/getAllWashes/");
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var a = JsonConvert.DeserializeObject<string>(responseAsString);
            return JsonConvert.DeserializeObject<List<Lavado>>(a);
        }

        public async Task AddCitaAsync(Citum citum)
        {
            var response = await _httpClient.PostAsync("CitumContoller/saveAppointment",
                new StringContent(JsonConvert.SerializeObject(citum, Formatting.Indented), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
        public async Task<List<Citum>> GetCitasAsync()
        {
            var response = await _httpClient.GetAsync($"CitumContoller/getAllAppointments/");
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            var a = JsonConvert.DeserializeObject<string>(responseAsString);
            return JsonConvert.DeserializeObject<List<Citum>>(a);
        }


        /*
         * Funcion que anade una nueva cita realizando un POST en la api
         * Parametros: appointment: cita a registrar
         */
        public async Task AddAppointmentAsync(Appointment appointment)
        {
            var response = await _httpClient.PostAsync("Quote/saveQuote",
                new StringContent(JsonConvert.SerializeObject(appointment, Formatting.Indented), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

        }
        /*
         * Funcion que anade un nuevo cliente realizando un POST en la api
         * Parametros: client: cliente a registrar
         */
        public async Task AddClientAsync(Client client)
        {
            var response = await _httpClient.PostAsync("Client/saveClientClient",
                new StringContent(JsonConvert.SerializeObject(client, Formatting.Indented), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        /*
         * Funcion que solicita las facturas de un cliente realizando un GET en la api
         * Parametros: id: id del cliente del cual se desean las facturas
         * Retorna: Lista de facturas del cliente
         */
        public async Task<List<Bill>> GetBillsAsync(string id)
        {
            var response = await _httpClient.GetAsync($"Quote/RequestBills/{id}");
            response.EnsureSuccessStatusCode();
            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Bill>>(responseAsString);
        }
        /*
         * Funcion que solicita un cliente por medio del ususario realizando un GET en la api
         * Parametros: user: user del cliente a solicitar
         * Retorna: cliente solicitado
         */
        public async Task<Client> GetClientAsync(string user)
        {
            var response = await _httpClient.GetAsync($"Client/requestClientbyUser/{user}");
            response.EnsureSuccessStatusCode();
            string responseAsString = await response.Content.ReadAsStringAsync();
            string responseAsString_slice = responseAsString.Substring(26, responseAsString.Length - 27);
            return JsonConvert.DeserializeObject<Client>(responseAsString_slice);
        }
        /*
         * Funcion que solicita un trabajador realizando un GET en la api
         * Retorna: trabajador solicitado
         */
        public async Task<Worker> GetWorkerRAsync()
        {
            var response = await _httpClient.GetAsync("Api/requestWorkerR");
            response.EnsureSuccessStatusCode();
            string responseAsString = await response.Content.ReadAsStringAsync();
            string responseAsString_slice = responseAsString.Substring(26, responseAsString.Length - 27);
            return JsonConvert.DeserializeObject<Worker>(responseAsString_slice);
        }
    }
}
