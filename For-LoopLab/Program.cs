
do
{
    Console.WriteLine(SumOfAll(UserInput()));
}while (ReplayCheck());

static int UserInput() //start with valid number check loop
{
    Console.WriteLine("Enter a number");
    string userInput = Console.ReadLine();
    bool validInput = int.TryParse(userInput, out int value);

    while (!validInput)
    {
        Console.WriteLine("Invalid input, please enter a valid number: ");
        userInput = Console.ReadLine();
        validInput = int.TryParse(userInput, out value);
    }

    return value; 
}

static int SumOfAll(int value) //constrained to for loop, probably better method to do this. Revisit later?
{
    int sum = 0;

    for (int i = 0; i <= value; i++)
    {

         sum += i;
    }
    return sum;
}
static bool ReplayCheck() //checks to see if the player would like to input a new value, otherwise returns false
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