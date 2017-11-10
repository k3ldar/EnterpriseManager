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
 *  File: ModuleName.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
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
