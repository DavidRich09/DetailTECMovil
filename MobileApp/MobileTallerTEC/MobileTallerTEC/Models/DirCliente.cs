using SQLite;
using System;
using System.Collections.Generic;
using System.Xml;

namespace MobileTallerTEC.Models {
    /*
 * Clase del modelo de la tabla DirCliente
 */
    public partial class DirCliente
    {
        public string Direccion { get; set; } = null!;
        public int CedCliente { get; set; }

        //public virtual Cliente CedClienteNavigation { get; set; } = null!;
    }
}
