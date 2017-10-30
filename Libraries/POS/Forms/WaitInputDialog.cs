using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SieraDelta.Languages;

namespace SieraDelta.POS.Forms
{
    public partial class WaitInputDialog : SieraDelta.Controls.Forms.BaseForm
    {
        private static WaitInputDialog _waitDialog = null;

        public WaitInputDialog()
        {
            InitializeComponent();
        }

        #region Static Methods

        public static void ShowWaitScreen()
        {
            if (_waitDialog == null)
            {
                _waitDialog = new WaitInputDialog();
                _waitDialog.Show();
                //System.Threading.Thread.CurrentThread.
            }
        }


        public static void HideWaitScreen()
        {
            if (_waitDialog != null)
            {
                _waitDialog.Close();
                _waitDialog.Dispose();
                _waitDialog = null;
            }
        }

        public static void UpdateWaitScreen(string text)
        {
            if (_waitDialog != null)
            {
                _waitDialog.Update(text);
            }
        }


        public static void UpdateWaitScreen(string text, int position)
        {
            if (_waitDialog != null)
            {
                _waitDialog.Update(text, position);
            }
        }

        #endregion Static Methods

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppPleaseWait;
        }

        #endregion Overridden Methods

        public void Update(string Text)
        {
            lblProgress.Text = Text;
            Refresh();
        }

        public void Update(string Text, int Pos)
        {
            lblProgress.Text = Text;
            Refresh();
        }

        public void UpdateProgress(int Position)
        {
            Refresh();
        }

        public void Update(int Max, int Position)
        {
        }
    }
}
