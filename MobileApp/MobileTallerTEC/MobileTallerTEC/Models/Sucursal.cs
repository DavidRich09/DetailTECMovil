using SQLite;
using System;
using System.Collections.Generic;

namespace MobileTallerTEC.Models
{
    /*
 * Clase del modelo de la tabla Sucursal
 */
    public partial class Sucursal
    {
        [PrimaryKey]
        public string Nombre { get; set; } = null!;
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public int Telefono { get; set; }
        public DateTime InicioGerente { get; set; }
        public DateTime Apertura { get; set; }
        public int CedGerente { get; set; }

    }
}
