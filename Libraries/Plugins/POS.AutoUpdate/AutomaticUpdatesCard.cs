using System;
using System.Drawing;

using Languages;
using Library.BOL.Users;
using POS.Base.Classes;
using POS.Base.Plugins;

namespace POS.AutoUpdate
{
    public class AutomaticUpdatesCard : HomeCard
    {
        #region Private Members

        Forms.AutoUpdatesForm _autoUpdate;

        #endregion Private Members

        public AutomaticUpdatesCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionPOS(Library.SecurityEnums.SecurityPermissionsPOS.ManageAutoUpdates));
        }
        public override Image ButtonImage()
        {
            return (Properties.Resources.AutoUpdate);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.Diary);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_autoUpdate == null)
            {
                _autoUpdate = new Forms.AutoUpdatesForm();
            }

            return (_autoUpdate);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppAutoUpdateTab);
        }

        public override int StatusPanelCount()
        {
            return (_autoUpdate.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_autoUpdate.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_autoUpdate.GetStatusHint(index));
        }

        #region Private Members

        #endregion Private Members
    }
}
