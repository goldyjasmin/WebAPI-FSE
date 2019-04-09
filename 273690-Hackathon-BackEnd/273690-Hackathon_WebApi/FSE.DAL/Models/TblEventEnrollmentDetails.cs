using System;
using System.Collections.Generic;

namespace FSE.DAL.Models
{
    public partial class TblEventEnrollmentDetails
    {
        public int Id { get; set; }
        public string EventId { get; set; }
        public string EventDescription { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventName { get; set; }
        public string BeneficiaryName { get; set; }
        public string CouncilName { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public double? VolunteerHours { get; set; }
        public double? TravelHours { get; set; }
        public int? LivesImpacted { get; set; }
        public int? BusinessUnitId { get; set; }
        public string Status { get; set; }
        public int? IiepcategoryId { get; set; }
        public int? BaseLocationId { get; set; }
        public bool IsReminderSent { get; set; }

        public virtual TblBaseLocation BaseLocation { get; set; }
        public virtual TblBusinessUnit BusinessUnit { get; set; }
        public virtual TblIiepcategory Iiepcategory { get; set; }
    }
}
