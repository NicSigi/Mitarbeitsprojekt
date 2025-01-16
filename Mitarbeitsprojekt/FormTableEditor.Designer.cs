    using System.Windows.Forms;

namespace Mitarbeitsprojekt
{
    partial class FormTableEditor
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.DataGridView dataGridViewColumns;
        private System.Windows.Forms.Label lblSelectTable;
        private System.Windows.Forms.Button btnAddColumn;
        private System.Windows.Forms.Button btnDeleteColumn;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.TextBox txtDataType;
        private System.Windows.Forms.Label lblColumnName;
        private System.Windows.Forms.Label lblDataType;
        private ComboBox cmbColumnType;
        private DataGridView dataGridViewTable;

        /// <summary>
        /// Bereinigt alle verwendeten Ressourcen.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initialisiert die Komponenten des Formulars.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.dataGridViewColumns = new System.Windows.Forms.DataGridView();
            this.lblSelectTable = new System.Windows.Forms.Label();
            this.btnAddColumn = new System.Windows.Forms.Button();
            this.btnDeleteColumn = new System.Windows.Forms.Button();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.txtDataType = new System.Windows.Forms.TextBox();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.lblDataType = new System.Windows.Forms.Label();
            this.cmbColumnType = new System.Windows.Forms.ComboBox();
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(20, 40);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(250, 21);
            this.comboBoxTables.TabIndex = 0;
            this.comboBoxTables.SelectedIndexChanged += new System.EventHandler(this.comboBoxTables_SelectedIndexChanged);
            // 
            // dataGridViewColumns
            // 
            this.dataGridViewColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewColumns.Location = new System.Drawing.Point(20, 80);
            this.dataGridViewColumns.Name = "dataGridViewColumns";
            this.dataGridViewColumns.RowHeadersWidth = 62;
            this.dataGridViewColumns.RowTemplate.Height = 28;
            this.dataGridViewColumns.Size = new System.Drawing.Size(500, 200);
            this.dataGridViewColumns.TabIndex = 1;
            // 
            // lblSelectTable
            // 
            this.lblSelectTable.AutoSize = true;
            this.lblSelectTable.Location = new System.Drawing.Point(20, 20);
            this.lblSelectTable.Name = "lblSelectTable";
            this.lblSelectTable.Size = new System.Drawing.Size(116, 20);
            this.lblSelectTable.TabIndex = 2;
            this.lblSelectTable.Text = "Tabelle wählen:";
            // 
            // btnAddColumn
            // 
            this.btnAddColumn.Location = new System.Drawing.Point(20, 360);
            this.btnAddColumn.Name = "btnAddColumn";
            this.btnAddColumn.Size = new System.Drawing.Size(120, 30);
            this.btnAddColumn.TabIndex = 3;
            this.btnAddColumn.Text = "Spalte hinzufügen";
            this.btnAddColumn.UseVisualStyleBackColor = true;
            this.btnAddColumn.Click += new System.EventHandler(this.btnAddColumn_Click);
            // 
            // btnDeleteColumn
            // 
            this.btnDeleteColumn.Location = new System.Drawing.Point(150, 360);
            this.btnDeleteColumn.Name = "btnDeleteColumn";
            this.btnDeleteColumn.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteColumn.TabIndex = 4;
            this.btnDeleteColumn.Text = "Spalte löschen";
            this.btnDeleteColumn.UseVisualStyleBackColor = true;
            this.btnDeleteColumn.Click += new System.EventHandler(this.btnDeleteColumn_Click);
            // 
            // txtColumnName
            // 
            this.txtColumnName.Location = new System.Drawing.Point(20, 320);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(120, 20);
            this.txtColumnName.TabIndex = 5;
            // 
            // txtDataType
            // 
            this.txtDataType.Location = new System.Drawing.Point(150, 320);
            this.txtDataType.Name = "txtDataType";
            this.txtDataType.Size = new System.Drawing.Size(120, 20);
            this.txtDataType.TabIndex = 6;
            // 
            // lblColumnName
            // 
            this.lblColumnName.AutoSize = true;
            this.lblColumnName.Location = new System.Drawing.Point(20, 300);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(93, 20);
            this.lblColumnName.TabIndex = 7;
            this.lblColumnName.Text = "Spaltenname";
            // 
            // lblDataType
            // 
            this.lblDataType.AutoSize = true;
            this.lblDataType.Location = new System.Drawing.Point(150, 300);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(72, 20);
            this.lblDataType.TabIndex = 8;
            this.lblDataType.Text = "Datentyp";
            // 
            // cmbColumnType
            // 
            this.cmbColumnType.FormattingEnabled = true;
            this.cmbColumnType.Items.AddRange(new object[] {
            "INT",
            "VARCHAR(50)",
            "DATE",
            "DECIMAL(10,2)"});
            this.cmbColumnType.Location = new System.Drawing.Point(150, 50);
            this.cmbColumnType.Name = "cmbColumnType";
            this.cmbColumnType.Size = new System.Drawing.Size(121, 21);
            this.cmbColumnType.TabIndex = 2;
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTable.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.Size = new System.Drawing.Size(760, 400);
            this.dataGridViewTable.TabIndex = 0;

            // 
            // FormTableEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.dataGridViewTable);
            this.Name = "FormTableEditor";
            this.Text = "Tabelleneditor";
            this.Load += new System.EventHandler(this.FormTableEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            this.ResumeLayout(false);

        }
    }
}