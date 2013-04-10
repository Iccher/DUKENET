namespace Logistica.Ingenieria.Presentacion.Mantenimientos.Ordenes_Trabajo
{
    partial class FrmOrdenTrabajo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOrdenTrabajo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.grBoxBusquedaGeneral = new System.Windows.Forms.GroupBox();
            this.tvResumen = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvOrdenesTrabajo = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cbBusqueda = new System.Windows.Forms.ComboBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.O_trabajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Maquina_Parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ODTSCD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Selec = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Modif = new System.Windows.Forms.DataGridViewLinkColumn();
            this.odtcod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.odtdpt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6.SuspendLayout();
            this.grBoxBusquedaGeneral.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesTrabajo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblBusqueda);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(894, 75);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.BackColor = System.Drawing.Color.White;
            this.lblBusqueda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblBusqueda.Location = new System.Drawing.Point(6, 41);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(882, 29);
            this.lblBusqueda.TabIndex = 1;
            this.lblBusqueda.Text = "AREAS";
            this.lblBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(882, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "Almacén de Ingeniería";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grBoxBusquedaGeneral
            // 
            this.grBoxBusquedaGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grBoxBusquedaGeneral.Controls.Add(this.tvResumen);
            this.grBoxBusquedaGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grBoxBusquedaGeneral.ForeColor = System.Drawing.Color.Navy;
            this.grBoxBusquedaGeneral.Location = new System.Drawing.Point(12, 93);
            this.grBoxBusquedaGeneral.Name = "grBoxBusquedaGeneral";
            this.grBoxBusquedaGeneral.Size = new System.Drawing.Size(344, 581);
            this.grBoxBusquedaGeneral.TabIndex = 42;
            this.grBoxBusquedaGeneral.TabStop = false;
            this.grBoxBusquedaGeneral.Text = "Centro de Costo";
            // 
            // tvResumen
            // 
            this.tvResumen.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvResumen.ImageIndex = 0;
            this.tvResumen.ImageList = this.imageList1;
            this.tvResumen.Location = new System.Drawing.Point(6, 20);
            this.tvResumen.Name = "tvResumen";
            this.tvResumen.SelectedImageIndex = 0;
            this.tvResumen.Size = new System.Drawing.Size(326, 555);
            this.tvResumen.TabIndex = 0;
            this.tvResumen.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvResumen_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "location.ico");
            this.imageList1.Images.SetKeyName(1, "AlignFull.ico");
            this.imageList1.Images.SetKeyName(2, "apercu.ico");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvOrdenesTrabajo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(356, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(717, 494);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Centro de Costo - ";
            // 
            // dgvOrdenesTrabajo
            // 
            this.dgvOrdenesTrabajo.AllowUserToAddRows = false;
            this.dgvOrdenesTrabajo.AllowUserToDeleteRows = false;
            this.dgvOrdenesTrabajo.AllowUserToOrderColumns = true;
            this.dgvOrdenesTrabajo.AllowUserToResizeColumns = false;
            this.dgvOrdenesTrabajo.AllowUserToResizeRows = false;
            this.dgvOrdenesTrabajo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrdenesTrabajo.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenesTrabajo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvOrdenesTrabajo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvOrdenesTrabajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenesTrabajo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.O_trabajo,
            this.Maquina_Parte,
            this.ODTSCD,
            this.DATO,
            this.Selec,
            this.Modif,
            this.odtcod,
            this.odtdpt});
            this.dgvOrdenesTrabajo.Location = new System.Drawing.Point(6, 20);
            this.dgvOrdenesTrabajo.Name = "dgvOrdenesTrabajo";
            this.dgvOrdenesTrabajo.ReadOnly = true;
            this.dgvOrdenesTrabajo.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvOrdenesTrabajo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrdenesTrabajo.Size = new System.Drawing.Size(705, 466);
            this.dgvOrdenesTrabajo.TabIndex = 38;
            this.dgvOrdenesTrabajo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenesTrabajo_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBusqueda);
            this.groupBox2.Controls.Add(this.cbBusqueda);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(356, 579);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 45);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(209, 17);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(333, 20);
            this.txtBusqueda.TabIndex = 1;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // cbBusqueda
            // 
            this.cbBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBusqueda.ForeColor = System.Drawing.Color.Navy;
            this.cbBusqueda.FormattingEnabled = true;
            this.cbBusqueda.Items.AddRange(new object[] {
            "Orden Trabajo",
            "Maq.Parte"});
            this.cbBusqueda.Location = new System.Drawing.Point(12, 17);
            this.cbBusqueda.Name = "cbBusqueda";
            this.cbBusqueda.Size = new System.Drawing.Size(191, 21);
            this.cbBusqueda.TabIndex = 0;
            this.cbBusqueda.SelectedIndexChanged += new System.EventHandler(this.cbBusqueda_SelectedIndexChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.BO1;
            this.btnNuevo.Location = new System.Drawing.Point(563, 624);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(48, 44);
            this.btnNuevo.TabIndex = 45;
            this.toolTip1.SetToolTip(this.btnNuevo, "Crear Nueva Orden de Trabajo");
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.close;
            this.btnSalir.Location = new System.Drawing.Point(617, 624);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(48, 44);
            this.btnSalir.TabIndex = 46;
            this.toolTip1.SetToolTip(this.btnSalir, "Salir");
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // O_trabajo
            // 
            this.O_trabajo.DataPropertyName = "O_trabajo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.O_trabajo.DefaultCellStyle = dataGridViewCellStyle1;
            this.O_trabajo.HeaderText = "O.Trabajo";
            this.O_trabajo.Name = "O_trabajo";
            this.O_trabajo.ReadOnly = true;
            this.O_trabajo.Width = 80;
            // 
            // Maquina_Parte
            // 
            this.Maquina_Parte.DataPropertyName = "Maquina_Parte";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Maquina_Parte.DefaultCellStyle = dataGridViewCellStyle2;
            this.Maquina_Parte.HeaderText = "Maq.Parte";
            this.Maquina_Parte.Name = "Maquina_Parte";
            this.Maquina_Parte.ReadOnly = true;
            this.Maquina_Parte.Width = 420;
            // 
            // ODTSCD
            // 
            this.ODTSCD.DataPropertyName = "ODTSCD";
            this.ODTSCD.HeaderText = "ODTSCD";
            this.ODTSCD.Name = "ODTSCD";
            this.ODTSCD.ReadOnly = true;
            this.ODTSCD.Visible = false;
            // 
            // DATO
            // 
            this.DATO.DataPropertyName = "DATO";
            this.DATO.HeaderText = "STS";
            this.DATO.Name = "DATO";
            this.DATO.ReadOnly = true;
            this.DATO.Width = 50;
            // 
            // Selec
            // 
            this.Selec.DataPropertyName = "Selec";
            this.Selec.HeaderText = "";
            this.Selec.Name = "Selec";
            this.Selec.ReadOnly = true;
            this.Selec.Text = "";
            this.Selec.Width = 50;
            // 
            // Modif
            // 
            this.Modif.DataPropertyName = "Modif";
            this.Modif.HeaderText = "";
            this.Modif.Name = "Modif";
            this.Modif.ReadOnly = true;
            this.Modif.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Modif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Modif.Width = 50;
            // 
            // odtcod
            // 
            this.odtcod.DataPropertyName = "odtcod";
            this.odtcod.HeaderText = "odtcod";
            this.odtcod.Name = "odtcod";
            this.odtcod.ReadOnly = true;
            this.odtcod.Visible = false;
            // 
            // odtdpt
            // 
            this.odtdpt.DataPropertyName = "odtdpt";
            this.odtdpt.HeaderText = "odtdpt";
            this.odtdpt.Name = "odtdpt";
            this.odtdpt.ReadOnly = true;
            this.odtdpt.Visible = false;
            // 
            // FrmOrdenTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 686);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grBoxBusquedaGeneral);
            this.Controls.Add(this.groupBox6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmOrdenTrabajo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orden de Trabajo";
            this.Load += new System.EventHandler(this.FrmOrdenTrabajo_Load);
            this.groupBox6.ResumeLayout(false);
            this.grBoxBusquedaGeneral.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesTrabajo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox grBoxBusquedaGeneral;
        private System.Windows.Forms.TreeView tvResumen;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView dgvOrdenesTrabajo;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.TextBox txtBusqueda;
        internal System.Windows.Forms.ComboBox cbBusqueda;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn O_trabajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Maquina_Parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ODTSCD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATO;
        private System.Windows.Forms.DataGridViewLinkColumn Selec;
        private System.Windows.Forms.DataGridViewLinkColumn Modif;
        private System.Windows.Forms.DataGridViewTextBoxColumn odtcod;
        private System.Windows.Forms.DataGridViewTextBoxColumn odtdpt;
    }
}