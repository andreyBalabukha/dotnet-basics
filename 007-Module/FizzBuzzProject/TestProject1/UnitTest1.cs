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
        Assert.AreEqual("1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz", fizzBuzz.GetFizzBuzz());
    }

    [Test]
    public void Test2()
    {
        var fizzBuzz = new FizzBuzz(15);
        Assert.AreEqual("1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, FizzBuzz, Fizz, Buzz", fizzBuzz.GetFizzBuzz());
    }
}

internal class FizzBuzz
{
    private int number;
    public FizzBuzz(int Number)
    {
        number = Number;
    }

    public string GetFizzBuzz() {
        if (number < 1) {
            return "Invalid number";
        }

        List<string> fizzBuzzList = new List<string>();

        for (int i = 1; i <= number; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                fizzBuzzList.Add("FizzBuzz");
            };

            if (i % 3 == 0)
            {
                fizzBuzzList.Add("Fizz");
            }

            if (i % 5 == 0)
            {
                fizzBuzzList.Add("Buzz");
            }

            if (i % 3 != 0 && i % 5 != 0)
            {
                fizzBuzzList.Add(i.ToString());
            }
        }
        
        return string.Join(", ", fizzBuzzList);
    }
}