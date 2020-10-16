using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class ProductosVector
    {
        public int PcoId { get; set; }
        public int ProId { get; set; }
        public byte PcoIndice { get; set; }
        public string PcoValor { get; set; }
        public byte PcoCantidad { get; set; }

        public Productos Pro { get; set; }
    }
}
