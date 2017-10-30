using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

using POS.Base.Plugins;

namespace POS.Base.Classes
{
    public class PluginModule
    {
        #region Private Members

        private string _fileName;

        #endregion Private Members

        #region Constructors


        internal PluginModule(string fileName, string className)
        {
            PluginModuleInstance = null;
            PluginFile = fileName;
            PluginClassName = className;
            IsLoaded = false;
        }

        internal PluginModule(string className)
        {
            PluginModuleInstance = null;
            PluginFile = String.Empty;
            PluginClassName = className;
            IsLoaded = false;
        }

        internal PluginModule (BasePlugin pluginModule, string fileName, string className)
        {
            PluginModuleInstance = pluginModule;
            PluginFile = fileName;
            PluginClassName = className;
            IsLoaded = false;
        }

        #endregion Constructors

        #region Public Methods

        public PluginVersion PluginVersion()
        {
            PluginVersion Result = Plugins.PluginVersion.Version1;

            if (PluginModuleInstance != null)
                Result = PluginModuleInstance.Version();

            return (Result);
        }

        public string Name()
        {
            string Result;

            if (PluginModuleInstance == null)
            {
                Result = Version.FileDescription.Replace(StringConstants.PLUGIN_PREFIX, String.Empty);
            }
            else
                Result = PluginModuleInstance.PluginName();

            return (Result);
        }

        #endregion Public Methods

        #region Properties

        /// <summary>
        /// Plugin Module
        /// </summary>
        public BasePlugin PluginModuleInstance { get; internal set; }

        /// <summary>
        /// File name containing plugin class
        /// </summary>
        public string PluginFile 
        { 
            get
            {
                return (_fileName);
            }
            
            internal set
            {
                _fileName = value;

                if (System.IO.File.Exists(_fileName))
                {
                    Version = FileVersionInfo.GetVersionInfo(_fileName);
                }
                else
                {
                    Version = null;
                }
            }
        }

        /// <summary>
        /// Class name of plugin
        /// </summary>
        public string PluginClassName { get; private set; }

        /// <summary>
        /// Indicates wether the class is active or not
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Determines wether the module is loaded or not
        /// </summary>
        public bool IsLoaded { get; set; }

        /// <summary>
        /// Determines wether the plugin module is disabled or not
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// Determines wether the plugin can be loaded or not
        /// </summary>
        public bool CanLoad { get; set; }

        /// <summary>
        /// Plugin Version
        /// </summary>
        public FileVersionInfo Version { get; private set; }

        #endregion Properties
    }


    public sealed class PluginManagerEventArgs
    {
        #region Constructors

        public PluginManagerEventArgs(PluginModule pluginManager)
        {
            Module = pluginManager;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// ThreadManager object
        /// </summary>
        public PluginModule Module { get; private set; }

        #endregion Properties
    }

    /// <summary>
    /// Delegate used in ThreadManager events
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void PluginManagerEventDelegate(object sender, PluginManagerEventArgs e);


}
