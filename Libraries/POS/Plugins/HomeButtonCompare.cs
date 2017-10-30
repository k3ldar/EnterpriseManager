using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Base.Plugins
{
#if BUTTON_INTERFACE
    public sealed class HomeButtonCompare : Comparer<HomeButton>
    {

        public override int Compare(HomeButton x, HomeButton y)
        {
            return (x.CompareTo(y));
        }
    }
#endif
}
