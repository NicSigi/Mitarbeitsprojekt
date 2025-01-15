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
        public void CreateTable(string tableName)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = $@"
                CREATE TABLE {tableName} (
                ID INT IDENTITY(1,1) PRIMARY KEY,
                Name NVARCHAR(50),
                CreatedDate DATETIME DEFAULT GETDATE()
                );";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fehler beim Erstellen der Tabelle: {ex.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        public DataTable GetColumns(string tableName)
        {
            DataTable columns = new DataTable();

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = $"SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.Fill(columns);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fehler beim Abrufen der Spalten: {ex.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return columns;
        }
        public void AddColumn(string tableName, string columnName, string columnType)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = $"ALTER TABLE {tableName} ADD {columnName} {columnType};";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Hinzufügen der Spalte: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }


        public void DeleteColumn(string tableName, string columnName)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = $"ALTER TABLE {tableName} DROP COLUMN {columnName};";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Löschen der Spalte: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
        public DataTable GetTableData(string tableName)
        {
            DataTable tableData = new DataTable();

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = $"SELECT * FROM {tableName};";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(tableData); // Daten in das DataTable-Objekt laden
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Abrufen der Tabellendaten: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return tableData;
        }



    }
}
