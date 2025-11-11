namespace StoreApi.Models.Entities;

public class Amenity
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Navegacion N-N
    public List<Place> Places { get; set; }
    public List<PlaceAmenity> PlaceAmenities { get; set; }
    
}