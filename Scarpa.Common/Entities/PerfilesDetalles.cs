using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class PerfilesDetalles
    {
        public int PdeId { get; set; }
        public int PerId { get; set; }
        public int ModId { get; set; }
        public byte PdePermiso { get; set; }

        public Modulos Mod { get; set; }
        public Perfiles Per { get; set; }
    }
}
