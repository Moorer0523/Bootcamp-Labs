
namespace RoshamboLab;

public class HumanPlayer : Player
{
    public string Name { get; set; }

    public override RoshamboValue GenerateRoshambo()
    {
        return Value;
    }
}
