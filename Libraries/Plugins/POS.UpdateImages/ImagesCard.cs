using System;
using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;


namespace POS.Images
{
    class ImagesCard : HomeCard
    {
        #region Private Members

        Controls.ImagesTab _imageTab;

        #endregion Private Members

        public ImagesCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(SecurityEnums.SecurityPermissionsPOS.ManageImages));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.ImagesIcon);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.ImageManagement);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_imageTab == null)
            {
                _imageTab = new Controls.ImagesTab();
            }

            return (_imageTab);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppCardImages);
        }

        public override int StatusPanelCount()
        {
            return (0);
        }

        public override string StatusPanelText(int index)
        {
            return (String.Empty);
        }

        public override string StatusPanelHint(int index)
        {
            return (String.Empty);
        }

        public override int SortOrder()
        {
            return (700);
        }

        #region Private Members


        #endregion Private Members
    }
}
