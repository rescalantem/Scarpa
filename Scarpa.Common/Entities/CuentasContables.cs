using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class CuentasContables
    {
        public CuentasContables()
        {
            CuentasxCobrarTipos = new HashSet<CuentasxCobrarTipos>();
            CuentasxPagarAplicacion = new HashSet<CuentasxPagarAplicacion>();
        }

        public int CcoId { get; set; }
        public string CcoCuenta { get; set; }
        public string CcoDescripcion { get; set; }
        public byte CcoTipoCuenta { get; set; }

        public ICollection<CuentasxCobrarTipos> CuentasxCobrarTipos { get; set; }
        public ICollection<CuentasxPagarAplicacion> CuentasxPagarAplicacion { get; set; }
    }
}
