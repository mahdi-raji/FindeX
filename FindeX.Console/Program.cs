using FindeX.Console.SearchEngine.Base;
using FindeX.Console.SearchEngine.FileMatchStrategy;
using FindeX.Console.SearchEngine.FileSearchStrategy;

Console.WriteLine("Enter File Name: ");
var searchTerm = Console.ReadLine();

Console.WriteLine("Enter File Extension: ");
var searchFileType = Console.ReadLine();

IFileMatchStrategy fileMatchStrategy = new ContainsFileMatchStrategy();
IFileSearchStrategy fileSearchStrategy = new DirectoryFileSearchStrategy(fileMatchStrategy);

if (searchTerm != null)
{
    var searchOptions = new FileSearchOptions()
    {
        SearchTerm = searchTerm,
        FileType = searchFileType
    };
    var searchResult = fileSearchStrategy.Search(searchOptions);

    foreach (var statistic in searchResult.DriveStatistics)
    {
        Console.WriteLine($"Drive: {statistic.DriveName}");
        Console.WriteLine($"Elapsed Time: {statistic.ElapsedTime}");
        Console.WriteLine($"Hit: {statistic.HitCount}");
        Console.WriteLine($"Miss: {statistic.MissCount}");
        Console.WriteLine($"Total Files: {statistic.TotalFiles}");
        Console.WriteLine("----------------------------------------");
    }
}
else
{
    Console.WriteLine("Null File!");
}

Console.ReadLine();