namespace POS.StockControl.Controls
{
    partial class StockControlAutoReorder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockControlAutoReorder));
            this.cbAllowAutoReOrder = new System.Windows.Forms.CheckBox();
            this.gbUser = new System.Windows.Forms.GroupBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserDescription = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.gbUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAllowAutoReOrder
            // 
            this.cbAllowAutoReOrder.AutoSize = true;
            this.cbAllowAutoReOrder.Location = new System.Drawing.Point(4, 4);
            this.cbAllowAutoReOrder.Name = "cbAllowAutoReOrder";
            this.cbAllowAutoReOrder.Size = new System.Drawing.Size(119, 17);
            this.cbAllowAutoReOrder.TabIndex = 0;
            this.cbAllowAutoReOrder.Text = "Allow Auto ReOrder";
            this.cbAllowAutoReOrder.UseVisualStyleBackColor = true;
            this.cbAllowAutoReOrder.CheckedChanged += new System.EventHandler(this.cbAllowAutoReOrder_CheckedChanged);
            // 
            // gbUser
            // 
            this.gbUser.Controls.Add(this.txtPassword);
            this.gbUser.Controls.Add(this.lblPassword);
            this.gbUser.Controls.Add(this.txtUserName);
            this.gbUser.Controls.Add(this.lblUserDescription);
            this.gbUser.Location = new System.Drawing.Point(3, 46);
            this.gbUser.Name = "gbUser";
            this.gbUser.Size = new System.Drawing.Size(453, 114);
            this.gbUser.TabIndex = 1;
            this.gbUser.TabStop = false;
            this.gbUser.Text = "User";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(10, 37);
            this.txtUserName.MaxLength = 150;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(437, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // lblUserDescription
            // 
            this.lblUserDescription.AutoSize = true;
            this.lblUserDescription.Location = new System.Drawing.Point(7, 20);
            this.lblUserDescription.Name = "lblUserDescription";
            this.lblUserDescription.Size = new System.Drawing.Size(35, 13);
            this.lblUserDescription.TabIndex = 0;
            this.lblUserDescription.Text = "label1";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(10, 64);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(10, 81);
            this.txtPassword.MaxLength = 100;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(437, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // StockControlAutoReorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbUser);
            this.Controls.Add(this.cbAllowAutoReOrder);
            this.Name = "StockControlAutoReorder";
            this.gbUser.ResumeLayout(false);
            this.gbUser.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbAllowAutoReOrder;
        private System.Windows.Forms.GroupBox gbUser;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserDescription;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
    }
}
