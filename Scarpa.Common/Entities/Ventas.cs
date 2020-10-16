using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Ventas
    {
        public Ventas()
        {
            ApartadoAbonos = new HashSet<ApartadoAbonos>();
            VentaDetalle = new HashSet<VentaDetalle>();
        }

        public int VenId { get; set; }
        public DateTime VenFechaHora { get; set; }
        public int VenCantidad { get; set; }
        public decimal VenImporte { get; set; }
        public int TieId { get; set; }
        public int UsuIdCajero { get; set; }
        public int UsuIdVendedor { get; set; }
        public byte VenTipo { get; set; }
        public byte VenEstatus { get; set; }
        public decimal VenEfectivo { get; set; }
        public decimal VenTarjetaCredito { get; set; }
        public decimal VenTarjetaDebito { get; set; }
        public decimal VenDevolucion { get; set; }
        public decimal VenMonedero { get; set; }
        public decimal VenOtros { get; set; }
        public decimal VenDescuento { get; set; }
        public int? FacId { get; set; }
        public int CliId { get; set; }
        public int CajId { get; set; }
        public int? MonId { get; set; }
        public DateTime VenFechaCaptura { get; set; }
        public bool VenDocumento { get; set; }

        public TiendaCajas Caj { get; set; }
        public Clientes Cli { get; set; }
        public Monedero Mon { get; set; }
        public Tiendas Tie { get; set; }
        public Usuarios UsuIdCajeroNavigation { get; set; }
        public Usuarios UsuIdVendedorNavigation { get; set; }
        public ICollection<ApartadoAbonos> ApartadoAbonos { get; set; }
        public ICollection<VentaDetalle> VentaDetalle { get; set; }
    }
}
