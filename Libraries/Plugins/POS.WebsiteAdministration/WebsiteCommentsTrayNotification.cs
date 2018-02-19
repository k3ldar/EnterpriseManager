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
 *  File: WebsiteCommentsTrayNotification.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
