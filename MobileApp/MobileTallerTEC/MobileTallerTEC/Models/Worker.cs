using System;

namespace MobileTallerTEC.Models
{
    /*
  * Clase Worker
  * Estructura de la entidad trabajador
  */
    public class Worker
    {
        /*
         * idNumber: Número de cédula del trabajador
        •	name: Nombre del trabajador
        •	lastName: Apellido del trabajador
        •	dateAdmisson: Día de admisión en el trabajo
        •	dateBirth: Día de nacimiento
        •	rol: Rol a desempeñar como trabajador
        •	password: Contraseña de la cuenta para ingresar a la aplicación web

         */
        public int idNumber { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string dateAdmisson { get; set; }
        public string dateBirth { get; set; }
        public string rol { get; set; }
        public string password { get; set; }


    }
}
