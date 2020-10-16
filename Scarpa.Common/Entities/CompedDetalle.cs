using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class CompedDetalle
    {
        public int CdeId { get; set; }
        public int CdeCantidad { get; set; }
        public decimal CdePrecio { get; set; }
        public string CdeCorridaOriginal { get; set; }
        public string CdeCorrida { get; set; }
        public int ComId { get; set; }
        public int ProId { get; set; }

        public Comped Com { get; set; }
        public Productos Pro { get; set; }
    }
}
