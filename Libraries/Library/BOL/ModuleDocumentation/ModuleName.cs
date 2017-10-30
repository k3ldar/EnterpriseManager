using System;
using System.Collections.Generic;
using System.Text;

using Shared.Classes;

namespace Library.BOL.ModuleDocumentation
{
    [Serializable]
    public sealed class ModuleName
    {
        #region Constructors

        public ModuleName(Int64 id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID for module
        /// </summary>
        public Int64 ID { get; set; }

        /// <summary>
        /// Name of module
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of module
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Returns a collection of classes belonging to the Module
        /// </summary>
        public ModuleClasses Classes
        {
            get
            {
                // has it been cached
                CacheItem cachedResult = DAL.DALHelper.InternalCache.Get(String.Format(Consts.CACHE_NAME_MODULE_CLASSES, Name));

                if (cachedResult == null)
                {
                    cachedResult = new CacheItem(String.Format(Consts.CACHE_NAME_MODULE_CLASSES, Name), DAL.FirebirdDB.ModuleClassSelect(this));
                    DAL.DALHelper.InternalCache.Add(String.Format(Consts.CACHE_NAME_MODULE_CLASSES, Name), cachedResult);
                }

                return ((ModuleClasses)cachedResult.Value);
            }
        }

        #endregion Properties

        #region Public Methods


        public ModuleClass AddClass(bool isPrimary, string moduleNamespace, 
            string name, string description, string exampleUsage)
        {
            return (DAL.FirebirdDB.ModuleClassInsert(this.ID, isPrimary, moduleNamespace, name, description, exampleUsage));
        }

        #endregion Public Methods
    }
}
