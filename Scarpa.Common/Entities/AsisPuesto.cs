using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class AsisPuesto
    {
        public AsisPuesto()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int PueId { get; set; }
        public string PueDescripcion { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
