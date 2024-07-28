List<string> lines = new List<string>(10);

string[] strLines = {"andrei", "Balabukha"};

lines.AddRange(strLines);

System.Console.WriteLine("-->> " + "lines count: " + lines.Count + "  capacity: " + lines.Capacity);

var str1 = lines.Select(x => x.ToUpper()).ToList();

foreach (var line in str1)
{
    System.Console.WriteLine(line);
}

Queue<string> queue = new Queue<string>();

queue.Enqueue("andrei");
var str = queue.Dequeue();
try
{
    var str2 = queue.Dequeue();
    System.Console.WriteLine("-->> " + str + " " + str2);
}
catch (Exception ex)
{
    System.Console.WriteLine("-->> " + ex.Message);
}

queue.Clear();

System.Console.WriteLine("-->> " + "queue count: " + queue.Count);



