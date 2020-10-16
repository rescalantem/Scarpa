using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class CuentasxCobrar
    {
        public CuentasxCobrar()
        {
            Cfdis = new HashSet<Cfdis>();
            CuentasxCobrarAplicacionCxcIdDestinoNavigation = new HashSet<CuentasxCobrarAplicacion>();
            CuentasxCobrarAplicacionCxcIdOrigenNavigation = new HashSet<CuentasxCobrarAplicacion>();
        }

        public int CxcId { get; set; }
        public int CctId { get; set; }
        public decimal CxcImporte { get; set; }
        public decimal CxcSaldo { get; set; }
        public string CxcDocumento { get; set; }
        public DateTime CxcFecha { get; set; }
        public byte CxcTipoDocumento { get; set; }
        public int CliId { get; set; }
        public DateTime CxcFechaVencimiento { get; set; }
        public byte CxcImpuesto { get; set; }
        public string CxcReferencia { get; set; }
        public bool CxcCancelada { get; set; }
        public string CxcMotivoCancelacion { get; set; }
        public short CxcPares { get; set; }
        public string CxcComentarios { get; set; }
        public byte CxcTipo { get; set; }
        public bool CxcImprocedente { get; set; }
        public byte CxcTipoPoliza { get; set; }
        public int UsuId { get; set; }
        public string CxcPo { get; set; }
        public bool? CcaPagado { get; set; }
        public string CxcUuid { get; set; }

        public CuentasxCobrarTipos Cct { get; set; }
        public Clientes Cli { get; set; }
        public ICollection<Cfdis> Cfdis { get; set; }
        public ICollection<CuentasxCobrarAplicacion> CuentasxCobrarAplicacionCxcIdDestinoNavigation { get; set; }
        public ICollection<CuentasxCobrarAplicacion> CuentasxCobrarAplicacionCxcIdOrigenNavigation { get; set; }
    }
}
