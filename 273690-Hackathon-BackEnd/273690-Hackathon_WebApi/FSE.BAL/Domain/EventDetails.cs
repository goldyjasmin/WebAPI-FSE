using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.BAL.Domain
{
    
    public class EventDetails
    {
        public List<EventNames> EventNames { get; set; }
        public List<LatestFeedback> LatestFeedback { get; set; }

        public int ParticipatedUsers { get; set; }
        public int ResgisterdNotAttended { get; set; }
        public int RegisteredUnregistered { get; set; }
        public string EventName { get; set; }
        public string EventLocation { get; set; }
        public string EventBenificary { get; set; }
        public double? VolunteerHours { get; set; }
        public int? LivesImpacted { get; set; }
        public int? Feedbackcount { get; set; }
        public int? Rating1Count { get; set; }
        public int? Rating2Count { get; set; }
        public int? Rating3Count { get; set; }
        public int? Rating4Count { get; set; }
        public int? Rating5Count { get; set; }
        public string LatestEventId { get; set; }
    }

    public class EventNames
    {
        public string EventId { get; set; }

        public string EventName { get; set; }
    }

    public class LatestFeedback
    {
        public string EmployeeName { get; set; }

        public string FeedbackDesc { get; set; }
    }
}
