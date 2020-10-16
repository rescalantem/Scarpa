using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class PromocionLineas
    {
        public int PliId { get; set; }
        public int ProId { get; set; }
        public string ProLinea { get; set; }

        public Promociones Pro { get; set; }
    }
}
