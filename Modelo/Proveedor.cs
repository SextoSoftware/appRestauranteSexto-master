namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proveedor")]
    public partial class Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor()
        {
            FacturaCompra = new HashSet<FacturaCompra>();
        }

        [Key]
        public int idProveedor { get; set; }

        [Required]
        [StringLength(14)]
        public string cedula { get; set; }

        [Required]
        [StringLength(150)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string ciudad { get; set; }

        [Required]
        public string direccion { get; set; }

        [StringLength(9)]
        public string telefono { get; set; }

        [Required]
        [StringLength(10)]
        public string celular { get; set; }

        public string mail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturaCompra> FacturaCompra { get; set; }
    }
}
