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
