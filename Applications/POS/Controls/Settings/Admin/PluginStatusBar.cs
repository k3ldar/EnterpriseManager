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
 *  File: PluginStatusBar.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System.Drawing;
using System.Windows.Forms;

using Languages;
using POS.Base.Classes;
using POS.Base.Plugins;

namespace PointOfSale.Controls.Settings.Admin
{
    public partial class PluginStatusBar : SharedControls.BaseSettings
    {
        #region Constructors

        public PluginStatusBar()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        public override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            lblAvailableStatusBar.Text = LanguageStrings.AppPluginStatusBarAvailable;
            lblSelectedStatusBar.Text = LanguageStrings.AppPluginStatusBarSelected;
        }

        public override bool SettingsSave()
        {
            foreach (Button button in flowPanelAvailable.Controls)
            {
                TrayNotification item = (TrayNotification)button.Tag;
                item.Visible = false;
            }

            foreach (Button button in flowPanelSelected.Controls)
            {
                TrayNotification item = (TrayNotification)button.Tag;
                item.Visible = true;
                item.Position = flowPanelSelected.Controls.GetChildIndex(button, false);
            }

            return base.SettingsSave();
        }

        public override void SettingsLoaded()
        {
            TrayNotificationCollection _allNotifications = PluginManager.TrayNotificationsGet(false);

            foreach (TrayNotification item in _allNotifications)
            {
                Button pnlNotification = new Button();
                pnlNotification.Tag = item;
                pnlNotification.Height = 35;
                pnlNotification.Width = 100;
                pnlNotification.AutoSize = true;
                pnlNotification.Text = item.StatusText();
                pnlNotification.AutoSize = false;
                pnlNotification.AllowDrop = true;
                pnlNotification.MouseDown += pnlNotification_MouseDown;
                pnlNotification.DragEnter += flowPanelSelected_DragEnter;
                pnlNotification.DragDrop += flowPanelSelected_DragDrop;

                if (item.Visible)
                    flowPanelSelected.Controls.Add(pnlNotification);
                else
                    flowPanelAvailable.Controls.Add(pnlNotification);
            }
        }

        #endregion Overridden Methods

        #region Private Methods

        private void pnlNotification_MouseDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).DoDragDrop((Button)sender, DragDropEffects.Move);
        }

        private void flowPanelSelected_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flowPanelSelected_DragDrop(object sender, DragEventArgs e)
        {
            FlowLayoutPanel parentPanel;

            if (sender is Button)
                parentPanel = (FlowLayoutPanel)((Button)sender).Parent;
            else
                parentPanel = (FlowLayoutPanel)sender;

            ((Button)e.Data.GetData(typeof(Button))).Parent = parentPanel;

            // Reorder
            Point p = parentPanel.PointToClient(new Point(e.X, e.Y));
            Button item = (Button)parentPanel.GetChildAtPoint(p);

            if (item == null)
            {
                p.X += 20; // get control to the right so we can insert just prior to it
                item = (Button)parentPanel.GetChildAtPoint(p);
            }

            int index = parentPanel.Controls.GetChildIndex(item, false);
            parentPanel.Controls.SetChildIndex((Button)e.Data.GetData(typeof(Button)), index);
        }

        #endregion Private Methods
    }
}
