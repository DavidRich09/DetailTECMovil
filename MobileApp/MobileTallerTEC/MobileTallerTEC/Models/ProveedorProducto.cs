using SQLite;
using System;
using System.Collections.Generic;
using System.Xml;

namespace MobileTallerTEC.Models
{
    public partial class ProveedorProducto
    {
        [Indexed(Name = "CompositeKey", Order = 1, Unique = true)]
        public string Nombre { get; set; } = null!;
        [Indexed(Name = "CompositeKey", Order = 2, Unique = true)]
        public string Marca { get; set; } = null!;
        [Indexed(Name = "CompositeKey", Order = 3, Unique = true)]
        public int CedProveedor { get; set; }

    }
}
