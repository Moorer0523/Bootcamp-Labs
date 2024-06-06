using CircleObjectsLab;

Circle circle = new Circle(CheckInput());

while (true)
{
    Console.WriteLine(string.Format("{0, -20} {1, -20} {2,-20} {3,-20}", "Radius", "Diameter", "Circumfrence", "Area"));
    Console.WriteLine(string.Format("{0, -20} {1, -20} {2,-20} {3,-20}", circle.GetRaidus(), circle.CalculateDiameter(), circle.CalculateCircumference(), circle.CalculateArea()));
    if (!GrowCheck())
        break;
}
double CheckInput()
{
    while (true)
    {
        Console.WriteLine("Please enter a radius");
        if (double.TryParse(Console.ReadLine(), out double radius))
            return radius;
        Console.WriteLine("Error resolving input. Ensure the number being input is a valid option.");
    }
}
bool GrowCheck()
{
    Console.WriteLine("Should the circle grow? y/n");
    if (Console.ReadLine().ToLower().Contains('y'))
    { 
        circle.Grow();
        return true;
    }
        
    return false;
}

