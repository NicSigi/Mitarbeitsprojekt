using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mitarbeitsprojekt
{
    public partial class FormTableSelection : Form
    {
        private SQLManagement sqlManager;
        private List<string> tables;
        private SqlConnection connection;

        // Konstruktor mit SQLManagement
        public FormTableSelection(SQLManagement manager)
        {
            InitializeComponent();
            sqlManager = manager;
            tables = new List<string>();
        }

        // Konstruktor mit SqlConnection
        public FormTableSelection(SqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;

            // Initialisiere SQLManagement
            sqlManager = new SQLManagement();
            sqlManager.connection = connection;

            tables = new List<string>();
        }

        private void FormTableSelection_Load(object sender, EventArgs e)
        {
            LoadTables(); // Tabellen laden
            UpdateTableList(); // Tabelle anzeigen
        }

        private void LoadTables()
        {
            if (sqlManager == null || sqlManager.connection == null)
            {
                MessageBox.Show("SQLManager oder Verbindung ist nicht korrekt initialisiert.");
                return;
            }

            tables = sqlManager.GetTables();
        }

        private void UpdateTableList()
        {
            comboBoxTable.Items.Clear();
            comboBoxTable.Items.AddRange(tables.ToArray());
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            if (comboBoxTable.SelectedItem != null)
            {
                string selectedTable = comboBoxTable.SelectedItem.ToString(); // Tabellenname holen
                FormTableEditor tableEditor = new FormTableEditor(selectedTable, sqlManager); // Reihenfolge korrigieren
                this.Hide();
                tableEditor.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Tabelle aus.");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (sqlManager == null || sqlManager.connection == null)
            {
                MessageBox.Show("Verbindung nicht verfügbar.");
                return;
            }

            string tableName = (this.Controls["txtTableName"] as TextBox)?.Text;
            if (string.IsNullOrWhiteSpace(tableName))
            {
                MessageBox.Show("Bitte einen Tabellennamen eingeben.");
                return;
            }

            try
            {
                sqlManager.CreateTable(tableName); // Tabelle erstellen
                MessageBox.Show($"Tabelle '{tableName}' erfolgreich erstellt.");
                LoadTables(); // Tabellenliste aktualisieren
                UpdateTableList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Erstellen der Tabelle: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxTable.SelectedItem == null) // Prüfen, ob eine Tabelle ausgewählt wurde
            {
                MessageBox.Show("Bitte wählen Sie eine Tabelle zum Löschen aus.");
                return; // Abbrechen, falls keine Auswahl getroffen wurde
            }

            string selectedTable = comboBoxTable.SelectedItem.ToString(); // Ausgewählte Tabelle abrufen

            DialogResult result = MessageBox.Show(
                $"Sind Sie sicher, dass Sie die Tabelle '{selectedTable}' löschen möchten? Alle Daten in der Tabelle gehen unwiderruflich verloren!",
                "Tabelle löschen",
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

                // SQL-Befehl, um die Tabelle zu löschen
                string query = $"DROP TABLE [{selectedTable}]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery(); // SQL-Befehl ausführen
                }

                // Entfernen der gelöschten Tabelle aus der Liste
                tables.Remove(selectedTable);
                MessageBox.Show($"Tabelle '{selectedTable}' wurde erfolgreich gelöscht.");

                UpdateTableList(); // Aktualisiere die Liste der verfügbaren Tabellen
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Löschen der Tabelle: {ex.Message}");
            }
            finally
            {
                connection.Close(); // Verbindung schließen
            }
        }
    }
}
