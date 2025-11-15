using CapaEntidad;
using CapaNegocio;
using Resetpc_app.Utilizades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Resetpc_app.Modales
{
    public partial class mdCliente : Form
    {
        public Cliente _Cliente { get; set; }
        public mdCliente()
        {
            InitializeComponent();
        }

        private void mdCliente_Load(object sender, EventArgs e)
        {
            List<Cliente> lista = new CN_Cliente().Listar();

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

            List<Cliente> listaCliente = new CN_Cliente().Listar();


            foreach (Cliente item in listaCliente)
            {
                dgvdata.Rows.Add(new object[] {
                    item.IdCliente,
                    item.NombreCompleto
                });
            }
        }

      

        private void dgvdata_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum > 0)
            {
                _Cliente = new Cliente()
                {
                    IdCliente = Convert.ToInt32(dgvdata.Rows[iRow].Cells["IdCliente"].Value),
                    NombreCompleto = dgvdata.Rows[iRow].Cells["NombreCompleto"].Value.ToString(),
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
