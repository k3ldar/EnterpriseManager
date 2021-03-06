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
 *  File: HomeButton.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  07/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using SharedControls.Forms;

namespace POS.Base.Plugins
{
    public abstract class HomeButton : IComparable<HomeButton>
    {
        #region Construcors

        /// <summary>
        /// Constructor for Home Button to be displayed on main form
        /// </summary>
        /// <param name="name">Name of button</param>
        /// <param name="description">Description of button</param>
        /// <param name="image">Image for button</param>
        public HomeButton(BasePluginModule parent, string buttonName,
            string description, Image image)
        {
            Parent = parent;
            ButtonName = buttonName;
            Description = description;
            Image = image;
        }

        #endregion Constructs

        #region Properties

        /// <summary>
        /// Parent Plugin Module
        /// </summary>
        public BasePluginModule Parent { get; private set; }

        /// <summary>
        /// Name to be displayed on button
        /// </summary>
        public string ButtonName { get; set; }

        /// <summary>
        /// Description of Button, to be displayed within settings dialog
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Image to be displayed on button
        /// </summary>
        public Image Image { get; private set; }

        /// <summary>
        /// Used internally to determine wether the button is active or not
        /// </summary>
        internal bool IsActive { get; set; }

        /// <summary>
        /// Position of button
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Determines wether the button is being shown or not
        /// </summary>
        public bool Visible { get; set; }

        #endregion Properties

        #region Sorting

        public int CompareTo(HomeButton button)
        {
            if (button.Visible)
            {
                return (Position.CompareTo(button.Position));
            }
            else
                return (1);
        }

        #endregion Sorting

        #region Public Methods

        /// <summary>
        /// Method to be overridden in descend classes for when the button is clicked
        /// </summary>
        /// <param name="parent">Parent Form</param>
        public abstract void ButtonClicked(object sender, EventArgs e);

        #endregion Public Methods

        #region Event Wrappers

        /// <summary>
        /// Raises the BringToFront event
        /// </summary>
        protected void RaiseBringToFront()
        {
            if (POSBringToFront != null)
                POSBringToFront(this, EventArgs.Empty);
        }

        protected void RaisePluginUsage(string name)
        {
            if (PluginUsage != null)
                PluginUsage(this, new PluginUsageEventArgs(name));
        }

        #endregion Event Wrappers

        #region Events

        /// <summary>
        /// Event raised by Button when the parent form should make it's self the main screen
        /// </summary>
        public event EventHandler POSBringToFront;

        /// <summary>
        /// Event raised when item is used, host application can track usage
        /// </summary>
        public event EventHandlerPluginUsage PluginUsage;

        #endregion Events
    }
}
