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
    public partial class mdAgregarComponente : Form
    {

        public Componente _Componente { get; set; }
        public mdAgregarComponente()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.frmAgregarComponente_Load);
        }

        private void frmAgregarComponente_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;

            List<Componente> lista = new CN_Componente().Listar();

            foreach (Categoria item in new CN_Categoria().Listar())
            {
                cbocategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }
            cbocategoria.DisplayMember = "Texto";
            cbocategoria.ValueMember = "Valor";
            cbocategoria.SelectedIndex = 0;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Componente obj = new Componente()
            {
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
                //Registar 
                int idGenerado = new CN_Componente().Registrar(obj, out mensaje);
                if (idGenerado != 0)
                {
                    MessageBox.Show("Se registró correctamente el componente: " + mensaje);
                    Limpiar();
                    this.Close(); // Cerramos el formulario

                    _Componente = new Componente()
                    {
                        IdComponente = idGenerado,
                        Codigo = obj.Codigo,
                        Nombre = obj.Nombre
                    };
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el componente: " + mensaje);
                }
            }
            
        }
        private void Limpiar()
        {
            
            txtcodigo.Text = "";
            txtnombre.Text = "";
            cbocategoria.SelectedIndex = 0;
            txtdescripcion.Text = "";
            cboestado.SelectedIndex = 0;
            

        }

        
    }
}
