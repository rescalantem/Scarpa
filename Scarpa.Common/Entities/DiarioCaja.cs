using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class DiarioCaja
    {
        public int DcaId { get; set; }
        public DateTime DcaFechaHora { get; set; }
        public decimal DcaFondo { get; set; }
        public int CajId { get; set; }
        public int UsuId { get; set; }

        public TiendaCajas Caj { get; set; }
        public Usuarios Usu { get; set; }
    }
}
