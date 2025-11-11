namespace StoreApi.Models.Entities;

public class Place
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public int? ElevationMeters { get; set; }
    public bool Accessible { get; set; }
    public double? EntryFee { get; set; }
    public string? OpeningHours { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navegación 1–N
    public List<Trail> Trails { get; set; }
    public List<Photo> Photos { get; set; } 
    public List<Review> Reviews { get; set; }

    // Navegación N–N
    public List<Amenity> Amenities { get; set; }
    public List<PlaceAmenity> PlaceAmenities { get; set; } 
    
}