using SQLite;
using System;
using System.Collections.Generic;
using System.Xml;

namespace MobileTallerTEC.Models
{
    public partial class Producto
    {
        [Indexed(Name = "CompositeKey", Order = 1, Unique = true)]
        public string Nombre { get; set; } = null!;
        [Indexed(Name = "CompositeKey", Order = 2, Unique = true)]
        public string Marca { get; set; } = null!;
        public int? Costo { get; set; }
        public string TipoLavado { get; set; } = null!;
    }
}
