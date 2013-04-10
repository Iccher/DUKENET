namespace Logistica.Ingenieria.Presentacion.Consultas
{
    partial class Frm_Detalle_Fechas
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvValesIng = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValesIng)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvValesIng);
            this.groupBox2.Location = new System.Drawing.Point(12, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(698, 429);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
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
            this.dgvValesIng.Location = new System.Drawing.Point(6, 10);
            this.dgvValesIng.Name = "dgvValesIng";
            this.dgvValesIng.ReadOnly = true;
            this.dgvValesIng.RowHeadersVisible = false;
            this.dgvValesIng.Size = new System.Drawing.Size(686, 413);
            this.dgvValesIng.TabIndex = 2;
            // 
            // Frm_Detalle_Fechas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 503);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "Frm_Detalle_Fechas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Detalle_Fechas";
            this.Load += new System.EventHandler(this.Frm_Detalle_Fechas_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValesIng)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView dgvValesIng;
    }
}