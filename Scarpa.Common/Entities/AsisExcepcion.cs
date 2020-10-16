using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class AsisExcepcion
    {
        public AsisExcepcion()
        {
            AsisBitacora = new HashSet<AsisBitacora>();
        }

        public int ExcId { get; set; }
        public string ExcDescripcion { get; set; }
        public int ExcColor { get; set; }

        public ICollection<AsisBitacora> AsisBitacora { get; set; }
    }
}
