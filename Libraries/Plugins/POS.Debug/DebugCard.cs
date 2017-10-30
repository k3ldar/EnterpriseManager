using System.Drawing;
using Languages;
using POS.Base.Plugins;
using Library.BOL.Users;

namespace POS.Debug
{
    class DebugCard : HomeCard
    {
        #region Private Members

        Forms.DebugInfo _tabFormPage;

        #endregion Private Members

        public DebugCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (true);
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Debug);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.Debug);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.DebugInfo();
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppMenuDebug);
        }

        public override int StatusPanelCount()
        {
            return (_tabFormPage.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_tabFormPage.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_tabFormPage.GetStatusHint(index));
        }

        public override Color ButtonFromColor()
        {
            return (Color.Yellow);
        }

        public override Color ButtonToColor()
        {
            return (Color.LightYellow);
        }

        public override int SortOrder()
        {
            return (int.MaxValue);
        }

        public override void EventRaised(NotificationEventArgs e)
        {
            if (_tabFormPage != null)
            {
                _tabFormPage.EventRaised(e);
            }
        }

        #region Private Members


        #endregion Private Members
    }
}
