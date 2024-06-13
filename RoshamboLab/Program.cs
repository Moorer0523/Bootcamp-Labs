using RoshamboLab;

Console.WriteLine("What is your name");
string userName = Console.ReadLine();
while (true)
{
    Console.WriteLine("Who do you want to be your opponent? Your options are:\n1) Rock Player\n2) Random Player");
    string userInput = Console.ReadLine();
    Player opponent = Console.ReadLine().ToLower() switch //dont use a switch this is weird.
    {
        "1" when int.TryParse(userInput,) => new RockPlayer(),
        "2" or 
    }

}


class RoshamboProgram
{
    HumanPlayer humanPlayer = new HumanPlayer();
    
    private string EntryQuestions()
    {
        Console.WriteLine("What is your name");
        return Console.ReadLine();
    }
    
    private void HumanOptionChoice()
    {
        while (true)
        {
            Console.WriteLine("Pick a an option:");
            try
            {
                string userInput = Console.ReadLine();
                if (Enum.TryParse(userInput, true, out RoshamboValue value))
                {
                    humanPlayer.Value = value;
                    break;
                }
            }
            catch
            {
                Console.WriteLine("Could not find matching value, please try again");
            }
        }
    }

    private void 
}
