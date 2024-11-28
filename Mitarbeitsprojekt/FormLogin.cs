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
        public SqlConnection connection; // Verbindung zur Datenbank

        // Konstruktor: Initialisiert das Login-Formular
        public FormLogin()
        {
            InitializeComponent(); // UI-Initialisierung
        }

        // Wird beim Laden des Formulars ausgeführt
        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Aktuell leer, hier kann zusätzliche Logik ergänzt werden
        }

        // Wird aufgerufen, wenn der Login-Button gedrückt wird
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Eingabefelder abrufen
            TextBox txtServer = (TextBox)this.Controls["txtServer"];
            TextBox txtUsername = (TextBox)this.Controls["txtUsername"];
            TextBox txtPassword = (TextBox)this.Controls["txtPassword"];
            CheckBox chkSSPI = (CheckBox)this.Controls["chkRememberMe"];

            string connectionString; // Verbindungszeichenfolge

            // Verbindungsmethoden
            if (chkSSPI.Checked)
            {
                // SSPI (Windows-Authentifizierung)
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
                using (SqlConnection connection = new SqlConnection(connectionString)) // Verbindung erstellen
                {
                    connection.Open(); // Verbindung öffnen
                    FormDatabaseSelection formDatabaseSelection = new FormDatabaseSelection(connection); // Nächstes Formular öffnen
                    this.Hide(); // Aktuelles Formular ausblenden
                    formDatabaseSelection.ShowDialog(); // Datenbankauswahl anzeigen
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}"); // Fehler anzeigen
            }
        }

        // Wenn der Checkbox-Wert geändert wird
        private void chkRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkSSPI = sender as CheckBox; // Checkbox abrufen
            TextBox txtUsername = (TextBox)this.Controls["txtUsername"]; // Benutzername-Feld
            TextBox txtPassword = (TextBox)this.Controls["txtPassword"]; // Passwort-Feld

            if (chkRememberMe.Checked == true) // Wenn Checkbox aktiviert ist
            {
                txtUsername.Visible = false; // Benutzername ausblenden
                lblBenutzername.Visible = false;

                txtPassword.Visible = false; // Passwort ausblenden
                lblPasswort.Visible = false;
            }
            else
            {
                txtUsername.Visible = true; // Benutzername einblenden
                lblBenutzername.Visible = true;

                txtPassword.Visible = true; // Passwort einblenden
                lblPasswort.Visible = true;
            }
        }

        // Wird aufgerufen, wenn sich der Text im Server-Feld ändert
        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            // Aktuell leer, hier kann Logik ergänzt werden
        }
    }
}
