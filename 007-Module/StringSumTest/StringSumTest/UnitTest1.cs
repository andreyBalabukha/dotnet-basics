namespace StringSumTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var stringSumTest = new StringSumTest();

        Assert.That(stringSumTest.getStringSum("", ""), Is.EqualTo(0));
    }

    [Test]
    public void Test2()
    {
        var stringSumTest = new StringSumTest();

        Assert.That(stringSumTest.getStringSum("2", ""), Is.EqualTo(0));
    }

    [Test]
    public void Test3()
    {
        var stringSumTest = new StringSumTest();

        Assert.That(stringSumTest.getStringSum("", "4"), Is.EqualTo(0));
    }

    [Test]
    public void Test4()
    {
        var stringSumTest = new StringSumTest();

        Assert.That(stringSumTest.getStringSum("2", "4"), Is.EqualTo(6));
    }
}

public class StringSumTest
{
    public int getStringSum(string Num1, string Num2) {
        if (Num1 == "" || Num2 == "") {
            return 0;
        } else {
            return int.Parse(Num1) + int.Parse(Num2);
        }
    }
}