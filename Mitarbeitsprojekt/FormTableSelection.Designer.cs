using System.Windows.Forms;

namespace Mitarbeitsprojekt
{
    partial class FormTableSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTable = new System.Windows.Forms.Label();
            this.comboBoxTable = new System.Windows.Forms.ComboBox();
            this.btnUse = new System.Windows.Forms.Button();
            this.lblNewTable = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Location = new System.Drawing.Point(20, 20);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(34, 13);
            this.lblTable.TabIndex = 0;
            this.lblTable.Text = "Table";
            // 
            // comboBoxTable
            // 
            this.comboBoxTable.Location = new System.Drawing.Point(20, 50);
            this.comboBoxTable.Name = "comboBoxTable";
            this.comboBoxTable.Size = new System.Drawing.Size(200, 21);
            this.comboBoxTable.TabIndex = 1;
            // 
            // btnUse
            // 
            this.btnUse.Location = new System.Drawing.Point(240, 50);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(100, 25);
            this.btnUse.TabIndex = 2;
            this.btnUse.Text = "Use";
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // lblNewTable
            // 
            this.lblNewTable.AutoSize = true;
            this.lblNewTable.Location = new System.Drawing.Point(20, 108);
            this.lblNewTable.Name = "lblNewTable";
            this.lblNewTable.Size = new System.Drawing.Size(59, 13);
            this.lblNewTable.TabIndex = 3;
            this.lblNewTable.Text = "New Table";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(240, 131);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 25);
            this.btnNew.TabIndex = 5;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(240, 84);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 25);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(20, 134);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(200, 20);
            this.txtTableName.TabIndex = 0;
            // 
            // FormTableSelection
            // 
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.comboBoxTable);
            this.Controls.Add(this.btnUse);
            this.Controls.Add(this.lblNewTable);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormTableSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Table Management";
            this.Load += new System.EventHandler(this.FormTableSelection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTable;
        private ComboBox comboBoxTable;
        private Button btnUse;
        private Label lblNewTable;
        private Button btnNew;
        private Button btnDelete;
        private TextBox txtTableName;
    }
}