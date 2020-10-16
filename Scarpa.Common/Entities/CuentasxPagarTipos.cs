using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class CuentasxPagarTipos
    {
        public CuentasxPagarTipos()
        {
            CuentasxPagar = new HashSet<CuentasxPagar>();
        }

        public int CptId { get; set; }
        public string CptDescripcion { get; set; }
        public bool CptCarga { get; set; }
        public bool CptReferenciado { get; set; }

        public ICollection<CuentasxPagar> CuentasxPagar { get; set; }
    }
}
