namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empleado")]
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            FacturaCompra = new HashSet<FacturaCompra>();
            FacturaVenta = new HashSet<FacturaVenta>();
        }

        [Key]
        public int idEmpleado { get; set; }

        [Required]
        [StringLength(14)]
        public string cedula { get; set; }

        [Required]
        [StringLength(150)]
        public string nombres { get; set; }

        [Required]
        [StringLength(150)]
        public string apellidos { get; set; }

        public string direccion { get; set; }

        [StringLength(9)]
        public string telefono { get; set; }

        [StringLength(10)]
        public string celular { get; set; }

        [StringLength(100)]
        public string usuario { get; set; }

        [StringLength(100)]
        public string clave { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturaCompra> FacturaCompra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturaVenta> FacturaVenta { get; set; }
    }
}
