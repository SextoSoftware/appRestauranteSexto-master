namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Receta")]
    public partial class Receta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Receta()
        {
            DetalleReceta = new HashSet<DetalleReceta>();
        }

        [Key]
        public int idReceta { get; set; }

        [Required]
        public string nombre { get; set; }

        public string detalle { get; set; }

        public int idPlato { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleReceta> DetalleReceta { get; set; }

        public virtual Plato Plato { get; set; }
    }
}
