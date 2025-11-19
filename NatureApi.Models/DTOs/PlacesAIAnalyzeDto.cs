namespace NatureApi.Models.DTOs;

public class PlaceAIAnalyzeDto
{
    public List<TopCategoryDto> TopCategories { get; set; }
    public DifficultyStatsDto DifficultyStats { get; set; }
    public double AccessiblePercentage { get; set; }
    public List<string> HighlightPlaces { get; set; }
    public List<string> Patterns { get; set; }
}

public class TopCategoryDto
{
    public string Name { get; set; }
    public int Count { get; set; }
}

public class DifficultyStatsDto
{
    public int Easy { get; set; }
    public int Moderate { get; set; }
    public int Hard { get; set; }
}