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
 *  File: UpdatePOS.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;
using System.IO;

using Shared.Classes;

#pragma warning disable IDE0028

namespace POS.Base.Classes
{
    /// <summary>
    /// Class that updates all plugins within the pos
    /// </summary>
    public class UpdatePOS : ThreadManager
    {
        #region Private Members

        NVPCodec _currentPlugins;

        #endregion Private Members

        #region Constructors

        public UpdatePOS()
            : base (null, new TimeSpan(0, 60, 0), null, 20000)
        {
            _currentPlugins = BuildUpdateList();
            this.HangTimeout = 70;
        }

        #endregion Constructors

        #region Overridden Methods

        protected override bool Run(object parameters)
        {
            if (HasCancelled())
                return (false);

            try
            {
                string newDownloads = Shared.Communication.HttpPost.Post(
                    ConfigurationSettings.Value(ConfigurationSettings.SYSTEM_CONFIG_PLUGIN_UPDATE_URL),
                    _currentPlugins, 250);

                //validity checks
                if (newDownloads == StringConstants.ERROR_UNABLE_TO_CONNECT_REMOTE_SERVER)
                    return (true);

                if (newDownloads == StringConstants.PLUGIN_ERROR_INVALID_HASH)
                    return (false);

                // no updates, try again in an hour
                if (newDownloads == StringConstants.PLUGIN_UPDATES_NONE)
                    return (true);

                if (!String.IsNullOrEmpty(newDownloads))
                {
                    string[] newPlugins = newDownloads.Split(StringConstants.SYMBOL_RETURN_CHAR);

                    foreach (string newFile in newPlugins)
                    {
                        if (String.IsNullOrEmpty(newFile.Trim()))
                            continue;

                        string[] pluginDetails = newFile.Split(StringConstants.SYMBOL_HASH_CHAR);

                        Shared.FileDownload.Download(pluginDetails[1],
                            AppController.POSFolder(FolderType.Plugins, true) + pluginDetails[0],
                            100, 200);
                    }
                }
            }
            catch (Exception err)
            {
                // on error assume that problem communicating with website
                if (err.Message.Contains("asdf"))
                {
                    
                }
            }

            return (true);
        }

        #endregion Overridden Methods

        #region Private Methods

        /// <summary>
        /// Builds a list containing plugins and versions
        /// </summary>
        /// <returns></returns>
        private NVPCodec BuildUpdateList()
        {
            NVPCodec Result = new NVPCodec();
            Result.Add(StringConstants.PLUGIN_STORE, SharedBase.DAL.DALHelper.StoreID.ToString());
            Result.Add(StringConstants.PLUGIN_TILL, SharedBase.DAL.DALHelper.TillID.ToString());
            Result.Add(StringConstants.PLUGIN_UPDATE_ADD_NEW_MODULES, AppController.LocalSettings.PluginsLoadNewModules.ToString());
            Result.Add(StringConstants.PLUGIN_HASH, Shared.Utilities.HashStringMD5(
                String.Format(StringConstants.PREFIX_AND_SUFFIX_HYPHEN,
                SharedBase.DAL.DALHelper.StoreID, SharedBase.DAL.DALHelper.TillID)));

            //string[] pluginFiles = System.IO.Directory.GetFiles(
            //    AppController.POSFolder(FolderType.Plugins, true),
            //    StringConstants.FILE_SEARCH_DLL.Substring(StringConstants.FILE_SEARCH_DLL.IndexOf(StringConstants.SYMBOL_PIPE) + 1),
            //    SearchOption.TopDirectoryOnly);

            List<PluginModule> plugins = PluginManager.PluginModulesGet();

            foreach (PluginModule plugin in plugins)
            {
                FileInfo info = new FileInfo(plugin.PluginFile);
                Result.Add(info.Name, plugin.Version.ProductVersion);
            }

            return (Result);
        }

        #endregion Private Methods
    }
}
