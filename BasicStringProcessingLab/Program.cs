
SentenceSplit();
ListDisplay();

static void SentenceSplit()
{
    while (true)
    {
        Console.WriteLine("Enter a sentence:");
        string[] userInput = Console.ReadLine().Split(" ");
        foreach (string word in userInput)
        {
            Console.WriteLine(word);
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

        Console.WriteLine(string.Join(' ', createdList));

        //replace with string join
        //for (int i = 0; i < createdList.Count; i++) 
        //{
        //    Console.Write($" {createdList[i]}");
        //}

        Console.WriteLine("Would you like to continue? Y/N");
        if (Console.ReadLine().ToLower().Contains("n"))
            break;
    }
    Console.WriteLine("Goodbye!");
}