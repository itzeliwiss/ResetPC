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
using ClosedXML.Excel;
using Resetpc_app.Utilizades;


namespace Resetpc_app
{
    public partial class frmComponentes : Form
    {

        private int indiceSeleccionado = -1;
        public frmComponentes()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.frmComponente_Load);
        }


        private void frmComponente_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            List<Componente> lista = new CN_Componente().Listar();

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

            foreach (Categoria item in new CN_Categoria().Listar())
            {
                cbocategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }
            cbocategoria.DisplayMember = "Texto";
            cbocategoria.ValueMember = "Valor";
            cbocategoria.SelectedIndex = 0;



            //MOSTRAR LAS TODOS LOS COMPONENTES EN LA TABLA 
            List<Componente> listaComponente = new CN_Componente().Listar();


            foreach (Componente item in listaComponente)
            {
                dgvdata.Rows.Add(new object[] {
                    "",
                    item.IdComponente,
                    item.Codigo,
                    item.Nombre,
                    item.oCategoria.Descripcion, //Categoria
                    item.oCategoria.IdCategoria, // Id Categoría
                    item.Descripcion,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta,
                    item.Estado == true ? "Activo" : "No Activo",
                    item.Estado == true ? 1 : 0

                });
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

        //BOTON DE GUARDAR
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Componente obj = new Componente()
            {
                IdComponente = Convert.ToInt32(txtid.Text),
                Codigo = txtcodigo.Text,
                Nombre = txtnombre.Text,
                oCategoria = new Categoria()
                {
                    IdCategoria = Convert.ToInt32(((OpcionCombo)cbocategoria.SelectedItem).Valor),
                    Descripcion = ((OpcionCombo)cbocategoria.SelectedItem).Texto
                },
                Descripcion = txtdescripcion.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };


            if (obj.IdComponente == 0)
            {
                //Registrar
                int idGenerado = new CN_Componente().Registrar(obj, out mensaje);

                if (idGenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {
                        "",
                        idGenerado,
                        txtcodigo.Text,
                        txtnombre.Text,
                        ((OpcionCombo)cbocategoria.SelectedItem).Texto.ToString(),
                        ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString(),
                        txtdescripcion.Text,
                        "0", // Stock inicial
                        "0.00", // Precio de compra
                        "0.00", // Precio de venta 
                        ((OpcionCombo)cboestado.SelectedItem).Texto.ToString(),
                        ((OpcionCombo)cboestado.SelectedItem).Valor.ToString()
                    });

                    MessageBox.Show("Se registró correctamente el componente: " + mensaje);
                    Limpiar();

                }
                else
                {
                    MessageBox.Show("No se pudo registrar el componente: " + mensaje);
                }
            }
            else
            {
                //Editar
                bool resultado = new CN_Componente().Editar(obj, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(indiceSeleccionado)];
                    row.Cells["IdCategoria"].Value = txtid.Text;
                    row.Cells["Codigo"].Value = txtcodigo.Text;
                    row.Cells["Nombre"].Value = txtnombre.Text;
                    row.Cells["Categoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).Texto.ToString();
                    row.Cells["IdCategoria"].Value = ((OpcionCombo)cbocategoria.SelectedItem).Valor.ToString();
                    row.Cells["Descripcion"].Value = txtdescripcion.Text;
                    //row.Cells[row.Cells["Stock"].ColumnIndex].Value = "0"; // Stock inicial
                   // row.Cells[row.Cells["PrecioCompra"].ColumnIndex].Value = "0.00"; // Precio de compra
                   // row.Cells[row.Cells["PrecioVenta"].ColumnIndex].Value = "0.00"; // Precio de venta
                    row.Cells["Estado"].Value = ((OpcionCombo)cboestado.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)cboestado.SelectedItem).Valor.ToString();
                    MessageBox.Show("Se editó correctamente el componente.");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo editar el componente: " + mensaje);
                }
            }
        }

        private void Limpiar()
        {
            txtid.Text = "0";
            txtcodigo.Text = "";
            txtnombre.Text = "";
            cbocategoria.SelectedIndex = 0;
            txtdescripcion.Text = "";
            cboestado.SelectedIndex = 0;
            indiceSeleccionado = -1; // Reinicia el índice

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            indiceSeleccionado = -1; // Reinicia el índice
            txtid.Text = "0";
            txtcodigo.Text = "";
            txtnombre.Text = "";
            cbocategoria.SelectedIndex = 0;
            txtdescripcion.Text = "";
            cboestado.SelectedIndex = 0;

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Deseas eliminar el componente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    Componente obj = new Componente()
                    {
                        IdComponente = Convert.ToInt32(txtid.Text)
                    };

                    bool resultado = new CN_Componente().Eliminar(obj, out mensaje);

                    if (resultado)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(indiceSeleccionado));

                        MessageBox.Show("Se eliminó correctamente el componente.");
                        Limpiar(); 
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el componente " + mensaje);
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
                    txtid.Text = dgvdata.Rows[indice].Cells["IdComponente"].Value.ToString();
                    txtcodigo.Text = dgvdata.Rows[indice].Cells["Codigo"].Value.ToString();
                    txtnombre.Text = dgvdata.Rows[indice].Cells["Nombre"].Value.ToString();     
                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();
                    

                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboestado.Items.IndexOf(oc);
                            cboestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionCombo oc in cbocategoria.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdCategoria"].Value))
                        {
                            int indice_combo = cbocategoria.Items.IndexOf(oc);
                            cbocategoria.SelectedIndex = indice_combo;
                            break;
                        }
                    }


                }
            }
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if(dgvdata.Rows.Count < 1) 
            {

                MessageBox.Show("No hay datos para exportar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn columna in dgvdata.Columns)
                {
                    if(columna.HeaderText != "" && columna.Visible) 
                    { 
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                    }
                }


                foreach (DataGridViewRow row in dgvdata.Rows)
                {
                    if (row.Visible) 
                    { 
                        dt.Rows.Add(new object[]
                        {
                           row.Cells[2].Value.ToString(),
                           row.Cells[3].Value.ToString(),
                           row.Cells[4].Value.ToString(),
                           row.Cells[6].Value.ToString(),
                           row.Cells[7].Value.ToString(),
                           row.Cells[8].Value.ToString(),
                           row.Cells[9].Value.ToString(),
                           row.Cells[10].Value.ToString(),
                           
                           
                        });
                    }
                }

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = string.Format("ReporteComponentes_{0}.xlsx", DateTime.Now.ToString("dd-MM-yyyy-HH'h'_mm'm'_ss's'"));
                saveFile.Filter = "Excel Files | *.xlsx";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt,"Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("No se pudo generar el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void frmComponentes_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
