namespace POS.Customers.Controls.Wizards.Export
{
    partial class Step4
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
            this.lblColumnsDesc = new System.Windows.Forms.Label();
            this.lstAvailable = new System.Windows.Forms.ListBox();
            this.lstSelected = new System.Windows.Forms.ListBox();
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblColumnsDesc
            // 
            this.lblColumnsDesc.AutoSize = true;
            this.lblColumnsDesc.Location = new System.Drawing.Point(4, 4);
            this.lblColumnsDesc.Name = "lblColumnsDesc";
            this.lblColumnsDesc.Size = new System.Drawing.Size(403, 13);
            this.lblColumnsDesc.TabIndex = 0;
            this.lblColumnsDesc.Text = "Select the columns you wish to export, they will be exported using the order sele" +
    "cted";
            // 
            // lstAvailable
            // 
            this.lstAvailable.FormattingEnabled = true;
            this.lstAvailable.Location = new System.Drawing.Point(7, 49);
            this.lstAvailable.Name = "lstAvailable";
            this.lstAvailable.Size = new System.Drawing.Size(234, 277);
            this.lstAvailable.TabIndex = 2;
            this.lstAvailable.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstAvailable_Format);
            this.lstAvailable.DoubleClick += new System.EventHandler(this.btnAssign_Click);
            // 
            // lstSelected
            // 
            this.lstSelected.FormattingEnabled = true;
            this.lstSelected.Location = new System.Drawing.Point(329, 49);
            this.lstSelected.Name = "lstSelected";
            this.lstSelected.Size = new System.Drawing.Size(222, 277);
            this.lstSelected.TabIndex = 6;
            this.lstSelected.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lstAvailable_Format);
            this.lstSelected.DoubleClick += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblAvailable
            // 
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Location = new System.Drawing.Point(7, 30);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(35, 13);
            this.lblAvailable.TabIndex = 1;
            this.lblAvailable.Text = "label2";
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(326, 30);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(35, 13);
            this.lblSelected.TabIndex = 5;
            this.lblSelected.Text = "label3";
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(248, 123);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssign.TabIndex = 3;
            this.btnAssign.Text = "button1";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(248, 163);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "button2";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Step4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblAvailable);
            this.Controls.Add(this.lstSelected);
            this.Controls.Add(this.lstAvailable);
            this.Controls.Add(this.lblColumnsDesc);
            this.Name = "Step4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblColumnsDesc;
        private System.Windows.Forms.ListBox lstAvailable;
        private System.Windows.Forms.ListBox lstSelected;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnRemove;
    }
}
