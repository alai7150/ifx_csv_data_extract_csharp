using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IFX_CSV_Data_Extractor
{
    public partial class Frm_IFX_CSV : Form
    {
        public Frm_IFX_CSV()
        {
            InitializeComponent();
        }

        IfxCsvExtractor extractor = null;
        private void Frm_IFX_CSV_Load(object sender, EventArgs e)
        {

        }

        private void buttonBrowseFile_Click(object sender, EventArgs e)
        {
            labelRowCount.Text = "Total rows:";
            labelTestStatistics.Text = "";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog1.FileName))
                {
                    //create extractor and extract data from csv file
                    extractor = new IfxCsvExtractor(openFileDialog1.FileName);
                    extractor.Extract();

                    //Display required information
                    labelRowCount.Text = "Total rows: " + extractor.RawDataTable.Rows.Count.ToString();
                    TestStatistic tso = extractor.GetOneTestStatistic("VTH@IG=3.000000E-005A");
                    string txt = $"Mean = {tso.Mean} , Median = {tso.Median}, Stdev = {tso.Stdev}";
                    labelTestStatistics.Text = txt;

                    //Bind raw data table to datagrid view
                    dataGridViewRaw.DataSource = extractor.RawDataTable;

                    //compute statistics for all test and bind to datagrid
                    dataGridViewStatistics.DataSource = extractor.ComputeTestStatistics();
                }
            }
        }

        private void Frm_IFX_CSV_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(extractor != null)
            {
                extractor.Dispose();
            }
        }
    }
}
