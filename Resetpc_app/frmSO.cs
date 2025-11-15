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

namespace Resetpc_app
{
    public partial class frmSO : Form
    {
        private int indiceSeleccionado = -1;
        public frmSO()
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            SO obj = new SO()
            {
                IdSO = Convert.ToInt32(txtid.Text),
                NombreSO = txtnombreSO.Text
            };


            if (obj.IdSO == 0)
            {
                //Registrar
                int idGenerado = new CN_SO().Registrar(obj, out mensaje);

                if (idGenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"",idGenerado,txtnombreSO.Text
                    });

                    MessageBox.Show("Se registró correctamente el SO");
                    Limpiar();

                }
                else
                {
                    MessageBox.Show("No se pudo registrar el SO: " + mensaje);
                }
            }
            else
            {
                //Editar
                bool resultado = new CN_SO().Editar(obj, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(indiceSeleccionado)];
                    row.Cells["IdSO"].Value = txtid.Text;
                    row.Cells["NombreSO"].Value = txtnombreSO.Text;

                    MessageBox.Show("Se editó correctamente el SO.");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo editar el SO: " + mensaje);
                }
            }


        }


        private void Limpiar()
        {
            txtid.Text = "0";
            txtnombreSO.Text = "";
            indiceSeleccionado = -1; // Reinicia el índice

        }

        private void frmSO_Load(object sender, EventArgs e)
        {
            List<SO> lista = new CN_SO().Listar();

           

            dgvdata.Rows.Clear();
            //MOSTRAR LAS CATEGORIAS
            List<SO> listaSO = new CN_SO().Listar();


            foreach (SO item in listaSO)
            {
                dgvdata.Rows.Add(new object[] {
                    "",
                    item.IdSO,
                    item.NombreSO

                });
            }

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Deseas eliminar la el SO?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    SO obj = new SO()
                    {
                        IdSO = Convert.ToInt32(txtid.Text),
                    };

                    bool resultado = new CN_SO().Eliminar(obj, out mensaje);

                    if (resultado)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(indiceSeleccionado));

                        MessageBox.Show("Se eliminó correctamente el SO.");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el SO: " + mensaje);
                    }
                }
            }
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);


                // Tamaño deseado (ajustado a la celda)
                int w = 20;
                int h = 20;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.comprobar, new Rectangle(x, y, w, h));
                e.Handled = true;

            }
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    indiceSeleccionado = indice;
                    txtid.Text = dgvdata.Rows[indice].Cells["IdSO"].Value.ToString();
                    txtnombreSO.Text = dgvdata.Rows[indice].Cells["NombreSO"].Value.ToString();

                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {

            txtid.Text = "0";
            txtnombreSO.Text = "";
            indiceSeleccionado = -1; // Reinicia el índice
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            BuscarEnTiempoReal();
            txtbusqueda.TextChanged += txtbusqueda_TextChanged;
        }

        private void BuscarEnTiempoReal()
        {
            string textoBuscado = txtbusqueda.Text.Trim().ToUpper();

            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                // Asegúrate de que la columna exista y no sea null
                if (row.Cells["NombreSO"].Value != null)
                {
                    string valorCelda = row.Cells["NombreSO"].Value.ToString().Trim().ToUpper();

                    // Mostrar solo si contiene el texto buscado
                    row.Visible = valorCelda.Contains(textoBuscado);
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
