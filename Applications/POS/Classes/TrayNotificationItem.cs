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
