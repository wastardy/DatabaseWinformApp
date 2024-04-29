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
    public partial class frmAddToExpert : Form
    {
        public frmAddToExpert()
        {
            InitializeComponent();
        }

        private void btnAddExpertAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(h.conStr))
            {
                string tb1 = textBox1.Text;
                string tb2 = textBox2.Text;
                string tb3 = textBox3.Text;
                string tb4 = textBox4.Text;
                string tb5 = textBox5.Text;
                string tb6 = textBox6.Text;

                string strFileName = h.pathToPhoto;
                FileStream fileStream = new FileStream(strFileName, FileMode.Open, FileAccess.Read);
                int fileSize = (Int32)fileStream.Length;
                byte[] dataArray = new byte[fileSize];
                fileStream.Read(dataArray, 0, fileSize);
                fileStream.Close();

                // add request
                string sql = "INSERT INTO Expert " +
                    "(expert_name, qualifications, " +
                    "hire_date, phone_number, " +
                    "salary, researches, expert_image)" +
                    
                    " VALUES (@exp_name, @qualif, " +
                    "@hire_dt, @ph_num, @salary, " +
                    "@research, @File)";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@exp_name", tb1);
                cmd.Parameters.AddWithValue("@qualif", tb2);
                cmd.Parameters.AddWithValue("@hire_dt", tb3); 
                cmd.Parameters.AddWithValue("@ph_num", tb4);
                cmd.Parameters.AddWithValue("@salary", tb5);
                cmd.Parameters.AddWithValue("@research", tb6);

                cmd.Parameters.AddWithValue("@File", dataArray);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Added successfully");
            }
            this.Close();
        }

        private void btnAddExpertCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddToExpert_Load(object sender, EventArgs e)
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
