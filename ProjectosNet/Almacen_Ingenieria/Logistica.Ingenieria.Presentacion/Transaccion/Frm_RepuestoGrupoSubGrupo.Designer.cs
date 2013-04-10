namespace Logistica.Ingenieria.Presentacion.Transaccion
{
    partial class Frm_RepuestoGrupoSubGrupo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_RepuestoGrupoSubGrupo));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cboBusqueda = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.Detalle = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Detalle1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion_Tarde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N_Parte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cod_Und_Med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unid_Med = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aplicabilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cod_Aplicabilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Des_Aplicabilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Des_Mecanicos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExcel);
            this.groupBox3.Location = new System.Drawing.Point(870, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(67, 75);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Enabled = false;
            this.btnExcel.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.icono_excel1;
            this.btnExcel.Location = new System.Drawing.Point(6, 12);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(55, 57);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtBusqueda);
            this.GroupBox1.Controls.Add(this.cboBusqueda);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.Color.Navy;
            this.GroupBox1.Location = new System.Drawing.Point(214, 111);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(601, 45);
            this.GroupBox1.TabIndex = 38;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Busqueda";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(207, 16);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(388, 20);
            this.txtBusqueda.TabIndex = 1;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // cboBusqueda
            // 
            this.cboBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBusqueda.ForeColor = System.Drawing.Color.Navy;
            this.cboBusqueda.FormattingEnabled = true;
            this.cboBusqueda.Location = new System.Drawing.Point(10, 16);
            this.cboBusqueda.Name = "cboBusqueda";
            this.cboBusqueda.Size = new System.Drawing.Size(191, 21);
            this.cboBusqueda.TabIndex = 0;
            this.cboBusqueda.SelectedIndexChanged += new System.EventHandler(this.cboBusqueda_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblBusqueda);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(852, 75);
            this.groupBox6.TabIndex = 37;
            this.groupBox6.TabStop = false;
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.BackColor = System.Drawing.Color.White;
            this.lblBusqueda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.ForeColor = System.Drawing.Color.Black;
            this.lblBusqueda.Location = new System.Drawing.Point(6, 41);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(838, 29);
            this.lblBusqueda.TabIndex = 1;
            this.lblBusqueda.Text = "Productos Almacén Ingeniería";
            this.lblBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(838, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "Almacén de Utiles";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToOrderColumns = true;
            this.dgvProductos.AllowUserToResizeColumns = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Detalle,
            this.Detalle1,
            this.Codigo,
            this.Descripcion,
            this.Descripcion_Tarde,
            this.N_Parte,
            this.Cod_Und_Med,
            this.Unid_Med,
            this.Ubicacion,
            this.Aplicabilidad,
            this.Cod_Aplicabilidad,
            this.Des_Aplicabilidad,
            this.Des_Mecanicos});
            this.dgvProductos.Location = new System.Drawing.Point(12, 164);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProductos.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvProductos.Size = new System.Drawing.Size(1121, 442);
            this.dgvProductos.TabIndex = 36;
            this.dgvProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellContentClick);
            // 
            // Detalle
            // 
            this.Detalle.Frozen = true;
            this.Detalle.HeaderText = "Detalle";
            this.Detalle.Name = "Detalle";
            this.Detalle.ReadOnly = true;
            this.Detalle.Text = "Ver Foto";
            this.Detalle.UseColumnTextForLinkValue = true;
            // 
            // Detalle1
            // 
            this.Detalle1.Frozen = true;
            this.Detalle1.HeaderText = "Detalle Adic.";
            this.Detalle1.Name = "Detalle1";
            this.Detalle1.ReadOnly = true;
            this.Detalle1.Text = "Ing.Det.Adicional";
            this.Detalle1.UseColumnTextForLinkValue = true;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Codigo.Frozen = true;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 70;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Descripcion.DefaultCellStyle = dataGridViewCellStyle2;
            this.Descripcion.Frozen = true;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 300;
            // 
            // Descripcion_Tarde
            // 
            this.Descripcion_Tarde.DataPropertyName = "Descripcion_Tarde";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Descripcion_Tarde.DefaultCellStyle = dataGridViewCellStyle3;
            this.Descripcion_Tarde.HeaderText = "Des. Adicional";
            this.Descripcion_Tarde.Name = "Descripcion_Tarde";
            this.Descripcion_Tarde.ReadOnly = true;
            this.Descripcion_Tarde.Width = 300;
            // 
            // N_Parte
            // 
            this.N_Parte.DataPropertyName = "N_Parte";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.N_Parte.DefaultCellStyle = dataGridViewCellStyle4;
            this.N_Parte.HeaderText = "Parte";
            this.N_Parte.Name = "N_Parte";
            this.N_Parte.ReadOnly = true;
            this.N_Parte.Width = 150;
            // 
            // Cod_Und_Med
            // 
            this.Cod_Und_Med.DataPropertyName = "Cod_Und_Med";
            this.Cod_Und_Med.HeaderText = "Cod_Und_Med";
            this.Cod_Und_Med.Name = "Cod_Und_Med";
            this.Cod_Und_Med.ReadOnly = true;
            this.Cod_Und_Med.Visible = false;
            // 
            // Unid_Med
            // 
            this.Unid_Med.DataPropertyName = "Unid_Med";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Unid_Med.DefaultCellStyle = dataGridViewCellStyle5;
            this.Unid_Med.HeaderText = "Unid Med.";
            this.Unid_Med.Name = "Unid_Med";
            this.Unid_Med.ReadOnly = true;
            // 
            // Ubicacion
            // 
            this.Ubicacion.DataPropertyName = "Ubicacion";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Ubicacion.DefaultCellStyle = dataGridViewCellStyle6;
            this.Ubicacion.HeaderText = "Ubicación";
            this.Ubicacion.Name = "Ubicacion";
            this.Ubicacion.ReadOnly = true;
            // 
            // Aplicabilidad
            // 
            this.Aplicabilidad.DataPropertyName = "Aplicabilidad";
            this.Aplicabilidad.HeaderText = "Aplicabilidad";
            this.Aplicabilidad.Name = "Aplicabilidad";
            this.Aplicabilidad.ReadOnly = true;
            this.Aplicabilidad.Visible = false;
            // 
            // Cod_Aplicabilidad
            // 
            this.Cod_Aplicabilidad.DataPropertyName = "Cod_Aplicabilidad";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cod_Aplicabilidad.DefaultCellStyle = dataGridViewCellStyle7;
            this.Cod_Aplicabilidad.HeaderText = "Cod.Aplica.";
            this.Cod_Aplicabilidad.Name = "Cod_Aplicabilidad";
            this.Cod_Aplicabilidad.ReadOnly = true;
            this.Cod_Aplicabilidad.Visible = false;
            this.Cod_Aplicabilidad.Width = 80;
            // 
            // Des_Aplicabilidad
            // 
            this.Des_Aplicabilidad.DataPropertyName = "Des_Aplicabilidad";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Des_Aplicabilidad.DefaultCellStyle = dataGridViewCellStyle8;
            this.Des_Aplicabilidad.HeaderText = "Aplicabilidad";
            this.Des_Aplicabilidad.Name = "Des_Aplicabilidad";
            this.Des_Aplicabilidad.ReadOnly = true;
            this.Des_Aplicabilidad.Width = 300;
            // 
            // Des_Mecanicos
            // 
            this.Des_Mecanicos.DataPropertyName = "Des_Mecanicos";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Des_Mecanicos.DefaultCellStyle = dataGridViewCellStyle9;
            this.Des_Mecanicos.HeaderText = "Des.Mecanica";
            this.Des_Mecanicos.Name = "Des_Mecanicos";
            this.Des_Mecanicos.ReadOnly = true;
            this.Des_Mecanicos.Width = 300;
            // 
            // Frm_RepuestoGrupoSubGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 613);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.dgvProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_RepuestoGrupoSubGrupo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Repuestos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_RepuestoGrupoSubGrupo_FormClosed);
            this.Load += new System.EventHandler(this.Frm_RepuestoGrupoSubGrupo_Load);
            this.groupBox3.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox txtBusqueda;
        internal System.Windows.Forms.ComboBox cboBusqueda;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewLinkColumn Detalle;
        private System.Windows.Forms.DataGridViewLinkColumn Detalle1;
        private System.Windows.Forms.DataGridViewLinkColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion_Tarde;
        private System.Windows.Forms.DataGridViewTextBoxColumn N_Parte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Und_Med;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unid_Med;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aplicabilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cod_Aplicabilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Des_Aplicabilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Des_Mecanicos;
    }
}