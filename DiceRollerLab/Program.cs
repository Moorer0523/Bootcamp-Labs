
DiceRoller diceRoller = new DiceRoller();
diceRoller.runGame();

public class DiceRoller
{
    static int entryQuestions() //verfies acceptable input and then returns dice side value
    {
        Console.WriteLine("Lets roll some dice. To start, how many sides should the dice have?");
        string userInput = Console.ReadLine();
        int maxNumber;
        bool allowedInput = int.TryParse(userInput, out maxNumber);
        while (!allowedInput)
        {
            Console.WriteLine("Error resolving input, try again.");
            userInput = Console.ReadLine();
            allowedInput = int.TryParse(userInput, out maxNumber);
        }
            return maxNumber;
    }

    static int[] mainRoll(int maxNumber) //takes dice side value and t;hen rolls number of dice related to it
    {
        Random rnd = new Random();
        return [rnd.Next(1, maxNumber + 1), rnd.Next(1, maxNumber + 1)];
    }
    static string comboCheck(int[] rolls) //checks for designated combo pairs contained within the dice rolls
    {

        if (rolls.Count(x => x == 1) == 2)
        {
            return "Snake Eyes!";
        }
        else if (rolls.Count(x => x == 1) == 1 && rolls.Count(y => y == 2) == 1)
        {
            return "Ace Deuce!";
        }
        else if(rolls.Count(x => x == 6) == 2)
        {
            return "Box Cars!";
        }
        else
        {
            return string.Empty;
        }
    }

    static string winCondition(int[] rolls) // checks sum of rolls to see if it matches winning conditions.
    {
        int total = rolls.Sum();

        if (total == 7 || total == 11)
        {
            return "Winner!";
        }

        else if (total == 2 || total == 3 || total == 12)
        {
            return "Craps!";
        }
        else
        {
            return string.Empty;
        }
    }
    public void runGame()
    {
        int[] rolls = mainRoll(entryQuestions());
        Console.Write("Your rolls are: ");
        for (int i = 0; i < rolls.Length; i++)
        {
            Console.Write(rolls[i] + " ");
        }
        Console.WriteLine("\nChecking for a matching combo... " + comboCheck(rolls));
        Console.WriteLine("Checking for a winning number... " + winCondition(rolls));

    }
}
