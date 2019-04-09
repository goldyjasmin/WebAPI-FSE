using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSE.BAL;
using FSE.BAL.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _273690_Hackathon_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {

        private readonly SettingsRepo _repo;
        public SettingsController(SettingsRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("pendingusers/{id}"), Authorize]
        public async Task<ActionResult<List<PendingFeedback>>> GetPendingFeedbackByEventId(string id)
        {

            var mytask = Task.Run(() => _repo.GetPendingFeedbackByEventId(id));
            var pendingList = await mytask;

            return pendingList;
        }

        [HttpPut, Route("sendmail")]
        public async Task<ActionResult> PostFeedbackDetails(List<PendingFeedback> feedbackDetails)
        {
            var mytask = Task.Run(() => _repo.SendMail(feedbackDetails));
            var eventlist = await mytask;
            return NoContent();
        }

        [HttpGet("details/{id}"), Authorize]
        public async Task<ActionResult<EventDetails>> GetEventDetailsById(string id)
        {
            var mytask = Task.Run(() => _repo.GetEventDetailsById(id));
            var eventDetails = await mytask;
            return eventDetails;
        }

        [HttpGet, Route("users"), Authorize]
        public async Task<ActionResult<UserDetails>> GetAllUsers()
        {

            var mytask = Task.Run(() => _repo.GetUserDetails());
            var users = await mytask;

            return users;
        }

        [HttpPut, Route("updateuser")]
        public async Task<ActionResult> PostFeedbackDetails(User userInfo)
        {
            var mytask = Task.Run(() => _repo.UpdateUser(userInfo));
            var eventlist = await mytask;
            return NoContent();
        }
    }
}