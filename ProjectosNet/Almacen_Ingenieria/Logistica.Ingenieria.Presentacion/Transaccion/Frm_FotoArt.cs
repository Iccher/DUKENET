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
    public partial class Frm_FotoArt : Form
    {
        public Frm_FotoArt()
        {
            InitializeComponent();
        }

        public string codProd = "";
        public string nomprod = "";
        string rutaProd = "";

        private void Frm_FotoArt_Load(object sender, EventArgs e)
        {
            try
            {
                label1.Text = codProd;
                label2.Text = nomprod;
                rutaProd = "M:\\fotoING\\" + codProd.Trim() + ".jpg";
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Image = Image.FromFile(rutaProd);
            }
            catch
            {
                //rutaProd = "Z:\\Tempus\\Asistencia\\Fotos\\SinFoto.jpg";
                //rutaProd = "M:\\fotoING\\SinFoto.jpg";
                //pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                //pictureBox.Image = Image.FromFile(rutaProd);
            }
        }

        private void Frm_FotoArt_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
