using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Monedero
    {
        public Monedero()
        {
            Ventas = new HashSet<Ventas>();
        }

        public int MonId { get; set; }
        public string MonNombre { get; set; }
        public string MonTelefono { get; set; }
        public decimal MonImporte { get; set; }
        public decimal MonSaldo { get; set; }
        public DateTime MonFechaHora { get; set; }
        public int TieId { get; set; }

        public Tiendas Tie { get; set; }
        public ICollection<Ventas> Ventas { get; set; }
    }
}
