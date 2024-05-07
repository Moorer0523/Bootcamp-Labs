
DiceRoller.GameLoop();

public class DiceRoller
{
    private static int[] EntryQuestions() //verfies acceptable input for dice side count and number of rolling dice then returns both values
    {
        Console.WriteLine("Lets roll some dice. To start, how many sides should the dice have?");
        string? userInput = Console.ReadLine();
        
        bool allowedMaxNumberInput = int.TryParse(userInput, out int maxNumber);
        while (!allowedMaxNumberInput)
        {
            Console.WriteLine("Error resolving input, try again.");
            userInput = Console.ReadLine();
            allowedMaxNumberInput = int.TryParse(userInput, out maxNumber);
        }

        Console.WriteLine("Next, how many dice should we roll?");
        userInput = Console.ReadLine();
        bool allowedDiceNumberInput = int.TryParse(userInput, out int numberOfDice);
        while (!allowedDiceNumberInput)
        {
            Console.WriteLine("Error resolving input, try again.");
            userInput = Console.ReadLine();
            allowedDiceNumberInput = int.TryParse(userInput, out numberOfDice);
        }

        return [maxNumber,numberOfDice];
    }

    private static int[] MainRoll(int[] input) //takes dice side value and t;hen rolls number of dice related to it
    {
        int maxNumber = input[0];
        int numberOfDice = input[1];
        int[] rolls = new int[numberOfDice];
        Random rnd = new Random();
        for (int i = 0; i < numberOfDice; i++)
        {
            rolls[i] = rnd.Next(1, maxNumber + 1);
        }
        return rolls;
    }
    private static string ComboCheck(int[] rolls) //checks for designated combo pairs contained within the dice rolls
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
    private static string WinCondition(int[] rolls) // checks sum of rolls to see if it matches winning conditions.
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
    private static void PlayRound() //primary round loop
    {
        int[] rolls = MainRoll(EntryQuestions());
        Console.Write("Your rolls are: ");

        for (int i = 0; i < rolls.Length; i++)
        {
            Console.Write(rolls[i] + " ");
        }

        Console.WriteLine("\nChecking for a matching combo... " + ComboCheck(rolls));
        Console.WriteLine("Checking for a winning number... " + WinCondition(rolls));

    }
    private static bool ReplayCheck() //checks to see if the player would like to start a new round, otherwise returns false
    {
        Console.WriteLine("Would you like to play again?");
        string? userInput = Console.ReadLine();
        bool userInputValid = userInput.ToLower().Contains('y') || userInput.ToLower().Contains('n');

        while (!userInputValid) 
        {
            Console.WriteLine("Error resolving input, please only answer 'y' or 'n'");
            userInput = Console.ReadLine();
            userInputValid = userInput.ToLower().Contains('y') || userInput.ToLower().Contains('n');
        }

        if (userInput.ToLower().Contains('y'))
            return true;
        else
            return false;


    }
    public static void GameLoop() //primary gameplay loop
    {
        do PlayRound();
        while (ReplayCheck());
    }
}