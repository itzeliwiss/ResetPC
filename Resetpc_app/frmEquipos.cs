using CapaEntidad;
using CapaNegocio;
using Resetpc_app.Modales;
using Resetpc_app.Utilizades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Resetpc_app
{
    public partial class frmEquipos : Form
    {
        private int indiceSeleccionado = -1;
        public frmEquipos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            using (var modal = new mdCliente())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtidcliente.Text = modal._Cliente.IdCliente.ToString();
                    txtnombrecliente.Text = modal._Cliente.NombreCompleto;
                }
                else
                {
                    txtnombrecliente.Select();
                }
            }
        }

        private void frmEquipos_Load(object sender, EventArgs e)
        {
          

            cbotipodisco.Items.Add(new OpcionCombo() { Valor = "SSD", Texto = "SSD" });
            cbotipodisco.Items.Add(new OpcionCombo() { Valor = "HDD", Texto = "HDD" });
            cbotipodisco.DisplayMember = "Texto";
            cbotipodisco.ValueMember = "Valor";
            cbotipodisco.SelectedIndex = 0;

            cbotipoequipo.Items.Add(new OpcionCombo() { Valor = "Laptop", Texto = "Laptop" });
            cbotipoequipo.Items.Add(new OpcionCombo() { Valor = "Escritorio", Texto = "Escritorio" });
            cbotipoequipo.DisplayMember = "Texto";
            cbotipoequipo.ValueMember = "Valor";
            cbotipoequipo.SelectedIndex = 0;

            foreach (Marca item in new CN_Marca().Listar())
            {
                cbomarca.Items.Add(new OpcionCombo() { Valor = item.IdMarca, Texto = item.NombreMarca });
            }
            cbomarca.DisplayMember = "Texto";
            cbomarca.ValueMember = "Valor";
            cbomarca.SelectedIndex = 0;

            foreach (SO item in new CN_SO().Listar())
            {
                cboSO.Items.Add(new OpcionCombo() { Valor = item.IdSO, Texto = item.NombreSO });
            }
            cboSO.DisplayMember = "Texto";
            cboSO.ValueMember = "Valor";
            cboSO.SelectedIndex = 0;


            

            //MOSTRAR LAS TODOS LOS EQUIPOS EN LA TABLA 
            List<Equipo> listaEquipo = new CN_Equipo().Listar();


            foreach (Equipo item in listaEquipo)
            {
                dgvdata.Rows.Add(new object[] {
                    "",
                    item.IdEquipo,
                    item.oCliente.IdCliente,
                    item.oCliente.NombreCompleto,
                    item.Tipo,
                    item.oMarca.IdMarca,
                    item.oMarca.NombreMarca,
                    item.Modelo,
                    item.Almacenamiento,
                    item.TipoDisco,
                    item.Ram,
                    item.Procesador,
                    item.oOS.IdSO,
                    item.oOS.NombreSO,
                    item.NumeroSerie,
                    item.Descripcion
                });
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Equipo obj = new Equipo()
            {
                IdEquipo = Convert.ToInt32(txtid.Text),
                oCliente = new Cliente() { 
                    IdCliente = Convert.ToInt32(txtidcliente.Text),
                    NombreCompleto = txtnombrecliente.Text
                },
                Tipo = ((OpcionCombo)cbotipoequipo.SelectedItem).Valor.ToString(),
                oMarca = new Marca() { 
                    IdMarca = Convert.ToInt32(((OpcionCombo)cbomarca.SelectedItem).Valor),
                    NombreMarca = ((OpcionCombo)cbomarca.SelectedItem).Texto
                },
                Modelo = txtmodelo.Text,
                Almacenamiento = txtalmacenamiento.Text,
                TipoDisco = ((OpcionCombo)cbotipodisco.SelectedItem).Valor.ToString(),
                Ram = txtram.Text,
                Procesador = txtprocesador.Text,
                NumeroSerie = txtnumeroserie.Text,
                Descripcion = txtdescripcion.Text,
                oOS = new SO()
                {
                    IdSO = Convert.ToInt32(((OpcionCombo)cboSO.SelectedItem).Valor),
                    NombreSO = ((OpcionCombo)cboSO.SelectedItem).Texto
                }

            };

            if (obj.IdEquipo == 0)
            {
                //REGISTRAR EQUIPO
                int idGenerado = new CN_Equipo().Registrar(obj, out mensaje);
                if (idGenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {
                        "",
                        idGenerado,
                        txtidcliente.Text,
                        txtnombrecliente.Text,
                        ((OpcionCombo)cbotipoequipo.SelectedItem).Valor.ToString(),

                        ((OpcionCombo)cbomarca.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cbomarca.SelectedItem).Texto.ToString(),

                        txtmodelo.Text,
                        txtalmacenamiento.Text,
                        ((OpcionCombo)cbotipodisco.SelectedItem).Valor.ToString(),
                        txtram.Text,
                        txtprocesador.Text,
                        

                        ((OpcionCombo)cboSO.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cboSO.SelectedItem).Texto.ToString(),
                        txtnumeroserie.Text,

                        txtdescripcion.Text
                    });

                    MessageBox.Show("Se registró correctamente el equipo");
                    Limpiar();

                }
                else
                {
                    MessageBox.Show("No se pudo registrar el equipo: " + mensaje);
                }


            }
            else
            {
                //Editar
                bool resultado = new CN_Equipo().Editar(obj, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(indiceSeleccionado)];
                    row.Cells["IdEquipo"].Value = obj.IdEquipo;
                    row.Cells["IdCliente"].Value = obj.oCliente.IdCliente;
                    row.Cells["Cliente"].Value = obj.oCliente.NombreCompleto;
                    row.Cells["Tipo"].Value = ((OpcionCombo)cbotipoequipo.SelectedItem).Valor.ToString();
                    row.Cells["IdMarca"].Value = ((OpcionCombo)cbomarca.SelectedItem).Valor.ToString();
                    row.Cells["Marca"].Value = ((OpcionCombo)cbomarca.SelectedItem).Texto.ToString();
                    row.Cells["Modelo"].Value = txtmodelo.Text;
                    row.Cells["Almacenamiento"].Value = txtalmacenamiento.Text;
                    row.Cells["TipoDisco"].Value = ((OpcionCombo)cbotipodisco.SelectedItem).Valor.ToString();
                    row.Cells["Ram"].Value = txtram.Text;
                    row.Cells["Procesador"].Value = txtprocesador.Text;
                    row.Cells["IdSO"].Value = ((OpcionCombo)cboSO.SelectedItem).Valor.ToString();
                    row.Cells["SistemaOperativo"].Value = ((OpcionCombo)cboSO.SelectedItem).Texto.ToString();

                    row.Cells["NumeroSerie"].Value = txtnumeroserie.Text;
                    
                    MessageBox.Show("Se editó correctamente el equipo.");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se pudo editar el equipo: " + mensaje);
                }
            }



        }

        private void Limpiar()
        {
            txtid.Text = "0";
            txtidcliente.Text = "0";
            txtnombrecliente.Text = "";
            cbotipoequipo.SelectedIndex = 0;
            cbomarca.SelectedIndex = 0;
            txtmodelo.Text = "";
            cboSO.SelectedIndex = 0;
            txtprocesador.Text = "";
            txtalmacenamiento.Text = "";
            cbotipodisco.SelectedIndex = 0;
            txtram.Text = "";
            txtnumeroserie.Text = "";
            txtdescripcion.Text = "";
            indiceSeleccionado = -1; // Reinicia el índice

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtid.Text = "0";
            txtidcliente.Text = "0";
            txtnombrecliente.Text = "";
            cbotipoequipo.SelectedIndex = 0;
            cbomarca.SelectedIndex = 0;
            txtmodelo.Text = "";
            cboSO.SelectedIndex = 0;
            txtprocesador.Text = "";
            txtalmacenamiento.Text = "";
            cbotipodisco.SelectedIndex = 0;
            txtram.Text = "";
            txtnumeroserie.Text = "";
            txtdescripcion.Text = "";
            indiceSeleccionado = -1; // Reinicia el índice
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿Deseas eliminar el equipo?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;

                    Equipo obj = new Equipo()
                    {
                        IdEquipo = Convert.ToInt32(txtid.Text)
                    };

                    bool resultado = new CN_Equipo().Eliminar(obj, out mensaje);

                    if (resultado)
                    {
                        dgvdata.Rows.RemoveAt(Convert.ToInt32(indiceSeleccionado));

                        MessageBox.Show("Se eliminó correctamente el equipo.");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el equipo " + mensaje);
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
                    txtid.Text = dgvdata.Rows[indice].Cells["IdEquipo"].Value.ToString();
                    txtidcliente.Text = dgvdata.Rows[indice].Cells["IdCliente"].Value.ToString();
                    txtnombrecliente.Text = dgvdata.Rows[indice].Cells["Cliente"].Value.ToString();
                    txtmodelo.Text = dgvdata.Rows[indice].Cells["Modelo"].Value.ToString();
                    txtprocesador.Text = dgvdata.Rows[indice].Cells["Procesador"].Value.ToString();
                    txtalmacenamiento.Text = dgvdata.Rows[indice].Cells["Almacenamiento"].Value.ToString();
                    txtram.Text = dgvdata.Rows[indice].Cells["Ram"].Value.ToString();
                    txtnumeroserie.Text = dgvdata.Rows[indice].Cells["NumeroSerie"].Value.ToString();
                    txtdescripcion.Text = dgvdata.Rows[indice].Cells["Descripcion"].Value.ToString();

                    foreach (OpcionCombo oc in cbotipoequipo.Items)
                    {
                        if (oc.Valor.ToString() == dgvdata.Rows[indice].Cells["Tipo"].Value.ToString())
                        {
                            int indice_combo = cbotipoequipo.Items.IndexOf(oc);
                            cbotipoequipo.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionCombo oc in cbomarca.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdMarca"].Value))
                        {
                            int indice_combo = cbomarca.Items.IndexOf(oc);
                            cbomarca.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionCombo oc in cboSO.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["IdSO"].Value))
                        {
                            int indice_combo = cboSO.Items.IndexOf(oc);
                            cboSO.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionCombo oc in cbotipodisco.Items)
                    {
                        if (oc.Valor.ToString() == dgvdata.Rows[indice].Cells["TipoDisco"].Value.ToString())
                        {
                            int indice_combo = cbotipodisco.Items.IndexOf(oc);
                            cbotipodisco.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                   

                }
            }
        }
    }
}
