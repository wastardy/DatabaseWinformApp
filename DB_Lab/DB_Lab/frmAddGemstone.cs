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
    public partial class frmAddGemstone : Form
    {
        public frmAddGemstone()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(h.conStr))
            {
                string tb1 = textBox1.Text;
                string tb2 = textBox2.Text;
                string tb3 = textBox3.Text;
                string tb4 = textBox4.Text;
                string tb5 = textBox5.Text;
                string tb6 = textBox6.Text;
                string tb7 = textBox7.Text;

                string strFileName = h.pathToPhoto;
                FileStream fileStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                int fileSize = (Int32)fileStream.Length;
                byte[] dataArray = new byte[fileSize];
                fileStream.Read(dataArray, 0, fileSize);
                fileStream.Close();

                // add request
                string sql = "INSERT INTO Gemstone " +
                    "(name, chemical_composition, " +
                    "color, transparency, hardness, " +
                    "source_of_origin, market_value, gem_image)" +
                    
                    " VALUES (@gem_name, @chem_compos, " +
                    "@color, @transpar, @hardness, " +
                    "@src_orig, @market_val, @File)";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@gem_name", tb1);
                cmd.Parameters.AddWithValue("@chem_compos", tb2);
                cmd.Parameters.AddWithValue("@color", tb3); 
                cmd.Parameters.AddWithValue("@transpar", tb4);
                cmd.Parameters.AddWithValue("@hardness", tb5);
                cmd.Parameters.AddWithValue("@src_orig", tb6);
                cmd.Parameters.AddWithValue("@market_val", tb7);

                cmd.Parameters.AddWithValue("@File", dataArray);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Added successfully");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddGemstone_Load(object sender, EventArgs e)
        {
            h.pathToPhoto = Application.StartupPath + @"\" + "photo.jpg";
            pictureBox1.Image = Image.FromFile(h.pathToPhoto);
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
