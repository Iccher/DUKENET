using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Bussiness;
using Logistica.Ingenieria.Utils;
using Logistica.Ingenieria.UtilsC;

namespace Logistica.Ingenieria.Presentacion
{
    public partial class Frm_Configuracion : Form
    {
        public Frm_Configuracion()
        {
            InitializeComponent();
        }

        BConfiguracion oTran = new BConfiguracion();
        DataTable dtUsu = new DataTable();
        BTablas oTablas = new BTablas();


        DataTable dtJefes = new DataTable();
        DataTable dtSupervisores = new DataTable();

        string SW = "";

        private void Frm_Configuracion_Load(object sender, EventArgs e)
        {
            oTran = new BConfiguracion();
            Program.dtPermisos = oTran.getCargaAutori();
            


            txtUsu.CharacterCasing = CharacterCasing.Upper;
            txtPwd.CharacterCasing = CharacterCasing.Upper; 


            dgvUsuarios.GridColor = Color.Red;
            dgvUsuarios1.GridColor = Color.Red;
            dgvUsuarios2.GridColor = Color.Red;
            oTran = new BConfiguracion();
            dtUsu = oTran.getCargaUsuarios();
            GrillUsu();



            /*ListView Cuenta Almacen*/
            int i = 0;
            while (i <= Program.dtCtaAlm.Rows.Count - 1)
            {
                ListViewItem List;
                List = lvCtaAlm.Items.Add(Program.dtCtaAlm.Rows[i]["MPTARG"].ToString());
                List.SubItems.Add(Program.dtCtaAlm.Rows[i]["MPTDES"].ToString());
                i += 1;
            }
            int j = 0;
            while (j <= Program.dtOcpiones.Rows.Count - 1)
            {
                ListViewItem List;
                List = lvAccesos.Items.Add(Program.dtOcpiones.Rows[j]["IDOPCI"].ToString());
                List.SubItems.Add(Program.dtOcpiones.Rows[j]["IDOPCD"].ToString());
                j += 1;
            }
                     
   



            string sql1 = " SELECT DISTINCT(A.CODUSE) AS USUARIO,NOMEMP AS NOMBRE FROM " + Program.LibreLALMINGB + ".TAUTUING A LEFT OUTER JOIN " +
                         " " + Program.LibreLALMINGB + ".ALIUSERS B ON  A.CODUSE=B.CODUSE " +
                         " WHERE NIVUSU='2'";
            oTablas = new BTablas();
            dtJefes = oTablas.getSELECTLIBRE(sql1);








           


        }

        void GrillUsu()
        {
            dgvUsuarios.DataSource = dtUsu;            
            dgvUsuarios.Columns["CODPWD"].Visible = false;           
            dgvUsuarios.Columns["FILLER"].Visible = false;

            dgvUsuarios.Columns["CODUSE"].DisplayIndex = 2;
            dgvUsuarios.Columns["CODEMP"].DisplayIndex = 0;
            dgvUsuarios.Columns["NOMEMP"].DisplayIndex = 1;

            dgvUsuarios.Columns["CODUSE"].HeaderText = "Usuario";
            dgvUsuarios.Columns["CODEMP"].HeaderText = "Codigo";
            dgvUsuarios.Columns["NOMEMP"].HeaderText = "Nombre";

            dgvUsuarios.Columns["CODUSE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.Columns["CODEMP"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.Columns["NOMEMP"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvUsuarios.Columns["CODUSE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.Columns["CODEMP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.Columns["NOMEMP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvUsuarios.Columns["CODUSE"].Width = 85;
            dgvUsuarios.Columns["CODEMP"].Width = 45;
            dgvUsuarios.Columns["NOMEMP"].Width = 200;




            dgvUsuarios1.DataSource = dtUsu;
            dgvUsuarios1.Columns["CODPWD"].Visible = false;
            dgvUsuarios1.Columns["FILLER"].Visible = false;
            dgvUsuarios1.Columns["CODUSE"].Visible = false;
            dgvUsuarios1.Columns["CODEMP"].Visible = false;

            dgvUsuarios1.Columns["NOMEMP"].DisplayIndex = 0;
            dgvUsuarios1.Columns["NOMEMP"].HeaderText = "Nombre";
            dgvUsuarios1.Columns["NOMEMP"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios1.Columns["NOMEMP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvUsuarios1.Columns["NOMEMP"].Width = 250;



            dgvUsuarios2.DataSource = dtUsu;
            dgvUsuarios2.Columns["CODPWD"].Visible = false;
            dgvUsuarios2.Columns["FILLER"].Visible = false;
            dgvUsuarios2.Columns["CODEMP"].Visible = false;
            dgvUsuarios2.Columns["NOMEMP"].DisplayIndex = 0;
            dgvUsuarios2.Columns["CODUSE"].DisplayIndex = 1;
            dgvUsuarios2.Columns["NOMEMP"].HeaderText = "Nombre";
            dgvUsuarios2.Columns["CODUSE"].HeaderText = "Usuario";
            dgvUsuarios2.Columns["NOMEMP"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios2.Columns["CODUSE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios2.Columns["NOMEMP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvUsuarios2.Columns["CODUSE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvUsuarios2.Columns["NOMEMP"].Width = 250;
            dgvUsuarios2.Columns["CODUSE"].Width = 85;
        }

        void RolearGilla()
        {
            try
            {
                int p = dgvUsuarios.CurrentRow.Index;
                txtCod.Text = dgvUsuarios.Rows[p].Cells["CODEMP"].Value.ToString();
                txtNom.Text = dgvUsuarios.Rows[p].Cells["NOMEMP"].Value.ToString();
                txtUsu.Text = dgvUsuarios.Rows[p].Cells["CODUSE"].Value.ToString();
                txtPwd.Text = dgvUsuarios.Rows[p].Cells["CODPWD"].Value.ToString();
            }
            catch { }
        }
        void Limpiar()
        {
            txtCod.Text = "";
            txtNom.Text = "";
            txtUsu.Text = "";
            txtPwd.Text = "";
        }


        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCod.Enabled = false;
            txtNom.Enabled = false;
            txtUsu.Enabled = false;
            txtPwd.Enabled = false;
            btnBuscar.Enabled = false;

            SW = "";

            btnNuevo.Enabled = true;
            btnModifica.Enabled = true;
            btnEliminar.Enabled = true;
            button1.Enabled = false;

            RolearGilla();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            SW = "NEW";
            Limpiar();
            txtPwd.Enabled = true;
            txtUsu.Enabled = true;
            btnBuscar.Enabled = true;
            button1.Enabled = true;
            btnModifica.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (SW == "NEW")
                {
                    if (MessageBox.Show("Desea Ingresar Usuario", "Alm. Ing.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        oTran = new BConfiguracion();
                        int i = oTran.BInsertUsuario(txtUsu.Text.Trim(), txtPwd.Text.Trim(), txtCod.Text.Trim(), txtNom.Text.Trim(), "");
                        if (i == 1)
                        {
                            MessageBox.Show("Ingreso Correcto", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Fallo Ingreso", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                if (SW == "CHG")
                {
                    if (MessageBox.Show("Desea Modificar Usuario", "Alm. Ing.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int i = oTran.BUpdateUsuario(txtUsu.Text.Trim(), txtPwd.Text.Trim(), txtCod.Text.Trim(), txtNom.Text.Trim(), "");
                        if (i == 1)
                        {
                            MessageBox.Show("Modificación Correcta", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Fallo Modificación", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch { }



            dgvUsuarios.GridColor = Color.Red;
            dgvUsuarios1.GridColor = Color.Red;
            oTran = new BConfiguracion();
            dtUsu = oTran.getCargaUsuarios();
            GrillUsu();

            SW = "";

            Limpiar();
            txtPwd.Enabled = false;
            txtUsu.Enabled = false;
            btnBuscar.Enabled = false;
            txtCod.Enabled = false;
            txtPwd.Enabled = false;

            button1.Enabled = false;
            btnNuevo.Enabled = true;
            btnEliminar.Enabled = true;
            btnModifica.Enabled = true;

        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            SW = "CHG";
            txtPwd.Enabled = true;
            txtUsu.Enabled = true;

            button1.Enabled = true;
            btnNuevo.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Busqueda frm = new Frm_Busqueda();
            //OT = Orden de Trabajo
            frm.Busqueda = "US";
            frm.ShowDialog();
            txtCod.Text = frm.vCodEmpleado;
            txtNom.Text = frm.vEmpleado;
            txtUsu.Focus();
            this.Cursor = Cursors.Default; 
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            txtCod.Enabled = false;
            txtNom.Enabled = false;
            txtUsu.Enabled = false;
            txtPwd.Enabled = false;
            btnBuscar.Enabled = false;

            SW = "";

            btnNuevo.Enabled = true;
            btnModifica.Enabled = true;
            btnEliminar.Enabled = true;
            button1.Enabled = false;
            RolearGilla();
        }

        private void txtUsu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPwd.Focus();
            }                
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            btnNuevo.Enabled = false;
            btnModifica.Enabled = false;

            if (MessageBox.Show("Desea Eliminar Usuario", "Alm. Ing.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                oTran = new BConfiguracion();
                int i = oTran.BDeleteUsuario(txtUsu.Text.Trim());
                if (i == 1)
                {
                    MessageBox.Show("Eliminación Correcto", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Fallo Eliminación", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            dgvUsuarios.GridColor = Color.Red;
            dgvUsuarios1.GridColor = Color.Red;
            oTran = new BConfiguracion();
            dtUsu = oTran.getCargaUsuarios();
            GrillUsu();
            SW = "";
            Limpiar();
            txtPwd.Enabled = false;
            txtUsu.Enabled = false;
            btnBuscar.Enabled = false;
            txtCod.Enabled = false;
            txtPwd.Enabled = false;

            button1.Enabled = false;
            btnNuevo.Enabled = true;
            btnEliminar.Enabled = true;
            btnModifica.Enabled = true;
        }


        /*TAUTU ALMACEN DE INGENIERIA*/
        
        DataView dvPermisos = new DataView();
        

        string CODUSE = "";
        string NIVUSE = "";
        string CTAALM = "";
        string AREUSU = "";
        private void button2_Click(object sender, EventArgs e)
        {

            if ((cboNivelUser.SelectedIndex == -1) || (cboNivelUser.SelectedIndex == 0)) { MessageBox.Show("Ingrese Nivel de Usuario", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Error); cboNivelUser.Focus(); return; }
            int p = dgvUsuarios1.CurrentRow.Index;
            CODUSE = dgvUsuarios1.Rows[p].Cells["CODUSE"].Value.ToString().Trim();
            NIVUSE = cboNivelUser.SelectedIndex.ToString().Trim();
            AREUSU = "";
            /*ListView Cuenta Almacen*/
            int i = 0;
            int k = 0;
            string flat = "";

            oTran = new BConfiguracion();
            k = oTran.BDeleteAutor(CODUSE); 

            while (i <= lvCtaAlm.Items.Count - 1)
            {
                if (lvCtaAlm.Items[i].Checked == true)
                {
                    k = 0;
                    CTAALM = lvCtaAlm.Items[i].Text.ToString().Trim();
                    oTran = new BConfiguracion();
                    k = oTran.BInsertAutor(CODUSE, NIVUSE, CTAALM, AREUSU); 
                    flat = "1";                    
                }
                i += 1;
            }
            if (flat == "")
            {
                MessageBox.Show("Ingrese Cta.Alm.", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lvCtaAlm.Focus();
                return;
            }
            if (k == 1)
            {
                MessageBox.Show("Ingreso Correcto", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            oTran = new BConfiguracion();
            Program.dtPermisos = oTran.getCargaAutori();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int p = dgvUsuarios1.CurrentRow.Index;
            CODUSE = dgvUsuarios1.Rows[p].Cells["CODUSE"].Value.ToString().Trim();
            if (MessageBox.Show("Desea Eliminar Autorizacion Users.", "Alm. Ing.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                oTran = new BConfiguracion();
                int i = oTran.BDeleteAutor(CODUSE);
                if (i == 1)
                {
                    MessageBox.Show("Eliminación Correcto", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Fallo Eliminación", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            oTran = new BConfiguracion();
            Program.dtPermisos = oTran.getCargaAutori();
        }
        
        private void dgvUsuarios1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            oTran = new BConfiguracion();            
            int p = dgvUsuarios1.CurrentRow.Index;
            CODUSE = dgvUsuarios1.Rows[p].Cells["CODUSE"].Value.ToString().Trim();
            dvPermisos = new DataView(Program.dtPermisos, "CODUSE = '" + CODUSE + "' ", "", DataViewRowState.OriginalRows);      
            int i = 0;
            while (i <= lvCtaAlm.Items.Count - 1)
            {
                lvCtaAlm.Items[i].Checked = false;
                i += 1;
            }
            i = 0;
            if (dvPermisos.Count > 0)
            {
                cboNivelUser.SelectedIndex = Convert.ToInt16(dvPermisos[0]["NIVUSU"].ToString());
                while (i <= lvCtaAlm.Items.Count - 1)
                {
                    for (int j = 0; j <= dvPermisos.Count - 1; j++)
                    {
                        if (lvCtaAlm.Items[i].Text.ToString().Trim() == dvPermisos[j]["CTAALM"].ToString().Trim())
                        {
                            lvCtaAlm.Items[i].Checked = true;
                        }
                    }
                    i += 1;
                }
            }
            else
            {
                cboNivelUser.SelectedIndex = 0;
                while (i <= lvCtaAlm.Items.Count - 1)
                {
                    lvCtaAlm.Items[i].Checked = false;                  
                    i += 1;
                }
            }
                       
        }

        private void dgvUsuarios1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                oTran = new BConfiguracion();
                int p = dgvUsuarios1.CurrentRow.Index;
                CODUSE = dgvUsuarios1.Rows[p].Cells["CODUSE"].Value.ToString().Trim();
                dvPermisos = new DataView(Program.dtPermisos, "CODUSE = '" + CODUSE + "' ", "", DataViewRowState.OriginalRows);
                int i = 0;
                while (i <= lvCtaAlm.Items.Count - 1)
                {
                    lvCtaAlm.Items[i].Checked = false;
                    i += 1;
                }
                i = 0;
                if (dvPermisos.Count > 0)
                {
                    cboNivelUser.SelectedIndex = Convert.ToInt16(dvPermisos[0]["NIVUSU"].ToString());
                    while (i <= lvCtaAlm.Items.Count - 1)
                    {
                        for (int j = 0; j <= dvPermisos.Count - 1; j++)
                        {
                            if (lvCtaAlm.Items[i].Text.ToString().Trim() == dvPermisos[j]["CTAALM"].ToString().Trim())
                            {
                                lvCtaAlm.Items[i].Checked = true;
                            }
                        }
                        i += 1;
                    }
                }
                else
                {
                    cboNivelUser.SelectedIndex = 0;
                    while (i <= lvCtaAlm.Items.Count - 1)
                    {
                        lvCtaAlm.Items[i].Checked = false;
                        i += 1;
                    }
                }
            }
            catch { }
        }


        DataView dvOpcionesxUsuario = new DataView();
        string CodigoUsers = "";
        string opcion = "";
        private void button4_Click(object sender, EventArgs e)
        {
            int p = dgvUsuarios2.CurrentRow.Index;
            CodigoUsers = dgvUsuarios2.Rows[p].Cells["CODUSE"].Value.ToString().Trim();
            /*ListView Cuenta Almacen*/
            int i = 0;
            int k = 0;
            string flat = "";

            oTran = new BConfiguracion();
            k = oTran.BDeleteOpcionesxUsuario(CodigoUsers);
            while (i <= lvAccesos.Items.Count - 1)
            {
                if (lvAccesos.Items[i].Checked == true)
                {
                    k = 0;
                    opcion = lvAccesos.Items[i].Text.ToString().Trim();
                    oTran = new BConfiguracion();
                    k = oTran.BInsertOpcionesxUsuario(CodigoUsers, opcion);
                    flat = "1";
                }
                i += 1;
            }
            if (flat == "")
            {
                MessageBox.Show("Ingrese Accesos", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lvCtaAlm.Focus();
                return;
            }
            if (k == 1)
            {
                MessageBox.Show("Ingreso Correcto", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            oTran = new BConfiguracion();
            Program.dtOcpionesxUsuario = oTran.getCargaOpcionesModuloXUsuario();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int p = dgvUsuarios2.CurrentRow.Index;
            CodigoUsers = dgvUsuarios2.Rows[p].Cells["CODUSE"].Value.ToString().Trim();
            if (MessageBox.Show("Desea Eliminar Accesos Users.", "Alm. Ing.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                oTran = new BConfiguracion();
                int i = oTran.BDeleteOpcionesxUsuario(CodigoUsers);
                if (i == 1)
                {
                    MessageBox.Show("Eliminación Correcto", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Fallo Eliminación", "Alm. Ing.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            oTran = new BConfiguracion();
            Program.dtOcpionesxUsuario = oTran.getCargaOpcionesModuloXUsuario();
        }

        private void dgvUsuarios2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            oTran = new BConfiguracion();
            int p = dgvUsuarios2.CurrentRow.Index;
            CodigoUsers = dgvUsuarios2.Rows[p].Cells["CODUSE"].Value.ToString().Trim();
            dvOpcionesxUsuario = new DataView(Program.dtOcpionesxUsuario, "IDUSER = '" + CodigoUsers + "' ", "", DataViewRowState.OriginalRows);
            int i = 0;
            while (i <= lvAccesos.Items.Count - 1)
            {
                lvAccesos.Items[i].Checked = false;
                i += 1;
            }
            i = 0;
            if (dvOpcionesxUsuario.Count > 0)
            {
                while (i <= lvAccesos.Items.Count - 1)
                {
                    for (int j = 0; j <= dvOpcionesxUsuario.Count - 1; j++)
                    {
                        if (lvAccesos.Items[i].Text.ToString().Trim() == dvOpcionesxUsuario[j]["IDOPCI"].ToString().Trim())
                        {
                            lvAccesos.Items[i].Checked = true;
                        }
                    }
                    i += 1;
                }
            }
            else
            {
                while (i <= lvAccesos.Items.Count - 1)
                {
                    lvAccesos.Items[i].Checked = false;
                    i += 1;
                }
            }
        }

        private void dgvUsuarios2_SelectionChanged(object sender, EventArgs e)
        {
            oTran = new BConfiguracion();
            int p = dgvUsuarios2.CurrentRow.Index;
            CodigoUsers = dgvUsuarios2.Rows[p].Cells["CODUSE"].Value.ToString().Trim();
            dvOpcionesxUsuario = new DataView(Program.dtOcpionesxUsuario, "IDUSER = '" + CodigoUsers + "' ", "", DataViewRowState.OriginalRows);
            int i = 0;
            while (i <= lvAccesos.Items.Count - 1)
            {
                lvAccesos.Items[i].Checked = false;
                i += 1;
            }
            i = 0;
            if (dvOpcionesxUsuario.Count > 0)
            {
                while (i <= lvAccesos.Items.Count - 1)
                {
                    for (int j = 0; j <= dvOpcionesxUsuario.Count - 1; j++)
                    {
                        if (lvAccesos.Items[i].Text.ToString().Trim() == dvOpcionesxUsuario[j]["IDOPCI"].ToString().Trim())
                        {
                            lvAccesos.Items[i].Checked = true;
                        }
                    }
                    i += 1;
                }
            }
            else
            {
                while (i <= lvAccesos.Items.Count - 1)
                {
                    lvAccesos.Items[i].Checked = false;
                    i += 1;
                }
            }
        }



        private void Frm_Configuracion_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }








    }
}
