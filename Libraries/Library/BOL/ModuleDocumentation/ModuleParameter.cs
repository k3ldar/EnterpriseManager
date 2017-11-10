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
 *  File: ModuleParameter.cs
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

namespace Library.BOL.ModuleDocumentation
{
    [Serializable]
    public sealed class ModuleParameter
    {
        #region Constructors

        public ModuleParameter (Int64 id, Int64 classMemberID, string name,
            ModuleProperties properties, int paramType, string description,
            string parameterType, string exampleUsage, string defaultValue, 
            int sortOrder)
        {
            ID = id;
            ClassMemberID = classMemberID;
            Name = name;
            Properties = properties;
            ParameterType = paramType;
            ParamType = parameterType;
            ExampleUsage = exampleUsage;
            Description = description;
            SortOrder = sortOrder;
            DefaultValue = defaultValue;
        }

        #endregion Constructors

        #region Properties

        public Int64 ID { get; set; }


        internal Int64 ClassMemberID { get; set; }


        public string Name { get; set; }


        public string ShortName
        {
            get
            {
                string Result = Name;

                if (Result.Contains("."))
                {
                    Result = Result.Substring(Result.LastIndexOf('.') + 1);
                }

                return (Result);
            }
        }


        public ModuleProperties Properties { get; set; }


        public int ParameterType { get; set; }

        public string ParamTypeShort
        {
            get
            {
                string Result = ParamType;

                switch (Result)
                {
                    case "System.Boolean":
                        return ("bool");
                    case "System.Byte":
                        return ("byte");
                    case "System.Double":
                        return ("double");
                    case "System.Decimal":
                        return ("decimal");
                    case "System.Char":
                        return ("char");
                    case "System.SByte":
                        return ("sbyte");
                    case "System.Object":
                        return ("object");
                    case "System.UInt64":
                        return ("ulong");
                    case "System.Int64":
                        return ("long");
                    case "System.UInt32":
                        return ("uint");
                    case "System.Int32":
                        return ("int");
                    case "System.Single":
                        return ("float");
                    case "System.Int16":
                        return ("short");
                    case "System.UInt16":
                        return ("ushort");
                    case "System.String":
                        return ("string");
                    default:
                        if (Result.Contains("."))
                            return (Result.Substring(Result.LastIndexOf(".") + 1));
                        else
                            return (Result);
                }
            }
        }

        public string ParamType { get; set; }

        public string Description { get; set; }

        public string ExampleUsage { get; set; }

        public string DefaultValue { get; set; }

        public int SortOrder { get; set; }

        #endregion Properties

        #region Public Methods

        public string GetDefaultValue()
        {
            if (Properties.HasFlag(ModuleProperties.IsOptional))
            {
                string dv = "null";

                if (ParamTypeShort == "string")
                {
                    return(String.Format(" = \"\"", DefaultValue.ToLower()));
                }
                else if (ParamTypeShort == "bool")
                {
                    return(String.Format(" = {0}", DefaultValue.ToLower()));
                }
                else
                    return(String.Format(" = {0}", String.IsNullOrEmpty(DefaultValue) ? dv : DefaultValue));
            }
            else
                return(String.IsNullOrEmpty(DefaultValue) ? String.Empty : String.Format(" = {0}", DefaultValue));

        }

        public void Save()
        {
            DAL.FirebirdDB.ModuleClassMemberParameterUpdate(this);
        }

        #endregion Public Methods
    }
}
