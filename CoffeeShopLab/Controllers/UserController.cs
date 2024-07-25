using CoffeeShopLab.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopLab.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(UserModel user) 
        {
            return View();
        }
    }
}
