using AutoMapper;
using TicketManagmentSystem.Api.Models;
using TicketManagmentSystem.Api.Models.Dto;

namespace TicketManagmentSystem.Api.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.CustomerName))
                .ForMember(dest => dest.TicketDescription, opt => opt.MapFrom(src => src.TicketCategory.TicketDescription))
                .ReverseMap();
                
            CreateMap<Order, OrderPatchDto>()
                .ReverseMap();
        }
    }
}
