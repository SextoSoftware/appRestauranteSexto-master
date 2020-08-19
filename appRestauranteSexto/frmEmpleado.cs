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
    public partial class frmEmpleado : Form
    {
        public baseContext bd = new baseContext();
        public int idEmpleado = 0;
        public frmEmpleado()
        {
            InitializeComponent();
        }


        private void limpiar()
        {
            cargarGrilla();
            idEmpleado = 0;
            txtCedula.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            txtUsuario.Text = "";
            txtClave.Text = "";

        }

        private void cargarGrilla()
        {
            List<Empleado> lista = bd.Empleado.ToList();
            dtgEmpleado.DataSource = lista;

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
            string usuario = txtUsuario.Text;
            string clave = txtClave.Text;



            try
            {
                if (idEmpleado == 0)
                {
                    Empleado emp = new Empleado();
                    emp.cedula = cedula;
                    emp.nombres = nombres;
                    emp.apellidos = apellidos;
                    emp.direccion = direccion;
                    emp.telefono = telefono;
                    emp.celular = celular;
                    emp.usuario = usuario;
                    emp.clave = clave;

                    bd.Empleado.Add(emp);
                    bd.SaveChanges();
                    MessageBox.Show("Empleado agregada exitosamente");
                    limpiar();
                }
                else
                {
                    Empleado emp = bd.Empleado.Find(idEmpleado);
                    emp.cedula = cedula;
                    emp.nombres = nombres;
                    emp.apellidos = apellidos;
                    emp.direccion = direccion;
                    emp.telefono = telefono;
                    emp.celular = celular;
                    emp.usuario = usuario;
                    emp.clave = clave;
                    bd.Entry(emp).State = EntityState.Modified;
                    bd.SaveChanges();
                    MessageBox.Show("Empleado editado exitosamente");
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
            if (txtCedula.Text.Trim() == "")
            {
                MessageBox.Show("Todos los campos son requeridos");
                return false;
            }

            if (idEmpleado == 0)
            {
                var cedula = txtCedula.Text.Trim();
                List<Empleado> lista = bd.Empleado.Where(x => x.cedula.ToLower() == cedula.ToLower()).ToList();
                int contar = lista.Count();
                if (contar > 0)
                {
                    MessageBox.Show("Ese empleado ya existe");
                    return false;
                }
            }
            else
            {
                Empleado emp = bd.Empleado.Find(idEmpleado);

                if (emp.cedula != txtCedula.Text)
                {
                    var cedula = txtCedula.Text.Trim();
                    List<Empleado> lista = bd.Empleado.Where(x => x.cedula.ToLower() == cedula.ToLower()).ToList();
                    int contar = lista.Count();
                    if (contar > 0)
                    {
                        MessageBox.Show("Ese empleado ya existe");
                        return false;
                    }
                }

                if (emp.nombres != txtNombres.Text)
                {
                    var nombre = txtNombres.Text.Trim();
                    List<Empleado> lista = bd.Empleado.Where(x => x.nombres.ToLower() == nombre.ToLower()).ToList();
                    int contar = lista.Count();
                    if (contar > 0)
                    {
                        MessageBox.Show("Ese empleado ya existe");
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idEmpleado == 0)
            {
                MessageBox.Show("Seleccione un E mpleado");
                return;
            }

            try
            {
                Empleado emp = bd.Empleado.Find(idEmpleado);
                bd.Empleado.Remove(emp);
                bd.SaveChanges();
                MessageBox.Show("Eliminado con éxito");
                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dtgEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int id = Convert.ToInt32(dtgEmpleado.Rows[e.RowIndex].Cells["idEmpleado"].Value.ToString());

            Empleado emp = bd.Empleado.Find(id);

            txtCedula.Text = emp.cedula;
            txtNombres.Text = emp.nombres;
            txtApellidos.Text = emp.apellidos;
            txtDireccion.Text = emp.direccion;
            txtTelefono.Text = emp.telefono;
            txtCelular.Text = emp.celular;
            txtUsuario.Text = emp.usuario;
            txtClave.Text = emp.clave;
            idEmpleado = emp.idEmpleado;
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            limpiar();
            cargarGrilla();
        }
    }
}
