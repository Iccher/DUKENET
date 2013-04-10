namespace Logistica.Ingenieria.Presentacion.Consultas
{
    partial class Frm_Consuta_ABC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Consuta_ABC));
            this.dgvABC = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvABC)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvABC
            // 
            this.dgvABC.AllowUserToAddRows = false;
            this.dgvABC.AllowUserToDeleteRows = false;
            this.dgvABC.AllowUserToOrderColumns = true;
            this.dgvABC.AllowUserToResizeColumns = false;
            this.dgvABC.AllowUserToResizeRows = false;
            this.dgvABC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvABC.BackgroundColor = System.Drawing.Color.White;
            this.dgvABC.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvABC.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvABC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvABC.Location = new System.Drawing.Point(12, 67);
            this.dgvABC.Name = "dgvABC";
            this.dgvABC.ReadOnly = true;
            this.dgvABC.RowHeadersVisible = false;
            this.dgvABC.Size = new System.Drawing.Size(1018, 494);
            this.dgvABC.TabIndex = 3;
            // 
            // Frm_Consuta_ABC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 573);
            this.Controls.Add(this.dgvABC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Consuta_ABC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta ABC";
            this.Load += new System.EventHandler(this.Frm_Consuta_ABC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvABC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvABC;
    }
}