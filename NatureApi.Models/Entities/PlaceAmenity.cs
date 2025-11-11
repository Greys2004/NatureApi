namespace StoreApi.Models.Entities;

public class PlaceAmenity
{
    public int PlaceId { get; set; }
    public Place Place { get; set; } 
    
    public int AmenityId { get; set; }
    public Amenity Amenity { get; set; }
}