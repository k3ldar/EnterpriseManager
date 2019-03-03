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
 *  Copyright (c) 2010 - 2019 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: CurrencyWatchCard.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;


using SharedControls.Forms;
using Languages;
using SharedBase;
using SharedBase.BOL.Products;
using SharedBase.BOL.Salons;
using SharedBase.BOL.Statistics;
using POS.Base.Classes;
using POS.Base.Plugins;
using POS.CurrencyWatch.Classes;
using SharedBase.BOL.Users;

namespace POS.CurrencyWatch
{
    public class CurrencyWatchCard : HomeCard, IDisposable
    {
        #region Private Members

        private CurrencyWatchTrayIcon _trayIcon;
        private Font _headerFont;
        StringFormat _headerStringFormat;
        StringFormat _bodyStringFormat;

        #endregion Private Members

        public CurrencyWatchCard(BasePlugin parent)
            : base(parent)
        {
            _headerFont = new Font(System.Drawing.SystemFonts.DefaultFont.FontFamily, 9.0f);
            _headerStringFormat = new StringFormat();
            _headerStringFormat.Alignment = StringAlignment.Center;
            _headerStringFormat.LineAlignment = StringAlignment.Near;
            _bodyStringFormat = new StringFormat();
            _bodyStringFormat.Alignment = StringAlignment.Near;
            _bodyStringFormat.LineAlignment = StringAlignment.Near;
            _bodyStringFormat.SetTabStops(1.3f, new float[] { 16f });
        }

        public CurrencyWatchCard(BasePlugin parent, CurrencyWatchTrayIcon trayIcon)
            : this (parent)
        {
            _trayIcon = trayIcon;
        }

        public override bool ValidateSecurity(User user)
        {
            // all users can see currency
            return (true);
        }

        public override Image ButtonImage()
        {
            return (null);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (HelpTopics.CurrencyWatch);
        }

        public override Base.Controls.BaseControl TabContents()
        {
            return (null);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppCurrencyWatch);
        }

        public override int StatusPanelCount()
        {
            return (0);
        }

        public override string StatusPanelText(int index)
        {
            return (String.Empty);
        }

        public override string StatusPanelHint(int index)
        {
            return (String.Empty);
        }

        public override int SortOrder()
        {
            return (250);
        }

        public override bool OwnerDrawn()
        {
            return (true);
        }

        public override void Paint(PaintEventArgs e)
        {
            string header = String.Empty;
            string body = _trayIcon.ButtonText(ref header);

            //header
            e.Graphics.DrawString(
                header,
                _headerFont,
                Brushes.Black,
                e.ClipRectangle,
                _headerStringFormat);

            Rectangle bodyRect = e.ClipRectangle;
            bodyRect.Inflate(-12, -12);
            // body
            e.Graphics.DrawString(
                body,
                _headerFont,
                Brushes.Black,
                bodyRect,
                _bodyStringFormat);
        }

        public void Dispose()
        {
            _headerFont.Dispose();
            _headerStringFormat.Dispose();
            _bodyStringFormat.Dispose();
        }

        #region Private Members


        #endregion Private Members
    }
}
