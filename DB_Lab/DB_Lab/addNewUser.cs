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
    public partial class addNewUser : Form
    {
        DataTable dtUserName;
        bool nUser;

        public addNewUser()
        {
            InitializeComponent();
        }

        private void addNewUser_Load(object sender, EventArgs e)
        {
            dtUserName = h.myfunDt("SELECT * FROM userName");
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            nUser = true;

            if (btnCancel.Focused ) 
            {
                this.Close();
            }
            else
            {
                for (int i = 0; i < dtUserName.Rows.Count; i++) 
                {
                    if (String.Equals(txtUserName.Text.Trim(), dtUserName.Rows[i][1].ToString())
                        || (String.Equals(txtUserName.Text, "")))
                    {
                        nUser = false;
                        break;
                    }
                }
            }
            if (!nUser)
            {
                MessageBox.Show("Username is not filled in or already exists!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
            }
        }

        private void txtAccessType_Leave(object sender, EventArgs e)
        {
            int g;
            nUser = true;

            if (btnCancel.Focused)
            {
                this.Close();
            }
            else
            {
                if (!int.TryParse(txtAccessType.Text, out g))
                {
                    nUser = false;
                    MessageBox.Show("Value is not a num");
                }
                else if ((int.Parse(txtAccessType.Text) < 0)
                    || (int.Parse(txtAccessType.Text) > 3))
                {
                    nUser = false;
                    MessageBox.Show("Num is out of range");
                }
            }

            if (!nUser)
            {
                MessageBox.Show("Incorrect user access type", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAccessType.Focus();
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text != "")
            {
                if (txtAccessType.Text != "")
                {
                    if (String.Equals(txtPassword.Text, txtConfirmPassword.Text))
                    {
                        string sqlcmd = "INSERT INTO userName (UserName, Type, Password)" +
                            " VALUES (@user_name, @access_type, @password)";
                        
                        MySqlConnection con = new MySqlConnection(h.conStr);
                        MySqlCommand cmdAdd = new MySqlCommand(sqlcmd, con);
                        
                        cmdAdd.Parameters.AddWithValue("@user_name", txtUserName.Text);
                        cmdAdd.Parameters.AddWithValue("@access_type", txtAccessType.Text);
                        cmdAdd.Parameters.AddWithValue("@password", h.EncriptedPassword_SHA256(txtPassword.Text));
                        
                        con.Open();
                        cmdAdd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("new user '" + txtUserName.Text + "'\n successfully added!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Passwords doesn't match! " +
                            "\n Enter passwords correctly.", "Error!", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("User access type not specified! " +
                            "\n Enter user access type correctly.", "Error!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAccessType.Focus();
                }
            }
            else
            {
                MessageBox.Show("No username specified! " +
                            "\n Enter a username correctly.", "Error!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}