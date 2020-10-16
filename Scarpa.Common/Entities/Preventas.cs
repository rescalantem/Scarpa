using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Preventas
    {
        public Preventas()
        {
            PreventaDetalle = new HashSet<PreventaDetalle>();
        }

        public int PveId { get; set; }
        public DateTime PveFechaHora { get; set; }
        public int UsuIdVendedor { get; set; }
        public int PveTotalArticulos { get; set; }

        public Usuarios UsuIdVendedorNavigation { get; set; }
        public ICollection<PreventaDetalle> PreventaDetalle { get; set; }
    }
}
