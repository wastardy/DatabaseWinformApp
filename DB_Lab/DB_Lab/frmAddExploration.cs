using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Lab
{
    public partial class frmAddExploration : Form
    {
        public frmAddExploration()
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

                // add request
                string sql = "INSERT INTO Exploration " +
                    "(expert_id, gem_id, laboratory_id, date_of_exploration, time_of_exploration)" +
                    " VALUES (@exp_id, @gem_id, @lab_id, @dt_explor, @tm_explor)";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@exp_id", tb1);
                cmd.Parameters.AddWithValue("@gem_id", tb2);
                cmd.Parameters.AddWithValue("@lab_id", tb3); 
                cmd.Parameters.AddWithValue("@dt_explor", tb4);
                cmd.Parameters.AddWithValue("@tm_explor", tb5);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record added successfully.");
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
