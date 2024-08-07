using AdoptionMVCLab.Models;

namespace AdoptionMVCLab.Data.Repos;

//need to dig into what the disposable part does
public interface IAnimalRepository : IDisposable
{
    AnimalModel GetAnimal(int id);
    List<AnimalModel> GetAnimals();
    List<AnimalModel> GetAnimals(string breed);
    void InsertAnimal(AnimalModel animal);
    void UpdateAnimal(AnimalModel animal);
    void DeleteAnimal(AnimalModel animal);
    void Save();
}
