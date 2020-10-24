using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class TiendaCajas
    {
        public TiendaCajas()
        {
            AsisGuid = new HashSet<AsisGuid>();
            DiarioCaja = new HashSet<DiarioCaja>();
            Ventas = new HashSet<Ventas>();
        }

        public int CajId { get; set; }
        public string CajDescripcion { get; set; }
        public int TieId { get; set; }

        public Tiendas Tie { get; set; }
        public ICollection<AsisGuid> AsisGuid { get; set; }
        public ICollection<DiarioCaja> DiarioCaja { get; set; }
        public ICollection<Ventas> Ventas { get; set; }
    }
}
