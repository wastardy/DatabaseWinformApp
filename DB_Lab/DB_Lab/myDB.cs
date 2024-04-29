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
// using MySql.Data.MySqlClient;

namespace DB_Lab
{
    public partial class myDB : Form
    {
        public myDB()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About f1 = new About();
            f1.ShowDialog();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculator c1 = new Calculator();
            c1.ShowDialog();
        }

        private void myDB_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TableExpert_Click(object sender, EventArgs e)
        {
            frmExpert f1 = new frmExpert();
            f1 .ShowDialog();
        }

        private void TableExploration_Click(object sender, EventArgs e)
        {
            frmExploration f2 = new frmExploration();
            f2.ShowDialog();
        }

        private void TableGemstone_Click(object sender, EventArgs e)
        {
            frmGemstone f3 = new frmGemstone();
            f3.ShowDialog();
        }

        private void TableLaboratory_Click(object sender, EventArgs e)
        {
            frmLaboratory f4 = new frmLaboratory();
            f4.ShowDialog();
        }

        private void myDB_Load(object sender, EventArgs e)
        {
            // MessageBox.Show(h.typeUser);
            if (int.Parse(h.typeUser) > 1)
            {
                adminToolStripMenuItem.Visible = false;
            }
        }

        private void addNewUser_Click(object sender, EventArgs e)
        {

        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addNewUser frmAddUser = new addNewUser();
            frmAddUser.ShowDialog();
        }

        private void removeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteUser frmDeleteUser = new deleteUser();
            frmDeleteUser.ShowDialog();
        }

        private void changeUsersPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editPassword frmEditPassword = new editPassword();
            frmEditPassword.ShowDialog();
        }

        private void changeUsersAccessTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editAccessType frmEditAccessType = new editAccessType();
            frmEditAccessType.ShowDialog();
        }

        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(h.conStr);
            MySqlCommand cmd = new MySqlCommand("CALL call_multiple_procedures", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Can't connect to SQL server!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Backup completed successfully! ");
        }

        private void backupDatabaseRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(h.conStr);
            MySqlCommand cmd = new MySqlCommand("CALL recoverExpertTable", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Can't connect to SQL server!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MessageBox.Show("Recovery completed successfully! ");
        }
    }
}
