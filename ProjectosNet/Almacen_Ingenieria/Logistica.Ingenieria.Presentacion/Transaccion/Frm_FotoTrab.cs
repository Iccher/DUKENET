using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Logistica.Ingenieria.Presentacion.Transaccion
{
    public partial class Frm_FotoTrab : Form
    {
        public Frm_FotoTrab()
        {
            InitializeComponent();
        }

        public string codTrab = "";
        public string nomTrab = "";
        string rutaTrabaj = "";
        private void Frm_FotoTrab_Load(object sender, EventArgs e)
        {
            try
            {
                switch (codTrab.Length.ToString())
                {
                    case "1":
                        codTrab = "000" + codTrab;
                        break;
                    case "2":
                        codTrab = "00" + codTrab;
                        break;
                    case "3":
                        codTrab = "0" + codTrab;
                        break;
                    default:
                        break;
                }
                label1.Text = codTrab;
                label2.Text = nomTrab;
                //rutaTrabaj = "Z:\\Tempus\\Asistencia\\Fotos\\" + codTrab + ".jpg";
                rutaTrabaj = "M:\\Fotos\\" + codTrab + ".jpg";
                
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = Image.FromFile(rutaTrabaj);
            }
            catch
            {
                rutaTrabaj = "M:\\Fotos\\SinFoto.jpg";
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = Image.FromFile(rutaTrabaj);
            }

           // pictureBox.Image=new Bitmap(rutaTrabaj);
            
            
        }

        private void Frm_FotoTrab_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
