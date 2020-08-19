namespace Modelo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class baseContext : DbContext
    {
        public baseContext()
            : base("name=baseContext")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DetalleFacturaCompra> DetalleFacturaCompra { get; set; }
        public virtual DbSet<DetalleFacturaVenta> DetalleFacturaVenta { get; set; }
        public virtual DbSet<DetalleReceta> DetalleReceta { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<FacturaCompra> FacturaCompra { get; set; }
        public virtual DbSet<FacturaVenta> FacturaVenta { get; set; }
        public virtual DbSet<Plato> Plato { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Receta> Receta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(e => e.nombreCategoria)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Producto)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.FacturaVenta)
                .WithRequired(e => e.Cliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.FacturaCompra)
                .WithRequired(e => e.Empleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.FacturaVenta)
                .WithRequired(e => e.Empleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FacturaCompra>()
                .HasMany(e => e.DetalleFacturaCompra)
                .WithRequired(e => e.FacturaCompra)
                .HasForeignKey(e => e.idFacturaCompra)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FacturaVenta>()
                .HasMany(e => e.DetalleFacturaVenta)
                .WithOptional(e => e.FacturaVenta)
                .HasForeignKey(e => e.idFacturaVenta);

            modelBuilder.Entity<Plato>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Plato>()
                .Property(e => e.detalle)
                .IsUnicode(false);

            modelBuilder.Entity<Plato>()
                .HasMany(e => e.Receta)
                .WithRequired(e => e.Plato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.DetalleFacturaCompra)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.DetalleReceta)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.ciudad)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .HasMany(e => e.FacturaCompra)
                .WithRequired(e => e.Proveedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Receta>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Receta>()
                .Property(e => e.detalle)
                .IsUnicode(false);

            modelBuilder.Entity<Receta>()
                .HasMany(e => e.DetalleReceta)
                .WithRequired(e => e.Receta)
                .WillCascadeOnDelete(false);
        }
    }
}
