using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FontAwesome.Sharp;
using CapaEntidad;

namespace Resetpc_app
{
    public partial class Inicio : Form
    {

        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        public Inicio()
        {
            InitializeComponent();
        }

        

        

        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem) sender, new frmClientes());
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;

            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.DarkSlateBlue;

            Contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        

       

        private void menuequipos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmEquipos());
        }

        private void menuproveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProveedores());
        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmReportes());
        }

        private void menuacercade_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmAcercade());
        }

        

        private void submenucategoria_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmCategoria());
        }

        private void submenuregistrarventa_Click(object sender, EventArgs e)
        {
            
        }

        private void submenudetalleventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuservicios, new frmDetalleServicios());
        }

        private void submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmCompras());
        }

        private void submenudetallecompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new frmDetalleCompra());
        }

        private void submenucomponentes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmComponentes());
        }

        private void submenunegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenedor, new frmNegocio());
        }

        private void serviciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuservicios, new frmServicios());
        }

        private void marcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuservicios, new frmMarca());
        }

        private void sOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuservicios, new frmSO());
        }

        private void menuconsolas_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmConsolas());
        }

        private void menumantenedor_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmConfiguracion());
        }
    }
}
