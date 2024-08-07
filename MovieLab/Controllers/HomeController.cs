using Microsoft.AspNetCore.Mvc;
using MovieLab.Models;
using MovieLab.Services;
using System.Diagnostics;

namespace MovieLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOMDBService _omdbService;
        private readonly IConfiguration _configuration;


        public HomeController(ILogger<HomeController> logger, IOMDBService service, IConfiguration config)
        {
            _logger = logger;
            _omdbService = service;
            _configuration = config;
        }

        [HttpPost]
        public async Task<IActionResult> Search(string movieName)
        {
            var result = await _omdbService.SearchMovies(movieName, _configuration.GetValue<string>("apiKey"));
            return View(result.Search);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
