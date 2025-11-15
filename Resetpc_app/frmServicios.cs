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
    public partial class frmServicios : Form
    {
        private int indiceSeleccionado = -1;
        public frmServicios()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.frmServicios_Load);
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            List<Servicio> lista = new CN_Servicio().Listar();

            // Limpiar items anteriores para evitar duplicados
            cbobusqueda.Items.Clear();

            foreach (DataGridViewColumn columna in dgvdata.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;

            

            dgvdata.Rows.Clear();
            //MOSTRAR LAS TODOS LOS COMPONENTES EN LA TABLA 
            List<Servicio> listasServicio = new CN_Servicio().Listar();


            foreach (Servicio item in listasServicio)
            {
                dgvdata.Rows.Add(new object[] {
                    "",
                    item.IdServicio,
                    item.Codigo,
                    item.Nombre,
                    item.Descripcion,
                    item.Precio.ToString("0.00"),
                });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Servicio obj = new Servicio()
            {
                IdServicio = Convert.ToInt32(txtid.Text),
                Codigo = txtcodigo.Text,
                Nombre = txtnombre.Text,
                Descripcion = txtdescripcion.Text,
                Precio = txtprecio.Text == "" ? 0 : Convert.ToDecimal(txtprecio.Text)
            };


            if (obj.IdServicio == 0)
            {
                //Registrar
                int idGenerado = new CN_Servicio().Registrar(obj, out mensaje);

                if (idGenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {
                        "",
                        idGenerado,
                        txtcodigo.Text,
                        txtnombre.Text,
                        txtdescripcion.Text,
                        txtprecio.Text
                    });

                    MessageBox.Show("Se registró correctamente el servicio.");
                    Limpiar();

                }
                else
                {
                    MessageBox.Show("No se pudo registrar el servicio: " + mensaje);
                }
            }
            else
            {
                //Editar
                bool resultado = new CN_Servicio().Editar(obj, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(indiceSeleccionado)];
                    row.Cells["IdServicio"].Value = txtid.Text;
                    row.Cells["Codigo"].Value = txtcodigo.Text;
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Descripcion"].Value = txtdescripcion.Text;
                    row.Cells["Precio"].Value = txtprecio.Text; 

                    MessageBox.Show("Se editó correctamente el servicio.");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo editar el Servicio: " + mensaje);
                }
            }
        }

        private void Limpiar()
        {
            txtid.Text = "0";
            txtcodigo.Text = "";
            txtnombre.Text = "";
            
            txtdescripcion.Text = "";
            txtprecio.Text = "";
            txtbusqueda.Text = "";
            indiceSeleccionado = -1; // Reinicia el índice

        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtid.Text = "0";
            txtcodigo.Text = "";
            txtnombre.Text = "";
            txtdescripcion.Text = "";
            txtprecio.Text = "";
            txtbusqueda.Text = "";
            indiceSeleccionado = -1; // Reinicia el índice
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
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
                    txtid.Text = dgvdata.Rows[indice].Cells["IdServicio"].Value.ToString();
                    txtcodigo.Text = dgvdata.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();
                    txtprecio.Text = dgvdata.Rows[indice].Cells["Precio"].Value.ToString();

                }
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Deseas eliminar el servicio?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    Servicio obj = new Servicio()
                    {
                        IdServicio = Convert.ToInt32(txtid.Text)
                    };

                    bool resultado = new CN_Servicio().Eliminar(obj, out mensaje);

                    if (resultado)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(indiceSeleccionado));

                        MessageBox.Show("Se eliminó correctamente el servicio.");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el servicio: " + mensaje);
                    }
                }
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtprecio_TextChanged(object sender, EventArgs e)
        {

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
    }
}
