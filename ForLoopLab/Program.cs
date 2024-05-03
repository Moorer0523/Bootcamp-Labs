
//begin 1st ask

bool firstLoop = true;
int userNumber;


do
{
    Console.WriteLine("Hello world!");
    Console.WriteLine("Would you like to continue? Y/N");
    string userInput = Console.ReadLine();
    if (userInput.ToLower().Contains("n"))
        firstLoop = false;
}
while (firstLoop) ;

//begin 2nd ask

bool secondLoop = true;
do
{
    Console.WriteLine("Enter a number:");
    string userInput = Console.ReadLine();

    if (int.TryParse(userInput, out userNumber))
    {
        for (int i = userNumber; i >= 0; i--)
        {
            Console.Write(i);
        }
        //new line between loops
        Console.WriteLine();
        for (int j = 0; j <= userNumber; j++)
        {
            Console.Write(j);
        }
    }
    Console.WriteLine("\nDo you want to continue? y/n");
    userInput = Console.ReadLine();
    if (userInput.ToLower().Contains("n"))
    {
        secondLoop = false;
        Console.WriteLine("Goodbye!");
    }
}
while (secondLoop);

//begin 3rd ask
//bool doorLocked = true;
//int allowedAttempts = 5;
//int currentAttempt = 1;
//string passcodeInput;
//string combination = "13579";

//while (doorLocked)
//{
//    Console.WriteLine("Please input your pin:");
//    passcodeInput = Console.ReadLine();
//    while ((passcodeInput.Length != 5 || passcodeInput != combination) && currentAttempt < allowedAttempts)
//    {
//        Console.WriteLine("Incorrect input. Attempts remaining: " + (allowedAttempts - currentAttempt));
//        passcodeInput = Console.ReadLine();
//        currentAttempt++;

//    }
//    if (currentAttempt < allowedAttempts)
//    {
//        Console.WriteLine("Door unlocked. \nWelcome inside!");
//        doorLocked = false;
//    }
//    else
//    {
//        Console.WriteLine("Attempts exceeded, try again later.");
//        break;
//    }

//}

//begin 4th ask and optional stretch


int allowedAttempts = 5;
string combination = "13579";

bool doorLocked = entryCheck(combination, allowedAttempts);
if (doorLocked)
    Console.WriteLine("Door unlocked, welcome home!");
else
    Console.WriteLine("Attempts exceeded, try again later.");

static bool entryCheck(string combination, int allowedAttempts)
{
    int currentAttempt = 1;

    Console.WriteLine("Please input your pin:");
    string passcodeInput = Console.ReadLine();

    do
    {
        if (passcodeInput == combination)
            return true;

        Console.WriteLine("Incorrect input. Attempts remaining: " + (allowedAttempts - currentAttempt));
        passcodeInput = Console.ReadLine();
        currentAttempt++;
    }
    while (passcodeInput.Length != 5 && currentAttempt < allowedAttempts);

    return false;
}