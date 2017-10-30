using System;

namespace Library.BOL.Basket
{
    [Serializable]
    public sealed class SavedBasket : BaseObject
    {
        #region Constructors

        public SavedBasket(Int64 basketID, Int64 userID, string description, string voucherCode)
        {
            BasketID = basketID;
            UserID = userID;
            Description = description;
            VoucherCode = voucherCode;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID of the basket
        /// </summary>
        public Int64 BasketID { get; set; }

        /// <summary>
        /// User who products are being sold to
        /// </summary>
        public Int64 UserID { get; set; }

        /// <summary>
        /// Description of saved basket
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Voucher Code entered on the basket
        /// </summary>
        public string VoucherCode { get; set; }

        #endregion Properties
    }
}
