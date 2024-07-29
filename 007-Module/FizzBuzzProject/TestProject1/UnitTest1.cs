namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var fizzBuzz = new FizzBuzz(10);
        Assert.Pass();
    }
}

internal class FizzBuzz
{
    private int number;
    public FizzBuzz(int Number)
    {
        number = Number;
    }
}