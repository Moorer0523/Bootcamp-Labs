using System.Runtime.CompilerServices;

namespace CarLotLab;

public class Car
{
    public string Make {  get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }
    public Car() { }
    public Car(string make, string model, int year, decimal price)
    {
        Make = make;
        Model = model;
        Year = year;
        Price = price;
    }
    public override string ToString()
    {
        return string.Format("{0, 6}{1, 14}{2,8}{3,8}", this.Make, this.Model, this.Year, this.Price);
    }

    public static void ListCars(List<Car> cars)
    {
        for (int i = 0; i < cars.Count(); i++)
        {
            Console.WriteLine($"{i+1}: {cars[i]}");
        }
    }
}
