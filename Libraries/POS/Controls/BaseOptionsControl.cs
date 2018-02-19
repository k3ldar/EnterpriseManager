/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2018 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: BaseOptionsControl.cs
 *
 *  Purpose:  Base Options Control
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

using Languages;

#pragma warning disable IDE1006

namespace POS.Base.Controls
{
    public class BaseOptionsControl : BaseTabControl
    {
        #region Constructors

        public BaseOptionsControl()
        {
            InitializeComponent();

            toolStripMainAdd.Image = POS.Base.Icons.AddIcon();
            toolStripMainDelete.Image = POS.Base.Icons.DeleteIcon();
            toolStripMainEdit.Image = POS.Base.Icons.EditIcon();
            toolStripMainRefresh.Image = POS.Base.Icons.RefreshIcon();
            toolStripMainSave.Image = POS.Base.Icons.SaveIcon();

            toolStripMainRefresh.Enabled = false;
            toolStripMainEdit.Enabled = false;

            AllowDelete = true;
            AllowAddNew = true;
        }

        #endregion Constructors

        #region Designer

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseOptionsControl));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripMainAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripMainSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMainRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(591, 343);
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMainAdd,
            this.toolStripMainDelete,
            this.toolStripMainEdit,
            this.toolStripMainSave,
            this.toolStripSeparator1,
            this.toolStripMainRefresh});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripMain.Size = new System.Drawing.Size(665, 39);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolStripMainAdd
            // 
            this.toolStripMainAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainAdd.Image")));
            this.toolStripMainAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainAdd.Name = "toolStripMainAdd";
            this.toolStripMainAdd.Size = new System.Drawing.Size(24, 24);
            this.toolStripMainAdd.Click += new System.EventHandler(this.toolStripMainAdd_Click);
            // 
            // toolStripMainDelete
            // 
            this.toolStripMainDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainDelete.Image")));
            this.toolStripMainDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainDelete.Name = "toolStripMainDelete";
            this.toolStripMainDelete.Size = new System.Drawing.Size(24, 24);
            this.toolStripMainDelete.Click += new System.EventHandler(this.toolStripMainDelete_Click);
            // 
            // toolStripMainEdit
            // 
            this.toolStripMainEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainEdit.Image")));
            this.toolStripMainEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainEdit.Name = "toolStripMainEdit";
            this.toolStripMainEdit.Size = new System.Drawing.Size(24, 24);
            this.toolStripMainEdit.Click += new System.EventHandler(this.toolStripMainEdit_Click);
            // 
            // toolStripMainSave
            // 
            this.toolStripMainSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainSave.Image")));
            this.toolStripMainSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainSave.Name = "toolStripMainSave";
            this.toolStripMainSave.Size = new System.Drawing.Size(24, 24);
            this.toolStripMainSave.Text = "toolStripButton1";
            this.toolStripMainSave.Click += new System.EventHandler(this.toolStripMainSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripMainRefresh
            // 
            this.toolStripMainRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripMainRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMainRefresh.Image")));
            this.toolStripMainRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMainRefresh.Name = "toolStripMainRefresh";
            this.toolStripMainRefresh.Size = new System.Drawing.Size(24, 24);
            this.toolStripMainRefresh.Click += new System.EventHandler(this.toolStripMainRefresh_Click);
            // 
            // BaseOptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripMain);
            this.Name = "BaseOptionsControl";
            this.Size = new System.Drawing.Size(665, 194);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        public System.Windows.Forms.ToolStripContentPanel ContentPanel;
        protected ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripMainAdd;
        private System.Windows.Forms.ToolStripButton toolStripMainDelete;
        private System.Windows.Forms.ToolStripButton toolStripMainEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripMainRefresh;
        private System.Windows.Forms.ToolStripButton toolStripMainSave;

        #endregion Designer

        #region Properties

        /// <summary>
        /// Indicates that an item is being edited
        /// </summary>
        protected bool IsEditing { get; set; }

        /// <summary>
        /// If true the edit button is enabled
        /// </summary>
        protected bool AllowEdit { get; set; }

        /// <summary>
        /// if true the delete button is enabled
        /// </summary>
        protected bool AllowDelete { get; set; }

        /// <summary>
        /// if true, the add new button is enabled
        /// </summary>
        protected bool AllowAddNew { get; set; }

        /// <summary>
        /// if true refresh button is enabled
        /// </summary>
        protected bool AllowRefresh { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            toolStripMainAdd.Text = LanguageStrings.AppCreate;
            toolStripMainDelete.Text = LanguageStrings.AppDelete;
            toolStripMainSave.Text = LanguageStrings.AppSave;
            toolStripMainEdit.Text = LanguageStrings.AppHintEdit;
            toolStripMainRefresh.Text = LanguageStrings.AppHintRefresh;

            toolStripMainAdd.ToolTipText = LanguageStrings.AppCreate;
            toolStripMainDelete.ToolTipText = LanguageStrings.AppDelete;
            toolStripMainSave.ToolTipText = LanguageStrings.AppSave;
            toolStripMainEdit.ToolTipText = LanguageStrings.AppHintEdit;
            toolStripMainRefresh.ToolTipText = LanguageStrings.AppHintRefresh;
        }

        #endregion Overridden Methods

        #region Protected Methods

        #region Custom Buttons

        protected void AddToolbarSeperator()
        {
            toolStripMain.Items.Add(new ToolStripSeparator());
        }

        protected void AddToobarButton(ToolStripButton button)
        {
            toolStripMain.Items.Add(button);
        }

        protected void AddToolbarCombo(ToolStripComboBox combo)
        {
            toolStripMain.Items.Add(combo);
        }

        #endregion Custom Buttons

        #region Generic Buttons

        protected virtual void OnCreateClicked()
        {

        }

        protected virtual void OnDeleteClicked()
        {

        }

        protected virtual void OnSaveClicked()
        {

        }

        protected virtual void OnRefreshClicked()
        {

        }

        protected virtual void OnEditClicked()
        {

        }

        #endregion Generic Buttons


        protected virtual void UpdateUI(bool itemSelected)
        {
            if (itemSelected)
            {
                toolStripMainDelete.Enabled = AllowDelete;
                toolStripMainSave.Enabled = IsEditing;
            }
            else
            {
                toolStripMainDelete.Enabled = false;
                toolStripMainSave.Enabled = false;
            }

            toolStripMainEdit.Enabled = AllowEdit;
            toolStripMainAdd.Enabled = AllowAddNew && !IsEditing;
            toolStripMainRefresh.Enabled = AllowRefresh;
        }

        protected virtual bool PromptSave()
        {
            return (true);
        }

        #endregion Protected Methods

        #region Private Methods

        private void toolStripMainAdd_Click(object sender, EventArgs e)
        {
            OnCreateClicked();
        }

        private void toolStripMainDelete_Click(object sender, EventArgs e)
        {
            OnDeleteClicked();
        }

        private void toolStripMainSave_Click(object sender, EventArgs e)
        {
            OnSaveClicked();
        }

        private void toolStripMainEdit_Click(object sender, EventArgs e)
        {
            OnEditClicked();
        }

        private void toolStripMainRefresh_Click(object sender, EventArgs e)
        {
            OnRefreshClicked();
        }
 
        #endregion Private Methods
   }
}
