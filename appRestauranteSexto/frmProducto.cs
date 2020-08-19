using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appRestauranteSexto
{
    public partial class frmProducto : Form
    {
        public baseContext bd = new baseContext();
        public int idProducto = 0;
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            limpiar();
            cargarGrilla();
        }

        private void limpiar()
        {
            cargarGrilla();
            idProducto = 0;
            txtNombre.Text = "";
            txtCosto.Text = "";
            txtPVP.Text = "";
            txtStock.Text = "";


        }

        private void cargarGrilla()
        {
            List<Producto> lista = bd.Producto.ToList();
            dtgProducto.DataSource = lista;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (verificar() == false)
            {
                return;
            }

            string nombre = txtNombre.Text;
            string costo = txtCosto.Text;
            string pvp = txtPVP.Text;
            string stock = txtStock.Text;



            try
            {
                if (idProducto == 0)
                {
                    Producto pro = new Producto();
                    pro.nombre = nombre;
                    /*  pro.costo = costo;
                      pro.pvp = pvp;
                      pro.stock = stock;*/

                    bd.Producto.Add(pro);
                    bd.SaveChanges();
                    MessageBox.Show("Producto agregado exitosamente");
                    limpiar();
                }
                else
                {
                    Producto pro = bd.Producto.Find(idProducto);
                    pro.nombre = nombre;
                    /* pro.costo = costo;
                     pro.pvp = pvp;
                     pro.stock = stock;*/

                    bd.Entry(pro).State = EntityState.Modified;
                    bd.SaveChanges();
                    MessageBox.Show("Producto editado exitosamente");
                    limpiar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool verificar()
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Todos los campos son requeridos");
                return false;
            }

            if (idProducto == 0)
            {
                var nombre = txtNombre.Text.Trim();
                List<Producto> lista = bd.Producto.Where(x => x.nombre.ToLower() == nombre.ToLower()).ToList();
                int contar = lista.Count();
                if (contar > 0)
                {
                    MessageBox.Show("Ese producto ya existe");
                    return false;
                }
            }
            else
            {
                Producto pro = bd.Producto.Find(idProducto);

                if (pro.nombre != txtNombre.Text)
                {
                    var nombre = txtNombre.Text.Trim();
                    List<Producto> lista = bd.Producto.Where(x => x.nombre.ToLower() == nombre.ToLower()).ToList();
                    int contar = lista.Count();
                    if (contar > 0)
                    {
                        MessageBox.Show("Ese producto ya existe");
                        return false;
                    }
                }

                if (pro.nombre != txtNombre.Text)
                {
                    var nombre = txtNombre.Text.Trim();
                    List<Producto> lista = bd.Producto.Where(x => x.nombre.ToLower() == nombre.ToLower()).ToList();
                    int contar = lista.Count();
                    if (contar > 0)
                    {
                        MessageBox.Show("Ese producto ya existe");
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProducto == 0)
            {
                MessageBox.Show("Seleccione un Producto");
                return;
            }

            try
            {
                Producto pro = bd.Producto.Find(idProducto);
                bd.Producto.Remove(pro);
                bd.SaveChanges();
                MessageBox.Show("Eliminado con éxito");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
