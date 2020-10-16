using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Inventario
    {
        public int InvId { get; set; }
        public DateTime InvFecha { get; set; }
        public string InvTallas { get; set; }
        public int ProId { get; set; }
        public int TieId { get; set; }

        public Productos Pro { get; set; }
        public Tiendas Tie { get; set; }
    }
}
