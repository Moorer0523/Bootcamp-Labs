
using CarLotLab;

List<Car> cars = new()
{
    new UsedCar("Ford", "Ranger", 1984, 7800, 225000.00),
    new UsedCar("Buick", "Century", 1993, 400, 375000.00),
    new UsedCar("Buick", "Lesabre", 2003, 845, 278000.00),
    new Car("Jeep", "Wrangler", 2023, 32000),
    new Car("Chevy", "Equinox", 2024, 26600),
    new Car("Mini", "Countryman", 2024, 43800)
};
while (cars.Count() > 0)
{


    Car.ListCars(cars);

    Console.WriteLine("Which car would you be interested in purchasing? Please input the number of the desired car:");
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int userInput))
        {
            try
            {
                Console.WriteLine($"You've purchased the {cars[userInput - 1].Make} {cars[userInput - 1].Model}.");
                cars.Remove(cars[userInput - 1]);
                break;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Write("That number does not exist in the list of cars. ");
            }

        }
        Console.WriteLine("Error resolving your selection, please try again");
    }
}
Console.WriteLine("You've purchased all the cars. Goodbye");

