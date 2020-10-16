using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Bitacora
    {
        public int BitId { get; set; }
        public int UsuId { get; set; }
        public DateTime BitFecha { get; set; }
        public byte BitAccion { get; set; }
        public int ModId { get; set; }
        public string BitReferencia { get; set; }

        public Modulos Mod { get; set; }
        public Usuarios Usu { get; set; }
    }
}
