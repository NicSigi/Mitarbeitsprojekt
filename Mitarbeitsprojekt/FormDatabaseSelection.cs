using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Mitarbeitsprojekt
{
    public partial class FormDatabaseSelection : Form
    {
        private List<string> databases;
        private SqlConnection connection;

        public FormDatabaseSelection(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
            databases = new List<string>();
            LoadDatabases();
            UpdateDatabaseList();
        }

        private void LoadDatabases()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                DataTable databasesTable = connection.GetSchema("Databases");
                databases.Clear();

                foreach (DataRow row in databasesTable.Rows)
                {
                    string databaseName = row["database_name"].ToString();
                    databases.Add(databaseName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Datenbanken: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void UpdateDatabaseList()
        {
            cmbDatabases.Items.Clear();
            cmbDatabases.Items.AddRange(databases.ToArray());
            cmbDatabases.SelectedIndex = databases.Count > 0 ? 0 : -1;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            
            string newDbName = txtNewDatabase.Text.Trim();
            MessageBox.Show(newDbName);

            if (string.IsNullOrEmpty(newDbName))
            {
                MessageBox.Show("Bitte geben Sie einen gültigen Datenbanknamen ein.");
                return;
            }

            // Datenbankname validieren
            if (!IsValidDatabaseName(newDbName))
            {
                MessageBox.Show("Ungültiger Datenbankname. Erlaubt sind nur alphanumerische Zeichen und Unterstriche.");
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string createDbQuery = $"CREATE DATABASE [{newDbName}]";
                using (SqlCommand cmd = new SqlCommand(createDbQuery, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Datenbank '{newDbName}' erfolgreich erstellt!");
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

        private bool IsValidDatabaseName(string dbName)
        {
            // Prüfen, ob nur alphanumerische Zeichen und Unterstriche verwendet werden
            return Regex.IsMatch(dbName, @"^[a-zA-Z0-9_]+$");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (cmbDatabases.SelectedItem == null)
            {
                MessageBox.Show("Bitte wählen Sie eine Datenbank zum Löschen aus.");
                return;
            }

            string selectedDb = cmbDatabases.SelectedItem.ToString();

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = $"DROP DATABASE [{selectedDb}]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }

                databases.Remove(selectedDb);
                MessageBox.Show($"Datenbank '{selectedDb}' erfolgreich gelöscht.");
                UpdateDatabaseList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Löschen der Datenbank: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void BtnUse_Click(object sender, EventArgs e)
        {
            if (cmbDatabases.SelectedItem == null)
            {
                MessageBox.Show("Bitte wählen Sie eine Datenbank zum Verwenden aus.");
                return;
            }

            string selectedDb = cmbDatabases.SelectedItem.ToString();

            try
            {
                var builder = new SqlConnectionStringBuilder(connection.ConnectionString)
                {
                    InitialCatalog = selectedDb
                };

                connection = new SqlConnection(builder.ConnectionString);
                connection.Open();

                MessageBox.Show($"Datenbank '{selectedDb}' erfolgreich ausgewählt!");

                FormTableSelection formTableSelection = new FormTableSelection(connection);
                this.Hide();
                formTableSelection.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Verwenden der Datenbank: {ex.Message}");
            }
        }

        private void FormDatabaseSelection_Load(object sender, EventArgs e)
        {
            LoadDatabases();
            UpdateDatabaseList();
        }

        private void cmbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Auswahl in ComboBox geändert
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
                if (cmbDatabases.SelectedItem == null) // Prüfen, ob eine Datenbank ausgewählt wurde
                {
                    MessageBox.Show("Bitte wählen Sie eine Datenbank zum Löschen aus.");
                    return; // Abbrechen, falls keine Auswahl getroffen wurde
                }

                string selectedDb = cmbDatabases.SelectedItem.ToString(); // Ausgewählte Datenbank abrufen

                DialogResult result = MessageBox.Show(
                    $"Sind Sie sicher, dass Sie die Datenbank '{selectedDb}' löschen möchten? Alle Daten gehen unwiderruflich verloren!",
                    "Datenbank löschen",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    return; // Abbrechen, falls der Benutzer "Nein" auswählt
                }

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open(); // Verbindung öffnen

                    // SQL-Befehl, um die Datenbank zu löschen
                    string query = $"DROP DATABASE [{selectedDb}]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery(); // SQL-Befehl ausführen
                    }

                    // Entfernen der gelöschten Datenbank aus der Liste
                    databases.Remove(selectedDb);
                    MessageBox.Show($"Datenbank '{selectedDb}' wurde erfolgreich gelöscht.");

                    UpdateDatabaseList(); // Aktualisiere die Liste der verfügbaren Datenbanken
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Löschen der Datenbank: {ex.Message}");
                }
                finally
                {
                    connection.Close(); // Verbindung schließen
                }
            }
        }
    }