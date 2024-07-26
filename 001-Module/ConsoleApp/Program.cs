// See https://aka.ms/new-console-template for more information
Console.WriteLine("Your name: ");
String? str = Console.ReadLine();

if (str != null)
{
    Console.WriteLine("Hello " + str);
}
else
{
    Console.WriteLine("String is null");
}