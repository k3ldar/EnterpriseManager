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
 *  File: StockWrapper.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

using Library.BOL.StockControl;
using POS.Base.Classes;

using Shared.Classes;

namespace POS.StockControl.Classes
{
    internal static class StockWrapper
    {
        /// <summary>
        /// Determines wether stock is low, or not
        /// </summary>
        /// <returns></returns>
        internal static bool StockIsLow()
        {
            bool Result = false;

            Stock currentStock = Stock.Get(AppController.ActiveUser);
            try
            {
                foreach (StockItem item in currentStock)
                {
                    if (item.AutoRestock)
                    {
                        if (item.Available < (item.MinLevel + AppController.LocalSettings.StockLevelLow))
                        {
                            //getting low, need to reorder
                            Result = true;
                            break;
                        }
                    }
                }
            }
            finally
            {
                currentStock.Clear();
                currentStock = null;
            }

            return (Result);
        }

        /// <summary>
        /// Looks at current stock levels and automatically places an order for new stock.
        /// </summary>
        internal static string ReOrderLowStock(Stock reOrderStock)
        {
            string Result = Languages.LanguageStrings.AppReOrderFailed;


            if (reOrderStock.Count > 0)
            {
                // new stock needs to be ordered
                NVPCodec nvc = new NVPCodec();

                nvc.Add(StringConstants.STOCK_REORDER_COUNT, reOrderStock.Count.ToString());
                //nvc.Add(StringConstants.STOCK_REORDER_PARAMETER_USER_ID, AppController.LocalSettings.StockAutoReOrderUserID.ToString());
                nvc.Add(StringConstants.STOCK_REORDER_PARAMETER_USER_EMAIL, AppController.LocalSettings.StockAutoReOrderUserEmail);
                nvc.Add(StringConstants.STOCK_REORDER_PARAMETER_USER_PASSWORD, AppController.LocalSettings.StockAutoReOrderUserPassword);
                nvc.Add(StringConstants.STOCK_REORDER_PARAMETER_USER_REQUESTING, AppController.ActiveUser.Email);
                //nvc.Add("Debug", "True");

                for (int i = 0; i < reOrderStock.Count; i++)
                {
                    decimal quantityRequired = reOrderStock[i].OrderQuantity;

                    while (quantityRequired < reOrderStock[i].MinLevel)
                        quantityRequired += reOrderStock[i].OrderQuantity;

                    nvc.Add(String.Format(StringConstants.STOCK_REORDER_PARAMATER_ID, i), reOrderStock[i].ID.ToString());
                    nvc.Add(String.Format(StringConstants.STOCK_REORDER_PARAMATER_NAME, i), reOrderStock[i].Name);
                    nvc.Add(String.Format(StringConstants.STOCK_REORDER_PARAMATER_QUANTITY, i), quantityRequired.ToString());
                    nvc.Add(String.Format(StringConstants.STOCK_REORDER_PARAMATER_SIZE, i), reOrderStock[i].Size);
                    nvc.Add(String.Format(StringConstants.STOCK_REORDER_PARAMATER_SKU, i), reOrderStock[i].SKU);
                }

                Result = Shared.Communication.HttpPost.Post(
                    ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_BASE_WEB_SITE_REORDER_STOCK), nvc, 600,
                    StringConstants.DEFAULT_BOT_CLOUD_AGENT, null);
            }

            return (Result);
        }
    }
}
