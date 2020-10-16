using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class CuentasxCobrarTipos
    {
        public CuentasxCobrarTipos()
        {
            CuentasxCobrar = new HashSet<CuentasxCobrar>();
        }

        public int CctId { get; set; }
        public string CctDescripcion { get; set; }
        public bool CctCarga { get; set; }
        public bool CctReferenciado { get; set; }
        public int CctGenera { get; set; }
        public bool CctControlImprocedentes { get; set; }
        public int? CcoId { get; set; }

        public CuentasContables Cco { get; set; }
        public ICollection<CuentasxCobrar> CuentasxCobrar { get; set; }
    }
}
