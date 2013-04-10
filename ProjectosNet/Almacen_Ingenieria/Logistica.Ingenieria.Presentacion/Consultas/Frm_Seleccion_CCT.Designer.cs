namespace Logistica.Ingenieria.Presentacion.Consultas
{
    partial class Frm_Seleccion_CCT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Seleccion_CCT));
            this.lvCtaAlmMP = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CHK1 = new System.Windows.Forms.CheckBox();
            this.CHK2 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvCtaAlmMP
            // 
            this.lvCtaAlmMP.CheckBoxes = true;
            this.lvCtaAlmMP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.lvCtaAlmMP.GridLines = true;
            this.lvCtaAlmMP.Location = new System.Drawing.Point(19, 49);
            this.lvCtaAlmMP.Name = "lvCtaAlmMP";
            this.lvCtaAlmMP.Size = new System.Drawing.Size(313, 249);
            this.lvCtaAlmMP.TabIndex = 48;
            this.lvCtaAlmMP.UseCompatibleStateImageBehavior = false;
            this.lvCtaAlmMP.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Cuentas Almacen";
            this.columnHeader4.Width = 298;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CHK2);
            this.groupBox1.Controls.Add(this.CHK1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lvCtaAlmMP);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 308);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cuentas Materia Prima";
            // 
            // button1
            // 
            this.button1.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.BUSCAR3;
            this.button1.Location = new System.Drawing.Point(19, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 49;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.barra07;
            this.button4.Location = new System.Drawing.Point(146, 409);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 57);
            this.button4.TabIndex = 49;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblBusqueda);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(359, 75);
            this.groupBox6.TabIndex = 52;
            this.groupBox6.TabStop = false;
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.BackColor = System.Drawing.Color.White;
            this.lblBusqueda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblBusqueda.Location = new System.Drawing.Point(6, 41);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(347, 29);
            this.lblBusqueda.TabIndex = 1;
            this.lblBusqueda.Text = "Cuentas de Almacen";
            this.lblBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(347, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "Materia Prima";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CHK1
            // 
            this.CHK1.AutoSize = true;
            this.CHK1.Location = new System.Drawing.Point(69, 25);
            this.CHK1.Name = "CHK1";
            this.CHK1.Size = new System.Drawing.Size(61, 17);
            this.CHK1.TabIndex = 50;
            this.CHK1.Text = "Activos";
            this.CHK1.UseVisualStyleBackColor = true;
            // 
            // CHK2
            // 
            this.CHK2.AutoSize = true;
            this.CHK2.Location = new System.Drawing.Point(153, 25);
            this.CHK2.Name = "CHK2";
            this.CHK2.Size = new System.Drawing.Size(71, 17);
            this.CHK2.TabIndex = 51;
            this.CHK2.Text = "Agotados";
            this.CHK2.UseVisualStyleBackColor = true;
            // 
            // Frm_Seleccion_CCT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 475);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Seleccion_CCT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas Almacen";
            this.Load += new System.EventHandler(this.Frm_Seleccion_CCT_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListView lvCtaAlmMP;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox CHK2;
        private System.Windows.Forms.CheckBox CHK1;
    }
}