using System;

using Languages;

using POS.Base.Classes;
using POS.Base.Plugins;


namespace POS.WebsiteAdministration
{
    /// <summary>
    /// Tray notification for website comments
    /// </summary>
    public class WebsiteCommentsTrayNotification : TrayNotification
    {
        #region Constructors

        public WebsiteCommentsTrayNotification(BasePlugin parent)
            : base(parent)
        {
            this.CanBlink = true;
            this.UpdateFrequency = new TimeSpan(0, 0, 30);
            this.Position = 4;
        }

        #endregion Constructors

        #region Overridden Methods

        public override string HintText()
        {
            return (String.Empty);
        }

        public override string StatusText()
        {
            string Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppComments;
            int countComments = AppController.Administration.StatsComments();
            this.Blinking = countComments > 0;
            this.CanBlink = countComments > 0;

            if (countComments == 1)
                Result = StringConstants.PREFIX_AND_SPACE + LanguageStrings.AppComment;

            Result = String.Format(Result, countComments);

            return (Result);
        }

        public override string Name()
        {
            return (LanguageStrings.AppPluginTrayCustomerComments);
        }

        public override void DoubleClick()
        {

        }

        public override bool CanLoad()
        {
            return (true);
        }

        public override bool CanUnload()
        {
            return (true);
        }

        public override void Unload()
        {

        }

        public override void Load()
        {

        }

        #endregion Overridden Methods
    }
}
