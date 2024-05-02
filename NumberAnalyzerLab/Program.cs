//initialize public variables
bool isEven;
bool keepAlive = true;

//start while loop to enable repeat attempts
while (keepAlive)
{

    //Ask for name
    Console.WriteLine("What is your name?");
    string userName = Console.ReadLine();

    Console.WriteLine($"Hi {userName}, pick a number between 1 and 100");
    string userInputNumber = Console.ReadLine();

    //check for valid input
    int.TryParse(userInputNumber, out int userNumber);

    //check odd or even
    if (userNumber % 2 == 0)
    {
        isEven = true;
    }
    else
    {
        isEven = false;
    }

    //check criteria if the number is within range  
    if (userNumber >= 1 && userNumber <= 100)
    {
        //checks the bool to limit number of if/else statements
        //current criteria doesn't include several numbers
        if (isEven)
        {
            if (userNumber >= 2 && userNumber <= 24)
                Console.WriteLine("Even and less than 25");
            else if (userNumber >= 25 && userNumber <= 60)
                Console.WriteLine("Even and between 26 and 60 inclusive.");
            else if (userNumber > 60)
                Console.WriteLine($"Hey {userName}, you typed {userNumber}. Even and greater than 60");
        }
        else
        {
            if (userNumber < 60)
                Console.WriteLine($"Hey {userName}, you typed {userNumber}. Odd and less than 60.");
            else if (userNumber > 60)
                Console.WriteLine($"Hey {userName}, you typed {userNumber}. Odd and greater than 60.");
        }

        //Repeat the program prompt
        Console.WriteLine("You did it! Did you want to run it again? Y/N");
        string repeatInput = Console.ReadLine();
        if (repeatInput.ToLower().Contains("y")) ;
        else
        {
            Console.WriteLine("Thanks for typing numbers.");
            keepAlive = false;
        }
    }
    //retry loop if user input is bad
    else
        Console.WriteLine($"That number is out of range, lets try again {userName}");
}