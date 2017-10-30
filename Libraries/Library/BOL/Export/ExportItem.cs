using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BOL.Export
{
    [Serializable]
    public sealed class ExportItem : BaseObject
    {
        public ExportItem(Int64 id, string tableName, string columnName, string description, ImportExportOptions options)
        {
            ID = id;
            Table = tableName;
            Column = columnName;
            Description = description;
            Options = options;
            Selected = false;
        }

        #region Properties

        /// <summary>
        /// Unique ID
        /// </summary>
        public Int64 ID { get; internal set; }

        /// <summary>
        /// Table Name
        /// </summary>
        public string Table { get; internal set; }

        /// <summary>
        /// Columnn Name
        /// </summary>
        public string Column { get; internal set; }

        /// <summary>
        /// Description of column
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// Import Export Options
        /// </summary>
        public ImportExportOptions Options { get; internal set; }

        /// <summary>
        /// Indicates whether the item is selected or not
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Position, user defined
        /// </summary>
        public int Position { get; set; }

        #endregion Properties
    }
}
