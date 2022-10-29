using SQLite;
using System;
using System.Collections.Generic;

namespace MobileTallerTEC.Models
{
    public partial class Trabajador
    {
        [PrimaryKey]
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string TPassword { get; set; }
        public string TPago { get; set; }
        public string Rol { get; set; }
        public DateTime Nacimiento { get; set; }
        public int Edad { get; set; }
        public DateTime Ingreso { get; set; }

    }
}
