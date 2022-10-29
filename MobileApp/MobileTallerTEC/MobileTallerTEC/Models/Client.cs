using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MobileTallerTEC.Models
{
    /*
     * Clase Client
     * Estructura de la entidad Cliente
     */
    public class Client
    {
        /*
         *  Id: Número de cédula del cliente
        •	Name: Nombre completo del cliente
        •	User: Usuario para inicio de sesión del cliente
        •	Email: Correo electrónico del cliente
        •	Password: Contraseña para inicio de sesión del cliente
        •	Address: Direcciones del cliente
        •	Phone: Teléfonos del cliente

         */
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string CPassword { get; set; }
        public string Correo { get; set; }
        public int Puntos { get; set; }
        public int PuntosRedimidos { get; set; }

        public List<string> Cita { get; set; }

        public List<string> DirClientes { get; set; }

        public List<string> TelClientes { get; set; }
    }
}
