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
 *  File: AutoUpdateRule.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using System;
using System.Collections.Generic;

namespace Library.BOL.DatabaseUpdates
{
    [Serializable]
    public sealed class AutoUpdateRule : BaseObject
    {
        #region Private Members

        private string _upDateColumnNames;

        private List<UpdateColumn> _updateColumns;

        #endregion Private Members

        #region Constructors

        public AutoUpdateRule()
        {
            _updateColumns = new List<UpdateColumn>();
        }

        public AutoUpdateRule(Int64 id, string name, string description, string sqlSelect,
            string sqlColumnNames, string sqlPrimaryColumn, string sqlUpdate, string sqlUpdateColumnNames,
            string sqlUpdateColumnDescriptions, bool useMemberLevel)
            :this()
        {
            ID = id;
            Name = name;
            Description = description;
            Select = sqlSelect;
            ColumnNames = sqlColumnNames;
            PrimaryColumn = sqlPrimaryColumn;
            Update = sqlUpdate;
            UpdateColumnDescriptions = sqlUpdateColumnDescriptions;
            UpdateColumnNames = sqlUpdateColumnNames;
            UseMemberLevel = useMemberLevel;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Unique ID
        /// </summary>
        public Int64 ID { get; private set; }

        /// <summary>
        /// Name of rule
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Description of rule
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Select Statement for rule
        /// </summary>
        public string Select { get; private set; }

        /// <summary>
        /// Column Names within rule
        /// </summary>
        public string ColumnNames { get; private set; }
        
        /// <summary>
        /// Primary Column
        /// </summary>
        public string PrimaryColumn { get; private set; }
        
        /// <summary>
        /// Update SQL
        /// </summary>
        public string Update { get; private set; }
        
        /// <summary>
        /// Update Column Names
        /// </summary>
        public string UpdateColumnNames 
        { 
            get
            {
                return (_upDateColumnNames);
            }

            private set
            {
                _upDateColumnNames = value;
                _updateColumns.Clear();

                string[] Columns = _upDateColumnNames.Split(';');
                string[] friendlyNames = UpdateColumnDescriptions.Split(';');
                int idx = 0;

                foreach (string column in Columns)
                {
                    if (String.IsNullOrEmpty(column))
                        continue;

                    UpdateColumn uc = new UpdateColumn();
                    uc.Update(column, friendlyNames[idx]);
                    _updateColumns.Add(uc);

                    idx++;
                }
            }
        }

        public List<UpdateColumn> UpdateColumns
        {
            get
            {
                return (_updateColumns);
            }
        }

        /// <summary>
        /// Update Column Description
        /// </summary>
        public string UpdateColumnDescriptions { get; private set; }
        
        /// <summary>
        /// If true then member level is part of the SQL
        /// </summary>
        public bool UseMemberLevel { get; private set; }

        /// <summary>
        /// Generated SQL for rule
        /// </summary>
        public string SQL { get; private set; }

        #endregion Properties

        #region Public Methods

        public void GenerateSQL(AutoUpdateItems items)
        {
            string sql = this.Update;

            foreach (UpdateColumn column in this.UpdateColumns)
            {
                if (column.ColumnType == Shared.ColumnType.Boolean)
                    sql = sql.Replace(String.Format("@{0}", column.Name), (bool)column.Value ? "Y" : "N");
                else
                    sql = sql.Replace(String.Format("@{0}", column.Name), column.Value.ToString());
            }

            bool first = true;
            string values = String.Empty;

            foreach (AutoUpdateItem item in items)
            {
                if (first)
                {
                    values = item.ID.ToString();
                    first = false;
                }
                else
                {
                    values = values + String.Format(", {0}", item.ID.ToString());
                }
            }

            sql = sql.Replace("@ID_RECORDS", values);
            SQL = sql;
        }

        public int TestSQL()
        {
            return (DAL.FirebirdDB.AutoUpdateExecute(this, true));
        }

        public AutoUpdateItems GetItems()
        {
            return (DAL.FirebirdDB.AutoUpdateItemsGet(this));
        }

        #endregion Public Methods

        #region Overridden Methods

        public override void Save()
        {
            DAL.FirebirdDB.AutoUpdateRulesSave(this);
        }

        #endregion Overridden Methods
    }
}
