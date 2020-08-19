namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleFacturaVenta")]
    public partial class DetalleFacturaVenta
    {
        [Key]
        public int idDetalle { get; set; }

        public int? idFacturaVenta { get; set; }

        public double? cantidad { get; set; }

        public double? precio { get; set; }

        public int? idProducto { get; set; }

        public int? idPlato { get; set; }

        public virtual FacturaVenta FacturaVenta { get; set; }

        public virtual Plato Plato { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
