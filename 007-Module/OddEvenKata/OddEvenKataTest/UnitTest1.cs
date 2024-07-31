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
        Assert.That(oddEven.generateOddEvenSequence(0), Is.EqualTo("Invalid number"));
    }

    [Test]
    public void Test2()
    {
        var oddEven = new OddEven();
        Assert.That(oddEven.generateOddEvenSequence(2), Is.EqualTo("1, Even"));
    }

    [Test]
    public void Test3()
    {
        var oddEven = new OddEven();
        Assert.That(oddEven.generateOddEvenSequence(3), Is.EqualTo("Odd, Even, Odd"));
    }

    [Test]
    public void Test4()
    {
        var oddEven = new OddEven();
        Assert.That(oddEven.generateOddEvenSequence(10), Is.EqualTo("Odd, Prime, Prime, Even, Prime, Even, Prime, Even, Odd, Even"));
    }
}

public class OddEven {

    private List<string> oddEvenList = new List<string>();

    private void checkForOddEven(int number) {
        if (isPrime(number)) {
            oddEvenList.Add("Prime");
        } else if (number % 2 == 0) {
            oddEvenList.Add("Even");
        } else {
            oddEvenList.Add("Odd");
        }
    }

    private bool isPrime(int number) {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        for (int i = 3; i <= Math.Sqrt(number); i += 2) {
            if (number % i == 0) return false;
        }
        return true;
    }

    public string generateOddEvenSequence(int number) {
        if (number < 1 || number > 100 ) {
            return "Invalid number";
        } 

        for (int i = 1; i <=number; i++) {
            checkForOddEven(i);
        }

        return string.Join(", ", oddEvenList);
    }
}