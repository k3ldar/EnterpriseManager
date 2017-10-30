namespace POS.Staff.Controls.Wizards.Commission.BonusPayments
{
    partial class Step2
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
            this.btnInvertSelection = new System.Windows.Forms.Button();
            this.btnUnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.lblSelectUsers = new System.Windows.Forms.Label();
            this.clbStaff = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // btnInvertSelection
            // 
            this.btnInvertSelection.Location = new System.Drawing.Point(447, 79);
            this.btnInvertSelection.Name = "btnInvertSelection";
            this.btnInvertSelection.Size = new System.Drawing.Size(104, 23);
            this.btnInvertSelection.TabIndex = 4;
            this.btnInvertSelection.Text = "button3";
            this.btnInvertSelection.UseVisualStyleBackColor = true;
            this.btnInvertSelection.Click += new System.EventHandler(this.btnInvertSelection_Click);
            // 
            // btnUnSelectAll
            // 
            this.btnUnSelectAll.Location = new System.Drawing.Point(447, 49);
            this.btnUnSelectAll.Name = "btnUnSelectAll";
            this.btnUnSelectAll.Size = new System.Drawing.Size(104, 23);
            this.btnUnSelectAll.TabIndex = 3;
            this.btnUnSelectAll.Text = "button2";
            this.btnUnSelectAll.UseVisualStyleBackColor = true;
            this.btnUnSelectAll.Click += new System.EventHandler(this.btnUnSelectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(446, 19);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(105, 23);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "button1";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // lblSelectUsers
            // 
            this.lblSelectUsers.AutoSize = true;
            this.lblSelectUsers.Location = new System.Drawing.Point(3, 0);
            this.lblSelectUsers.Name = "lblSelectUsers";
            this.lblSelectUsers.Size = new System.Drawing.Size(35, 13);
            this.lblSelectUsers.TabIndex = 0;
            this.lblSelectUsers.Text = "label1";
            // 
            // clbStaff
            // 
            this.clbStaff.CheckOnClick = true;
            this.clbStaff.FormattingEnabled = true;
            this.clbStaff.Location = new System.Drawing.Point(3, 19);
            this.clbStaff.MultiColumn = true;
            this.clbStaff.Name = "clbStaff";
            this.clbStaff.Size = new System.Drawing.Size(437, 319);
            this.clbStaff.TabIndex = 1;
            this.clbStaff.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.clbStaff_Format);
            // 
            // Step2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnInvertSelection);
            this.Controls.Add(this.btnUnSelectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.lblSelectUsers);
            this.Controls.Add(this.clbStaff);
            this.Name = "Step2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInvertSelection;
        private System.Windows.Forms.Button btnUnSelectAll;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Label lblSelectUsers;
        private System.Windows.Forms.CheckedListBox clbStaff;
    }
}
