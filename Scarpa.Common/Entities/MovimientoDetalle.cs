using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class MovimientoDetalle
    {
        public int MdeId { get; set; }
        public int MovId { get; set; }
        public int ProId { get; set; }
        public string MdeTallas { get; set; }
        public int MdeCantidad { get; set; }
        public decimal MdePrecio { get; set; }
        public decimal MdeCosto { get; set; }

        public Movimientos Mov { get; set; }
        public Productos Pro { get; set; }
    }
}
