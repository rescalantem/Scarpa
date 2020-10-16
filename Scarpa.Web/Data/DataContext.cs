using Microsoft.EntityFrameworkCore;
using Scarpa.Common.Entities;

namespace Scarpa.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<ApartadoAbonos> ApartadoAbonos { get; set; }
        public virtual DbSet<ApartadoDetalle> ApartadoDetalle { get; set; }
        public virtual DbSet<Apartados> Apartados { get; set; }
        public virtual DbSet<AsisAsistencia> AsisAsistencia { get; set; }
        public virtual DbSet<AsisBitacora> AsisBitacora { get; set; }
        public virtual DbSet<AsisClasificacion> AsisClasificacion { get; set; }
        public virtual DbSet<AsisDepartamento> AsisDepartamento { get; set; }
        public virtual DbSet<AsisExcepcion> AsisExcepcion { get; set; }
        public virtual DbSet<AsisHorario> AsisHorario { get; set; }
        public virtual DbSet<AsisPuesto> AsisPuesto { get; set; }
        public virtual DbSet<AsisRoles> AsisRoles { get; set; }
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<Catalogos> Catalogos { get; set; }
        public virtual DbSet<Cfdis> Cfdis { get; set; }
        public virtual DbSet<CfdisDetalle> CfdisDetalle { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Comped> Comped { get; set; }
        public virtual DbSet<CompedDetalle> CompedDetalle { get; set; }
        public virtual DbSet<CuentasContables> CuentasContables { get; set; }
        public virtual DbSet<CuentasxCobrar> CuentasxCobrar { get; set; }
        public virtual DbSet<CuentasxCobrarAplicacion> CuentasxCobrarAplicacion { get; set; }
        public virtual DbSet<CuentasxCobrarTipos> CuentasxCobrarTipos { get; set; }
        public virtual DbSet<CuentasxPagar> CuentasxPagar { get; set; }
        public virtual DbSet<CuentasxPagarAplicacion> CuentasxPagarAplicacion { get; set; }
        public virtual DbSet<CuentasxPagarTipos> CuentasxPagarTipos { get; set; }
        public virtual DbSet<DiarioCaja> DiarioCaja { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Folios> Folios { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<Monedero> Monedero { get; set; }
        public virtual DbSet<MovimientoDetalle> MovimientoDetalle { get; set; }
        public virtual DbSet<Movimientos> Movimientos { get; set; }
        public virtual DbSet<NotaEntradaDetalle> NotaEntradaDetalle { get; set; }
        public virtual DbSet<NotasEntrada> NotasEntrada { get; set; }
        public virtual DbSet<Perfiles> Perfiles { get; set; }
        public virtual DbSet<PerfilesDetalles> PerfilesDetalles { get; set; }
        public virtual DbSet<PreventaDetalle> PreventaDetalle { get; set; }
        public virtual DbSet<Preventas> Preventas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<ProductosTiendas> ProductosTiendas { get; set; }
        public virtual DbSet<ProductosVector> ProductosVector { get; set; }
        public virtual DbSet<Promociones> Promociones { get; set; }
        public virtual DbSet<PromocionLineas> PromocionLineas { get; set; }
        public virtual DbSet<PromocionTiendas> PromocionTiendas { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<TiendaCajas> TiendaCajas { get; set; }
        public virtual DbSet<Tiendas> Tiendas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<VentaDetalle> VentaDetalle { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer("Data source=desarrollo2020;initial catalog=Scarpa;integrated security=true");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApartadoAbonos>(entity =>
            {
                entity.HasKey(e => e.AabId);

                entity.ToTable("apartadoAbonos");

                entity.Property(e => e.AabId).HasColumnName("aabId");

                entity.Property(e => e.AabFechaHora)
                    .HasColumnName("aabFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.AabImporte)
                    .HasColumnName("aabImporte")
                    .HasColumnType("money");

                entity.Property(e => e.ApaId).HasColumnName("apaId");

                entity.Property(e => e.UsuIdRecibio).HasColumnName("usuIdRecibio");

                entity.Property(e => e.VenId).HasColumnName("venId");

                entity.HasOne(d => d.Apa)
                    .WithMany(p => p.ApartadoAbonos)
                    .HasForeignKey(d => d.ApaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_apartadoAbonos_apartados");

                entity.HasOne(d => d.Ven)
                    .WithMany(p => p.ApartadoAbonos)
                    .HasForeignKey(d => d.VenId)
                    .HasConstraintName("FK_apartadoAbonos_ventas");
            });

            modelBuilder.Entity<ApartadoDetalle>(entity =>
            {
                entity.HasKey(e => e.AdeId);

                entity.ToTable("apartadoDetalle");

                entity.Property(e => e.AdeId).HasColumnName("adeId");

                entity.Property(e => e.ApaCantidad).HasColumnName("apaCantidad");

                entity.Property(e => e.ApaId).HasColumnName("apaId");

                entity.Property(e => e.ApaPrecio)
                    .HasColumnName("apaPrecio")
                    .HasColumnType("money");

                entity.Property(e => e.PtiId).HasColumnName("ptiId");

                entity.HasOne(d => d.Apa)
                    .WithMany(p => p.ApartadoDetalle)
                    .HasForeignKey(d => d.ApaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_apartadoDetalle_apartados");

                entity.HasOne(d => d.Pti)
                    .WithMany(p => p.ApartadoDetalle)
                    .HasForeignKey(d => d.PtiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_apartadoDetalle_productosTiendas");
            });

            modelBuilder.Entity<Apartados>(entity =>
            {
                entity.HasKey(e => e.ApaId);

                entity.ToTable("apartados");

                entity.Property(e => e.ApaId).HasColumnName("apaId");

                entity.Property(e => e.ApaDias).HasColumnName("apaDias");

                entity.Property(e => e.ApaFechaHora)
                    .HasColumnName("apaFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.ApaImporte)
                    .HasColumnName("apaImporte")
                    .HasColumnType("money");

                entity.Property(e => e.ApaSaldo)
                    .HasColumnName("apaSaldo")
                    .HasColumnType("money");

                entity.Property(e => e.CliId).HasColumnName("cliId");

                entity.Property(e => e.TieId).HasColumnName("tieId");

                entity.Property(e => e.UsuId).HasColumnName("usuId");

                entity.HasOne(d => d.Cli)
                    .WithMany(p => p.Apartados)
                    .HasForeignKey(d => d.CliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_apartados_clientes");

                entity.HasOne(d => d.Tie)
                    .WithMany(p => p.Apartados)
                    .HasForeignKey(d => d.TieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_apartados_tiendas");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Apartados)
                    .HasForeignKey(d => d.UsuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_apartados_usuarios");
            });

            modelBuilder.Entity<AsisAsistencia>(entity =>
            {
                entity.HasKey(e => e.AsiId);

                entity.ToTable("asisAsistencia");

                entity.Property(e => e.AsiId).HasColumnName("asiId");

                entity.Property(e => e.AsiEnSistema)
                    .HasColumnName("asiEnSistema")
                    .HasColumnType("datetime");

                entity.Property(e => e.AsiIncidencia)
                    .HasColumnName("asiIncidencia")
                    .HasColumnType("datetime");

                entity.Property(e => e.AsiNumero).HasColumnName("asiNumero");

                entity.Property(e => e.AsiRetardo).HasColumnName("asiRetardo");

                entity.Property(e => e.UsuId).HasColumnName("usuId");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.AsisAsistencia)
                    .HasForeignKey(d => d.UsuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asisAsistencia_usuarios");
            });

            modelBuilder.Entity<AsisBitacora>(entity =>
            {
                entity.HasKey(e => e.BitId);

                entity.ToTable("asisBitacora");

                entity.Property(e => e.BitId).HasColumnName("bitId");

                entity.Property(e => e.BitComentarios)
                    .IsRequired()
                    .HasColumnName("bitComentarios")
                    .HasMaxLength(50);

                entity.Property(e => e.BitFecha)
                    .HasColumnName("bitFecha")
                    .HasColumnType("date");

                entity.Property(e => e.ExcId).HasColumnName("excId");

                entity.Property(e => e.UsuId).HasColumnName("usuId");

                entity.HasOne(d => d.Exc)
                    .WithMany(p => p.AsisBitacora)
                    .HasForeignKey(d => d.ExcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asisBitacora_asisExcepcion");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.AsisBitacora)
                    .HasForeignKey(d => d.UsuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asisBitacora_usuarios");
            });

            modelBuilder.Entity<AsisClasificacion>(entity =>
            {
                entity.HasKey(e => e.ClaId);

                entity.ToTable("asisClasificacion");

                entity.Property(e => e.ClaId).HasColumnName("claId");

                entity.Property(e => e.ClaDescripcion)
                    .IsRequired()
                    .HasColumnName("claDescripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AsisDepartamento>(entity =>
            {
                entity.HasKey(e => e.DepId);

                entity.ToTable("asisDepartamento");

                entity.Property(e => e.DepId).HasColumnName("depId");

                entity.Property(e => e.DepDescripcion)
                    .IsRequired()
                    .HasColumnName("depDescripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AsisExcepcion>(entity =>
            {
                entity.HasKey(e => e.ExcId);

                entity.ToTable("asisExcepcion");

                entity.Property(e => e.ExcId).HasColumnName("excId");

                entity.Property(e => e.ExcColor).HasColumnName("excColor");

                entity.Property(e => e.ExcDescripcion)
                    .IsRequired()
                    .HasColumnName("excDescripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AsisHorario>(entity =>
            {
                entity.HasKey(e => e.HorId);

                entity.ToTable("asisHorario");

                entity.Property(e => e.HorId).HasColumnName("horId");

                entity.Property(e => e.HorDDosEntrada).HasColumnName("horD_DosEntrada");

                entity.Property(e => e.HorDDosHoras).HasColumnName("horD_DosHoras");

                entity.Property(e => e.HorDTresEntrada).HasColumnName("horD_TresEntrada");

                entity.Property(e => e.HorDTresHoras).HasColumnName("horD_TresHoras");

                entity.Property(e => e.HorDUnoEntrada).HasColumnName("horD_UnoEntrada");

                entity.Property(e => e.HorDUnoHoras).HasColumnName("horD_UnoHoras");

                entity.Property(e => e.HorDescripcion)
                    .IsRequired()
                    .HasColumnName("horDescripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.HorEDosEntrada).HasColumnName("horE_DosEntrada");

                entity.Property(e => e.HorEDosHoras).HasColumnName("horE_DosHoras");

                entity.Property(e => e.HorETresEntrada).HasColumnName("horE_TresEntrada");

                entity.Property(e => e.HorETresHoras).HasColumnName("horE_TresHoras");

                entity.Property(e => e.HorEUnoEntrada).HasColumnName("horE_UnoEntrada");

                entity.Property(e => e.HorEUnoHoras).HasColumnName("horE_UnoHoras");

                entity.Property(e => e.HorJDosEntrada).HasColumnName("horJ_DosEntrada");

                entity.Property(e => e.HorJDosHoras).HasColumnName("horJ_DosHoras");

                entity.Property(e => e.HorJTresEntrada).HasColumnName("horJ_TresEntrada");

                entity.Property(e => e.HorJTresHoras).HasColumnName("horJ_TresHoras");

                entity.Property(e => e.HorJUnoEntrada).HasColumnName("horJ_UnoEntrada");

                entity.Property(e => e.HorJUnoHoras).HasColumnName("horJ_UnoHoras");

                entity.Property(e => e.HorLDosEntrada).HasColumnName("horL_DosEntrada");

                entity.Property(e => e.HorLDosHoras).HasColumnName("horL_DosHoras");

                entity.Property(e => e.HorLTresEntrada).HasColumnName("horL_TresEntrada");

                entity.Property(e => e.HorLTresHoras).HasColumnName("horL_TresHoras");

                entity.Property(e => e.HorLUnoEntrada).HasColumnName("horL_UnoEntrada");

                entity.Property(e => e.HorLUnoHoras).HasColumnName("horL_UnoHoras");

                entity.Property(e => e.HorMDosEntrada).HasColumnName("horM_DosEntrada");

                entity.Property(e => e.HorMDosHoras).HasColumnName("horM_DosHoras");

                entity.Property(e => e.HorMTresEntrada).HasColumnName("horM_TresEntrada");

                entity.Property(e => e.HorMTresHoras).HasColumnName("horM_TresHoras");

                entity.Property(e => e.HorMUnoEntrada).HasColumnName("horM_UnoEntrada");

                entity.Property(e => e.HorMUnoHoras).HasColumnName("horM_UnoHoras");

                entity.Property(e => e.HorRetardo).HasColumnName("horRetardo");

                entity.Property(e => e.HorSDosEntrada).HasColumnName("horS_DosEntrada");

                entity.Property(e => e.HorSDosHoras).HasColumnName("horS_DosHoras");

                entity.Property(e => e.HorSTresEntrada).HasColumnName("horS_TresEntrada");

                entity.Property(e => e.HorSTresHoras).HasColumnName("horS_TresHoras");

                entity.Property(e => e.HorSUnoEntrada).HasColumnName("horS_UnoEntrada");

                entity.Property(e => e.HorSUnoHoras).HasColumnName("horS_UnoHoras");

                entity.Property(e => e.HorVDosEntrada).HasColumnName("horV_DosEntrada");

                entity.Property(e => e.HorVDosHoras).HasColumnName("horV_DosHoras");

                entity.Property(e => e.HorVTresEntrada).HasColumnName("horV_TresEntrada");

                entity.Property(e => e.HorVTresHoras).HasColumnName("horV_TresHoras");

                entity.Property(e => e.HorVUnoEntrada).HasColumnName("horV_UnoEntrada");

                entity.Property(e => e.HorVUnoHoras).HasColumnName("horV_UnoHoras");

                entity.Property(e => e.TieId).HasColumnName("tieId");

                entity.HasOne(d => d.Tie)
                    .WithMany(p => p.AsisHorario)
                    .HasForeignKey(d => d.TieId)
                    .HasConstraintName("FK_asisHorario_tiendas");
            });

            modelBuilder.Entity<AsisPuesto>(entity =>
            {
                entity.HasKey(e => e.PueId);

                entity.ToTable("asisPuesto");

                entity.Property(e => e.PueId).HasColumnName("pueId");

                entity.Property(e => e.PueDescripcion)
                    .IsRequired()
                    .HasColumnName("pueDescripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AsisRoles>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.ToTable("asisRoles");

                entity.Property(e => e.RolId).HasColumnName("rolId");

                entity.Property(e => e.HorId).HasColumnName("horId");

                entity.Property(e => e.RolActual).HasColumnName("rolActual");

                entity.Property(e => e.RolContador).HasColumnName("rolContador");

                entity.Property(e => e.UsuId).HasColumnName("usuId");

                entity.HasOne(d => d.Hor)
                    .WithMany(p => p.AsisRoles)
                    .HasForeignKey(d => d.HorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asisRoles_asisHorario");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.AsisRoles)
                    .HasForeignKey(d => d.UsuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asisRoles_usuarios");
            });

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.BitId);

                entity.ToTable("bitacora");

                entity.Property(e => e.BitId).HasColumnName("bitId");

                entity.Property(e => e.BitAccion).HasColumnName("bitAccion");

                entity.Property(e => e.BitFecha)
                    .HasColumnName("bitFecha")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BitReferencia)
                    .HasColumnName("bitReferencia")
                    .HasMaxLength(50);

                entity.Property(e => e.ModId).HasColumnName("modId");

                entity.Property(e => e.UsuId).HasColumnName("usuId");

                entity.HasOne(d => d.Mod)
                    .WithMany(p => p.Bitacora)
                    .HasForeignKey(d => d.ModId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bitacora_modulos");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Bitacora)
                    .HasForeignKey(d => d.UsuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bitacora_usuarios");
            });

            modelBuilder.Entity<Catalogos>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.ToTable("catalogos");

                entity.Property(e => e.CatId).HasColumnName("catId");

                entity.Property(e => e.CarDescripcion)
                    .IsRequired()
                    .HasColumnName("carDescripcion")
                    .HasMaxLength(250);

                entity.Property(e => e.CarTipo)
                    .IsRequired()
                    .HasColumnName("carTipo")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Cfdis>(entity =>
            {
                entity.HasKey(e => e.CfdId);

                entity.ToTable("cfdis");

                entity.Property(e => e.CfdId).HasColumnName("cfdId");

                entity.Property(e => e.CfdArticulos).HasColumnName("cfdArticulos");

                entity.Property(e => e.CfdCancelada).HasColumnName("cfdCancelada");

                entity.Property(e => e.CfdDescuento)
                    .HasColumnName("cfdDescuento")
                    .HasColumnType("money");

                entity.Property(e => e.CfdFechaAplicacion)
                    .HasColumnName("cfdFechaAplicacion")
                    .HasColumnType("datetime");

                entity.Property(e => e.CfdFechaCaptura)
                    .HasColumnName("cfdFechaCaptura")
                    .HasColumnType("datetime");

                entity.Property(e => e.CfdFechaVencimiento)
                    .HasColumnName("cfdFechaVencimiento")
                    .HasColumnType("date");

                entity.Property(e => e.CfdFolio)
                    .IsRequired()
                    .HasColumnName("cfdFolio")
                    .HasMaxLength(10);

                entity.Property(e => e.CfdImporte)
                    .HasColumnName("cfdImporte")
                    .HasColumnType("money");

                entity.Property(e => e.CfdImpuesto).HasColumnName("cfdImpuesto");

                entity.Property(e => e.CfdMotivoCancelada)
                    .IsRequired()
                    .HasColumnName("cfdMotivoCancelada")
                    .HasMaxLength(50);

                entity.Property(e => e.CfdReferencia)
                    .IsRequired()
                    .HasColumnName("cfdReferencia")
                    .HasMaxLength(20);

                entity.Property(e => e.CfdSerie)
                    .IsRequired()
                    .HasColumnName("cfdSerie")
                    .HasMaxLength(10);

                entity.Property(e => e.CfdTipoComprobante).HasColumnName("cfdTipoComprobante");

                entity.Property(e => e.CfdTipoDocumento).HasColumnName("cfdTipoDocumento");

                entity.Property(e => e.CfdUuid)
                    .IsRequired()
                    .HasColumnName("cfdUuid")
                    .HasMaxLength(36);

                entity.Property(e => e.CliId).HasColumnName("cliId");

                entity.Property(e => e.CxcId).HasColumnName("cxcId");

                entity.Property(e => e.UsuId).HasColumnName("usuId");

                entity.HasOne(d => d.Cli)
                    .WithMany(p => p.Cfdis)
                    .HasForeignKey(d => d.CliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cfdis_clientes");

                entity.HasOne(d => d.Cxc)
                    .WithMany(p => p.Cfdis)
                    .HasForeignKey(d => d.CxcId)
                    .HasConstraintName("FK_cfdis_cuentasxCobrar");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Cfdis)
                    .HasForeignKey(d => d.UsuId)
                    .HasConstraintName("FK_cfdis_usuarios");
            });

            modelBuilder.Entity<CfdisDetalle>(entity =>
            {
                entity.HasKey(e => e.CdeId);

                entity.ToTable("cfdisDetalle");

                entity.Property(e => e.CdeId).HasColumnName("cdeId");

                entity.Property(e => e.CdeCantidad).HasColumnName("cdeCantidad");

                entity.Property(e => e.CdeDescripcion)
                    .IsRequired()
                    .HasColumnName("cdeDescripcion")
                    .HasMaxLength(350);

                entity.Property(e => e.CdePrecio)
                    .HasColumnName("cdePrecio")
                    .HasColumnType("money");

                entity.Property(e => e.CdeTallas)
                    .IsRequired()
                    .HasColumnName("cdeTallas")
                    .HasMaxLength(350);

                entity.Property(e => e.CfdId).HasColumnName("cfdId");

                entity.HasOne(d => d.Cfd)
                    .WithMany(p => p.CfdisDetalle)
                    .HasForeignKey(d => d.CfdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cfdisDetalle_cfdis");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.CliId);

                entity.ToTable("clientes");

                entity.Property(e => e.CliId).HasColumnName("cliId");

                entity.Property(e => e.CliAutorizado)
                    .IsRequired()
                    .HasColumnName("cliAutorizado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CliAutorizarPedidos)
                    .IsRequired()
                    .HasColumnName("cliAutorizarPedidos")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CliCalle)
                    .IsRequired()
                    .HasColumnName("cliCalle")
                    .HasMaxLength(150);

                entity.Property(e => e.CliClienteInterno).HasColumnName("cliClienteInterno");

                entity.Property(e => e.CliCodigoPostal)
                    .IsRequired()
                    .HasColumnName("cliCodigoPostal")
                    .HasMaxLength(5);

                entity.Property(e => e.CliColonia)
                    .IsRequired()
                    .HasColumnName("cliColonia")
                    .HasMaxLength(150);

                entity.Property(e => e.CliCondiciones)
                    .IsRequired()
                    .HasColumnName("cliCondiciones")
                    .HasMaxLength(50);

                entity.Property(e => e.CliContactoPagos)
                    .IsRequired()
                    .HasColumnName("cliContactoPagos")
                    .HasMaxLength(50);

                entity.Property(e => e.CliCpExport)
                    .IsRequired()
                    .HasColumnName("cliCpExport")
                    .HasMaxLength(50);

                entity.Property(e => e.CliCuentaConcentradora)
                    .IsRequired()
                    .HasColumnName("cliCuentaConcentradora")
                    .HasMaxLength(50);

                entity.Property(e => e.CliCuentaContable)
                    .IsRequired()
                    .HasColumnName("cliCuentaContable")
                    .HasMaxLength(50);

                entity.Property(e => e.CliCuentaContableReal)
                    .IsRequired()
                    .HasColumnName("cliCuentaContableReal")
                    .HasMaxLength(50);

                entity.Property(e => e.CliDescuento).HasColumnName("cliDescuento");

                entity.Property(e => e.CliDiasCredito).HasColumnName("cliDiasCredito");

                entity.Property(e => e.CliEmail)
                    .IsRequired()
                    .HasColumnName("cliEmail")
                    .HasMaxLength(100);

                entity.Property(e => e.CliEstadoExport)
                    .IsRequired()
                    .HasColumnName("cliEstadoExport")
                    .HasMaxLength(50);

                entity.Property(e => e.CliExtranjero).HasColumnName("cliExtranjero");

                entity.Property(e => e.CliFlete)
                    .IsRequired()
                    .HasColumnName("cliFlete")
                    .HasMaxLength(50);

                entity.Property(e => e.CliFormaPago)
                    .IsRequired()
                    .HasColumnName("cliFormaPago")
                    .HasMaxLength(50);

                entity.Property(e => e.CliGrupo)
                    .IsRequired()
                    .HasColumnName("cliGrupo")
                    .HasMaxLength(50);

                entity.Property(e => e.CliLimiteCredito)
                    .HasColumnName("cliLimiteCredito")
                    .HasColumnType("money");

                entity.Property(e => e.CliMetodoPago)
                    .IsRequired()
                    .HasColumnName("cliMetodoPago")
                    .HasMaxLength(50);

                entity.Property(e => e.CliNombre)
                    .IsRequired()
                    .HasColumnName("cliNombre")
                    .HasMaxLength(250);

                entity.Property(e => e.CliNumExterior)
                    .IsRequired()
                    .HasColumnName("cliNumExterior")
                    .HasMaxLength(50);

                entity.Property(e => e.CliNumInterior)
                    .IsRequired()
                    .HasColumnName("cliNumInterior")
                    .HasMaxLength(50);

                entity.Property(e => e.CliNumRegIdTrib)
                    .IsRequired()
                    .HasColumnName("cliNumRegIdTrib")
                    .HasMaxLength(40);

                entity.Property(e => e.CliNumeroCuenta)
                    .IsRequired()
                    .HasColumnName("cliNumeroCuenta")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('0000')");

                entity.Property(e => e.CliPais)
                    .IsRequired()
                    .HasColumnName("cliPais")
                    .HasMaxLength(50);

                entity.Property(e => e.CliPoblacion)
                    .IsRequired()
                    .HasColumnName("cliPoblacion")
                    .HasMaxLength(150);

                entity.Property(e => e.CliRfc)
                    .IsRequired()
                    .HasColumnName("cliRfc")
                    .HasMaxLength(15);

                entity.Property(e => e.CliSatNomBancoOrd)
                    .IsRequired()
                    .HasColumnName("cliSatNomBancoOrd")
                    .HasMaxLength(200);

                entity.Property(e => e.CliStatus).HasColumnName("cliStatus");

                entity.Property(e => e.CliTabulador).HasColumnName("cliTabulador");

                entity.Property(e => e.CliTelefonos)
                    .IsRequired()
                    .HasColumnName("cliTelefonos")
                    .HasMaxLength(50);

                entity.Property(e => e.CliTipoCliente).HasColumnName("cliTipoCliente");

                entity.Property(e => e.CliTransporte)
                    .IsRequired()
                    .HasColumnName("cliTransporte")
                    .HasMaxLength(50);

                entity.Property(e => e.CliUsoCfdi)
                    .IsRequired()
                    .HasColumnName("cliUsoCfdi")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("(N'G01')");

                entity.Property(e => e.EstId).HasColumnName("estId");

                entity.HasOne(d => d.Est)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.EstId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_clientes_estados");
            });

            modelBuilder.Entity<Comped>(entity =>
            {
                entity.HasKey(e => e.ComId);

                entity.ToTable("comped");

                entity.Property(e => e.ComId).HasColumnName("comId");

                entity.Property(e => e.CliId).HasColumnName("cliId");

                entity.Property(e => e.ComArticulos).HasColumnName("comArticulos");

                entity.Property(e => e.ComCondiciones)
                    .IsRequired()
                    .HasColumnName("comCondiciones")
                    .HasMaxLength(150);

                entity.Property(e => e.ComEsCompra).HasColumnName("comEsCompra");

                entity.Property(e => e.ComEstatus).HasColumnName("comEstatus");

                entity.Property(e => e.ComFechaCancelada)
                    .HasColumnName("comFechaCancelada")
                    .HasColumnType("datetime");

                entity.Property(e => e.ComFechaCaptura)
                    .HasColumnName("comFechaCaptura")
                    .HasColumnType("datetime");

                entity.Property(e => e.ComFechaEntrega)
                    .HasColumnName("comFechaEntrega")
                    .HasColumnType("datetime");

                entity.Property(e => e.ComImporte)
                    .HasColumnName("comImporte")
                    .HasColumnType("money");

                entity.Property(e => e.ComMarca)
                    .IsRequired()
                    .HasColumnName("comMarca")
                    .HasMaxLength(50);

                entity.Property(e => e.ComMotivoCancelada)
                    .HasColumnName("comMotivoCancelada")
                    .HasMaxLength(50);

                entity.Property(e => e.ComObservaciones)
                    .IsRequired()
                    .HasColumnName("comObservaciones")
                    .HasMaxLength(150);

                entity.Property(e => e.ComReferencia)
                    .IsRequired()
                    .HasColumnName("comReferencia")
                    .HasMaxLength(15);

                entity.Property(e => e.ComSuspendido).HasColumnName("comSuspendido");

                entity.Property(e => e.ComTipo).HasColumnName("comTipo");

                entity.Property(e => e.PrvId).HasColumnName("prvId");

                entity.Property(e => e.UsuIdCancelo).HasColumnName("usuIdCancelo");

                entity.Property(e => e.UsuIdCapturo).HasColumnName("usuIdCapturo");

                entity.HasOne(d => d.Cli)
                    .WithMany(p => p.Comped)
                    .HasForeignKey(d => d.CliId)
                    .HasConstraintName("FK_comped_clientes");

                entity.HasOne(d => d.Prv)
                    .WithMany(p => p.Comped)
                    .HasForeignKey(d => d.PrvId)
                    .HasConstraintName("FK_compras_proveedores");

                entity.HasOne(d => d.UsuIdCanceloNavigation)
                    .WithMany(p => p.CompedUsuIdCanceloNavigation)
                    .HasForeignKey(d => d.UsuIdCancelo)
                    .HasConstraintName("FK_compras_usuariosCancelo");

                entity.HasOne(d => d.UsuIdCapturoNavigation)
                    .WithMany(p => p.CompedUsuIdCapturoNavigation)
                    .HasForeignKey(d => d.UsuIdCapturo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_compras_usuariosCapturo");
            });

            modelBuilder.Entity<CompedDetalle>(entity =>
            {
                entity.HasKey(e => e.CdeId);

                entity.ToTable("compedDetalle");

                entity.Property(e => e.CdeId).HasColumnName("cdeId");

                entity.Property(e => e.CdeCantidad).HasColumnName("cdeCantidad");

                entity.Property(e => e.CdeCorrida)
                    .IsRequired()
                    .HasColumnName("cdeCorrida")
                    .HasMaxLength(400);

                entity.Property(e => e.CdeCorridaOriginal)
                    .IsRequired()
                    .HasColumnName("cdeCorridaOriginal")
                    .HasMaxLength(400);

                entity.Property(e => e.CdePrecio)
                    .HasColumnName("cdePrecio")
                    .HasColumnType("money");

                entity.Property(e => e.ComId).HasColumnName("comId");

                entity.Property(e => e.ProId).HasColumnName("proId");

                entity.HasOne(d => d.Com)
                    .WithMany(p => p.CompedDetalle)
                    .HasForeignKey(d => d.ComId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_compedDetalle_comped");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.CompedDetalle)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_compedDetalle_productos");
            });

            modelBuilder.Entity<CuentasContables>(entity =>
            {
                entity.HasKey(e => e.CcoId);

                entity.ToTable("cuentasContables");

                entity.Property(e => e.CcoId).HasColumnName("ccoId");

                entity.Property(e => e.CcoCuenta)
                    .IsRequired()
                    .HasColumnName("ccoCuenta")
                    .HasMaxLength(30);

                entity.Property(e => e.CcoDescripcion)
                    .IsRequired()
                    .HasColumnName("ccoDescripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.CcoTipoCuenta).HasColumnName("ccoTipoCuenta");
            });

            modelBuilder.Entity<CuentasxCobrar>(entity =>
            {
                entity.HasKey(e => e.CxcId);

                entity.ToTable("cuentasxCobrar");

                entity.Property(e => e.CxcId).HasColumnName("cxcId");

                entity.Property(e => e.CcaPagado)
                    .HasColumnName("ccaPagado")
                    .HasDefaultValueSql("('false')");

                entity.Property(e => e.CctId).HasColumnName("cctId");

                entity.Property(e => e.CliId).HasColumnName("cliId");

                entity.Property(e => e.CxcCancelada).HasColumnName("cxcCancelada");

                entity.Property(e => e.CxcComentarios)
                    .IsRequired()
                    .HasColumnName("cxcComentarios")
                    .HasMaxLength(100);

                entity.Property(e => e.CxcDocumento)
                    .IsRequired()
                    .HasColumnName("cxcDocumento")
                    .HasMaxLength(50);

                entity.Property(e => e.CxcFecha)
                    .HasColumnName("cxcFecha")
                    .HasColumnType("date");

                entity.Property(e => e.CxcFechaVencimiento)
                    .HasColumnName("cxcFechaVencimiento")
                    .HasColumnType("date");

                entity.Property(e => e.CxcImporte)
                    .HasColumnName("cxcImporte")
                    .HasColumnType("money");

                entity.Property(e => e.CxcImprocedente).HasColumnName("cxcImprocedente");

                entity.Property(e => e.CxcImpuesto).HasColumnName("cxcImpuesto");

                entity.Property(e => e.CxcMotivoCancelacion)
                    .IsRequired()
                    .HasColumnName("cxcMotivoCancelacion")
                    .HasMaxLength(50);

                entity.Property(e => e.CxcPares).HasColumnName("cxcPares");

                entity.Property(e => e.CxcPo)
                    .IsRequired()
                    .HasColumnName("cxcPO")
                    .HasMaxLength(20);

                entity.Property(e => e.CxcReferencia)
                    .IsRequired()
                    .HasColumnName("cxcReferencia")
                    .HasMaxLength(20);

                entity.Property(e => e.CxcSaldo)
                    .HasColumnName("cxcSaldo")
                    .HasColumnType("money");

                entity.Property(e => e.CxcTipo).HasColumnName("cxcTipo");

                entity.Property(e => e.CxcTipoDocumento).HasColumnName("cxcTipoDocumento");

                entity.Property(e => e.CxcTipoPoliza).HasColumnName("cxcTipoPoliza");

                entity.Property(e => e.CxcUuid)
                    .HasColumnName("cxcUuid")
                    .HasMaxLength(36);

                entity.Property(e => e.UsuId).HasColumnName("usuId");

                entity.HasOne(d => d.Cct)
                    .WithMany(p => p.CuentasxCobrar)
                    .HasForeignKey(d => d.CctId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cuentasxCobrar_cuentasxCobrarTipos");

                entity.HasOne(d => d.Cli)
                    .WithMany(p => p.CuentasxCobrar)
                    .HasForeignKey(d => d.CliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cuentasxCobrar_clientes");
            });

            modelBuilder.Entity<CuentasxCobrarAplicacion>(entity =>
            {
                entity.HasKey(e => e.CcaId);

                entity.ToTable("cuentasxCobrarAplicacion");

                entity.Property(e => e.CcaId).HasColumnName("ccaId");

                entity.Property(e => e.CcaFecha)
                    .HasColumnName("ccaFecha")
                    .HasColumnType("date");

                entity.Property(e => e.CcaFechaPago)
                    .HasColumnName("ccaFechaPago")
                    .HasColumnType("date");

                entity.Property(e => e.CcaImporte)
                    .HasColumnName("ccaImporte")
                    .HasColumnType("money");

                entity.Property(e => e.CcaPagado).HasColumnName("ccaPagado");

                entity.Property(e => e.CcoId).HasColumnName("ccoId");

                entity.Property(e => e.CxcIdDestino).HasColumnName("cxcIdDestino");

                entity.Property(e => e.CxcIdOrigen).HasColumnName("cxcIdOrigen");

                entity.HasOne(d => d.CxcIdDestinoNavigation)
                    .WithMany(p => p.CuentasxCobrarAplicacionCxcIdDestinoNavigation)
                    .HasForeignKey(d => d.CxcIdDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cuentasxCobrarAplicacion_cuentasxCobrar1");

                entity.HasOne(d => d.CxcIdOrigenNavigation)
                    .WithMany(p => p.CuentasxCobrarAplicacionCxcIdOrigenNavigation)
                    .HasForeignKey(d => d.CxcIdOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cuentasxCobrarAplicacion_cuentasxCobrar");
            });

            modelBuilder.Entity<CuentasxCobrarTipos>(entity =>
            {
                entity.HasKey(e => e.CctId);

                entity.ToTable("cuentasxCobrarTipos");

                entity.Property(e => e.CctId).HasColumnName("cctId");

                entity.Property(e => e.CcoId).HasColumnName("ccoId");

                entity.Property(e => e.CctCarga).HasColumnName("cctCarga");

                entity.Property(e => e.CctControlImprocedentes).HasColumnName("cctControlImprocedentes");

                entity.Property(e => e.CctDescripcion)
                    .IsRequired()
                    .HasColumnName("cctDescripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.CctGenera).HasColumnName("cctGenera");

                entity.Property(e => e.CctReferenciado).HasColumnName("cctReferenciado");

                entity.HasOne(d => d.Cco)
                    .WithMany(p => p.CuentasxCobrarTipos)
                    .HasForeignKey(d => d.CcoId)
                    .HasConstraintName("FK_cuentasxCobrarTipos_cuentasContables");
            });

            modelBuilder.Entity<CuentasxPagar>(entity =>
            {
                entity.HasKey(e => e.CxpId);

                entity.ToTable("cuentasxPagar");

                entity.Property(e => e.CxpId).HasColumnName("cxpId");

                entity.Property(e => e.CptId).HasColumnName("cptId");

                entity.Property(e => e.CxpArticulos).HasColumnName("cxpArticulos");

                entity.Property(e => e.CxpDescuentos).HasColumnName("cxpDescuentos");

                entity.Property(e => e.CxpDevolucionProveedor)
                    .IsRequired()
                    .HasColumnName("cxpDevolucionProveedor")
                    .HasMaxLength(50);

                entity.Property(e => e.CxpEstatus).HasColumnName("cxpEstatus");

                entity.Property(e => e.CxpFechaAplicacion)
                    .HasColumnName("cxpFechaAplicacion")
                    .HasColumnType("date");

                entity.Property(e => e.CxpFechaCaptura)
                    .HasColumnName("cxpFechaCaptura")
                    .HasColumnType("date");

                entity.Property(e => e.CxpFechaVencimiento)
                    .HasColumnName("cxpFechaVencimiento")
                    .HasColumnType("date");

                entity.Property(e => e.CxpImporte)
                    .HasColumnName("cxpImporte")
                    .HasColumnType("money");

                entity.Property(e => e.CxpImpuesto).HasColumnName("cxpImpuesto");

                entity.Property(e => e.CxpReferencia)
                    .IsRequired()
                    .HasColumnName("cxpReferencia")
                    .HasMaxLength(50);

                entity.Property(e => e.CxpSaldo)
                    .HasColumnName("cxpSaldo")
                    .HasColumnType("money");

                entity.Property(e => e.CxpTipoDocumento).HasColumnName("cxpTipoDocumento");

                entity.Property(e => e.CxpUuid)
                    .HasColumnName("cxpUuid")
                    .HasMaxLength(36);

                entity.Property(e => e.MovId).HasColumnName("movId");

                entity.Property(e => e.NenId).HasColumnName("nenId");

                entity.Property(e => e.PrvId).HasColumnName("prvId");

                entity.HasOne(d => d.Cpt)
                    .WithMany(p => p.CuentasxPagar)
                    .HasForeignKey(d => d.CptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cuentasxPagar_cuentasxPagarTipos");

                entity.HasOne(d => d.Mov)
                    .WithMany(p => p.CuentasxPagar)
                    .HasForeignKey(d => d.MovId)
                    .HasConstraintName("FK_cuentasxPagar_movimientos");

                entity.HasOne(d => d.Prv)
                    .WithMany(p => p.CuentasxPagar)
                    .HasForeignKey(d => d.PrvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cuentasxPagar_proveedores");
            });

            modelBuilder.Entity<CuentasxPagarAplicacion>(entity =>
            {
                entity.HasKey(e => e.CpaId);

                entity.ToTable("cuentasxPagarAplicacion");

                entity.Property(e => e.CpaId).HasColumnName("cpaId");

                entity.Property(e => e.CcoId).HasColumnName("ccoId");

                entity.Property(e => e.CpaFecha)
                    .HasColumnName("cpaFecha")
                    .HasColumnType("date");

                entity.Property(e => e.CpaImporte)
                    .HasColumnName("cpaImporte")
                    .HasColumnType("money");

                entity.Property(e => e.CxpIdDestino).HasColumnName("cxpIdDestino");

                entity.Property(e => e.CxpIdOrigen).HasColumnName("cxpIdOrigen");

                entity.HasOne(d => d.Cco)
                    .WithMany(p => p.CuentasxPagarAplicacion)
                    .HasForeignKey(d => d.CcoId)
                    .HasConstraintName("FK_cuentasxPagarAplicacion_cuentasContables");

                entity.HasOne(d => d.CxpIdDestinoNavigation)
                    .WithMany(p => p.CuentasxPagarAplicacionCxpIdDestinoNavigation)
                    .HasForeignKey(d => d.CxpIdDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cuentasxPagarAplicacion_cuentasxPagarDestino");

                entity.HasOne(d => d.CxpIdOrigenNavigation)
                    .WithMany(p => p.CuentasxPagarAplicacionCxpIdOrigenNavigation)
                    .HasForeignKey(d => d.CxpIdOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cuentasxPagarAplicacion_cuentasxPagarOrigen");
            });

            modelBuilder.Entity<CuentasxPagarTipos>(entity =>
            {
                entity.HasKey(e => e.CptId);

                entity.ToTable("cuentasxPagarTipos");

                entity.Property(e => e.CptId).HasColumnName("cptId");

                entity.Property(e => e.CptCarga).HasColumnName("cptCarga");

                entity.Property(e => e.CptDescripcion)
                    .IsRequired()
                    .HasColumnName("cptDescripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.CptReferenciado).HasColumnName("cptReferenciado");
            });

            modelBuilder.Entity<DiarioCaja>(entity =>
            {
                entity.HasKey(e => e.DcaId);

                entity.ToTable("diarioCaja");

                entity.Property(e => e.DcaId).HasColumnName("dcaId");

                entity.Property(e => e.CajId).HasColumnName("cajId");

                entity.Property(e => e.DcaFechaHora)
                    .HasColumnName("dcaFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.DcaFondo)
                    .HasColumnName("dcaFondo")
                    .HasColumnType("money");

                entity.Property(e => e.UsuId).HasColumnName("usuId");

                entity.HasOne(d => d.Caj)
                    .WithMany(p => p.DiarioCaja)
                    .HasForeignKey(d => d.CajId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_diarioCaja_tiendaCajas");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.DiarioCaja)
                    .HasForeignKey(d => d.UsuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_diarioCaja_usuarios");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.HasKey(e => e.EstId);

                entity.ToTable("estados");

                entity.Property(e => e.EstId)
                    .HasColumnName("estId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EstNombre)
                    .IsRequired()
                    .HasColumnName("estNombre")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Folios>(entity =>
            {
                entity.HasKey(e => e.FolId);

                entity.ToTable("folios");

                entity.Property(e => e.FolId).HasColumnName("folId");

                entity.Property(e => e.FolFolioActual).HasColumnName("folFolioActual");

                entity.Property(e => e.FolSerie)
                    .IsRequired()
                    .HasColumnName("folSerie")
                    .HasMaxLength(10);

                entity.Property(e => e.FolTipo).HasColumnName("folTipo");

                entity.Property(e => e.TieId).HasColumnName("tieId");

                entity.HasOne(d => d.Tie)
                    .WithMany(p => p.Folios)
                    .HasForeignKey(d => d.TieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_folios_tiendas");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.InvId);

                entity.ToTable("inventario");

                entity.Property(e => e.InvId).HasColumnName("invId");

                entity.Property(e => e.InvFecha)
                    .HasColumnName("invFecha")
                    .HasColumnType("date");

                entity.Property(e => e.InvTallas)
                    .IsRequired()
                    .HasColumnName("invTallas")
                    .HasMaxLength(250);

                entity.Property(e => e.ProId).HasColumnName("proId");

                entity.Property(e => e.TieId).HasColumnName("tieId");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_inventario_productos");

                entity.HasOne(d => d.Tie)
                    .WithMany(p => p.Inventario)
                    .HasForeignKey(d => d.TieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_inventario_tiendas");
            });

            modelBuilder.Entity<Modulos>(entity =>
            {
                entity.HasKey(e => e.ModId);

                entity.ToTable("modulos");

                entity.Property(e => e.ModId)
                    .HasColumnName("modId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ModForma).HasColumnName("modForma");

                entity.Property(e => e.ModNombre)
                    .IsRequired()
                    .HasColumnName("modNombre")
                    .HasMaxLength(100);

                entity.Property(e => e.ModPadre).HasColumnName("modPadre");
            });

            modelBuilder.Entity<Monedero>(entity =>
            {
                entity.HasKey(e => e.MonId);

                entity.ToTable("monedero");

                entity.Property(e => e.MonId).HasColumnName("monId");

                entity.Property(e => e.MonFechaHora)
                    .HasColumnName("monFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.MonImporte)
                    .HasColumnName("monImporte")
                    .HasColumnType("money");

                entity.Property(e => e.MonNombre)
                    .IsRequired()
                    .HasColumnName("monNombre")
                    .HasMaxLength(150);

                entity.Property(e => e.MonSaldo)
                    .HasColumnName("monSaldo")
                    .HasColumnType("money");

                entity.Property(e => e.MonTelefono)
                    .IsRequired()
                    .HasColumnName("monTelefono")
                    .HasMaxLength(10);

                entity.Property(e => e.TieId).HasColumnName("tieId");

                entity.HasOne(d => d.Tie)
                    .WithMany(p => p.Monedero)
                    .HasForeignKey(d => d.TieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_monedero_tiendas");
            });

            modelBuilder.Entity<MovimientoDetalle>(entity =>
            {
                entity.HasKey(e => e.MdeId);

                entity.ToTable("movimientoDetalle");

                entity.Property(e => e.MdeId).HasColumnName("mdeId");

                entity.Property(e => e.MdeCantidad).HasColumnName("mdeCantidad");

                entity.Property(e => e.MdeCosto)
                    .HasColumnName("mdeCosto")
                    .HasColumnType("money");

                entity.Property(e => e.MdePrecio)
                    .HasColumnName("mdePrecio")
                    .HasColumnType("money");

                entity.Property(e => e.MdeTallas)
                    .IsRequired()
                    .HasColumnName("mdeTallas")
                    .HasMaxLength(350);

                entity.Property(e => e.MovId).HasColumnName("movId");

                entity.Property(e => e.ProId).HasColumnName("proId");

                entity.HasOne(d => d.Mov)
                    .WithMany(p => p.MovimientoDetalle)
                    .HasForeignKey(d => d.MovId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movimientoDetalle_movimientos");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.MovimientoDetalle)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movimientoDetalle_productos");
            });

            modelBuilder.Entity<Movimientos>(entity =>
            {
                entity.HasKey(e => e.MovId);

                entity.ToTable("movimientos");

                entity.Property(e => e.MovId).HasColumnName("movId");

                entity.Property(e => e.MovAplicado).HasColumnName("movAplicado");

                entity.Property(e => e.MovCancelado).HasColumnName("movCancelado");

                entity.Property(e => e.MovCantidad).HasColumnName("movCantidad");

                entity.Property(e => e.MovFechaAplicado)
                    .HasColumnName("movFechaAplicado")
                    .HasColumnType("datetime");

                entity.Property(e => e.MovFechaCancelado)
                    .HasColumnName("movFechaCancelado")
                    .HasColumnType("datetime");

                entity.Property(e => e.MovFechaHora)
                    .HasColumnName("movFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.MovImporte)
                    .HasColumnName("movImporte")
                    .HasColumnType("money");

                entity.Property(e => e.MovMotivoCancelado)
                    .HasColumnName("movMotivoCancelado")
                    .HasMaxLength(50);

                entity.Property(e => e.MovReferencia)
                    .IsRequired()
                    .HasColumnName("movReferencia")
                    .HasMaxLength(30);

                entity.Property(e => e.MovReferenciaPrv)
                    .IsRequired()
                    .HasColumnName("movReferenciaPrv")
                    .HasMaxLength(15);

                entity.Property(e => e.MovTipoMovto).HasColumnName("movTipoMovto");

                entity.Property(e => e.PrvId).HasColumnName("prvId");

                entity.Property(e => e.TieIdDestino).HasColumnName("tieIdDestino");

                entity.Property(e => e.TieIdOrigen).HasColumnName("tieIdOrigen");

                entity.Property(e => e.UsuIdAplico).HasColumnName("usuIdAplico");

                entity.Property(e => e.UsuIdCancelo).HasColumnName("usuIdCancelo");

                entity.HasOne(d => d.Prv)
                    .WithMany(p => p.Movimientos)
                    .HasForeignKey(d => d.PrvId)
                    .HasConstraintName("FK_movimientos_proveedores");

                entity.HasOne(d => d.TieIdDestinoNavigation)
                    .WithMany(p => p.MovimientosTieIdDestinoNavigation)
                    .HasForeignKey(d => d.TieIdDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movimientos_tieDestino");

                entity.HasOne(d => d.TieIdOrigenNavigation)
                    .WithMany(p => p.MovimientosTieIdOrigenNavigation)
                    .HasForeignKey(d => d.TieIdOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movimientos_tieOrigen");

                entity.HasOne(d => d.UsuIdAplicoNavigation)
                    .WithMany(p => p.MovimientosUsuIdAplicoNavigation)
                    .HasForeignKey(d => d.UsuIdAplico)
                    .HasConstraintName("FK_movimientos_usuAplico");

                entity.HasOne(d => d.UsuIdCanceloNavigation)
                    .WithMany(p => p.MovimientosUsuIdCanceloNavigation)
                    .HasForeignKey(d => d.UsuIdCancelo)
                    .HasConstraintName("FK_movimientos_usuCancelo");
            });

            modelBuilder.Entity<NotaEntradaDetalle>(entity =>
            {
                entity.HasKey(e => e.NedId);

                entity.ToTable("notaEntradaDetalle");

                entity.Property(e => e.NedId).HasColumnName("nedId");

                entity.Property(e => e.CdeId).HasColumnName("cdeId");

                entity.Property(e => e.NedCantidad).HasColumnName("nedCantidad");

                entity.Property(e => e.NedCorrida)
                    .IsRequired()
                    .HasColumnName("nedCorrida")
                    .HasMaxLength(400);

                entity.Property(e => e.NedPrecio)
                    .HasColumnName("nedPrecio")
                    .HasColumnType("money");

                entity.Property(e => e.NenId).HasColumnName("nenId");

                entity.HasOne(d => d.Nen)
                    .WithMany(p => p.NotaEntradaDetalle)
                    .HasForeignKey(d => d.NenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_notaEntradaDetalle_notasEntrada");
            });

            modelBuilder.Entity<NotasEntrada>(entity =>
            {
                entity.HasKey(e => e.NenId);

                entity.ToTable("notasEntrada");

                entity.Property(e => e.NenId).HasColumnName("nenId");

                entity.Property(e => e.CxpId).HasColumnName("cxpId");

                entity.Property(e => e.NenFechaCancelada)
                    .HasColumnName("nenFechaCancelada")
                    .HasColumnType("datetime");

                entity.Property(e => e.NenFechaCaptura)
                    .HasColumnName("nenFechaCaptura")
                    .HasColumnType("datetime");

                entity.Property(e => e.NenImporte)
                    .HasColumnName("nenImporte")
                    .HasColumnType("money");

                entity.Property(e => e.NenMotivoCancelada)
                    .HasColumnName("nenMotivoCancelada")
                    .HasMaxLength(50);

                entity.Property(e => e.NenObservaciones)
                    .IsRequired()
                    .HasColumnName("nenObservaciones")
                    .HasMaxLength(150);

                entity.Property(e => e.NenReferencia)
                    .IsRequired()
                    .HasColumnName("nenReferencia")
                    .HasMaxLength(15);

                entity.Property(e => e.NenTipoDocumento).HasColumnName("nenTipoDocumento");

                entity.Property(e => e.NenTotalArticulo).HasColumnName("nenTotalArticulo");

                entity.Property(e => e.PrvId).HasColumnName("prvId");

                entity.Property(e => e.UsuIdCancelo).HasColumnName("usuIdCancelo");

                entity.Property(e => e.UsuIdCapturo).HasColumnName("usuIdCapturo");

                entity.HasOne(d => d.Cxp)
                    .WithMany(p => p.NotasEntrada)
                    .HasForeignKey(d => d.CxpId)
                    .HasConstraintName("FK_notasEntrada_cuentasxPagar");

                entity.HasOne(d => d.Prv)
                    .WithMany(p => p.NotasEntrada)
                    .HasForeignKey(d => d.PrvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_notasEntrada_proveedores");

                entity.HasOne(d => d.UsuIdCanceloNavigation)
                    .WithMany(p => p.NotasEntradaUsuIdCanceloNavigation)
                    .HasForeignKey(d => d.UsuIdCancelo)
                    .HasConstraintName("FK_notasEntrada_usuariosCancelo");

                entity.HasOne(d => d.UsuIdCapturoNavigation)
                    .WithMany(p => p.NotasEntradaUsuIdCapturoNavigation)
                    .HasForeignKey(d => d.UsuIdCapturo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_notasEntrada_usuariosCapturo");
            });

            modelBuilder.Entity<Perfiles>(entity =>
            {
                entity.HasKey(e => e.PerId);

                entity.ToTable("perfiles");

                entity.Property(e => e.PerId).HasColumnName("perId");

                entity.Property(e => e.PerDescripcion)
                    .IsRequired()
                    .HasColumnName("perDescripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.PerTipo).HasColumnName("perTipo");
            });

            modelBuilder.Entity<PerfilesDetalles>(entity =>
            {
                entity.HasKey(e => e.PdeId);

                entity.ToTable("perfilesDetalles");

                entity.Property(e => e.PdeId).HasColumnName("pdeId");

                entity.Property(e => e.ModId).HasColumnName("modId");

                entity.Property(e => e.PdePermiso).HasColumnName("pdePermiso");

                entity.Property(e => e.PerId).HasColumnName("perId");

                entity.HasOne(d => d.Mod)
                    .WithMany(p => p.PerfilesDetalles)
                    .HasForeignKey(d => d.ModId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_perfilesDetalles_modulos");

                entity.HasOne(d => d.Per)
                    .WithMany(p => p.PerfilesDetalles)
                    .HasForeignKey(d => d.PerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_perfilesDetalles_perfiles");
            });

            modelBuilder.Entity<PreventaDetalle>(entity =>
            {
                entity.HasKey(e => e.PdeId);

                entity.ToTable("preventaDetalle");

                entity.Property(e => e.PdeId).HasColumnName("pdeId");

                entity.Property(e => e.PtiId).HasColumnName("ptiId");

                entity.Property(e => e.PveId).HasColumnName("pveId");

                entity.HasOne(d => d.Pti)
                    .WithMany(p => p.PreventaDetalle)
                    .HasForeignKey(d => d.PtiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_preventaDetalle_productosTiendas");

                entity.HasOne(d => d.Pve)
                    .WithMany(p => p.PreventaDetalle)
                    .HasForeignKey(d => d.PveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_preventaDetalle_preventas");
            });

            modelBuilder.Entity<Preventas>(entity =>
            {
                entity.HasKey(e => e.PveId);

                entity.ToTable("preventas");

                entity.Property(e => e.PveId).HasColumnName("pveId");

                entity.Property(e => e.PveFechaHora)
                    .HasColumnName("pveFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.PveTotalArticulos).HasColumnName("pveTotalArticulos");

                entity.Property(e => e.UsuIdVendedor).HasColumnName("usuIdVendedor");

                entity.HasOne(d => d.UsuIdVendedorNavigation)
                    .WithMany(p => p.Preventas)
                    .HasForeignKey(d => d.UsuIdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_preventas_usuarios");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.ToTable("productos");

                entity.Property(e => e.ProId).HasColumnName("proId");

                entity.Property(e => e.ProActivo).HasColumnName("proActivo");

                entity.Property(e => e.ProColor)
                    .IsRequired()
                    .HasColumnName("proColor")
                    .HasMaxLength(50);

                entity.Property(e => e.ProCorrida)
                    .IsRequired()
                    .HasColumnName("proCorrida")
                    .HasMaxLength(10);

                entity.Property(e => e.ProCosto)
                    .HasColumnName("proCosto")
                    .HasColumnType("money");

                entity.Property(e => e.ProDescripcion)
                    .IsRequired()
                    .HasColumnName("proDescripcion")
                    .HasMaxLength(250);

                entity.Property(e => e.ProEstilo)
                    .IsRequired()
                    .HasColumnName("proEstilo")
                    .HasMaxLength(15);

                entity.Property(e => e.ProEstiloProveedor)
                    .IsRequired()
                    .HasColumnName("proEstiloProveedor")
                    .HasMaxLength(30);

                entity.Property(e => e.ProForro)
                    .IsRequired()
                    .HasColumnName("proForro")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProInventariable)
                    .IsRequired()
                    .HasColumnName("proInventariable")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProLinea)
                    .IsRequired()
                    .HasColumnName("proLinea")
                    .HasMaxLength(30);

                entity.Property(e => e.ProMarca)
                    .IsRequired()
                    .HasColumnName("proMarca")
                    .HasMaxLength(150);

                entity.Property(e => e.ProMaterial)
                    .IsRequired()
                    .HasColumnName("proMaterial")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProPrecio1)
                    .HasColumnName("proPrecio1")
                    .HasColumnType("money");

                entity.Property(e => e.ProPrecio2)
                    .HasColumnName("proPrecio2")
                    .HasColumnType("money");

                entity.Property(e => e.ProPrecio3)
                    .HasColumnName("proPrecio3")
                    .HasColumnType("money");

                entity.Property(e => e.ProPrecio4)
                    .HasColumnName("proPrecio4")
                    .HasColumnType("money");

                entity.Property(e => e.ProPrecioFull)
                    .HasColumnName("proPrecioFull")
                    .HasColumnType("money");

                entity.Property(e => e.ProSatId)
                    .IsRequired()
                    .HasColumnName("proSatId")
                    .HasMaxLength(8)
                    .HasDefaultValueSql("(N'53111600')");

                entity.Property(e => e.ProSatUnidadMedida)
                    .IsRequired()
                    .HasColumnName("proSatUnidadMedida")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("(N'PR')");

                entity.Property(e => e.ProSuela)
                    .IsRequired()
                    .HasColumnName("proSuela")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProTemporada)
                    .IsRequired()
                    .HasColumnName("proTemporada")
                    .HasMaxLength(150);

                entity.Property(e => e.ProTipoProducto).HasColumnName("proTipoProducto");
            });

            modelBuilder.Entity<ProductosTiendas>(entity =>
            {
                entity.HasKey(e => e.PtiId);

                entity.ToTable("productosTiendas");

                entity.Property(e => e.PtiId).HasColumnName("ptiId");

                entity.Property(e => e.ProCodigo)
                    .IsRequired()
                    .HasColumnName("proCodigo")
                    .HasMaxLength(5);

                entity.Property(e => e.ProId).HasColumnName("proId");

                entity.Property(e => e.PtiApartados).HasColumnName("ptiApartados");

                entity.Property(e => e.PtiExistencia).HasColumnName("ptiExistencia");

                entity.Property(e => e.TieId).HasColumnName("tieId");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.ProductosTiendas)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_productosTiendas_productos");

                entity.HasOne(d => d.Tie)
                    .WithMany(p => p.ProductosTiendas)
                    .HasForeignKey(d => d.TieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_productosTiendas_tiendas");
            });

            modelBuilder.Entity<ProductosVector>(entity =>
            {
                entity.HasKey(e => e.PcoId);

                entity.ToTable("productosVector");

                entity.Property(e => e.PcoId).HasColumnName("pcoId");

                entity.Property(e => e.PcoCantidad).HasColumnName("pcoCantidad");

                entity.Property(e => e.PcoIndice).HasColumnName("pcoIndice");

                entity.Property(e => e.PcoValor)
                    .IsRequired()
                    .HasColumnName("pcoValor")
                    .HasMaxLength(15);

                entity.Property(e => e.ProId).HasColumnName("proId");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.ProductosVector)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_productosVector_productos");
            });

            modelBuilder.Entity<Promociones>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.ToTable("promociones");

                entity.Property(e => e.ProId).HasColumnName("proId");

                entity.Property(e => e.ProDescuento)
                    .HasColumnName("proDescuento")
                    .HasColumnType("decimal(4, 2)");

                entity.Property(e => e.ProDomingo).HasColumnName("proDomingo");

                entity.Property(e => e.ProFechaFinal)
                    .HasColumnName("proFechaFinal")
                    .HasColumnType("date");

                entity.Property(e => e.ProFechaInicial)
                    .HasColumnName("proFechaInicial")
                    .HasColumnType("date");

                entity.Property(e => e.ProHoraFinal).HasColumnName("proHoraFinal");

                entity.Property(e => e.ProHoraInicial).HasColumnName("proHoraInicial");

                entity.Property(e => e.ProJueves).HasColumnName("proJueves");

                entity.Property(e => e.ProLunes).HasColumnName("proLunes");

                entity.Property(e => e.ProMartes).HasColumnName("proMartes");

                entity.Property(e => e.ProMiercoles).HasColumnName("proMiercoles");

                entity.Property(e => e.ProSabado).HasColumnName("proSabado");

                entity.Property(e => e.ProTipo).HasColumnName("proTipo");

                entity.Property(e => e.ProViernes).HasColumnName("proViernes");
            });

            modelBuilder.Entity<PromocionLineas>(entity =>
            {
                entity.HasKey(e => e.PliId);

                entity.ToTable("promocionLineas");

                entity.Property(e => e.PliId).HasColumnName("pliId");

                entity.Property(e => e.ProId).HasColumnName("proId");

                entity.Property(e => e.ProLinea)
                    .IsRequired()
                    .HasColumnName("proLinea")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.PromocionLineas)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_promocionLineas_promociones");
            });

            modelBuilder.Entity<PromocionTiendas>(entity =>
            {
                entity.HasKey(e => e.PtiId);

                entity.ToTable("promocionTiendas");

                entity.Property(e => e.PtiId).HasColumnName("ptiId");

                entity.Property(e => e.ProId).HasColumnName("proId");

                entity.Property(e => e.TieId).HasColumnName("tieId");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.PromocionTiendas)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_promocionTiendas_promociones");

                entity.HasOne(d => d.Tie)
                    .WithMany(p => p.PromocionTiendas)
                    .HasForeignKey(d => d.TieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_promocionTiendas_tiendas");
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.HasKey(e => e.PrvId);

                entity.ToTable("proveedores");

                entity.Property(e => e.PrvId).HasColumnName("prvId");

                entity.Property(e => e.EstId).HasColumnName("estId");

                entity.Property(e => e.PrvActivo).HasColumnName("prvActivo");

                entity.Property(e => e.PrvAlias)
                    .IsRequired()
                    .HasColumnName("prvAlias")
                    .HasMaxLength(50);

                entity.Property(e => e.PrvAtencionProveedor)
                    .IsRequired()
                    .HasColumnName("prvAtencionProveedor")
                    .HasMaxLength(50);

                entity.Property(e => e.PrvCalle)
                    .IsRequired()
                    .HasColumnName("prvCalle")
                    .HasMaxLength(150);

                entity.Property(e => e.PrvCodigoPostal)
                    .IsRequired()
                    .HasColumnName("prvCodigoPostal")
                    .HasMaxLength(5);

                entity.Property(e => e.PrvColonia)
                    .IsRequired()
                    .HasColumnName("prvColonia")
                    .HasMaxLength(150);

                entity.Property(e => e.PrvCondiciones)
                    .IsRequired()
                    .HasColumnName("prvCondiciones")
                    .HasMaxLength(100);

                entity.Property(e => e.PrvContacto)
                    .IsRequired()
                    .HasColumnName("prvContacto")
                    .HasMaxLength(50);

                entity.Property(e => e.PrvCuentaContableFiscal)
                    .IsRequired()
                    .HasColumnName("prvCuentaContableFiscal")
                    .HasMaxLength(15);

                entity.Property(e => e.PrvCuentaContableReal)
                    .IsRequired()
                    .HasColumnName("prvCuentaContableReal")
                    .HasMaxLength(15);

                entity.Property(e => e.PrvDiasCredito).HasColumnName("prvDiasCredito");

                entity.Property(e => e.PrvEmail)
                    .IsRequired()
                    .HasColumnName("prvEmail")
                    .HasMaxLength(250);

                entity.Property(e => e.PrvEmailCobranza)
                    .IsRequired()
                    .HasColumnName("prvEmailCobranza")
                    .HasMaxLength(250);

                entity.Property(e => e.PrvGrupo)
                    .IsRequired()
                    .HasColumnName("prvGrupo")
                    .HasMaxLength(50);

                entity.Property(e => e.PrvLimiteCredito)
                    .HasColumnName("prvLimiteCredito")
                    .HasColumnType("money");

                entity.Property(e => e.PrvNombre)
                    .IsRequired()
                    .HasColumnName("prvNombre")
                    .HasMaxLength(150);

                entity.Property(e => e.PrvNumExterior)
                    .IsRequired()
                    .HasColumnName("prvNumExterior")
                    .HasMaxLength(50);

                entity.Property(e => e.PrvNumInterior)
                    .IsRequired()
                    .HasColumnName("prvNumInterior")
                    .HasMaxLength(50);

                entity.Property(e => e.PrvPais)
                    .IsRequired()
                    .HasColumnName("prvPais")
                    .HasMaxLength(50);

                entity.Property(e => e.PrvPoblacion)
                    .IsRequired()
                    .HasColumnName("prvPoblacion")
                    .HasMaxLength(150);

                entity.Property(e => e.PrvRfc)
                    .IsRequired()
                    .HasColumnName("prvRFC")
                    .HasMaxLength(15);

                entity.Property(e => e.PrvTelefono)
                    .IsRequired()
                    .HasColumnName("prvTelefono")
                    .HasMaxLength(50);

                entity.Property(e => e.PrvTipo).HasColumnName("prvTipo");

                entity.HasOne(d => d.Est)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.EstId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_proveedores_estados");
            });

            modelBuilder.Entity<TiendaCajas>(entity =>
            {
                entity.HasKey(e => e.CajId);

                entity.ToTable("tiendaCajas");

                entity.Property(e => e.CajId).HasColumnName("cajId");

                entity.Property(e => e.CajDescripcion)
                    .IsRequired()
                    .HasColumnName("cajDescripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.TieId).HasColumnName("tieId");

                entity.HasOne(d => d.Tie)
                    .WithMany(p => p.TiendaCajas)
                    .HasForeignKey(d => d.TieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tiendaCajas_tiendas");
            });

            modelBuilder.Entity<Tiendas>(entity =>
            {
                entity.HasKey(e => e.TieId);

                entity.ToTable("tiendas");

                entity.Property(e => e.TieId).HasColumnName("tieId");

                entity.Property(e => e.EstId).HasColumnName("estId");

                entity.Property(e => e.TieCalle)
                    .IsRequired()
                    .HasColumnName("tieCalle")
                    .HasMaxLength(300);

                entity.Property(e => e.TieCataColonia)
                    .IsRequired()
                    .HasColumnName("tieCataColonia")
                    .HasMaxLength(10);

                entity.Property(e => e.TieCataEstado)
                    .IsRequired()
                    .HasColumnName("tieCataEstado")
                    .HasMaxLength(10);

                entity.Property(e => e.TieCataMunicipio)
                    .IsRequired()
                    .HasColumnName("tieCataMunicipio")
                    .HasMaxLength(10);

                entity.Property(e => e.TieCertificado).HasColumnName("tieCertificado");

                entity.Property(e => e.TieCodigoPostal)
                    .IsRequired()
                    .HasColumnName("tieCodigoPostal")
                    .HasMaxLength(10);

                entity.Property(e => e.TieColonia)
                    .IsRequired()
                    .HasColumnName("tieColonia")
                    .HasMaxLength(300);

                entity.Property(e => e.TieContraKey)
                    .IsRequired()
                    .HasColumnName("tieContraKey")
                    .HasMaxLength(50);

                entity.Property(e => e.TieContraTimbrado)
                    .IsRequired()
                    .HasColumnName("tieContraTimbrado")
                    .HasMaxLength(50);

                entity.Property(e => e.TieKey).HasColumnName("tieKey");

                entity.Property(e => e.TieMunicipio)
                    .IsRequired()
                    .HasColumnName("tieMunicipio")
                    .HasMaxLength(100);

                entity.Property(e => e.TieNoExterior)
                    .IsRequired()
                    .HasColumnName("tieNoExterior")
                    .HasMaxLength(50);

                entity.Property(e => e.TieNombre)
                    .IsRequired()
                    .HasColumnName("tieNombre")
                    .HasMaxLength(300);

                entity.Property(e => e.TiePais)
                    .IsRequired()
                    .HasColumnName("tiePais")
                    .HasMaxLength(50);

                entity.Property(e => e.TieRegimenFiscal)
                    .IsRequired()
                    .HasColumnName("tieRegimenFiscal")
                    .HasMaxLength(200);

                entity.Property(e => e.TieRfc)
                    .IsRequired()
                    .HasColumnName("tieRFC")
                    .HasMaxLength(50);

                entity.Property(e => e.TieTelefono)
                    .IsRequired()
                    .HasColumnName("tieTelefono")
                    .HasMaxLength(50);

                entity.Property(e => e.TieTipo).HasColumnName("tieTipo");

                entity.Property(e => e.TieUsuarioTimbrado)
                    .IsRequired()
                    .HasColumnName("tieUsuarioTimbrado")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Est)
                    .WithMany(p => p.Tiendas)
                    .HasForeignKey(d => d.EstId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tiendas_estados");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuId);

                entity.ToTable("usuarios");

                entity.Property(e => e.UsuId).HasColumnName("usuId");

                entity.Property(e => e.ClaId).HasColumnName("claId");

                entity.Property(e => e.DepId).HasColumnName("depId");

                entity.Property(e => e.PerId).HasColumnName("perId");

                entity.Property(e => e.PueId).HasColumnName("pueId");

                entity.Property(e => e.TieId).HasColumnName("tieId");

                entity.Property(e => e.UsuActivo).HasColumnName("usuActivo");

                entity.Property(e => e.UsuChecaAsistencia).HasColumnName("usuChecaAsistencia");

                entity.Property(e => e.UsuClaveNomina)
                    .IsRequired()
                    .HasColumnName("usuClaveNomina")
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsuContra)
                    .IsRequired()
                    .HasColumnName("usuContra")
                    .HasMaxLength(50);

                entity.Property(e => e.UsuCurp)
                    .IsRequired()
                    .HasColumnName("usuCurp")
                    .HasMaxLength(18)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsuDireccion)
                    .IsRequired()
                    .HasColumnName("usuDireccion")
                    .HasMaxLength(300);

                entity.Property(e => e.UsuEmail)
                    .IsRequired()
                    .HasColumnName("usuEmail")
                    .HasMaxLength(150);

                entity.Property(e => e.UsuFechaFinal)
                    .HasColumnName("usuFechaFinal")
                    .HasColumnType("date");

                entity.Property(e => e.UsuFechaInicial)
                    .HasColumnName("usuFechaInicial")
                    .HasColumnType("date");

                entity.Property(e => e.UsuFoto)
                    .HasColumnName("usuFoto")
                    .HasColumnType("image");

                entity.Property(e => e.UsuLogin)
                    .IsRequired()
                    .HasColumnName("usuLogin")
                    .HasMaxLength(20);

                entity.Property(e => e.UsuNacimiento)
                    .HasColumnName("usuNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.UsuNombre)
                    .IsRequired()
                    .HasColumnName("usuNombre")
                    .HasMaxLength(200);

                entity.Property(e => e.UsuRfc)
                    .IsRequired()
                    .HasColumnName("usuRfc")
                    .HasMaxLength(13)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsuTelefono)
                    .IsRequired()
                    .HasColumnName("usuTelefono")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Cla)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.ClaId)
                    .HasConstraintName("FK_usuarios_asisClasificacion1");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK_usuarios_asisDepartamento1");

                entity.HasOne(d => d.Per)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuarios_perfiles");

                entity.HasOne(d => d.Pue)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PueId)
                    .HasConstraintName("FK_usuarios_asisPuesto1");

                entity.HasOne(d => d.Tie)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TieId)
                    .HasConstraintName("FK_usuarios_tiendas");
            });

            modelBuilder.Entity<VentaDetalle>(entity =>
            {
                entity.HasKey(e => e.VdeId);

                entity.ToTable("ventaDetalle");

                entity.Property(e => e.VdeId).HasColumnName("vdeId");

                entity.Property(e => e.PtiId).HasColumnName("ptiId");

                entity.Property(e => e.VdeCantidad).HasColumnName("vdeCantidad");

                entity.Property(e => e.VdeDescuento)
                    .HasColumnName("vdeDescuento")
                    .HasColumnType("money");

                entity.Property(e => e.VdePrecio)
                    .HasColumnName("vdePrecio")
                    .HasColumnType("money");

                entity.Property(e => e.VenId).HasColumnName("venId");

                entity.HasOne(d => d.Pti)
                    .WithMany(p => p.VentaDetalle)
                    .HasForeignKey(d => d.PtiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventaDetalle_productosTiendas");

                entity.HasOne(d => d.Ven)
                    .WithMany(p => p.VentaDetalle)
                    .HasForeignKey(d => d.VenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventaDetalle_ventas");
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.HasKey(e => e.VenId);

                entity.ToTable("ventas");

                entity.Property(e => e.VenId).HasColumnName("venId");

                entity.Property(e => e.CajId).HasColumnName("cajId");

                entity.Property(e => e.CliId).HasColumnName("cliId");

                entity.Property(e => e.FacId).HasColumnName("facId");

                entity.Property(e => e.MonId).HasColumnName("monId");

                entity.Property(e => e.TieId).HasColumnName("tieId");

                entity.Property(e => e.UsuIdCajero).HasColumnName("usuIdCajero");

                entity.Property(e => e.UsuIdVendedor).HasColumnName("usuIdVendedor");

                entity.Property(e => e.VenCantidad).HasColumnName("venCantidad");

                entity.Property(e => e.VenDescuento)
                    .HasColumnName("venDescuento")
                    .HasColumnType("money");

                entity.Property(e => e.VenDevolucion)
                    .HasColumnName("venDevolucion")
                    .HasColumnType("money");

                entity.Property(e => e.VenDocumento).HasColumnName("venDocumento");

                entity.Property(e => e.VenEfectivo)
                    .HasColumnName("venEfectivo")
                    .HasColumnType("money");

                entity.Property(e => e.VenEstatus).HasColumnName("venEstatus");

                entity.Property(e => e.VenFechaCaptura)
                    .HasColumnName("venFechaCaptura")
                    .HasColumnType("datetime");

                entity.Property(e => e.VenFechaHora)
                    .HasColumnName("venFechaHora")
                    .HasColumnType("datetime");

                entity.Property(e => e.VenImporte)
                    .HasColumnName("venImporte")
                    .HasColumnType("money");

                entity.Property(e => e.VenMonedero)
                    .HasColumnName("venMonedero")
                    .HasColumnType("money");

                entity.Property(e => e.VenOtros)
                    .HasColumnName("venOtros")
                    .HasColumnType("money");

                entity.Property(e => e.VenTarjetaCredito)
                    .HasColumnName("venTarjetaCredito")
                    .HasColumnType("money");

                entity.Property(e => e.VenTarjetaDebito)
                    .HasColumnName("venTarjetaDebito")
                    .HasColumnType("money");

                entity.Property(e => e.VenTipo).HasColumnName("venTipo");

                entity.HasOne(d => d.Caj)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.CajId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventas_cajas");

                entity.HasOne(d => d.Cli)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.CliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventas_clientes");

                entity.HasOne(d => d.Mon)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.MonId)
                    .HasConstraintName("FK_ventas_monedero");

                entity.HasOne(d => d.Tie)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.TieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventas_tiendas");

                entity.HasOne(d => d.UsuIdCajeroNavigation)
                    .WithMany(p => p.VentasUsuIdCajeroNavigation)
                    .HasForeignKey(d => d.UsuIdCajero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventas_cajero");

                entity.HasOne(d => d.UsuIdVendedorNavigation)
                    .WithMany(p => p.VentasUsuIdVendedorNavigation)
                    .HasForeignKey(d => d.UsuIdVendedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ventas_vendedor");
            });
        }
    }
}
