using Microsoft.AspNetCore.Mvc;
using TacosFastFoodAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacosFastFoodAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class DrinkController : ControllerBase
{
    private readonly TacoDBContext _tacoDB;

    public DrinkController(TacoDBContext tacoDB)
    {
        _tacoDB = tacoDB;
    }
    // GET: api/<DrinkController>
    [HttpGet]
    public IActionResult GetDrinks()
    {
        return Ok(_tacoDB.Drinks.ToList().OrderBy(x => x.Cost));
    }

    // GET api/<DrinkController>/5
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
    public void Post([FromBody] string value)
    {

    }

    // PUT api/<DrinkController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

}
