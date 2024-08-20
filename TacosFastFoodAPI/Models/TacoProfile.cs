using AutoMapper;
using TacosFastFoodAPI.Models.Dto;

namespace TacosFastFoodAPI.Models;

public class TacoProfile : Profile
{
    public TacoProfile()
    {
        CreateMap<Taco, TacoDto>();
    }
}
