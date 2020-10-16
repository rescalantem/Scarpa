using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Movimientos
    {
        public Movimientos()
        {
            CuentasxPagar = new HashSet<CuentasxPagar>();
            MovimientoDetalle = new HashSet<MovimientoDetalle>();
        }

        public int MovId { get; set; }
        public DateTime MovFechaHora { get; set; }
        public string MovReferencia { get; set; }
        public int MovCantidad { get; set; }
        public byte MovTipoMovto { get; set; }
        public decimal MovImporte { get; set; }
        public string MovReferenciaPrv { get; set; }
        public bool MovAplicado { get; set; }
        public int? UsuIdAplico { get; set; }
        public DateTime? MovFechaAplicado { get; set; }
        public bool MovCancelado { get; set; }
        public string MovMotivoCancelado { get; set; }
        public int? UsuIdCancelo { get; set; }
        public int TieIdOrigen { get; set; }
        public int TieIdDestino { get; set; }
        public int? PrvId { get; set; }
        public DateTime? MovFechaCancelado { get; set; }

        public Proveedores Prv { get; set; }
        public Tiendas TieIdDestinoNavigation { get; set; }
        public Tiendas TieIdOrigenNavigation { get; set; }
        public Usuarios UsuIdAplicoNavigation { get; set; }
        public Usuarios UsuIdCanceloNavigation { get; set; }
        public ICollection<CuentasxPagar> CuentasxPagar { get; set; }
        public ICollection<MovimientoDetalle> MovimientoDetalle { get; set; }
    }
}
