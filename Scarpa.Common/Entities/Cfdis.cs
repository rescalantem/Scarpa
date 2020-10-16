using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Cfdis
    {
        public Cfdis()
        {
            CfdisDetalle = new HashSet<CfdisDetalle>();
        }

        public int CfdId { get; set; }
        public string CfdFolio { get; set; }
        public string CfdSerie { get; set; }
        public byte CfdTipoDocumento { get; set; }
        public int CliId { get; set; }
        public DateTime CfdFechaCaptura { get; set; }
        public DateTime CfdFechaAplicacion { get; set; }
        public DateTime CfdFechaVencimiento { get; set; }
        public decimal CfdImporte { get; set; }
        public byte CfdImpuesto { get; set; }
        public string CfdReferencia { get; set; }
        public bool CfdCancelada { get; set; }
        public string CfdMotivoCancelada { get; set; }
        public int CfdArticulos { get; set; }
        public int? UsuId { get; set; }
        public int? CxcId { get; set; }
        public byte CfdTipoComprobante { get; set; }
        public string CfdUuid { get; set; }
        public decimal? CfdDescuento { get; set; }

        public Clientes Cli { get; set; }
        public CuentasxCobrar Cxc { get; set; }
        public Usuarios Usu { get; set; }
        public ICollection<CfdisDetalle> CfdisDetalle { get; set; }
    }
}
