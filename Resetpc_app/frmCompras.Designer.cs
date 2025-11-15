namespace Resetpc_app
{
    partial class frmCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcantidad = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtprecioventa = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtpreciounitario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtcomponente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtcodcomponente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbodocumento = new System.Windows.Forms.ComboBox();
            this.txtfecha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtidproveedor = new System.Windows.Forms.TextBox();
            this.btnbuscarrfc = new FontAwesome.Sharp.IconButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtrazonsocial = new System.Windows.Forms.TextBox();
            this.txtrfc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTasaIVA = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtidcomponente = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnagregarcomponente = new FontAwesome.Sharp.IconButton();
            this.btnbuscarcomponente = new FontAwesome.Sharp.IconButton();
            this.dgvdata = new System.Windows.Forms.DataGridView();
            this.IdComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Componente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TasaIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVACalculado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txttotalpagar = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtivatotal = new System.Windows.Forms.TextBox();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.btnregistrar = new FontAwesome.Sharp.IconButton();
            this.btnagregar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(878, 522);
            this.label1.TabIndex = 47;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(592, 49);
            this.txtcantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtcantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(68, 20);
            this.txtcantidad.TabIndex = 69;
            this.txtcantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(589, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 68;
            this.label13.Text = "Cantidad:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(504, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 67;
            this.label12.Text = "Precio Venta:";
            // 
            // txtprecioventa
            // 
            this.txtprecioventa.Location = new System.Drawing.Point(507, 49);
            this.txtprecioventa.Name = "txtprecioventa";
            this.txtprecioventa.Size = new System.Drawing.Size(77, 20);
            this.txtprecioventa.TabIndex = 66;
            this.txtprecioventa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprecioventa_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(419, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 65;
            this.label11.Text = "Precio Unitario:";
            // 
            // txtpreciounitario
            // 
            this.txtpreciounitario.Location = new System.Drawing.Point(422, 49);
            this.txtpreciounitario.Name = "txtpreciounitario";
            this.txtpreciounitario.Size = new System.Drawing.Size(77, 20);
            this.txtpreciounitario.TabIndex = 64;
            this.txtpreciounitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpreciounitario_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(190, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Componente:";
            // 
            // txtcomponente
            // 
            this.txtcomponente.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtcomponente.Location = new System.Drawing.Point(193, 49);
            this.txtcomponente.Name = "txtcomponente";
            this.txtcomponente.Size = new System.Drawing.Size(173, 20);
            this.txtcomponente.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(17, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 59;
            this.label6.Text = "Cod. Componente:";
            // 
            // txtcodcomponente
            // 
            this.txtcodcomponente.Location = new System.Drawing.Point(20, 49);
            this.txtcodcomponente.Name = "txtcodcomponente";
            this.txtcodcomponente.Size = new System.Drawing.Size(125, 20);
            this.txtcodcomponente.TabIndex = 58;
            this.txtcodcomponente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcodcomponente_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(168, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 25);
            this.label7.TabIndex = 52;
            this.label7.Text = "Registrar Compra";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbodocumento);
            this.groupBox1.Controls.Add(this.txtfecha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(173, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 84);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(17, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(119, 13);
            this.label17.TabIndex = 86;
            this.label17.Text = "Información de Compra:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(23, -16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 77;
            this.label10.Text = "Información de Compra";
            // 
            // cbodocumento
            // 
            this.cbodocumento.BackColor = System.Drawing.SystemColors.Window;
            this.cbodocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbodocumento.FormattingEnabled = true;
            this.cbodocumento.Location = new System.Drawing.Point(153, 44);
            this.cbodocumento.Name = "cbodocumento";
            this.cbodocumento.Size = new System.Drawing.Size(144, 21);
            this.cbodocumento.TabIndex = 76;
            // 
            // txtfecha
            // 
            this.txtfecha.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtfecha.Location = new System.Drawing.Point(26, 44);
            this.txtfecha.Name = "txtfecha";
            this.txtfecha.Size = new System.Drawing.Size(104, 20);
            this.txtfecha.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(150, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "Tipo Documento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(23, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Fecha:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtidproveedor);
            this.groupBox2.Controls.Add(this.btnbuscarrfc);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtrazonsocial);
            this.groupBox2.Controls.Add(this.txtrfc);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(516, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 84);
            this.groupBox2.TabIndex = 78;
            this.groupBox2.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(132, 13);
            this.label18.TabIndex = 86;
            this.label18.Text = "Información de Proveedor:";
            // 
            // txtidproveedor
            // 
            this.txtidproveedor.Location = new System.Drawing.Point(366, 18);
            this.txtidproveedor.Name = "txtidproveedor";
            this.txtidproveedor.Size = new System.Drawing.Size(38, 20);
            this.txtidproveedor.TabIndex = 79;
            this.txtidproveedor.TabStop = false;
            this.txtidproveedor.Text = "0";
            this.txtidproveedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtidproveedor.Visible = false;
            // 
            // btnbuscarrfc
            // 
            this.btnbuscarrfc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnbuscarrfc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarrfc.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbuscarrfc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarrfc.ForeColor = System.Drawing.Color.White;
            this.btnbuscarrfc.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscarrfc.IconColor = System.Drawing.Color.Black;
            this.btnbuscarrfc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarrfc.IconSize = 16;
            this.btnbuscarrfc.Location = new System.Drawing.Point(166, 44);
            this.btnbuscarrfc.Name = "btnbuscarrfc";
            this.btnbuscarrfc.Size = new System.Drawing.Size(38, 22);
            this.btnbuscarrfc.TabIndex = 83;
            this.btnbuscarrfc.UseVisualStyleBackColor = false;
            this.btnbuscarrfc.Click += new System.EventHandler(this.btnbuscarrfc_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(23, -16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 13);
            this.label14.TabIndex = 77;
            this.label14.Text = "Información de Proveedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(207, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 82;
            this.label5.Text = "Razón Social:";
            // 
            // txtrazonsocial
            // 
            this.txtrazonsocial.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtrazonsocial.Location = new System.Drawing.Point(210, 46);
            this.txtrazonsocial.Name = "txtrazonsocial";
            this.txtrazonsocial.Size = new System.Drawing.Size(194, 20);
            this.txtrazonsocial.TabIndex = 81;
            // 
            // txtrfc
            // 
            this.txtrfc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtrfc.Location = new System.Drawing.Point(16, 45);
            this.txtrfc.Name = "txtrfc";
            this.txtrfc.Size = new System.Drawing.Size(144, 20);
            this.txtrfc.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 80;
            this.label3.Text = "RFC:";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.txtTasaIVA);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtidcomponente);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtcodcomponente);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtcantidad);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.btnagregarcomponente);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.btnbuscarcomponente);
            this.groupBox3.Controls.Add(this.txtprecioventa);
            this.groupBox3.Controls.Add(this.txtcomponente);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtpreciounitario);
            this.groupBox3.Location = new System.Drawing.Point(173, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(764, 88);
            this.groupBox3.TabIndex = 78;
            this.groupBox3.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(664, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 13);
            this.label19.TabIndex = 87;
            this.label19.Text = "Tasa IVA:";
            // 
            // txtTasaIVA
            // 
            this.txtTasaIVA.Location = new System.Drawing.Point(667, 49);
            this.txtTasaIVA.Name = "txtTasaIVA";
            this.txtTasaIVA.Size = new System.Drawing.Size(77, 20);
            this.txtTasaIVA.TabIndex = 86;
            this.txtTasaIVA.Text = "0.16";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 13);
            this.label9.TabIndex = 85;
            this.label9.Text = "Información de Componente:";
            // 
            // txtidcomponente
            // 
            this.txtidcomponente.Location = new System.Drawing.Point(120, 23);
            this.txtidcomponente.Name = "txtidcomponente";
            this.txtidcomponente.Size = new System.Drawing.Size(38, 20);
            this.txtidcomponente.TabIndex = 84;
            this.txtidcomponente.TabStop = false;
            this.txtidcomponente.Text = "0";
            this.txtidcomponente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtidcomponente.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(23, -16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 13);
            this.label15.TabIndex = 77;
            this.label15.Text = "Información de Componente";
            // 
            // btnagregarcomponente
            // 
            this.btnagregarcomponente.BackColor = System.Drawing.Color.ForestGreen;
            this.btnagregarcomponente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnagregarcomponente.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnagregarcomponente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnagregarcomponente.ForeColor = System.Drawing.Color.White;
            this.btnagregarcomponente.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnagregarcomponente.IconColor = System.Drawing.Color.White;
            this.btnagregarcomponente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnagregarcomponente.IconSize = 16;
            this.btnagregarcomponente.Location = new System.Drawing.Point(372, 49);
            this.btnagregarcomponente.Name = "btnagregarcomponente";
            this.btnagregarcomponente.Size = new System.Drawing.Size(38, 20);
            this.btnagregarcomponente.TabIndex = 71;
            this.btnagregarcomponente.UseVisualStyleBackColor = false;
            this.btnagregarcomponente.Click += new System.EventHandler(this.btnagregarcomponente_Click_1);
            // 
            // btnbuscarcomponente
            // 
            this.btnbuscarcomponente.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnbuscarcomponente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarcomponente.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btnbuscarcomponente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarcomponente.ForeColor = System.Drawing.Color.White;
            this.btnbuscarcomponente.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscarcomponente.IconColor = System.Drawing.Color.Black;
            this.btnbuscarcomponente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarcomponente.IconSize = 16;
            this.btnbuscarcomponente.Location = new System.Drawing.Point(149, 49);
            this.btnbuscarcomponente.Name = "btnbuscarcomponente";
            this.btnbuscarcomponente.Size = new System.Drawing.Size(38, 20);
            this.btnbuscarcomponente.TabIndex = 70;
            this.btnbuscarcomponente.UseVisualStyleBackColor = false;
            this.btnbuscarcomponente.Click += new System.EventHandler(this.btnbuscarcomponente_Click);
            // 
            // dgvdata
            // 
            this.dgvdata.AllowUserToAddRows = false;
            this.dgvdata.AllowUserToDeleteRows = false;
            this.dgvdata.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvdata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdComponente,
            this.Componente,
            this.Cantidad,
            this.PrecioUnitario,
            this.TasaIVA,
            this.PrecioVenta,
            this.IVACalculado,
            this.SubTotal,
            this.Total,
            this.btnseleccionar});
            this.dgvdata.Location = new System.Drawing.Point(172, 248);
            this.dgvdata.MultiSelect = false;
            this.dgvdata.Name = "dgvdata";
            this.dgvdata.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvdata.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvdata.RowTemplate.Height = 28;
            this.dgvdata.Size = new System.Drawing.Size(647, 260);
            this.dgvdata.TabIndex = 85;
            this.dgvdata.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdata_CellContentClick);
            this.dgvdata.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvdata_CellPainting);
            // 
            // IdComponente
            // 
            this.IdComponente.HeaderText = "IdComponente";
            this.IdComponente.Name = "IdComponente";
            this.IdComponente.ReadOnly = true;
            this.IdComponente.Visible = false;
            this.IdComponente.Width = 140;
            // 
            // Componente
            // 
            this.Componente.HeaderText = "Componente";
            this.Componente.Name = "Componente";
            this.Componente.ReadOnly = true;
            this.Componente.Width = 200;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 80;
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.HeaderText = "Precio Unitario";
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.ReadOnly = true;
            this.PrecioUnitario.Width = 140;
            // 
            // TasaIVA
            // 
            this.TasaIVA.HeaderText = "Tasa IVA";
            this.TasaIVA.Name = "TasaIVA";
            this.TasaIVA.ReadOnly = true;
            this.TasaIVA.Visible = false;
            this.TasaIVA.Width = 80;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.HeaderText = "Precio Venta";
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            this.PrecioVenta.Visible = false;
            // 
            // IVACalculado
            // 
            this.IVACalculado.HeaderText = "Impuesto";
            this.IVACalculado.Name = "IVACalculado";
            this.IVACalculado.ReadOnly = true;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal (sin IVA)";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "SubTotal (con IVA)";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.FillWeight = 3.669725F;
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.Width = 30;
            // 
            // txttotalpagar
            // 
            this.txttotalpagar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txttotalpagar.Location = new System.Drawing.Point(828, 442);
            this.txttotalpagar.Name = "txttotalpagar";
            this.txttotalpagar.Size = new System.Drawing.Size(109, 20);
            this.txttotalpagar.TabIndex = 84;
            this.txttotalpagar.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(825, 426);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 85;
            this.label16.Text = "Total a Pagar:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(825, 347);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 13);
            this.label20.TabIndex = 87;
            this.label20.Text = "Subtotal:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(825, 388);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 13);
            this.label21.TabIndex = 88;
            this.label21.Text = "Impuesto:";
            // 
            // txtivatotal
            // 
            this.txtivatotal.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtivatotal.Location = new System.Drawing.Point(828, 404);
            this.txtivatotal.Name = "txtivatotal";
            this.txtivatotal.Size = new System.Drawing.Size(109, 20);
            this.txtivatotal.TabIndex = 89;
            this.txtivatotal.Text = "0";
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtsubtotal.Location = new System.Drawing.Point(828, 365);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.Size = new System.Drawing.Size(109, 20);
            this.txtsubtotal.TabIndex = 90;
            this.txtsubtotal.Text = "0";
            // 
            // btnregistrar
            // 
            this.btnregistrar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnregistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnregistrar.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnregistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnregistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregistrar.ForeColor = System.Drawing.Color.Black;
            this.btnregistrar.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.btnregistrar.IconColor = System.Drawing.Color.DodgerBlue;
            this.btnregistrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnregistrar.IconSize = 30;
            this.btnregistrar.Location = new System.Drawing.Point(828, 468);
            this.btnregistrar.Name = "btnregistrar";
            this.btnregistrar.Size = new System.Drawing.Size(109, 37);
            this.btnregistrar.TabIndex = 86;
            this.btnregistrar.Text = "Registrar";
            this.btnregistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnregistrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnregistrar.UseVisualStyleBackColor = false;
            this.btnregistrar.Click += new System.EventHandler(this.btnregistrar_Click);
            // 
            // btnagregar
            // 
            this.btnagregar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnagregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnagregar.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btnagregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnagregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnagregar.ForeColor = System.Drawing.Color.Black;
            this.btnagregar.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnagregar.IconColor = System.Drawing.Color.ForestGreen;
            this.btnagregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnagregar.IconSize = 40;
            this.btnagregar.Location = new System.Drawing.Point(828, 248);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(109, 87);
            this.btnagregar.TabIndex = 84;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnagregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // frmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1136, 551);
            this.Controls.Add(this.txtsubtotal);
            this.Controls.Add(this.txtivatotal);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnregistrar);
            this.Controls.Add(this.txttotalpagar);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dgvdata);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Name = "frmCompras";
            this.Text = "frmCompras";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.frmCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtcantidad)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnagregarcomponente;
        private FontAwesome.Sharp.IconButton btnbuscarcomponente;
        private System.Windows.Forms.NumericUpDown txtcantidad;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtprecioventa;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtpreciounitario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtcomponente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtcodcomponente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbodocumento;
        private System.Windows.Forms.TextBox txtfecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private FontAwesome.Sharp.IconButton btnbuscarrfc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtrazonsocial;
        private System.Windows.Forms.TextBox txtrfc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtidproveedor;
        private System.Windows.Forms.TextBox txtidcomponente;
        private System.Windows.Forms.DataGridView dgvdata;
        private System.Windows.Forms.TextBox txttotalpagar;
        private System.Windows.Forms.Label label16;
        private FontAwesome.Sharp.IconButton btnregistrar;
        private FontAwesome.Sharp.IconButton btnagregar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtTasaIVA;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtivatotal;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Componente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn TasaIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVACalculado;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
    }
}