namespace RestaurantFavesAPI.Models.DTO;

public class UpdateOrderDTO
{
    public string? Description { get; set; }
    public string? Restaurant { get; set; }
    public int? Rating { get; set; }
    public bool? OrderAgain { get; set; }
}
