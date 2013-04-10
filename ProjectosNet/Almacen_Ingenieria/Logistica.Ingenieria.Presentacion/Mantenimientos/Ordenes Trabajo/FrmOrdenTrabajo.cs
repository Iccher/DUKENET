using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Bussiness;
namespace Logistica.Ingenieria.Presentacion.Mantenimientos.Ordenes_Trabajo
{
    public partial class FrmOrdenTrabajo : Form
    {
        public FrmOrdenTrabajo()
        {
            InitializeComponent();
        }
        BTablas objTab = new BTablas();
        DataTable dtCentroCosto = new DataTable();
        private void FrmOrdenTrabajo_Load(object sender, EventArgs e)
        {
            dgvOrdenesTrabajo.GridColor = Color.Red; 
            objTab = new BTablas();
            //dtCentroCosto = objTab.getSELECTLIBRE("SELECT t01esp, t01al1 FROM " + Program.LibreLUGTF + ".ugt01 WHERE t01idt='CCG'  AND  t01stt<>'E' ORDER BY t01esp");
            dtCentroCosto = objTab.getSELECTLIBRE("SELECT ODTDPT AS t01esp,(SELECT T01AL1 FROM " + Program.LibreLUGTF + ".ugt01 WHERE t01idt='CCT' AND T01ESP=DIGITS(ODTDPT)) AS t01al1  FROM PRACTICA.AIODET WHERE ODTDPT<>0 GROUP BY ODTDPT ORDER BY ODTDPT");

            dgvOrdenesTrabajo.Columns["O_trabajo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdenesTrabajo.Columns["Maquina_Parte"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdenesTrabajo.Columns["DATO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdenesTrabajo.Columns["Selec"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdenesTrabajo.Columns["Modif"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cargaTreview();
        }

        private void cargaTreview()
        {
            // Variables
            string idCodigo = "";
            string descItem = "";
            // Cursor de espera, mientras que el TreeView se están creando
            Cursor.Current = Cursors.WaitCursor;
            // TreeView
            tvResumen.BeginUpdate();
            tvResumen.Nodes.Clear();
            TreeNode rootNode = new TreeNode("CCCosto");
            rootNode.Tag = null;
            rootNode.ImageIndex = 1;
            rootNode.SelectedImageIndex = 1;
            tvResumen.Nodes.Add(rootNode);
            // Carga
            int i = 0;
            while (i <= dtCentroCosto.Rows.Count - 1)
            {
                idCodigo = dtCentroCosto.Rows[i]["t01esp"].ToString().Trim();
                descItem = dtCentroCosto.Rows[i]["t01al1"].ToString().Trim();
                TreeNode node = new TreeNode(rootNode.ToString());
                node.Tag = idCodigo;
                node.Text = idCodigo + "  -  " + descItem;
                node.ImageIndex = 0;
                node.SelectedImageIndex = 2;
                rootNode.Nodes.Add(node);
                ++i;
            }
            // Expande
            //tvResumen.ExpandAll;
            tvResumen.EndUpdate();
        }

        string desCCT = "";
        string xCodCCT = "";
        private void tvResumen_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string xWhere = "";
                TreeNode nodoActual = tvResumen.SelectedNode;
                TreeNode nodoPadre = tvResumen.SelectedNode.Parent;
                desCCT = nodoActual.Text;
                xCodCCT = (string)nodoActual.Tag;
                switch (xCodCCT)
                {
                    case null: break;
                    default:
                        groupBox1.Text = "Centro de Costo " + desCCT.Trim();
                        objTab = new BTablas();
                        //dtCentroCosto = objTab.getSELECTLIBRE("SELECT odtcod||'-'||ODTSCD AS O_trabajo, ODTDES AS Maquina_Parte,ODTSCD " +
                        //" FROM PRACTICA.aiodet LEFT OUTER JOIN " + Program.LibreLUGTF + ".ugt01 on t01idt='CCG' AND odtdpt=t01esp WHERE ODTSTT='OT' AND odtdpt=" + Convert.ToDecimal(xCodCCT) + " " +
                        //" ORDER BY odtcod, odtfil");
                        //dtCentroCosto = objTab.getSELECTLIBRE("SELECT odtcod||'-'||ODTSCD AS O_trabajo, trim(ODTDES) AS Maquina_Parte,ODTSCD, " +
                        //" (SELECT '+' FROM PRACTICA.AIODET AS M WHERE M.ODTCOD=T.odtcod AND ODTSCD=1) AS DATO,'Selec.' AS Selec,'Modif.'as Modif,odtcod,odtdpt " +
                        //" FROM PRACTICA.aiodet AS T LEFT OUTER JOIN " + Program.LibreLUGTF + ".ugt01 on t01idt='CCG' AND odtdpt=t01esp WHERE ODTSTT='OT' AND odtdpt=" + Convert.ToDecimal(xCodCCT) + " " +
                        //" ORDER BY odtcod, odtfil");

                        dtCentroCosto = objTab.getSELECTLIBRE("SELECT odtcod AS O_trabajo, trim(ODTDES) AS Maquina_Parte,ODTSCD, " +
                        " (SELECT '+' FROM PRACTICA.AIODET AS M WHERE M.ODTCOD=T.odtcod AND ODTSCD=1) AS DATO,'Selec.' AS Selec,'Modif.'as Modif,odtcod,odtdpt " +
                        " FROM PRACTICA.aiodet AS T LEFT OUTER JOIN " + Program.LibreLUGTF + ".ugt01 on t01idt='CCG' AND odtdpt=t01esp WHERE ODTSTT='OT' AND odtdpt=" + Convert.ToDecimal(xCodCCT) + " " +
                        " ORDER BY odtcod, odtfil");

                        dv = new DataView(dtCentroCosto, "ODTSCD=0", "", DataViewRowState.OriginalRows); 
                        dgvOrdenesTrabajo.DataSource = dv;
                        
                        break;
                }
            }
            catch { }
        }

        DataView dv = new DataView();
        private void cbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int index = cbBusqueda.SelectedIndex;
                switch (index)
                {
                    case 0:
                        dv = new DataView(dtCentroCosto, "", "O_trabajo ASC", DataViewRowState.OriginalRows);
                        dgvOrdenesTrabajo.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(dtCentroCosto, "", "Maquina_Parte ASC", DataViewRowState.OriginalRows);
                        dgvOrdenesTrabajo.DataSource = dv;
                        break;
                }
            }
            catch { }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int index = cbBusqueda.SelectedIndex;
                switch (index)
                {
                    case 0:
                        dv = new DataView(dtCentroCosto, "O_trabajo LIKE '%" + txtBusqueda.Text.Trim() + "%'", "O_trabajo ASC", DataViewRowState.OriginalRows);
                        dgvOrdenesTrabajo.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(dtCentroCosto, "Maquina_Parte LIKE '%" + txtBusqueda.Text.Trim() + "%'", "Maquina_Parte ASC", DataViewRowState.OriginalRows);
                        dgvOrdenesTrabajo.DataSource = dv;
                        break;
                }
            }
            catch { }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvOrdenesTrabajo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int p = dgvOrdenesTrabajo.CurrentRow.Index;
                string orden = dgvOrdenesTrabajo.Rows[p].Cells["O_trabajo"].Value.ToString();
                string area = dgvOrdenesTrabajo.Rows[p].Cells["odtdpt"].Value.ToString();
                MessageBox.Show(orden + "-" + area);
                //
                //codigo_inv = dgvInventarriador.Rows[p].Cells["co_trabajador"].Value.ToString();
                //nombre_inv = dgvInventarriador.Rows[p].Cells["no_inventariador"].Value.ToString();
                //usu_inv = dgvInventarriador.Rows[p].Cells["co_inv"].Value.ToString();
                //this.Close();
            }
        }
    }
}
