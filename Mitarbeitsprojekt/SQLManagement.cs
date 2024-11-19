using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mitarbeitsprojekt
{
    public class SQLManagement
    {
        public SqlConnection connection;

        public SQLManagement()
        {
            connection = new SqlConnection();
        }

        public void SetConnection(string connectionString)
        {
            connection.ConnectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }

        public bool TestConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<string> GetTables()
        {
            List<string> tables = new List<string>();

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                DataTable tablesTable = connection.GetSchema("Tables");
                foreach (DataRow row in tablesTable.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    tables.Add(tableName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Tabellen: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return tables;
        }
    }
}
