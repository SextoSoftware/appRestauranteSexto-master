namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            DetalleFacturaCompra = new HashSet<DetalleFacturaCompra>();
            DetalleFacturaVenta = new HashSet<DetalleFacturaVenta>();
            DetalleReceta = new HashSet<DetalleReceta>();
        }

        [Key]
        public int idProducto { get; set; }

        [Required]
        public string nombre { get; set; }

        public int idCategoria { get; set; }

        public double costo { get; set; }

        public double pvp { get; set; }

        public double stock { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFacturaCompra> DetalleFacturaCompra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFacturaVenta> DetalleFacturaVenta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleReceta> DetalleReceta { get; set; }
    }
}
