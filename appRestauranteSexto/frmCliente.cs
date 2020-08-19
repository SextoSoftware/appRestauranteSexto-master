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
    public partial class frmCliente : Form
    {
        public baseContext bd = new baseContext();
        public int idCliente = 0;
        public frmCliente()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = Convert.ToInt32(dtgClientes.Rows[e.RowIndex].Cells["idCliente"].Value.ToString());

            Cliente cli = bd.Cliente.Find(id);
            txtCedula.Text = cli.cedula;
            txtNombres.Text = cli.nombres;
            txtApellidos.Text = cli.apellidos;
            txtDireccion.Text = cli.direccion;
            txtTelefono.Text = cli.telefono;
            txtCelular.Text = cli.celular;
            txtEmail.Text = cli.mail;


            idCliente = cli.idCliente;
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            limpiar();
            cargarGrilla();
            
        }
        private void limpiar()
        {
            cargarGrilla();
            idCliente = 0;
            txtCedula.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";

        }
        private void cargarGrilla()
        {
            List<Cliente> lista = bd.Cliente.ToList();
            dtgClientes.DataSource = lista;
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



            string cedula = txtCedula.Text;

            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string celular = txtCelular.Text;
            string email = txtEmail.Text;


            try
            {
                if (idCliente == 0)
                {
                    Cliente cli = new Cliente();
                    cli.cedula = cedula;

                    cli.nombres = nombres;
                    cli.apellidos = apellidos;
                    cli.direccion = direccion;
                    cli.telefono = telefono;
                    cli.celular = celular;
                    cli.mail = email;






                    bd.Cliente.Add(cli);
                    bd.SaveChanges();
                    MessageBox.Show("Cliente agregado exitosamente");
                    limpiar();
                }
                else
                {
                    Cliente cli = bd.Cliente.Find(idCliente);
                    cli.cedula = cedula;

                    cli.nombres = nombres;
                    cli.apellidos = apellidos;
                    cli.direccion = direccion;
                    cli.telefono = telefono;
                    cli.celular = celular;
                    cli.mail = email;
                    txtCedula.ReadOnly = true;
                    bd.Entry(cli).State = EntityState.Modified;
                    bd.SaveChanges();
                    MessageBox.Show("Cliente editado exitosamente");
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
            if (idCliente == 0)
            {
                MessageBox.Show("Seleccione un Cliente");
                return;
            }

            try
            {
                Cliente cli = bd.Cliente.Find(idCliente);
                bd.Cliente.Remove(cli);
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
            if (txtCedula.Text.Trim() == "" 
                && txtNombres.Text.Trim() == ""
                && txtApellidos.Text.Trim() == ""
                && txtDireccion.Text.Trim() == ""
                && txtTelefono.Text.Trim() == ""
                && txtCelular.Text.Trim() == ""
                && txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Todos los campos son requeridos");
                return false;
            }

            if (idCliente == 0)
            {
                var cedula = txtCedula.Text.Trim();
                List<Cliente> lista = bd.Cliente.Where(x => x.cedula.ToLower() == cedula.ToLower()).ToList();
                int contar = lista.Count();
                if (contar > 0)
                {
                    MessageBox.Show("El cliente ya existe");
                    return false;
                }
            }
            else
            {
                Cliente cli = bd.Cliente.Find(idCliente);

                if (cli.cedula != txtCedula.Text 
                    && cli.telefono != txtTelefono.Text 
                    && cli.celular != txtCelular.Text
                    && cli.mail != txtEmail.Text)
                {
                    var cedula = txtCedula.Text.Trim();
                    var telefono = txtTelefono.Text.Trim();
                    var celular = txtCelular.Text.Trim();
                    var mail = txtEmail.Text.Trim();

                    List<Cliente> lista = bd.Cliente.Where(x => x.cedula.ToLower() == cedula.ToLower() ).ToList();
                    int contar = lista.Count();
                    if (contar > 0)
                    {
                        MessageBox.Show("El cliente ya existe");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
