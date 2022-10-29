using System;
using System.Collections.Generic;
using SQLite;

namespace MobileTallerTEC.Models
{
    public partial class Proveedor
    {
        [PrimaryKey] 
        public int CedJuridica { get; set; }
        public string? Nombre { get; set; }
        public int? Contacto { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }
    }
}
