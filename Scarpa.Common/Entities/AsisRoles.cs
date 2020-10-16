using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class AsisRoles
    {
        public int RolId { get; set; }
        public int UsuId { get; set; }
        public int HorId { get; set; }
        public bool RolActual { get; set; }
        public byte RolContador { get; set; }

        public AsisHorario Hor { get; set; }
        public Usuarios Usu { get; set; }
    }
}
