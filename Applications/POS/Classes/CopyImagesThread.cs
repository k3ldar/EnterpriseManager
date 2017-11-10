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
 *  Copyright (c) 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: CopyImagesThread.cs
 *
 *  Created: 09/06/2017
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  09/06/2017  Simon Carter        Initially Created
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Text;

using SieraDelta.Shared.Classes;

namespace Heavenskincare.PointOfSale.Classes
{
    /// <summary>
    /// Thread which copies images (.jpg, .bmp, .jpeg, .gif, .ico) from one path to another
    /// </summary>
    public class CopyImagesThread : ThreadManager
    {
        #region Private Members

        private string _pathFrom;
        private string _pathTo;

        #endregion Private Members

        #region Constructor

        public CopyImagesThread(string fromPath, string toPath)
            : base (null, new TimeSpan())
        {
            _pathFrom = fromPath;
            _pathTo = toPath;
        }

        #endregion Constructor

        #region Overridden Methods

        protected override bool Run(object parameters)
        {


            return (false);
        }

        #endregion Overridden Methods
    }
}
