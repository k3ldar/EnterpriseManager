using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Languages;

using Library.BOL.Users;

namespace POS.Diary.Forms
{
    public partial class NewAppointments : POS.Base.Forms.BaseForm
    {
        #region Constructors

        public NewAppointments()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Overridden Methods
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.DiaryApptNew;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.AppDiaryNewAppointments;
        }

        #endregion Overridden Methods
    }
}
