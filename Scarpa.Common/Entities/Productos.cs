using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Productos
    {
        public Productos()
        {
            CompedDetalle = new HashSet<CompedDetalle>();
            Inventario = new HashSet<Inventario>();
            MovimientoDetalle = new HashSet<MovimientoDetalle>();
            ProductosTiendas = new HashSet<ProductosTiendas>();
            ProductosVector = new HashSet<ProductosVector>();
        }

        public int ProId { get; set; }
        public string ProEstilo { get; set; }
        public string ProLinea { get; set; }
        public string ProColor { get; set; }
        public string ProMaterial { get; set; }
        public string ProForro { get; set; }
        public string ProSuela { get; set; }
        public string ProCorrida { get; set; }
        public decimal ProCosto { get; set; }
        public decimal ProPrecioFull { get; set; }
        public decimal ProPrecio1 { get; set; }
        public decimal ProPrecio2 { get; set; }
        public decimal ProPrecio3 { get; set; }
        public decimal ProPrecio4 { get; set; }
        public string ProEstiloProveedor { get; set; }
        public bool ProActivo { get; set; }
        public string ProSatId { get; set; }
        public string ProSatUnidadMedida { get; set; }
        public byte ProTipoProducto { get; set; }
        public string ProDescripcion { get; set; }
        public string ProMarca { get; set; }
        public string ProTemporada { get; set; }
        public bool? ProInventariable { get; set; }

        public ICollection<CompedDetalle> CompedDetalle { get; set; }
        public ICollection<Inventario> Inventario { get; set; }
        public ICollection<MovimientoDetalle> MovimientoDetalle { get; set; }
        public ICollection<ProductosTiendas> ProductosTiendas { get; set; }
        public ICollection<ProductosVector> ProductosVector { get; set; }
    }
}
