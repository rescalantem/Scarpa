using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Clientes
    {
        public Clientes()
        {
            Apartados = new HashSet<Apartados>();
            Cfdis = new HashSet<Cfdis>();
            Comped = new HashSet<Comped>();
            CuentasxCobrar = new HashSet<CuentasxCobrar>();
            Ventas = new HashSet<Ventas>();
        }

        public int CliId { get; set; }
        public string CliNombre { get; set; }
        public string CliCalle { get; set; }
        public string CliColonia { get; set; }
        public string CliNumExterior { get; set; }
        public string CliNumInterior { get; set; }
        public string CliCodigoPostal { get; set; }
        public string CliPoblacion { get; set; }
        public byte EstId { get; set; }
        public string CliRfc { get; set; }
        public string CliTelefonos { get; set; }
        public bool CliStatus { get; set; }
        public byte CliDiasCredito { get; set; }
        public decimal CliLimiteCredito { get; set; }
        public byte CliDescuento { get; set; }
        public string CliEmail { get; set; }
        public string CliFlete { get; set; }
        public string CliCondiciones { get; set; }
        public string CliTransporte { get; set; }
        public string CliGrupo { get; set; }
        public byte CliTipoCliente { get; set; }
        public string CliContactoPagos { get; set; }
        public string CliCuentaConcentradora { get; set; }
        public string CliCuentaContable { get; set; }
        public string CliCuentaContableReal { get; set; }
        public byte CliTabulador { get; set; }
        public bool CliExtranjero { get; set; }
        public bool? CliAutorizado { get; set; }
        public string CliMetodoPago { get; set; }
        public string CliNumeroCuenta { get; set; }
        public string CliPais { get; set; }
        public bool CliClienteInterno { get; set; }
        public bool? CliAutorizarPedidos { get; set; }
        public string CliNumRegIdTrib { get; set; }
        public string CliCpExport { get; set; }
        public string CliEstadoExport { get; set; }
        public string CliUsoCfdi { get; set; }
        public string CliFormaPago { get; set; }
        public string CliSatNomBancoOrd { get; set; }

        public Estados Est { get; set; }
        public ICollection<Apartados> Apartados { get; set; }
        public ICollection<Cfdis> Cfdis { get; set; }
        public ICollection<Comped> Comped { get; set; }
        public ICollection<CuentasxCobrar> CuentasxCobrar { get; set; }
        public ICollection<Ventas> Ventas { get; set; }
    }
}
