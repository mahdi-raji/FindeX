namespace FindeX.Console.SearchEngine.Base;

public class FileSearchResult
{
    public List<string> Files { get; set; } = [];
    public List<DriveSearchStatistic> DriveStatistics { get; set; } = [];
}