using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mitarbeitsprojekt
{
    public partial class FormTableSelection : Form
    {
        private SQLManagement sqlManager;
        private List<string> tables;
        private SqlConnection connection;

        public FormTableSelection(SQLManagement manager)
        {
            InitializeComponent();
            sqlManager = manager;
            tables = new List<string>();
        }

        public FormTableSelection(SqlConnection connection)
        {
            this.connection = connection;
        }

        private void FormTableSelection_Load(object sender, EventArgs e)
        {
            LoadTables();
            UpdateTableList();
        }

        private void LoadTables()
        {
            tables = sqlManager.GetTables();
        }

        private void UpdateTableList()
        {
            comboBoxTable.Items.Clear();
            comboBoxTable.Items.AddRange(tables.ToArray());
        }
        private void comboBoxTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormTableSelection_Load_1(object sender, EventArgs e)
        {
            LoadTables();
        }

    }
}
