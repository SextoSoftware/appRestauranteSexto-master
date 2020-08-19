namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FacturaCompra")]
    public partial class FacturaCompra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FacturaCompra()
        {
            DetalleFacturaCompra = new HashSet<DetalleFacturaCompra>();
        }

        [Key]
        public int idFactura { get; set; }

        public DateTime? fecha { get; set; }

        public int idEmpleado { get; set; }

        public int idProveedor { get; set; }

        public double? iva { get; set; }

        public double? descuento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFacturaCompra> DetalleFacturaCompra { get; set; }

        public virtual Empleado Empleado { get; set; }

        public virtual Proveedor Proveedor { get; set; }
    }
}
