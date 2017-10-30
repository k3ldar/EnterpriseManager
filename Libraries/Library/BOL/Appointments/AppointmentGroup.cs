using System;

namespace Library.BOL.Appointments
{
    [Serializable]
    public sealed class AppointmentGroup : BaseObject
    {
        #region Private Consts


        #endregion Private Consts

        #region Constructors

        public AppointmentGroup(int id, string description)
        {
            ID = id;
            Description = description;
        }

        #endregion Constructors

        #region Properties

        public int ID { get; }

        public string Description { get; set; }

        #endregion Properties

        #region Overridden Methods

        public override void Save()
        {
            DAL.FirebirdDB.AppointmentGroupUpdate(this);
        }

        public override void Delete()
        {
            DAL.FirebirdDB.AppointmentGroupDelete(this);
        }

        #endregion Overridden Methods
    }
}
