namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Plato")]
    public partial class Plato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plato()
        {
            DetalleFacturaVenta = new HashSet<DetalleFacturaVenta>();
            Receta = new HashSet<Receta>();
        }

        [Key]
        public int idPlato { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        public string detalle { get; set; }

        public bool? activo { get; set; }

        public double? pvp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFacturaVenta> DetalleFacturaVenta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Receta> Receta { get; set; }
    }
}
