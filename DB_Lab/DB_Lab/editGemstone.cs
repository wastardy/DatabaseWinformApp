using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Lab
{
    public partial class editGemstone : Form
    {
        public editGemstone()
        {
            InitializeComponent();
        }

        private void Apply()
        {
            string sqlStr;

            if ((checkBoxTxt.Checked == true) && (checkBoxImg.Checked == false))
            {
                sqlStr = "UPDATE Gemstone SET " + txtSetUpdate.Text +
                " WHERE " + txtWhereUpdate.Text;

                if (MessageBox.Show("Are you sure you want to change data?", "Change value in Gemstone table",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MySqlConnection con = new MySqlConnection(h.conStr))
                    {
                        MySqlCommand cmd = new MySqlCommand(sqlStr, con);
                            con.Open();             // open connection
                            cmd.ExecuteNonQuery();  // execute command
                            con.Close();            // close connection
                        MessageBox.Show("Edited successfully");
                    }
                }
            }

            if ((checkBoxTxt.Checked == false) && (checkBoxImg.Checked == true))
            {
                int fileSize;
                byte[] bytesArray;
                FileStream fileStream;
                string strFileName;

                strFileName = h.pathToPhoto; // get from openFileDialog
                fileStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                fileSize = (Int32)fileStream.Length;
                bytesArray = new byte[fileSize];
                fileStream.Read(bytesArray, 0, fileSize);
                fileStream.Close();

                sqlStr = "UPDATE Gemstone SET gem_image = @File WHERE " +
                    txtWhereUpdate.Text;

                if (MessageBox.Show("Are you sure you want to change data?", "Change value in Gemstone table",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MySqlConnection con = new MySqlConnection(h.conStr))
                    {
                        MySqlCommand cmd = new MySqlCommand(sqlStr, con);
                        cmd.Parameters.AddWithValue("@File", bytesArray);

                            con.Open();             // open connection
                            cmd.ExecuteNonQuery();  // execute command
                            con.Close();            // close connection
                        MessageBox.Show("Edited successfully");
                    }
                }
            }

            if ((checkBoxTxt.Checked == true) && (checkBoxImg.Checked == true))
            {
                int fileSize;
                byte[] dataArray;
                FileStream fileStream;
                string strFileName;

                strFileName = h.pathToPhoto; // get from openFileDialog
                fileStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                fileSize = (Int32)fileStream.Length;
                dataArray = new byte[fileSize];
                fileStream.Read(dataArray, 0, fileSize);
                fileStream.Close();

                sqlStr = "UPDATE Gemstone SET " + txtSetUpdate.Text +
                    " , gem_image = @File " + 
                    " WHERE " + txtWhereUpdate.Text;

                if (MessageBox.Show("Are you sure you want to change data?", "Change data in Gemstone table",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MySqlConnection con = new MySqlConnection(h.conStr))
                    {
                        MySqlCommand cmd = new MySqlCommand(sqlStr, con);
                        cmd.Parameters.AddWithValue("@File", dataArray);
                            con.Open();             // open connection
                            cmd.ExecuteNonQuery();  // execute command
                            con.Close();            // close connection
                        MessageBox.Show("Edited successfully");
                    }
                }
            }

            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void txtSetUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Apply();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editGemstone_Load(object sender, EventArgs e)
        {
            txtWhereUpdate.Text = h.keyName + " = "; // + h.curVal0;
            h.pathToPhoto = Application.StartupPath + @"\" + "photo.jpg";
            pictureBox1.Image = Image.FromFile(h.pathToPhoto);
        }

        private void checkBoxTxt_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTxt.Checked == true)
            {
                label1.Visible = true;
                txtSetUpdate.Visible = true;
                btnApply.Visible = true;
            }
            else if (checkBoxTxt.Checked == false)
            {
                label1.Visible = false;
                txtSetUpdate.Visible = false;

                if (checkBoxImg.Checked == false)
                {
                    btnApply.Visible = false;
                }
            }
        }

        private void checkBoxImg_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxImg.Checked == true)
            {
                panel2.Visible = true;
                label3.Visible = true;
                btnSelect.Visible = true;
                pictureBox1.Visible = true;
                btnApply.Visible = true;
            }
            else if (checkBoxImg.Checked == false)
            {
                panel2.Visible = false;
                label3.Visible = false;
                btnSelect.Visible = false;
                pictureBox1.Visible = false;

                if (checkBoxTxt.Checked == false)
                {
                    btnApply.Visible = false;
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select file";
            openFileDialog.Filter = "img files (*.jpg)|*.jpg|bmp file (*.bmp)|*.bmp|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Application.StartupPath;

            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            {
                h.pathToPhoto = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(h.pathToPhoto);
            }
        }
    }
}
