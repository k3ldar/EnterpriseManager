namespace PointOfSale.Controls.Settings.Admin
{
    partial class Plugins
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
            this.cbPromptBeforeLoadNew = new System.Windows.Forms.CheckBox();
            this.lvPluginModules = new SharedControls.Classes.ListViewEx();
            this.lvPluginsColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPluginsColumnLoad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPluginsColumnDisabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvPluginsColumnVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbAutoLoadNewModules = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbPromptBeforeLoadNew
            // 
            this.cbPromptBeforeLoadNew.AutoSize = true;
            this.cbPromptBeforeLoadNew.Location = new System.Drawing.Point(4, 4);
            this.cbPromptBeforeLoadNew.Name = "cbPromptBeforeLoadNew";
            this.cbPromptBeforeLoadNew.Size = new System.Drawing.Size(189, 17);
            this.cbPromptBeforeLoadNew.TabIndex = 0;
            this.cbPromptBeforeLoadNew.Text = "Prompt before loading new Plugins";
            this.cbPromptBeforeLoadNew.UseVisualStyleBackColor = true;
            this.cbPromptBeforeLoadNew.Visible = false;
            // 
            // lvPluginModules
            // 
            this.lvPluginModules.AllowColumnReorder = true;
            this.lvPluginModules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvPluginsColumnName,
            this.lvPluginsColumnLoad,
            this.lvPluginsColumnDisabled,
            this.lvPluginsColumnVersion});
            this.lvPluginModules.FullRowSelect = true;
            this.lvPluginModules.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPluginModules.HideSelection = false;
            this.lvPluginModules.Location = new System.Drawing.Point(0, 4);
            this.lvPluginModules.MultiSelect = false;
            this.lvPluginModules.Name = "lvPluginModules";
            this.lvPluginModules.OwnerDraw = true;
            this.lvPluginModules.SaveName = "";
            this.lvPluginModules.ShowToolTip = false;
            this.lvPluginModules.Size = new System.Drawing.Size(457, 336);
            this.lvPluginModules.TabIndex = 2;
            this.lvPluginModules.UseCompatibleStateImageBehavior = false;
            this.lvPluginModules.View = System.Windows.Forms.View.Details;
            this.lvPluginModules.DoubleClick += new System.EventHandler(this.lvPluginModules_DoubleClick);
            // 
            // lvPluginsColumnName
            // 
            this.lvPluginsColumnName.Text = "Name";
            this.lvPluginsColumnName.Width = 180;
            // 
            // lvPluginsColumnLoad
            // 
            this.lvPluginsColumnLoad.Text = "Load";
            this.lvPluginsColumnLoad.Width = 90;
            // 
            // lvPluginsColumnDisabled
            // 
            this.lvPluginsColumnDisabled.Text = "Disabled";
            this.lvPluginsColumnDisabled.Width = 90;
            // 
            // lvPluginsColumnVersion
            // 
            this.lvPluginsColumnVersion.Text = "Version";
            this.lvPluginsColumnVersion.Width = 110;
            // 
            // cbAutoLoadNewModules
            // 
            this.cbAutoLoadNewModules.AutoSize = true;
            this.cbAutoLoadNewModules.Location = new System.Drawing.Point(4, 26);
            this.cbAutoLoadNewModules.Name = "cbAutoLoadNewModules";
            this.cbAutoLoadNewModules.Size = new System.Drawing.Size(80, 17);
            this.cbAutoLoadNewModules.TabIndex = 1;
            this.cbAutoLoadNewModules.Text = "checkBox1";
            this.cbAutoLoadNewModules.UseVisualStyleBackColor = true;
            this.cbAutoLoadNewModules.Visible = false;
            // 
            // Plugins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbAutoLoadNewModules);
            this.Controls.Add(this.lvPluginModules);
            this.Controls.Add(this.cbPromptBeforeLoadNew);
            this.Name = "Plugins";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbPromptBeforeLoadNew;
        private SharedControls.Classes.ListViewEx lvPluginModules;
        private System.Windows.Forms.ColumnHeader lvPluginsColumnName;
        private System.Windows.Forms.ColumnHeader lvPluginsColumnLoad;
        private System.Windows.Forms.ColumnHeader lvPluginsColumnDisabled;
        private System.Windows.Forms.ColumnHeader lvPluginsColumnVersion;
        private System.Windows.Forms.CheckBox cbAutoLoadNewModules;
    }
}
