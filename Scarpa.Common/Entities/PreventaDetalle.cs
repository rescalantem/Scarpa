using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class PreventaDetalle
    {
        public int PdeId { get; set; }
        public int PveId { get; set; }
        public int PtiId { get; set; }

        public ProductosTiendas Pti { get; set; }
        public Preventas Pve { get; set; }
    }
}
