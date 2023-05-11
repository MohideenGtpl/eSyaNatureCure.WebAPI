using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaNatureCure.DO
{
    public class DO_GuestActivity
    {
        public int BusinessKey { get; set; }
        public long Ipnumber { get; set; }
        public int SerialNumber { get; set; }
        public long HospitalNumber { get; set; }
        public int ActivityId { get; set; }
        public int ActivityDayId { get; set; }
        public DateTime ActivityDate { get; set; }
        public TimeSpan ActivityFromTime { get; set; }
        public TimeSpan ActivityToTime { get; set; }
        public string ActivityStatus { get; set; }
        public bool ReviewGiven { get; set; }
        public int? ServiceRating { get; set; }
        public string RatingComments { get; set; }
        public bool ActiveStatus { get; set; }

        public string ActivityDesc { get; set; }
        public string ScheduleType { get; set; }
        public double ActivityDurationHH { get; set; }
        public double ActivityDurationMM { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentDesc { get; set; }

        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public string ModifiedUser { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

    public class DO_GuestActivityHeader
    {
        public int ActivityDayId { get; set; }
        public DateTime ActivityDate { get; set; }
        public double ActivityDurationHH { get; set; }
        public double ActivityDurationMM { get; set; }
    }
    public class DO_GuestActivities
    {
        public List<DO_GuestActivityHeader> l_activityheader { get; set; }
        public List<DO_GuestActivity> l_activitydetails { get; set; }
    }
}
