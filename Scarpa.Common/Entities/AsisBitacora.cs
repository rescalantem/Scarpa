using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class AsisBitacora
    {
        public int BitId { get; set; }
        public string BitComentarios { get; set; }
        public DateTime BitFecha { get; set; }
        public int UsuId { get; set; }
        public int ExcId { get; set; }

        public AsisExcepcion Exc { get; set; }
        public Usuarios Usu { get; set; }
    }
}
