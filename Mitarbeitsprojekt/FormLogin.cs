using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mitarbeitsprojekt
{
    public partial class FormLogin : Form
    {
        public SqlConnection connection;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            TextBox txtServer = (TextBox)this.Controls["txtServer"];
            TextBox txtUsername = (TextBox)this.Controls["txtUsername"];
            TextBox txtPassword = (TextBox)this.Controls["txtPassword"];
            CheckBox chkSSPI = (CheckBox)this.Controls["chkRememberMe"];

            string connectionString;

            // Verbindungsmethoden
            if (chkSSPI.Checked)
            {
                // SSPI
                connectionString = $"Server={txtServer.Text}; Integrated Security=True;";
            }
            else
            {
                // Benutzername und Passwort
                connectionString = $"Server={txtServer.Text}; User Id={txtUsername.Text}; Password={txtPassword.Text};";
            }

            // Test der Verbindung
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    FormDatabaseSelection formDatabaseSelection = new FormDatabaseSelection(connection);
                    this.Hide();
                    formDatabaseSelection.ShowDialog();
 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}");
            }
        }

        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSSPI = sender as CheckBox;
            TextBox txtUsername = (TextBox)this.Controls["txtUsername"];
            TextBox txtPassword = (TextBox)this.Controls["txtPassword"];

            if (chkRememberMe.Checked == true) 
            {
                txtUsername.Visible = false;
                lblBenutzername.Visible = false;

                txtPassword.Visible = false;
                lblPasswort.Visible = false;
            }
            else
            {
                txtUsername.Visible = true;
                lblBenutzername.Visible = true;

                txtPassword.Visible = true;
                lblPasswort.Visible = true;
            }
        }

        private void txtServer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

