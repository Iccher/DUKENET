using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

using Logistica.Ingenieria.Bussiness;
using System.IO;


namespace Logistica.Ingenieria.Presentacion.Consultas
{
    public partial class Frm_Anio_ABC : Form
    {
        public Frm_Anio_ABC()
        {
            InitializeComponent();
        }


        BTablas objTablas = new BTablas();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Consultas.Frm_Consuta_ABC frm = new Logistica.Ingenieria.Presentacion.Consultas.Frm_Consuta_ABC();
            frm.ANIO = DTP1.Text;
            frm.ShowDialog();            
            objTablas = new BTablas();
            //dataGridView1.DataSource = objTablas.getConsultaABC("2010");

            //objTablas = new BTablas();
            //ExportarExcelDataTable(objTablas.getConsultaABC("2010"), "C:\\PRUEBASOFFICE\\xxx.xls");
            //try
            //{
            //    ArrayList titulos = new ArrayList();
            //    DataTable datosTabla = new DataTable();
            //    //Especificar rutal del archivo con extencion de excel.
            //    OtrosFormatos OF = new OtrosFormatos(Application.StartupPath + @"\\test.xls");

            //    //obtenemos los titulos del grid y creamos las columnas de la tabla
            //    foreach (DataGridViewColumn item in dataGridView1.Columns)
            //    {
            //        titulos.Add(item.HeaderText);
            //        datosTabla.Columns.Add();
            //    }
            //    //se crean los renglones de la tabla
            //    foreach (DataGridViewRow item in dataGridView1.Rows)
            //    {
            //        DataRow rowx = datosTabla.NewRow();
            //        datosTabla.Rows.Add(rowx);
            //    }
            //    //se pasan los datos del dataGridView a la tabla
            //    foreach (DataGridViewColumn item in dataGridView1.Columns)
            //    {
            //        foreach (DataGridViewRow itemx in dataGridView1.Rows)
            //        {
            //            datosTabla.Rows[itemx.Index][item.Index] = dataGridView1[item.Index, itemx.Index].Value;
            //        }
            //    }
            //    OF.Export(titulos, datosTabla);
            //    Process.Start(OF.xpath);
            //    MessageBox.Show("Procceso Completo");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            this.Cursor = Cursors.Default;



        }

        void ExportarExcelDataTable(DataTable dt, string RutaExcel)
        {
            const string FIELDSEPARATOR = "\t";
            const string ROWSEPARATOR = "\n";
            StringBuilder output = new StringBuilder();
            // Escribir encabezados    
            foreach (DataColumn dc in dt.Columns)
            {
                output.Append(dc.ColumnName);
                output.Append(FIELDSEPARATOR);
            }
            output.Append(ROWSEPARATOR);
            foreach (DataRow item in dt.Rows)
            {
                foreach (object value in item.ItemArray)
                {
                    output.Append(value.ToString().Replace('\n', ' ').Replace('\r', ' ').Replace('.', ','));
                    output.Append(FIELDSEPARATOR);
                }
                // Escribir una línea de registro        
                output.Append(ROWSEPARATOR);
            }
            // Valor de retorno    
            // output.ToString();
            StreamWriter sw = new StreamWriter(RutaExcel);
            sw.Write(output.ToString());
            sw.Close();
        }

        private void Frm_Anio_ABC_Load(object sender, EventArgs e)
        {
            DTP1.MaxDate = DateTime.Now;
        }


    }
}



        


