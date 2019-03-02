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
 *  File: ModuleClass.cs
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

namespace SharedBase.BOL.ModuleDocumentation
{
    /// <summary>
    /// Class holding information and documentation on modules
    /// </summary>
    [Serializable]
    public sealed class ModuleClass : BaseObject
    {
        #region Constructors

        public ModuleClass(Int64 id, bool isPrimary, string name,
            string description)
        {
            ID = id;
            Name = name;
            Description = description;
            IsPrimary = isPrimary;
        }

        public ModuleClass(Int64 id, bool isPrimary, Int64 moduleID, string moduleNamespace, string name, 
            string description, string exampleUsage)
            :this(id, isPrimary, name, description)
        {
            Namespace = moduleNamespace;
            ExampleUsage = exampleUsage;
            ModuleID = moduleID;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID
        /// </summary>
        public Int64 ID { get; internal set; }

        /// <summary>
        /// Namespace module belongs to 
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Name of Module
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of module
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Example usage for module
        /// </summary>
        public string ExampleUsage { get; set; }

        /// <summary>
        /// Module ID
        /// </summary>
        internal Int64 ModuleID { get; set; }


        public ModuleName Module
        {
            get
            {
                return (ModuleNames.Get(ModuleID));
            }
        }

        /// <summary>
        /// Determines wether it's a primary member that shows on the main screen or not
        /// </summary>
        public bool IsPrimary { get; set; }

        /// <summary>
        /// Retrieves a collection of all Members of the class
        /// </summary>
        public ModuleMembers Members
        {
            get
            {
                string cacheName = String.Format(Consts.CACHE_NAME_CLASS_MEMBERS, ID);

                // has it been cached
                CacheItem cachedResult = DAL.DALHelper.InternalCache.Get(cacheName);

                if (cachedResult == null)
                {
                    cachedResult = new CacheItem(cacheName, DAL.FirebirdDB.ModuleClassMemberSelect(this));
                    DAL.DALHelper.InternalCache.Add(cacheName, cachedResult);
                }

                return ((ModuleMembers)cachedResult.Value);
            }
        }

        #endregion Properties

        #region Overridden Methods

        public override void Save()
        {
            DAL.FirebirdDB.ModuleClassUpdate(this);
        }

        #endregion Overridden Methods

        #region Public Methods

        /// <summary>
        /// Add's a new member to the class
        /// </summary>
        /// <param name="memberProperties"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="exceptions"></param>
        /// <param name="exampleUsage"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public ModuleMember AddMember(ModuleProperties memberProperties, string name, string description, 
            string exceptions, string exampleUsage, string returnValue, string returnValueDesc)
        {
            if (returnValue.Contains("`"))
                returnValue = returnValue.Substring(0, returnValue.IndexOf("`"));

            return (DAL.FirebirdDB.ModuleClassMemberInsert(this.ID, memberProperties, name, description, exceptions, exampleUsage, returnValue, returnValueDesc));
        }

        #endregion Public Methods
    }
}
