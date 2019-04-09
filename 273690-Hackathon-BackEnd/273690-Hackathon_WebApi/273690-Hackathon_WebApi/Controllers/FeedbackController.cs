using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FSE.BAL;
using FSE.BAL.Domain;
using FSE.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _273690_Hackathon_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackRepo _repo;
        public FeedbackController(FeedbackRepo repo)
        {
            _repo = repo;
        }
       
        [HttpPost , Route("save")]
        public async Task<ActionResult> PostFeedbackDetails(Feedback feedbackDetails)
        {
            var mytask = Task.Run(() => _repo.Save(feedbackDetails));
            var eventlist = await mytask;
            return NoContent();
        }

        [HttpGet("details/{eventId}/{empId}/{userType}")]
        public async Task<ActionResult<Feedback>> GetEventDetailsById(string eventId, int empId, int userType)
        {
            var mytask = Task.Run(() => _repo.EventDetailsForFeedbackPage(eventId, empId, userType));
            var feedbackInfo = await mytask;
            return feedbackInfo;
        }

    }
}