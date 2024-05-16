

Console.WriteLine(IsPassing(65));
Console.WriteLine(IsPassing(75));


Console.WriteLine(AverageGrades(55,65,75));


Console.WriteLine(OddOrEvenAndPassing(55));
Console.WriteLine(OddOrEvenAndPassing(54));
Console.WriteLine(OddOrEvenAndPassing(85));
Console.WriteLine(OddOrEvenAndPassing(84));
static bool IsPassing(double grade)
{
    return grade > 65;
}

static double AverageGrades(double grade1, double grade2, double grade3)
{
    return (grade1 + grade2 + grade3) / 3;
}

static string OddOrEvenAndPassing(double grade)
{
    bool passed = IsPassing(grade);

    if (passed)
    {
        if (grade % 2 == 0)
            return "Passing and even";
        else
            return "Passing and odd";
    }
    else
    {
        if (grade % 2 == 0)
            return "failing and even";
        else
            return "failing and odd";
    }
}