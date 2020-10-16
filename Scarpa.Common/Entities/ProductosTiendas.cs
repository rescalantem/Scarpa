using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class ProductosTiendas
    {
        public ProductosTiendas()
        {
            ApartadoDetalle = new HashSet<ApartadoDetalle>();
            PreventaDetalle = new HashSet<PreventaDetalle>();
            VentaDetalle = new HashSet<VentaDetalle>();
        }

        public int PtiId { get; set; }
        public int ProId { get; set; }
        public string ProCodigo { get; set; }
        public int PtiExistencia { get; set; }
        public int PtiApartados { get; set; }
        public int TieId { get; set; }

        public Productos Pro { get; set; }
        public Tiendas Tie { get; set; }
        public ICollection<ApartadoDetalle> ApartadoDetalle { get; set; }
        public ICollection<PreventaDetalle> PreventaDetalle { get; set; }
        public ICollection<VentaDetalle> VentaDetalle { get; set; }
    }
}
