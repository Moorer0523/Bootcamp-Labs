using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using TacosFastFoodAPI.Data;
using TacosFastFoodAPI.Models;
using TacosFastFoodAPI.Models.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacosFastFoodAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class DrinkController : ControllerBase
{
    private readonly TacoDBContext _tacoDB;

    private readonly IMapper _mapper;

    public DrinkController(TacoDBContext tacoDB, IMapper mapper)
    {
        _tacoDB = tacoDB;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetDrinks(string? SortByCost)
    {

        if (SortByCost == "ascending")
            return Ok(_tacoDB.Drinks.ToList().OrderBy(x => x.Cost));

        else if (SortByCost == "descending")
            return Ok(_tacoDB.Drinks.ToList().OrderByDescending(x => x.Cost));

        return Ok(_tacoDB.Drinks.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetDrinkByID(int id)
    {
        var drink = _tacoDB.Drinks.Find(id);

        if (drink == null)
            return NotFound();

        return Ok(drink);
    }

    // POST api/<DrinkController>
    [HttpPost]
    public IActionResult CreateDrink([FromBody] DrinkDto drink)
    {
        Drink newDrink = new()
        {
            Name = drink.Name,
            Cost = drink.Cost,
            Slushie = drink.Slushie
        };

        _tacoDB.Add(newDrink);
        _tacoDB.SaveChanges();

        return CreatedAtAction(nameof(GetDrinkByID), new {id = newDrink.Id}, newDrink);
    }

    // PUT api/<DrinkController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateDrinkDto drinkUpdate)
    {
        Drink drink = _tacoDB.Drinks.Find(id);

;
        //automapper push into a drink object
        Drink updatedDrink = _mapper.Map<Drink>(drinkUpdate);

        if (drink == null)
            return NotFound();

        //TODO Work out how to compare and loop through two different object properties
        //Need to figure out how to work with nullable properties.....
        //based on Jonathan's advice, do not do, unmaintable -- Check out automapper https://github.com/AutoMapper/AutoMapper
        //foreach (var updateProperty in drinkUpdate.GetType().GetProperties())
        //{
        //    //attempt second loop to compare 
        //    foreach (var currentProperty in drink.GetType().GetProperties())
        //    {
        //        if (currentProperty.Name == updateProperty.Name)
        //        {
        //            if (currentProperty.GetValue(drink) != updateProperty.GetValue(drinkUpdate))
        //            {
        //                currentProperty.SetValue(drink, updateProperty.GetValue(drinkUpdate));
        //            }
        //        }
        //    }
        //}


        foreach (var property in updatedDrink.GetType().GetProperties())
        {
            var oldValue = property.GetValue(drink);
            var newValue = property.GetValue(updatedDrink);


            //TODO Issue with new values comign up with 0 if omitted from sending statement
            if (oldValue != newValue)
            {
                property.SetValue(drink, newValue);
            }
        }



        //drink.Name = drinkUpdate.Name;
        //drink.Cost = drinkUpdate.Cost;
        //drink.Slushie = drinkUpdate.Slushie;

        return Ok(drink);
    }

}
