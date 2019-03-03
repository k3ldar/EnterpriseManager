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
 *  File: CalendarReports.cs
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

using SharedControls.Forms;

using SharedBase.BOL.Appointments;
using SharedBase.BOL.Therapists;
using Reports.Salons;

namespace Reports.Salons
{
    public partial class CalendarReports : BaseForm
    {
        private Therapists _therapists;

        #region Constructor

        public CalendarReports()
        {
            InitializeComponent();
            _therapists = Therapists.Get();

            cmbReportType.SelectedIndex = 0;

            cmbEmployee.DataSource = Therapists.Get();
            UpdateUI();
        }

        #endregion Constructor

        #region Public Methods

        public static void ViewSalonReportsA(Appointments appointments)
        {
            try
            {
                CalendarReports reports = new CalendarReports();
                try
                {
                    reports.AllAppointments = appointments;
                    reports.ShowDialog();
                }
                finally
                {
                    reports.Dispose();
                    reports = null;
                }
            }
            catch (Exception err)
            {
                SharedBase.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
                throw;
            }
        }

        public static void ViewSalonReports()
        {
            try
            {
                CalendarReports reports = new CalendarReports();
                try
                {
                    reports.ShowDialog();
                }
                finally
                {
                    reports.Dispose();
                    reports = null;
                }
            }
            catch (Exception err)
            {
                SharedBase.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err);
                throw;
            }
        }

        #endregion Public Methods

        #region Overridden Methods

        #endregion Overridden Methods

        #region Properties

        /// <summary>
        /// All appointments loaded in memory
        /// </summary>
        public Appointments AllAppointments { get; set; }

        #endregion Properties

        #region Private Methods

        private void UpdateUI()
        {
            switch (cmbReportType.SelectedIndex)
            {
                case 0: //Daily
                case 2: //daily product sales
                    lblFrom.Text = "Select Date";
                    lblTo.Enabled = false;
                    dtpTo.Enabled = false;

                    break;
                case 1: // Monthly
                case 3: //monthly product sales
                case 4: // changed appointments
                case 5: // changed appointments (not Arrived/Confirmed)
                case 6: // Cancelled Appointments
                case 7: // summary of total
                    lblFrom.Text = "Start Date";
                    lblTo.Text = "End Date";
                    lblTo.Enabled = true;
                    dtpTo.Enabled = true;

                    break;

                default:
                    throw new Exception("Invalid Report Type");
            }

            cmbEmployee.Enabled = cmbReportType.SelectedIndex == 200;
            lblEmployee.Enabled = cmbReportType.SelectedIndex == 200;
        }

        private void cmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void cmbEmployee_Format(object sender, ListControlConvertEventArgs e)
        {
            Therapist therapist = (Therapist)e.ListItem;
            e.Value = therapist.EmployeeName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cmbReportType.SelectedIndex)
                {
                    case 0: //Daily Salon Report
                        PDFDailySalonReport rpt = new PDFDailySalonReport(dtpFrom.Value.Date, dtpFrom.Value.Date, _therapists, "");
                        rpt.View();
                        break;
                    case 1: // Date Period
                        PDFDailySalonReport rptPeriod = new PDFDailySalonReport(dtpFrom.Value.Date, dtpTo.Value.Date, _therapists, "");
                        rptPeriod.View();
                        break;
                    case 2: //Daily Salon Product Sales
                        PDFTherapistProductSales rptSales = new PDFTherapistProductSales(dtpFrom.Value.Date, dtpFrom.Value.Date, _therapists, "");
                        rptSales.View();
                        break;
                    case 3: //Monthly Salon Product Sales
                        PDFTherapistProductSales rptSalesPeriod = new PDFTherapistProductSales(dtpFrom.Value.Date, dtpTo.Value.Date, _therapists, "");
                        rptSalesPeriod.View();
                        break;
                    case 4: // changed appointments
                    case 5: //changed appointments (not Arrived/Confirmed)
                        Appointments changed = BuildAppointmentDifferenceList(cmbReportType.SelectedIndex == 4 ? false : true);
                        PDFChangedAppointments rptChangedAppointments = new PDFChangedAppointments(dtpFrom.Value.Date, dtpTo.Value.Date, changed);
                        rptChangedAppointments.View();
                        break;
                    case 6: // Cancelled Appointments
                        Appointments cancelled = BuildCancelledAppointments();
                        PDFCancelledAppointments rptCancelled = new PDFCancelledAppointments(dtpFrom.Value.Date, dtpTo.Value.Date, cancelled);
                        rptCancelled.View();
                        break;
                    case 7: // summary of total
                        PDFAppointmentSummary rptSummary = new PDFAppointmentSummary(dtpFrom.Value.Date, dtpTo.Value.Date);
                        rptSummary.View();
                        break;
                    default:
                        throw new Exception("Invalid Report Type");
                }
            }
            catch (Exception err)
            {
                ShowError("View Report", err.Message);
                SharedBase.ErrorHandling.LogError(System.Reflection.MethodBase.GetCurrentMethod(), err, sender, e);
            }

            //DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private Appointments BuildCancelledAppointments()
        {
            Appointments Result = new Appointments();

            foreach (Appointment appt in AllAppointments)
            {
                if (appt.AppointmentType == 0 && Shared.Utilities.DateWithin(dtpFrom.Value, dtpTo.Value, appt.LastAltered))
                {
                    if (appt.Status == SharedBase.Enums.AppointmentStatus.CancelledByStaff ||
                        appt.Status == SharedBase.Enums.AppointmentStatus.CancelledByUser)
                    {
                        Result.Add(appt);
                    }
                }
            }

            return (Result);
        }

        private Appointments BuildAppointmentDifferenceList(bool ignoreArriveComplete)
        {
            Appointments Result = new Appointments();

            foreach (Appointment appt in AllAppointments)
            {
                if (appt.AppointmentType == 0 && Shared.Utilities.DateWithin(dtpFrom.Value, dtpTo.Value, appt.LastAltered))
                {
                    if (ignoreArriveComplete)
                    {
                        foreach (AppointmentChangeItem changes in appt.History())
                        {
                            if (changes.StatusArrivedCompleteConfirmed(appt))
                            {
                                Result.Add(appt);
                                break;
                            }
                        }
                    }
                    else
                        Result.Add(appt);
                }
            }

            return (Result);
        }

        #endregion Private Methods
    }
}
