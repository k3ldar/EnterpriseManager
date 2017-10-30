using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace POS.Export.Forms
{
    public partial class frmExportSelectDate : POS.Base.Forms.BaseForm
    {
        #region Constructors

        public frmExportSelectDate()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = Languages.LanguageStrings.AppExportSelectDate;
            lblDescription.Text = Languages.LanguageStrings.AppExportSelectDateDesc;
            btnCancel.Text = Languages.LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = Languages.LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Properties

        public DateTime DateFrom
        {
            get
            {
                return (calSelectedDate.SelectionRange.Start.Date);
            }
        }

        #endregion Properties
    }
}
