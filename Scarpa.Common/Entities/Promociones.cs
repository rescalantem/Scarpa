using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Promociones
    {
        public Promociones()
        {
            PromocionLineas = new HashSet<PromocionLineas>();
            PromocionTiendas = new HashSet<PromocionTiendas>();
        }

        public int ProId { get; set; }
        public DateTime ProFechaInicial { get; set; }
        public DateTime ProFechaFinal { get; set; }
        public byte ProTipo { get; set; }
        public TimeSpan ProHoraInicial { get; set; }
        public TimeSpan ProHoraFinal { get; set; }
        public bool ProLunes { get; set; }
        public bool ProMartes { get; set; }
        public bool ProMiercoles { get; set; }
        public bool ProJueves { get; set; }
        public bool ProViernes { get; set; }
        public bool ProSabado { get; set; }
        public bool ProDomingo { get; set; }
        public decimal ProDescuento { get; set; }

        public ICollection<PromocionLineas> PromocionLineas { get; set; }
        public ICollection<PromocionTiendas> PromocionTiendas { get; set; }
    }
}
