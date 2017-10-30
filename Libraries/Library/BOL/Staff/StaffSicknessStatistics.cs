using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.BOL.Staff
{
    public class StaffSicknessStatistics
    {
        public bool CurrentlySick { get; set; }
        public double TotalDays { get; set; }
        public int TotalTimes { get; set; }
        public int Prebooked { get; set; }
        public int Cancelled { get; set; }
        public int SelfCertified { get; set; }
        public double PreviousTotalDays { get; set; }
        public int PreviousTotalTimes { get; set; }
        public int PreviousPrebooked { get; set; }
        public int PreviousCancelled { get; set; }
        public int PreviousSelfCertified { get; set; }
    }
}
