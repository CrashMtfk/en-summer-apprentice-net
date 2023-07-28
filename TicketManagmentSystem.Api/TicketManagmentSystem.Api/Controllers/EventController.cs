using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using TicketManagmentSystem.Api.Models;
using TicketManagmentSystem.Api.Models.Dto;
using TicketManagmentSystem.Api.Repositories;

namespace TicketManagmentSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;

        public EventController(IEventRepository eventRepository, IMapper mapper)
        { 
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public ActionResult<List<EventDto>> GetAll()
        {
            var events = eventRepository.GetAll();

            
            var dtoEvents = events.Select( e => mapper.Map<EventDto>(e));

            return Ok(dtoEvents);
        }

        [HttpGet]
        public ActionResult<EventDto> GetById(int id)
        {
            var @event = eventRepository.GetById(id);

            if(@event == null)
            {
                return NotFound();
            }

            var dtoEvent = mapper.Map<EventDto>(@event);
            return Ok(dtoEvent);
        }

        [HttpPatch]
        public async Task<ActionResult<EventPatchDto>> UpdateEvent(EventPatchDto eventPatch) 
        {
            var eventEntity = await eventRepository.GetById(eventPatch.EventId);
            if(eventEntity == null)
            {
                return NotFound();
            }
            mapper.Map(eventPatch, eventEntity);
            eventRepository.Update(eventEntity);
            return Ok(eventEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEvent(int id)
        {
            var eventEntity = await eventRepository.GetById(id);
            if(eventEntity == null)
            {
                return NotFound();
            }
            eventRepository.Delete(eventEntity);
            return NoContent();
        }
    }
}
