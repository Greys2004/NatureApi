namespace NatureApi.Models.DTOs;

public class TrailDto
{
    public int Id { get; set; }
    public int PlaceId { get; set; }
    public string Name { get; set; }
    public double DistanceKm { get; set; }
    public int EstimatedTimeMinutes { get; set; }
    public string Difficulty { get; set; }
    public bool IsLoop { get; set; }
}