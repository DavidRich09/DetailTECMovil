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

        Task<Client> GetClientAsync(string user);

        Task<List<Bill>> GetBillsAsync(string id);

        Task<Worker> GetWorkerRAsync();

    }
}

