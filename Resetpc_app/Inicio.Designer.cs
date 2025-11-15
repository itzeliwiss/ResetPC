namespace Resetpc_app
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menumantenedor = new FontAwesome.Sharp.IconMenuItem();
            this.menuservicios = new FontAwesome.Sharp.IconMenuItem();
            this.submenuregistrarventa = new FontAwesome.Sharp.IconMenuItem();
            this.submenudetalleventa = new FontAwesome.Sharp.IconMenuItem();
            this.menucompras = new FontAwesome.Sharp.IconMenuItem();
            this.submenuregistrarcompra = new FontAwesome.Sharp.IconMenuItem();
            this.submenudetallecompra = new FontAwesome.Sharp.IconMenuItem();
            this.menuequipos = new FontAwesome.Sharp.IconMenuItem();
            this.menuconsolas = new FontAwesome.Sharp.IconMenuItem();
            this.menuclientes = new FontAwesome.Sharp.IconMenuItem();
            this.menuproveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menureportes = new FontAwesome.Sharp.IconMenuItem();
            this.menuacercade = new FontAwesome.Sharp.IconMenuItem();
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.Contenedor = new System.Windows.Forms.Panel();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menumantenedor,
            this.menuservicios,
            this.menucompras,
            this.menuequipos,
            this.menuconsolas,
            this.menuclientes,
            this.menuproveedores,
            this.menureportes,
            this.menuacercade});
            this.menu.Location = new System.Drawing.Point(0, 61);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1130, 73);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menumantenedor
            // 
            this.menumantenedor.AutoSize = false;
            this.menumantenedor.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.menumantenedor.IconColor = System.Drawing.Color.Black;
            this.menumantenedor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menumantenedor.IconSize = 50;
            this.menumantenedor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menumantenedor.Name = "menumantenedor";
            this.menumantenedor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menumantenedor.Size = new System.Drawing.Size(122, 69);
            this.menumantenedor.Text = "Mantenedor";
            this.menumantenedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menumantenedor.Click += new System.EventHandler(this.menumantenedor_Click);
            // 
            // menuservicios
            // 
            this.menuservicios.AutoSize = false;
            this.menuservicios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuregistrarventa,
            this.submenudetalleventa});
            this.menuservicios.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuservicios.IconColor = System.Drawing.Color.Black;
            this.menuservicios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuservicios.IconSize = 50;
            this.menuservicios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuservicios.Name = "menuservicios";
            this.menuservicios.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuservicios.Size = new System.Drawing.Size(122, 69);
            this.menuservicios.Text = "Servicios";
            this.menuservicios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuregistrarventa
            // 
            this.submenuregistrarventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuregistrarventa.IconColor = System.Drawing.Color.Black;
            this.submenuregistrarventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuregistrarventa.Name = "submenuregistrarventa";
            this.submenuregistrarventa.Size = new System.Drawing.Size(180, 22);
            this.submenuregistrarventa.Text = "Registar";
            this.submenuregistrarventa.Click += new System.EventHandler(this.submenuregistrarventa_Click);
            // 
            // submenudetalleventa
            // 
            this.submenudetalleventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenudetalleventa.IconColor = System.Drawing.Color.Black;
            this.submenudetalleventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenudetalleventa.Name = "submenudetalleventa";
            this.submenudetalleventa.Size = new System.Drawing.Size(180, 22);
            this.submenudetalleventa.Text = "Ver Detalle";
            this.submenudetalleventa.Click += new System.EventHandler(this.submenudetalleventa_Click);
            // 
            // menucompras
            // 
            this.menucompras.AutoSize = false;
            this.menucompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuregistrarcompra,
            this.submenudetallecompra});
            this.menucompras.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.menucompras.IconColor = System.Drawing.Color.Black;
            this.menucompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucompras.IconSize = 50;
            this.menucompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menucompras.Name = "menucompras";
            this.menucompras.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menucompras.Size = new System.Drawing.Size(122, 69);
            this.menucompras.Text = "Compras";
            this.menucompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuregistrarcompra
            // 
            this.submenuregistrarcompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuregistrarcompra.IconColor = System.Drawing.Color.Black;
            this.submenuregistrarcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuregistrarcompra.Name = "submenuregistrarcompra";
            this.submenuregistrarcompra.Size = new System.Drawing.Size(180, 22);
            this.submenuregistrarcompra.Text = "Registar";
            this.submenuregistrarcompra.Click += new System.EventHandler(this.submenuregistrarcompra_Click);
            // 
            // submenudetallecompra
            // 
            this.submenudetallecompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenudetallecompra.IconColor = System.Drawing.Color.Black;
            this.submenudetallecompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenudetallecompra.Name = "submenudetallecompra";
            this.submenudetallecompra.Size = new System.Drawing.Size(180, 22);
            this.submenudetallecompra.Text = "Ver Detalle";
            this.submenudetallecompra.Click += new System.EventHandler(this.submenudetallecompra_Click);
            // 
            // menuequipos
            // 
            this.menuequipos.AutoSize = false;
            this.menuequipos.IconChar = FontAwesome.Sharp.IconChar.Computer;
            this.menuequipos.IconColor = System.Drawing.Color.Black;
            this.menuequipos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuequipos.IconSize = 50;
            this.menuequipos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuequipos.Name = "menuequipos";
            this.menuequipos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuequipos.Size = new System.Drawing.Size(122, 69);
            this.menuequipos.Text = "Equipos";
            this.menuequipos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuequipos.Click += new System.EventHandler(this.menuequipos_Click);
            // 
            // menuconsolas
            // 
            this.menuconsolas.AutoSize = false;
            this.menuconsolas.IconChar = FontAwesome.Sharp.IconChar.Gamepad;
            this.menuconsolas.IconColor = System.Drawing.Color.Black;
            this.menuconsolas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuconsolas.IconSize = 50;
            this.menuconsolas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuconsolas.Name = "menuconsolas";
            this.menuconsolas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuconsolas.Size = new System.Drawing.Size(122, 69);
            this.menuconsolas.Text = "Consolas";
            this.menuconsolas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuconsolas.Click += new System.EventHandler(this.menuconsolas_Click);
            // 
            // menuclientes
            // 
            this.menuclientes.AutoSize = false;
            this.menuclientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuclientes.IconColor = System.Drawing.Color.Black;
            this.menuclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuclientes.IconSize = 50;
            this.menuclientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuclientes.Name = "menuclientes";
            this.menuclientes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuclientes.Size = new System.Drawing.Size(122, 69);
            this.menuclientes.Text = "Clientes";
            this.menuclientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuclientes.Click += new System.EventHandler(this.menuclientes_Click);
            // 
            // menuproveedores
            // 
            this.menuproveedores.AutoSize = false;
            this.menuproveedores.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.menuproveedores.IconColor = System.Drawing.Color.Black;
            this.menuproveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuproveedores.IconSize = 50;
            this.menuproveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuproveedores.Name = "menuproveedores";
            this.menuproveedores.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuproveedores.Size = new System.Drawing.Size(122, 69);
            this.menuproveedores.Text = "Proveedores";
            this.menuproveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuproveedores.Click += new System.EventHandler(this.menuproveedores_Click);
            // 
            // menureportes
            // 
            this.menureportes.AutoSize = false;
            this.menureportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.menureportes.IconColor = System.Drawing.Color.Black;
            this.menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menureportes.IconSize = 50;
            this.menureportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menureportes.Name = "menureportes";
            this.menureportes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menureportes.Size = new System.Drawing.Size(122, 69);
            this.menureportes.Text = "Reportes";
            this.menureportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menureportes.Click += new System.EventHandler(this.menureportes_Click);
            // 
            // menuacercade
            // 
            this.menuacercade.AutoSize = false;
            this.menuacercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuacercade.IconColor = System.Drawing.Color.Black;
            this.menuacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuacercade.IconSize = 50;
            this.menuacercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuacercade.Name = "menuacercade";
            this.menuacercade.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuacercade.Size = new System.Drawing.Size(122, 69);
            this.menuacercade.Text = "Acerca de";
            this.menuacercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuacercade.Click += new System.EventHandler(this.menuacercade_Click);
            // 
            // menutitulo
            // 
            this.menutitulo.AutoSize = false;
            this.menutitulo.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.menutitulo.Location = new System.Drawing.Point(0, 0);
            this.menutitulo.Name = "menutitulo";
            this.menutitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menutitulo.Size = new System.Drawing.Size(1130, 61);
            this.menutitulo.TabIndex = 1;
            this.menutitulo.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema ResetPC";
            // 
            // Contenedor
            // 
            this.Contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Contenedor.Location = new System.Drawing.Point(0, 134);
            this.Contenedor.Name = "Contenedor";
            this.Contenedor.Size = new System.Drawing.Size(1130, 549);
            this.Contenedor.TabIndex = 3;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1130, 683);
            this.Controls.Add(this.Contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menutitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  ";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menutitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menuclientes;
        private FontAwesome.Sharp.IconMenuItem menuservicios;
        private FontAwesome.Sharp.IconMenuItem menuequipos;
        private FontAwesome.Sharp.IconMenuItem menucompras;
        private FontAwesome.Sharp.IconMenuItem menumantenedor;
        private FontAwesome.Sharp.IconMenuItem menuproveedores;
        private FontAwesome.Sharp.IconMenuItem menureportes;
        private FontAwesome.Sharp.IconMenuItem menuacercade;
        private System.Windows.Forms.Panel Contenedor;
        private FontAwesome.Sharp.IconMenuItem submenuregistrarventa;
        private FontAwesome.Sharp.IconMenuItem submenudetalleventa;
        private FontAwesome.Sharp.IconMenuItem submenuregistrarcompra;
        private FontAwesome.Sharp.IconMenuItem submenudetallecompra;
        private FontAwesome.Sharp.IconMenuItem menuconsolas;
    }
}

