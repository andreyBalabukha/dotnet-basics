namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, bool> filter = (string str) => str.Contains(".cs");

            var fileSystemVisitor = new FileSystemVisitor("/Users/andreybalabukha/Documents/csharp-mentoring-epam/003-module", filter);

            fileSystemVisitor.StartSearch += () => Console.WriteLine("Start search");
            fileSystemVisitor.FinishSearch += () => Console.WriteLine("Finish search");
            fileSystemVisitor.DirectoryFinded += (directory) => Console.WriteLine("Directory: " + directory);
            fileSystemVisitor.FileFinded += (file) => Console.WriteLine("File: " + file);

            var filesList = new List<string>();

            var travrse = fileSystemVisitor.Traverse();


                foreach (var file in travrse)
                {
                    Console.WriteLine(file);
                }
        }
    }
}
