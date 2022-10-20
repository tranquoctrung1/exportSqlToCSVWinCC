namespace ExportSqlToCSV
{
    partial class Form1
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
            this.grv = new System.Windows.Forms.DataGridView();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.txtTableName = new System.Windows.Forms.Label();
            this.btnNextTable = new System.Windows.Forms.Button();
            this.txtTableIndex = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            this.SuspendLayout();
            // 
            // grv
            // 
            this.grv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grv.Location = new System.Drawing.Point(12, 75);
            this.grv.Name = "grv";
            this.grv.Size = new System.Drawing.Size(776, 346);
            this.grv.TabIndex = 0;
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Location = new System.Drawing.Point(449, 28);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(164, 23);
            this.btnExportCSV.TabIndex = 1;
            this.btnExportCSV.Text = "ExportCVS";
            this.btnExportCSV.UseVisualStyleBackColor = true;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // txtTableName
            // 
            this.txtTableName.AutoSize = true;
            this.txtTableName.Location = new System.Drawing.Point(13, 28);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(0, 13);
            this.txtTableName.TabIndex = 2;
            // 
            // btnNextTable
            // 
            this.btnNextTable.Location = new System.Drawing.Point(201, 28);
            this.btnNextTable.Name = "btnNextTable";
            this.btnNextTable.Size = new System.Drawing.Size(75, 23);
            this.btnNextTable.TabIndex = 3;
            this.btnNextTable.Text = "Next Table";
            this.btnNextTable.UseVisualStyleBackColor = true;
            this.btnNextTable.Click += new System.EventHandler(this.btnNextTable_Click);
            // 
            // txtTableIndex
            // 
            this.txtTableIndex.AutoSize = true;
            this.txtTableIndex.Location = new System.Drawing.Point(103, 28);
            this.txtTableIndex.Name = "txtTableIndex";
            this.txtTableIndex.Size = new System.Drawing.Size(0, 13);
            this.txtTableIndex.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtTableIndex);
            this.Controls.Add(this.btnNextTable);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.btnExportCSV);
            this.Controls.Add(this.grv);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grv;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.Label txtTableName;
        private System.Windows.Forms.Button btnNextTable;
        private System.Windows.Forms.Label txtTableIndex;
    }
}

