using MobileTallerTEC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MobileTallerTEC.Services
{
    /*
     * Interfac IService
     * Interfaz utilizada para la creacion de la clase ApiService
     */
    public interface IService
    {
        Task AddAppointmentAsync(Appointment appointment);
        Task AddClientAsync(Client client);
        
        Task AddClienteAsync(Cliente cliente);
        Task<List<Cliente>> GetClientesAsync();

        Task AddTrabajadorAsync(Trabajador trabajador);
        Task<List<Trabajador>> GetTrabajadoresAsync();

        Task AddSucursalAsync(Sucursal sucursal);
        Task<List<Sucursal>> GetSucursalesAsync();

        Task AddLavadoAsync(Lavado lavado);
        Task<List<Lavado>> GetLavadosAsync();

        Task AddCitaAsync(Citum citum);
        Task<List<Citum>> GetCitasAsync();

        Task<Client> GetClientAsync(string user);

        Task<List<Bill>> GetBillsAsync(string id);

        Task<Worker> GetWorkerRAsync();

    }
}

