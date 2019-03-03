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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: ImagesPluginModule.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

using POS.Images.Classes;

using SharedControls.Forms;
using Languages;
using POS.Base.Classes;
using POS.Base.Plugins;

#pragma warning disable IDE1006 // naming rule violation

namespace POS.Images
{
    class ImagesPluginModule : BasePlugin
    {
        #region Private Members

        private ToolStripMenuItem menuToolsImages;
        private ToolStripMenuItem menuToolsImagesImagesAndPictures;
        private ToolStripMenuItem menuToolsImagesSynchronize;
        private ToolStripSeparator menuToolsImagesSeperator;
        private ToolStripSeparator menuToolsImagesSeperator1;

        private ImagesCard _imagesCard;

        #endregion Private Members

        #region Constructors

        public ImagesPluginModule(Form parent)
            : base(parent)
        {

        }

        #endregion Constructors

        #region Overridden Methods

        public override PluginVersion Version()
        {
            return (PluginVersion.Version1);
        }

        public override string PluginName()
        {
            return (LanguageStrings.AppPluginImageManagement);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {
            menuToolsImagesSeperator.Owner.Items.Remove(menuToolsImagesSeperator);
            menuToolsImagesSeperator.Dispose();
            menuToolsImagesSeperator = null;

            // remove the menu items
            menuToolsImagesSynchronize.Owner.Items.Remove(menuToolsImagesSynchronize);
            menuToolsImagesSynchronize.Dispose();
            menuToolsImagesSynchronize = null;

            menuToolsImagesSeperator1.Owner.Items.Remove(menuToolsImagesSeperator1);
            menuToolsImagesSeperator1.Dispose();
            menuToolsImagesSeperator1 = null;

            menuToolsImagesImagesAndPictures.Owner.Items.Remove(menuToolsImagesImagesAndPictures);
            menuToolsImagesImagesAndPictures.Dispose();
            menuToolsImagesImagesAndPictures = null;

            menuToolsImages.Owner.Items.Remove(menuToolsImages);
            menuToolsImages.Dispose();
            menuToolsImages = null;

            Shared.Classes.ThreadManager.Cancel(StringConstants.THREAD_NAME_UPDATE_IMAGE);
        }

        public override bool BeforeLoad()
        {
            return (true);
        }

        public override void AfterLoad()
        {
            Shared.Classes.ThreadManager.ThreadStart(new UpdateImagesThread(),
                StringConstants.THREAD_NAME_UPDATE_IMAGE, ThreadPriority.BelowNormal);
        }

        public override void UpdateLanguage(CultureInfo culture)
        {
            menuToolsImages.Text = LanguageStrings.AppMenuImages;
            menuToolsImagesImagesAndPictures.Text = LanguageStrings.AppCardImages;
            menuToolsImagesSynchronize.Text = LanguageStrings.AppMenuUpdateImages;
        }

        public override void LoadAdministrationSettings(FormSettings settingsForm)
        {

        }

        public override void LoadUserSettings(FormSettings settingsForm)
        {

        }

        public override bool CanClose()
        {
            return (true);
        }

        public override void MenuAdd(PluginMenuType menuType, ToolStripMenuItem parentMenu)
        {
            switch (menuType)
            {
                case PluginMenuType.Tools:
                    CreateToolsMenu(parentMenu);
                    break;
            }
        }

        public override void MenuAdd(PluginMenuType menuType, MenuStrip mainMenu)
        {

        }

        public override void MenuDropDown(PluginMenuType menuType)
        {

        }

        public override HomeCards HomeCards()
        {
            HomeCards Result = new HomeCards();

            if (_imagesCard == null)
                _imagesCard = new ImagesCard(this);

            Result.Add(_imagesCard);

            return (Result);
        }

        #region Notification Items

        /// <summary>
        /// Retrieves Tray Notification Items
        /// </summary>
        /// <returns></returns>
        public override TrayNotificationCollection TrayNotifications()
        {
            return (null);
        }

        #endregion Notification Items

        #region Notification Events

        public override void Notification(NotificationEventArgs e)
        {
            base.Notification(e);

            switch (e.EventName)
            {
                default:
                    foreach (HomeCard card in HomeCards())
                    {
                        card.EventRaised(e);
                    }

                    break;
            }
        }

        public override void NotificationsGet(ref List<string> names)
        {
            base.NotificationsGet(ref names);

        }

        #endregion Notification Events

        #endregion Overridden Methods

        #region Private Methods

        private void CreateToolsMenu(ToolStripMenuItem parent)
        {
            menuToolsImagesSeperator = new ToolStripSeparator();
            parent.DropDownItems.Add(menuToolsImagesSeperator);

            menuToolsImages = new ToolStripMenuItem(LanguageStrings.AppMenuImages);
            parent.DropDownItems.Add(menuToolsImages);

            menuToolsImagesImagesAndPictures = new ToolStripMenuItem(LanguageStrings.AppCardImages);
            menuToolsImagesImagesAndPictures.Click += MenuToolsImagesImagesAndPictures_Click;
            menuToolsImages.DropDownItems.Add(menuToolsImagesImagesAndPictures);

            menuToolsImagesSeperator1 = new ToolStripSeparator();
            menuToolsImages.DropDownItems.Add(menuToolsImagesSeperator1);

            menuToolsImagesSynchronize = new ToolStripMenuItem(LanguageStrings.AppMenuUpdateImages);
            menuToolsImagesSynchronize.Click += menuToolsUpdateImages_Click;
            menuToolsImages.DropDownItems.Add(menuToolsImagesSynchronize);
        }

        private void MenuToolsImagesImagesAndPictures_Click(object sender, EventArgs e)
        {
            _imagesCard.HomeTabButton.ForceClick();
        }

        private void menuToolsUpdateImages_Click(object sender, EventArgs e)
        {
            ParentForm.Cursor = Cursors.WaitCursor;
            UpdateImagesThread imageUpdateThread = new UpdateImagesThread();
            imageUpdateThread.ThreadFinishing += imageUpdateThread_ThreadFinishing;
            Shared.Classes.ThreadManager.ThreadStart(imageUpdateThread,
                StringConstants.THREAD_NAME_UPDATE_IMAGE, ThreadPriority.BelowNormal);
        }


        void imageUpdateThread_ThreadFinishing(object sender, Shared.ThreadManagerEventArgs e)
        {
            if (ParentForm.InvokeRequired)
            {
                Shared.ThreadManagerEventDelegate eh = new Shared.ThreadManagerEventDelegate(imageUpdateThread_ThreadFinishing);
                ParentForm.Invoke(eh, new object[] { sender, e });
            }
            else
            {
                ParentForm.Cursor = Cursors.Arrow;
                MessageBox.Show(LanguageStrings.AppImageFilesUpdated, LanguageStrings.AppImageFiles,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion Private Methods
    }
}
