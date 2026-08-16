namespace FindeX.Console.SearchEngine.Base;

public interface IFileSearchStrategy
{
    FileSearchResult Search(FileSearchOptions options);
}