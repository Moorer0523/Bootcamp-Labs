using AutoMapper;
using RestaurantFavesAPI.Models.DTO;
using System.Xml;


namespace RestaurantFavesAPI.Models.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDTO>();
        CreateMap<UpdateOrderDTO, Order>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
