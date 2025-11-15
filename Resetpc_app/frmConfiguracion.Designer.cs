namespace Resetpc_app
{
    partial class frmConfiguracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Contenedor = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menucategoria = new System.Windows.Forms.ToolStripMenuItem();
            this.menucomponente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuservicios = new System.Windows.Forms.ToolStripMenuItem();
            this.menunegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.menumarcas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuso = new System.Windows.Forms.ToolStripMenuItem();
            this.menutipoconsola = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(225, 0);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(911, 551);
            this.Contenedor.TabIndex = 35;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 551);
            this.panel1.TabIndex = 34;
            // 
            // menucategoria
            // 
            this.menucategoria.Name = "menucategoria";
            this.menucategoria.Padding = new System.Windows.Forms.Padding(5);
            this.menucategoria.Size = new System.Drawing.Size(218, 34);
            this.menucategoria.Text = "Categoria";
            this.menucategoria.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menucategoria.Click += new System.EventHandler(this.menucategoria_Click);
            // 
            // menucomponente
            // 
            this.menucomponente.Name = "menucomponente";
            this.menucomponente.Padding = new System.Windows.Forms.Padding(5);
            this.menucomponente.Size = new System.Drawing.Size(218, 34);
            this.menucomponente.Text = "Componentes";
            this.menucomponente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menucomponente.Click += new System.EventHandler(this.menucomponente_Click);
            // 
            // menuservicios
            // 
            this.menuservicios.Name = "menuservicios";
            this.menuservicios.Padding = new System.Windows.Forms.Padding(5);
            this.menuservicios.Size = new System.Drawing.Size(218, 34);
            this.menuservicios.Text = "Servicios";
            this.menuservicios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuservicios.Click += new System.EventHandler(this.menuservicios_Click);
            // 
            // menunegocio
            // 
            this.menunegocio.Name = "menunegocio";
            this.menunegocio.Padding = new System.Windows.Forms.Padding(5);
            this.menunegocio.Size = new System.Drawing.Size(218, 34);
            this.menunegocio.Text = "Negocio";
            this.menunegocio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menunegocio.Click += new System.EventHandler(this.menunegocio_Click);
            // 
            // menumarcas
            // 
            this.menumarcas.Name = "menumarcas";
            this.menumarcas.Padding = new System.Windows.Forms.Padding(5);
            this.menumarcas.Size = new System.Drawing.Size(218, 34);
            this.menumarcas.Text = "Marcas";
            this.menumarcas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menumarcas.Click += new System.EventHandler(this.menumarcas_Click);
            // 
            // menuso
            // 
            this.menuso.Name = "menuso";
            this.menuso.Padding = new System.Windows.Forms.Padding(5);
            this.menuso.Size = new System.Drawing.Size(218, 34);
            this.menuso.Text = "SO";
            this.menuso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuso.Click += new System.EventHandler(this.menuso_Click);
            // 
            // menutipoconsola
            // 
            this.menutipoconsola.Name = "menutipoconsola";
            this.menutipoconsola.Padding = new System.Windows.Forms.Padding(5);
            this.menutipoconsola.Size = new System.Drawing.Size(218, 34);
            this.menutipoconsola.Text = "Tipos de Consola";
            this.menutipoconsola.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menucategoria,
            this.menucomponente,
            this.menuservicios,
            this.menunegocio,
            this.menumarcas,
            this.menuso,
            this.menutipoconsola});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 100, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(225, 551);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 30);
            this.label7.TabIndex = 34;
            this.label7.Text = "Configuracion";
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 551);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmConfiguracion";
            this.Text = "frmMenuConfiguracion";
            this.Load += new System.EventHandler(this.frmMenuConfiguracion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Contenedor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menucategoria;
        private System.Windows.Forms.ToolStripMenuItem menucomponente;
        private System.Windows.Forms.ToolStripMenuItem menuservicios;
        private System.Windows.Forms.ToolStripMenuItem menunegocio;
        private System.Windows.Forms.ToolStripMenuItem menumarcas;
        private System.Windows.Forms.ToolStripMenuItem menuso;
        private System.Windows.Forms.ToolStripMenuItem menutipoconsola;
    }
}