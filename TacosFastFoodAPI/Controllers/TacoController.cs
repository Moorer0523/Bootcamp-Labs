using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacosFastFoodAPI.Data;
using TacosFastFoodAPI.Models;
using TacosFastFoodAPI.Models.Dto;

namespace TacosFastFoodAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class TacoController : ControllerBase
{
    private readonly TacoDBContext _tacoDB;

    public TacoController(TacoDBContext tacoDB)
    {
        _tacoDB = tacoDB;
    }

    [HttpGet]
    public IActionResult GetAllTacos([FromQuery]bool? softShell)
    {
        if (softShell == null)
            return Ok(_tacoDB.Tacos.ToList());

        return Ok(_tacoDB.Tacos.Where(x => x.SoftShell == softShell).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetTacoById(int id)
    {
        var taco = _tacoDB.Tacos.Find(id);

        if (taco == null)
            return NotFound();
        
        return Ok(taco);
    }

    [HttpPost]
    public IActionResult CreateTaco([FromBody] TacoDto taco)
    {
        Taco newTaco = new()
        {
            Name = taco.Name,
            Cost = taco.Cost,
            SoftShell = taco.SoftShell,
            Chips = taco.Chips
        };

        _tacoDB.Add(newTaco);
        _tacoDB.SaveChanges();

        return Created($"/tacos/{newTaco.Id}",newTaco);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTaco(int id)
    {
        var taco = _tacoDB.Tacos.Find(id);

        if (taco == null)
            return NotFound();

        _tacoDB.Remove(taco);
        _tacoDB.SaveChanges();

        return NoContent();
    }
}

//Get, get id, post, delete
