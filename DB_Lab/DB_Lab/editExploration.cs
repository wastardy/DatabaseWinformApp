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

namespace DB_Lab
{
    public partial class editExploration : Form
    {
        public editExploration()
        {
            InitializeComponent();
        }

        private void Apply()
        {
            string sqlStr = "UPDATE Exploration SET " + txtSetUpdate.Text +
                " WHERE " + txtWhereUpdate.Text;

            if (MessageBox.Show("Are you sure you want to change data?", "Change date of exploration",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (MySqlConnection con = new MySqlConnection(h.conStr))
                {
                    MySqlCommand cmd = new MySqlCommand(sqlStr, con);
                    con.Open();             // open connection
                    cmd.ExecuteNonQuery();  // execute command
                    con.Close();            // close connection
                }
            }
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editExploration_Load(object sender, EventArgs e)
        {
            txtWhereUpdate.Text = h.keyName + " = " + h.curVal0;
        }

        private void txtSetUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Apply();
            }
        }
    }
}
