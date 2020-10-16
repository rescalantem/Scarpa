using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Apartados
    {
        public Apartados()
        {
            ApartadoAbonos = new HashSet<ApartadoAbonos>();
            ApartadoDetalle = new HashSet<ApartadoDetalle>();
        }

        public int ApaId { get; set; }
        public DateTime ApaFechaHora { get; set; }
        public byte ApaDias { get; set; }
        public decimal ApaImporte { get; set; }
        public decimal ApaSaldo { get; set; }
        public int CliId { get; set; }
        public int TieId { get; set; }
        public int UsuId { get; set; }

        public Clientes Cli { get; set; }
        public Tiendas Tie { get; set; }
        public Usuarios Usu { get; set; }
        public ICollection<ApartadoAbonos> ApartadoAbonos { get; set; }
        public ICollection<ApartadoDetalle> ApartadoDetalle { get; set; }
    }
}
