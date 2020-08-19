namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleFacturaCompra")]
    public partial class DetalleFacturaCompra
    {
        [Key]
        public int idDetalle { get; set; }

        public int idFacturaCompra { get; set; }

        public double cantidad { get; set; }

        public int idProducto { get; set; }

        public double precio { get; set; }

        public virtual FacturaCompra FacturaCompra { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
