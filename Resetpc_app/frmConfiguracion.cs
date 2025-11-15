using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resetpc_app
{
    public partial class frmConfiguracion : Form
    {
        private static ToolStripMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmMenuConfiguracion_Load(object sender, EventArgs e)
        {

        }

        private void AbrirFolumario(ToolStripMenuItem menu, Form formulario)
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

        private void menucategoria_Click(object sender, EventArgs e)
        {
            AbrirFolumario((ToolStripMenuItem)sender, new frmCategoria());
        }

        private void menucomponente_Click(object sender, EventArgs e)
        {
            AbrirFolumario((ToolStripMenuItem)sender, new frmComponentes());
        }

        private void menuservicios_Click(object sender, EventArgs e)
        {
            AbrirFolumario((ToolStripMenuItem)sender, new frmServicios());
        }

        private void menunegocio_Click(object sender, EventArgs e)
        {
            AbrirFolumario((ToolStripMenuItem)sender, new frmNegocio());
        }

        private void menumarcas_Click(object sender, EventArgs e)
        {
            AbrirFolumario((ToolStripMenuItem)sender, new frmMarca());
        }

        private void menuso_Click(object sender, EventArgs e)
        {
            AbrirFolumario((ToolStripMenuItem)sender, new frmSO());
        }
    }
}
