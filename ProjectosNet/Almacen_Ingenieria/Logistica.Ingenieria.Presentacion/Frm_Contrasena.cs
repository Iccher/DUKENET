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
    public partial class Frm_Contrasena : Form
    {
        public Frm_Contrasena()
        {
            InitializeComponent();
        }

        BLogin objBus = new BLogin();
        public string flag = "";
        private void button1_Click(object sender, EventArgs e)
        {
            ProLogin();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ProLogin()
        {
            DataTable dtUser = new DataTable();
            this.Cursor = Cursors.WaitCursor;
            dtUser = objBus.DLogUsuaPC(Program.Usuario, txtPwd.Text);
            if (dtUser.Rows.Count == 1)
            {
                Frm_Contrasena_Nueva frm = new Frm_Contrasena_Nueva();
                //this.Visible = false;
                frm.ShowDialog();
                if (frm.flag == "1")
                {
                    this.Close();
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Favor de Ingresar la clave valida", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.Cursor = Cursors.Default;
        }

        private void Frm_Contrasena_Load(object sender, EventArgs e)
        {
            txtPwd.CharacterCasing = CharacterCasing.Upper;
            txtPwd.Focus();
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) ProLogin();
        }

        private void Frm_Contrasena_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
