namespace Logistica.Ingenieria.Presentacion.Sistema
{
    partial class Frm_Asign_CCT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Asign_CCT));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvAsignacion = new System.Windows.Forms.DataGridView();
            this.IDOCOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATCVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATDES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDOARE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.T01AL1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblnom1 = new System.Windows.Forms.Label();
            this.lblcod1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblnom2 = new System.Windows.Forms.Label();
            this.lblcod2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lblnom3 = new System.Windows.Forms.Label();
            this.lblcod3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblBusqueda);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(963, 75);
            this.groupBox6.TabIndex = 30;
            this.groupBox6.TabStop = false;
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.BackColor = System.Drawing.Color.White;
            this.lblBusqueda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblBusqueda.Location = new System.Drawing.Point(6, 41);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(951, 29);
            this.lblBusqueda.TabIndex = 1;
            this.lblBusqueda.Text = "Asign Centro de Costo";
            this.lblBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(951, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "Almacén de Utiles";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvAsignacion
            // 
            this.dgvAsignacion.AllowUserToAddRows = false;
            this.dgvAsignacion.AllowUserToDeleteRows = false;
            this.dgvAsignacion.AllowUserToOrderColumns = true;
            this.dgvAsignacion.AllowUserToResizeColumns = false;
            this.dgvAsignacion.AllowUserToResizeRows = false;
            this.dgvAsignacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAsignacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvAsignacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvAsignacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvAsignacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDOCOD,
            this.TRANOM,
            this.DATCVE,
            this.DATDES,
            this.IDOARE,
            this.T01AL1});
            this.dgvAsignacion.Location = new System.Drawing.Point(12, 93);
            this.dgvAsignacion.Name = "dgvAsignacion";
            this.dgvAsignacion.ReadOnly = true;
            this.dgvAsignacion.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAsignacion.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAsignacion.Size = new System.Drawing.Size(598, 337);
            this.dgvAsignacion.TabIndex = 35;
            this.dgvAsignacion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsignacion_CellContentClick);
            this.dgvAsignacion.SelectionChanged += new System.EventHandler(this.dgvAsignacion_SelectionChanged);
            // 
            // IDOCOD
            // 
            this.IDOCOD.DataPropertyName = "IDOCOD";
            this.IDOCOD.HeaderText = "Codigo";
            this.IDOCOD.Name = "IDOCOD";
            this.IDOCOD.ReadOnly = true;
            this.IDOCOD.Width = 50;
            // 
            // TRANOM
            // 
            this.TRANOM.DataPropertyName = "TRANOM";
            this.TRANOM.HeaderText = "Nombre";
            this.TRANOM.Name = "TRANOM";
            this.TRANOM.ReadOnly = true;
            this.TRANOM.Width = 270;
            // 
            // DATCVE
            // 
            this.DATCVE.DataPropertyName = "DATCVE";
            this.DATCVE.HeaderText = "DATCVE";
            this.DATCVE.Name = "DATCVE";
            this.DATCVE.ReadOnly = true;
            this.DATCVE.Visible = false;
            // 
            // DATDES
            // 
            this.DATDES.DataPropertyName = "DATDES";
            this.DATDES.HeaderText = "DATDES";
            this.DATDES.Name = "DATDES";
            this.DATDES.ReadOnly = true;
            this.DATDES.Visible = false;
            // 
            // IDOARE
            // 
            this.IDOARE.DataPropertyName = "IDOARE";
            this.IDOARE.HeaderText = "Cod.Area";
            this.IDOARE.Name = "IDOARE";
            this.IDOARE.ReadOnly = true;
            this.IDOARE.Width = 70;
            // 
            // T01AL1
            // 
            this.T01AL1.DataPropertyName = "T01AL1";
            this.T01AL1.HeaderText = "Des.Area";
            this.T01AL1.Name = "T01AL1";
            this.T01AL1.ReadOnly = true;
            this.T01AL1.Width = 190;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblnom1);
            this.groupBox1.Controls.Add(this.lblcod1);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(617, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 49);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nombres";
            // 
            // lblnom1
            // 
            this.lblnom1.ForeColor = System.Drawing.Color.Black;
            this.lblnom1.Location = new System.Drawing.Point(80, 20);
            this.lblnom1.Name = "lblnom1";
            this.lblnom1.Size = new System.Drawing.Size(272, 19);
            this.lblnom1.TabIndex = 1;
            this.lblnom1.Text = "lblnom1";
            // 
            // lblcod1
            // 
            this.lblcod1.ForeColor = System.Drawing.Color.Black;
            this.lblcod1.Location = new System.Drawing.Point(15, 20);
            this.lblcod1.Name = "lblcod1";
            this.lblcod1.Size = new System.Drawing.Size(59, 19);
            this.lblcod1.TabIndex = 0;
            this.lblcod1.Text = "lblcod";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblnom2);
            this.groupBox2.Controls.Add(this.lblcod2);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(617, 236);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(358, 49);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Area Actual";
            // 
            // lblnom2
            // 
            this.lblnom2.ForeColor = System.Drawing.Color.Black;
            this.lblnom2.Location = new System.Drawing.Point(80, 20);
            this.lblnom2.Name = "lblnom2";
            this.lblnom2.Size = new System.Drawing.Size(272, 19);
            this.lblnom2.TabIndex = 1;
            this.lblnom2.Text = "lblnom2";
            // 
            // lblcod2
            // 
            this.lblcod2.ForeColor = System.Drawing.Color.Black;
            this.lblcod2.Location = new System.Drawing.Point(15, 20);
            this.lblcod2.Name = "lblcod2";
            this.lblcod2.Size = new System.Drawing.Size(59, 19);
            this.lblcod2.TabIndex = 0;
            this.lblcod2.Text = "lblcod2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.lblnom3);
            this.groupBox3.Controls.Add(this.lblcod3);
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(616, 291);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(358, 49);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Area Asignada";
            // 
            // button2
            // 
            this.button2.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources._16__Find_;
            this.button2.Location = new System.Drawing.Point(328, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblnom3
            // 
            this.lblnom3.ForeColor = System.Drawing.Color.Black;
            this.lblnom3.Location = new System.Drawing.Point(80, 20);
            this.lblnom3.Name = "lblnom3";
            this.lblnom3.Size = new System.Drawing.Size(242, 19);
            this.lblnom3.TabIndex = 1;
            this.lblnom3.Text = "lblnom3";
            // 
            // lblcod3
            // 
            this.lblcod3.ForeColor = System.Drawing.Color.Black;
            this.lblcod3.Location = new System.Drawing.Point(15, 20);
            this.lblcod3.Name = "lblcod3";
            this.lblcod3.Size = new System.Drawing.Size(59, 19);
            this.lblcod3.TabIndex = 0;
            this.lblcod3.Text = "lblcod3";
            // 
            // button1
            // 
            this.button1.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.barra07;
            this.button1.Location = new System.Drawing.Point(763, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 80);
            this.button1.TabIndex = 39;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(617, 93);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(358, 47);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Busqueda";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(134, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Codigo",
            "nombre"});
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(987, 442);
            this.shapeContainer1.TabIndex = 41;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.Navy;
            this.lineShape1.BorderWidth = 3;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 622;
            this.lineShape1.X2 = 974;
            this.lineShape1.Y1 = 159;
            this.lineShape1.Y2 = 159;
            // 
            // Frm_Asign_CCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 442);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAsignacion);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Asign_CCT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación CCT";
            this.Load += new System.EventHandler(this.Frm_Asign_CCT_Load);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignacion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.DataGridView dgvAsignacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDOCOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATCVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATDES;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDOARE;
        private System.Windows.Forms.DataGridViewTextBoxColumn T01AL1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblnom1;
        private System.Windows.Forms.Label lblcod1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblnom2;
        private System.Windows.Forms.Label lblcod2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblnom3;
        private System.Windows.Forms.Label lblcod3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
    }
}