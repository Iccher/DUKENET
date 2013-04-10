namespace Logistica.Ingenieria.Presentacion
{
    partial class Frm_Configuracion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Configuracion));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUsu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvArea = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboNivelUser = new System.Windows.Forms.ComboBox();
            this.dgvUsuarios1 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lvCtaAlm = new System.Windows.Forms.ListView();
            this.Column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dgvUsuarios2 = new System.Windows.Forms.DataGridView();
            this.lvAccesos = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblBusqueda);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(802, 75);
            this.groupBox6.TabIndex = 29;
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
            this.lblBusqueda.Text = "Configuración";
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
            this.label11.Text = "Almacén de Utiles";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(12, 103);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(802, 454);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.txtCod);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtNom);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.btnModifica);
            this.tabPage1.Controls.Add(this.btnNuevo);
            this.tabPage1.Controls.Add(this.txtPwd);
            this.tabPage1.Controls.Add(this.txtUsu);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dgvUsuarios);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.ImageIndex = 2;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(794, 427);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Usuarios";
            this.tabPage1.ToolTipText = "Usuarios";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.barra07;
            this.button1.Location = new System.Drawing.Point(606, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 57);
            this.button1.TabIndex = 41;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.BUSCAR1;
            this.btnBuscar.Location = new System.Drawing.Point(751, 137);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(29, 28);
            this.btnBuscar.TabIndex = 40;
            this.btnBuscar.Text = "...";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCod
            // 
            this.txtCod.BackColor = System.Drawing.Color.White;
            this.txtCod.Enabled = false;
            this.txtCod.Location = new System.Drawing.Point(452, 100);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(76, 20);
            this.txtCod.TabIndex = 39;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(369, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 29);
            this.label5.TabIndex = 38;
            this.label5.Text = "Codigo :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNom
            // 
            this.txtNom.BackColor = System.Drawing.Color.White;
            this.txtNom.Enabled = false;
            this.txtNom.Location = new System.Drawing.Point(452, 142);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(293, 20);
            this.txtNom.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(369, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 29);
            this.label4.TabIndex = 36;
            this.label4.Text = "Nombre :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.barra04;
            this.btnEliminar.Location = new System.Drawing.Point(545, 263);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(55, 57);
            this.btnEliminar.TabIndex = 35;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.barra03;
            this.btnModifica.Location = new System.Drawing.Point(484, 263);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(55, 57);
            this.btnModifica.TabIndex = 34;
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.barra01;
            this.btnNuevo.Location = new System.Drawing.Point(423, 263);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(55, 57);
            this.btnNuevo.TabIndex = 33;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.Color.White;
            this.txtPwd.Enabled = false;
            this.txtPwd.Location = new System.Drawing.Point(452, 228);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(144, 20);
            this.txtPwd.TabIndex = 32;
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // txtUsu
            // 
            this.txtUsu.BackColor = System.Drawing.Color.White;
            this.txtUsu.Enabled = false;
            this.txtUsu.Location = new System.Drawing.Point(452, 183);
            this.txtUsu.Name = "txtUsu";
            this.txtUsu.Size = new System.Drawing.Size(144, 20);
            this.txtUsu.TabIndex = 31;
            this.txtUsu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsu_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(97, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(583, 29);
            this.label3.TabIndex = 30;
            this.label3.Text = "Usuarios Modulo Almacen de Ingenieria";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(354, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 29);
            this.label2.TabIndex = 29;
            this.label2.Text = "Password :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToResizeColumns = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(6, 67);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsuarios.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsuarios.Size = new System.Drawing.Size(339, 336);
            this.dgvUsuarios.TabIndex = 28;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(369, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.dgvUsuarios1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.lvCtaAlm);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(794, 427);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Autozación";
            this.tabPage2.ToolTipText = "Autozación";
            // 
            // button2
            // 
            this.button2.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.barra07;
            this.button2.Location = new System.Drawing.Point(318, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 57);
            this.button2.TabIndex = 45;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.barra04;
            this.button3.Location = new System.Drawing.Point(379, 355);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 57);
            this.button3.TabIndex = 44;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvArea);
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(540, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 220);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Area";
            // 
            // lvArea
            // 
            this.lvArea.CheckBoxes = true;
            this.lvArea.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvArea.GridLines = true;
            this.lvArea.Location = new System.Drawing.Point(6, 19);
            this.lvArea.Name = "lvArea";
            this.lvArea.Size = new System.Drawing.Size(232, 195);
            this.lvArea.TabIndex = 2;
            this.lvArea.UseCompatibleStateImageBehavior = false;
            this.lvArea.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "";
            this.columnHeader1.Text = "Cod.Ar.";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Area";
            this.columnHeader2.Width = 175;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboNivelUser);
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(540, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 59);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nivel de Usuario";
            // 
            // cboNivelUser
            // 
            this.cboNivelUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivelUser.FormattingEnabled = true;
            this.cboNivelUser.Items.AddRange(new object[] {
            "",
            "Gerente",
            "Jefatura",
            "Supervisor",
            "Mecanico",
            "Almacenero"});
            this.cboNivelUser.Location = new System.Drawing.Point(7, 20);
            this.cboNivelUser.Name = "cboNivelUser";
            this.cboNivelUser.Size = new System.Drawing.Size(231, 21);
            this.cboNivelUser.TabIndex = 0;
            // 
            // dgvUsuarios1
            // 
            this.dgvUsuarios1.AllowUserToAddRows = false;
            this.dgvUsuarios1.AllowUserToDeleteRows = false;
            this.dgvUsuarios1.AllowUserToOrderColumns = true;
            this.dgvUsuarios1.AllowUserToResizeColumns = false;
            this.dgvUsuarios1.AllowUserToResizeRows = false;
            this.dgvUsuarios1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios1.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvUsuarios1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUsuarios1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios1.Location = new System.Drawing.Point(8, 64);
            this.dgvUsuarios1.Name = "dgvUsuarios1";
            this.dgvUsuarios1.ReadOnly = true;
            this.dgvUsuarios1.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsuarios1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsuarios1.Size = new System.Drawing.Size(266, 279);
            this.dgvUsuarios1.TabIndex = 32;
            this.dgvUsuarios1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios1_CellContentClick);
            this.dgvUsuarios1.SelectionChanged += new System.EventHandler(this.dgvUsuarios1_SelectionChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(96, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(583, 29);
            this.label6.TabIndex = 31;
            this.label6.Text = "Accesos Cuentas Almacen de Ingenieria";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvCtaAlm
            // 
            this.lvCtaAlm.CheckBoxes = true;
            this.lvCtaAlm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Column1,
            this.Column2});
            this.lvCtaAlm.GridLines = true;
            this.lvCtaAlm.Location = new System.Drawing.Point(283, 64);
            this.lvCtaAlm.Name = "lvCtaAlm";
            this.lvCtaAlm.Size = new System.Drawing.Size(251, 279);
            this.lvCtaAlm.TabIndex = 1;
            this.lvCtaAlm.UseCompatibleStateImageBehavior = false;
            this.lvCtaAlm.View = System.Windows.Forms.View.Details;
            // 
            // Column1
            // 
            this.Column1.Tag = "";
            this.Column1.Text = "Cta.Alm.";
            this.Column1.Width = 63;
            // 
            // Column2
            // 
            this.Column2.Text = "Almacen";
            this.Column2.Width = 180;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.dgvUsuarios2);
            this.tabPage3.Controls.Add(this.lvAccesos);
            this.tabPage3.ImageIndex = 3;
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(794, 427);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Accesos";
            this.tabPage3.ToolTipText = "Accesos";
            // 
            // button5
            // 
            this.button5.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.barra04;
            this.button5.Location = new System.Drawing.Point(404, 339);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(55, 57);
            this.button5.TabIndex = 50;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Image = global::Logistica.Ingenieria.Presentacion.Properties.Resources.barra07;
            this.button4.Location = new System.Drawing.Point(343, 339);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 57);
            this.button4.TabIndex = 47;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dgvUsuarios2
            // 
            this.dgvUsuarios2.AllowUserToAddRows = false;
            this.dgvUsuarios2.AllowUserToDeleteRows = false;
            this.dgvUsuarios2.AllowUserToOrderColumns = true;
            this.dgvUsuarios2.AllowUserToResizeColumns = false;
            this.dgvUsuarios2.AllowUserToResizeRows = false;
            this.dgvUsuarios2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsuarios2.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvUsuarios2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvUsuarios2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios2.Location = new System.Drawing.Point(6, 44);
            this.dgvUsuarios2.Name = "dgvUsuarios2";
            this.dgvUsuarios2.ReadOnly = true;
            this.dgvUsuarios2.RowHeadersVisible = false;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUsuarios2.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsuarios2.Size = new System.Drawing.Size(364, 279);
            this.dgvUsuarios2.TabIndex = 34;
            this.dgvUsuarios2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios2_CellContentClick);
            this.dgvUsuarios2.SelectionChanged += new System.EventHandler(this.dgvUsuarios2_SelectionChanged);
            // 
            // lvAccesos
            // 
            this.lvAccesos.CheckBoxes = true;
            this.lvAccesos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lvAccesos.GridLines = true;
            this.lvAccesos.Location = new System.Drawing.Point(376, 44);
            this.lvAccesos.Name = "lvAccesos";
            this.lvAccesos.Size = new System.Drawing.Size(409, 279);
            this.lvAccesos.TabIndex = 33;
            this.lvAccesos.UseCompatibleStateImageBehavior = false;
            this.lvAccesos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "";
            this.columnHeader3.Text = "Codigo";
            this.columnHeader3.Width = 97;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Accesos";
            this.columnHeader4.Width = 300;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "CLIENTES.bmp");
            this.imageList1.Images.SetKeyName(1, "ACCESOS.bmp");
            this.imageList1.Images.SetKeyName(2, "USER.ICO");
            this.imageList1.Images.SetKeyName(3, "AS.ICO");
            this.imageList1.Images.SetKeyName(4, "ASOCIADO.ICO");
            // 
            // Frm_Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 569);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Configuracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametros de Congifuración";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Configuracion_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Configuracion_Load);
            this.groupBox6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUsu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvCtaAlm;
        private System.Windows.Forms.ColumnHeader Column1;
        private System.Windows.Forms.ColumnHeader Column2;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.DataGridView dgvUsuarios1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboNivelUser;
        private System.Windows.Forms.ListView lvArea;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.DataGridView dgvUsuarios2;
        private System.Windows.Forms.ListView lvAccesos;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}