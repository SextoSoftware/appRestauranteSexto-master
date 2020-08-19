namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleReceta")]
    public partial class DetalleReceta
    {
        [Key]
        public int idDetalle { get; set; }

        public int idReceta { get; set; }

        public int idProducto { get; set; }

        public double cantidad { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual Receta Receta { get; set; }
    }
}
