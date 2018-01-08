using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Website.Library.Classes;
using Library.BOL.Users;
using Library.BOL.Products;
using Library.Utils;

namespace SieraDelta.Website.Controls
{
    public partial class OutOfStockNotification : BaseControlClass
    {
        #region Private / Protected Members

        protected ProductCost _item;

        #endregion Private / Protected Members

        #region Public Properties

        #endregion Public Properties

        #region Public Methods

        public void SetItem(ProductCost item)
        {
            _item = item;

            User user = GetUser();

            // does the user already have a notification setup?
            if (user != null && Notifications.Exists(item, user.Email))
            {
                txtEmail.Enabled = false;
                btnAddNotification.Visible = false;
                btnRemoveNotification.Visible = true;
                lblDescription.InnerText = Languages.LanguageStrings.OutOfStockNotificationSet;
            }
            else
            {
                btnRemoveNotification.Visible = false;
                btnAddNotification.Visible = true;
                lblDescription.InnerText = Languages.LanguageStrings.OutOfStockDescription;
            }

        }

        #endregion Public Methods

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            User user = GetUser();

            if (user != null)
            {
                txtEmail.Text = user.Email;
                txtEmail.Enabled = false;
            }

            lblError.Visible = false;
            btnAddNotification.Text = Languages.LanguageStrings.OutOfStockAddNotification;
            btnRemoveNotification.Text = Languages.LanguageStrings.OutOfStockRemoveNotification;
        }

        protected void btnAddNotification_Click(object sender, EventArgs e)
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
            if (SharedUtils.IsValidEmail(txtEmail.Text))
            {
                Notifications.Add(_item, txtEmail.Text);
                btnAddNotification.Visible = false;
                btnRemoveNotification.Visible = true;
                lblDescription.InnerText = Languages.LanguageStrings.OutOfStockNotificationSet;
            }
            else
            {
                lblError.Visible = true;
                lblError.InnerText = "Invalid Email Address";
            }
        }

        protected void btnRemoveNotification_Click(object sender, EventArgs e)
        {
            //SieraDeltaUtils u = new SieraDeltaUtils();
            if (SharedUtils.IsValidEmail(txtEmail.Text))
            {
                Notifications.Remove(_item, txtEmail.Text);
                btnRemoveNotification.Visible = false;
                btnAddNotification.Visible = true;
                lblDescription.InnerText = Languages.LanguageStrings.OutOfStockDescription;
            }
            else
            {
                lblError.Visible = true;
                lblError.InnerText = "Invalid Email Address";
            }
        }

        #endregion Protected Methods

    }
}