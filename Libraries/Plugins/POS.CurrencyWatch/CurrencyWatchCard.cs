using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;


using SharedControls.Forms;
using Languages;
using Library;
using Library.BOL.Products;
using Library.BOL.Salons;
using Library.BOL.Statistics;
using POS.Base.Classes;
using POS.Base.Plugins;
using POS.CurrencyWatch.Classes;
using Library.BOL.Users;

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
