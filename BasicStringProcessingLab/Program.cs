
SentenceSplit();
ListDisplay();

static void SentenceSplit()
{
    while (true)
    {
        Console.WriteLine("Enter a sentence:");
        string[] userInput = Console.ReadLine().Split(" ");
        foreach (string line in userInput)
        {
            Console.WriteLine($"{line}");
        }
        Console.WriteLine("Would you like to continue?");
        if (Console.ReadLine().ToLower().Contains("n"))
            break;
    }
    Console.WriteLine("Goodbye!");
}
static void ListDisplay()
{
    List<string> createdList = new List<string>();
    while (true)
    {
        Console.WriteLine("Enter some text: ");
        createdList.Add(Console.ReadLine());
        Console.WriteLine("You've entered: ");
        for (int i = 0; i < createdList.Count; i++)
        {
            Console.Write($" {createdList[i]}");
        }

        Console.WriteLine("Would you like to continue?");
        if (Console.ReadLine().ToLower().Contains("n"))
            break;
    }
    Console.WriteLine("Goodbye!");
}