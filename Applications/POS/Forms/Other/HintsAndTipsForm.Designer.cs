namespace PointOfSale.Forms.Other
{
    partial class HintsAndTipsForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.cbShowAtStart = new System.Windows.Forms.CheckBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.hintsData = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.hintsData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(13, 13);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(238, 45);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Did You Know?";
            // 
            // cbShowAtStart
            // 
            this.cbShowAtStart.AutoSize = true;
            this.cbShowAtStart.Location = new System.Drawing.Point(21, 286);
            this.cbShowAtStart.Name = "cbShowAtStart";
            this.cbShowAtStart.Size = new System.Drawing.Size(102, 17);
            this.cbShowAtStart.TabIndex = 2;
            this.cbShowAtStart.Text = "Show at Startup";
            this.cbShowAtStart.UseVisualStyleBackColor = true;
            this.cbShowAtStart.CheckedChanged += new System.EventHandler(this.cbShowAtStart_CheckedChanged);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(392, 282);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(473, 282);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lblHint
            // 
            this.lblHint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.Location = new System.Drawing.Point(21, 62);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(527, 217);
            this.lblHint.TabIndex = 1;
            this.lblHint.Text = "label2";
            // 
            // hintsData
            // 
            this.hintsData.DataSetName = "HintsDataSet";
            // 
            // HintsAndTipsForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 317);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.cbShowAtStart);
            this.Controls.Add(this.lblHeader);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HintsAndTipsForm";
            this.SaveState = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hints And Tips";
            this.Load += new System.EventHandler(this.HintsAndTipsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hintsData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.CheckBox cbShowAtStart;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHint;
        private System.Data.DataSet hintsData;
    }
}