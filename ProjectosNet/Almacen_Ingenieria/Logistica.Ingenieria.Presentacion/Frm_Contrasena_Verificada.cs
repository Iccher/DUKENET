using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Bussiness;

namespace Logistica.Ingenieria.Presentacion
{
    public partial class Frm_Contrasena_Verificada : Form
    {
        public Frm_Contrasena_Verificada()
        {
            InitializeComponent();
        }

        public string NewContrasena = "";
        public string flag = "";

        BTransaccion obj = new BTransaccion();

        private void button1_Click(object sender, EventArgs e)
        {
            newPWD();
        }

        void newPWD()
        {
            this.Cursor = Cursors.WaitCursor;
            if (txtPwd.Text.Trim() == NewContrasena.Trim())
            {
                obj = new BTransaccion();
                int j = obj.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALIUSERS SET CODPWD='" + txtPwd.Text.Trim() + "' WHERE CODUSE='" + Program.Usuario + "'");
                MessageBox.Show("Se realizó la actualización de la clave de manera correcta", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Frm_Contrasena_Nueva frm = new Frm_Contrasena_Nueva();
                flag = "1";
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe Reingresar la misma clave", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Cursor = Cursors.Default;
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) newPWD();
        }

        private void Frm_Contrasena_Verificada_Load(object sender, EventArgs e)
        {
            txtPwd.CharacterCasing = CharacterCasing.Upper;
            txtPwd.Focus();
        }

        private void Frm_Contrasena_Verificada_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
