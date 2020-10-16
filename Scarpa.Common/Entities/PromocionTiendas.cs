using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class PromocionTiendas
    {
        public int PtiId { get; set; }
        public int ProId { get; set; }
        public int TieId { get; set; }

        public Promociones Pro { get; set; }
        public Tiendas Tie { get; set; }
    }
}
