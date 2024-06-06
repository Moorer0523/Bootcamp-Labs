using System.Runtime.CompilerServices;

namespace CarLotLab;

public class UsedCar : Car
{
    public double Mileage { get; set; }
    public UsedCar(string make, string model, int year, decimal price, double mileage) : base(make, model, year, price)
    {
        Mileage = mileage;
    }

    public override string ToString()
    {
        return string.Format("{0, 6}{1, 14}{2,8}{3,8}{4,8}", this.Make, this.Model, this.Year, this.Price, this.Mileage);
    }
}
