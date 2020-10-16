using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class CuentasxCobrarAplicacion
    {
        public int CcaId { get; set; }
        public int CxcIdOrigen { get; set; }
        public int CxcIdDestino { get; set; }
        public decimal CcaImporte { get; set; }
        public DateTime CcaFecha { get; set; }
        public int CcoId { get; set; }
        public DateTime CcaFechaPago { get; set; }
        public bool? CcaPagado { get; set; }

        public CuentasxCobrar CxcIdDestinoNavigation { get; set; }
        public CuentasxCobrar CxcIdOrigenNavigation { get; set; }
    }
}
