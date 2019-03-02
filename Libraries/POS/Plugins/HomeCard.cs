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
 *  File: HomeCard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using POS.Base.Controls;

using SharedBase.BOL.Users;

namespace POS.Base.Plugins
{
    /// <summary>
    /// Base class for items displaying a tab
    /// </summary>
    public abstract class HomeCard : IComparable<HomeCard>
    {
        #region Constructor

        public HomeCard(BasePlugin parent)
        {
            Parent = parent;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Parent Plugin Module
        /// </summary>
        public BasePlugin Parent { get; private set; }

        /// <summary>
        /// Button on the home tab for ths HomeTab item
        /// </summary>
        public BaseHomeTabButton HomeTabButton { get; set; }

        #endregion Propertes

        #region Abstract Methods

        /// <summary>
        /// Determines wether the user can have access to the module
        /// </summary>
        /// <param name="user"></param>
        /// <returns>bool, true if user is allowed, otherwise false</returns>
        public abstract bool ValidateSecurity(User user);

        /// <summary>
        /// Image to be displayed on the home page
        /// </summary>
        /// <returns></returns>
        public abstract Image ButtonImage();

        /// <summary>
        /// Name of Tab, shown on Tab Header
        /// </summary>
        /// <returns></returns>
        public abstract string GetName();

        /// <summary>
        /// Custom colour for tab
        /// </summary>
        /// <returns></returns>
        public abstract Color TabColour();

        /// <summary>
        /// Returns the contents (base Tab Control) to be shown within the tab
        /// </summary>
        /// <returns></returns>
        public abstract POS.Base.Controls.BaseControl TabContents();

        #endregion Abstract Methods

        #region Virtual Methods

        /// <summary>
        /// Indicates the card is being freed etc, save settings or free resources etc
        /// </summary>
        public virtual void Closing()
        {

        }

        /// <summary>
        /// Notifications will be displayed on the home screen if there are any
        /// </summary>
        /// <returns></returns>
        public virtual int GetNotificationCount()
        {
            return (0);
        }

        public virtual Brush GetNotificationColor()
        {
            return (Brushes.DarkCyan);
        }
   
        /// <summary>
        /// Display tab determines wether the button shows a tab page or not, default true
        /// </summary>
        /// <returns>true if a tab page is to be displayed</returns>
        public virtual bool DisplayTab()
        {
            return (true);
        }

        
        /// <summary>
        /// Default execute method, if no tab is displayed, this 
        /// method is called when the button is clicked
        /// </summary>
        public virtual void Execute()
        {

        }

        /// <summary>
        /// Default sort order for sorting on home page
        /// </summary>
        /// <returns></returns>
        public virtual int SortOrder()
        {
            return (5000);
        }

        #region Button Options

        public virtual bool OwnerDrawn()
        {
            return (false);
        }

        public virtual void Paint(PaintEventArgs e)
        {

        }

        public virtual LinearGradientMode ButtonGradientMode()
        {
            return (LinearGradientMode.ForwardDiagonal);
        }

        public virtual Color ButtonFromColor()
        {
            return (Color.Blue);
        }

        public virtual Color ButtonToColor()
        {
            return (Color.LightGray);
        }

        public virtual Brush ButtonHeaderColor()
        {
            return (Brushes.LemonChiffon);
        }

        public virtual Brush ButtonBorderColor()
        {
            return (Brushes.DarkGray);
        }

        public virtual byte ButtonBorderWidth()
        {
            return (4);
        }

        public virtual void EventRaised(NotificationEventArgs e)
        {

        }

        #endregion Button Options

        #region Status Bar Panels

        public virtual int StatusPanelCount()
        {
            return (0);
        }

        public virtual string StatusPanelText(int index)
        {
            return (String.Empty);
        }

        public virtual string StatusPanelHint(int index)
        {
            return (String.Empty);
        }

        public virtual void StatusPanelDoubleClick(int index)
        {

        }

        #endregion Status Bar Panels

        /// <summary>
        /// Icon will be displayed on the left of the title on the tab header
        /// </summary>
        /// <returns></returns>
        public virtual Icon GetIcon()
        {
            return (null);
        }

        #region Help String

        /// <summary>
        /// Returns the help context string for the tab
        /// </summary>
        /// <returns></returns>
        public abstract string HepString();

        #endregion Help String

        #endregion Virtual Methods

        #region Comparable

        int IComparable<HomeCard>.CompareTo(HomeCard other)
        {
            throw new NotImplementedException();
        }

        #endregion Comparable
    }
}
