using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Languages;

namespace POS.Base.Forms
{
    public partial class NotesViewForm : BaseForm
    {
        #region Constructors

        public NotesViewForm()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Static Methods

        public static bool ShowNotes(Form parent, ref string notes, bool isReadOnly, int maxLength)
        {
            bool Result = false;

            NotesViewForm frm = new NotesViewForm();
            try
            {
                frm.txtNotes.Text = notes;
                frm.txtNotes.MaxLength = maxLength;
                frm.txtNotes.ReadOnly = isReadOnly;
                frm.btnSave.Enabled = !isReadOnly;

                Result = frm.ShowDialog(parent) == DialogResult.OK;

                if (Result)
                    notes = frm.txtNotes.Text;
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }

            return (Result);
        }

        #endregion Static Methods

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.ViewNotes;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            this.Text = LanguageStrings.Notes;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnSave.Text = LanguageStrings.AppMenuButtonSave;
        }

        #endregion Overridden Methods
    }
}
