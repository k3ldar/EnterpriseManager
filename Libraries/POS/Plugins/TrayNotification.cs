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
 *  File: TrayNotification.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace POS.Base.Plugins
{
    public abstract class TrayNotification : IComparable<TrayNotification>
    {
        public TrayNotification(BasePlugin parent)
        {
            Parent = parent;
        }


        #region Sorting

        public int CompareTo(TrayNotification notification)
        {
            if (notification.Visible)
            {
                return (Position.CompareTo(notification.Position));
            }
            else
                return (1);
        }

        #endregion Sorting


        #region Virtual Methods

        /// <summary>
        /// Returns the text that is shown in the status message
        /// </summary>
        /// <returns></returns>
        public abstract string StatusText();

        /// <summary>
        /// Unique Name for tray notification
        /// </summary>
        /// <returns></returns>
        public abstract string Name();

        /// <summary>
        /// Method called when user double clicks the notification
        /// </summary>
        public abstract void DoubleClick();

        /// <summary>
        /// Hint text for tray icon control
        /// </summary>
        /// <returns></returns>
        public abstract string HintText();

        /// <summary>
        /// Method called to determine wether the control can be loaded
        /// </summary>
        /// <returns></returns>
        public abstract bool CanLoad();

        /// <summary>
        /// Method called before unloading
        /// </summary>
        /// <returns></returns>
        public abstract bool CanUnload();

        /// <summary>
        /// Method call prior to unloading
        /// </summary>
        public abstract void Unload();

        /// <summary>
        /// Method call after the tray icon is loaded
        /// </summary>
        public abstract void Load();

        #endregion Virtual Methods

        #region Properties

        /// <summary>
        /// Determines wether the notification changes colour every 10 seconds or not
        /// 
        /// Used as a visual alert to the user
        /// </summary>
        public bool Blinking { get; set; }

        /// <summary>
        /// Indicates wether the tray status can blink or not
        /// </summary>
        public bool CanBlink { get; protected set; }

        /// <summary>
        /// Frequency that an update is requested
        /// </summary>
        public TimeSpan UpdateFrequency { get; protected set; }

        /// <summary>
        /// Date/Time status last updated
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Parent Plugin Class
        /// </summary>
        protected BasePlugin Parent { get; set; }

        /// <summary>
        /// Position within tray
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Indicates wether the current Tray Notification is visible or not
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Status Label associated with current tray notification
        /// </summary>
        public ToolStripStatusLabel StatusLabel { get; set; }

        #endregion Properties
    }
}
