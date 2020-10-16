using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class CuentasxPagarAplicacion
    {
        public int CpaId { get; set; }
        public int CxpIdOrigen { get; set; }
        public int CxpIdDestino { get; set; }
        public decimal CpaImporte { get; set; }
        public DateTime CpaFecha { get; set; }
        public int? CcoId { get; set; }

        public CuentasContables Cco { get; set; }
        public CuentasxPagar CxpIdDestinoNavigation { get; set; }
        public CuentasxPagar CxpIdOrigenNavigation { get; set; }
    }
}
