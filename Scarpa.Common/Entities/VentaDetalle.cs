using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class VentaDetalle
    {
        public int VdeId { get; set; }
        public int VenId { get; set; }
        public int VdeCantidad { get; set; }
        public decimal VdePrecio { get; set; }
        public decimal VdeDescuento { get; set; }
        public int PtiId { get; set; }

        public ProductosTiendas Pti { get; set; }
        public Ventas Ven { get; set; }
    }
}
