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
 *  File: Download.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.ComponentModel;
using System.Reflection;

using Shared.Classes;

namespace Library
{
    public static class FileDownload
    {
        private static bool _downloading = false;

        public static bool Downloading
        {
            get
            {
                return (_downloading);
            }
        }

        public static void Download(string SourceFile, string DestinationFile)
        {
            try
            {
                _downloading = true;
                WebClientEx client = new WebClientEx();
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                Uri uri = new Uri(SourceFile);
                client.DownloadFileAsync(uri, DestinationFile);
            }
            catch (Exception err)
            {
                _downloading = false;
                Library.ErrorHandling.LogError(MethodBase.GetCurrentMethod(), err, SourceFile, DestinationFile);
            }
        }

        private static void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _downloading = false;
        }

    }
}
