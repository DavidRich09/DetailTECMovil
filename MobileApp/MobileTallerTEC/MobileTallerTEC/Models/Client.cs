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
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string User { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public List<ClientAddress> Address { get; set; }
        
        public List<ClientPhones> Phone { get; set; }

    }
    /*
     * Clase Client Address
     * Estructura de la relacion entre direccion y cliente
     */
    public class ClientAddress
    {
        /*
         * ClientId: Número de cédula del cliente
        •	Province: Provincia de la dirección del cliente
        •	Canton: Cantón de la dirección del cliente
        •	District: Distrito de la dirección del cliente
        •	Nstreet: Número de calle de la dirección del cliente

         */
        public string ClientId { get; set; }
        public string Nstreet { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Canton { get; set; }

    }
    /*
     * Clase ClientPhones
     * Estructura de la relacion entre cliente y telefono
     */
    public class ClientPhones
    {
        /*
         * •	ClientId: Número de cédula del cliente
•	            Phone: Teléfono del cliente
         */
        public string ClientId { get; set; }

        public string Phone { get; set; }
    }
}
