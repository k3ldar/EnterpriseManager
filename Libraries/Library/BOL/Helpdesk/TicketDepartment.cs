using System;
using System.Collections.Generic;
#if !ANDROID
using System.Web;
#endif

namespace Library.BOL.Helpdesk
{
    [Serializable]
    public sealed class TicketDepartment : BaseObject
    {
        #region Constructors / Destructors

        public TicketDepartment(int id, string description)
        {
            ID = id;
            Description = description;
        }

        #endregion Constructors / Destructors

        #region Properties

        public int ID { get; set; }

        public string Description { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void Save()
        {
            DAL.FirebirdDB.HelpdeskTicketDepartmentSave(this);
        }

        public override void Delete()
        {
            DAL.FirebirdDB.HelpdeskTicketDepartmentDelete(this);
        }

        #endregion Overridden Methods
    }
}