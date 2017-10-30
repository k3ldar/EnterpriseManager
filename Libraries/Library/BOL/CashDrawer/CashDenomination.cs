using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.CashDrawer
{
    [Serializable]
    public sealed class CashDenomination : BaseObject
    {
        #region Constructors

        public CashDenomination(Int64 id, bool isNote, decimal value, decimal linkValue)
        {
            ID = id;
            IsNote = isNote;
            Value = value;
            LinkValue = linkValue;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID for record
        /// </summary>
        public Int64 ID { get; private set; }

        /// <summary>
        /// Indicates wether this is a note or coin
        /// </summary>
        public bool IsNote { get; private set; }

        /// <summary>
        /// Value of currency denomination
        /// </summary>
        public decimal Value { get; private set; }

        /// <summary>
        /// The linked value this denomination is linked to in Cash Drawer Table
        /// </summary>
        public decimal LinkValue { get; private set; }

        #endregion Properties
    }
}
