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
 *  File: Notes.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
    public partial class Notes : BaseForm
    {
        #region Private Members

        private bool _required;

        #endregion Private Members

        #region Constructors

        public Notes()
        {
            InitializeComponent();
            txtNotes.Focus();
        }

        #endregion Constructors

        #region Public Methods

        public static bool ShowNotes(ref string notes, bool required, string title)
        {
            Notes frmNotes = new Notes();
            try
            {
                frmNotes.Required = required;
                frmNotes.Note = notes;
                frmNotes.Title = title;

                if (frmNotes.ShowDialog() == DialogResult.OK)
                {
                    notes = frmNotes.Note;
                    return (true);
                }
                else
                {
                    return (false);
                }
            }
            finally
            {
                frmNotes.Dispose();
                frmNotes = null;
            }
        }

        #endregion Public Methods

        #region Properties

        /// <summary>
        /// Indicates wether notes are required or not
        /// </summary>
        public bool Required
        {
            get
            {
                return (_required);
            }

            set
            {
                _required = value;

                btnOK.Enabled = (!_required | (_required && txtNotes.Text.Length > 20));
            }
        }

        /// <summary>
        /// Notes being viewed
        /// </summary>
        public string Note
        {
            get
            {
                return (txtNotes.Text);
            }

            set
            {
                txtNotes.Text = value;
            }
        }

        public string Title { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            HelpTopic = POS.Base.Classes.HelpTopics.Notes;
        }

        protected override void LanguageChanged(System.Globalization.CultureInfo culture)
        {
            if (String.IsNullOrEmpty(Title))
                this.Text = LanguageStrings.AppNotes;
            else
                this.Text = Title;

            btnCancel.Text = LanguageStrings.AppMenuButtonCancel;
            btnOK.Text = LanguageStrings.AppMenuButtonOK;
        }

        #endregion Overridden Methods

        #region Private Methods

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Required)
            {
                if (txtNotes.Text.Length < 20)
                {
                    ShowError(LanguageStrings.AppError, LanguageStrings.AppNotesRequired);
                    return;
                }
                else
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = (!_required | (_required && txtNotes.Text.Length > 20));
        }

        #endregion Private Methods
    }
}
