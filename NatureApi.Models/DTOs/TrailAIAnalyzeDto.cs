namespace NatureApi.Models.DTOs;

public class TrailAIAnalyzeDto
{
    public int TotalTrails { get; set; }
    public double AverageDistanceKm { get; set; }
    public double AverageTimeMinutes { get; set; }
    public DifficultyCountDto DifficultyCounts { get; set; }
    public double LoopPercentage { get; set; }
    public List<NotableTrailDto> NotableTrails { get; set; }
    public List<string> Patterns { get; set; }
}

public class DifficultyCountDto
{
    public int Easy { get; set; }
    public int Moderate { get; set; }
    public int Hard { get; set; }
}

public class NotableTrailDto
{
    public string Name { get; set; }
    public string PlaceName { get; set; }
    public string Reason { get; set; }
}