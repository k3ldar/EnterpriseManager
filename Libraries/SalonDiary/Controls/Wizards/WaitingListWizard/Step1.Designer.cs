namespace SalonDiary.Controls.Wizards.WaitingListWizard
{
    partial class Step1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Step1));
            this.lvCurrentWaitList = new SharedControls.Classes.ListViewEx();
            this.lstUsers = new System.Windows.Forms.ImageList(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvCurrentWaitList
            // 
            this.lvCurrentWaitList.HideSelection = false;
            this.lvCurrentWaitList.LargeImageList = this.lstUsers;
            this.lvCurrentWaitList.Location = new System.Drawing.Point(4, 29);
            this.lvCurrentWaitList.Name = "lvCurrentWaitList";
            this.lvCurrentWaitList.Size = new System.Drawing.Size(464, 324);
            this.lvCurrentWaitList.TabIndex = 0;
            this.lvCurrentWaitList.UseCompatibleStateImageBehavior = false;
            this.lvCurrentWaitList.Click += new System.EventHandler(this.lvCurrentWaitList_Click);
            this.lvCurrentWaitList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvCurrentWaitList_MouseDoubleClick);
            this.lvCurrentWaitList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvCurrentWaitList_MouseUp);
            // 
            // lstUsers
            // 
            this.lstUsers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lstUsers.ImageStream")));
            this.lstUsers.TransparentColor = System.Drawing.Color.Transparent;
            this.lstUsers.Images.SetKeyName(0, "user_32.png");
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(4, 4);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(234, 13);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Select a person from the waiting list, or click add";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(474, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(475, 59);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Step1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lvCurrentWaitList);
            this.Name = "Step1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharedControls.Classes.ListViewEx lvCurrentWaitList;
        private System.Windows.Forms.ImageList lstUsers;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
    }
}
