using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Hooks
{
    public sealed class Hook : BaseObject
    {
        #region Constructors

        public Hook(HookEvent eventName, Int64 userID)
        {
            EventName = eventName;
            UserID = userID;
        }

        #endregion Constructors

        #region Properties

        public HookEvent EventName { get; set; }

        public Int64 UserID { get; set; }

        #endregion Properties
    }
}
