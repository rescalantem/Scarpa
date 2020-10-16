using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Proveedores
    {
        public Proveedores()
        {
            Comped = new HashSet<Comped>();
            CuentasxPagar = new HashSet<CuentasxPagar>();
            Movimientos = new HashSet<Movimientos>();
            NotasEntrada = new HashSet<NotasEntrada>();
        }

        public int PrvId { get; set; }
        public string PrvRfc { get; set; }
        public string PrvNombre { get; set; }
        public string PrvCalle { get; set; }
        public string PrvColonia { get; set; }
        public string PrvNumExterior { get; set; }
        public string PrvNumInterior { get; set; }
        public string PrvCodigoPostal { get; set; }
        public string PrvPoblacion { get; set; }
        public string PrvTelefono { get; set; }
        public byte PrvDiasCredito { get; set; }
        public decimal PrvLimiteCredito { get; set; }
        public bool PrvActivo { get; set; }
        public string PrvEmail { get; set; }
        public string PrvContacto { get; set; }
        public string PrvCondiciones { get; set; }
        public string PrvCuentaContableFiscal { get; set; }
        public string PrvCuentaContableReal { get; set; }
        public byte PrvTipo { get; set; }
        public string PrvAlias { get; set; }
        public string PrvAtencionProveedor { get; set; }
        public string PrvGrupo { get; set; }
        public string PrvEmailCobranza { get; set; }
        public byte EstId { get; set; }
        public string PrvPais { get; set; }

        public Estados Est { get; set; }
        public ICollection<Comped> Comped { get; set; }
        public ICollection<CuentasxPagar> CuentasxPagar { get; set; }
        public ICollection<Movimientos> Movimientos { get; set; }
        public ICollection<NotasEntrada> NotasEntrada { get; set; }
    }
}
