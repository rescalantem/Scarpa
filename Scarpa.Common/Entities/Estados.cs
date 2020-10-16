using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Estados
    {
        public Estados()
        {
            Clientes = new HashSet<Clientes>();
            Proveedores = new HashSet<Proveedores>();
            Tiendas = new HashSet<Tiendas>();
        }

        public byte EstId { get; set; }
        public string EstNombre { get; set; }

        public ICollection<Clientes> Clientes { get; set; }
        public ICollection<Proveedores> Proveedores { get; set; }
        public ICollection<Tiendas> Tiendas { get; set; }
    }
}
