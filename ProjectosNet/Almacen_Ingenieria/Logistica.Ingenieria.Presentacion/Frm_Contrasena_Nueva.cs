using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Logistica.Ingenieria.Presentacion
{
    public partial class Frm_Contrasena_Nueva : Form
    {
        public Frm_Contrasena_Nueva()
        {
            InitializeComponent();
        }

        public string flag = "";

        private void Frm_Contrasena_Nueva_Load(object sender, EventArgs e)
        {
            txtPwd.CharacterCasing = CharacterCasing.Upper;
            txtPwd.Focus();
        }

        void newPWD()
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Contrasena_Verificada frm = new Frm_Contrasena_Verificada();
            frm.NewContrasena = txtPwd.Text.ToUpper().Trim();
            frm.ShowDialog();
            if (frm.flag == "1")
            {
                flag = frm.flag;
                this.Close();
            }

            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newPWD();        
        }        

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) newPWD();
        }

        private void Frm_Contrasena_Nueva_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
