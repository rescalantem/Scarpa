using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class AsisAsistencia
    {
        public int AsiId { get; set; }
        public DateTime AsiIncidencia { get; set; }
        public byte AsiNumero { get; set; }
        public DateTime AsiEnSistema { get; set; }
        public byte AsiRetardo { get; set; }
        public int UsuId { get; set; }

        public Usuarios Usu { get; set; }
    }
}
