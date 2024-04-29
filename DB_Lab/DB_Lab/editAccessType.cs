using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DB_Lab
{
    public partial class editAccessType : Form
    {
        DataTable dtUserName;

        public editAccessType()
        {
            InitializeComponent();
        }

        private void editAccessType_Load(object sender, EventArgs e)
        {
            dtUserName = h.myfunDt("SELECT * FROM userName");

            for (int i = 0; i < dtUserName.Rows.Count; i++)
            {
                cmbUserName.Items.Add(dtUserName.Rows[i][1].ToString());
            }

            cmbUserName.Text = dtUserName.Rows[0][1].ToString();

            for (int i = 1; i <= 3; i++)
            {
                cmbAccessType.Items.Add(i.ToString());
            }

            // cmbAccessType.Text = dtUserName.Rows[0][1].ToString(); ??
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            int countAdm = 0;
            for (int i = 0; i < dtUserName.Rows.Count; i++)
            {
                if (int.Parse(dtUserName.Rows[i][2].ToString()) == 1)
                    countAdm++;
            }

            if (countAdm > 1)
            {
                string sqlcmd = "UPDATE userName SET Type = '" + cmbAccessType.Text +
                    "' WHERE UserName = '" + cmbUserName.Text + "'";

                MySqlConnection con = new MySqlConnection(h.conStr);
                MySqlCommand cmdAdd = new MySqlCommand(sqlcmd, con);

                con.Open();
                cmdAdd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Access type for user '" + cmbUserName.Text + 
                    "' \n successfully changed.");

                this.Close();
            }
            else
            {
                MessageBox.Show("You cannot change access type for user '" + cmbUserName.Text +
                    "'! \n                   This is the only admin.", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmbAccessType.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
