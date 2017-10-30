using System;
using System.Globalization;
using System.Windows.Forms;

using Languages;

using Library.BOL.Appointments;

using POS.Administration.Classes;

namespace POS.Administration.Forms.Categories
{
    public partial class AppointmentGroupCategoryTypeForm : BaseCategoryEditAddForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public AppointmentGroupCategoryTypeForm()
            :base (CategoryType.AppointmentGroupTypes)
        {
            InitializeComponent();
        }

        public AppointmentGroupCategoryTypeForm(ref AppointmentGroup group)
            : this()
        {
            Group = group;
            IsNew = Group == null;

            if (!IsNew)
            {
                Description = group.Description;
            }
        }

        #endregion Constructors

        #region Properties

        private AppointmentGroup Group { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppAppointmentGroup;
        }

        protected override void btnOKClick(object sender, EventArgs e)
        {
            if (IsNew)
            {
                Group = AppointmentGroups.Create(Description);
            }
            else
            {
                Group.Description = Description;
                Group.Save();
            }

            DialogResult = DialogResult.OK;
        }

        #endregion Overridden Methods

        #region Static Methods

        public static bool ShowCategoryForm(ref AppointmentGroup group)
        {
            bool Result = false;

            AppointmentGroupCategoryTypeForm frm = new AppointmentGroupCategoryTypeForm(ref group);
            try
            {
                Result = frm.ShowDialog() == DialogResult.OK;

                group = frm.Group;
            }
            finally
            {
                frm.Dispose();
                frm = null;
            }

            return (Result);
        }

        #endregion Static Methods
    }
}

