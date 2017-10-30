using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BOL.DatabaseUpdates
{
    [Serializable]
    public sealed class AutoUpdateItem : BaseObject
    {
        #region Constructors

        public AutoUpdateItem(Int64 id, string description)
        {
            ID = id;
            Description = description;
        }

        #endregion Constructors

        #region Properties

        public Int64 ID { get; private set; }

        public string Description { get; private set; }

        #endregion Properties
    }
}
