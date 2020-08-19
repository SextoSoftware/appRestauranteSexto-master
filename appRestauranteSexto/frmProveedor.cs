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
    public partial class frmProveedor : Form
    {
        public baseContext bd = new baseContext();
        public int idProveedor = 0;
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            limpiar();
            cargarGrilla();
        }

        private void dtgProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = Convert.ToInt32(dtgProveedor.Rows[e.RowIndex].Cells["idProveedor"].Value.ToString());

            Proveedor pro = bd.Proveedor.Find(id);

            txtCedula.Text = pro.cedula;
            txtNombre.Text = pro.nombre;
            txtCiudad.Text = pro.ciudad;
            txtDireccion.Text = pro.direccion;
            txtTelefono.Text = pro.telefono;
            txtCelular.Text = pro.celular;
            txtMail.Text = pro.mail;
            idProveedor = pro.idProveedor;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (verificar() == false)
            {
                return;
            }

            string cedula = txtCedula.Text;
            string nombre = txtNombre.Text;
            string ciudad = txtCiudad.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string celular = txtCelular.Text;
            string mail = txtMail.Text;


            try
            {
                if (idProveedor == 0)
                {
                    Proveedor pro = new Proveedor();
                    pro.cedula = cedula;
                    pro.nombre = nombre;
                    pro.ciudad = ciudad;
                    pro.direccion = direccion;
                    pro.telefono = telefono;
                    pro.celular = celular;
                    pro.mail = mail;
                    bd.Proveedor.Add(pro);
                    bd.SaveChanges();
                    MessageBox.Show("Proveedor agregada exitosamente");
                    limpiar();
                }
                else
                {
                    Proveedor pro = bd.Proveedor.Find(idProveedor);
                    pro.cedula = cedula;
                    pro.nombre = nombre;
                    pro.ciudad = ciudad;
                    pro.direccion = direccion;
                    pro.telefono = telefono;
                    pro.celular = celular;
                    pro.mail = mail;
                    bd.Entry(pro).State = EntityState.Modified;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (idProveedor == 0)
            {
                MessageBox.Show("Seleccione un proveedor");
                return;
            }

            try
            {
                Proveedor pro = bd.Proveedor.Find(idProveedor);
                bd.Proveedor.Remove(pro);
                bd.SaveChanges();
                MessageBox.Show("Eliminado con éxito");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void limpiar()
        {
            cargarGrilla();
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtCiudad.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            txtMail.Text = "";
            idProveedor = 0;

        }

        private void cargarGrilla()
        {
            List<Proveedor> lista = bd.Proveedor.ToList();
            dtgProveedor.DataSource = lista;

        }

        private bool verificar()
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Todos los campos son requeridos");
                return false;
            }

            if (idProveedor == 0)
            {
                var cedula = txtCedula.Text.Trim();
                var mail = txtMail.Text.Trim();
                List<Proveedor> lista = bd.Proveedor.Where(x => x.mail.ToLower() == mail.ToLower()).ToList();
                int contar = lista.Count();
                int contar1 = lista.Count();
                if (contar > 0)
                {
                    MessageBox.Show("Esa categoría ya existe");
                    return false;
                }
                if (contar1 > 0)
                {
                    MessageBox.Show("Ese e-mail ya existe");
                    return false;
                }
            }
            else
            {
                Proveedor pro = bd.Proveedor.Find(idProveedor);

                if (pro.mail != txtMail.Text)
                {
                    var mail = txtMail.Text.Trim();
                    List<Proveedor> lista = bd.Proveedor.Where(x => x.mail.ToLower() == mail.ToLower()).ToList();
                    int contar = lista.Count();
                    if (contar > 0)
                    {
                        MessageBox.Show("El e-mail ya existe");
                        return false;
                    }
                }

                if (pro.telefono != txtTelefono.Text)
                {
                    var telefono = txtTelefono.Text.Trim();
                    List<Proveedor> lista = bd.Proveedor.Where(x => x.telefono.ToLower() == telefono.ToLower()).ToList();
                    int contar = lista.Count();
                    if (contar > 0)
                    {
                        MessageBox.Show("El teléfono ya existe");
                        return false;
                    }
                }

                if (pro.celular != txtCelular.Text)
                {
                    var celular = txtCelular.Text.Trim();
                    List<Proveedor> lista = bd.Proveedor.Where(x => x.celular.ToLower() == celular.ToLower()).ToList();
                    int contar = lista.Count();
                    if (contar > 0)
                    {
                        MessageBox.Show("El celular ya existe");
                        return false;
                    }
                }

            }
            return true;
        }

    }
}
