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
    public partial class frmPlato : Form
    {
        public baseContext bd = new baseContext();
        public int idPlato = 0;
        public frmPlato()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (verificar() == false)
            {
                return;
            }

            string nombre = txtNombre.Text;
            string detalles = txtDetalle.Text;
            float pvp = (float)Convert.ToDouble(txtPvp.Text);
            bool activo = Convert.ToBoolean(cmbEstado.Text);

            try
            {
                if (idPlato == 0)
                {
                    Plato pla = new Plato();
                    pla.nombre = nombre;
                    pla.detalle = detalles;
                    pla.pvp = pvp;
                    pla.activo = activo;
                    bd.Plato.Add(pla);
                    bd.SaveChanges();
                    MessageBox.Show("Proveedor agregada exitosamente");
                    limpiar();
                }
                else
                {
                    Plato pla = bd.Plato.Find(idPlato);
                    pla.nombre = nombre;
                    pla.detalle = detalles;
                    pla.pvp = pvp;
                    pla.activo = activo;
                    bd.Entry(pla).State = EntityState.Modified;
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

        private void limpiar()
        {
            cargarGrilla();
            txtNombre.Text = "";
            txtDetalle.Text = "";
            txtPvp.Text = "";
            idPlato = 0;

        }

        private void dtgPlato_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = Convert.ToInt32(dtgPlato.Rows[e.RowIndex].Cells["idPlato"].Value.ToString());

            Plato plat = bd.Plato.Find(id);

            txtNombre.Text = plat.nombre;
            txtDetalle.Text = plat.detalle;
            txtPvp.Text = Convert.ToString(plat.pvp);
            cmbEstado.Text = Convert.ToString(plat.activo);
            idPlato = plat.idPlato;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (idPlato == 0)
            {
                MessageBox.Show("Seleccione un plato");
                return;
            }

            try
            {
                Plato pla = bd.Plato.Find(idPlato);
                bd.Plato.Remove(pla);
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

            if (idPlato == 0)
            {
                var nombre = txtNombre.Text.Trim();
                List<Plato> lista = bd.Plato.Where(x => x.nombre.ToLower() == nombre.ToLower()).ToList();
                int contar = lista.Count();
                if (contar > 0)
                {
                    MessageBox.Show("Esa categoría ya existe");
                    return false;
                }

            }
            else
            {
                Plato pla = bd.Plato.Find(idPlato);

                if (pla.nombre != txtNombre.Text)
                {
                    var nombre = txtNombre.Text.Trim();
                    List<Plato> lista = bd.Plato.Where(x => x.nombre.ToLower() == nombre.ToLower()).ToList();
                    int contar = lista.Count();
                    if (contar > 0)
                    {
                        MessageBox.Show("El plato ya existe");
                        return false;
                    }
                }


            }
            return true;
        }

        private void frmPlato_Load(object sender, EventArgs e)
        {
            limpiar();
            cargarGrilla();
        }

        private void cargarGrilla()
        {
            List<Plato> lista = bd.Plato.ToList();
            dtgPlato.DataSource = lista;

        }

    }
}
