using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class AsisGuid
    {
        public int GuiId { get; set; }
        public string GuiValor { get; set; }
        public int CajId { get; set; }

        public TiendaCajas Caj { get; set; }
    }
}
