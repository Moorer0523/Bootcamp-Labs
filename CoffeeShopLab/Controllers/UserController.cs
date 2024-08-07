using CoffeeShopLab.Models;
using CoffeeShopLab.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopLab.Controllers;


public class UserController : Controller
{
    //dependency injection (DI)
    private AppDbContext _dbContext;

    public UserController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult RegisterUser(User user) 
    {
        _dbContext.Add(user);

        _dbContext.SaveChanges();

        return RedirectToAction("Index","Home");
    }
}
