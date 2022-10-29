using SQLite;
using System;
using System.Collections.Generic;
using System.Xml;

namespace MobileTallerTEC.Models
{
    public partial class PersonalLavado
    {
        [Indexed(Name = "CompositeKey", Order = 1, Unique = true)]
        public string TipoLavado { get; set; } = null!;
        [Indexed(Name = "CompositeKey", Order = 2, Unique = true)]
        public string Rol { get; set; } = null!;
        public int Cantidad { get; set; }
    }
}
