using System;
using System.Data;
using System.Windows.Forms;

namespace Mitarbeitsprojekt
{
    public partial class FormTableEditor : Form
    {
        private string selectedTableName;
        private SQLManagement sqlManager;
        private string tableName;
        private string selectedTable;

        public FormTableEditor(SQLManagement manager, string selectedTable)
        {
            InitializeComponent();
            this.selectedTableName = tableName; // Tabellenname speichern
            this.sqlManager = sqlManager; // SQL-Management-Instanz speichern
        }

        public FormTableEditor(string selectedTable, SQLManagement sqlManager)
        {
            this.selectedTable = selectedTable;
            this.sqlManager = sqlManager;
        }

        private void FormTableEditor_Load(object sender, EventArgs e)
        {
            LoadTableData(); // Tabellendaten beim Laden des Formulars abrufen
        }

        private void LoadTableData()
        {
            try
            {
                // Tabellendaten über SQLManagement abrufen
                DataTable tableData = sqlManager.GetTableData(tableName);

                // Daten im DataGridView anzeigen
                dataGridViewTable.DataSource = tableData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Tabellendaten: {ex.Message}");
            }
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            // Neue Spalte zur Tabelle hinzufügen
            try
            {
                string columnName = txtColumnName.Text;
                string columnType = cmbColumnType.Text;

                if (string.IsNullOrWhiteSpace(columnName) || string.IsNullOrWhiteSpace(columnType))
                {
                    MessageBox.Show("Bitte geben Sie einen gültigen Spaltennamen und Datentyp ein.");
                    return;
                }

                sqlManager.AddColumn(tableName, columnName, columnType); // Spalte hinzufügen
                MessageBox.Show($"Spalte '{columnName}' erfolgreich hinzugefügt.");
                LoadTableData(); // Tabelle neu laden
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Hinzufügen der Spalte: {ex.Message}");
            }
        }

        private void btnDeleteColumn_Click(object sender, EventArgs e)
        {
            // Spalte aus der Tabelle entfernen
            try
            {
                string columnName = txtColumnName.Text;

                if (string.IsNullOrWhiteSpace(columnName))
                {
                    MessageBox.Show("Bitte geben Sie einen gültigen Spaltennamen ein.");
                    return;
                }

                sqlManager.DeleteColumn(tableName, columnName); // Spalte entfernen
                MessageBox.Show($"Spalte '{columnName}' erfolgreich gelöscht.");
                LoadTableData(); // Tabelle neu laden
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Löschen der Spalte: {ex.Message}");
            }
        }
        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Logik für die Auswahländerung kann hier später hinzugefügt werden
        }

        private void FormTableEditor_Load_1(object sender, EventArgs e)
        {

        }
    }
}
