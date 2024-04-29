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
    public partial class deleteUser : Form
    {
        DataTable dtUserName;

        public deleteUser()
        {
            InitializeComponent();
        }

        private void deleteUser_Load(object sender, EventArgs e)
        {
            dtUserName = h.myfunDt("SELECT * FROM userName");

            for (int i = 0; i < dtUserName.Rows.Count; i++)
            {
                cmbUserName.Items.Add(dtUserName.Rows[i][1].ToString());
            }

            cmbUserName.Text = dtUserName.Rows[0][1].ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int countAdm = 0;
            for (int i = 0; i < dtUserName.Rows.Count; i++ )
            {
                if (int.Parse(dtUserName.Rows[i][2].ToString()) == 1)
                {
                    countAdm++;
                }
            }
            if (countAdm > 0)
            {
                string sqlcmd = "DELETE FROM userName " +
                    " WHERE UserName = '" + cmbUserName.Text + "'";
                
                MySqlConnection con = new MySqlConnection(h.conStr);
                MySqlCommand cmdAdd = new MySqlCommand(sqlcmd, con);

                con.Open();
                cmdAdd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User '" + cmbUserName.Text + "'\n was deleted successfully");

                this.Close();
            }
            else
            {
                MessageBox.Show("You cannot delete '" + cmbUserName.Text + 
                    "'\n because '" + cmbUserName.Text + "' is only administrator", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbUserName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
