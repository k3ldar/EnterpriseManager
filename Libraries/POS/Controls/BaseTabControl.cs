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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: BaseTabControl.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Windows.Forms;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable IDE0017 // Object initialization can be simplified

namespace POS.Base.Controls
{
    public partial class BaseTabControl : BaseControl
    {
        public BaseTabControl()
        {
            InitializeComponent();
        }

        public virtual void Closing()
        {

        }

        public virtual void AfterResize()
        {

        }

        public virtual void BeforeTabHide()
        {

        }

        public virtual void BeforeTabShow()
        {

        }

        public virtual void AfterTabShow()
        {

        }

        public virtual int GetStatusCount()
        {
            return (0);
        }

        public virtual string GetStatusHint(int index)
        {
            return (String.Empty);
        }

        public virtual string GetStatusText(int index)
        {
            return (String.Empty);
        }

        public virtual string GetHelpTopic()
        {
            return (String.Empty);
        }

        protected virtual void LoadSettings()
        {

        }

        protected virtual void SetPermissions()
        {

        }

        #region Protected Methods

        protected void RebuildContextMenu(ToolStrip toolStrip, ContextMenuStrip menu)
        {
            if (toolStrip == null)
                throw new ArgumentNullException("toolStrip");

            if (menu == null)
                throw new ArgumentNullException("menu");

            menu.Items.Clear();
            int newSize = POS.Base.Icons.IconSize();
            toolStrip.ImageScalingSize = new System.Drawing.Size(newSize, newSize);
            toolStrip.Text = String.Empty;

            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (item.GetType() == typeof(ToolStripButton))
                {
                    item.EnabledChanged += item_EnabledChanged;
                    item.TextChanged += item_TextChanged;
                    ((ToolStripButton)item).CheckedChanged += BaseForm_CheckedChanged;

                    ToolStripMenuItem newMenu = new ToolStripMenuItem(item.ToolTipText);
                    newMenu.Image = item.Image;
                    newMenu.Enabled = item.Enabled;
                    item.Tag = newMenu;
                    newMenu.Tag = item;
                    newMenu.Click += newMenu_Click;

                    menu.Items.Add(newMenu);
                }

                if (item.GetType() == typeof(ToolStripSeparator))
                {
                    ToolStripSeparator newSep = new ToolStripSeparator();

                    menu.Items.Add(newSep);
                }
            }

            while (menu.Items[menu.Items.Count - 1].GetType() == typeof(ToolStripSeparator))
                menu.Items.Remove(menu.Items[menu.Items.Count - 1]);
        }

        #endregion Protected Methods

        #region Private Methods

        #region Context Menu

        private void newMenu_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menu)
            {
                if (menu.Tag == null)
                    return;

                ToolStripButton btn = (ToolStripButton)menu.Tag;

                btn.PerformClick();
            }
        }

        private void BaseForm_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripButton btn)
            {
                if (btn.Tag == null)
                    return;

                ToolStripMenuItem menu = (ToolStripMenuItem)btn.Tag;

                menu.Checked = btn.Checked;
            }
        }

        private void item_TextChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripButton btn)
            {
                if (btn.Tag == null)
                    return;

                ToolStripMenuItem menu = (ToolStripMenuItem)btn.Tag;

                menu.Text = btn.Text;
            }
        }

        private void item_EnabledChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripButton btn)
            {
                if (btn.Tag == null)
                    return;

                ToolStripMenuItem menu = (ToolStripMenuItem)btn.Tag;

                menu.Enabled = btn.Enabled;
            }
        }

        #endregion Context Menu

        #endregion Private Methods
    }
}
