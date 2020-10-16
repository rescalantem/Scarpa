using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class NotasEntrada
    {
        public NotasEntrada()
        {
            NotaEntradaDetalle = new HashSet<NotaEntradaDetalle>();
        }

        public int NenId { get; set; }
        public byte NenTipoDocumento { get; set; }
        public DateTime NenFechaCaptura { get; set; }
        public int NenTotalArticulo { get; set; }
        public decimal NenImporte { get; set; }
        public string NenReferencia { get; set; }
        public string NenObservaciones { get; set; }
        public DateTime? NenFechaCancelada { get; set; }
        public string NenMotivoCancelada { get; set; }
        public int? CxpId { get; set; }
        public int PrvId { get; set; }
        public int UsuIdCapturo { get; set; }
        public int? UsuIdCancelo { get; set; }

        public CuentasxPagar Cxp { get; set; }
        public Proveedores Prv { get; set; }
        public Usuarios UsuIdCanceloNavigation { get; set; }
        public Usuarios UsuIdCapturoNavigation { get; set; }
        public ICollection<NotaEntradaDetalle> NotaEntradaDetalle { get; set; }
    }
}
