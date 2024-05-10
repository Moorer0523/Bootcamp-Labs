
DiceRoller.GameLoop();

public class DiceRoller
{
    private static int[] EntryQuestions() //verfies acceptable input for dice side count and number of rolling dice then returns both values. Revisit later to refactor into single method to call twice
    {
        Console.WriteLine("Lets roll some dice. To start, how many sides should the dice have?");
        string? userInput = Console.ReadLine();
        bool allowedMaxNumberInput = int.TryParse(userInput, out int maxNumber);

        while (!allowedMaxNumberInput) //verify actual input
        {
            Console.WriteLine("Error resolving input, try again. How many sides should the dice have?");
            userInput = Console.ReadLine();
            allowedMaxNumberInput = int.TryParse(userInput, out maxNumber);
        }

        Console.WriteLine("Next, how many dice should we roll?");
        userInput = Console.ReadLine();
        bool allowedDiceNumberInput = int.TryParse(userInput, out int numberOfDice);

        while (!allowedDiceNumberInput) //duplicate effort with different strings...bad
        {
            Console.WriteLine("Error resolving input, try again. Next, how many dice should we roll?");
            userInput = Console.ReadLine();
            allowedDiceNumberInput = int.TryParse(userInput, out numberOfDice);
        }

        return [maxNumber,numberOfDice];
    }

    private static int[] MainRoll(int[] input) //takes dice side value and then rolls number of dice related to it
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
    private static string ComboCheck(int[] rolls, int maxNumber, int numberOfDice) //checks for designated combo pairs contained within the dice rolls
    {
        if (maxNumber == 6 && numberOfDice == 2) //added check to meet request criteria for 2d6 sided dice. conditionals work for any number of dice, but constraining to meet criteria.
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

        else //including section to calculate some form of a return for alternate sized dice and varied number of rolls
        {
            if (rolls.Count(x => x == maxNumber) == numberOfDice)
            {
                return "This is the theoretical best roll! Nice! The chances of that happening are " + (1/(numberOfDice*maxNumber))*100; //revisit later if bored to calculate percent chance of that happening
            }

            else // Given array with numberOfDice length, explore trying to remove duplicate values and counting the number of represented items.
            {
                int[] rollUnique = rolls.Distinct().ToArray(); //remove duplicate values
                Array.Sort(rollUnique);

                foreach (int i in rollUnique)
                {
                    Console.Write($"\nCount of {i}: {rolls.Count(x => x == i)}");
                }
                return string.Empty;
            }
        }
    }
    private static string WinCondition(int[] rolls, int maxNumber, int numberOfDice) // checks sum of rolls to see if it matches winning conditions.
    {
        return rolls.Sum() switch
        {
            
            7 or 10 when maxNumber == 6 && numberOfDice == 2 => "Winner",
            2 or 3 or 12 when maxNumber == 6 && numberOfDice == 2 => "Craps! You achieved a total of 2, 3, or 12",
            _ => string.Empty,
        };

        //replaced in favor of a switch
        //if (total == 7 || total == 11) 
        //    {
        //        return "Winner!";
        //    }

        //    else if (total == 2 || total == 3 || total == 12)
        //    {
        //        return "Craps! You achieved a total of 2, 3, or 12";
        //    }

        //    else
        //    {
        //        return string.Empty;
        //    }

    }
    private static void PlayRound() //primary round loop
    {
        int[] entryResults = EntryQuestions();
        int[] rolls = MainRoll(entryResults);
        string comboMessage = ComboCheck(rolls, entryResults[0], entryResults[1]);
        string winMessage = WinCondition(rolls, entryResults[0], entryResults[1]);

        // added section for improved UX
        if (comboMessage == null) 
        {
            comboMessage = "No matching combinations.";
        }

        if (winMessage == null)
        {
            winMessage = "No matching win conditions.";
        }    


        Console.Write("Your rolls are: ");

        for (int i = 0; i < rolls.Length; i++)
        {
            Console.Write(rolls[i] + " ");
        }

        Console.WriteLine($"\nYour total roll value was {rolls.Sum()}"); //sum all together for criteria requirement

        Console.WriteLine("\nChecking for a matching combo... " + comboMessage); //added entry result values to meet criteria of ask
        Console.WriteLine("Checking for a winning number... " + winMessage);
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
        {
            Console.WriteLine("Thank you for playing.");
            return false;
        }

    }
    public static void GameLoop() //primary gameplay loop
    {
        do PlayRound();
        while (ReplayCheck());
    }
}