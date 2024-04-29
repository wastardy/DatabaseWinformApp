using MySql.Data.MySqlClient;
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
    public partial class frmExpert : Form
    {
        string path = Path.GetFullPath(@"C:\Users\Користувач\source\repos\DB_Lab\DB_Lab\bin\Debug\Report");

        DataTable dt;

        public frmExpert()
        {
            InitializeComponent();
        }

        private void TableExpert_Click(object sender, EventArgs e)
        {
            frmExpert f1 = new frmExpert();
            f1.ShowDialog();
        }

        private void frmExpert_Load(object sender, EventArgs e)
        {
            if (int.Parse(h.typeUser) == 2)
            {
                // these buttons will be invisible to type 2 users
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                dataGridView1.ReadOnly = true;
            }

            if (int.Parse(h.typeUser) == 3)
            {
                // these buttons will be invisible to type 3 users
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                dataGridView1.ReadOnly = true;
            }

            h.bs1 = new BindingSource();
            h.bs1.DataSource = h.myfunDt("SELECT * FROM Expert");
            dataGridView1.DataSource = h.bs1;
            bindingNavigator1.BindingSource = h.bs1;

            // path += @"\Report"; // ?????????????

            dt = (DataTable)h.bs1.DataSource;
            // OR
            // dt = h.myfunDt("SELECT * FROM Expert");

            h.bs1.Sort = "expert_name ASC";

            DWGFormat();

            DataTable dtBorder = new DataTable();
            DataTable dtDistinctRes = new DataTable();
            DataTable dtDistinctPhone = new DataTable();
            
            dtBorder = h.myfunDt("SELECT MIN(salary), MAX(salary), MIN(hire_date), MAX(hire_date) FROM Expert");
            dtDistinctRes = h.myfunDt("SELECT DISTINCT researches FROM Expert");
            dtDistinctPhone = h.myfunDt("SELECT DISTINCT phone_number FROM Expert");

            // Записую межі у відповідні елементи керування:
            txtSalaryFrom.Text = dtBorder.Rows[0][0].ToString();
            txtSalaryTo.Text = dtBorder.Rows[0][1].ToString();
              
            dateHireDtFrom.Value = Convert.ToDateTime(dtBorder.Rows[0][2].ToString());
            dateHireDtTo.Value = Convert.ToDateTime(dtBorder.Rows[0][3].ToString());

            // Визначаю перелік можливих значень текстового поля:
            // cmbResearches.Items.Add("");
            for (int i = 0; i < dtDistinctRes.Rows.Count; i++)
            {
                cmbResearches.Items.Add(dtDistinctRes.Rows[i][0].ToString());
            }
            cmbResearches.DropDownStyle = ComboBoxStyle.DropDownList; // заборона редагування comboBox

            for (int i = 0; i < dtDistinctPhone.Rows.Count; i++)
            {
                cmbPhoneNum.Items.Add(dtDistinctPhone.Rows[i][0].ToString());
            }
            cmbPhoneNum.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        void DWGFormat()
        {
            dataGridView1.Font = new Font("Times New Roman", 12, FontStyle.Regular);

            dataGridView1.Columns[0].Width = 25;
            dataGridView1.Columns[0].HeaderText = "№";

            dataGridView1.Columns[1].Width = 130;

            dataGridView1.Columns[2].Width = 180;

            dataGridView1.Columns[3].Width = 100;

            dataGridView1.Columns[4].Width = 105;

            dataGridView1.Columns[5].Width = 65;

            dataGridView1.Columns[6].Width = 75;
        }

        private void btnCloseExpert_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (btnFind.Checked)
            {
                label1.Visible = true;
                txtFind.Visible = true;
                txtFind.Focus();
            } 
            else
            {
                CancelFind();
            }
        }

        // basic method to find by entered text the whole row

        /*private void txtFind_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;

                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(txtFind.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }*/

        // better method to find especially one cell instead of whole row
        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            // Deselect all cells before starting a new search
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Selected = false;
                }
            }

            // Itarate through each cell to find the specified text
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(txtFind.Text))
                        {
                            // Set the selection for the found cell
                            dataGridView1.Rows[i].Cells[j].Selected = true;
                            // Exit the method after finding the first cell with the specified text
                            return; 
                        }
                    }
                }
            }
        }


        private void txtFind_Leave(object sender, EventArgs e)
        {
            btnFind.Checked = false;
            CancelFind();
        }

        private void CancelFind()
        {
            label1.Visible = false;
            txtFind.Visible = false;
            txtFind.Text = "";

            for (int i = 0; i < dataGridView1.RowCount; i++)
                dataGridView1.Rows[i].Selected = false;
        }

    private void groupBox1_Paint(object sender, PaintEventArgs e)
    {
      Graphics gfx = e.Graphics;
      Pen p = new Pen(Color.AliceBlue, 1); // колір і товщина рамки

      gfx.DrawLine(p, 0, 5, 5, 5); // верхня горизонтальна лінія до Text

      gfx.DrawLine(p, 35, 5, e.ClipRectangle.Width - 2, 5); // верхня горизонтальна лінія після Text

      gfx.DrawLine(p, 0, 5, 0, e.ClipRectangle.Height - 2); // верхня горизонтальна лінія до Text

      gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5,
                      e.ClipRectangle.Width - 2, 
                      e.ClipRectangle.Height - 2); // права вертикаль

      gfx.DrawLine(p, e.ClipRectangle.Width - 2,
                      e.ClipRectangle.Height - 2, 0,
                      e.ClipRectangle.Height - 2); // низ
    }

    private void btnFilter_Click(object sender, EventArgs e)
    {
      if (btnFilter.Checked)
      {
        this.Height = 430;
        groupBox1.Visible = true;
      }
      else
      {
        this.Height = 300;
        groupBox1.Visible = false;
      }
    }

        private void btnFilterOk_Click(object sender, EventArgs e)
        {
            string strFilter = "";
            strFilter += "expert_id > 0";

            // filer for expert_name
            if (txtExpertName.Text != "")
            {
                strFilter += " AND expert_name LIKE '" + txtExpertName.Text + "%'";
            }
            
            // filter for salary and hire_date
            if ((txtSalaryFrom.Text != "") && (txtSalaryTo.Text != ""))
            {
                strFilter +=
                    " AND (salary >= " + 
                    txtSalaryFrom.Text.ToString().Replace(',', '.') +
                    " AND salary <= " + 
                    txtSalaryTo.Text.ToString().Replace(",", ".") + ")";
            } 
            else if ((txtSalaryFrom.Text == "") && (txtSalaryTo.Text != ""))
            {
                strFilter +=
                    " AND (salary <= " + 
                    txtSalaryTo.Text.ToString().Replace(",", ".") + ")";
            }
            else if ((txtSalaryFrom.Text != "") && (txtSalaryTo.Text == ""))
            {
                strFilter +=
                    " AND (salary >= " +
                    txtSalaryFrom.Text.ToString().Replace(',', '.');
            }

            strFilter += " AND (hire_date >= '" + dateHireDtFrom.Value.ToString("yyyy-MM-dd") + 
                "'" + " AND hire_date <= '" + dateHireDtTo.Value.ToString("yyyy-MM-dd") + "')";

            // filter for unique values of Researches
            if (cmbResearches.Text != "")
            {
                strFilter += " AND (researches = '" + cmbResearches.Text + "')";
            }

            if (cmbPhoneNum.Text != "")
            {
                strFilter += " AND (phone_number = '" + cmbPhoneNum.Text + "')";
            }

            MessageBox.Show(strFilter);

            h.bs1.Filter = strFilter;
        }

        private void btnFilterCancel_Click(object sender, EventArgs e)
        {
            h.bs1.RemoveFilter();
        }

        private void addNew_Click(object sender, EventArgs e)
        {
            frmAddToExpert form1Add = new frmAddToExpert();
            form1Add.ShowDialog();
            h.bs1.DataSource = h.myfunDt("SELECT * FROM Expert");
            dataGridView1.DataSource = h.bs1;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            h.curVal0 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            h.keyName = dataGridView1.Columns[0].Name;

            frmRemoveExpert formRemove = new frmRemoveExpert();
            formRemove.ShowDialog();

            h.bs1.DataSource = h.myfunDt("SELECT * FROM Expert");
            dataGridView1.DataSource = h.bs1;
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            h.keyName = dataGridView1.Columns[0].Name;
            h.curVal0 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            int curColInx = dataGridView1.CurrentCellAddress.X;
            string curColName = dataGridView1.Columns[curColInx].Name;
            string newCurCellVal = e.Value.ToString();

            if (curColName == "expert_name" || curColName == "qualifications"
                || curColName == "phone_number" || curColName == "researches")
            {
                newCurCellVal = "'" + newCurCellVal + "'";
            }

            // for date fields
            if (curColName == "hire_date")
            {
                newCurCellVal = Convert.ToDateTime(newCurCellVal).ToString("yyyy-MM-dd");
                newCurCellVal = "'" + newCurCellVal + "'";
            }

            // for decimal fields
            if (curColName == "salary")
            {
                newCurCellVal = newCurCellVal.Replace(',', '.');
            }

            string sqlStr = "UPDATE Expert SET " + curColName + " = " +
                newCurCellVal + " WHERE " + h.keyName + " = " + h.curVal0;

            // MessageBox.Show(sqlStr);

            if (MessageBox.Show("Are you sure you want to change data?", "Change value in table Expert",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (MySqlConnection con = new MySqlConnection(h.conStr))
                {
                MySqlCommand cmd = new MySqlCommand(sqlStr, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                }
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            h.curVal0 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            h.keyName = dataGridView1.Columns[0].Name;

            editExpert form = new editExpert();
            form.ShowDialog();

            h.bs1.DataSource = h.myfunDt("SELECT * FROM Expert");
            dataGridView1.DataSource = h.bs1; 
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;

            if (dataGridView1.Rows[rowIndex].Cells[7].Value.ToString().Length > 0) 
            {
                byte[] a = (byte[])dataGridView1.Rows[rowIndex].Cells[7].Value;
                MemoryStream memoryImage = new MemoryStream(a);
                pictureBox1.Image = Image.FromStream(memoryImage);
                memoryImage.Close();
            }
            else
            {
                h.pathToPhoto = Application.StartupPath + @"\" + "empty.jpg";
                pictureBox1.Image = Image.FromFile(h.pathToPhoto);
            }
        }

        private void btnStream_Click(object sender, EventArgs e)
        {
            var srcEncoding = Encoding.GetEncoding(1251); 

            string extend;

            if (rbtnTsv.Checked) {
                extend = ".tsv";
            } 
            else if (rbtnDoc.Checked) {
                extend = ".doc";
            }
            else if (rbtnXls.Checked) {
                extend = ".xls";
            }
            else {
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
                using (OleDbCommand cmd  = new OleDbCommand(commandCreateOledb, connection))
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

        private void btnExportToFile_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }
    }
}
