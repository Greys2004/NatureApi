namespace StoreApi.Models.Entities;

public class Review
{
    
    public int Id { get; set; }
    public int PlaceId { get; set; }
    public string Author { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    
    //Navegacion
    public int idPlace { get; set; }
    public Place Place { get; set; }
}