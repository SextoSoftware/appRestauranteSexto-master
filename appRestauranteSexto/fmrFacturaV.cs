using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace appRestauranteSexto
{
    public partial class fmrFacturaV : Form
    {
      public  baseContext bd= new baseContext();
        public int idFactura = 0;
        public int idEmpleado = 2;
        
        public fmrFacturaV()
        {
            InitializeComponent();
        }

        private void btnBusquedaProducto_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void fmrFacturaV_Load(object sender, EventArgs e)
        {
            cargarFactura();
            cargarCliente();
            //cargarPlatillos();
            cargarProductos();
        }

        private void cargarFactura()
        {
            int ultima = 1;

            if (bd.FacturaVenta.Count() != 0)
            {
                ultima = ultima+bd.FacturaVenta.OrderByDescending(x => x.idFactura).Select(x => x.idFactura).FirstOrDefault();
                idFactura = ultima;
            }
            else
            {
                idFactura = ultima;
            }


        }

        private void cargarProductos()
        {
            List<Producto> lista = bd.Producto.Where(x=>x.idCategoria==3).ToList();
            cmbProducto.ValueMember = "idProducto";
            cmbProducto.DisplayMember = "Nombre";
            cmbProducto.DataSource = lista;
        }


        private void cargarCliente()
        {
            var lista = (from c in bd.Cliente 
                         group c by new
                         {
                           id=c.idCliente,
                           cli=c.nombres+" "+c.apellidos
                         }into l
                         select new
                         {
                           idCliente=l.Key.id,
                           Nombres=l.Key.cli
                          }).ToList();

            cmbCliente.ValueMember = "idCliente";
            cmbCliente.DisplayMember = "Nombres";
            cmbCliente.DataSource = lista;
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex < 0)
            {
                return;
            }

            try
            {
                int id = Convert.ToInt32(cmbProducto.SelectedValue);
                Producto pro = bd.Producto.Find(id);
                txtStock.Text = pro.stock.ToString();
                txtPVenta.Text = pro.pvp.ToString();


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var identificador = 1;
            dtgFactura.Rows.Add();

            int i = dtgFactura.Rows.Count - 1;
            dtgFactura.Rows[i].Cells[1].Value=txtCantidadProducto.Text;
            dtgFactura.Rows[i].Cells[2].Value = cmbProducto.Text.ToString();
            dtgFactura.Rows[i].Cells[3].Value = txtPVenta.Text.ToString();

            var sub = Convert.ToDouble(txtCantidadProducto.Text) * Convert.ToDouble(txtPVenta.Text);
            dtgFactura.Rows[i].Cells[4].Value = sub.ToString();
            dtgFactura.Rows[i].Cells[0].Value = cmbProducto.SelectedValue.ToString(); 
            dtgFactura.Rows[i].Cells["Identificador"].Value = identificador;
           // guardar();

        }



        private void guardar()
        {

            FacturaVenta fv = new FacturaVenta();
            fv.idEmpleado = idEmpleado;
            fv.fecha = DateTime.Now;
            fv.iva = 12;
            fv.descuento = 0;

            bd.FacturaVenta.Add(fv);
            bd.SaveChanges();
            



            int contador = 0;
            foreach (var item in dtgFactura.Rows)
            {

                if (dtgFactura.Rows[contador].Cells["Identificador"].Value.ToString().Equals("1"))
                {
                    try
                    {
                        DetalleFacturaVenta df = new DetalleFacturaVenta();
                        df.idFacturaVenta = idFactura;
                        df.cantidad = Convert.ToDouble(dtgFactura.Rows[contador].Cells["Cantidad"].Value.ToString());
                        df.idProducto = 1;
                        df.precio = 0;

                        bd.DetalleFacturaVenta.Add(df);
                        bd.SaveChanges();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("");
                    }

                }
                else
                {
                    DetalleFacturaVenta df = new DetalleFacturaVenta();
                    df.idFacturaVenta = idFactura;
                    df.cantidad = Convert.ToDouble(dtgFactura.Rows[contador].Cells[1].Value.ToString());
                    df.idPlato = 1;
                    df.precio=0;
                    bd.DetalleFacturaVenta.Add(df);
                    bd.SaveChanges();
                }


                contador++;

            }
        }
    }
}
