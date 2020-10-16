using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class CuentasxPagar
    {
        public CuentasxPagar()
        {
            CuentasxPagarAplicacionCxpIdDestinoNavigation = new HashSet<CuentasxPagarAplicacion>();
            CuentasxPagarAplicacionCxpIdOrigenNavigation = new HashSet<CuentasxPagarAplicacion>();
            NotasEntrada = new HashSet<NotasEntrada>();
        }

        public int CxpId { get; set; }
        public int CptId { get; set; }
        public int PrvId { get; set; }
        public bool CxpEstatus { get; set; }
        public byte CxpTipoDocumento { get; set; }
        public decimal CxpImporte { get; set; }
        public decimal CxpSaldo { get; set; }
        public byte CxpImpuesto { get; set; }
        public bool CxpDescuentos { get; set; }
        public string CxpReferencia { get; set; }
        public short CxpArticulos { get; set; }
        public string CxpDevolucionProveedor { get; set; }
        public DateTime CxpFechaCaptura { get; set; }
        public DateTime CxpFechaAplicacion { get; set; }
        public DateTime CxpFechaVencimiento { get; set; }
        public int? MovId { get; set; }
        public string CxpUuid { get; set; }
        public int? NenId { get; set; }

        public CuentasxPagarTipos Cpt { get; set; }
        public Movimientos Mov { get; set; }
        public Proveedores Prv { get; set; }
        public ICollection<CuentasxPagarAplicacion> CuentasxPagarAplicacionCxpIdDestinoNavigation { get; set; }
        public ICollection<CuentasxPagarAplicacion> CuentasxPagarAplicacionCxpIdOrigenNavigation { get; set; }
        public ICollection<NotasEntrada> NotasEntrada { get; set; }
    }
}
