using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appRestauranteSexto
{
    public partial class frmPrincipal : Form
    {
        int lx, ly;
        int sw, sh;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }

        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["frmProveedor"] == null)
                btnProductos.BackColor = Color.FromArgb(128, 0, 0);
            if (Application.OpenForms["frmEmpleado"] == null)
                btnEmpleados.BackColor = Color.FromArgb(128, 0, 0);
            if (Application.OpenForms["FrmClientes"] == null)
                btnClientes.BackColor = Color.FromArgb(128, 0, 0);
            if (Application.OpenForms["FrmRegistrarUsuarios"] == null)
                btnPlatos.BackColor = Color.FromArgb(128, 0, 0);
            if (Application.OpenForms["FrmRegistroVentas"] == null)
                btnVentas.BackColor = Color.FromArgb(128, 0, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de salir?", "Alerta",
       MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void btnCerrarSeion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de cerrar seción?", "Alerta",
         MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
           // FrmLogin formulario = new FrmLogin();
            //formulario.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmProveedor>();
            btnProveedores.BackColor = Color.FromArgb(252, 96, 31);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmEmpleado>();
            btnEmpleados.BackColor = Color.FromArgb(252, 96, 31);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmCliente>();
            btnClientes.BackColor = Color.FromArgb(252, 96, 31);
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
