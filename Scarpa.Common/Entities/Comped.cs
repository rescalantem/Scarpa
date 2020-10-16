using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Comped
    {
        public Comped()
        {
            CompedDetalle = new HashSet<CompedDetalle>();
        }

        public int ComId { get; set; }
        public DateTime ComFechaCaptura { get; set; }
        public DateTime? ComFechaEntrega { get; set; }
        public DateTime? ComFechaCancelada { get; set; }
        public string ComMotivoCancelada { get; set; }
        public bool ComSuspendido { get; set; }
        public string ComCondiciones { get; set; }
        public string ComReferencia { get; set; }
        public string ComMarca { get; set; }
        public int ComArticulos { get; set; }
        public decimal ComImporte { get; set; }
        public string ComObservaciones { get; set; }
        public byte ComEstatus { get; set; }
        public int UsuIdCapturo { get; set; }
        public int? UsuIdCancelo { get; set; }
        public int? PrvId { get; set; }
        public int? CliId { get; set; }
        public bool ComEsCompra { get; set; }
        public byte ComTipo { get; set; }

        public Clientes Cli { get; set; }
        public Proveedores Prv { get; set; }
        public Usuarios UsuIdCanceloNavigation { get; set; }
        public Usuarios UsuIdCapturoNavigation { get; set; }
        public ICollection<CompedDetalle> CompedDetalle { get; set; }
    }
}
