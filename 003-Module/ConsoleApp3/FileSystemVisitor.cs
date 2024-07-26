
namespace ConsoleApp3
{
    public class FileSystemVisitor
    {
        public event Action StartSearch;
        public event Action FinishSearch;

        public event Action<string> FileFinded;
        public event Action<string> DirectoryFinded;

        private string Path { get; }
        private Func<string, bool>? Filter { get; }

        public FileSystemVisitor(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            Path = path;
        }

        public FileSystemVisitor(string path, Func<string, bool>? filter)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            Path = path;
            Filter = filter;
        }

    public IEnumerable<string> Traverse()
    {
        StartSearch?.Invoke();

        var directoriesToProcess = new Stack<string>();
        directoriesToProcess.Push(Path);

        while (directoriesToProcess.Count > 0)
        {
            var currentDirectory = directoriesToProcess.Pop();
            IEnumerable<string> fileSystemEntries;

            try
            {
                fileSystemEntries = Directory.EnumerateFileSystemEntries(currentDirectory);
            }
            catch (UnauthorizedAccessException)
            {
                continue; // Skip this directory if access is denied
            }

            foreach (var fileSystemEntry in fileSystemEntries)
            {
                if(Filter(fileSystemEntry)) 
                {
                    FileFinded?.Invoke(fileSystemEntry);
                    yield return fileSystemEntry;
                }

                if (Directory.Exists(fileSystemEntry))
                {
                    DirectoryFinded?.Invoke(fileSystemEntry);
                    directoriesToProcess.Push(fileSystemEntry);
                }
            }
        }

        FinishSearch?.Invoke();
    }

    }
}