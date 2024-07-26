namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            System.Console.WriteLine("Type any string and press Enter:");
            string? str = System.Console.ReadLine();

            try
            {
                string newString = GetFirstChar(str);
                System.Console.WriteLine("result: " + newString);
            }
            catch (System.ArgumentOutOfRangeException)
            {
                System.Console.WriteLine("String is empty");
            }
        }

        private static string GetFirstChar(string str)
        {
            return str[0].ToString();
        }
    }
}