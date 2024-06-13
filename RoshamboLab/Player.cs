namespace RoshamboLab;

public abstract class Player
{
    public RoshamboValue Value { get; set; }

    public abstract RoshamboValue GenerateRoshambo();
}
