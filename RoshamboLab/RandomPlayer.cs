namespace RoshamboLab;

public class RandomPlayer : Player
{
    public override RoshamboValue GenerateRoshambo()
    {
        Random random = new Random();
        int randNumber = random.Next(0,3);
        return (RoshamboValue)randNumber;
    }
}
