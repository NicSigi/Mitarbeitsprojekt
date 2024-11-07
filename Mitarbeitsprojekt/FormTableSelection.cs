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
    public partial class FormTableSelection : Form
    {
        private SqlConnection connection;
        private List<string> tables;

        public FormTableSelection(SqlConnection conn)
        {
            InitializeComponent();
            connection = conn;
            tables = new List<string>();
        }

        private void FormTableSelection_Load(object sender, EventArgs e)
        {
            LoadTables();
            UpdateTableList();
        }

        private void LoadTables()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                // Tabellen abrufen
                DataTable tablesTable = connection.GetSchema("Tables");
                tables.Clear();

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
        }

        private void UpdateTableList()
        {
            comboBoxTable.Items.Clear();
            comboBoxTable.Items.AddRange(tables.ToArray());
        }

        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}