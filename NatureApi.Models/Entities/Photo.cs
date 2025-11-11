namespace StoreApi.Models.Entities;

public class Photo
{
    public int Id { get; set; }
    public int PlaceId { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    
    //Navegacion
    public int idPlace { get; set; }
    public Place Place { get; set; }
}