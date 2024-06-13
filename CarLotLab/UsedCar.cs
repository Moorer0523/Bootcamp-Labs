using System.Runtime.CompilerServices;

namespace CarLotLab;

public class UsedCar : Car
{
    private double Mileage { get; set; }
    public UsedCar(string make, string model, int year, decimal price, double mileage) : base(make, model, year, price)
    {
        Mileage = mileage;
    }

    public override string ToString() => string.Format("{0, 6}{1, 14}{2,8}{3,8}{4,8}", this.Make, this.Model, this.Year, this.Price, this.Mileage);

    void BuyBack()
    {
        bool keepAlive = true;
        Console.WriteLine("Starting the buyback program. Type cancel at any point to return to the main menu");
        while (keepAlive)
        {
            //TODO need to 
            while (true)
            {

            }
        }
    }
}
