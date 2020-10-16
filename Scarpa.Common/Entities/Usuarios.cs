using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Apartados = new HashSet<Apartados>();
            AsisAsistencia = new HashSet<AsisAsistencia>();
            AsisBitacora = new HashSet<AsisBitacora>();
            AsisRoles = new HashSet<AsisRoles>();
            Bitacora = new HashSet<Bitacora>();
            Cfdis = new HashSet<Cfdis>();
            CompedUsuIdCanceloNavigation = new HashSet<Comped>();
            CompedUsuIdCapturoNavigation = new HashSet<Comped>();
            DiarioCaja = new HashSet<DiarioCaja>();
            MovimientosUsuIdAplicoNavigation = new HashSet<Movimientos>();
            MovimientosUsuIdCanceloNavigation = new HashSet<Movimientos>();
            NotasEntradaUsuIdCanceloNavigation = new HashSet<NotasEntrada>();
            NotasEntradaUsuIdCapturoNavigation = new HashSet<NotasEntrada>();
            Preventas = new HashSet<Preventas>();
            VentasUsuIdCajeroNavigation = new HashSet<Ventas>();
            VentasUsuIdVendedorNavigation = new HashSet<Ventas>();
        }

        public int UsuId { get; set; }
        public string UsuNombre { get; set; }
        public string UsuDireccion { get; set; }
        public string UsuTelefono { get; set; }
        public string UsuLogin { get; set; }
        public string UsuContra { get; set; }
        public int PerId { get; set; }
        public DateTime UsuFechaInicial { get; set; }
        public DateTime UsuFechaFinal { get; set; }
        public string UsuEmail { get; set; }
        public int? TieId { get; set; }
        public bool UsuActivo { get; set; }
        public byte[] UsuFoto { get; set; }
        public bool UsuChecaAsistencia { get; set; }
        public string UsuCurp { get; set; }
        public string UsuRfc { get; set; }
        public int? DepId { get; set; }
        public int? ClaId { get; set; }
        public int? PueId { get; set; }
        public string UsuClaveNomina { get; set; }
        public DateTime UsuNacimiento { get; set; }

        public AsisClasificacion Cla { get; set; }
        public AsisDepartamento Dep { get; set; }
        public Perfiles Per { get; set; }
        public AsisPuesto Pue { get; set; }
        public Tiendas Tie { get; set; }
        public ICollection<Apartados> Apartados { get; set; }
        public ICollection<AsisAsistencia> AsisAsistencia { get; set; }
        public ICollection<AsisBitacora> AsisBitacora { get; set; }
        public ICollection<AsisRoles> AsisRoles { get; set; }
        public ICollection<Bitacora> Bitacora { get; set; }
        public ICollection<Cfdis> Cfdis { get; set; }
        public ICollection<Comped> CompedUsuIdCanceloNavigation { get; set; }
        public ICollection<Comped> CompedUsuIdCapturoNavigation { get; set; }
        public ICollection<DiarioCaja> DiarioCaja { get; set; }
        public ICollection<Movimientos> MovimientosUsuIdAplicoNavigation { get; set; }
        public ICollection<Movimientos> MovimientosUsuIdCanceloNavigation { get; set; }
        public ICollection<NotasEntrada> NotasEntradaUsuIdCanceloNavigation { get; set; }
        public ICollection<NotasEntrada> NotasEntradaUsuIdCapturoNavigation { get; set; }
        public ICollection<Preventas> Preventas { get; set; }
        public ICollection<Ventas> VentasUsuIdCajeroNavigation { get; set; }
        public ICollection<Ventas> VentasUsuIdVendedorNavigation { get; set; }
    }
}
