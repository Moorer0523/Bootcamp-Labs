using AutoMapper;
using TacosFastFoodAPI.Models.Dto;

namespace TacosFastFoodAPI.Models;

public class DrinkProfile : Profile
{
    public DrinkProfile()
    {
        CreateMap<Drink, DrinkDto>();
        CreateMap<UpdateDrinkDto, Drink>();
    }
}
