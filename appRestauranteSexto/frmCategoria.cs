using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appRestauranteSexto
{
    public partial class frmCategoria : Form
    {
        public baseContext bd = new baseContext();
        public int idCategoria = 0;
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            limpiar();
            cargarGrilla();
            cargarCategoria();
        }


        private void limpiar()
        {
            cargarGrilla();
            idCategoria = 0;
            txtNombre.Text = "";

        }

        private void cargarCategoria()
        {
           
            List<Categoria> lista = bd.Categoria.ToList();
            cmbCategoria.DisplayMember = "nombreCategoria";
            cmbCategoria.ValueMember = "idCategoria";
            cmbCategoria.DataSource = lista;


        }

        private void cargarGrilla()
        {
            List<Categoria> lista = bd.Categoria.ToList();
            dtgCategorias.DataSource = lista;
           /* Producto pr = new Producto();
            pr.nombre = "asdlkasd";
            pr.idCategoria = 1;
            pr.pvp = 0;
            pr.stock = 0;*/           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (verificar() == false)
            {
                return;
            }



            string nombre = txtNombre.Text;



            try
            {
                if (idCategoria == 0)
                {
                    Categoria cat = new Categoria();
                    cat.nombreCategoria = nombre;

                    bd.Categoria.Add(cat);
                    bd.SaveChanges();
                    MessageBox.Show("Categoría agregada exitosamente");
                    limpiar();
                }
                else
                {
                    Categoria cat = bd.Categoria.Find(idCategoria);
                    cat.nombreCategoria = nombre;
                    bd.Entry(cat).State=EntityState.Modified;
                    bd.SaveChanges();
                    MessageBox.Show("Categoría editada exitosamente");
                    limpiar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }









        }

        private void dtgCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = Convert.ToInt32(dtgCategorias.Rows[e.RowIndex].Cells["idCategoria"].Value.ToString());

            Categoria cat = bd.Categoria.Find(id);

            txtNombre.Text = cat.nombreCategoria;
            idCategoria = cat.idCategoria;
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idCategoria == 0)
            {
                MessageBox.Show("Seleccione una categoría");
                return;
            }

            try
            {
                Categoria cat = bd.Categoria.Find(idCategoria);
                bd.Categoria.Remove(cat);
                bd.SaveChanges();
                MessageBox.Show("Eliminado con éxito");
                limpiar();
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

            if (idCategoria==0)
            {
                var nombre = txtNombre.Text.Trim();
                List<Categoria> lista = bd.Categoria.Where(x => x.nombreCategoria.ToLower() == nombre.ToLower()).ToList();
                int contar = lista.Count();
                if (contar > 0)
                {
                    MessageBox.Show("Esa categoría ya existe");
                    return false;
                }
           }
            else
            {
                Categoria cat = bd.Categoria.Find(idCategoria);

                if (cat.nombreCategoria != txtNombre.Text)
                {
                    var nombre = txtNombre.Text.Trim();
                    List<Categoria> lista = bd.Categoria.Where(x => x.nombreCategoria.ToLower() == nombre.ToLower()).ToList();
                    int contar = lista.Count();
                    if (contar > 0)
                    {
                        MessageBox.Show("Esa categoría ya existe");
                        return false;
                    }
                }
            }
            return true;
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(cmbCategoria.SelectedValue.ToString());
        }
    }
}
