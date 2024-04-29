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
    public partial class editPassword : Form
    {
        DataTable dtUserName;

        public editPassword()
        {
            InitializeComponent();
        }

        private void editPassword_Load(object sender, EventArgs e)
        {
            dtUserName = h.myfunDt("SELECT * FROM userName");

            for (int i = 0; i < dtUserName.Rows.Count; i++)
            {
                cmbUserName.Items.Add(dtUserName.Rows[i][1].ToString());
            }

            cmbUserName.Text = dtUserName.Rows[0][1].ToString();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (String.Equals(txtPassword.Text, txtPasswordConfirm.Text) 
                && txtPassword.Text != "")
            {
                string sqlcmd = "UPDATE userName SET Password = '" +
                    h.EncriptedPassword_SHA256(txtPassword.Text) +
                    "' WHERE UserName = '" + cmbUserName.Text + "'";

                MySqlConnection con = new MySqlConnection(h.conStr);
                MySqlCommand cmdAdd = new MySqlCommand(sqlcmd, con);

                con.Open();
                cmdAdd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Password for user '" + cmbUserName.Text +
                    "'\n changed successfully. ", "", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Passwords don't match \n or aren't entered.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
