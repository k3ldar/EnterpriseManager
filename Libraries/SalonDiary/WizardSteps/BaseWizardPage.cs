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
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: BaseWizardPage.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  08/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SalonDiary.WizardSteps
{
    public class BaseWizardPage : UserControl
    {
        #region Virtual Methods

        /// <summary>
        /// Virtual method to be overridden in each wizard page for when Next button is clicked
        /// </summary>
        /// <returns>bool, true if can continue to the next step, otherwise false</returns>
        public virtual bool NextClicked()
        {
            return (true);
        }

        /// <summary>
        /// Virtual method to be overridden in final page prior to Finish being clicked
        /// </summary>
        /// <returns>bool, true if can proceed otherwise false</returns>
        public virtual bool BeforeFinish()
        {
            return (true);
        }

        #endregion Virtual Methods

        #region Internal Methods

        /// <summary>
        /// Shows a confirmation dialog box
        /// </summary>
        /// <param name="Title">Title</param>
        /// <param name="Message">Message / question being asked</param>
        /// <returns>true if user clicks Yes, otherwise false</returns>
        internal bool ShowHardConfirm(string Title, string Message)
        {
            return (MessageBox.Show(Message, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes);
        }

        /// <summary>
        /// Shows a question dialog box
        /// </summary>
        /// <param name="Title">Title</param>
        /// <param name="Message">Question being asked</param>
        /// <returns>True if user clicks Yes, otherwise false</returns>
        internal bool ShowQuestion(string Title, string Message)
        {
            return (MessageBox.Show(Message, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes);
        }

        /// <summary>
        /// Shows an information dialog
        /// </summary>
        /// <param name="Title">Title for information</param>
        /// <param name="Message">Information message</param>
        internal void ShowInformation(string Title, string Message)
        {
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Displays an error dialog
        /// </summary>
        /// <param name="Title">Title of error</param>
        /// <param name="Message">Error Message</param>
        internal void ShowError(string Title, string Message)
        {
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        #endregion Internal Methods
    }
}
