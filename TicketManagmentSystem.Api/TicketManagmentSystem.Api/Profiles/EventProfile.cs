using AutoMapper;
using TicketManagmentSystem.Api.Models;
using TicketManagmentSystem.Api.Models.Dto;

namespace TicketManagmentSystem.Api.Profiles;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventDto>().ReverseMap();
        CreateMap<Event, EventPatchDto>().ReverseMap();
    }
}
