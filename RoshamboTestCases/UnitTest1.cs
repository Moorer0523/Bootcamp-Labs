using RoshamboLab;

namespace RoshamboTestCases;


public class Tests
{
    private RockPlayer _rockPlayer;
    private RandomPlayer _randomPlayer;
    private HumanPlayer _humanPlayer;
    [SetUp]

    public void Setup()
    {
        _rockPlayer = new RockPlayer();
        _randomPlayer = new RandomPlayer();
        _humanPlayer = new HumanPlayer();
    }

    [Test]
    public void TestBadHumanInput()
    {
        Assert.That(Enum.IsDefined(typeof(RoshamboValue), _humanPlayer.GenerateRoshambo()));
    }
}