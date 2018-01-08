using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SieraDelta.Website.Controls
{
    public partial class ParamaterEditor : System.Web.UI.UserControl
    {
        #region Constructors

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion Constructors

        #region Public Methods

        public void Initialise(string name, string description)
        {
            Description = description;
            PropertyName = name;
        }

        #endregion Public Methods

        #region Properties

        public string PropertyName
        {
            get
            {
                return (pPropertyName.InnerText);
            }

            set
            {
                pPropertyName.InnerText = value;
            }
        }

        public string Description
        {
            get
            {
                return (txtPropertyDescription.Text);
            }

            set
            {
                txtPropertyDescription.Text = value;
            }
        }

        #endregion Properties
    }
}