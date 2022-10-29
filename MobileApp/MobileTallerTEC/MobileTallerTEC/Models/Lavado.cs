using SQLite;
using System;
using System.Collections.Generic;

namespace MobileTallerTEC.Models
{
    public partial class Lavado
    {
        [PrimaryKey]
        public string TipoLavado { get; set; } = null!;
        public string Duracion { get; set; }
        public int Costo { get; set; }
        public int Precio { get; set; }
        public int PuntosOtorga { get; set; }
        public int PuntosRedimir { get; set; }

    }
}
