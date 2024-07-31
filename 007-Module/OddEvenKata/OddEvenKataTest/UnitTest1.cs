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
        Assert.That(oddEven.generateOddEvenSequence(2), Is.EqualTo("1, Even"));
    }
}

public class OddEven {

    private List<string> oddEvenList = new List<string>();

    private void checkForOddEven(int number) {
        if (number % 2 == 0) {
            oddEvenList.Add("Even");
        } else {
            oddEvenList.Add(number.ToString());
        }
    }

    public string generateOddEvenSequence(int number) {
        if (number < 1 && number > 100 ) {
            return "Invalid number";
        }

        for (int i = 1; i <=number; i++) {
            checkForOddEven(i);
        }

        return string.Join(", ", oddEvenList);
    }
}