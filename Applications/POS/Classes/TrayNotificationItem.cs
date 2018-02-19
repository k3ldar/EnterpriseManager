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
 *  File: TrayNotificationItem.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using POS.Base.Plugins;

namespace PointOfSale.Classes
{
    /// <summary>
    /// Type of notification item
    /// </summary>
    public enum NotificationItemType
    {
        Fixed,

        Plugn,

        Tab
    }

    public class TrayNotificationItem
    {
        public TrayNotificationItem()
        {
            ItemType = NotificationItemType.Fixed;
        }

        public TrayNotificationItem(TrayNotification notification)
        {
            NotificationItem = notification;
            ItemType = NotificationItemType.Plugn;
        }

        public TrayNotificationItem(HomeCard homeTab, int index)
        {
            Index = index;
            Tab = homeTab;
            ItemType = NotificationItemType.Tab;
        }

        public TrayNotification NotificationItem { get; private set; }

        public int Index { get; private set; }

        public NotificationItemType ItemType { get; private set; }

        public HomeCard Tab { get; private set; }
    }
}
