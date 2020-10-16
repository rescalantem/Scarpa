using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class CfdisDetalle
    {
        public int CdeId { get; set; }
        public int CfdId { get; set; }
        public decimal CdePrecio { get; set; }
        public int CdeCantidad { get; set; }
        public string CdeTallas { get; set; }
        public string CdeDescripcion { get; set; }

        public Cfdis Cfd { get; set; }
    }
}
