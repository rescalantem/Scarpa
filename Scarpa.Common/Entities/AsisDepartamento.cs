using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class AsisDepartamento
    {
        public AsisDepartamento()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int DepId { get; set; }
        public string DepDescripcion { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
