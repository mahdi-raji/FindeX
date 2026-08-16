using FindeX.Console.SearchEngine.Base;

namespace FindeX.Console.SearchEngine.FileMatchStrategy;


public class ContainsFileMatchStrategy : IFileMatchStrategy
{
    public bool IsMatch(string fileName, FileSearchOptions options)
    {
        if (!string.IsNullOrWhiteSpace(options.FileType) && !fileName.EndsWith($".{options.FileType}", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        return Path.GetFileNameWithoutExtension(fileName).Contains(options.SearchTerm, StringComparison.OrdinalIgnoreCase);
    }
}