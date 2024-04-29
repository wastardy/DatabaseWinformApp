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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Lab
{
    public partial class frmAddLaboratory : Form
    {
        public frmAddLaboratory()
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

                string strFileName = h.pathToPhoto;
                FileStream fileStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                int fileSize = (Int32)fileStream.Length;
                byte[] dataArray = new byte[fileSize];
                fileStream.Read(dataArray, 0, fileSize);
                fileStream.Close();

                // add request
                string sql = "INSERT INTO Laboratory " +
                    "(name, address, contact_information, lab_image)" +
                    " VALUES (@lab_name, @lab_address," +
                    " @contact_info, @File)";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@lab_name", tb1);
                cmd.Parameters.AddWithValue("@lab_address", tb2);
                cmd.Parameters.AddWithValue("@contact_info", tb3);

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

        private void frmAddLaboratory_Load(object sender, EventArgs e)
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
