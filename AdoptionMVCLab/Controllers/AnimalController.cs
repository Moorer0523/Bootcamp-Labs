using AdoptionMVCLab.Data;
using AdoptionMVCLab.Data.Repos;
using AdoptionMVCLab.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdoptionMVCLab.Controllers
{
    public class AnimalController : Controller
    {
        //private AppDbContext _dbContext;

        //public AnimalController(AppDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //WIP Need to figure out how the DB Context is going on

        private IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchResults(string breed)
        {
            var animals = _animalRepository.GetAnimals(breed);
            return View(animals);
        }

        //this is wrong and should get moved to a service? I think? 
        public IActionResult Add(AnimalModel animal) 
        {
            //_dbContext.Add(animal);

            //_dbContext.SaveChanges();
            return View();
        }


    }
}
