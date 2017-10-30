using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Windows.Forms;

using Heavenskincare.PointOfSale.Controls;

using Heavenskincare.Library.BOL.Distributors;
using Heavenskincare.Library.BOL.Users;
using Heavenskincare.Library;
using Heavenskincare.Library.Utils;

namespace Heavenskincare.PointOfSale.Forms.Administration.Distributors
{
    public partial class AdminDistributorEdit : BaseForm
    {
        private User _User;
        private WebsiteAdministration _Admin;
        private Distributor _Distributor;

        public AdminDistributorEdit(User user, WebsiteAdministration admin, Distributor distributor)
        {
            _User = user;
            _Admin = admin;
            _Distributor = distributor;

            InitializeComponent();

            LoadImages();
            LoadDistributor();
        }

        protected override void SetPermissions()
        {
            //btnNew.Enabled = _User.MemberLevel > Heavenskincare.Library.Enums.MemberLevel.AdminReadOnly;
            //btnSave.Enabled = _User.MemberLevel > Heavenskincare.Library.Enums.MemberLevel.AdminReadOnly;
            //btnDelete.Enabled = _User.MemberLevel == Heavenskincare.Library.Enums.MemberLevel.Admin;
        }

        private void LoadDistributor()
        {
            HSCUtils u = new HSCUtils();
            txtName.Text = _Distributor.Name;
            txtURL.Text = _Distributor.URL;
            txtContactDetails.Text = u.ReplaceHTMLElements(_Distributor.ContactDetails).Replace("\r", "\r\n");
            cmbImage.SelectedIndex = cmbImage.Items.IndexOf(_Distributor.Image);
        }

        private void LoadImages()
        {
            cmbImage.Items.Clear();

            XmlTextReader reader = new XmlTextReader("DistributorImages.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text: //Display the text in each element.
                        cmbImage.Items.Add(reader.Value);
                        break;
                }
            }
        }

        private void cmbImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            imgPicture.ImageLocation = String.Format("http://www.heavenskincare.com/images/Distributors/{0}", cmbImage.SelectedItem);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ShowHardConfirm("Delete Distributor", "Are you sure you want to delete this Distributor?\r\rThis action can not be undone!"))
            {
                _Distributor.Delete();
                DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HSCUtils u = new HSCUtils();
            _Distributor.ContactDetails = u.ReplaceHTMLElements(txtContactDetails.Text);
            _Distributor.Image = (string)cmbImage.Items[cmbImage.SelectedIndex];
            _Distributor.URL = txtURL.Text;
            _Distributor.Name = txtName.Text;
            _Distributor.Save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }


    }
}
