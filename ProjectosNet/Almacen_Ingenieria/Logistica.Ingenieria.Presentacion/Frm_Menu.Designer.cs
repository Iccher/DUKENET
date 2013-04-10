namespace Logistica.Ingenieria.Presentacion
{
    partial class Frm_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Menu));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.RQG01 = new System.Windows.Forms.ToolStripButton();
            this.RQG01T = new System.Windows.Forms.ToolStripSeparator();
            this.RQG02 = new System.Windows.Forms.ToolStripButton();
            this.RQG02T = new System.Windows.Forms.ToolStripSeparator();
            this.RQG04 = new System.Windows.Forms.ToolStripButton();
            this.RQG04T = new System.Windows.Forms.ToolStripSeparator();
            this.RQGSalir = new System.Windows.Forms.ToolStripButton();
            this.RQGSalirT = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Sistema = new System.Windows.Forms.ToolStripMenuItem();
            this.RQGSalirS1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RQG06S = new System.Windows.Forms.ToolStripMenuItem();
            this.cambioContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignacionCCTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Transaccion = new System.Windows.Forms.ToolStripMenuItem();
            this.RQG01S = new System.Windows.Forms.ToolStripMenuItem();
            this.RQG02S = new System.Windows.Forms.ToolStripMenuItem();
            this.RQG04S = new System.Windows.Forms.ToolStripMenuItem();
            this.Consultas = new System.Windows.Forms.ToolStripMenuItem();
            this.RQG07S = new System.Windows.Forms.ToolStripMenuItem();
            this.RQGSalirS = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RQG01,
            this.RQG01T,
            this.RQG02,
            this.RQG02T,
            this.RQG04,
            this.RQG04T,
            this.RQGSalir,
            this.RQGSalirT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(663, 61);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // RQG01
            // 
            this.RQG01.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.BO;
            this.RQG01.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RQG01.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RQG01.Margin = new System.Windows.Forms.Padding(14, 5, 14, 5);
            this.RQG01.Name = "RQG01";
            this.RQG01.Size = new System.Drawing.Size(57, 51);
            this.RQG01.Text = "Solicitud";
            this.RQG01.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RQG01.Visible = false;
            this.RQG01.Click += new System.EventHandler(this.tsbFactura_Click);
            // 
            // RQG01T
            // 
            this.RQG01T.Name = "RQG01T";
            this.RQG01T.Size = new System.Drawing.Size(6, 61);
            this.RQG01T.Visible = false;
            // 
            // RQG02
            // 
            this.RQG02.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.NOTAS121;
            this.RQG02.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RQG02.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RQG02.Margin = new System.Windows.Forms.Padding(14, 5, 14, 5);
            this.RQG02.Name = "RQG02";
            this.RQG02.Size = new System.Drawing.Size(73, 51);
            this.RQG02.Text = "Aprobación";
            this.RQG02.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RQG02.ToolTipText = "Aprobación";
            this.RQG02.Visible = false;
            this.RQG02.Click += new System.EventHandler(this.tbsAprobacion_Click);
            // 
            // RQG02T
            // 
            this.RQG02T.Name = "RQG02T";
            this.RQG02T.Size = new System.Drawing.Size(6, 61);
            this.RQG02T.Visible = false;
            // 
            // RQG04
            // 
            this.RQG04.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.FACTURAR;
            this.RQG04.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RQG04.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RQG04.Margin = new System.Windows.Forms.Padding(14, 5, 14, 5);
            this.RQG04.Name = "RQG04";
            this.RQG04.Size = new System.Drawing.Size(112, 51);
            this.RQG04.Text = "Aprobación Trabaj.";
            this.RQG04.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RQG04.ToolTipText = "Aprobación Trabaj.";
            this.RQG04.Visible = false;
            this.RQG04.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // RQG04T
            // 
            this.RQG04T.Name = "RQG04T";
            this.RQG04T.Size = new System.Drawing.Size(6, 61);
            this.RQG04T.Visible = false;
            // 
            // RQGSalir
            // 
            this.RQGSalir.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.close;
            this.RQGSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.RQGSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RQGSalir.Margin = new System.Windows.Forms.Padding(14, 5, 14, 5);
            this.RQGSalir.Name = "RQGSalir";
            this.RQGSalir.Size = new System.Drawing.Size(36, 51);
            this.RQGSalir.Text = "Salir";
            this.RQGSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RQGSalir.ToolTipText = "Salir";
            this.RQGSalir.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // RQGSalirT
            // 
            this.RQGSalirT.Name = "RQGSalirT";
            this.RQGSalirT.Size = new System.Drawing.Size(6, 61);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sistema,
            this.Transaccion,
            this.Consultas,
            this.RQGSalirS});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(663, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Sistema
            // 
            this.Sistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RQGSalirS1,
            this.RQG06S,
            this.cambioContraseñaToolStripMenuItem,
            this.asignacionCCTToolStripMenuItem});
            this.Sistema.Name = "Sistema";
            this.Sistema.Size = new System.Drawing.Size(60, 20);
            this.Sistema.Text = "&Sistema";
            // 
            // RQGSalirS1
            // 
            this.RQGSalirS1.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.close;
            this.RQGSalirS1.Name = "RQGSalirS1";
            this.RQGSalirS1.Size = new System.Drawing.Size(179, 22);
            this.RQGSalirS1.Text = "Salir...";
            this.RQGSalirS1.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // RQG06S
            // 
            this.RQG06S.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.ACCESOS;
            this.RQG06S.Name = "RQG06S";
            this.RQG06S.Size = new System.Drawing.Size(179, 22);
            this.RQG06S.Text = "Configuración";
            this.RQG06S.Visible = false;
            this.RQG06S.Click += new System.EventHandler(this.configuracionToolStripMenuItem_Click);
            // 
            // cambioContraseñaToolStripMenuItem
            // 
            this.cambioContraseñaToolStripMenuItem.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.BO1;
            this.cambioContraseñaToolStripMenuItem.Name = "cambioContraseñaToolStripMenuItem";
            this.cambioContraseñaToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.cambioContraseñaToolStripMenuItem.Text = "Cambio Contraseña";
            this.cambioContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambioContraseñaToolStripMenuItem_Click);
            // 
            // asignacionCCTToolStripMenuItem
            // 
            this.asignacionCCTToolStripMenuItem.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.ASNT1;
            this.asignacionCCTToolStripMenuItem.Name = "asignacionCCTToolStripMenuItem";
            this.asignacionCCTToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.asignacionCCTToolStripMenuItem.Text = "Asignacion CCT";
            this.asignacionCCTToolStripMenuItem.Click += new System.EventHandler(this.asignacionCCTToolStripMenuItem_Click);
            // 
            // Transaccion
            // 
            this.Transaccion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RQG01S,
            this.RQG02S,
            this.RQG04S});
            this.Transaccion.Name = "Transaccion";
            this.Transaccion.Size = new System.Drawing.Size(94, 20);
            this.Transaccion.Text = "&Transacciones";
            // 
            // RQG01S
            // 
            this.RQG01S.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.BO;
            this.RQG01S.Name = "RQG01S";
            this.RQG01S.Size = new System.Drawing.Size(146, 22);
            this.RQG01S.Text = "Solicitud...";
            this.RQG01S.Visible = false;
            this.RQG01S.Click += new System.EventHandler(this.facturaToolStripMenuItem_Click);
            // 
            // RQG02S
            // 
            this.RQG02S.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.APROBAR3;
            this.RQG02S.Name = "RQG02S";
            this.RQG02S.Size = new System.Drawing.Size(146, 22);
            this.RQG02S.Text = "Aprobación";
            this.RQG02S.Visible = false;
            this.RQG02S.Click += new System.EventHandler(this.aprobaciónToolStripMenuItem_Click);
            // 
            // RQG04S
            // 
            this.RQG04S.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.FACTURAR;
            this.RQG04S.Name = "RQG04S";
            this.RQG04S.Size = new System.Drawing.Size(146, 22);
            this.RQG04S.Text = "Aprob.Trabaj.";
            this.RQG04S.Visible = false;
            this.RQG04S.Click += new System.EventHandler(this.genValeMPToolStripMenuItem_Click);
            // 
            // Consultas
            // 
            this.Consultas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RQG07S});
            this.Consultas.Name = "Consultas";
            this.Consultas.Size = new System.Drawing.Size(71, 20);
            this.Consultas.Text = "&Consultas";
            // 
            // RQG07S
            // 
            this.RQG07S.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.BUSCAR;
            this.RQG07S.Name = "RQG07S";
            this.RQG07S.Size = new System.Drawing.Size(131, 22);
            this.RQG07S.Text = "Consumos";
            this.RQG07S.Visible = false;
            this.RQG07S.Click += new System.EventHandler(this.consumosToolStripMenuItem1_Click);
            // 
            // RQGSalirS
            // 
            this.RQGSalirS.Name = "RQGSalirS";
            this.RQGSalirS.Size = new System.Drawing.Size(41, 20);
            this.RQGSalirS.Text = "&Salir";
            this.RQGSalirS.Click += new System.EventHandler(this.salirToolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(450, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "ALMACEN DE UTILES";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(69, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "ALMACEN DE UTILES";
            // 
            // Frm_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = global::Logistica.Ingenieria.Presentacion.Properties.Resources.RM1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(663, 338);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modulo Almacén Servicios Generales";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Menu_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Menu_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton RQG01;
        private System.Windows.Forms.ToolStripSeparator RQG01T;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Sistema;
        private System.Windows.Forms.ToolStripMenuItem RQGSalirS1;
        private System.Windows.Forms.ToolStripMenuItem Transaccion;
        private System.Windows.Forms.ToolStripMenuItem RQG01S;
        private System.Windows.Forms.ToolStripMenuItem Consultas;
        private System.Windows.Forms.ToolStripMenuItem RQG06S;
        private System.Windows.Forms.ToolStripMenuItem RQG07S;
        private System.Windows.Forms.ToolStripMenuItem RQGSalirS;
        private System.Windows.Forms.ToolStripButton RQG02;
        private System.Windows.Forms.ToolStripSeparator RQG02T;
        private System.Windows.Forms.ToolStripMenuItem RQG02S;
        private System.Windows.Forms.ToolStripButton RQG04;
        private System.Windows.Forms.ToolStripSeparator RQG04T;
        private System.Windows.Forms.ToolStripMenuItem RQG04S;
        private System.Windows.Forms.ToolStripButton RQGSalir;
        private System.Windows.Forms.ToolStripSeparator RQGSalirT;
        private System.Windows.Forms.ToolStripMenuItem cambioContraseñaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem asignacionCCTToolStripMenuItem;
        private System.Windows.Forms.Label label2;
    }
}