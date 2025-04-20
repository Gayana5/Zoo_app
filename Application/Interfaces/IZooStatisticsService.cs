namespace Application.Interfaces;

public class ZooStatistics
{
    public int TotalAnimals { get; set; }
    public int TotalEnclosures { get; set; }
    public int FreeEnclosures { get; set; }
}

public interface IZooStatisticsService
{
    ZooStatistics GetStatistics();
}
