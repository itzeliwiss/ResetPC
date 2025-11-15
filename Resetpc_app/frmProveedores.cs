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

namespace Resetpc_app
{
    public partial class frmProveedores : Form
    {
        private int indiceSeleccionado = -1;

        public frmProveedores()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.frmProveedor_Load);
        }

        private void frmProveedor_Load(object sender, EventArgs e) 
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            List<Proveedor> lista = new CN_Proveedor().Listar();

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



            //MOSTRAR LAS TODOS LOS PROVEEDORES EN LA TABLA 
            List<Proveedor> listaProveedor = new CN_Proveedor().Listar();


            foreach (Proveedor item in listaProveedor)
            {
                dgvdata.Rows.Add(new object[] {
                    "",
                    item.IdProveedor,
                    item.RazonSocial,
                    item.RFC,
                    item.Telefono,
                    item.Correo,
                    item.Direccion,
                    item.Estado == true ? "Activo" : "No Activo",
                    item.Estado == true ? 1 : 0

                });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Proveedor obj = new Proveedor()
            {
                IdProveedor = Convert.ToInt32(txtid.Text),
                RazonSocial = txtrazonsocial.Text.Trim(),
                RFC = txtrfc.Text.Trim(),
                Telefono = txttelefono.Text,
                Correo = txtcorreo.Text,
                Direccion = txtdireccion.Text.Trim(),
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };


            if (obj.IdProveedor == 0)
            {
                //Registrar
                int idGenerado = new CN_Proveedor().Registrar(obj, out mensaje);

                if (idGenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {
                        "",
                        idGenerado,
                        txtrazonsocial.Text,
                        txtrfc.Text,
                        txttelefono.Text,
                        txtcorreo.Text,
                        txtdireccion.Text,
                        ((OpcionCombo)cboestado.SelectedItem).Texto.ToString(),
                        ((OpcionCombo)cboestado.SelectedItem).Valor.ToString()
                    });

                    MessageBox.Show("Se registró correctamente el proveedor: " + mensaje);
                    Limpiar();

                }
                else
                {
                    MessageBox.Show("No se pudo registrar el proveedor: " + mensaje);
                }
            }
            else
            {
                //Editar
                bool resultado = new CN_Proveedor().Editar(obj, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(indiceSeleccionado)];
                    row.Cells["IdProveedor"].Value = obj.IdProveedor;
                    row.Cells["RazonSocial"].Value = txtrazonsocial.Text;
                    row.Cells["RFC"].Value = txtrfc.Text;
                    row.Cells["Telefono"].Value = txttelefono.Text;
                    row.Cells["Correo"].Value = txtcorreo.Text;
                    row.Cells["Direccion"].Value = txtdireccion.Text;
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    MessageBox.Show("Se editó correctamente el proveedor.");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo editar el proveedor: " + mensaje);
                }
            }
        }

        private void Limpiar()
        {
            txtid.Text = "0";
            txtrazonsocial.Text = "";
            txtrfc.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            txtdireccion.Text = "";
            cboestado.SelectedIndex = 0;
            indiceSeleccionado = -1; // Reinicia el índice

        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            foreach (DataGridViewRow row in dgvdata.Rows)
            {
                row.Visible = true; // Mostrar todas las filas
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtid.Text = "0";
            txtrazonsocial.Text = "";
            txtrfc.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            txtdireccion.Text = "";
            cboestado.SelectedIndex = 0;
            indiceSeleccionado = -1; // Reinicia el índice
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Deseas eliminar el proveedor?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    Proveedor obj = new Proveedor()
                    {
                        IdProveedor = Convert.ToInt32(txtid.Text)
                    };

                    bool resultado = new CN_Proveedor().Eliminar(obj, out mensaje);

                    if (resultado)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(indiceSeleccionado));

                        MessageBox.Show("Se eliminó correctamente el proveedor.");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el proveedor: " + mensaje);
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
                    txtid.Text = dgvdata.Rows[indice].Cells["IdProveedor"].Value.ToString();
                    txtrazonsocial.Text = dgvdata.Rows[indice].Cells["RazonSocial"].Value.ToString();
                    txtrfc.Text = dgvdata.Rows[indice].Cells["RFC"].Value.ToString();
                    txttelefono.Text = dgvdata.Rows[indice].Cells["Telefono"].Value.ToString();
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtdireccion.Text = dgvdata.Rows[indice].Cells["Direccion"].Value.ToString();

                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboestado.Items.IndexOf(oc);
                            cboestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }



                }
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
    }
}
