using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.IO;
using CapaEntidad;

namespace Resetpc_app
{
    public partial class frmNegocio : Form
    {
        public frmNegocio()
        {
            InitializeComponent();
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = new Bitmap(ms);

            return image;
        }

        private void frmNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] byteimage = new CN_Negocio().ObtenerLogo(out obtenido);

            if (obtenido)
                picLogo.Image = ByteToImage(byteimage);
                
            Negocio datos = new CN_Negocio().ObtenerDatos();

            txtrazonsocial.Text = datos.RazonSocial;
            txtrfc.Text = datos.RFC;
            txtdireccion.Text = datos.Direccion;
            txttelefono.Text = datos.Telefono;

        }

        private void btnsubir_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.FileName = "Files |*.jpg;*.jpeg;*.png";

            if(oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] byteimagen = File.ReadAllBytes(oOpenFileDialog.FileName);
                bool respuesta = new CN_Negocio().ActualizarLogo(byteimagen, out mensaje);

                if(respuesta)
                    picLogo.Image = ByteToImage(byteimagen);
                else
                    MessageBox.Show(mensaje, "Error al actualizar logo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Negocio obj = new Negocio()
            {
                RazonSocial = txtrazonsocial.Text,
                RFC = txtrfc.Text,
                Direccion = txtdireccion.Text,
                Telefono = txttelefono.Text
            };
            bool respuesta = new CN_Negocio().GuardarDatos(obj, out mensaje);
            if (respuesta)
            {
                MessageBox.Show("Los cambios fueron guardados.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Error al guardar datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
