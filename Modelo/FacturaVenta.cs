namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FacturaVenta")]
    public partial class FacturaVenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FacturaVenta()
        {
            DetalleFacturaVenta = new HashSet<DetalleFacturaVenta>();
        }

        [Key]
        public int idFactura { get; set; }

        public DateTime? fecha { get; set; }

        public int idEmpleado { get; set; }

        public int idCliente { get; set; }

        public double? iva { get; set; }

        public double? descuento { get; set; }

        public virtual Cliente Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFacturaVenta> DetalleFacturaVenta { get; set; }

        public virtual Empleado Empleado { get; set; }
    }
}
