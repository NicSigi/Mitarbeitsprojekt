using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mitarbeitsprojekt
{
    public partial class FormDatabaseSelection : Form
    {
        private List<string> databases; // Liste der verfügbaren Datenbanken
        private SqlConnection connection; // Verbindung zur SQL-Datenbank

        // Konstruktor - Verbindung wird übergeben
        public FormDatabaseSelection(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn; // Verbindung speichern
            databases = new List<string>(); // Liste initialisieren
            LoadDatabases(); // Datenbanken laden
            UpdateDatabaseList(); // Datenbankliste in ComboBox anzeigen
        }

        // Datenbanken laden
        private void LoadDatabases()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open(); // Verbindung öffnen, falls geschlossen

                // SQL-Schema "Databases" abfragen
                DataTable databasesTable = connection.GetSchema("Databases");
                databases.Clear(); // Liste leeren

                // Jede Datenbank zur Liste hinzufügen
                foreach (DataRow row in databasesTable.Rows)
                {
                    string databaseName = row["database_name"].ToString(); // Name abrufen
                    databases.Add(databaseName); // Zur Liste hinzufügen
                }
            }
            catch (Exception ex) // Fehler abfangen
            {
                MessageBox.Show($"Fehler beim Laden der Datenbanken: {ex.Message}");
            }
            finally
            {
                connection.Close(); // Verbindung schließen
            }
        }

        // ComboBox mit Datenbanken aktualisieren
        private void UpdateDatabaseList()
        {
            cmbDatabases.Items.Clear(); // ComboBox leeren
            cmbDatabases.Items.AddRange(databases.ToArray()); // Neue Datenbanken einfügen
            cmbDatabases.SelectedIndex = databases.Count > 0 ? 0 : -1; // Erste auswählen
        }

        // Neue Datenbank hinzufügen
        private void BtnNew_Click(object sender, EventArgs e)
        {
            string newDbName = txtNewDatabase.Text.Trim(); // Name der neuen Datenbank
            if (string.IsNullOrEmpty(newDbName))
            {
                MessageBox.Show("Bitte geben Sie einen gültigen Datenbanknamen ein.");
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string createDbQuery = $"CREATE DATABASE [{newDbName}]"; // SQL-Abfrage zum Erstellen der Datenbank
                using (SqlCommand cmd = new SqlCommand(createDbQuery, connection))
                {
                    cmd.ExecuteNonQuery(); // Abfrage ausführen
                }

                MessageBox.Show($"Datenbank '{newDbName}' erfolgreich erstellt!");

                // Liste der Datenbanken aktualisieren
                LoadDatabases();
                UpdateDatabaseList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Erstellen der Datenbank: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }


        // Datenbank löschen
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (cmbDatabases.SelectedItem == null) // Prüfen, ob etwas ausgewählt ist
            {
                MessageBox.Show("Bitte wählen Sie eine Datenbank zum Löschen aus.");
                return; // Abbrechen
            }

            string selectedDb = cmbDatabases.SelectedItem.ToString(); // Ausgewählte Datenbank holen

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open(); // Verbindung öffnen

                // SQL-Befehl für das Löschen der Datenbank
                string query = $"DROP DATABASE [{selectedDb}]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery(); // Befehl ausführen
                }

                databases.Remove(selectedDb); // Datenbank aus der Liste entfernen
                MessageBox.Show($"Datenbank '{selectedDb}' erfolgreich gelöscht.");
                UpdateDatabaseList(); // Liste aktualisieren
            }
            catch (Exception ex) // Fehler abfangen
            {
                MessageBox.Show($"Fehler beim Löschen der Datenbank: {ex.Message}");
            }
            finally
            {
                connection.Close(); // Verbindung schließen
            }
        }

        // Datenbank umbenennen
        private void BtnRename_Click(object sender, EventArgs e)
        {
            if (cmbDatabases.SelectedItem == null) // Prüfen, ob etwas ausgewählt ist
            {
                MessageBox.Show("Bitte wählen Sie eine Datenbank zum Umbenennen aus.");
                return; // Abbrechen
            }

            string selectedDb = cmbDatabases.SelectedItem.ToString(); // Ausgewählte Datenbank holen
            string newDbName = txtNewDatabase.Text.Trim(); // Neuer Name aus TextBox

            if (string.IsNullOrEmpty(newDbName)) // Prüfen, ob der neue Name leer ist
            {
                MessageBox.Show("Bitte geben Sie einen neuen gültigen Datenbanknamen ein.");
                return; // Abbrechen
            }

            if (databases.Contains(newDbName)) // Prüfen, ob neuer Name schon existiert
            {
                MessageBox.Show("Eine Datenbank mit diesem Namen existiert bereits.");
                return; // Abbrechen
            }

            // Datenbanken können nicht direkt umbenannt werden
            MessageBox.Show("Datenbanken können nicht direkt umbenannt werden. Erstellen Sie eine neue Datenbank und kopieren Sie die Daten.");
        }

        // Datenbank verwenden
        private void BtnUse_Click(object sender, EventArgs e)
        {
            if (cmbDatabases.SelectedItem == null) // Prüfen, ob etwas ausgewählt ist
            {
                MessageBox.Show("Bitte wählen Sie eine Datenbank zum Verwenden aus.");
                return; // Abbrechen
            }

            string selectedDb = cmbDatabases.SelectedItem.ToString(); // Ausgewählte Datenbank holen

            try
            {
                // ConnectionString aktualisieren
                var builder = new SqlConnectionStringBuilder(connection.ConnectionString)
                {
                    InitialCatalog = selectedDb // Datenbankname setzen
                };

                connection = new SqlConnection(builder.ConnectionString); // Neue Verbindung
                connection.Open(); // Verbindung testen

                MessageBox.Show($"Datenbank '{selectedDb}' erfolgreich ausgewählt!");

                // Nächste Form öffnen
                FormTableSelection formTableSelection = new FormTableSelection(connection);
                this.Hide(); // Aktuelles Fenster verstecken
                formTableSelection.ShowDialog(); // Neues Fenster anzeigen
                this.Close(); // Aktuelles Fenster schließen
            }
            catch (Exception ex) // Fehler abfangen
            {
                MessageBox.Show($"Fehler beim Verwenden der Datenbank: {ex.Message}");
            }
        }

        private void FormDatabaseSelection_Load(object sender, EventArgs e)
        {
            LoadDatabases(); // Datenbanken laden
            UpdateDatabaseList(); // Liste aktualisieren
        }

        private void cmbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl in ComboBox geändert
        }



    }
}
