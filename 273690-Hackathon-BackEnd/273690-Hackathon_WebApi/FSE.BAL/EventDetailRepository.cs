using FSE.BAL.Domain;
using FSE.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using NBench;

namespace FSE.BAL
{
    public interface IEventDetailRepository
    {
        EventDetails GeAllEventIdListByuserId(int userId);
        EventDetails GetEventDetailsById(string id);
    }
   public class EventDetailRepository: IEventDetailRepository
    {
        private readonly FeedBackManagementSystemContext _context;
        private const string AddCounterName = "AddCounter";
        private Counter addCounter;
        private const int AcceptableMinAddThroughput = 20000000;

        public EventDetailRepository(FeedBackManagementSystemContext context)
        {
            _context = context;
        }

      

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            addCounter = context.GetCounter(AddCounterName);

        }

        [PerfBenchmark(RunMode = RunMode.Throughput, TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName, MustBe.GreaterThan, AcceptableMinAddThroughput)]

        public EventDetails GeAllEventIdListByuserId(int userId)
        {
            var role = _context.TblLogin.Where(x => x.UserId == userId.ToString()).FirstOrDefault().RoleId;
            EventDetails result = new EventDetails();
            
           
            if (role == 1)
            {
                var eventDetails = _context.TblEventEnrollmentDetails.ToList();
                if (eventDetails != null && eventDetails.Count > 0)
                {
                    result.LatestEventId = eventDetails.OrderByDescending(x => x.EventDate).FirstOrDefault().EventId;
                    var items = eventDetails
                    .Select(e => new EventNames
                    {
                        EventId = e.EventId,
                        EventName = e.EventName

                    })
                    .ToList();
                    result.EventNames = items.GroupBy(x => x.EventId).Select(x => x.FirstOrDefault()).ToList();
                }
            }
            else
            {
                var pocDetails = _context.TblPoceventDetails.Where(x => x.Pocid == userId.ToString()).ToList();
                
                if (pocDetails != null && pocDetails.Count > 0)
                {
                    result.LatestEventId = pocDetails.OrderByDescending(x => x.EventDate).FirstOrDefault().EventId;
                    var items = pocDetails
                    .Select(e => new EventNames
                    {
                        EventId = e.EventId,
                        EventName = e.EventName

                    })
                    .ToList();
                    result.EventNames = items.GroupBy(x => x.EventId).Select(x => x.FirstOrDefault()).ToList();
                }
            }
            return result;
        }
        private string GetEmpName(List<TblEventEnrollmentDetails> eventDetails,int empId,string eventId )
        {
            var evDetails = eventDetails.Where(x => x.EmployeeId == empId && x.EventId == eventId);
            if (evDetails != null && evDetails.Count() > 0)
            {
                return evDetails.FirstOrDefault().EmployeeName;
            }
            else
            {
                return string.Empty;
            }
        }
        private string GetEventName(List<TblEventEnrollmentDetails> eventDetails, int empId, string eventId)
        {
            var evDetails = eventDetails.Where(x => x.EmployeeId == empId && x.EventId == eventId);
            return eventDetails.FirstOrDefault().EventName;
        }

        [PerfBenchmark(RunMode = RunMode.Throughput, TestMode = TestMode.Test)]
        [CounterThroughputAssertion(AddCounterName, MustBe.GreaterThan, AcceptableMinAddThroughput)]
        public EventDetails GetEventDetailsById(string id)
        {
            EventDetails result = new EventDetails();
            if (!string.IsNullOrEmpty(id))
            {
                var tblEventEnrollmentDetails = _context.TblEventEnrollmentDetails.Where(x => x.EventId == id).ToList();
                var tblNotparticipated = _context.TblNotParticipated.Where(x => x.EventId == id).ToList();
                var tblFeedbackDetails = _context.TblFeedbackDetails.Where(x => x.EventId == id).ToList();
                var latestFeedback = tblFeedbackDetails.TakeLast(5).ToList();
                var feedbackUpdates = latestFeedback.Select(e => new LatestFeedback
                {
                    EmployeeName = GetEmpName(tblEventEnrollmentDetails, e.EmployeeId, e.EventId),
                    FeedbackDesc =( !string.IsNullOrEmpty(e.Answer1)?e.Answer1 + ";":string.Empty) + e.Answer2


               })
               .ToList();
                result.LatestFeedback = feedbackUpdates;
                if (tblEventEnrollmentDetails != null)
                {
                    result.EventName = tblEventEnrollmentDetails.FirstOrDefault().EventName;
                    //result.EventLocation = tblEventEnrollmentDetails.FirstOrDefault().BaseLocation.BaseLocation;
                    result.EventBenificary = tblEventEnrollmentDetails.FirstOrDefault().BeneficiaryName;
                    result.LivesImpacted = tblEventEnrollmentDetails.FirstOrDefault().LivesImpacted;
                    result.VolunteerHours = tblEventEnrollmentDetails.FirstOrDefault().VolunteerHours;
                    result.ParticipatedUsers = tblEventEnrollmentDetails.Count;
                }
                if (tblNotparticipated != null)
                {
                    result.ResgisterdNotAttended = tblNotparticipated.Where(x => x.UserCategoryId == 2).Count();
                    result.RegisteredUnregistered = tblNotparticipated.Where(x => x.UserCategoryId == 3).Count();
                }

                if (tblFeedbackDetails != null)
                {
                    result.Feedbackcount = tblFeedbackDetails.Count;
                    result.Rating1Count = tblFeedbackDetails.Where(x => x.RatingId == 1).Count();
                    result.Rating2Count = tblFeedbackDetails.Where(x => x.RatingId == 2).Count();
                    result.Rating3Count = tblFeedbackDetails.Where(x => x.RatingId == 3).Count();
                    result.Rating4Count = tblFeedbackDetails.Where(x => x.RatingId == 4).Count();
                    result.Rating5Count = tblFeedbackDetails.Where(x => x.RatingId == 5).Count();
                }
            }
            return result;
        }
    }
}
