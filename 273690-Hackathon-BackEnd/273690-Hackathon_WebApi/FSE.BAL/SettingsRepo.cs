using FSE.BAL.Domain;
using FSE.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSE.BAL
{
    public interface ISettingsRepo
    {
        EventDetails GeAllEventIdList();
       List<PendingFeedback> GetPendingFeedbackByEventId(int eventId);
        int SendMail(List<PendingFeedback> pendingFeedback);

        EventDetails GetEventDetailsById(string id);

        UserDetails GetUserDetails();
        int UpdateUser(User userInfo);
    }
    public class SettingsRepo
    {
        private readonly FeedBackManagementSystemContext _context;

        public SettingsRepo(FeedBackManagementSystemContext context)
        {
            _context = context;
        }
        public EventDetails GeAllEventIdList()
        {
            EventDetails result = new EventDetails();
            var eventDetails = _context.TblEventEnrollmentDetails.ToList();
            result.LatestEventId = eventDetails.OrderByDescending(x => x.EventDate).FirstOrDefault().EventId;
            if (eventDetails != null && eventDetails.Count > 0)
            {
                var items = eventDetails
                .Select(e => new EventNames
                {
                    EventId = e.EventId,
                    EventName = e.EventName

                })
                .ToList();
                result.EventNames = items.GroupBy(x => x.EventId).Select(x => x.FirstOrDefault()).ToList();
            }
            return result;
        }
       
        public List<PendingFeedback> GetPendingFeedbackByEventId(string eventId)
        {
            List<PendingFeedback> result = new List<PendingFeedback>();
            var eventEnrollmentDetails = _context.TblEventEnrollmentDetails.Where(x => x.EventId == eventId).ToList();
            var feedbackDetails = _context.TblFeedbackDetails.Where(x => x.EventId == eventId).ToList();
            var pendingParticipatedlist=eventEnrollmentDetails.Where(e => !feedbackDetails.Any(f => f.EventId == e.EventId && f.EmployeeId==e.EmployeeId));
            var notParticiapted = _context.TblNotParticipated.Where(x => x.EventId == eventId).ToList();
            var pendingnNotParticipatedlist = notParticiapted.Where(e => !feedbackDetails.Any(f => f.EventId == e.EventId && f.EmployeeId == e.EmployeeId));

            var participatedResult = pendingParticipatedlist.Select(e => new PendingFeedback
            {
                EventId = e.EventId,
                EventPrimaryId = e.Id,
                EmployeeId = e.EmployeeId,
                Name = e.EmployeeName,
                EventName = e.EventName,
                UserTypeId = 1,
                UserType = "Participated Users",
                Location = e.BaseLocationId.HasValue ? GeLocationName(e.BaseLocationId.Value) : string.Empty
            })
              .ToList();
            var notParticipatedResult = pendingnNotParticipatedlist.Select(e => new PendingFeedback
            {
                EventId = e.EventId,
                EventPrimaryId = e.Id,
                EmployeeId = e.EmployeeId,
                Name = e.EmployeeId+"@cogniznat.com",
                EventName = e.EventName,
                UserTypeId = 2,
                UserType = "Not Participated Users",
                Location = e.BaseLocationId.HasValue ? GeLocationName(e.BaseLocationId.Value):string.Empty
            })
            .ToList();
            result.AddRange(participatedResult);
            result.AddRange(notParticipatedResult);
            return result;
        }

        public int SendMail(List<PendingFeedback> pendingFeedback)
        {
            int result = 0;
            foreach(var user in pendingFeedback )
            {
                if(user.UserTypeId==1)
                {
                    var participatedUser = _context.TblEventEnrollmentDetails.Where(x=>x.Id==user.EventPrimaryId).FirstOrDefault();
                    participatedUser.IsReminderSent = true;
                    _context.Update(participatedUser);
                    result=_context.SaveChanges();
                }
                else
                {
                    var notParticipatedUser = _context.TblNotParticipated.Where(x=>x.Id==user.EventPrimaryId).FirstOrDefault();
                    notParticipatedUser.IsReminderSent = true;
                    _context.Update(notParticipatedUser);
                    result= _context.SaveChanges();
                }
            }
            return result;
        }

        public int UpdateUser(User userInfo)
        {
            var user = _context.TblLogin.Where(x => x.UserId == userInfo.UserId).FirstOrDefault();
            user.IsActive = userInfo.IsActive;
            user.RoleId = userInfo.SelectedRoleId;
            _context.Update(user);
           return _context.SaveChanges();

        }
        private List<RoleDetails> GetRoles()
        {
            var roles = _context.TblRoleType.ToList();
            List<RoleDetails> result = new List<RoleDetails>();

            result = roles
                .Select(e => new RoleDetails
                {
                    RoleId = e.RoleTypeId,
                    RolenNme = e.RoleType

                })
                .ToList();
            return result;
        }
        public UserDetails GetUserDetails()
        {
            UserDetails userDetails =new  UserDetails();
            
            var roles = GetRoles();
            var loginDetails = _context.TblLogin.ToList();
           
            var user = loginDetails.Select(e => new User
            {
               UserId=e.UserId,
               SelectedRoleId=e.RoleId.Value,
            
               IsActive=e.IsActive

            })
            .ToList();
            userDetails.user = user;
            userDetails.Roles = roles;
            return userDetails;
        }
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
                   // FeedbackDesc = e.Answer//GetEventName(tblEventEnrollmentDetails, e.EmployeeId, e.EventId)

                })
                 .ToList();
                result.LatestFeedback = feedbackUpdates;
                if (tblEventEnrollmentDetails != null && tblEventEnrollmentDetails.Count>0)
                {
                    result.EventName = tblEventEnrollmentDetails.FirstOrDefault().EventName;
                    //result.EventLocation = tblEventEnrollmentDetails.FirstOrDefault().BaseLocation.BaseLocation;
                    result.EventBenificary = tblEventEnrollmentDetails.FirstOrDefault().BeneficiaryName;
                    result.LivesImpacted = tblEventEnrollmentDetails.FirstOrDefault().LivesImpacted;
                    result.VolunteerHours = tblEventEnrollmentDetails.FirstOrDefault().VolunteerHours;
                    result.ParticipatedUsers = tblEventEnrollmentDetails.Count;
                }
                if (tblNotparticipated != null && tblNotparticipated.Count>0)
                {
                    result.ResgisterdNotAttended = tblNotparticipated.Where(x => x.UserCategoryId == 2).Count();
                    result.RegisteredUnregistered = tblNotparticipated.Where(x => x.UserCategoryId == 3).Count();
                }

                if (tblFeedbackDetails != null && tblFeedbackDetails.Count>0)
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
        private string GetEmpName(List<TblEventEnrollmentDetails> eventDetails, int empId, string eventId)
        {
            var evDetails = eventDetails.Where(x => x.EmployeeId == empId && x.EventId == eventId);
            if (evDetails != null && evDetails.Count()>0)
            {
                return evDetails.FirstOrDefault().EmployeeName;
            }
            else
            {
                return string.Empty;
            }
        }
        private string GetBusinessUnitName(int id)
        {
            return _context.TblBusinessUnit.Where(x => x.BusinessUnitId == id).FirstOrDefault().BusinessUnit;
        }
        private string GeLocationName(int id)
        {
            return _context.TblBaseLocation.Where(x => x.BaseLocationId == id).FirstOrDefault().BaseLocation;
        }
    }
}
