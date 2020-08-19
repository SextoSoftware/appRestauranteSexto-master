namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            FacturaVenta = new HashSet<FacturaVenta>();
        }

        [Key]
        public int idCliente { get; set; }

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

        public string mail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturaVenta> FacturaVenta { get; set; }
    }
}
