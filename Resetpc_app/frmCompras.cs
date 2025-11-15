using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Resetpc_app.Modales;
using Resetpc_app.Utilizades;

using CapaEntidad;
using CapaNegocio;

namespace Resetpc_app
{
    public partial class frmCompras : Form
    {
        public frmCompras()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.frmCompras_Load);
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            cbodocumento.Items.Clear();
            cbodocumento.Items.Add(new OpcionCombo() { Valor = "Recibo", Texto = "Recibo" });
            cbodocumento.Items.Add(new OpcionCombo() { Valor = "Factura", Texto = "Factura" });
            cbodocumento.DisplayMember = "Texto";
            cbodocumento.ValueMember = "Valor";
            cbodocumento.SelectedIndex = 0;

            txtfecha.Text = DateTime.Now.ToString("MM/dd/yyyy");

            txtidproveedor.Text = "0";
            txtidcomponente.Text = "0";

        }

        private void btnbuscarrfc_Click(object sender, EventArgs e)
        {
            using (var modal = new mdProveedor())   
            { 
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtidproveedor.Text = modal._Proveedor.IdProveedor.ToString();
                    txtrfc.Text = modal._Proveedor.RFC;
                    txtrazonsocial.Text = modal._Proveedor.RazonSocial;
                }
                else
                {
                    txtrfc.Select();
                }
            }
        }

        private void btnagregarcomponente_Click_1(object sender, EventArgs e)
        {
            using (var modal = new mdAgregarComponente()) 
            { 
                var result = modal.ShowDialog();

                if (result == DialogResult.OK) {
                    txtidcomponente.Text = modal._Componente.IdComponente.ToString();
                    txtcodcomponente.Text = modal._Componente.Codigo;
                    txtcomponente.Text = modal._Componente.Nombre;
                }

            }
        }

        private void btnbuscarcomponente_Click(object sender, EventArgs e)
        {
            using (var modal = new mdComponente())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtidcomponente.Text = modal._Componente.IdComponente.ToString();
                    txtcodcomponente.Text = modal._Componente.Codigo;
                    txtcomponente.Text = modal._Componente.Nombre;
                }
                else
                {
                   txtcodcomponente.Select();
                }
            }
        }

        private void txtcodcomponente_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                Componente oComponente = new CN_Componente().Listar().Where(c => c.Codigo == txtcodcomponente.Text && c.Estado == true).FirstOrDefault();

                if(oComponente != null)
                {
                    txtcodcomponente.BackColor = Color.Honeydew;
                    txtidcomponente.Text = oComponente.IdComponente.ToString();
                    txtcodcomponente.Text = oComponente.Codigo;
                    txtcomponente.Text = oComponente.Nombre;
                    txtpreciounitario.SelectAll();

                }
                else
                {
                    txtcodcomponente.BackColor = Color.MistyRose;
                    MessageBox.Show("El componente no existe o no esta activo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtidcomponente.Text = "0";
                    txtcodcomponente.Text = "";
                    txtcodcomponente.SelectAll();
                    txtcodcomponente.Focus();
                }

            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            decimal precioUnitario = 0;
            decimal precioVenta = 0;
            bool producto_existe = false;

           

            if (txtidproveedor.Text == "0")
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnbuscarrfc.Select();
                return;
            }
            if (txtidcomponente.Text == "0")
            {
                MessageBox.Show("Debe seleccionar un componente", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnbuscarcomponente.Select();
                return;
            }
            if (!decimal.TryParse(txtpreciounitario.Text, out precioUnitario))
            {
                MessageBox.Show("El precio unitario no es correcto", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtpreciounitario.SelectAll();
                txtpreciounitario.Focus();
                return;
            }
            if (!decimal.TryParse(txtprecioventa.Text, out precioVenta))
            {
                MessageBox.Show("El precio de venta no es correcto", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtprecioventa.SelectAll();
                txtprecioventa.Focus();
                return;
            }
            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                if (fila.Cells["IdComponente"].Value.ToString() == txtidcomponente.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            

            if (!producto_existe)
            {
                decimal cantidad = txtcantidad.Value;
                decimal TasaIVA = decimal.Parse(txtTasaIVA.Text);
                decimal subtotal = txtcantidad.Value * precioUnitario ;
                decimal ivaCalculado = subtotal * TasaIVA;
                decimal total = subtotal + ivaCalculado;

                dgvdata.Rows.Add(new object[] {
                    txtidcomponente.Text, //IdComponente
                    txtcomponente.Text, //NombreComponente
                    txtcantidad.Value.ToString(), //Cantidad
                    precioUnitario.ToString("0.00"), //PrecioCompra
                    txtTasaIVA.Text, //Tasa de IVA
                    precioVenta.ToString("0.00"), //PrecioVenta
                    ivaCalculado.ToString("0.00"), //IVACalculado
                    subtotal.ToString(), //SubTotal
                    total.ToString("0.00") //Total

                });

                calcularTotal();
                calcularIVATotal();
                limpiarComponente();
                txtcodcomponente.Select();
            }



        }

        private void limpiarComponente()
        {
            txtidcomponente.Text = "0";
            txtcodcomponente.Text = "";
            txtcomponente.Text = "";
            txtcantidad.Value = 1;
            txtpreciounitario.Text = "";
            txtprecioventa.Text = "";
            txtTasaIVA.Text = "0.16";
            txtcodcomponente.BackColor = Color.White;
        }

        private void calcularIVATotal()
        {
            decimal totalIVA = 0;

            if (dgvdata.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvdata.Rows)
                {
                    totalIVA += Convert.ToDecimal(fila.Cells["IVACalculado"].Value);
                }
                txtivatotal.Text = totalIVA.ToString("0.00");
            }
        }

        private void calcularTotal()
        {
            decimal total = 0;
            calcularIVATotal();

            if (dgvdata.Rows.Count > 0) 
            {
                foreach (DataGridViewRow fila in dgvdata.Rows)
                {
                    total += Convert.ToDecimal(fila.Cells["SubTotal"].Value);
                }
                txtsubtotal.Text = total.ToString("0.00");
                decimal ivaTotal = Convert.ToDecimal(txtivatotal.Text);
                decimal totalAPagar = total + ivaTotal;

                txttotalpagar.Text = totalAPagar.ToString("0.00");
            }
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 9)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);


                // Tamaño deseado (ajustado a la celda)
                int w = 20;
                int h = 20;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.Borrar1, new Rectangle(x, y, w, h));
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
                    dgvdata.Rows.RemoveAt(indice);
                    calcularTotal();

                }
            }
        }

        private void txtpreciounitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                    e.Handled = false;
            }
            else
            {
                if(txtpreciounitario.Text.Trim().Length == 0 && e.KeyChar == '.')
                {
                    e.Handled = true;
                }
                else
                {
                    if(Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".") 
                    { 
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtprecioventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtprecioventa.Text.Trim().Length == 0 && e.KeyChar == '.')
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (txtidproveedor.Text == "0")
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnbuscarrfc.Select();
                return;
            }
            if (dgvdata.Rows.Count < 1)
            {
                MessageBox.Show("Debe agregar al menos un componente en la compra", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnbuscarcomponente.Select();
                return;
            }
            DataTable detalle_compra = new DataTable();

            detalle_compra.Columns.Add("IdComponente", typeof(int));
            detalle_compra.Columns.Add("Cantidad", typeof(int));
            detalle_compra.Columns.Add("PrecioUnitario", typeof(decimal));
            detalle_compra.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_compra.Columns.Add("TasaIVA", typeof(decimal));
            detalle_compra.Columns.Add("IVACalculado", typeof(decimal));
            detalle_compra.Columns.Add("SubTotal", typeof(decimal));
            detalle_compra.Columns.Add("MontoTotal", typeof(decimal));

            foreach (DataGridViewRow fila in dgvdata.Rows)
            {
                detalle_compra.Rows.Add(
                    new object[] {
                        Convert.ToInt32(fila.Cells["IdComponente"].Value.ToString()),
                        fila.Cells["Cantidad"].Value.ToString(),
                        fila.Cells["PrecioUnitario"].Value.ToString(),
                        fila.Cells["PrecioVenta"].Value.ToString(),
                        fila.Cells["TasaIVA"].Value.ToString(),
                        fila.Cells["IVACalculado"].Value.ToString(),
                        fila.Cells["SubTotal"].Value.ToString(),
                        fila.Cells["Total"].Value.ToString()
                    });

            }
            int idcorrelativo = new CN_Compra().ObtenerCorrelativo();
            string numerodocumento = string.Format("{0:00000}", idcorrelativo);

            Compra oCompra = new Compra()
            {
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txtidproveedor.Text) },
                Tipo_Documento = ((OpcionCombo)cbodocumento.SelectedItem).Texto,
                NumeroDocumento = numerodocumento,
                MontoTotal = Convert.ToDecimal(txttotalpagar.Text),
                Subtotal = Convert.ToDecimal(txtsubtotal.Text),
                IVATotal = Convert.ToDecimal(txtivatotal.Text)

            };

            string mensaje = string.Empty;
            bool respuesta = new CN_Compra().Registrar(oCompra, detalle_compra, out mensaje);


            if (respuesta)
            {
                var result = MessageBox.Show("Numero de compra generada: \n" + numerodocumento + 
                    "\n\n¿Desea copiar al portapapeles?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    Clipboard.SetText(numerodocumento);
                }



                txtidproveedor.Text = "0";
                txtrfc.Text = "";
                txtrazonsocial.Text = "";
                txtfecha.Text = DateTime.Now.ToString("MM/dd/yyyy");
                dgvdata.Rows.Clear();
                calcularTotal();

            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
