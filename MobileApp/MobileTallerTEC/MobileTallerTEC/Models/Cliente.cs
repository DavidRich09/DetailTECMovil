using SQLite;

using System;
using System.Collections.Generic;

namespace MobileTallerTEC.Models
{
    /*
 * Clase del modelo de la tabla Cliente
 */
    public partial class Cliente
    {

        [PrimaryKey]
        public int Cedula { get; set; }
        public string? Nombre { get; set; }
        public string? Usuario { get; set; }
        public string? CPassword { get; set; }
        public string? Correo { get; set; }
        public int? Puntos { get; set; }
        public int? PuntosRedimidos { get; set; }

    }
}
