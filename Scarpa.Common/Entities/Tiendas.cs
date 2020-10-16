using System;
using System.Collections.Generic;

namespace Scarpa.Common.Entities
{
    public partial class Tiendas
    {
        public Tiendas()
        {
            Apartados = new HashSet<Apartados>();
            AsisHorario = new HashSet<AsisHorario>();
            Folios = new HashSet<Folios>();
            Inventario = new HashSet<Inventario>();
            Monedero = new HashSet<Monedero>();
            MovimientosTieIdDestinoNavigation = new HashSet<Movimientos>();
            MovimientosTieIdOrigenNavigation = new HashSet<Movimientos>();
            ProductosTiendas = new HashSet<ProductosTiendas>();
            PromocionTiendas = new HashSet<PromocionTiendas>();
            TiendaCajas = new HashSet<TiendaCajas>();
            Usuarios = new HashSet<Usuarios>();
            Ventas = new HashSet<Ventas>();
        }

        public int TieId { get; set; }
        public string TieRfc { get; set; }
        public string TieNombre { get; set; }
        public string TieCalle { get; set; }
        public string TieCodigoPostal { get; set; }
        public string TieColonia { get; set; }
        public byte EstId { get; set; }
        public string TieMunicipio { get; set; }
        public string TieNoExterior { get; set; }
        public string TiePais { get; set; }
        public string TieTelefono { get; set; }
        public string TieRegimenFiscal { get; set; }
        public string TieCataColonia { get; set; }
        public string TieCataMunicipio { get; set; }
        public string TieCataEstado { get; set; }
        public byte[] TieCertificado { get; set; }
        public byte[] TieKey { get; set; }
        public string TieContraKey { get; set; }
        public string TieUsuarioTimbrado { get; set; }
        public string TieContraTimbrado { get; set; }
        public byte TieTipo { get; set; }

        public Estados Est { get; set; }
        public ICollection<Apartados> Apartados { get; set; }
        public ICollection<AsisHorario> AsisHorario { get; set; }
        public ICollection<Folios> Folios { get; set; }
        public ICollection<Inventario> Inventario { get; set; }
        public ICollection<Monedero> Monedero { get; set; }
        public ICollection<Movimientos> MovimientosTieIdDestinoNavigation { get; set; }
        public ICollection<Movimientos> MovimientosTieIdOrigenNavigation { get; set; }
        public ICollection<ProductosTiendas> ProductosTiendas { get; set; }
        public ICollection<PromocionTiendas> PromocionTiendas { get; set; }
        public ICollection<TiendaCajas> TiendaCajas { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
        public ICollection<Ventas> Ventas { get; set; }
    }
}
