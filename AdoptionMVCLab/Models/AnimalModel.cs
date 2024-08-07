using System.ComponentModel.DataAnnotations;

namespace AdoptionMVCLab.Models;

public class AnimalModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Pet Name is required")]
    public string PetName { get; set; }
    public string Discription { get; set; }
    public int Age { get; set; }
    public string ImageName { get; set; }
    public SpeciesEnum Species { get; set; }
    public string Breed {  get; set; }
    public bool IsAdopted { get; set; }
}
