namespace POS.Customers.Controls.Wizards.Export
{
    partial class Step6
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSelectFileDesc = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.rbCSVFile = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.cbCloseAfterSave = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblSelectFileDesc
            // 
            this.lblSelectFileDesc.AutoSize = true;
            this.lblSelectFileDesc.Location = new System.Drawing.Point(4, 4);
            this.lblSelectFileDesc.Name = "lblSelectFileDesc";
            this.lblSelectFileDesc.Size = new System.Drawing.Size(209, 13);
            this.lblSelectFileDesc.TabIndex = 0;
            this.lblSelectFileDesc.Text = "Select the file where the data will be saved";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(7, 21);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(429, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(442, 19);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(103, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "CSV File|*.csv|XML File|*.xml";
            // 
            // rbCSVFile
            // 
            this.rbCSVFile.AutoSize = true;
            this.rbCSVFile.Checked = true;
            this.rbCSVFile.Location = new System.Drawing.Point(7, 72);
            this.rbCSVFile.Name = "rbCSVFile";
            this.rbCSVFile.Size = new System.Drawing.Size(65, 17);
            this.rbCSVFile.TabIndex = 3;
            this.rbCSVFile.TabStop = true;
            this.rbCSVFile.Text = "CSV File";
            this.rbCSVFile.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(7, 170);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "button1";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(7, 200);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(538, 23);
            this.pbProgress.TabIndex = 5;
            // 
            // cbCloseAfterSave
            // 
            this.cbCloseAfterSave.AutoSize = true;
            this.cbCloseAfterSave.Location = new System.Drawing.Point(7, 324);
            this.cbCloseAfterSave.Name = "cbCloseAfterSave";
            this.cbCloseAfterSave.Size = new System.Drawing.Size(105, 17);
            this.cbCloseAfterSave.TabIndex = 6;
            this.cbCloseAfterSave.Text = "Close After Save";
            this.cbCloseAfterSave.UseVisualStyleBackColor = true;
            // 
            // Step6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbCloseAfterSave);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rbCSVFile);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblSelectFileDesc);
            this.Name = "Step6";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectFileDesc;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton rbCSVFile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.CheckBox cbCloseAfterSave;
    }
}
