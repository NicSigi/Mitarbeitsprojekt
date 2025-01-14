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
        

    }
}
