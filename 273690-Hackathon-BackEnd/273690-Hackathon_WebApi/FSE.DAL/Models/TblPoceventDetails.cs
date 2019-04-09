using System;
using System.Collections.Generic;

namespace FSE.DAL.Models
{
    public partial class TblPoceventDetails
    {
        public int Id { get; set; }
        public string Pocid { get; set; }
        public string Pocname { get; set; }
        public string PoccontactNo { get; set; }
        public string EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime? EventDate { get; set; }
        public string Month { get; set; }
        public string BeneficiaryName { get; set; }
        public int? BaseLocationId { get; set; }
        public string CouncilName { get; set; }
        public string Project { get; set; }
        public string Category { get; set; }
        public decimal? OverallVolunteringHours { get; set; }
        public int? ActivityType { get; set; }
        public string VenueAddress { get; set; }
        public int? TotalVolunteers { get; set; }
        public decimal? TotalVolunteerHours { get; set; }
        public decimal? TotalTravelHours { get; set; }
        public int? LivesImpacted { get; set; }
        public string Status { get; set; }

        public virtual TblBaseLocation BaseLocation { get; set; }
    }
}
