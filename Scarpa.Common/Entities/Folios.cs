using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Folios
    {
        public int FolId { get; set; }
        public string FolSerie { get; set; }
        public int FolFolioActual { get; set; }
        public byte FolTipo { get; set; }
        public int TieId { get; set; }

        public Tiendas Tie { get; set; }
    }
}
