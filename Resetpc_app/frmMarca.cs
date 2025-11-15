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
    public partial class frmMarca : Form
    {
        private int indiceSeleccionado = -1;
        public frmMarca()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.frmMarca_Load);
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Marca obj = new Marca()
            {
                IdMarca = Convert.ToInt32(txtid.Text),
                NombreMarca = txtmarca.Text
            };


            if (obj.IdMarca == 0)
            {
                //Registrar
                int idGenerado = new CN_Marca().Registrar(obj, out mensaje);

                if (idGenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"",idGenerado,txtmarca.Text
                    });

                    MessageBox.Show("Se registró correctamente la marca: " + mensaje);
                    Limpiar();

                }
                else
                {
                    MessageBox.Show("No se pudo registrar la marca: " + mensaje);
                }
            }
            else
            {
                //Editar
                bool resultado = new CN_Marca().Editar(obj, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(indiceSeleccionado)];
                    row.Cells["IdMarca"].Value = txtid.Text;
                    row.Cells["Nombre"].Value = txtmarca.Text;

                    MessageBox.Show("Se editó correctamente la marca.");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo editar la marca: " + mensaje);
                }
            }
        }
        private void Limpiar()
        {
            txtid.Text = "0";
            txtmarca.Text = "";
            indiceSeleccionado = -1; // Reinicia el índice

        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            List<Marca> lista = new CN_Marca().Listar();

            

            dgvdata.Rows.Clear();
            //MOSTRAR LAS CATEGORIAS
            List<Marca> listaMarca = new CN_Marca().Listar();


            foreach (Marca item in listaMarca)
            {
                dgvdata.Rows.Add(new object[] {
                    "",
                    item.IdMarca,
                    item.NombreMarca

                });
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtid.Text = "0";
            txtmarca.Text = "";
            indiceSeleccionado = -1; // Reinicia el índice
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Deseas eliminar la marca?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    Marca obj = new Marca()
                    {
                        IdMarca = Convert.ToInt32(txtid.Text)
                    };

                    bool resultado = new CN_Marca().Eliminar(obj, out mensaje);

                    if (resultado)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(indiceSeleccionado));

                        MessageBox.Show("Se eliminó correctamente la marca.");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la marca: " + mensaje);
                    }
                }
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
                    txtid.Text = dgvdata.Rows[indice].Cells["IdMarca"].Value.ToString();
                    txtmarca.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();

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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
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
                if (row.Cells["Nombre"].Value != null)
                {
                    string valorCelda = row.Cells["Nombre"].Value.ToString().Trim().ToUpper();

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
