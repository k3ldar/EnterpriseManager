using System;
using System.Collections.Generic;
using System.Text;

using Library;
using Library.BOL.Basket;
using Library.BOL.Users;

namespace Library.BOL.CashDrawer
{
    /// <summary>
    /// Cash Drawers
    /// </summary>
    [Serializable]
    public sealed class CashDrawers : BaseObject
    {
        #region Static Methods

        public static void Submit(User user, string CheckType, CashDrawerType type, string notes, 
            int Pound500, int Pound100, int Pound50, int Pound20, int Pound10, int Pound5, int Pound2, 
            int Pound1, int Pence50, int Pence20, int Pence10, int Pence5, int Pence2, int Pence1)
        {
            DAL.FirebirdDB.CashDrawerSubmit(user, CheckType, type, notes, Pound500, Pound100, Pound50, Pound20,
                Pound10, Pound5, Pound2, Pound1, Pence50, Pence20, Pence10, Pence5, Pence2, Pence1);
        }

        public static bool StartOfDayComplete(CashDrawerType type)
        {
            return (DAL.FirebirdDB.CashDrawerDailyStartComplete(type));
        }

        public static bool CheckedInLast10Minutes()
        {
            return (DAL.FirebirdDB.CashDrawer10MinuteCheck());
        }

        public static string CurrentStatus(int storeID, Countries.Country country,
            Currency currency, DateTime date, CashDrawerType type)
        {
            return (DAL.FirebirdDB.CashDrawerVerify(storeID, country, currency, date, type));
        }

        #endregion Static Methods
    }
}
