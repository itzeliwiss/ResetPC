using CapaEntidad;
using CapaNegocio;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace Resetpc_app
{
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Compra oCompra = new CN_Compra().ObtenerCompra(txtbusqueda.Text);

            if (oCompra.IdCompra != 0)
            {
                txtnumerodocumento.Text = oCompra.NumeroDocumento;
                txtfecha.Text = oCompra.FechaRegistro;
                txttipodocumento.Text = oCompra.Tipo_Documento;
                txtrfc.Text = oCompra.oProveedor.RFC;
                txtrazonsocial.Text = oCompra.oProveedor.RazonSocial;
                


            }
            else
            {
                MessageBox.Show("No se encontró la compra con el número de documento especificado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtbusqueda.Text = "";
                txtnumerodocumento.Text = "";
                txtfecha.Text = "";
                txttipodocumento.Text = "";
                txtrfc.Text = "";
                txtrazonsocial.Text = "";
            }

            dgvdata.Rows.Clear();

            if (oCompra != null && oCompra.oDetalleCompra != null && oCompra.oDetalleCompra.Count > 0)
            {
                foreach (Detalle_Compra dc in oCompra.oDetalleCompra)
                {
                    dgvdata.Rows.Add(new object[]
                    {
                        dc.oComponente.Nombre,
                        dc.Cantidad,
                        dc.PrecioUnitario,
                        dc.IVACalculado,
                        dc.Subtotal,
                        dc.MontoTotal
                    });
                }

                txtmontototal.Text = oCompra.MontoTotal.ToString("0.00");
            }
            else
            {
                // Opcional: limpiar campos o dejar en blanco
                txtmontototal.Text = "0.00";
            }

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            txtnumerodocumento.Text = "";
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtrfc.Text = "";
            txtrazonsocial.Text = "";
            txtmontototal.Text = "0.00";
            dgvdata.Rows.Clear();
        }

        private void txtpdf_Click(object sender, EventArgs e)
        {
            if(txttipodocumento.Text == "")
            {
                MessageBox.Show("Debe buscar una compra primero.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            string Texto_html = Properties.Resources.PlantillaCompra;
            Negocio odatos = new CN_Negocio().ObtenerDatos();

            Texto_html = Texto_html.Replace("@RazonSocial", odatos.RazonSocial.ToUpper());
            Texto_html = Texto_html.Replace("@RFCNegocio", odatos.RFC);
            Texto_html = Texto_html.Replace("@Direccion", odatos.Direccion);
            Texto_html = Texto_html.Replace("@Telefono", odatos.Telefono);

            Texto_html = Texto_html.Replace("@tipodocumento", txttipodocumento.Text.ToUpper());
            Texto_html = Texto_html.Replace("@numerodocumento", txtnumerodocumento.Text);

            Texto_html = Texto_html.Replace("@RFCProveedor", txtrfc.Text);
            Texto_html = Texto_html.Replace("@nombreproveedor", txtrazonsocial.Text);
            Texto_html = Texto_html.Replace("@fecharegistro", txtfecha.Text);

            
            Compra oCompra = new CN_Compra().ObtenerCompra(txtnumerodocumento.Text);

            Texto_html = Texto_html.Replace("@SubTotal", oCompra.Subtotal.ToString());
            Texto_html = Texto_html.Replace("@Impuesto", oCompra.IVATotal.ToString());


           foreach (Detalle_Compra item in oCompra.oDetalleCompra)
            {
                Texto_html = Texto_html.Replace("@TasaIVA", $"{(Convert.ToDecimal(item.TasaIVA) * 100).ToString("0")}%");

            }


            string filas = string.Empty;
            foreach(DataGridViewRow fila in dgvdata.Rows)
            {
                filas += "<tr>";
                filas += $"<td style='padding:5px; border: 2px solid white; text-align: center;'>{fila.Cells["Componente"].Value}</td>"; // Nombre del componente
                filas += $"<td style='padding:5px; border: 2px solid white; text-align: center;'>{fila.Cells["Cantidad"].Value}</td>"; // Cantidad
                filas += $"<td style='padding:5px; border: 2px solid white; text-align: center;'>{fila.Cells["PrecioUnitario"].Value}</td>"; // Precio unitario
                filas += $"<td style='padding:5px; border: 2px solid white; text-align: center;'>{fila.Cells["IVACalculado"].Value}</td>"; // IVA calculado
                filas += $"<td style='padding:5px; border: 2px solid white; text-align: center;'>{fila.Cells["Total"].Value}</td>"; // Subtotal
                filas += "</tr>";
            }

            Texto_html = Texto_html.Replace("@filas", filas);

            

            Texto_html = Texto_html.Replace("@MontoTotal", txtmontototal.Text);

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = string.Format("Compra_{0}.pdf", txtnumerodocumento.Text);
            saveFile.Filter = "Pdf Files |*.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    bool obtenido = true;
                    byte[] byteImage = new CN_Negocio().ObtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleAbsolute(70,70);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51)); // ✅ Corregido
                        pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(Texto_html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();

                    MessageBox.Show("PDF generado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); // ✅ Corregido
                }
            }




        }
    }
}
