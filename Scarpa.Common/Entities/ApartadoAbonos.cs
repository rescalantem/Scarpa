using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class ApartadoAbonos
    {
        public int AabId { get; set; }
        public decimal AabImporte { get; set; }
        public DateTime AabFechaHora { get; set; }
        public int UsuIdRecibio { get; set; }
        public int ApaId { get; set; }
        public int? VenId { get; set; }

        public Apartados Apa { get; set; }
        public Ventas Ven { get; set; }
    }
}
