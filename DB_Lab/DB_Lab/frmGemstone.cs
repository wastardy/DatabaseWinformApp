using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Lab
{
    public partial class frmGemstone : Form
    {
        public frmGemstone()
        {
            InitializeComponent();
        }

        private void TableGemstone_Click(object sender, EventArgs e)
        {
            frmGemstone f3 = new frmGemstone();
            f3.ShowDialog();
        }

        private void frmGemstone_Load(object sender, EventArgs e)
        {
            if (int.Parse(h.typeUser) == 3)
            {
                // these buttons will be invisible to type 3 users
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnEdit.Visible = false;
                dataGridView1.ReadOnly = true;
            }

            if (int.Parse(h.typeUser) == 2)
            {
                // these buttons will be invisible to type 2 users
                btnDelete.Visible = false;
                btnEdit.Visible = false;
                dataGridView1.ReadOnly = true;
            }

            h.bs1 = new BindingSource();
            h.bs1.DataSource = h.myfunDt("SELECT * FROM Gemstone");
            dataGridView1.DataSource = h.bs1;
            bindingNavigator1.BindingSource = h.bs1;

            h.bs1.Sort = "source_of_origin ASC";

            DWGFormat();

            DataTable dtBorder = new DataTable();
            DataTable dtDistinctSourceOrig = new DataTable();

            dtBorder = h.myfunDt("SELECT MIN(hardness), MAX(hardness) FROM Gemstone;");
            dtDistinctSourceOrig = h.myfunDt("SELECT DISTINCT source_of_origin FROM Gemstone;");

            // Записую межі у відповідні елементи керування:
            txtHardnessFrom.Text = dtBorder.Rows[0][0].ToString();
            txtHardnessTo.Text = dtBorder.Rows[0][1].ToString();

            // Визначаю перелік можливих значень текстового поля:
            // cmbSourceOrig.Items.Add("");
            for (int i = 0; i < dtDistinctSourceOrig.Rows.Count; i++)
            {
                cmbSourseOrig.Items.Add(dtDistinctSourceOrig.Rows[i][0].ToString());
            }
            cmbSourseOrig.DropDownStyle = ComboBoxStyle.DropDownList; // заборона редагування comboBox
        }

        void DWGFormat()
        {
            dataGridView1.Font = new Font("Times New Roman", 12, FontStyle.Regular);

            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[0].HeaderText = "№";

            dataGridView1.Columns[1].Width = 70;

            dataGridView1.Columns[2].Width = 145;

            dataGridView1.Columns[3].Width = 75;

            dataGridView1.Columns[4].Width = 100;

            dataGridView1.Columns[5].Width = 65;

            dataGridView1.Columns[6].Width = 115;

            dataGridView1.Columns[7].Width = 110;
            dataGridView1.Columns[7].HeaderText = "market value";
        }

        private void btnCloseGemstone_Click(object sender, EventArgs e)
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

        private void txtFind_TextChanged(object sender, EventArgs e)
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
                this.Height = 450;
                groupBox1.Visible = true;
            }
            else
            {
                this.Height = 320;
                groupBox1.Visible = false;
            }
        }

        private void btnFilterOk_Click(object sender, EventArgs e)
        {
            string strFilter = "";
            strFilter += "gem_id > 0";

            // filer for name
            if (txtGemName.Text != "")
            {
                strFilter += " AND name LIKE '" + txtGemName.Text + "%'";
            }

            // filter for hardness and hire_date
            if ((txtHardnessFrom.Text != "") && (txtHardnessTo.Text != ""))
            {
                strFilter +=
                    " AND (hardness >= " +
                    txtHardnessFrom.Text.ToString() +
                    " AND hardness <= " +
                    txtHardnessTo.Text.ToString() + ")";
            }
            else if ((txtHardnessFrom.Text == "") && (txtHardnessTo.Text != ""))
            {
                strFilter +=
                    " AND (hardness <= " +
                    txtHardnessTo.Text.ToString() + ")";
            }
            else if ((txtHardnessFrom.Text != "") && (txtHardnessTo.Text == ""))
            {
                strFilter +=
                    " AND (hardness >= " +
                    txtHardnessFrom.Text.ToString();
            }

            // filter for unique values of Source og Origin
            if (cmbSourseOrig.Text != "")
            {
                strFilter += " AND (source_of_origin = '" + cmbSourseOrig.Text + "')";
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
            frmAddGemstone frmAdd = new frmAddGemstone();
            frmAdd.ShowDialog();
            h.bs1.DataSource = h.myfunDt("SELECT * FROM Gemstone");
            dataGridView1.DataSource = h.bs1;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            h.curVal0 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            h.keyName = dataGridView1.Columns[0].Name;

            frmRemoveGem formRemove = new frmRemoveGem();
            formRemove.ShowDialog();

            h.bs1.DataSource = h.myfunDt("SELECT * FROM Gemstone");
            dataGridView1.DataSource = h.bs1;
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            h.keyName = dataGridView1.Columns[0].Name;
            h.curVal0 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            int curColInx = dataGridView1.CurrentCellAddress.X;
            string curColName = dataGridView1.Columns[curColInx].Name;
            string newCurCellVal = e.Value.ToString();

            if (curColName == "name" || curColName == "chemical_composition"
                || curColName == "color" || curColName == "transparency"
                || curColName == "hardness" || curColName == "source_of_origin"
                || curColName == "market_value")
            {
                newCurCellVal = "'" + newCurCellVal + "'";
            }

            string sqlStr = "UPDATE Gemstone SET " + curColName + " = " +
                newCurCellVal + " WHERE " + h.keyName + " = " + h.curVal0;

            // MessageBox.Show(sqlStr);

            if (MessageBox.Show("Are you sure you want to change data?", "Change value in table Gemstone",
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

            editGemstone form = new editGemstone();
            form.ShowDialog();

            h.bs1.DataSource = h.myfunDt("SELECT * FROM Gemstone");
            dataGridView1.DataSource = h.bs1;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;

            if (dataGridView1.Rows[rowIndex].Cells[8].Value.ToString().Length > 0)
            {
                byte[] a = (byte[])dataGridView1.Rows[rowIndex].Cells[8].Value;
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
    }
}   
