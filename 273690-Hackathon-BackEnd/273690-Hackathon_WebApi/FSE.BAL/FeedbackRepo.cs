using FSE.BAL.Domain;
using FSE.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSE.BAL
{
    public interface IFeedbackRepo
    {
        int Save(Feedback tblFeedbackDetails);

        Feedback EventDetailsForFeedbackPage(string id, int empId,int userType);
    }
    public class FeedbackRepo: IFeedbackRepo
    {
        private readonly FeedBackManagementSystemContext _context;

        public FeedbackRepo(FeedBackManagementSystemContext context)
        {
            _context = context;
        }


        public int Save(Feedback feedbackDetails)
        {
            
            TblFeedbackDetails obj = new TblFeedbackDetails();
            obj.EmployeeId = feedbackDetails.EmployeeId;
            obj.EventId = feedbackDetails.EventId;
            obj.FeedbackOptionId = feedbackDetails.FeedbackOptionId;
            obj.RatingId = feedbackDetails.RatingId;
            obj.UserCategoryId = feedbackDetails.UserCategoryId;
            obj.Answer1 = feedbackDetails.Qstn1Ans;
            obj.Answer2 = feedbackDetails.Qstn2Ans;
            _context.TblFeedbackDetails.Add(obj);
           return _context.SaveChanges();
        }

       public Feedback EventDetailsForFeedbackPage(string id, int empId, int userType)
        {
            Feedback result = new Feedback();

            var eventDetails = _context.TblEventEnrollmentDetails.Where(x => x.EventId == id );
            bool isAuthorized = false;
            if(userType==1)
            {
                isAuthorized= eventDetails.Any(x => x.EventId == id && x.EmployeeId == empId);
                var eventInfo = eventDetails.Where(x => x.EventId == id && x.EmployeeId == empId);
                if (eventInfo != null && eventInfo.Count() > 0)
                {
                    result.EventName = eventInfo.FirstOrDefault().EventName;
                    result.EventBenificary = eventInfo.FirstOrDefault().BeneficiaryName;
                    result.LivesImpacted = eventInfo.FirstOrDefault().LivesImpacted.HasValue ? eventInfo.FirstOrDefault().LivesImpacted.Value:0;
                    result.IsAuthorized = isAuthorized;
                }
            }
            else
            {
                var notparticipated = _context.TblNotParticipated.Where(x => x.EventId == id && x.EmployeeId == empId);
                if (notparticipated != null && notparticipated.Count() > 0)
                {
                    result.IsAuthorized = notparticipated.Any();
                    result.EventName = notparticipated.Where(x => x.EventId == id && x.EmployeeId == empId).FirstOrDefault().EventName;
                    result.EventBenificary = notparticipated.Where(x => x.EventId == id && x.EmployeeId == empId).FirstOrDefault().BeneficiaryName;
                    result.LivesImpacted = eventDetails.Where(x => x.EventId == id).FirstOrDefault().LivesImpacted.HasValue? eventDetails.Where(x => x.EventId == id).FirstOrDefault().LivesImpacted.Value:0;
                }
            }
           
            return result;
        }
    }
}
