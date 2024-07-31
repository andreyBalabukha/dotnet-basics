namespace OddEvenKataTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var oddEven = new OddEven();
        oddEven.generateOddEvenSequence(10);
        Assert.Pass();
    }
}