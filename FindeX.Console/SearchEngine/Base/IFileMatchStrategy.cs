namespace FindeX.Console.SearchEngine.Base;

public interface IFileMatchStrategy
{
    bool IsMatch(string fileName, FileSearchOptions options);
}