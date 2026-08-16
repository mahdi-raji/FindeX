namespace FindeX.Console.SearchEngine.Base;

public class DriveSearchStatistic
{
    public string DriveName { get; set; }
    public TimeSpan ElapsedTime { get; set; }
    public long HitCount { get; set; }
    public long MissCount { get; set; }
    public long TotalFiles => HitCount + MissCount;
}