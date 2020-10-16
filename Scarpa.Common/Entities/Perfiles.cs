using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Perfiles
    {
        public Perfiles()
        {
            PerfilesDetalles = new HashSet<PerfilesDetalles>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int PerId { get; set; }
        public string PerDescripcion { get; set; }
        public byte PerTipo { get; set; }

        public ICollection<PerfilesDetalles> PerfilesDetalles { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
