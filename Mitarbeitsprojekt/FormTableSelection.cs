using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mitarbeitsprojekt
{
    public partial class FormTableSelection : Form
    {
        private SQLManagement sqlManager; // Instanz für SQL-Operationen
        private List<string> tables; // Liste der Tabellen im aktuellen Schema
        private SqlConnection connection; // Verbindung zur Datenbank

        // Konstruktor mit SQLManagement-Objekt
        public FormTableSelection(SQLManagement manager)
        {
            InitializeComponent(); // UI-Initialisierung
            sqlManager = manager; // SQLManager zuweisen
            tables = new List<string>(); // Tabelle-Liste initialisieren
        }

        // Konstruktor mit SqlConnection-Objekt
        public FormTableSelection(SqlConnection connection)
        {
            this.connection = connection; // Verbindung setzen
        }

        // Wird beim Laden des Formulars ausgeführt
        private void FormTableSelection_Load(object sender, EventArgs e)
        {
            LoadTables(); // Tabellen laden
            UpdateTableList(); // Tabelle-Liste aktualisieren
        }

        // Tabellen aus der Datenbank laden
        private void LoadTables()
        {
            tables = sqlManager.GetTables(); // Tabellen über SQLManager abrufen
        }

        // ComboBox mit Tabellennamen füllen
        private void UpdateTableList()
        {
            comboBoxTable.Items.Clear(); // ComboBox leeren
            comboBoxTable.Items.AddRange(tables.ToArray()); // Tabellen hinzufügen
        }

        // Wird ausgelöst, wenn die Auswahl in der ComboBox geändert wird
        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aktuell leer, hier kann Logik ergänzt werden
        }

        // Zusätzlicher Load-Handler, sollte nicht benötigt werden
        private void FormTableSelection_Load_1(object sender, EventArgs e)
        {
            LoadTables(); // Tabellen laden (wie im ersten Load-Handler)
        }
    }
}
