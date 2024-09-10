using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantFavesAPI.Data;
using RestaurantFavesAPI.Models;
using RestaurantFavesAPI.Models.DTO;
namespace RestaurantFavesAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly RestaurantDBContext _context;
    private readonly IMapper _mapper;

    public OrdersController(RestaurantDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Orders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        return await _context.Orders.ToListAsync();
    }

    // GET: api/Orders/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    // PUT: api/Orders/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrder(int id, [FromBody] UpdateOrderDTO orderInputDTO)
    {
        try
        {
            //redo later maybe? Want to find a better way of doing this. pushing entire object as the frontend will be sending the entire object back to me, there will be no partial object that will be sent.
            Order currentOrder = await _context.Orders.FindAsync(id);
            if (currentOrder == null)
            {
                return NotFound();
            }

            Order updatedOrder = _mapper.Map(orderInputDTO, currentOrder);

            _context.Entry(currentOrder).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest();
        }

        return NoContent();
    }

    // POST: api/Orders
    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder([FromBody] OrderDTO orderInputDTO)
    {
        Order order = _mapper.Map<Order>(orderInputDTO);
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetOrder", new { id = order.Id }, order);
    }

    // DELETE: api/Orders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
