using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException("Invalid number format");
            }

            string trimmedStringValue = stringValue.Trim();

            if (trimmedStringValue.Length == 0)
            {
                    throw new FormatException("Invalid number format");
            }

            bool isNegative = stringValue[0] == '-';
            bool isPositive = stringValue[0] == '+';

            int result = 0;
            int multiflier = 1;

            for (int i = trimmedStringValue.Length -1; i >= ((isNegative || isPositive) ? 1 : 0); i--)
            {
                char c = trimmedStringValue[i];

                System.Console.WriteLine(c);
                if (c < '0' || c > '9')
                {
                    throw new FormatException("Invalid number format");
                }

                result = result + (c - '0') * multiflier;
                multiflier *= 10;
            }
            return isNegative ? -result : result;
        }
    }
}