using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Base.Plugins
{

    public sealed class TrayNotificationCompare : Comparer<TrayNotification>
    {
        public override int Compare(TrayNotification x, TrayNotification y)
        {
            return (x.CompareTo(y));
        }
    }
}
