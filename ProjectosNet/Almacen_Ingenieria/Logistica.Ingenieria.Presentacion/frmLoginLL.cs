using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Globalization;

using Logistica.Ingenieria.Bussiness;

namespace Logistica.Ingenieria.Presentacion
{
    public partial class frmLoginLL : Form
    {
        public frmLoginLL()
        {
            InitializeComponent();
        }

        BLogin objBus = new BLogin();

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmLoginLL_Load(object sender, EventArgs e)
        {

            DateTime FechaSis = DateTime.Now;

            CultureInfo ci = new CultureInfo("Es-Es");
            string DIASEMANA = (ci.DateTimeFormat.GetDayName(FechaSis.DayOfWeek)).Substring(0,1);
            //MessageBox.Show(DIASEMANA);

            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox1.Focus();            
        }

        void ProLogin()
        {
            DataTable dtUser = new DataTable();
            this.Cursor = Cursors.WaitCursor;
            dtUser = objBus.DLogUsuaPC(textBox1.Text, textBox2.Text);
            if (dtUser.Rows.Count == 1)
            {
                Frm_Menu frm = new Frm_Menu();
                Program.Usuario = textBox1.Text;
                Program.Password = textBox2.Text;
                Program.codplanillaUSU = dtUser.Rows[0]["CODEMP"].ToString().Trim();

                Program.correo = dtUser.Rows[0]["FILLER"].ToString().Trim();
                Program.NomCorreo = dtUser.Rows[0]["NOMEMP"].ToString().Trim();
                Program.correo2 = dtUser.Rows[0]["FILLER1"].ToString().Trim();
                this.Visible = false;
                frm.Show();
            }
            else
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Verifique el Usuario", "Alm. PT");
            }
            this.Cursor = Cursors.Default;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ProLogin();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) textBox2.Focus();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) ProLogin();
        }

    }
}