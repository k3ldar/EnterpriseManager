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
 *  File: ModuleMember.cs
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
    [Serializable]
    public sealed class ModuleMember
    {
        #region Constructors

        public ModuleMember (Int64 id, Int64 classID, ModuleProperties properties,
            string name, string description, string exceptions, string exampleUsage,
            string returnValue, string returnDescription)
        {
            ID = id;
            ClassID = classID;
            Properties = properties;
            Name = name;
            Description = description;
            Exceptions = exceptions;
            ExampleUsage = exampleUsage;
            ReturnValue = returnValue;
            ReturnValueDescription = returnDescription;
        }

        #endregion Constructors

        #region Properties

        public Int64 ID { get; internal set; }


        internal Int64 ClassID { get; set; }

        public ModuleClass Class
        {
            get
            {
                return ModuleClasses.Get(ClassID);
            }
        }

        public ModuleProperties Properties { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public string Exceptions { get; set; }


        public string ExampleUsage { get; set; }


        public string ReturnValue { get; set; }

        public string ReturnValueDescription { get; set; }

        public string ReturnValueShort
        {
            get
            {
                string retVal = ReturnValue;

                switch (retVal)
                {
                    case "Boolean":
                    case "System.Boolean":
                        return "bool";
                    case "Byte":
                    case "System.Byte":
                        return "byte";
                    case "Double":
                    case "System.Double":
                        return "double";
                    case "Decimal":
                    case "System.Decimal":
                        return "decimal";
                    case "Char":
                    case "System.Char":
                        return "char";
                    case "SByte":
                    case "System.SByte":
                        return "sbyte";
                    case "Object":
                    case "System.Object":
                        return "object";
                    case "UInt64":
                    case "System.UInt64":
                        return "ulong";
                    case "Int64":
                    case "System.Int64":
                        return "long";
                    case "UInt32":
                    case "System.UInt32":
                        return "uint";
                    case "Int32":
                    case "System.Int32":
                        return "int";
                    case "Single":
                    case "System.Single":
                        return "float";
                    case "Int16":
                    case "System.Int16":
                        return "short";
                    case "UInt16":
                    case "System.UInt16":
                        return "ushort";
                    case "String":
                    case "System.String":
                        return "string";
                    case "Void":
                        return "void";
                    default:
                        if (retVal.Contains("."))
                            return retVal.Substring(retVal.LastIndexOf(".") + 1);
                        else
                            return retVal;
                }
            }
        }

        public ModuleParameters Parameters
        {
            get
            {
                string cacheName = String.Format(Consts.CACHE_NAME_CLASS_MEMBER_PARAMS, ID);

                // has it been cached
                CacheItem cachedResult = DAL.DALHelper.InternalCache.Get(cacheName);

                if (cachedResult == null)
                {
                    cachedResult = new CacheItem(cacheName, DAL.FirebirdDB.ModuleClassMemberParameterSelect(this));
                    DAL.DALHelper.InternalCache.Add(cacheName, cachedResult);
                }

                return (ModuleParameters)cachedResult.Value;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Adds a new parameter to the member
        /// </summary>
        /// <param name="name"></param>
        /// <param name="properties"></param>
        /// <param name="parameterType"></param>
        /// <param name="description"></param>
        /// <param name="paramType"></param>
        /// <param name="exampluUsage"></param>
        /// <returns></returns>
        public ModuleParameter AddParameter(string name, ModuleProperties 
            properties, int parameterType, string description, string paramType, 
            string exampluUsage, string defaultValue, int sortOrder)
        {
            if (paramType.Contains("`"))
                paramType = paramType.Substring(0, paramType.IndexOf("`"));

            return DAL.FirebirdDB.ModuleClassMemberParameterInsert(this.ID, name, 
                properties, parameterType, description, paramType, exampluUsage,
                defaultValue, sortOrder);
        }

        /// <summary>
        /// Saves an instance of this class
        /// </summary>
        public void Save()
        {
            foreach (ModuleParameter parm in Parameters)
            {
                parm.Save();
            }

            DAL.FirebirdDB.ModuleClassMemberUpdate(this);
        }

        #endregion Public Methods
    }
}
