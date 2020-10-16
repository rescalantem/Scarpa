using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class ApartadoDetalle
    {
        public int AdeId { get; set; }
        public int ApaId { get; set; }
        public int ApaCantidad { get; set; }
        public decimal ApaPrecio { get; set; }
        public int PtiId { get; set; }

        public Apartados Apa { get; set; }
        public ProductosTiendas Pti { get; set; }
    }
}
