using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Languages;
using POS.Base.Classes;
using POS.Base.Controls;
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
