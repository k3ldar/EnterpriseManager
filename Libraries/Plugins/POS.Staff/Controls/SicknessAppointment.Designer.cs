namespace POS.Staff.Controls
{
    partial class SicknessAppointment
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
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerContact = new System.Windows.Forms.Label();
            this.lblTreatment = new System.Windows.Forms.Label();
            this.lblReschedule = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.rbCancel = new System.Windows.Forms.RadioButton();
            this.rbReschedule = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(3, 5);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(35, 13);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "label1";
            // 
            // lblCustomerContact
            // 
            this.lblCustomerContact.AutoSize = true;
            this.lblCustomerContact.Location = new System.Drawing.Point(3, 32);
            this.lblCustomerContact.Name = "lblCustomerContact";
            this.lblCustomerContact.Size = new System.Drawing.Size(35, 13);
            this.lblCustomerContact.TabIndex = 1;
            this.lblCustomerContact.Text = "label2";
            // 
            // lblTreatment
            // 
            this.lblTreatment.AutoSize = true;
            this.lblTreatment.Location = new System.Drawing.Point(3, 56);
            this.lblTreatment.Name = "lblTreatment";
            this.lblTreatment.Size = new System.Drawing.Size(35, 13);
            this.lblTreatment.TabIndex = 2;
            this.lblTreatment.Text = "label1";
            // 
            // lblReschedule
            // 
            this.lblReschedule.AutoSize = true;
            this.lblReschedule.Location = new System.Drawing.Point(3, 80);
            this.lblReschedule.Name = "lblReschedule";
            this.lblReschedule.Size = new System.Drawing.Size(35, 13);
            this.lblReschedule.TabIndex = 3;
            this.lblReschedule.Text = "label1";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(255, 112);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.Text = "button1";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // rbCancel
            // 
            this.rbCancel.AutoSize = true;
            this.rbCancel.Location = new System.Drawing.Point(6, 115);
            this.rbCancel.Name = "rbCancel";
            this.rbCancel.Size = new System.Drawing.Size(85, 17);
            this.rbCancel.TabIndex = 5;
            this.rbCancel.TabStop = true;
            this.rbCancel.Text = "radioButton1";
            this.rbCancel.UseVisualStyleBackColor = true;
            this.rbCancel.CheckedChanged += new System.EventHandler(this.rbCancel_CheckedChanged);
            // 
            // rbReschedule
            // 
            this.rbReschedule.AutoSize = true;
            this.rbReschedule.Checked = true;
            this.rbReschedule.Location = new System.Drawing.Point(112, 115);
            this.rbReschedule.Name = "rbReschedule";
            this.rbReschedule.Size = new System.Drawing.Size(85, 17);
            this.rbReschedule.TabIndex = 6;
            this.rbReschedule.TabStop = true;
            this.rbReschedule.Text = "radioButton2";
            this.rbReschedule.UseVisualStyleBackColor = true;
            this.rbReschedule.CheckedChanged += new System.EventHandler(this.rbReschedule_CheckedChanged);
            // 
            // SicknessAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbReschedule);
            this.Controls.Add(this.rbCancel);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lblReschedule);
            this.Controls.Add(this.lblTreatment);
            this.Controls.Add(this.lblCustomerContact);
            this.Controls.Add(this.lblCustomerName);
            this.Name = "SicknessAppointment";
            this.Size = new System.Drawing.Size(333, 141);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerContact;
        private System.Windows.Forms.Label lblTreatment;
        private System.Windows.Forms.Label lblReschedule;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.RadioButton rbCancel;
        private System.Windows.Forms.RadioButton rbReschedule;
    }
}
