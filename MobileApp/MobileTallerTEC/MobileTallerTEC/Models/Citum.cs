using System;
using SQLite;
using System.Collections.Generic;

namespace MobileTallerTEC.Models
{
    public partial class Citum
    {
        [Indexed(Name = "CompositeKey", Order = 1, Unique = true)]
        public string PlacaVehiculo { get; set; } = null!;
        
        [Indexed(Name = "CompositeKey", Order = 2, Unique = true)]
        public DateTime Fecha { get; set; }
        public string? TipoLavado { get; set; }
        public string? Sucursal { get; set; }
        public int? CedEmpleado { get; set; }
        public int? CedCliente { get; set; }
    }
}
