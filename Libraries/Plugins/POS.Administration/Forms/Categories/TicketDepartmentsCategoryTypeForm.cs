using System;
using System.Globalization;
using System.Windows.Forms;

using Languages;

using Library.BOL.Helpdesk;

using POS.Administration.Classes;

namespace POS.Administration.Forms.Categories
{
    public partial class TicketDepartmentsCategoryTypeForm : BaseCategoryEditAddForm
    {
        #region Private Members


        #endregion Private Members

        #region Constructors

        public TicketDepartmentsCategoryTypeForm()
            :base (CategoryType.TicketDepartmentTypes)
        {
            InitializeComponent();
        }

        public TicketDepartmentsCategoryTypeForm(ref TicketDepartment departmentType)
            : this()
        {
            DepartmentType = departmentType;
            IsNew = DepartmentType == null;

            if (!IsNew)
            {
                Description = departmentType.Description;
            }
        }

        #endregion Constructors

        #region Properties

        private TicketDepartment DepartmentType { get; set; }

        #endregion Properties

        #region Overridden Methods

        protected override void LanguageChanged(CultureInfo culture)
        {
            base.LanguageChanged(culture);

            this.Text = LanguageStrings.AppTicketDepartment;
        }

        protected override void btnOKClick(object sender, EventArgs e)
        {
            if (IsNew)
            {
                DepartmentType = TicketDepartments.Create(Description);
            }
            else
            {
                DepartmentType.Description = Description;
                DepartmentType.Save();
            }

            DialogResult = DialogResult.OK;
        }

        #endregion Overridden Methods

        #region Static Methods

        public static bool ShowCategoryForm(ref TicketDepartment ticketGroup)
        {
            bool Result = false;

            TicketDepartmentsCategoryTypeForm frm = new TicketDepartmentsCategoryTypeForm(ref ticketGroup);
            try
            {
                Result = frm.ShowDialog() == DialogResult.OK;

                ticketGroup = frm.DepartmentType;
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