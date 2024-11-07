using System.Drawing;
using System.Windows.Forms;

namespace Mitarbeitsprojekt
{
    partial class FormDatabaseSelection
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
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblNewDatabase = new System.Windows.Forms.Label();
            this.cmbDatabases = new System.Windows.Forms.ComboBox();
            this.txtNewDatabase = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnUse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDatabase
            // 
            this.lblDatabase.Location = new System.Drawing.Point(30, 30);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(100, 20);
            this.lblDatabase.TabIndex = 0;
            this.lblDatabase.Text = "Database";
            // 
            // lblNewDatabase
            // 
            this.lblNewDatabase.Location = new System.Drawing.Point(30, 70);
            this.lblNewDatabase.Name = "lblNewDatabase";
            this.lblNewDatabase.Size = new System.Drawing.Size(100, 20);
            this.lblNewDatabase.TabIndex = 2;
            this.lblNewDatabase.Text = "New Database";
            // 
            // cmbDatabases
            // 
            this.cmbDatabases.Location = new System.Drawing.Point(150, 30);
            this.cmbDatabases.Name = "cmbDatabases";
            this.cmbDatabases.Size = new System.Drawing.Size(200, 21);
            this.cmbDatabases.TabIndex = 1;
            this.cmbDatabases.SelectedIndexChanged += new System.EventHandler(this.cmbDatabases_SelectedIndexChanged);
            // 
            // txtNewDatabase
            // 
            this.txtNewDatabase.Location = new System.Drawing.Point(150, 70);
            this.txtNewDatabase.Name = "txtNewDatabase";
            this.txtNewDatabase.Size = new System.Drawing.Size(200, 20);
            this.txtNewDatabase.TabIndex = 3;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(30, 110);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(80, 30);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(120, 110);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(210, 110);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(80, 30);
            this.btnRename.TabIndex = 6;
            this.btnRename.Text = "Rename";
            // 
            // btnUse
            // 
            this.btnUse.Location = new System.Drawing.Point(300, 110);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(80, 30);
            this.btnUse.TabIndex = 7;
            this.btnUse.Text = "Use";
            this.btnUse.Click += new System.EventHandler(this.BtnUse_Click);
            // 
            // FormDatabaseSelection
            // 
            this.ClientSize = new System.Drawing.Size(382, 253);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.cmbDatabases);
            this.Controls.Add(this.lblNewDatabase);
            this.Controls.Add(this.txtNewDatabase);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnUse);
            this.Name = "FormDatabaseSelection";
            this.Text = "Database Selection";
            this.Load += new System.EventHandler(this.FormDatabaseSelection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Label lblDatabase;
        private Label lblNewDatabase;
        private ComboBox cmbDatabases;
        private TextBox txtNewDatabase;
        private Button btnNew;
        private Button btnDelete;
        private Button btnRename;
        private Button btnUse;
    }
}