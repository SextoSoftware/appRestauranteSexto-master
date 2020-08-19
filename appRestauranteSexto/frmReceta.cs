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
    public partial class frmReceta : Form
    {
        public baseContext bd = new baseContext();
        public int idReceta = 0;
        public frmReceta()
        {
            InitializeComponent();
        }
        private void frmReceta_Load(object sender, EventArgs e)
        {
            limpiar();
            cargarGrilla();
            cargarPlato();
        }
        private void limpiar()
        {
            cargarGrilla();
            idReceta = 0;
            txtNombre.Text = "";

        }

        private void cargarPlato()
        {

            List<Plato> lista = bd.Plato.ToList();
            cmbPlato.DisplayMember = "nombre";
            cmbPlato.ValueMember = "idPLato";
            cmbPlato.DataSource = lista;


        }
        private void cargarGrilla()
        {
            List<Receta> lista = bd.Receta.ToList();
            dtgRecetas.DataSource = lista;
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
            string detalle = txtDetalle.Text;



            try
            {
                if (idReceta == 0)
                {
                    Receta rec = new Receta();
                    rec.nombre = nombre;
                    rec.detalle = detalle;

                    bd.Receta.Add(rec);
                    bd.SaveChanges();
                    MessageBox.Show("Receta agregada exitosamente");
                    limpiar();
                }
                else
                {
                    Receta rec = bd.Receta.Find(idReceta);
                    rec.nombre = nombre;
                    rec.detalle = detalle;
                    bd.Entry(rec).State = EntityState.Modified;
                    bd.SaveChanges();
                    MessageBox.Show("Receta editada exitosamente");
                    limpiar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }



        }

        private void dtgRecetas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = Convert.ToInt32(dtgRecetas.Rows[e.RowIndex].Cells["idReceta"].Value.ToString());

            Receta rec = bd.Receta.Find(id);

            txtNombre.Text = rec.nombre;
            idReceta = rec.idReceta;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idReceta == 0)
            {
                MessageBox.Show("Seleccione una Receta");
                return;
            }

            try
            {
                Receta rec = bd.Receta.Find(idReceta);
                bd.Receta.Remove(rec);
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
            if (txtNombre.Text.Trim() == ""
                && txtDetalle.Text.Trim() == "")
            {
                MessageBox.Show("Todos los campos son requeridos");
                return false;
            }

            if (idReceta == 0)
            {
                var nombre = txtNombre.Text.Trim();
                List<Receta> lista = bd.Receta.Where(x => x.nombre.ToLower() == nombre.ToLower()).ToList();
                int contar = lista.Count();
                if (contar > 0)
                {
                    MessageBox.Show("Esa Receta ya existe");
                    return false;
                }
            }
            else
            {
                Receta rec = bd.Receta.Find(idReceta);

                if (rec.nombre != txtNombre.Text)
                {
                    var nombre = txtNombre.Text.Trim();
                    List<Receta> lista = bd.Receta.Where(x => x.nombre.ToLower() == nombre.ToLower()).ToList();
                    int contar = lista.Count();
                    if (contar > 0)
                    {
                        MessageBox.Show("Esa Receta ya existe");
                        return false;
                    }
                }
            }
            return true;
        }

        private void frmReceta_Load_1(object sender, EventArgs e)
        {

        }
    }
}
