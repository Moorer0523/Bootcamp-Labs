namespace CircleObjectsLab;

internal class Circle
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double CalculateDiameter()
    {
        return radius * 2;
    }
    public double CalculateCircumference()
    {
        return radius * 2 * double.Pi;
    }

    public double CalculateArea()
    {
        return Math.Pow(radius,2) * double.Pi;
    }

    public void Grow()
    {
        radius = radius * 2;
    }

    public double GetRaidus()
    {
        return radius;
    }
}

