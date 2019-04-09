using FSE.BAL;
using FSE.BAL.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _273690_Hackathon_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        private readonly EventDetailRepository _repo;

        public EventsController(EventDetailRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("eventnames/{userId}"), Authorize]
       public async Task<ActionResult<EventDetails>> GeAllEventId(int userId)
        {

            var mytask = Task.Run(() => _repo.GeAllEventIdListByuserId(userId));
            var eventlist = await mytask;
                        
            return eventlist;
        }
        [HttpGet("details/{id}"), Authorize]
        public async Task<ActionResult<EventDetails>> GetEventDetailsById(string id)
        {
            var mytask = Task.Run(() => _repo.GetEventDetailsById(id));
            var eventDetails = await mytask;
            return eventDetails;
        }
    }
}