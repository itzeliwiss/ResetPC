using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using Resetpc_app.Utilizades;

namespace Resetpc_app.Modales
{
    public partial class mdComponente : Form
    {
        public Componente _Componente { get; set; }
        public mdComponente()
        {
            InitializeComponent();
        }

        private void mdComponente_Load(object sender, EventArgs e)
        {
            List<Componente> lista = new CN_Componente().Listar();

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true)
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            List<Componente> listaComponente = new CN_Componente().Listar();


            foreach (Componente item in listaComponente)
            {
                dgvdata.Rows.Add(new object[] {
                    item.IdComponente,
                    item.Codigo,
                    item.Nombre,
                    item.Descripcion
                });
            }
        }

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum > 0)
            {
                _Componente = new Componente()
                {
                    IdComponente = Convert.ToInt32(dgvdata.Rows[iRow].Cells["IdComponente"].Value),
                    Codigo = dgvdata.Rows[iRow].Cells["Codigo"].Value.ToString(),
                    Nombre = dgvdata.Rows[iRow].Cells["Nombre"].Value.ToString(),
                    Descripcion = dgvdata.Rows[iRow].Cells["Descripcion"].Value.ToString()
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();
            string textoBuscado = txtbusqueda.Text.Trim();

            // Si no hay texto para búsqueda, mostrar todas las filas
            if (string.IsNullOrWhiteSpace(textoBuscado))
            {
                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                if (row.Cells[columnaFiltro].Value != null) // Validamos que no sea null
                {
                    string valorCelda = row.Cells[columnaFiltro].Value.ToString().Trim();
                    // Convertimos ambos a mayúsculas para que la búsqueda no dependa de mayúsculas/minúsculas
                    if (valorCelda.ToUpper().Contains(textoBuscado.ToUpper()))
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true; // Mostrar todas las filas
            }
        }
    }
}
