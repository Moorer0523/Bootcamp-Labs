
namespace RoshamboLab;

public class HumanPlayer : Player
{
    public string Name { get; set; }

    public override RoshamboValue GenerateRoshambo()
    {
        while (true)
        {
            try
            {

                string userInput = Console.ReadLine();
                if (Enum.IsDefined(typeof(RoshamboValue), userInput))
                {
                    Enum.TryParse(userInput, true, out RoshamboValue value);
                    return value;
                }
                Console.WriteLine("Could not find matching value, please try again");
            }
            catch
            {
                Console.WriteLine("Error resolving input");
            }
        }
    }
}
