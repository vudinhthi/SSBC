using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace SSBC_Mix
{
    public partial class frmExportData : Form
    {
        public frmExportData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DateTime from = dtFrom.Value.Date;
            DateTime to = dtTo.Value.Date;

            var dbContext = new SSBC_Data.SourceContext();
            

            if(rdMix.Checked==true)
            {
                var data = dbContext.vSSBC_MixTracks.Where(x => x.ScaleDate >= from && x.ScaleDate <= to).ToList();
                DataTable tbl = SSBC_Data.SourceContext.Action.ToDataTable(data);
                tbl.ExportToExcel(txtUrl.Text);
            }
            else if(rdCrush.Checked==true)
            {
                var data = dbContext.vSSBC_CrushTracks.Where(x => x.ScaleDate >= from && x.ScaleDate <= to).ToList();
                DataTable tbl = SSBC_Data.SourceContext.Action.ToDataTable(data);
                tbl.ExportToExcel(txtUrl.Text);
            }

            
        }

        private void frmExportData_Load(object sender, EventArgs e)
        {

        }
    }
    public static class My_DataTable_Extensions
    {

        // Export DataTable into an excel file with field names in the header line
        // - Save excel file without ever making it visible if filepath is given
        // - Don't save excel file, just make it visible if no filepath is given
        public static void ExportToExcel(this DataTable tbl, string excelFilePath = null)
        {
            try
            {
                if (tbl == null || tbl.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();

                // single worksheet
                Excel._Worksheet workSheet = excelApp.ActiveSheet;

                // column headings
                for (var i = 0; i < tbl.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                }

                // rows
                for (var i = 0; i < tbl.Rows.Count; i++)
                {
                    // to do: format datetime values before printing
                    for (var j = 0; j < tbl.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                    }
                }

                // check file path
                if (!string.IsNullOrEmpty(excelFilePath))
                {
                    try
                    {
                        workSheet.SaveAs(excelFilePath);
                        excelApp.Quit();
                        MessageBox.Show("Excel file saved!");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                            + ex.Message);
                    }
                }
                else
                { // no file path is given
                    excelApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
}
