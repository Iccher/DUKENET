namespace Logistica.Ingenieria.Presentacion.Consultas
{
    partial class Frm_Ingreso_AI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Ingreso_AI));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cboBusqueda = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvValesIng = new System.Windows.Forms.DataGridView();
            this.panelDetalle = new System.Windows.Forms.Panel();
            this.lblProv = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblGuia = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblFac = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblOC = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl17 = new System.Windows.Forms.Label();
            this.lbl16 = new System.Windows.Forms.Label();
            this.lbl15 = new System.Windows.Forms.Label();
            this.lbl14 = new System.Windows.Forms.Label();
            this.lbl13 = new System.Windows.Forms.Label();
            this.lbl12 = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValesIng)).BeginInit();
            this.panelDetalle.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExcel);
            this.groupBox3.Location = new System.Drawing.Point(883, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(67, 75);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.icono_excel1;
            this.btnExcel.Location = new System.Drawing.Point(6, 12);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(55, 57);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtBusqueda);
            this.GroupBox1.Controls.Add(this.cboBusqueda);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.Color.Navy;
            this.GroupBox1.Location = new System.Drawing.Point(51, 89);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(601, 45);
            this.GroupBox1.TabIndex = 23;
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
            this.groupBox6.Size = new System.Drawing.Size(802, 75);
            this.groupBox6.TabIndex = 22;
            this.groupBox6.TabStop = false;
            // 
            // lblBusqueda
            // 
            this.lblBusqueda.BackColor = System.Drawing.Color.White;
            this.lblBusqueda.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblBusqueda.Location = new System.Drawing.Point(6, 41);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(785, 29);
            this.lblBusqueda.TabIndex = 1;
            this.lblBusqueda.Text = "Ingresos de Almacen Ingeniría";
            this.lblBusqueda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(785, 29);
            this.label11.TabIndex = 0;
            this.label11.Text = "Almacén de Ingeniería";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvValesIng
            // 
            this.dgvValesIng.AllowUserToAddRows = false;
            this.dgvValesIng.AllowUserToDeleteRows = false;
            this.dgvValesIng.AllowUserToOrderColumns = true;
            this.dgvValesIng.AllowUserToResizeColumns = false;
            this.dgvValesIng.AllowUserToResizeRows = false;
            this.dgvValesIng.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvValesIng.BackgroundColor = System.Drawing.Color.White;
            this.dgvValesIng.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvValesIng.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvValesIng.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValesIng.Location = new System.Drawing.Point(12, 140);
            this.dgvValesIng.Name = "dgvValesIng";
            this.dgvValesIng.ReadOnly = true;
            this.dgvValesIng.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvValesIng.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvValesIng.Size = new System.Drawing.Size(1507, 558);
            this.dgvValesIng.TabIndex = 26;
            this.dgvValesIng.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvValesIng_CellDoubleClick);
            // 
            // panelDetalle
            // 
            this.panelDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetalle.Controls.Add(this.lblProv);
            this.panelDetalle.Controls.Add(this.label19);
            this.panelDetalle.Controls.Add(this.lblGuia);
            this.panelDetalle.Controls.Add(this.label20);
            this.panelDetalle.Controls.Add(this.lblFac);
            this.panelDetalle.Controls.Add(this.label9);
            this.panelDetalle.Controls.Add(this.lblOC);
            this.panelDetalle.Controls.Add(this.label8);
            this.panelDetalle.Controls.Add(this.lbl17);
            this.panelDetalle.Controls.Add(this.lbl16);
            this.panelDetalle.Controls.Add(this.lbl15);
            this.panelDetalle.Controls.Add(this.lbl14);
            this.panelDetalle.Controls.Add(this.lbl13);
            this.panelDetalle.Controls.Add(this.lbl12);
            this.panelDetalle.Controls.Add(this.lbl11);
            this.panelDetalle.Controls.Add(this.lbl10);
            this.panelDetalle.Controls.Add(this.lbl9);
            this.panelDetalle.Controls.Add(this.lbl5);
            this.panelDetalle.Controls.Add(this.lbl4);
            this.panelDetalle.Controls.Add(this.lbl3);
            this.panelDetalle.Controls.Add(this.lbl2);
            this.panelDetalle.Controls.Add(this.lbl1);
            this.panelDetalle.Controls.Add(this.button1);
            this.panelDetalle.Controls.Add(this.label18);
            this.panelDetalle.Controls.Add(this.label15);
            this.panelDetalle.Controls.Add(this.label16);
            this.panelDetalle.Controls.Add(this.label17);
            this.panelDetalle.Controls.Add(this.label14);
            this.panelDetalle.Controls.Add(this.label13);
            this.panelDetalle.Controls.Add(this.label2);
            this.panelDetalle.Controls.Add(this.label12);
            this.panelDetalle.Controls.Add(this.label10);
            this.panelDetalle.Controls.Add(this.label6);
            this.panelDetalle.Controls.Add(this.label5);
            this.panelDetalle.Controls.Add(this.label4);
            this.panelDetalle.Controls.Add(this.label3);
            this.panelDetalle.Controls.Add(this.label1);
            this.panelDetalle.Location = new System.Drawing.Point(483, 201);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Size = new System.Drawing.Size(686, 383);
            this.panelDetalle.TabIndex = 27;
            this.panelDetalle.Visible = false;
            // 
            // lblProv
            // 
            this.lblProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProv.ForeColor = System.Drawing.Color.Black;
            this.lblProv.Location = new System.Drawing.Point(133, 79);
            this.lblProv.Name = "lblProv";
            this.lblProv.Size = new System.Drawing.Size(464, 20);
            this.lblProv.TabIndex = 43;
            this.lblProv.Text = "label7";
            this.lblProv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Navy;
            this.label19.Location = new System.Drawing.Point(42, 79);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(85, 20);
            this.label19.TabIndex = 42;
            this.label19.Text = "Proveedor  :";
            // 
            // lblGuia
            // 
            this.lblGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGuia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuia.ForeColor = System.Drawing.Color.Black;
            this.lblGuia.Location = new System.Drawing.Point(541, 127);
            this.lblGuia.Name = "lblGuia";
            this.lblGuia.Size = new System.Drawing.Size(98, 20);
            this.lblGuia.TabIndex = 41;
            this.lblGuia.Text = "label7";
            this.lblGuia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Navy;
            this.label20.Location = new System.Drawing.Point(470, 127);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(65, 20);
            this.label20.TabIndex = 40;
            this.label20.Text = "Guia      :";
            // 
            // lblFac
            // 
            this.lblFac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFac.ForeColor = System.Drawing.Color.Black;
            this.lblFac.Location = new System.Drawing.Point(342, 127);
            this.lblFac.Name = "lblFac";
            this.lblFac.Size = new System.Drawing.Size(98, 20);
            this.lblFac.TabIndex = 39;
            this.lblFac.Text = "label7";
            this.lblFac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(259, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 20);
            this.label9.TabIndex = 38;
            this.label9.Text = "Factura   :";
            // 
            // lblOC
            // 
            this.lblOC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOC.ForeColor = System.Drawing.Color.Black;
            this.lblOC.Location = new System.Drawing.Point(132, 127);
            this.lblOC.Name = "lblOC";
            this.lblOC.Size = new System.Drawing.Size(98, 20);
            this.lblOC.TabIndex = 37;
            this.lblOC.Text = "label7";
            this.lblOC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(61, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 36;
            this.label8.Text = "O/C      :";
            // 
            // lbl17
            // 
            this.lbl17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl17.ForeColor = System.Drawing.Color.Black;
            this.lbl17.Location = new System.Drawing.Point(130, 316);
            this.lbl17.Name = "lbl17";
            this.lbl17.Size = new System.Drawing.Size(110, 20);
            this.lbl17.TabIndex = 35;
            this.lbl17.Text = "lbl17";
            this.lbl17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl16
            // 
            this.lbl16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl16.ForeColor = System.Drawing.Color.Black;
            this.lbl16.Location = new System.Drawing.Point(543, 280);
            this.lbl16.Name = "lbl16";
            this.lbl16.Size = new System.Drawing.Size(74, 20);
            this.lbl16.TabIndex = 34;
            this.lbl16.Text = "lbl16";
            this.lbl16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl15
            // 
            this.lbl15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl15.ForeColor = System.Drawing.Color.Black;
            this.lbl15.Location = new System.Drawing.Point(356, 279);
            this.lbl15.Name = "lbl15";
            this.lbl15.Size = new System.Drawing.Size(74, 20);
            this.lbl15.TabIndex = 33;
            this.lbl15.Text = "lbl15";
            this.lbl15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl14
            // 
            this.lbl14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl14.ForeColor = System.Drawing.Color.Black;
            this.lbl14.Location = new System.Drawing.Point(129, 280);
            this.lbl14.Name = "lbl14";
            this.lbl14.Size = new System.Drawing.Size(88, 20);
            this.lbl14.TabIndex = 32;
            this.lbl14.Text = "lbl14";
            this.lbl14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl13
            // 
            this.lbl13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl13.ForeColor = System.Drawing.Color.Black;
            this.lbl13.Location = new System.Drawing.Point(543, 248);
            this.lbl13.Name = "lbl13";
            this.lbl13.Size = new System.Drawing.Size(74, 20);
            this.lbl13.TabIndex = 31;
            this.lbl13.Text = "lbl13";
            this.lbl13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl12
            // 
            this.lbl12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl12.ForeColor = System.Drawing.Color.Black;
            this.lbl12.Location = new System.Drawing.Point(356, 248);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(74, 20);
            this.lbl12.TabIndex = 30;
            this.lbl12.Text = "lbl12";
            this.lbl12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl11
            // 
            this.lbl11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl11.ForeColor = System.Drawing.Color.Black;
            this.lbl11.Location = new System.Drawing.Point(129, 249);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(88, 20);
            this.lbl11.TabIndex = 29;
            this.lbl11.Text = "lbl11";
            this.lbl11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl10
            // 
            this.lbl10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl10.ForeColor = System.Drawing.Color.Black;
            this.lbl10.Location = new System.Drawing.Point(356, 214);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(159, 20);
            this.lbl10.TabIndex = 28;
            this.lbl10.Text = "lbl10";
            this.lbl10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl9
            // 
            this.lbl9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl9.ForeColor = System.Drawing.Color.Black;
            this.lbl9.Location = new System.Drawing.Point(129, 214);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(71, 20);
            this.lbl9.TabIndex = 27;
            this.lbl9.Text = "lbl9";
            this.lbl9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl5
            // 
            this.lbl5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.ForeColor = System.Drawing.Color.Black;
            this.lbl5.Location = new System.Drawing.Point(428, 170);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(111, 20);
            this.lbl5.TabIndex = 23;
            this.lbl5.Text = "lbl5";
            this.lbl5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl4
            // 
            this.lbl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.ForeColor = System.Drawing.Color.Black;
            this.lbl4.Location = new System.Drawing.Point(135, 170);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(111, 20);
            this.lbl4.TabIndex = 22;
            this.lbl4.Text = "lbl4";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl3
            // 
            this.lbl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.ForeColor = System.Drawing.Color.Black;
            this.lbl3.Location = new System.Drawing.Point(423, 43);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(110, 20);
            this.lbl3.TabIndex = 21;
            this.lbl3.Text = "lbl3";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl2
            // 
            this.lbl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.Black;
            this.lbl2.Location = new System.Drawing.Point(131, 43);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(98, 20);
            this.lbl2.TabIndex = 20;
            this.lbl2.Text = "lbl2";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl1
            // 
            this.lbl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.Black;
            this.lbl1.Location = new System.Drawing.Point(131, 14);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(466, 20);
            this.lbl1.TabIndex = 19;
            this.lbl1.Text = "lbl1";
            this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Cerrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Navy;
            this.label18.Location = new System.Drawing.Point(28, 317);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 20);
            this.label18.TabIndex = 17;
            this.label18.Text = "Ubicacion      :";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(443, 280);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 20);
            this.label15.TabIndex = 16;
            this.label15.Text = "Stock. Vig.      :";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(236, 280);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(127, 20);
            this.label16.TabIndex = 15;
            this.label16.Text = "Pedido Reposic.   :";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Navy;
            this.label17.Location = new System.Drawing.Point(16, 280);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 20);
            this.label17.TabIndex = 14;
            this.label17.Text = "Stock Emerg.     :";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(443, 249);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 20);
            this.label14.TabIndex = 13;
            this.label14.Text = "Stock. Min      :";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(256, 249);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 20);
            this.label13.TabIndex = 12;
            this.label13.Text = "Stock. Max     :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(27, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Und. Med.      :";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(246, 215);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 20);
            this.label12.TabIndex = 10;
            this.label12.Text = "Procedencia      :";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(27, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 20);
            this.label10.TabIndex = 9;
            this.label10.Text = "Cta.Cargo       :";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(326, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Costo S/.       :";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(44, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cantidad    :";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(331, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nro Ing.      :";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(28, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha Ing      :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(40, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Producto    :";
            // 
            // Frm_Ingreso_AI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1544, 716);
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.dgvValesIng);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.groupBox6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Ingreso_AI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consumos de Almacen Ingeniería";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Consumos_AI_Load);
            this.groupBox3.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValesIng)).EndInit();
            this.panelDetalle.ResumeLayout(false);
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
        public System.Windows.Forms.DataGridView dgvValesIng;
        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl17;
        private System.Windows.Forms.Label lbl16;
        private System.Windows.Forms.Label lbl15;
        private System.Windows.Forms.Label lbl14;
        private System.Windows.Forms.Label lbl13;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Label lblGuia;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblFac;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblOC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblProv;
        private System.Windows.Forms.Label label19;
    }
}