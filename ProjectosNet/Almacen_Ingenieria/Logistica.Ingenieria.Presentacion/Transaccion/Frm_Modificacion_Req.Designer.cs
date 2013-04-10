namespace Logistica.Ingenieria.Presentacion.Transaccion
{
    partial class Frm_Modificacion_Req
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblUndMed = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnEliminar = new System.Windows.Forms.ToolStripButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTotalD = new System.Windows.Forms.TextBox();
            this.txtTotalS = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.txtDpto = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtSolicitante = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnHelpCodProd = new System.Windows.Forms.Button();
            this.txtDesProd = new System.Windows.Forms.TextBox();
            this.TxtCodProd = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDescripcionDPTO = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCodDpto = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOrden = new System.Windows.Forms.Button();
            this.txtOrden = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvDetReq = new System.Windows.Forms.DataGridView();
            this.groupBox7.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetReq)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblUndMed);
            this.groupBox7.Controls.Add(this.toolStrip1);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.txtCantidad);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.ForeColor = System.Drawing.Color.Navy;
            this.groupBox7.Location = new System.Drawing.Point(626, 134);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(269, 42);
            this.groupBox7.TabIndex = 66;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Cantidad";
            // 
            // lblUndMed
            // 
            this.lblUndMed.AutoSize = true;
            this.lblUndMed.Location = new System.Drawing.Point(120, 19);
            this.lblUndMed.Name = "lblUndMed";
            this.lblUndMed.Size = new System.Drawing.Size(0, 13);
            this.lblUndMed.TabIndex = 29;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAgregar,
            this.toolStripSeparator1,
            this.BtnEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(184, 11);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(64, 25);
            this.toolStrip1.TabIndex = 28;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAgregar.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.NUEVO;
            this.BtnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(23, 22);
            this.BtnAgregar.Text = "Adicionar Producto";
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnEliminar.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.Borrar;
            this.BtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(23, 22);
            this.BtnEliminar.Text = "Eliminar Producto";
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label9.Location = new System.Drawing.Point(181, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 33);
            this.label9.TabIndex = 27;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Enabled = false;
            this.txtCantidad.Location = new System.Drawing.Point(7, 16);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(106, 20);
            this.txtCantidad.TabIndex = 17;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtTurno
            // 
            this.txtTurno.Enabled = false;
            this.txtTurno.Location = new System.Drawing.Point(637, 407);
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.Size = new System.Drawing.Size(90, 20);
            this.txtTurno.TabIndex = 74;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.toolStripButton4,
            this.toolStripSeparator3,
            this.tsbSalir});
            this.toolStrip2.Location = new System.Drawing.Point(11, 441);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(93, 25);
            this.toolStrip2.TabIndex = 73;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.BO;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Generar Req.";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.ELIMINA;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Cancelar Req.";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSalir
            // 
            this.tsbSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSalir.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.SALIDA;
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(23, 22);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label18.Location = new System.Drawing.Point(8, 437);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 33);
            this.label18.TabIndex = 72;
            // 
            // txtTotalD
            // 
            this.txtTotalD.Location = new System.Drawing.Point(884, 446);
            this.txtTotalD.Name = "txtTotalD";
            this.txtTotalD.Size = new System.Drawing.Size(100, 20);
            this.txtTotalD.TabIndex = 71;
            this.txtTotalD.Visible = false;
            // 
            // txtTotalS
            // 
            this.txtTotalS.Location = new System.Drawing.Point(879, 145);
            this.txtTotalS.Name = "txtTotalS";
            this.txtTotalS.Size = new System.Drawing.Size(100, 20);
            this.txtTotalS.TabIndex = 70;
            this.txtTotalS.Visible = false;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.txtDpto);
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.ForeColor = System.Drawing.Color.Navy;
            this.groupBox11.Location = new System.Drawing.Point(194, 83);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(250, 46);
            this.groupBox11.TabIndex = 69;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Area";
            // 
            // txtDpto
            // 
            this.txtDpto.BackColor = System.Drawing.Color.White;
            this.txtDpto.Enabled = false;
            this.txtDpto.Location = new System.Drawing.Point(11, 16);
            this.txtDpto.Name = "txtDpto";
            this.txtDpto.Size = new System.Drawing.Size(229, 20);
            this.txtDpto.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtSolicitante);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.ForeColor = System.Drawing.Color.Navy;
            this.groupBox10.Location = new System.Drawing.Point(7, 392);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(523, 46);
            this.groupBox10.TabIndex = 68;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Solicitado Por...";
            // 
            // txtSolicitante
            // 
            this.txtSolicitante.Enabled = false;
            this.txtSolicitante.Location = new System.Drawing.Point(6, 16);
            this.txtSolicitante.Name = "txtSolicitante";
            this.txtSolicitante.Size = new System.Drawing.Size(511, 20);
            this.txtSolicitante.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.button4);
            this.groupBox9.Controls.Add(this.button3);
            this.groupBox9.Controls.Add(this.button2);
            this.groupBox9.Controls.Add(this.btnHelpCodProd);
            this.groupBox9.Controls.Add(this.txtDesProd);
            this.groupBox9.Controls.Add(this.TxtCodProd);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.ForeColor = System.Drawing.Color.Navy;
            this.groupBox9.Location = new System.Drawing.Point(7, 134);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(620, 42);
            this.groupBox9.TabIndex = 65;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Producto";
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.ForeColor = System.Drawing.Color.Transparent;
            this.button4.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.PROCESO1;
            this.button4.Location = new System.Drawing.Point(582, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(29, 26);
            this.button4.TabIndex = 18;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.BUSCAR;
            this.button3.Location = new System.Drawing.Point(552, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 26);
            this.button3.TabIndex = 17;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources._16__Find_;
            this.button2.Location = new System.Drawing.Point(522, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 26);
            this.button2.TabIndex = 16;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnHelpCodProd
            // 
            this.btnHelpCodProd.AutoSize = true;
            this.btnHelpCodProd.ForeColor = System.Drawing.Color.Transparent;
            this.btnHelpCodProd.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.search;
            this.btnHelpCodProd.Location = new System.Drawing.Point(492, 13);
            this.btnHelpCodProd.Name = "btnHelpCodProd";
            this.btnHelpCodProd.Size = new System.Drawing.Size(29, 26);
            this.btnHelpCodProd.TabIndex = 10;
            this.btnHelpCodProd.Text = "...";
            this.btnHelpCodProd.UseVisualStyleBackColor = true;
            this.btnHelpCodProd.Click += new System.EventHandler(this.btnHelpCodProd_Click);
            // 
            // txtDesProd
            // 
            this.txtDesProd.BackColor = System.Drawing.SystemColors.Control;
            this.txtDesProd.Enabled = false;
            this.txtDesProd.Location = new System.Drawing.Point(87, 15);
            this.txtDesProd.Name = "txtDesProd";
            this.txtDesProd.Size = new System.Drawing.Size(399, 20);
            this.txtDesProd.TabIndex = 15;
            // 
            // TxtCodProd
            // 
            this.TxtCodProd.Location = new System.Drawing.Point(6, 15);
            this.TxtCodProd.MaxLength = 11;
            this.TxtCodProd.Name = "TxtCodProd";
            this.TxtCodProd.Size = new System.Drawing.Size(79, 20);
            this.TxtCodProd.TabIndex = 14;
            this.TxtCodProd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodProd_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dt1);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(850, 83);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(135, 46);
            this.groupBox4.TabIndex = 64;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Fecha";
            // 
            // dt1
            // 
            this.dt1.Enabled = false;
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt1.Location = new System.Drawing.Point(8, 16);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(121, 20);
            this.dt1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDescripcionDPTO);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(440, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(412, 46);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Para ser Empleado en....";
            // 
            // txtDescripcionDPTO
            // 
            this.txtDescripcionDPTO.BackColor = System.Drawing.Color.White;
            this.txtDescripcionDPTO.Enabled = false;
            this.txtDescripcionDPTO.Location = new System.Drawing.Point(11, 16);
            this.txtDescripcionDPTO.Name = "txtDescripcionDPTO";
            this.txtDescripcionDPTO.Size = new System.Drawing.Size(395, 20);
            this.txtDescripcionDPTO.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCodDpto);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(113, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(84, 46);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cod. Dpto";
            // 
            // txtCodDpto
            // 
            this.txtCodDpto.BackColor = System.Drawing.Color.White;
            this.txtCodDpto.Enabled = false;
            this.txtCodDpto.Location = new System.Drawing.Point(6, 15);
            this.txtCodDpto.Name = "txtCodDpto";
            this.txtCodDpto.Size = new System.Drawing.Size(69, 20);
            this.txtCodDpto.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOrden);
            this.groupBox1.Controls.Add(this.txtOrden);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(7, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 46);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orden Trabajo";
            // 
            // btnOrden
            // 
            this.btnOrden.AutoSize = true;
            this.btnOrden.ForeColor = System.Drawing.Color.Transparent;
            this.btnOrden.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.search;
            this.btnOrden.Location = new System.Drawing.Point(72, 14);
            this.btnOrden.Name = "btnOrden";
            this.btnOrden.Size = new System.Drawing.Size(29, 26);
            this.btnOrden.TabIndex = 11;
            this.btnOrden.Text = "...";
            this.btnOrden.UseVisualStyleBackColor = true;
            this.btnOrden.Click += new System.EventHandler(this.btnOrden_Click);
            // 
            // txtOrden
            // 
            this.txtOrden.Location = new System.Drawing.Point(6, 16);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Size = new System.Drawing.Size(63, 20);
            this.txtOrden.TabIndex = 0;
            this.txtOrden.TextChanged += new System.EventHandler(this.txtOrden_TextChanged);
            this.txtOrden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrden_KeyPress);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtTotal);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(7, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(978, 75);
            this.groupBox6.TabIndex = 60;
            this.groupBox6.TabStop = false;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtTotal.Location = new System.Drawing.Point(6, 41);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(966, 29);
            this.txtTotal.TabIndex = 1;
            this.txtTotal.Text = "MODIFICACIÓN - NroReq";
            this.txtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(966, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "ALMACEN UTILES";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgvDetReq);
            this.groupBox5.Location = new System.Drawing.Point(7, 168);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(978, 218);
            this.groupBox5.TabIndex = 67;
            this.groupBox5.TabStop = false;
            // 
            // dgvDetReq
            // 
            this.dgvDetReq.AllowUserToAddRows = false;
            this.dgvDetReq.AllowUserToDeleteRows = false;
            this.dgvDetReq.AllowUserToOrderColumns = true;
            this.dgvDetReq.AllowUserToResizeColumns = false;
            this.dgvDetReq.AllowUserToResizeRows = false;
            this.dgvDetReq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetReq.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetReq.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvDetReq.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDetReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetReq.Location = new System.Drawing.Point(6, 13);
            this.dgvDetReq.Name = "dgvDetReq";
            this.dgvDetReq.ReadOnly = true;
            this.dgvDetReq.RowHeadersVisible = false;
            this.dgvDetReq.Size = new System.Drawing.Size(966, 199);
            this.dgvDetReq.TabIndex = 1;
            // 
            // Frm_Modificacion_Req
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 476);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.txtTurno);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtTotalD);
            this.Controls.Add(this.txtTotalS);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Name = "Frm_Modificacion_Req";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificacion de Req.";
            this.Load += new System.EventHandler(this.Frm_Modificacion_Req_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetReq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblUndMed;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnAgregar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnEliminar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtTurno;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTotalD;
        private System.Windows.Forms.TextBox txtTotalS;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TextBox txtDpto;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox txtSolicitante;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnHelpCodProd;
        private System.Windows.Forms.TextBox txtDesProd;
        private System.Windows.Forms.TextBox TxtCodProd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dt1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDescripcionDPTO;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCodDpto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOrden;
        private System.Windows.Forms.TextBox txtOrden;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.DataGridView dgvDetReq;
    }
}