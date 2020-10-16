using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Modulos
    {
        public Modulos()
        {
            Bitacora = new HashSet<Bitacora>();
            PerfilesDetalles = new HashSet<PerfilesDetalles>();
        }

        public int ModId { get; set; }
        public string ModNombre { get; set; }
        public int? ModPadre { get; set; }
        public bool ModForma { get; set; }

        public ICollection<Bitacora> Bitacora { get; set; }
        public ICollection<PerfilesDetalles> PerfilesDetalles { get; set; }
    }
}
