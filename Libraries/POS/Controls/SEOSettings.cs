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
 *  File: SEOSettings Control
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  29/01/2018  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

using Languages;

using Library.BOL.HashTags;

namespace POS.Base.Controls
{
    public partial class SEOSettings : BaseControl
    {
        #region Private Members

        private Uri _url;

        #endregion Private Members

        #region Constructors

        public SEOSettings()
        {
            InitializeComponent();
        }

        public SEOSettings(Uri uri)
            : this()
        {
            _url = uri ?? throw new ArgumentNullException(nameof(uri));
        }

        #endregion Constructors

        #region Properties

        public Uri Url
        {
            get
            {
                return (_url);
            }

            set
            {
                _url = value ?? throw new ArgumentOutOfRangeException(nameof(Url));

                LoadSeoData();
            }
        }

        private HashTags PageTags { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            lblAvailableTags.Text = LanguageStrings.AvailableTags;
            lblMetaDescription.Text = LanguageStrings.MetaDescription;
            lblSelectedTags.Text = LanguageStrings.SelectedTags;
            lblTitle.Text = LanguageStrings.Title;
        }

        #endregion Overridden Methods

        #region Public Methods

        public void Save()
        {
            string page = Url.ToString();

            if (page.Length > 38)
            {
                page = page.Substring(page.Length - 38);
            }

            Library.LibraryHelperClass.SettingsSetMeta(String.Format("DESCRIPTION:{0}", page), txtMetaDescription.Text);
            Library.LibraryHelperClass.SettingsSetMeta(String.Format("TITLE:{0}", page), txtTitle.Text);
        }

        public void LoadSeoData()
        {
            PageTags = HashTags.GetPageTags(Url);

            lstAvailableTags.Items.Clear();

            foreach (HashTag tag in HashTags.GetTags())
            {
                if (PageTags.IndexOf(tag.ID))
                    lstSelectedTags.Items.Add(tag);
                else
                    lstAvailableTags.Items.Add(tag);
            }

            string page = Url.ToString();

            if (page.Length > 38)
            {
                page = page.Substring(page.Length - 38);
            }

            txtMetaDescription.Text = Library.LibraryHelperClass.SettingsGetMeta(String.Format("DESCRIPTION:{0}", page)).Trim();
            txtTitle.Text = Library.LibraryHelperClass.SettingsGetMeta(String.Format("TITLE:{0}", page)).Trim();
        }

        #endregion Public Methods

        #region Private Methds

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstAvailableTags.SelectedIndex == -1)
                return;

            HashTag tag = (HashTag)lstAvailableTags.Items[lstAvailableTags.SelectedIndex];
            HashTags.AddHashTag(tag, Url);
            lstSelectedTags.Items.Add(tag);
            lstAvailableTags.Items.Remove(tag);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelectedTags.SelectedIndex == -1)
                return;

            HashTag tag = (HashTag)lstSelectedTags.Items[lstSelectedTags.SelectedIndex];
            HashTags.RemoveHashTag(tag, Url);
            lstSelectedTags.Items.Remove(tag);
            lstAvailableTags.Items.Add(tag);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string newTagName = String.Empty;

            if (Forms.NewTagName.CreateTag(out newTagName))
            {
                HashTag newTag = HashTags.CreateHashTag(Url, newTagName);
                lstSelectedTags.Items.Add(newTag);
            }
        }

        private void lstAvailableTags_Format(object sender, ListControlConvertEventArgs e)
        {
            HashTag tag = (HashTag)e.ListItem;
            e.Value = tag.Tag;
        }

        #endregion Private Methods
    }
}