using System.Diagnostics;
using FindeX.Console.SearchEngine.Base;

namespace FindeX.Console.SearchEngine.FileSearchStrategy;

public class DirectoryFileSearchStrategy : IFileSearchStrategy
{
    private readonly IFileMatchStrategy _fileMatchStrategy;

    public DirectoryFileSearchStrategy(IFileMatchStrategy fileMatchStrategy)
    {
        _fileMatchStrategy = fileMatchStrategy;
    }

    public FileSearchResult Search(FileSearchOptions options)
    {
        var searchResult = new FileSearchResult();

        // options: ( by FileAttributes )
        var enumerationOptions = new EnumerationOptions
        {
            RecurseSubdirectories = true,
            AttributesToSkip = FileAttributes.None
        };

        // options: drive type - drive name
        var drives = DriveInfo.GetDrives()
            .Where(x => x is { IsReady: true, DriveType: DriveType.Fixed });

        foreach (var drive in drives)
        {
            System.Console.WriteLine($"Searching In: {drive.Name} ...");
            
            var stopwatch = Stopwatch.StartNew();

            long hitCount = 0;
            long missCount = 0;

            var files = Directory.EnumerateFiles(drive.RootDirectory.FullName, "*", enumerationOptions);

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);

                if (_fileMatchStrategy.IsMatch(fileName, options))
                {
                    hitCount++;
                    System.Console.WriteLine(file);
                    searchResult.Files.Add(file);
                }
                else
                {
                    missCount++;
                }
            }

            stopwatch.Stop();

            searchResult.DriveStatistics.Add(new DriveSearchStatistic
            {
                DriveName = drive.Name,
                ElapsedTime = stopwatch.Elapsed,
                HitCount = hitCount,
                MissCount = missCount
            });
        }

        return searchResult;
    }
}