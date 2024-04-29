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
    public partial class frmLaboratory : Form
    {
        public frmLaboratory()
        {
            InitializeComponent();
        }

        private void TableLaboratory_Click(object sender, EventArgs e)
        {
            frmLaboratory f4 = new frmLaboratory();
            f4.ShowDialog();
        }

        private void frmLaboratory_Load(object sender, EventArgs e)
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
            h.bs1.DataSource = h.myfunDt("SELECT * FROM Laboratory");
            dataGridView1.DataSource = h.bs1;
            bindingNavigator1.BindingSource = h.bs1;

            h.bs1.Sort = "name ASC";

            DWGFormat();
        }

        void DWGFormat()
        {
            dataGridView1.Font = new Font("Times New Roman", 12, FontStyle.Regular);

            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[0].HeaderText = "№";

            dataGridView1.Columns[1].Width = 160;

            dataGridView1.Columns[2].Width = 175;

            dataGridView1.Columns[3].Width = 320;
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

        private void addNew_Click(object sender, EventArgs e)
        {
            frmAddLaboratory formAdd = new frmAddLaboratory();
            formAdd.ShowDialog();
            h.bs1.DataSource = h.myfunDt("SELECT * FROM Laboratory");
            dataGridView1.DataSource = h.bs1;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            h.curVal0 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            h.keyName = dataGridView1.Columns[0].Name;

            frmRemoveLaboratory formRemove = new frmRemoveLaboratory();
            formRemove.ShowDialog();

            h.bs1.DataSource = h.myfunDt("SELECT * FROM Laboratory");
            dataGridView1.DataSource = h.bs1;
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            h.keyName = dataGridView1.Columns[0].Name;
            h.curVal0 = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            int curColInx = dataGridView1.CurrentCellAddress.X;
            string curColName = dataGridView1.Columns[curColInx].Name;
            string newCurCellVal = e.Value.ToString();

            if (curColName == "name" || curColName == "address"
                || curColName == "contact_information")
            {
                newCurCellVal = "'" + newCurCellVal + "'";
            }

            string sqlStr = "UPDATE Laboratory SET " + curColName + " = " +
                newCurCellVal + " WHERE " + h.keyName + " = " + h.curVal0;

            // MessageBox.Show(sqlStr);

            if (MessageBox.Show("Are you sure you want to change data?", "Change value in table Laboratory",
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

            editLaboratory form = new editLaboratory();
            form.ShowDialog();

            h.bs1.DataSource = h.myfunDt("SELECT * FROM Laboratory");
            dataGridView1.DataSource = h.bs1;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;

            if (dataGridView1.Rows[rowIndex].Cells[4].Value.ToString().Length > 0)
            {
                byte[] a = (byte[])dataGridView1.Rows[rowIndex].Cells[4].Value;
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
