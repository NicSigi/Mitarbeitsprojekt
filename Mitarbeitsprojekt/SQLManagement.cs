using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mitarbeitsprojekt
{
    public class SQLManagement
    {
        public SqlConnection connection; // Verbindung zur Datenbank

        // Konstruktor: Initialisiert die SQL-Verbindung
        public SQLManagement()
        {
            connection = new SqlConnection(); // Leere Verbindung erstellen
        }

        // Setzt die Verbindungszeichenfolge
        public void SetConnection(string connectionString)
        {
            connection.ConnectionString = connectionString; // Verbindung konfigurieren
        }

        // Gibt die aktuelle SQL-Verbindung zurück
        public SqlConnection GetConnection()
        {
            return connection; // Verbindung zurückgeben
        }

        // Testet die Verbindung zur Datenbank
        public bool TestConnection()
        {
            try
            {
                connection.Open(); // Verbindung öffnen
                return true; // Verbindung erfolgreich
            }
            catch
            {
                return false; // Fehler bei der Verbindung
            }
            finally
            {
                connection.Close(); // Verbindung immer schließen
            }
        }

        // Ruft die Liste der Tabellen aus der Datenbank ab
        public List<string> GetTables()
        {
            List<string> tables = new List<string>(); // Liste für Tabellennamen

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open(); // Verbindung öffnen, falls geschlossen

                DataTable tablesTable = connection.GetSchema("Tables"); // Tabellen abrufen
                foreach (DataRow row in tablesTable.Rows) // Zeilen durchlaufen
                {
                    string tableName = row["TABLE_NAME"].ToString(); // Tabellenname abrufen
                    tables.Add(tableName); // Zur Liste hinzufügen
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Tabellen: {ex.Message}"); // Fehler anzeigen
            }
            finally
            {
                connection.Close(); // Verbindung schließen
            }

            return tables; // Tabellenliste zurückgeben
        }
    }
}
