using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mitarbeitsprojekt
{
    public partial class FormTableEditor : Form
    {
        private SQLManagement sqlManager; // SQL-Verwaltung
        private List<string> tables; // Tabellenliste
        private string selectedTable; // Ausgewählte Tabelle

        public FormTableEditor(SQLManagement manager)
        {
            InitializeComponent();
            sqlManager = manager;
            tables = new List<string>();
        }

        private void FormTableEditor_Load(object sender, EventArgs e)
        {
            LoadTables();
            UpdateTableList();
        }

        private void LoadTables()
        {
            // Tabellen laden
            try
            {
                tables = sqlManager.GetTables();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Tabellen: {ex.Message}");
            }
        }

        private void UpdateTableList()
        {
            // Tabellen in ComboBox einfügen
            comboBoxTables.Items.Clear();
            comboBoxTables.Items.AddRange(tables.ToArray());
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ausgewählte Tabelle
            selectedTable = comboBoxTables.SelectedItem.ToString();
            LoadColumns();
        }

        private void LoadColumns()
        {
            // Spalten der Tabelle laden
            try
            {
                if (string.IsNullOrEmpty(selectedTable)) return;

                DataTable columnsTable = sqlManager.GetColumns(selectedTable); // Spalten abrufen
                dataGridViewColumns.DataSource = columnsTable; // In DataGridView anzeigen
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Spalten: {ex.Message}");
            }
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            // Neue Spalte hinzufügen
            try
            {
                string columnName = txtColumnName.Text;
                string dataType = txtDataType.Text;

                if (string.IsNullOrEmpty(columnName) || string.IsNullOrEmpty(dataType))
                {
                    MessageBox.Show("Bitte Spaltennamen und Datentyp eingeben.");
                    return;
                }

                sqlManager.AddColumn(selectedTable, columnName, dataType);
                MessageBox.Show($"Spalte '{columnName}' erfolgreich hinzugefügt.");
                LoadColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Hinzufügen der Spalte: {ex.Message}");
            }
        }

        private void btnDeleteColumn_Click(object sender, EventArgs e)
        {
            // Spalte löschen
            try
            {
                if (dataGridViewColumns.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Bitte eine Spalte auswählen.");
                    return;
                }

                string columnName = dataGridViewColumns.SelectedRows[0].Cells["COLUMN_NAME"].Value.ToString();
                sqlManager.DeleteColumn(selectedTable, columnName);
                MessageBox.Show($"Spalte '{columnName}' erfolgreich gelöscht.");
                LoadColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Löschen der Spalte: {ex.Message}");
            }
        }
    }
}
