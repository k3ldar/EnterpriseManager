using System.Drawing;
using Languages;

using Library;
using Library.BOL.Users;

using POS.Base.Classes;
using POS.Base.Plugins;


namespace POS.Administration
{
    public class SalonTreatmentCard : HomeCard
    {
        #region Private Members

        Forms.Treatments.AdminSalonTreatments _tabFormPage;

        #endregion Private Members

        public SalonTreatmentCard(BasePlugin parent)
            : base(parent)
        {

        }

        public override bool ValidateSecurity(User user)
        {
            return (user.HasPermissionCalendar(SecurityEnums.SecurityPermissionsCalendar.EditTreatments));
        }

        public override Image ButtonImage()
        {
            return (Properties.Resources.Treatments);
        }

        public override Color TabColour()
        {
            return (Color.LightGray);
        }

        public override string HepString()
        {
            return (POS.Base.Classes.HelpTopics.SalonTreatments);
        }

        public override POS.Base.Controls.BaseControl TabContents()
        {
            if (_tabFormPage == null)
            {
                _tabFormPage = new Forms.Treatments.AdminSalonTreatments(AppController.Administration);
            }

            return (_tabFormPage);
        }

        public override string GetName()
        {
            return (LanguageStrings.AppTreatments);
        }

        public override int StatusPanelCount()
        {
            return (_tabFormPage.GetStatusCount());
        }

        public override string StatusPanelText(int index)
        {
            return (_tabFormPage.GetStatusText(index));
        }

        public override string StatusPanelHint(int index)
        {
            return (_tabFormPage.GetStatusHint(index));
        }

        public override int SortOrder()
        {
            return (2050);
        }

        #region Private Members


        #endregion Private Members
    }
}
