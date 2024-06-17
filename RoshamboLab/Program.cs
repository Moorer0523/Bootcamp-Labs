using RoshamboLab;

RoshamboProgram roshamboProgram = new RoshamboProgram();
roshamboProgram.HumanOptionChoice();
 class RoshamboProgram
{
    HumanPlayer humanPlayer = new HumanPlayer();
    
    private string EntryQuestions()
    {
        Console.WriteLine("What is your name");
        return Console.ReadLine();
    }
    
    public void HumanOptionChoice()
    {
        while (true)
        {
            Console.WriteLine("Pick a an option: 1) 'Rock' 2) 'Paper' 3) 'Scissors'. ");
            try
            {
                string userInput = Console.ReadLine();
                if (Enum.IsDefined(typeof(RoshamboValue), userInput)) // Doesnt work and needs a refactor
                {

                    humanPlayer.Value = (RoshamboValue)Enum.Parse(typeof(RoshamboValue), userInput);
                    break;
                }
                else if (int.Parse(userInput) < Enum.GetNames(typeof(RoshamboValue)).Length + 1)
                {
                    int x = int.Parse(userInput);
                    humanPlayer.Value = (RoshamboValue)x;
                }
            }
            catch
            {
                Console.WriteLine("Could not find that choice, please try again.");
            }
        }
    }

    //private void 
}
