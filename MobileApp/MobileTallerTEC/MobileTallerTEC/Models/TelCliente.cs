using SQLite;
using System;
using System.Collections.Generic;
using System.Xml;

namespace MobileTallerTEC.Models
{
    public partial class TelCliente
    {
        [Indexed(Name = "CompositeKey", Order = 1, Unique = true)]
        public int Telefono { get; set; }
        [Indexed(Name = "CompositeKey", Order = 2, Unique = true)]
        public int CedCliente { get; set; }

    }
}
