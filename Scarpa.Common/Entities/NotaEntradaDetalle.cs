using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class NotaEntradaDetalle
    {
        public int NedId { get; set; }
        public int NedCantidad { get; set; }
        public decimal NedPrecio { get; set; }
        public string NedCorrida { get; set; }
        public int NenId { get; set; }
        public int CdeId { get; set; }

        public NotasEntrada Nen { get; set; }
    }
}
