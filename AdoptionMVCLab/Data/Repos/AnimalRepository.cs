using AdoptionMVCLab.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptionMVCLab.Data.Repos;

public class AnimalRepository : IAnimalRepository
{
    private AppDbContext _dbContext;

    public AnimalRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    //single pull of animal data
    public AnimalModel GetAnimal(int id)
    {
        return _dbContext.Animals.Find(id);
    }

    //complete pull of animal data
    public List<AnimalModel> GetAnimals() 
    {
        return _dbContext.Animals.ToList();
    }

    //filtered pull of animal data
    public List<AnimalModel> GetAnimals(string breed)
    {
        return _dbContext.Animals.Where(x => x.Breed == breed).ToList();
    }
    //add new animal
    public void InsertAnimal(AnimalModel model)
    {
        _dbContext.Animals.Add(model);
    }
    //update animal
    public void UpdateAnimal(AnimalModel model)
    {
        _dbContext.Entry(model).State = EntityState.Modified;
    }
    //remove animal
    public void DeleteAnimal(AnimalModel inputAnimal)
    {
        AnimalModel animal = _dbContext.Animals.Find(inputAnimal.Id);
        _dbContext.Animals.Remove(animal);
    }
    public void Save()
    {
        _dbContext.SaveChanges();
    }

    //dispose stuff goes here, not sure what its doing and need to dig further
    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
