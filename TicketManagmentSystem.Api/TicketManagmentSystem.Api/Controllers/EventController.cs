using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManagmentSystem.Api.Models.Dto;

namespace TicketManagmentSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            var events = new List<EventDto>();

            events.Add(new EventDto
            {
                EventId = 1,
                EventName = "Test 1",
                EventDescription = "Merge treaba",
                EventType = "Muzica",
                Venue = "Acasa"
            });
            events.Add(new EventDto
            {
                EventId = 2,
                EventName = "Test 2",
                EventDescription = "Nu merge",
                EventType = "Bautura",
                Venue = "La bar"
            });

            return Ok(events);
        }
    }
}
