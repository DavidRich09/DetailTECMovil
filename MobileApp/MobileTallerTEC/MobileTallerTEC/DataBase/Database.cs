using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MobileTallerTEC.Models;
using MobileTallerTEC.Services;
using SQLite;

namespace MobileTallerTEC.DataBase
{
    public class Database
    {
        /*
         * Creacion de la base de datos y sus respectivas tablas 
         */
        private readonly SQLiteAsyncConnection _database;
        public Database(string dbPath) 
        { 
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Cliente>().Wait();
            _database.CreateTableAsync<TelCliente>().Wait();
            _database.CreateTableAsync<DirCliente>().Wait();
            _database.CreateTableAsync<Trabajador>().Wait();
            _database.CreateTableAsync<Sucursal>().Wait();
            _database.CreateTableAsync<Lavado>().Wait();
            _database.CreateTableAsync<Citum>().Wait();
        }
        /*
         * Gets y add a las tablas de la DB SQLite
         */ 
        public Task<List<Cliente>> GetClientesAsync()
        {
            return _database.Table<Cliente>().ToListAsync();
        }
        public Task<List<Trabajador>> GetTrabajodresAsync()
        {
            return _database.Table<Trabajador>().ToListAsync();
        }
        public Task<int> SaveClienteAsync(Cliente cliente)
        {
            return _database.InsertAsync(cliente);
        }
        public Task<List<TelCliente>> GetTelClientes()
        {
            return _database.Table<TelCliente>().ToListAsync();
        }
        public Task<int> SaveTelClienteAsync(TelCliente telcliente)
        {
            return _database.InsertAsync(telcliente);
        }
        public Task<List<DirCliente>> GetDirClientes()
        {
            return _database.Table<DirCliente>().ToListAsync();
        }
        public Task<int> SaveDirClienteAsync(DirCliente dircliente)
        {
            return _database.InsertAsync(dircliente);
        }

        public async Task<Trabajador> GetTrabajadorRAsync()
        {
            List<Trabajador> trabajadores = await _database.Table<Trabajador>().ToListAsync();
            Console.WriteLine("Count Trabajadores");
            Console.WriteLine(trabajadores.Count);
            Random rnd = new Random();
            if (trabajadores.Count != 0)
            {
                return trabajadores[rnd.Next(trabajadores.Count)];
            }
            else
            {
                return null;
            }
        }
        public Task<int> SaveTrabajadorAsync(Trabajador trabajador)
        {
            return _database.InsertAsync(trabajador);
        }
        public Task<int> SaveSucursalAsync(Sucursal sucursal)
        {
            return _database.InsertAsync(sucursal);
        }

        public Task<int> SaveCitumAsync(Citum citum)
        {
            return _database.InsertAsync(citum);
        }

        public Task<List<Citum>> GetCitasAsync()
        {
            return _database.Table<Citum>().ToListAsync();
        }

        public Task<List<Sucursal>> GetSucursalesAsync()
        {
            return _database.Table<Sucursal>().ToListAsync();
        }

        public Task<int> SaveLavadoAsync(Lavado lavado)
        {
            return _database.InsertAsync(lavado);
        }
        public Task<List<Lavado>> GetLavadosAsync()
        {
            return _database.Table<Lavado>().ToListAsync();
        }
        /*
         * Metodo de sincornizacion entre las bases de datos SQL Server y SQLite
         * Parametros: _service: servicio con el cual se conectara a la api
         */
        public async Task syncronizeDataBase(IService _service)
        {
            int timeout = 1000;
            List<Cliente> clientes = await GetClientesAsync();
            foreach (Cliente cliente_ in clientes)
            {
                try
                {
                    var task = _service.AddClienteAsync(cliente_);
                    if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
                    {
                        await task;
                    }
                    else
                    {
                        throw new TimeoutException("The operation has timed out.");
                    }
                    //await _service.AddClienteAsync(cliente_);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            try
            {
                var task = _service.GetClientesAsync();
                List<Cliente> newClientes = new List<Cliente>();
                if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
                {
                    newClientes = await task;
                }
                else
                {
                    throw new TimeoutException("The operation has timed out.");
                }

                await _database.DeleteAllAsync<Cliente>();

                foreach (Cliente newCliente_ in newClientes)
                {
                    try
                    {
                        await SaveClienteAsync(newCliente_);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var task = _service.GetTrabajadoresAsync();
                List<Trabajador> newTrabajadores = new List<Trabajador>();
                if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
                {
                    newTrabajadores = await task;
                }
                else
                {
                    throw new TimeoutException("The operation has timed out.");
                }
                //List<Trabajador> newTrabajadores = await _service.GetTrabajadoresAsync();
                await _database.DeleteAllAsync<Trabajador>();

                foreach (Trabajador newTrabajador_ in newTrabajadores)
                {
                    try
                    {
                        await SaveTrabajadorAsync(newTrabajador_);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var task = _service.GetSucursalesAsync();
                List<Sucursal> newSucursales = new List<Sucursal>();
                if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
                {
                    newSucursales = await task;
                }
                else
                {
                    throw new TimeoutException("The operation has timed out.");
                }
                //List<Sucursal> newSucursales = await _service.GetSucursalesAsync();
                await _database.DeleteAllAsync<Sucursal>();

                foreach (Sucursal newSucursal_ in newSucursales)
                {
                    try
                    {
                        await SaveSucursalAsync(newSucursal_);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var task = _service.GetLavadosAsync();
                List<Lavado> newLavados = new List<Lavado>();
                if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
                {
                    newLavados = await task;
                }
                else
                {
                    throw new TimeoutException("The operation has timed out.");
                }
                //List<Lavado> newLavados = await _service.GetLavadosAsync();
                await _database.DeleteAllAsync<Lavado>();

                foreach (Lavado newLavado_ in newLavados)
                {
                    try
                    {
                        await SaveLavadoAsync(newLavado_);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            List<Citum> citas = await GetCitasAsync();
            foreach (Citum cita_ in citas)
            {
                try
                {
                    var task = _service.AddCitaAsync(cita_);
                    if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
                    {
                        await task;
                    }
                    else
                    {
                        throw new TimeoutException("The operation has timed out.");
                    }
                    //await _service.AddCitaAsync(cita_);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            try
            {
                var task = _service.GetCitasAsync();
                List<Citum> newCitas = new List<Citum>();
                if (await Task.WhenAny(task, Task.Delay(timeout)) == task)
                {
                    newCitas = await task;
                }
                else
                {
                    throw new TimeoutException("The operation has timed out.");
                }
                //List<Citum> newCitas = await _service.GetCitasAsync();
                await _database.DeleteAllAsync<Citum>();

                foreach (Citum newCita_ in newCitas)
                {
                    try
                    {
                        await SaveCitumAsync(newCita_);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        } 
    }
}
