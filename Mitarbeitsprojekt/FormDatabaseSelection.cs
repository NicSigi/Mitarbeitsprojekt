    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace Mitarbeitsprojekt
    {
            //(localdb)\MSSQLLocalDB
    public partial class FormDatabaseSelection : Form
        {
            private List<string> databases;
            private SqlConnection connection;
            private string connectionString;

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

                    // Datenbanken abrufen
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
            }

            private void BtnNew_Click(object sender, EventArgs e, TextBox txtNewDatabase)
            {
                string newDbName = txtNewDatabase.Text.Trim();
                if (!string.IsNullOrEmpty(newDbName) && !databases.Contains(newDbName))
                {
                    databases.Add(newDbName);
                    MessageBox.Show($"Datenbank '{newDbName}' erfolgreich hinzugefügt!");
                    UpdateDatabaseList();
                }
                else
                {
                    MessageBox.Show("Ungültiger oder doppelter Datenbankname.");
                }
            }

            private void BtnDelete_Click(object sender, EventArgs e, ComboBox cmbDatabases)
            {
                if (cmbDatabases.SelectedItem != null)
                {
                    string selectedDb = cmbDatabases.SelectedItem.ToString();
                    databases.Remove(selectedDb);
                    MessageBox.Show($"Datenbank '{selectedDb}' erfolgreich gelöscht!");
                    UpdateDatabaseList();
                }
                else
                {
                    MessageBox.Show("Bitte wählen Sie eine Datenbank zum Löschen aus.");
                }
            }

            private void BtnRename_Click(object sender, EventArgs e, ComboBox cmbDatabases, TextBox txtNewDatabase)
            {
                if (cmbDatabases.SelectedItem != null)
                {
                    string selectedDb = cmbDatabases.SelectedItem.ToString();
                    string newDbName = txtNewDatabase.Text.Trim();
                    if (!string.IsNullOrEmpty(newDbName) && !databases.Contains(newDbName))
                    {
                        int index = databases.IndexOf(selectedDb);
                        databases[index] = newDbName;
                        MessageBox.Show($"Datenbank '{selectedDb}' erfolgreich in '{newDbName}' umbenannt!");
                        UpdateDatabaseList();
                    }
                    else
                    {
                        MessageBox.Show("Ungültiger oder doppelter neuer Datenbankname.");
                    }
                }
                else
                {
                    MessageBox.Show("Bitte wählen Sie eine Datenbank zum Umbenennen aus.");
                }
            }

            private void BtnUse_Click(object sender, EventArgs e)
            {
            if (cmbDatabases.SelectedItem != null)
            {
                string selectedDb = cmbDatabases.SelectedItem.ToString();
                try
                {
                    var builder = new SqlConnectionStringBuilder(connection.ConnectionString)
                    {
                        InitialCatalog = selectedDb
                    };
                    connectionString = builder.ConnectionString;

                    connection = new SqlConnection(connectionString);
                    connection.Open();

                    FormTableSelection formTableSelection = new FormTableSelection(connection);
                    this.Hide();
                    formTableSelection.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Verbinden mit der Datenbank: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie eine Datenbank zum Verwenden aus.");
            }
        }

            private void cmbDatabases_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void FormDatabaseSelection_Load(object sender, EventArgs e)
            {

            }
        }
    }