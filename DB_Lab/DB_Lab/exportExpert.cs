using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel; // lab 10

namespace DB_Lab
{
    public partial class exportExpert : Form
    {
        string path = Path.GetFullPath(@"C:\Users\Користувач\source\repos\DB_Lab\DB_Lab\bin\Debug\Report");

        DataTable dt;

        public exportExpert()
        {
            InitializeComponent();
        }

        private void exportExpert_Load(object sender, EventArgs e)
        {
            dt = (DataTable)h.bs1.DataSource;
        }

        private void btnStream_Click(object sender, EventArgs e)
        {
            var srcEncoding = Encoding.GetEncoding(1251);

            string extend;

            if (rbtnTsv.Checked)
            {
                extend = ".tsv";
            }
            else if (rbtnDoc.Checked)
            {
                extend = ".doc";
            }
            else if (rbtnXls.Checked)
            {
                extend = ".xls";
            }
            else
            {
                extend = ".txt";
            }

            string fileName = path + @"Expert_stream" + extend;

            if (File.Exists(fileName)) File.Delete(fileName);

            // declaring stream
            StreamWriter wr = new StreamWriter(fileName, false, encoding: srcEncoding);

            // output to file
            try
            {
                // output columns names
                /*wr.Write("№ \t expert name \t qualification \t hire date \t" +
                    " phone number \t salary \t researches ");*/

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    wr.Write(dt.Columns[i] + "\t");
                }
                wr.WriteLine();

                // output data
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            if (dt.Columns[j].DataType.ToString() == "System.Byte[]")
                                wr.Write("Image" + "\t");

                            else if (dt.Columns[j].DataType.ToString() == "System.DateTime")
                                wr.Write(Convert.ToDateTime(
                                    dt.Rows[i][j]).ToString("dd.MM.yyyy") + "\t"); // here could be mistake, replace . to /

                            else if (dt.Columns[j].DataType.ToString() == "System.Double")
                                wr.Write(Convert.ToDouble(
                                    dt.Rows[i][j]).ToString() + "\t");

                            else
                                wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                        }
                        else
                            wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                    }
                    wr.WriteLine();
                }
                wr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            MessageBox.Show("Successfull export to file ");
        }

        private void btnOLEDB_Click(object sender, EventArgs e)
        {
            string fileName = path + @"Expert_oledb.xls";
            if (File.Exists(fileName)) File.Delete(fileName);

            // connection 
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; " +
                "Data Source = " + fileName + ";Mode = ReadWrite; " +
                "Extended Properties = \"Excel 8.0; HDR = NO\"";

            string commandCreateOledb = "CREATE TABLE [MySheet] ([" +
                dt.Columns[0].ColumnName + "] int";

            for (int i = 0; i < (dt.Columns.Count); i++)
                commandCreateOledb += ", [" + dt.Columns[i].ColumnName + "] string";
            commandCreateOledb += ")";

            // make connection with Excel DB
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // creating table
                using (OleDbCommand cmd = new OleDbCommand(commandCreateOledb, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery(); // create Excel table

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            cmd.CommandText = "insert int [MySheet$] values(" +
                                Convert.ToString(dt.Rows[i][0]);

                            for (int j = 0; j < (dt.Columns.Count); j++)
                            {
                                if (dt.Columns[j].DataType.ToString() == "System.String")
                                    cmd.CommandText += ", '" + Convert.ToString(dt.Rows[i][j]) + "'";

                                else if (dt.Columns[j].DataType.ToString() == "System.Int32")
                                    cmd.CommandText += ", '" + Convert.ToInt32(dt.Rows[i][j]) + "'";

                                else if (dt.Columns[j].DataType.ToString() == "System.Decimal")
                                    cmd.CommandText += ", '" + Convert.ToDecimal(dt.Rows[i][j]) + "'";

                                else if (dt.Columns[j].DataType.ToString() == "System.DateTime")
                                    cmd.CommandText += ", '" + Convert.ToDateTime(
                                        dt.Rows[i][j]).ToString("dd.MM.yyyy") + "'";

                                else
                                    cmd.CommandText += ", 'not converted'";
                            }
                            cmd.CommandText += ")";

                            // using generated Insert command
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Table MySheet already exists or isn't open");
                    }
                }
                connection.Close();
            }
            MessageBox.Show("successfully data export to file as OLEDB");
        }

        // ------------------
        private void formatExpertCom(Excel.Application excel, Excel.Worksheet sheet)
        {
            int row1 = 1;
            int col1 = 1;
            int row2 = dt.Rows.Count;
            int col2 = dt.Columns.Count;

            Excel.Range range0 = (Excel.Range)sheet.Range[sheet.Cells[9, 2], 
                                                          sheet.Cells[9, 2]];

            Excel.Range range1 = (Excel.Range)sheet.Range[sheet.Cells[row1, col1], 
                                                          sheet.Cells[row2, col2]];

            Excel.Range range2 = (Excel.Range)sheet.Range[sheet.Cells[10, 1], 
                                                          sheet.Cells[10, 5]];

            range1.Font.Background = true;
            range1.Font.Size = 12;
            range1.Font.Color = ColorTranslator.ToOle(Color.Black); 
            range1.Font.Name = "Times New Roman";

            range1.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            range1.Borders.Weight = Excel.XlBorderWeight.xlThin;
            range1.Borders.Color = ColorTranslator.ToOle(Color.Blue); 

            range1.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            range1.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            range1.EntireColumn.AutoFit();
            range1.EntireRow.AutoFit();

            range1.Interior.Color = ColorTranslator.ToOle(Color.LightBlue); 
            range2.Merge(Type.Missing);
        }

        private void btnComObj_Click(object sender, EventArgs e)
        {
            string fileName = path + @"\Expert_com.xls";
            if (File.Exists(fileName)) File.Delete(fileName);

            Excel.Application excel = new Excel.Application(); // com excel obj
            excel.Workbooks.Add(Type.Missing); // add book
            Excel.Workbook workbook = excel.Workbooks[1]; // ref for first opened book

            // workbook.Application.DisplayAlerts = false;

            Excel.Worksheet sheet = workbook.Worksheets.get_Item(1); // ref for first page
            sheet.Name = "Experts";

            for (int j = 0; j < dt.Columns.Count; j++)
            {
                sheet.Cells[1, j + 1].Value = dt.Columns[j].ColumnName;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Columns[j].DataType.ToString() == "System.Byte[]")
                    {
                        sheet.Cells[i + 2, j + 1].Value = "Image"; // image doesn't output
                    }
                    else
                    {
                        sheet.Cells[i + 2, j + 1].Value = dt.Rows[i][j];
                    }
                }
            }

            formatExpertCom(excel, sheet); // excel parameter

            excel.Application.ActiveWorkbook.SaveAs(
                fileName, Excel.XlSaveAsAccessMode.xlNoChange);
            workbook.Close(false); // false = close book without asking about saving achnges
            excel.Quit();

            MessageBox.Show("xls file  was created using Excel com-objects");
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            string fileName = path + @"\Expert_xml.xls";
            dt.WriteXml(fileName);
            MessageBox.Show("xls file was created using xml markup");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportExpert formExport = new exportExpert();
            formExport.ShowDialog();
        }
    }
}
