using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class AsisClasificacion
    {
        public AsisClasificacion()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int ClaId { get; set; }
        public string ClaDescripcion { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
